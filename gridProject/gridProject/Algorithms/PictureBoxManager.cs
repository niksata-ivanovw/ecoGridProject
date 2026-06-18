using gridProject.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gridProject.Algorithms
{
    internal static class PictureBoxManager
    {
        public static void DrawGraph(Graphics g, Size containerSize, Font baseFont, Point panOffset, float zoomFactor)
        {
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;

            g.TranslateTransform(panOffset.X, panOffset.Y);
            g.ScaleTransform(zoomFactor, zoomFactor);

            foreach (var edge in GraphManager.NetworkEdges)
            {
                if (!GraphManager.NetworkNodes.ContainsKey(edge.SourceId) ||
                    !GraphManager.NetworkNodes.ContainsKey(edge.TargetId))
                    continue;

                Node src = GraphManager.NetworkNodes[edge.SourceId];
                Node target = GraphManager.NetworkNodes[edge.TargetId];

                using (Pen pen = edge.IsActive ? new Pen(Color.Green, 2) : new Pen(Color.Red, 2))
                {
                    g.DrawLine(pen, src.X, src.Y, target.X, target.Y);
                }
            }

            foreach (var node in GraphManager.NetworkNodes.Values)
            {
                Brush nodeBrush;

                if (node.Type == "Source")
                {
                    nodeBrush = node.IsActive ? Brushes.Gold : Brushes.DarkGray;
                }
                else if (node.Type == "Consumer")
                {
                    nodeBrush = node.HasPower ? Brushes.LightBlue : Brushes.OrangeRed;
                }
                else
                {
                    nodeBrush = Brushes.LightGray;
                }

                g.FillEllipse(nodeBrush, node.X - 15, node.Y - 15, 30, 30);
                g.DrawEllipse(Pens.Black, node.X - 15, node.Y - 15, 30, 30);

                string label = node.Name;
                g.DrawString(label, baseFont, Brushes.Black, node.X - 20, node.Y + 18);
            }
        }
    }
}
