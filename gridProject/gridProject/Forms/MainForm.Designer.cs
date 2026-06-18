namespace gridProject.Forms
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.editEdgeBtn = new System.Windows.Forms.Button();
            this.deleteNodeBtn = new System.Windows.Forms.Button();
            this.lblRecommendation = new System.Windows.Forms.Label();
            this.lblCurrentConsumption = new System.Windows.Forms.Label();
            this.lblPowerAvailable = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.undoActionBtn = new System.Windows.Forms.Button();
            this.simulateCrashBtn = new System.Windows.Forms.Button();
            this.optimizeNetworkBtn = new System.Windows.Forms.Button();
            this.loadNetworkBtn = new System.Windows.Forms.Button();
            this.graphDisplay = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.graphDisplay)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.dataGridView1);
            this.splitContainer1.Panel1.Controls.Add(this.treeView1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.button1);
            this.splitContainer1.Panel2.Controls.Add(this.editEdgeBtn);
            this.splitContainer1.Panel2.Controls.Add(this.deleteNodeBtn);
            this.splitContainer1.Panel2.Controls.Add(this.lblRecommendation);
            this.splitContainer1.Panel2.Controls.Add(this.lblCurrentConsumption);
            this.splitContainer1.Panel2.Controls.Add(this.lblPowerAvailable);
            this.splitContainer1.Panel2.Controls.Add(this.label4);
            this.splitContainer1.Panel2.Controls.Add(this.label3);
            this.splitContainer1.Panel2.Controls.Add(this.undoActionBtn);
            this.splitContainer1.Panel2.Controls.Add(this.simulateCrashBtn);
            this.splitContainer1.Panel2.Controls.Add(this.optimizeNetworkBtn);
            this.splitContainer1.Panel2.Controls.Add(this.loadNetworkBtn);
            this.splitContainer1.Panel2.Controls.Add(this.graphDisplay);
            this.splitContainer1.Size = new System.Drawing.Size(1999, 964);
            this.splitContainer1.SplitterDistance = 464;
            this.splitContainer1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(39, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(377, 25);
            this.label2.TabIndex = 5;
            this.label2.Text = "Обекти по електропреносната мрежа:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(39, 500);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(374, 25);
            this.label1.TabIndex = 4;
            this.label1.Text = "Връзки по електропреносната мрежа:";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(44, 546);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(395, 375);
            this.dataGridView1.TabIndex = 3;
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(44, 86);
            this.treeView1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(394, 374);
            this.treeView1.TabIndex = 2;
            // 
            // editEdgeBtn
            // 
            this.editEdgeBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editEdgeBtn.Location = new System.Drawing.Point(1247, 86);
            this.editEdgeBtn.Name = "editEdgeBtn";
            this.editEdgeBtn.Size = new System.Drawing.Size(140, 80);
            this.editEdgeBtn.TabIndex = 12;
            this.editEdgeBtn.Text = "Промени връзка";
            this.editEdgeBtn.UseVisualStyleBackColor = true;
            this.editEdgeBtn.Click += new System.EventHandler(this.editEdgeBtn_Click);
            // 
            // deleteNodeBtn
            // 
            this.deleteNodeBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteNodeBtn.Location = new System.Drawing.Point(987, 86);
            this.deleteNodeBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.deleteNodeBtn.Name = "deleteNodeBtn";
            this.deleteNodeBtn.Size = new System.Drawing.Size(140, 80);
            this.deleteNodeBtn.TabIndex = 11;
            this.deleteNodeBtn.Text = "Изтрий обект";
            this.deleteNodeBtn.UseVisualStyleBackColor = true;
            this.deleteNodeBtn.Click += new System.EventHandler(this.deleteNodeBtn_Click);
            // 
            // lblRecommendation
            // 
            this.lblRecommendation.AutoSize = true;
            this.lblRecommendation.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecommendation.Location = new System.Drawing.Point(1232, 350);
            this.lblRecommendation.Name = "lblRecommendation";
            this.lblRecommendation.Size = new System.Drawing.Size(0, 22);
            this.lblRecommendation.TabIndex = 10;
            // 
            // lblCurrentConsumption
            // 
            this.lblCurrentConsumption.AutoSize = true;
            this.lblCurrentConsumption.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentConsumption.Location = new System.Drawing.Point(1232, 304);
            this.lblCurrentConsumption.Name = "lblCurrentConsumption";
            this.lblCurrentConsumption.Size = new System.Drawing.Size(244, 22);
            this.lblCurrentConsumption.TabIndex = 9;
            this.lblCurrentConsumption.Text = "Текущо потребление: 0 MW";
            // 
            // lblPowerAvailable
            // 
            this.lblPowerAvailable.AutoSize = true;
            this.lblPowerAvailable.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPowerAvailable.Location = new System.Drawing.Point(1232, 262);
            this.lblPowerAvailable.Name = "lblPowerAvailable";
            this.lblPowerAvailable.Size = new System.Drawing.Size(219, 22);
            this.lblPowerAvailable.TabIndex = 8;
            this.lblPowerAvailable.Text = "Налична мощност: 0 MW";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(17, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(348, 36);
            this.label4.TabIndex = 7;
            this.label4.Text = "Действия по мрежата:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(18, 211);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(386, 36);
            this.label3.TabIndex = 6;
            this.label3.Text = "Електропреносна мрежа:";
            // 
            // undoActionBtn
            // 
            this.undoActionBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.undoActionBtn.Location = new System.Drawing.Point(745, 86);
            this.undoActionBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.undoActionBtn.Name = "undoActionBtn";
            this.undoActionBtn.Size = new System.Drawing.Size(140, 80);
            this.undoActionBtn.TabIndex = 5;
            this.undoActionBtn.Text = "Върни назад";
            this.undoActionBtn.UseVisualStyleBackColor = true;
            this.undoActionBtn.Click += new System.EventHandler(this.undoActionBtn_Click);
            // 
            // simulateCrashBtn
            // 
            this.simulateCrashBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simulateCrashBtn.Location = new System.Drawing.Point(507, 86);
            this.simulateCrashBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.simulateCrashBtn.Name = "simulateCrashBtn";
            this.simulateCrashBtn.Size = new System.Drawing.Size(141, 80);
            this.simulateCrashBtn.TabIndex = 4;
            this.simulateCrashBtn.Text = "Симулирай авария";
            this.simulateCrashBtn.UseVisualStyleBackColor = true;
            this.simulateCrashBtn.Click += new System.EventHandler(this.simulateCrashBtn_Click);
            // 
            // optimizeNetworkBtn
            // 
            this.optimizeNetworkBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.optimizeNetworkBtn.Location = new System.Drawing.Point(260, 86);
            this.optimizeNetworkBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.optimizeNetworkBtn.Name = "optimizeNetworkBtn";
            this.optimizeNetworkBtn.Size = new System.Drawing.Size(144, 80);
            this.optimizeNetworkBtn.TabIndex = 3;
            this.optimizeNetworkBtn.Text = "Оптимизирай мрежата";
            this.optimizeNetworkBtn.UseVisualStyleBackColor = true;
            this.optimizeNetworkBtn.Click += new System.EventHandler(this.optimizeNetworkBtn_Click);
            // 
            // loadNetworkBtn
            // 
            this.loadNetworkBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.loadNetworkBtn.Location = new System.Drawing.Point(60, 86);
            this.loadNetworkBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.loadNetworkBtn.Name = "loadNetworkBtn";
            this.loadNetworkBtn.Size = new System.Drawing.Size(114, 80);
            this.loadNetworkBtn.TabIndex = 2;
            this.loadNetworkBtn.Text = "Зареди мрежата";
            this.loadNetworkBtn.UseVisualStyleBackColor = true;
            this.loadNetworkBtn.Click += new System.EventHandler(this.loadNetworkBtn_Click);
            // 
            // graphDisplay
            // 
            this.graphDisplay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.graphDisplay.Location = new System.Drawing.Point(22, 262);
            this.graphDisplay.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.graphDisplay.Name = "graphDisplay";
            this.graphDisplay.Size = new System.Drawing.Size(1204, 658);
            this.graphDisplay.TabIndex = 0;
            this.graphDisplay.TabStop = false;
            this.graphDisplay.Paint += new System.Windows.Forms.PaintEventHandler(this.graphDisplay_Paint);
            this.graphDisplay.MouseClick += new System.Windows.Forms.MouseEventHandler(this.graphDisplay_Click);
            this.graphDisplay.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbGraph_MouseDown);
            this.graphDisplay.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pbGraph_MouseMove);
            this.graphDisplay.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pbGraph_MouseUp);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1236, 475);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(240, 33);
            this.button1.TabIndex = 13;
            this.button1.Text = "testovo butonche -> active";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1999, 964);
            this.Controls.Add(this.splitContainer1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.graphDisplay)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.PictureBox graphDisplay;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button simulateCrashBtn;
        private System.Windows.Forms.Button optimizeNetworkBtn;
        private System.Windows.Forms.Button loadNetworkBtn;
        private System.Windows.Forms.Button undoActionBtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblCurrentConsumption;
        private System.Windows.Forms.Label lblPowerAvailable;
        private System.Windows.Forms.Label lblRecommendation;
        private System.Windows.Forms.Button deleteNodeBtn;
        private System.Windows.Forms.Button editEdgeBtn;
        private System.Windows.Forms.Button button1;
    }
}