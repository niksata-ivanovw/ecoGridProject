using gridProject.Models;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gridProject.Algorithms
{
    public class DisjointSet
    {
        private Dictionary<int, int> parent = new Dictionary<int, int>();

        public void MakeSet(IEnumerable<int> universe)
        {
            foreach (int i in universe)
                parent[i] = i;
        }

        public int Find(int k)
        {
            if (parent[k] == k)
                return k;
            return Find(parent[k]);
        }

        public void Union(int a, int b)
        {
            int x = Find(a);
            int y = Find(b);
            parent[x] = y;
        }
    }
    internal static class GraphManager
    {
        private static string connectionString = "Data Source=gridProjectDB.db;Version=3;";

        public static Dictionary<int, Node> NetworkNodes = new Dictionary<int, Node>();

        public static List<Edge> NetworkEdges = new List<Edge>();

        public static Stack<NetworkSnapshot> ActionHistory = new Stack<NetworkSnapshot>();

        public static Queue<Node> PendingConnections = new Queue<Node>();

        public static List<Edge> LoadEdgesFromDatabase()
        {
            List<Edge> edges = new List<Edge>();

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM Edges";
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Edge edge = new Edge
                            {
                                SourceId = Convert.ToInt32(reader["SourceId"]),
                                TargetId = Convert.ToInt32(reader["TargetId"]),
                                LossFactor = Convert.ToDouble(reader["LossFactor"]),
                                IsActive = Convert.ToInt32(reader["IsActive"]) == 1
                            };
                            edges.Add(edge);
                        }
                    }
                }
            }

            return edges;
        }

        public static Dictionary<int, Node> LoadNodesFromDatabase()
        {
            Dictionary<int, Node> nodes = new Dictionary<int, Node>();

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM Nodes";
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Node node = new Node
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Name = reader["Name"].ToString(),
                                Type = reader["Type"].ToString(),
                                Capacity = Convert.ToDouble(reader["Capacity"]),
                                Priority = Convert.ToInt32(reader["Priority"]),
                                X = Convert.ToInt32(reader["X"]),
                                Y = Convert.ToInt32(reader["Y"]),
                            };
                            nodes.Add(node.Id, node);
                        }
                    }
                }
            }

            return nodes;
        }

        public static List<Node> GetConsumersSortedByPriority(List<Node> accesibleNodes = null)
        {
            if (accesibleNodes == null)
            {
                List<Node> consumers = NetworkNodes.Values.Where(n => n.Type == "Consumer").ToList();

                for (int i = 0; i < consumers.Count - 1; i++)
                {
                    for (int j = 0; j < consumers.Count - i - 1; j++)
                    {
                        if (consumers[j].Priority > consumers[j + 1].Priority)
                        {
                            var temp = consumers[j];
                            consumers[j] = consumers[j + 1];
                            consumers[j + 1] = temp;
                        }
                    }
                }
                return consumers;
            }

            for (int i = 0; i < accesibleNodes.Count - 1; i++)
            {
                for (int j = 0; j < accesibleNodes.Count - i - 1; j++)
                {
                    if (accesibleNodes[j].Priority > accesibleNodes[j + 1].Priority)
                    {
                        var temp = accesibleNodes[j];
                        accesibleNodes[j] = accesibleNodes[j + 1];
                        accesibleNodes[j + 1] = temp;
                    }
                }
            }
            return accesibleNodes;
        }

        public static bool FindAlternativeRoute(int currentId, int targetSourceId, HashSet<int> visited)
        {
            if (currentId == targetSourceId) return true;

            visited.Add(currentId);

            var neighbors = NetworkEdges.Where(e => e.SourceId == currentId && e.IsActive).Select(e => e.TargetId);

            foreach (var neighbor in neighbors)
            {
                if (!visited.Contains(neighbor))
                {
                    if (FindAlternativeRoute(neighbor, targetSourceId, visited))
                        return true;
                }
            }

            visited.Remove(currentId);
            return false;
        }
        public static void RefreshNetworkData(TreeView tv, DataGridView dgv, PictureBox pb1)
        {
            NetworkEdges = LoadEdgesFromDatabase();
            NetworkNodes = LoadNodesFromDatabase();
            TreeViewManager.PopulateTreeView(tv);
            DataGridManager.UpdateDataGridView(dgv);
            pb1.Invalidate();
        }

        public static void SaveSnapshot(string actionType = "StateChange", int addedNodeId = 0)
        {
            var snapshot = new NetworkSnapshot
            {
                AddedNodeId = addedNodeId,
                ActionType = actionType,
            };

            foreach (var node in NetworkNodes.Values)
            {
                snapshot.Nodes.Add(node.Id, new NodeSnapshot
                {
                    Id = node.Id,
                    IsActive = node.IsActive,
                    HasPower = node.HasPower
                });
            }

            foreach (var edge in NetworkEdges)
            {
                snapshot.Edges.Add(new EdgeSnapshot
                {
                    SourceId = edge.SourceId,
                    TargetId = edge.TargetId,
                    IsActive = edge.IsActive
                });
            }

            ActionHistory.Push(snapshot);
        }

        public static bool RestoreLastSnapshot()
        {
            if (ActionHistory.Count == 0) return false;

            var snapshot = ActionHistory.Pop();

            if (snapshot.ActionType == "NodeAdded" && snapshot.AddedNodeId > 0)
            {
                string query = $"DELETE FROM Nodes WHERE Id = {snapshot.AddedNodeId}";
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();
                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }
                if (NetworkNodes.ContainsKey(snapshot.AddedNodeId))
                {
                    NetworkNodes.Remove(snapshot.AddedNodeId);
                }
            }

            foreach (var nodeSnapshot in snapshot.Nodes.Values)
            {
                if (NetworkNodes.ContainsKey(nodeSnapshot.Id))
                {
                    NetworkNodes[nodeSnapshot.Id].IsActive = nodeSnapshot.IsActive;
                    NetworkNodes[nodeSnapshot.Id].HasPower = nodeSnapshot.HasPower;
                }
            }

            foreach (var edgeSnapshot in snapshot.Edges)
            {
                var originalEdge = NetworkEdges.FirstOrDefault(e => e.SourceId == edgeSnapshot.SourceId && e.TargetId == edgeSnapshot.TargetId);
                if (originalEdge != null)
                {
                    originalEdge.IsActive = edgeSnapshot.IsActive;
                    string updateQuery = $"UPDATE Edges SET IsActive = {(edgeSnapshot.IsActive ? 1 : 0)} " +
                             $"WHERE SourceId = {edgeSnapshot.SourceId} AND TargetId = {edgeSnapshot.TargetId}";
                    using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                    {
                        connection.Open();
                        using (SQLiteCommand command = new SQLiteCommand(updateQuery, connection))
                        {
                            command.ExecuteNonQuery();
                        }
                    }
                }
            }

            return true;
        }
    }
}
