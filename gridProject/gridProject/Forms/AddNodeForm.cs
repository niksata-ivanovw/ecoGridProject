using gridProject.Algorithms;
using gridProject.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace gridProject.Forms
{
    public partial class AddNodeForm : Form
    {
        private int _generatedX;
        private int _generatedY;
        private static string connectionString = "Data Source=gridProjectDB.db;Version=3;";
        public int InsertedNodeId { get; private set; } = 0;

        private double generateLossFactor()
        {
            Random random = new Random();

            double min = 0.1;
            double max = 9.9;

            double randomNumber = min + (random.NextDouble() * (max - min));

            double roundedNumber = Math.Round(randomNumber, 1);

            return roundedNumber;
        }

        public AddNodeForm(int x, int y)
        {
            InitializeComponent();

            _generatedX = x;
            _generatedY = y;

            label2.Text = $"Генерирани координати: ({_generatedX}, {_generatedY})";
        }

        private void AddNodeForm_Load(object sender, EventArgs e)
        {
            TreeViewManager.PopulateTreeView(treeView1);
        }

        private void createButton_Click(object sender, EventArgs e)
        {
            string nodeName = textBox1.Text;
            int capacity = numericUpDown1.Value > 0 ? (int)numericUpDown1.Value : 0;
            int priority = numericUpDown2.Value > 0 && numericUpDown2.Value <= 3 ? (int)numericUpDown2.Value : 3;

            string pattern = @"^(?<Type>SRCE|SUST|CON)-(?<Location>[A-Za-zА-Яа-я0-9\s\-_()]+)-(?<Number>[0-9]+)$";

            List<string> validTypes = new List<string> { "SRCE", "SUST", "CON" };

            if (string.IsNullOrWhiteSpace(nodeName))
            {
                MessageBox.Show("Името не може да бъде празно.", "Грешка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (!Regex.IsMatch(nodeName, pattern))
            //@"^(?<Type>SRCE|SUST|CON)-(?<Location>[A-Za-zА-Яа-я0-9\s\-_()]+)-(?<Number>[0-9]+)$";
            {
                MessageBox.Show("Името трябва да съдържа само букви, цифри и допустими символи (-, _, (, )).", "Грешка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                Match match = Regex.Match(nodeName, pattern);

                string objectType = match.Groups["Type"].Value;
                string location = match.Groups["Location"].Value;
                string number = match.Groups["Number"].Value;


                if (GraphManager.NetworkNodes.Values.Any(n => n.Name.Equals(nodeName, StringComparison.OrdinalIgnoreCase)))
                {
                    MessageBox.Show("Вече съществува възел с това име.", "Грешка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (GraphManager.NetworkNodes.Values.Any(n => n.Id.ToString() == number))
                {
                    MessageBox.Show("Вече съществува възел с този номер.", "Грешка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (!validTypes.Contains(objectType))
                {
                    MessageBox.Show("Типът на възела трябва да бъде SRCE, SUST или CON.", "Грешка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                switch (objectType)
                {
                    case "SRCE":
                        objectType = "Source";
                        break;
                    case "SUST":
                        objectType = "Substation";
                        break;
                    case "CON":
                        objectType = "Consumer";
                        break;
                }

                List<int> selectedNodeIds = treeView2.Nodes.Cast<TreeNode>()
                    .Where(n => n.Tag != null)
                    .Select(n => (int)n.Tag)
                    .ToList();

                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();

                    string queryInsertNode = $"INSERT INTO Nodes(Id, Name, Type, Capacity, Priority, X, Y) " +
                        $"VALUES('{number}', '{location}', '{objectType}', {capacity}, {priority}, {_generatedX}, {_generatedY})";
                    using (SQLiteCommand command = new SQLiteCommand(queryInsertNode, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                    using (SQLiteCommand idCmd = new SQLiteCommand("SELECT last_insert_rowid();", connection))
                    {
                        InsertedNodeId = Convert.ToInt32(idCmd.ExecuteScalar());
                    }

                    foreach (int SourceId in selectedNodeIds)
                    {
                        double lossFactor = generateLossFactor();
                        string queryInsertEdge = "INSERT INTO Edges(SourceId, TargetId, LossFactor, IsActive) " +
    System.FormattableString.Invariant($"VALUES('{SourceId}', '{number}', {lossFactor}, 1)");
                        using (SQLiteCommand command = new SQLiteCommand(queryInsertEdge, connection))
                        {
                            command.ExecuteNonQuery();
                        }
                    }
                }
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void sendRightBtn_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode == null)
            {
                MessageBox.Show("Моля, изберете възел от първото дърво.", "Грешка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int selectedNodeId = (int)treeView1.SelectedNode.Tag;
            Node selectedNode = GraphManager.NetworkNodes[selectedNodeId];

            if (selectedNode == null)
            {
                MessageBox.Show("Възелът не съществува в системата.", "Грешка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            bool isAlreadyAdded = treeView2.Nodes.Cast<TreeNode>().Any(n => n.Tag != null && (int)n.Tag == selectedNodeId);

            if (isAlreadyAdded)
            {
                MessageBox.Show("Възелът вече е добавен.", "Грешка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            TreeNode node = new TreeNode($"{selectedNode.Name}");
            node.Tag = selectedNodeId;

            treeView2.Nodes.Add(node);
        }

        private void sendLeftBtn_Click(object sender, EventArgs e)
        {
            if (treeView2.SelectedNode == null)
            {
                MessageBox.Show("Моля, изберете възел от списъка за премахване.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            TreeNode nodeToRemove = treeView2.SelectedNode;

            treeView2.Nodes.Remove(nodeToRemove); ;
        }

    }
}
