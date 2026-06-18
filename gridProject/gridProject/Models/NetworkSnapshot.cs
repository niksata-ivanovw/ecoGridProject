using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gridProject
{
    public class NodeSnapshot
    {
        public int Id { get; set; }
        public bool IsActive { get; set; }
        public bool HasPower { get; set; }
    }

    public class EdgeSnapshot
    {
        public int SourceId { get; set; }
        public int TargetId { get; set; }
        public bool IsActive { get; set; }
    }

    public class NetworkSnapshot
    {
        public string ActionType { get; set; } = "StateChange";
        public int AddedNodeId { get; set; }
        public Dictionary<int, NodeSnapshot> Nodes { get; set; } = new Dictionary<int, NodeSnapshot>();
        public List<EdgeSnapshot> Edges { get; set; } = new List<EdgeSnapshot>();
    }
}
