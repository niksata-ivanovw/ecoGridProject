using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gridProject.Algorithms
{
    internal class DataGridManager
    {
        public static void UpdateDataGridView(DataGridView dgv)
        {
            if (dgv == null) return;

            dgv.DataSource = null;

            if (GraphManager.NetworkEdges != null && GraphManager.NetworkEdges.Count > 0 ) 
            {
                dgv.DataSource = GraphManager.NetworkEdges;

                dgv.RowHeadersVisible = false;
                if (dgv.Columns["Id"] != null) dgv.Columns["Id"].Visible = false;
                dgv.Columns["SourceId"].HeaderText = "Източник";
                dgv.Columns["SourceId"].ReadOnly = true;
                dgv.Columns["TargetId"].HeaderText = "Получател";
                dgv.Columns["TargetId"].ReadOnly = true;
                dgv.Columns["LossFactor"].HeaderText = "Загуби по трасето";
                dgv.Columns["LossFactor"].ReadOnly = true;
                dgv.Columns["IsActive"].HeaderText = "Активен";
                dgv.Columns["IsActive"].ReadOnly = true;
            }
        }
    }
}
