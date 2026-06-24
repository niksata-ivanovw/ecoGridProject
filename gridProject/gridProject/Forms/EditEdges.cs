using gridProject.Algorithms;
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
            groupBox1.ForeColor = ColorTranslator.FromHtml("#1B4F8A");
            groupBox2.ForeColor = ColorTranslator.FromHtml("#1B4F8A");


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

        private void saveChangesBtn_Click(object sender, EventArgs e)
        {
            GraphManager.SaveSnapshot("EdgeChanged");

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

        private void addNewBtn_Click(object sender, EventArgs e)
        {
            GraphManager.SaveSnapshot("EdgeChanged");

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

        private void deleteEdgeBtn_Click(object sender, EventArgs e)
        {
            GraphManager.SaveSnapshot("EdgeChanged");

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

        private void groupBox1_Paint(object sender, PaintEventArgs e)
        {
            GroupBox groupBox = (GroupBox)sender;

            Color borderColor = ColorTranslator.FromHtml("#CBD5E0");

            using (SolidBrush bgBrush = new SolidBrush(groupBox.BackColor))
            {
                e.Graphics.FillRectangle(bgBrush, groupBox.ClientRectangle);
            }

            Size textSize = TextRenderer.MeasureText(groupBox.Text, groupBox.Font);

            int topOffset = textSize.Height / 2;
            Rectangle borderRect = new Rectangle(
                0,
                topOffset,
                groupBox.Width - 1,
                groupBox.Height - topOffset - 1
            );

            using (Pen pen = new Pen(borderColor, 1))
            {
                e.Graphics.DrawLine(pen, borderRect.Left, borderRect.Top, borderRect.Left, borderRect.Bottom);
                e.Graphics.DrawLine(pen, borderRect.Left, borderRect.Bottom, borderRect.Right, borderRect.Bottom);
                e.Graphics.DrawLine(pen, borderRect.Right, borderRect.Top, borderRect.Right, borderRect.Bottom);

                int textStartGap = 8;
                int textEndGap = textStartGap + textSize.Width;

                e.Graphics.DrawLine(pen, borderRect.Left, borderRect.Top, textStartGap, borderRect.Top);
                e.Graphics.DrawLine(pen, textEndGap, borderRect.Top, borderRect.Right, borderRect.Top);
            }

            using (SolidBrush textBrush = new SolidBrush(groupBox.ForeColor))
            {
                e.Graphics.DrawString(groupBox.Text, groupBox.Font, textBrush, new PointF(8, 0));
            }
        }

        private void groupBox2_Paint(object sender, PaintEventArgs e)
        {
            GroupBox groupBox = (GroupBox)sender;

            Color borderColor = ColorTranslator.FromHtml("#CBD5E0");

            using (SolidBrush bgBrush = new SolidBrush(groupBox.BackColor))
            {
                e.Graphics.FillRectangle(bgBrush, groupBox.ClientRectangle);
            }

            Size textSize = TextRenderer.MeasureText(groupBox.Text, groupBox.Font);

            int topOffset = textSize.Height / 2;
            Rectangle borderRect = new Rectangle(
                0,
                topOffset,
                groupBox.Width - 1,
                groupBox.Height - topOffset - 1
            );

            using (Pen pen = new Pen(borderColor, 1))
            {
                e.Graphics.DrawLine(pen, borderRect.Left, borderRect.Top, borderRect.Left, borderRect.Bottom);
                e.Graphics.DrawLine(pen, borderRect.Left, borderRect.Bottom, borderRect.Right, borderRect.Bottom);
                e.Graphics.DrawLine(pen, borderRect.Right, borderRect.Top, borderRect.Right, borderRect.Bottom);

                int textStartGap = 8;
                int textEndGap = textStartGap + textSize.Width;

                e.Graphics.DrawLine(pen, borderRect.Left, borderRect.Top, textStartGap, borderRect.Top);
                e.Graphics.DrawLine(pen, textEndGap, borderRect.Top, borderRect.Right, borderRect.Top);
            }

            using (SolidBrush textBrush = new SolidBrush(groupBox.ForeColor))
            {
                e.Graphics.DrawString(groupBox.Text, groupBox.Font, textBrush, new PointF(8, 0));
            }
        }
    }
}
