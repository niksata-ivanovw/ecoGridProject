using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gridProject.Models
{
    public class Edge
    {
        public int SourceId { get; set; }
        public int TargetId { get; set; }
        public double LossFactor { get; set; }
        public bool IsActive { get; set; }
    }
}
