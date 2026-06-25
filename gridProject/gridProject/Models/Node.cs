using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gridProject.Models
{
    public class Node
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public double Capacity { get; set; }
        public int Priority { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public bool IsActive { get; set; } = true;
        public bool HasPower { get; set; } = true;
    }
}
