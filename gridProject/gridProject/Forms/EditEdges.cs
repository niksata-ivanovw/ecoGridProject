using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gridProject.Forms
{
    public partial class EditEdges : Form
    {
        private static string connectionString = "Data Source=gridProjectDB.db;Version=3;";
        public int EditedSourceId { get; private set; } = -1;
        public int EditedTargetId { get; private set; } = -1;
        public bool EditedIsActive { get; private set; } = true;
        public EditEdges()
        {
            InitializeComponent();
        }

        private void EditEdges_Load(object sender, EventArgs e)
        {
            foreach (var edge in Algorithms.GraphManager.NetworkEdges)
            {
                string edgeSourceName = Algorithms.GraphManager.NetworkNodes[edge.SourceId].Name;
                string edgeTargetName = Algorithms.GraphManager.NetworkNodes[edge.TargetId].Name;
                listBox1.Items.Add($"{edgeSourceName} → {edgeTargetName}");
                
            }

            foreach (var node in Algorithms.GraphManager.NetworkNodes.Values)
            {
                comboBox1.Items.Add(node.Name);
                comboBox2.Items.Add(node.Name);
                comboBox3.Items.Add(node.Name);
                comboBox4.Items.Add(node.Name);
            }

        }

        private void listBox1_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;

            e.DrawBackground();

            string itemText = listBox1.Items[e.Index].ToString();

            TextFormatFlags flags = TextFormatFlags.VerticalCenter | TextFormatFlags.Left;

            TextRenderer.DrawText(e.Graphics, itemText, e.Font, e.Bounds, e.ForeColor, flags);

            e.DrawFocusRectangle();
        }

        private void comboBox1_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;

            e.DrawBackground();

            string itemText = comboBox1.Items[e.Index].ToString();

            TextFormatFlags flags = TextFormatFlags.VerticalCenter | TextFormatFlags.Left;

            TextRenderer.DrawText(e.Graphics, itemText, e.Font, e.Bounds, e.ForeColor, flags);

            e.DrawFocusRectangle();
        }

        private void comboBox2_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;

            e.DrawBackground();

            string itemText = comboBox2.Items[e.Index].ToString();

            TextFormatFlags flags = TextFormatFlags.VerticalCenter | TextFormatFlags.Left;

            TextRenderer.DrawText(e.Graphics, itemText, e.Font, e.Bounds, e.ForeColor, flags);

            e.DrawFocusRectangle();
        }

        private void comboBox3_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;

            e.DrawBackground();

            string itemText = comboBox3.Items[e.Index].ToString();

            TextFormatFlags flags = TextFormatFlags.VerticalCenter | TextFormatFlags.Left;

            TextRenderer.DrawText(e.Graphics, itemText, e.Font, e.Bounds, e.ForeColor, flags);

            e.DrawFocusRectangle();
        }

        private void comboBox4_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;

            e.DrawBackground();

            string itemText = comboBox4.Items[e.Index].ToString();

            TextFormatFlags flags = TextFormatFlags.VerticalCenter | TextFormatFlags.Left;

            TextRenderer.DrawText(e.Graphics, itemText, e.Font, e.Bounds, e.ForeColor, flags);

            e.DrawFocusRectangle();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string selectedSourceNodeName = comboBox1.SelectedItem?.ToString();
            string selectedTargetNodeName = comboBox2.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(selectedSourceNodeName) || string.IsNullOrEmpty(selectedTargetNodeName))
            {
                MessageBox.Show("Моля, изберете източник и цел за ръчно добавяне на ръб.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (selectedSourceNodeName == selectedTargetNodeName)
            {
                MessageBox.Show("Източникът и целта не могат да бъдат еднакви.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int sourceNodeId = Algorithms.GraphManager.NetworkNodes.Values.First(n => n.Name == selectedSourceNodeName).Id;
            int targetNodeId = Algorithms.GraphManager.NetworkNodes.Values.First(n => n.Name == selectedTargetNodeName).Id;

            var existingEdge = Algorithms.GraphManager.NetworkEdges.FirstOrDefault(ed => ed.SourceId == sourceNodeId && ed.TargetId == targetNodeId);
            if (existingEdge == null) existingEdge = Algorithms.GraphManager.NetworkEdges.FirstOrDefault(ed => ed.SourceId == targetNodeId && ed.TargetId == sourceNodeId);

            double selectedLossFactor = (double)numericUpDown1.Value;
            bool selectedIsActive = checkBox1.Checked;



            string editQuery = $"UPDATE Edges SET LossFactor = {selectedLossFactor}, IsActive = {(selectedIsActive ? 1 : 0)} " +
                   $"WHERE SourceId = {existingEdge.SourceId} AND TargetId = {existingEdge.TargetId}";

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                using (SQLiteTransaction transaction = connection.BeginTransaction())
                {
                    using (SQLiteCommand command = new SQLiteCommand(editQuery, connection, transaction))
                    {
                        command.ExecuteNonQuery();
                    }

                    transaction.Commit();
                }
            }

            EditedSourceId = existingEdge.SourceId;
            EditedTargetId = existingEdge.TargetId;
            EditedIsActive = checkBox1.Checked;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string selectedSourceNodeName = comboBox3.SelectedItem?.ToString();
            string selectedTargetNodeName = comboBox4.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(selectedSourceNodeName) || string.IsNullOrEmpty(selectedTargetNodeName))
            {
                MessageBox.Show("Моля, изберете източник и цел за ръчно добавяне на ръб.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (selectedSourceNodeName == selectedTargetNodeName)
            {
                MessageBox.Show("Източникът и целта не могат да бъдат еднакви.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int sourceNodeId = Algorithms.GraphManager.NetworkNodes.Values.First(n => n.Name == selectedSourceNodeName).Id;
            int targetNodeId = Algorithms.GraphManager.NetworkNodes.Values.First(n => n.Name == selectedTargetNodeName).Id;
            var existingEdge = Algorithms.GraphManager.NetworkEdges.FirstOrDefault(ed => ed.SourceId == sourceNodeId && ed.TargetId == targetNodeId);
            numericUpDown1.Value = (decimal)(existingEdge?.LossFactor ?? 0);

            double selectedLossFactor = (double)numericUpDown2.Value;

            string addQuery = $"INSERT INTO Edges (SourceId, TargetId, LossFactor, IsActive) VALUES ({sourceNodeId}, {targetNodeId}, {selectedLossFactor}, 1)";

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                using (SQLiteTransaction transaction = connection.BeginTransaction())
                {
                    using (SQLiteCommand command = new SQLiteCommand(addQuery, connection, transaction))
                    {
                        command.ExecuteNonQuery();
                    }

                    transaction.Commit();
                }
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string selectedSourceNodeName = listBox1.SelectedItem?.ToString().Split('→')[0].Trim();
            string selectedTargetNodeName = listBox1.SelectedItem?.ToString().Split('→')[1].Trim();

            if (string.IsNullOrEmpty(selectedSourceNodeName) || string.IsNullOrEmpty(selectedTargetNodeName))
            {
                MessageBox.Show("Моля, изберете ръб за изтриване.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int sourceNodeId = Algorithms.GraphManager.NetworkNodes.Values.First(n => n.Name == selectedSourceNodeName).Id;
            int targetNodeId = Algorithms.GraphManager.NetworkNodes.Values.First(n => n.Name == selectedTargetNodeName).Id;

            string deleteQuery = $"DELETE FROM Edges WHERE SourceId = {sourceNodeId} AND TargetId = {targetNodeId}";

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                using (SQLiteTransaction transaction = connection.BeginTransaction())
                {
                    using (SQLiteCommand command = new SQLiteCommand(deleteQuery, connection, transaction))
                    {
                        command.ExecuteNonQuery();
                    }

                    transaction.Commit();
                }
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
