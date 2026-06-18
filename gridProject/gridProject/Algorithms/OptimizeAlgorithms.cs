using System;
using System.Data.SQLite;
using System.Linq;

namespace gridProject.Algorithms
{
    public static class OptimizeAlgorithms
    {
        public static bool OptimizeNetwork()
        {
            if (GraphManager.NetworkNodes.Count == 0 || GraphManager.NetworkEdges.Count == 0)
                return false;

            GraphManager.SaveSnapshot("Преди оптимизация на мрежата");

            double totalAvailableCapacity = GraphManager.NetworkNodes.Values
                .Where(n => n.Type == "Source" && n.IsActive)
                .Sum(n => Math.Abs(n.Capacity));

            foreach (var node in GraphManager.NetworkNodes.Values.Where(n => n.Type == "Consumer"))
            {
                node.HasPower = false;
            }

            var prioritizedConsumers = GraphManager.NetworkNodes.Values
                .Where(n => n.Type == "Consumer" && n.IsActive)
                .OrderBy(n => n.Priority)
                .ToList();

            foreach (var consumer in prioritizedConsumers)
            {
                double requiredPower = Math.Abs(consumer.Capacity);

                if (totalAvailableCapacity >= requiredPower)
                {
                    consumer.HasPower = true;
                    totalAvailableCapacity -= requiredPower;
                }
                else
                {
                    consumer.HasPower = false;
                }
            }

            var sortedEdges = GraphManager.NetworkEdges.OrderBy(edge => edge.LossFactor).ToList();
            DisjointSet ds = new DisjointSet();
            ds.MakeSet(GraphManager.NetworkNodes.Keys);

            foreach (var edge in GraphManager.NetworkEdges)
            {
                edge.IsActive = false;
            }

            foreach (var edge in sortedEdges)
            {
                var srcNode = GraphManager.NetworkNodes[edge.SourceId];
                var targetNode = GraphManager.NetworkNodes[edge.TargetId];

                bool isOfflineSource = (srcNode.Type == "Source" && !srcNode.IsActive) ||
                                       (targetNode.Type == "Source" && !targetNode.IsActive);

                bool isOfflineConsumer = (srcNode.Type == "Consumer" && !srcNode.HasPower) ||
                                         (targetNode.Type == "Consumer" && !targetNode.HasPower);

                if (isOfflineSource || isOfflineConsumer)
                    continue;

                if (ds.Find(edge.SourceId) != ds.Find(edge.TargetId))
                {
                    edge.IsActive = true;
                    ds.Union(edge.SourceId, edge.TargetId);
                }
            }

            string connectionString = "Data Source=gridProjectDB.db;Version=3;";
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                foreach (var edge in GraphManager.NetworkEdges)
                {
                    string updateQuery = $"UPDATE Edges SET IsActive = {(edge.IsActive ? 1 : 0)} " +
                                         $"WHERE SourceId = {edge.SourceId} AND TargetId = {edge.TargetId}";
                    using (SQLiteCommand command = new SQLiteCommand(updateQuery, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }
            }

            return true;
        }
    }
}