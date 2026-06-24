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
                    LossFactor = edge.LossFactor,
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
            if (snapshot.ActionType == "NodeRemoved" && snapshot.RemovedNode != null)
            {
                var n = snapshot.RemovedNode;
                string reinsertNode = $"INSERT INTO Nodes (Id, Name, Type, Capacity, Priority, X, Y) " +
                                      $"VALUES ({n.Id}, '{n.Name}', '{n.Type}', {n.Capacity}, {n.Priority}, {n.X}, {n.Y})";
                using (SQLiteConnection conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();
                    new SQLiteCommand(reinsertNode, conn).ExecuteNonQuery();
                    foreach (var ed in snapshot.RemovedEdges)
                    {
                        string reinsertEdge = $"INSERT INTO Edges (SourceId, TargetId, LossFactor, IsActive) " +
                                              $"VALUES ({ed.SourceId}, {ed.TargetId}, {ed.LossFactor}, {(ed.IsActive ? 1 : 0)})";
                        new SQLiteCommand(reinsertEdge, conn).ExecuteNonQuery();
                    }
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

            var snapshotEdgeKeys = snapshot.Edges
                .Select(es => (es.SourceId, es.TargetId)).ToHashSet();
            var edgesToRemove = NetworkEdges
                .Where(e => !snapshotEdgeKeys.Contains((e.SourceId, e.TargetId))).ToList();

            foreach (var edgeSnapshot in snapshot.Edges)
            {
                //var snapshotEdgeKeys = snapshot.Edges
                //    .Select(es => (es.SourceId, es.TargetId)).ToHashSet();
                //var edgesToRemove = NetworkEdges
                //    .Where(e => !snapshotEdgeKeys.Contains((e.SourceId, e.TargetId))).ToList();

                using (SQLiteConnection conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();

                    foreach (var edge in edgesToRemove)
                    {
                        string del = $"DELETE FROM Edges WHERE SourceId = {edge.SourceId} AND TargetId = {edge.TargetId}";
                        new SQLiteCommand(del, conn).ExecuteNonQuery();
                    }

                    foreach (var es in snapshot.Edges)
                    {
                        var existing = NetworkEdges.FirstOrDefault(
                            e => e.SourceId == es.SourceId && e.TargetId == es.TargetId);

                        if (existing != null)
                        {
                            // Edge exists — restore its values
                            existing.IsActive = es.IsActive;
                            existing.LossFactor = es.LossFactor;
                            string upd = $"UPDATE Edges SET IsActive = {(es.IsActive ? 1 : 0)}, LossFactor = {es.LossFactor} " +
                                         $"WHERE SourceId = {es.SourceId} AND TargetId = {es.TargetId}";
                            new SQLiteCommand(upd, conn).ExecuteNonQuery();
                        }
                        else
                        {
                            string del = $"DELETE FROM Edges WHERE SourceId = {es.SourceId} AND TargetId = {es.TargetId}";
                            new SQLiteCommand(del, conn).ExecuteNonQuery();

                            string ins = $"INSERT INTO Edges (SourceId, TargetId, LossFactor, IsActive) " +
                                         $"VALUES ({es.SourceId}, {es.TargetId}, {es.LossFactor}, {(es.IsActive ? 1 : 0)})";
                            new SQLiteCommand(ins, conn).ExecuteNonQuery();
                        }
                    }
                }
            }

            return true;
        }

        public static List<int> FindEmergencyRoute(int targetConsumerId)
        {
            var activeSources = NetworkNodes.Values
                .Where(n => n.Type == "Source" && n.IsActive)
                .Select(n => n.Id)
                .ToList();

            foreach (int sourceId in activeSources)
            {
                var visited = new HashSet<int>();
                var path = new List<int>();

                if (RecursiveDFS(sourceId, targetConsumerId, visited, path))
                    return path; 
            }

            return null; 
        }

        private static bool RecursiveDFS(int currentId, int targetId, HashSet<int> visited, List<int> path)
        {
            visited.Add(currentId);
            path.Add(currentId);

            if (currentId == targetId)
                return true;

            var neighbours = NetworkEdges
                .Where(e => e.SourceId == currentId || e.TargetId == currentId)
                .Select(e => e.SourceId == currentId ? e.TargetId : e.SourceId)
                .Where(neighbourId => !visited.Contains(neighbourId))
                .ToList();

            foreach (int neighbourId in neighbours)
            {
                if (RecursiveDFS(neighbourId, targetId, visited, path))
                    return true;
            }

            path.RemoveAt(path.Count - 1);
            return false;
        }
    }
}
