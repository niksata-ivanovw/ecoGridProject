using gridProject.Algorithms;
using System;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace gridProject.Forms
{
    public partial class MainForm : Form
    {
        private static string connectionString = "Data Source=gridProjectDB.db;Version=3;";
        private bool isDragging = false;
        private Point clickPosition;
        private Point panOffset = new Point(0, 0);
        private float zoomFactor = 1.0f;

        public MainForm()
        {
            InitializeComponent();
            this.MouseWheel += pbGraph_MouseWheel;
            
        }

        private void pbGraph_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0)
            {
                zoomFactor += 0.1f;
            }
            else
            {
                zoomFactor -= 0.1f;
            }

            if (zoomFactor < 0.3f) zoomFactor = 0.3f;
            if (zoomFactor > 4.0f) zoomFactor = 4.0f;

            graphDisplay.Invalidate();
        }

        private void pbGraph_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = true;
                clickPosition = e.Location;
            }
        }

        private void pbGraph_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                int deltaX = e.X - clickPosition.X;
                int deltaY = e.Y - clickPosition.Y;

                panOffset.X += (int)(deltaX / zoomFactor);
                panOffset.Y += (int)(deltaY / zoomFactor);

                clickPosition = e.Location;

                graphDisplay.Invalidate();
            }
        }

        private void pbGraph_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = false;
            }
        }

        private void loadNetworkBtn_Click(object sender, EventArgs e)
        {
            GraphManager.RefreshNetworkData(treeView1, dataGridView1, graphDisplay);
            UpdatePowerLabels();
        }

        private void optimizeNetworkBtn_Click(object sender, EventArgs e)
        {
            if (OptimizeAlgorithms.OptimizeNetwork())
            {
                graphDisplay.Invalidate();
                MessageBox.Show("Мрежата е оптимизирана успешно!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                UpdatePowerLabels();
            }
            else
            {
                MessageBox.Show("Моля, първо заредете мрежата от базата данни!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void graphDisplay_Paint(object sender, PaintEventArgs e)
        {
            Color borderColor = ColorTranslator.FromHtml("#1E3A5F");
            int borderThickness = 1;

            using (Pen pen = new Pen(borderColor, borderThickness))
            {
                pen.Alignment = System.Drawing.Drawing2D.PenAlignment.Inset;

                e.Graphics.DrawRectangle(pen, 0, 0, graphDisplay.Width, graphDisplay.Height);
            }
            PictureBoxManager.DrawGraph(
                e.Graphics,
                graphDisplay.Size,
                this.Font,
                this.panOffset,
                this.zoomFactor
            );
        }

        private void simulateCrashBtn_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode == null || treeView1.SelectedNode.Tag == null)
            {
                MessageBox.Show("Моля, селектирайте конкретен източник (Source) от списъка!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int selectedNodeId = (int)treeView1.SelectedNode.Tag;

            if (GraphManager.NetworkNodes.ContainsKey(selectedNodeId))
            {
                var node = GraphManager.NetworkNodes[selectedNodeId];

                if (node.Type != "Source")
                {
                    MessageBox.Show("Моля, изберете възел от тип Производствена мощност (Source)!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                GraphManager.SaveSnapshot($"Преди авария на {node.Name}");

                node.IsActive = false;
                node.HasPower = false;

                graphDisplay.Invalidate();

                MessageBox.Show($"Източникът '{node.Name}' успешно претърпя авария. Сега натиснете бутона за Оптимизация!", "Авария", MessageBoxButtons.OK, MessageBoxIcon.Information);
                UpdatePowerLabels();
            }

        }

        private void undoActionBtn_Click(object sender, EventArgs e)
        {
            if (GraphManager.RestoreLastSnapshot())
            {
                GraphManager.NetworkNodes = GraphManager.LoadNodesFromDatabase();
                GraphManager.NetworkEdges = GraphManager.LoadEdgesFromDatabase();
                GraphManager.RefreshNetworkData(treeView1, dataGridView1, graphDisplay);
                UpdatePowerLabels();

                MessageBox.Show("Действието беше отменено успешно!", "Undo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Няма повече действия за отмяна в историята.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void UpdatePowerLabels()
        {
            double availablePower = GraphManager.NetworkNodes.Values
                .Where(n => n.Type == "Source" && n.IsActive)
                .Sum(n => Math.Abs(n.Capacity));

            double actualConsumption = GraphManager.NetworkNodes.Values
                .Where(n => n.Type == "Consumer" && n.IsActive && n.HasPower)
                .Sum(n => Math.Abs(n.Capacity));

            if (actualConsumption > availablePower)
            {
                lblRecommendation.Text = "Препоръка:\nМощността не достига!\nНужна е оптимизация!";
            }
            else
            {
                lblRecommendation.Text = "Препоръка:\nМрежата е оптимизирана!";
            }

            lblPowerAvailable.Text = $"Налична мощност: {availablePower} MW";
            lblCurrentConsumption.Text = $"Текущо потребление: {actualConsumption} MW";
        }

        private void graphDisplay_Click(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                int worldX = (int)((e.X - panOffset.X) / zoomFactor);
                int worldY = (int)((e.Y - panOffset.Y) / zoomFactor);

                using (AddNodeForm addForm = new AddNodeForm(worldX, worldY))
                {
                    if (addForm.ShowDialog() == DialogResult.OK)
                    {
                        GraphManager.SaveSnapshot("NodeAdded", addForm.InsertedNodeId);

                        GraphManager.NetworkNodes = GraphManager.LoadNodesFromDatabase();
                        GraphManager.NetworkEdges = GraphManager.LoadEdgesFromDatabase();
                        GraphManager.RefreshNetworkData(treeView1, dataGridView1, graphDisplay);
                        UpdatePowerLabels();
                    }
                }
            }
        }

        private void deleteNodeBtn_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode == null || treeView1.SelectedNode.Tag == null)
            {
                MessageBox.Show("Моля, селектирайте конкретен обект от списъка!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int selectedNodeId = (int)treeView1.SelectedNode.Tag;

            GraphManager.SaveSnapshot("NodeRemoved", selectedNodeId);

            var snap = GraphManager.ActionHistory.Peek();
            snap.RemovedNode = GraphManager.NetworkNodes[selectedNodeId];
            snap.RemovedEdges = GraphManager.NetworkEdges
                .Where(ed => ed.SourceId == selectedNodeId || ed.TargetId == selectedNodeId)
                .ToList();

            string deleteEdgesQuery = "DELETE FROM Edges WHERE SourceId = @NodeId OR TargetId = @NodeId";
            string deleteNodeQuery = "DELETE FROM Nodes WHERE Id = @NodeId";

            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();

                    using (SQLiteTransaction transaction = connection.BeginTransaction())
                    {
                        using (SQLiteCommand command = new SQLiteCommand(deleteEdgesQuery, connection, transaction))
                        {
                            command.Parameters.AddWithValue("@NodeId", selectedNodeId);
                            command.ExecuteNonQuery();
                        }

                        using (SQLiteCommand command = new SQLiteCommand(deleteNodeQuery, connection, transaction))
                        {
                            command.Parameters.AddWithValue("@NodeId", selectedNodeId);
                            command.ExecuteNonQuery();
                        }

                        transaction.Commit();
                    }
                }

                GraphManager.NetworkNodes = GraphManager.LoadNodesFromDatabase();
                GraphManager.NetworkEdges = GraphManager.LoadEdgesFromDatabase();

                GraphManager.RefreshNetworkData(treeView1, dataGridView1, graphDisplay);
                UpdatePowerLabels();

                MessageBox.Show("Възелът и неговите връзки бяха изтрити успешно!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Възникна грешка при изтриването: {ex.Message}", "Грешка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void editEdgeBtn_Click(object sender, EventArgs e)
        {
            using (EditEdges editEdgesForm = new EditEdges())
            {
                if (editEdgesForm.ShowDialog() == DialogResult.OK)
                {
                    //GraphManager.SaveSnapshot("NodeAdded", editEdgesForm.InsertedNodeId);

                    GraphManager.NetworkNodes = GraphManager.LoadNodesFromDatabase();
                    GraphManager.NetworkEdges = GraphManager.LoadEdgesFromDatabase();

                    GraphManager.RefreshNetworkData(treeView1, dataGridView1, graphDisplay);
                    UpdatePowerLabels();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string queryTest = "UPDATE Edges SET IsActive = 1;";
                using (SQLiteTransaction transaction = connection.BeginTransaction())
                {
                    using (SQLiteCommand command = new SQLiteCommand(queryTest, connection, transaction))
                    {
                        command.ExecuteNonQuery();
                    }

                    transaction.Commit();
                }
            }
            GraphManager.RefreshNetworkData(treeView1, dataGridView1, graphDisplay);
        }


        private void dataGridView1_Paint(object sender, PaintEventArgs e)
        {
            dataGridView1.BorderStyle = BorderStyle.None;
            Color borderColor = ColorTranslator.FromHtml("#1E3A5F");
            int borderThickness = 1;

            using (Pen pen = new Pen(borderColor, borderThickness))
            {
                pen.Alignment = System.Drawing.Drawing2D.PenAlignment.Inset;
                e.Graphics.DrawRectangle(pen, 0, 0, dataGridView1.Width, dataGridView1.Height);
            }
        }

        private void treeView1_DrawNode(object sender, DrawTreeNodeEventArgs e)
        {
            e.DrawDefault = false;

            bool isSelected = (e.State & TreeNodeStates.Selected) != 0;

            Color bgColor = isSelected
                ? ColorTranslator.FromHtml("#1B4F8A")
                : ColorTranslator.FromHtml("#0D1B2A");

            using (SolidBrush bg = new SolidBrush(bgColor))
                e.Graphics.FillRectangle(bg, e.Bounds);

            int tag = e.Node?.Tag is int t ? t : -1;
            Color dotColor = Color.Transparent;

            if (tag > 0 && GraphManager.NetworkNodes.ContainsKey(tag))
            {
                var node = GraphManager.NetworkNodes[tag];
                if (node.Type == "Source")
                    dotColor = node.IsActive ? Color.Gold : Color.DimGray;
                else if (node.Type == "Consumer")
                    dotColor = node.HasPower ? ColorTranslator.FromHtml("#56CCF2") : Color.OrangeRed;
                else
                    dotColor = Color.LightGray;
            }

            int dotX = e.Bounds.Left + (e.Node.Level * 16) + 4;
            int dotY = e.Bounds.Top + (e.Bounds.Height - 10) / 2;

            if (dotColor != Color.Transparent)
            {
                using (SolidBrush dot = new SolidBrush(dotColor))
                    e.Graphics.FillEllipse(dot, dotX, dotY, 10, 10);
            }

            Color textColor = isSelected ? Color.White : ColorTranslator.FromHtml("#A8D8F0");
            bool isCategoryNode = e.Node.Tag == null;
            Font font = isCategoryNode
                ? new Font("Segoe UI", 9f, FontStyle.Bold)
                : new Font("Segoe UI", 9f);

            using (SolidBrush text = new SolidBrush(textColor))
                e.Graphics.DrawString(e.Node.Text, font, text,
                    dotX + (dotColor != Color.Transparent ? 14 : 0),
                    e.Bounds.Top + (e.Bounds.Height - font.Height) / 2);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            ApplyTheme();
        }

        private void ApplyTheme()
        {
            loadNetworkBtn.FlatAppearance.BorderColor = ColorTranslator.FromHtml("#2E6DB4");
            optimizeNetworkBtn.FlatAppearance.BorderColor = ColorTranslator.FromHtml("#2E6DB4");
            simulateCrashBtn.FlatAppearance.BorderColor = ColorTranslator.FromHtml("#2E6DB4");
            undoActionBtn.FlatAppearance.BorderColor = ColorTranslator.FromHtml("#2E6DB4");
            deleteNodeBtn.FlatAppearance.BorderColor = ColorTranslator.FromHtml("#2E6DB4");
            editEdgeBtn.FlatAppearance.BorderColor = ColorTranslator.FromHtml("#2E6DB4");

            treeView1.BackColor = ColorTranslator.FromHtml("#0D1B2A");
            treeView1.ForeColor = ColorTranslator.FromHtml("#A8D8F0");
            treeView1.BorderStyle = BorderStyle.None;
            treeView1.DrawMode = TreeViewDrawMode.OwnerDrawAll;
            treeView1.ShowLines = false;
            treeView1.ItemHeight = 26;
            treeView1.Font = new Font("Segoe UI", 9f);

            dataGridView1.BackgroundColor = ColorTranslator.FromHtml("#0D1B2A");
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.GridColor = ColorTranslator.FromHtml("#1E3A5F");
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Font = new Font("Segoe UI", 9f);

            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#112240");
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#56CCF2");
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
            dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridView1.ColumnHeadersHeight = 32;
            dataGridView1.EnableHeadersVisualStyles = false;

            dataGridView1.DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#0D1B2A");
            dataGridView1.DefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#A8D8F0");
            dataGridView1.DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#1B4F8A");
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.White;
            dataGridView1.DefaultCellStyle.Padding = new Padding(4, 0, 0, 0);

            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#112240");
            dataGridView1.AlternatingRowsDefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#A8D8F0");

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ScrollBars = ScrollBars.Vertical;

            if (dataGridView1.Columns.Count >= 3)
            {
                dataGridView1.Columns[0].FillWeight = 30;
                dataGridView1.Columns[1].FillWeight = 30;
                dataGridView1.Columns[2].FillWeight = 40;
            }

            dataGridView1.Parent.BackColor = ColorTranslator.FromHtml("#0D1B2A");

            dataGridView1.RowTemplate.Height = 28;
            DataGridViewExtensions.SetDoubleBuffered(dataGridView1, true);
            dataGridView1.Scroll += (s, e) => dataGridView1.Invalidate();
        }
    }
    public static class DataGridViewExtensions
    {
        public static void SetDoubleBuffered(this DataGridView dgv, bool value)
        {
            typeof(DataGridView)
                .GetProperty("DoubleBuffered",
                    System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
                .SetValue(dgv, value, null);
        }
    }
    
    public class StyledDataGridView : DataGridView
    {
        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            foreach (Control c in this.Controls)
            {
                if (c is VScrollBar vsb)
                {
                    vsb.Width = 8;
                    vsb.BackColor = ColorTranslator.FromHtml("#112240");
                }
            }
        }
    }
}
