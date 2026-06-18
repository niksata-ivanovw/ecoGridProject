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
    }
}
