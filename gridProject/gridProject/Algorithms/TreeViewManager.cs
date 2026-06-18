using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gridProject.Algorithms
{
    internal class TreeViewManager
    {
        public static void PopulateTreeView(TreeView tv)
        {
            tv.Nodes.Clear();

            TreeNode sourcesNode = new TreeNode("Производствени мощности (Sources)");
            TreeNode substationsNode = new TreeNode("Разпределителни подстанции (Substations)");
            TreeNode consumersNode = new TreeNode("Енергийни консуматори (Consumers)");

            foreach (var node in GraphManager.NetworkNodes.Values)
            {
                string nodeText = node.Type == "Substation"
                    ? $"{node.Id} - {node.Name}"
                    : $"{node.Id} - {node.Name} ({node.Capacity} MW)";

                TreeNode childNode = new TreeNode(nodeText);

                childNode.Tag = node.Id;

                if (node.Type == "Source")
                {
                    sourcesNode.Nodes.Add(childNode);
                }
                else if (node.Type == "Substation")
                {
                    substationsNode.Nodes.Add(childNode);
                }
                else if (node.Type == "Consumer")
                {
                    consumersNode.Nodes.Add(childNode);
                }
            }

            tv.Nodes.Add(sourcesNode);
            tv.Nodes.Add(substationsNode);
            tv.Nodes.Add(consumersNode);

            tv.ExpandAll();
        }
    }
}
