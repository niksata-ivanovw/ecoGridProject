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
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.loadNetworkBtn = new System.Windows.Forms.Button();
            this.optimizeNetworkBtn = new System.Windows.Forms.Button();
            this.editEdgeBtn = new System.Windows.Forms.Button();
            this.simulateCrashBtn = new System.Windows.Forms.Button();
            this.deleteNodeBtn = new System.Windows.Forms.Button();
            this.undoActionBtn = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.lblRecommendation = new System.Windows.Forms.Label();
            this.lblCurrentConsumption = new System.Windows.Forms.Label();
            this.lblPowerAvailable = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.graphDisplay = new System.Windows.Forms.PictureBox();
            this.dataGridView1 = new gridProject.Forms.StyledDataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.graphDisplay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
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
            this.splitContainer1.Panel2.Controls.Add(this.panel1);
            this.splitContainer1.Panel2.Controls.Add(this.button1);
            this.splitContainer1.Panel2.Controls.Add(this.lblRecommendation);
            this.splitContainer1.Panel2.Controls.Add(this.lblCurrentConsumption);
            this.splitContainer1.Panel2.Controls.Add(this.lblPowerAvailable);
            this.splitContainer1.Panel2.Controls.Add(this.label4);
            this.splitContainer1.Panel2.Controls.Add(this.label3);
            this.splitContainer1.Panel2.Controls.Add(this.graphDisplay);
            this.splitContainer1.Size = new System.Drawing.Size(1710, 771);
            this.splitContainer1.SplitterDistance = 465;
            this.splitContainer1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(35, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(333, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Обекти по електропреносната мрежа:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(35, 400);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(332, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Връзки по електропреносната мрежа:";
            // 
            // treeView1
            // 
            this.treeView1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(27)))), ((int)(((byte)(42)))));
            this.treeView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.treeView1.DrawMode = System.Windows.Forms.TreeViewDrawMode.OwnerDrawAll;
            this.treeView1.Font = new System.Drawing.Font("Segoe UI Semibold", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeView1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(216)))), ((int)(((byte)(240)))));
            this.treeView1.ItemHeight = 26;
            this.treeView1.Location = new System.Drawing.Point(39, 69);
            this.treeView1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.treeView1.Name = "treeView1";
            this.treeView1.ShowLines = false;
            this.treeView1.Size = new System.Drawing.Size(431, 299);
            this.treeView1.TabIndex = 2;
            this.treeView1.DrawNode += new System.Windows.Forms.DrawTreeNodeEventHandler(this.treeView1_DrawNode);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(27)))), ((int)(((byte)(42)))));
            this.panel1.Controls.Add(this.loadNetworkBtn);
            this.panel1.Controls.Add(this.optimizeNetworkBtn);
            this.panel1.Controls.Add(this.editEdgeBtn);
            this.panel1.Controls.Add(this.simulateCrashBtn);
            this.panel1.Controls.Add(this.deleteNodeBtn);
            this.panel1.Controls.Add(this.undoActionBtn);
            this.panel1.Location = new System.Drawing.Point(16, 65);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1291, 89);
            this.panel1.TabIndex = 14;
            // 
            // loadNetworkBtn
            // 
            this.loadNetworkBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(79)))), ((int)(((byte)(138)))));
            this.loadNetworkBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.loadNetworkBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.loadNetworkBtn.ForeColor = System.Drawing.Color.White;
            this.loadNetworkBtn.Location = new System.Drawing.Point(27, 11);
            this.loadNetworkBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.loadNetworkBtn.Name = "loadNetworkBtn";
            this.loadNetworkBtn.Size = new System.Drawing.Size(101, 64);
            this.loadNetworkBtn.TabIndex = 2;
            this.loadNetworkBtn.Text = "Зареди мрежата";
            this.loadNetworkBtn.UseVisualStyleBackColor = false;
            this.loadNetworkBtn.Click += new System.EventHandler(this.loadNetworkBtn_Click);
            // 
            // optimizeNetworkBtn
            // 
            this.optimizeNetworkBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(79)))), ((int)(((byte)(138)))));
            this.optimizeNetworkBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.optimizeNetworkBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.optimizeNetworkBtn.ForeColor = System.Drawing.Color.White;
            this.optimizeNetworkBtn.Location = new System.Drawing.Point(212, 11);
            this.optimizeNetworkBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.optimizeNetworkBtn.Name = "optimizeNetworkBtn";
            this.optimizeNetworkBtn.Size = new System.Drawing.Size(128, 64);
            this.optimizeNetworkBtn.TabIndex = 3;
            this.optimizeNetworkBtn.Text = "Оптимизирай мрежата";
            this.optimizeNetworkBtn.UseVisualStyleBackColor = false;
            this.optimizeNetworkBtn.Click += new System.EventHandler(this.optimizeNetworkBtn_Click);
            // 
            // editEdgeBtn
            // 
            this.editEdgeBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(79)))), ((int)(((byte)(138)))));
            this.editEdgeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.editEdgeBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editEdgeBtn.ForeColor = System.Drawing.Color.White;
            this.editEdgeBtn.Location = new System.Drawing.Point(1079, 11);
            this.editEdgeBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.editEdgeBtn.Name = "editEdgeBtn";
            this.editEdgeBtn.Size = new System.Drawing.Size(124, 64);
            this.editEdgeBtn.TabIndex = 12;
            this.editEdgeBtn.Text = "Промени връзка";
            this.editEdgeBtn.UseVisualStyleBackColor = false;
            this.editEdgeBtn.Click += new System.EventHandler(this.editEdgeBtn_Click);
            // 
            // simulateCrashBtn
            // 
            this.simulateCrashBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(79)))), ((int)(((byte)(138)))));
            this.simulateCrashBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.simulateCrashBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simulateCrashBtn.ForeColor = System.Drawing.Color.White;
            this.simulateCrashBtn.Location = new System.Drawing.Point(418, 11);
            this.simulateCrashBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.simulateCrashBtn.Name = "simulateCrashBtn";
            this.simulateCrashBtn.Size = new System.Drawing.Size(125, 64);
            this.simulateCrashBtn.TabIndex = 4;
            this.simulateCrashBtn.Text = "Симулирай авария";
            this.simulateCrashBtn.UseVisualStyleBackColor = false;
            this.simulateCrashBtn.Click += new System.EventHandler(this.simulateCrashBtn_Click);
            // 
            // deleteNodeBtn
            // 
            this.deleteNodeBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(79)))), ((int)(((byte)(138)))));
            this.deleteNodeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deleteNodeBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteNodeBtn.ForeColor = System.Drawing.Color.White;
            this.deleteNodeBtn.Location = new System.Drawing.Point(852, 11);
            this.deleteNodeBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.deleteNodeBtn.Name = "deleteNodeBtn";
            this.deleteNodeBtn.Size = new System.Drawing.Size(124, 64);
            this.deleteNodeBtn.TabIndex = 11;
            this.deleteNodeBtn.Text = "Изтрий обект";
            this.deleteNodeBtn.UseVisualStyleBackColor = false;
            this.deleteNodeBtn.Click += new System.EventHandler(this.deleteNodeBtn_Click);
            // 
            // undoActionBtn
            // 
            this.undoActionBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(79)))), ((int)(((byte)(138)))));
            this.undoActionBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.undoActionBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.undoActionBtn.ForeColor = System.Drawing.Color.White;
            this.undoActionBtn.Location = new System.Drawing.Point(628, 11);
            this.undoActionBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.undoActionBtn.Name = "undoActionBtn";
            this.undoActionBtn.Size = new System.Drawing.Size(124, 64);
            this.undoActionBtn.TabIndex = 5;
            this.undoActionBtn.Text = "Върни назад";
            this.undoActionBtn.UseVisualStyleBackColor = false;
            this.undoActionBtn.Click += new System.EventHandler(this.undoActionBtn_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1097, 697);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(212, 26);
            this.button1.TabIndex = 13;
            this.button1.Text = "testovo butonche -> active";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblRecommendation
            // 
            this.lblRecommendation.AutoSize = true;
            this.lblRecommendation.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecommendation.ForeColor = System.Drawing.Color.White;
            this.lblRecommendation.Location = new System.Drawing.Point(1092, 267);
            this.lblRecommendation.Name = "lblRecommendation";
            this.lblRecommendation.Size = new System.Drawing.Size(0, 18);
            this.lblRecommendation.TabIndex = 10;
            // 
            // lblCurrentConsumption
            // 
            this.lblCurrentConsumption.AutoSize = true;
            this.lblCurrentConsumption.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentConsumption.ForeColor = System.Drawing.Color.Transparent;
            this.lblCurrentConsumption.Location = new System.Drawing.Point(1092, 230);
            this.lblCurrentConsumption.Name = "lblCurrentConsumption";
            this.lblCurrentConsumption.Size = new System.Drawing.Size(202, 18);
            this.lblCurrentConsumption.TabIndex = 9;
            this.lblCurrentConsumption.Text = "Текущо потребление: 0 MW";
            // 
            // lblPowerAvailable
            // 
            this.lblPowerAvailable.AutoSize = true;
            this.lblPowerAvailable.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPowerAvailable.ForeColor = System.Drawing.Color.Transparent;
            this.lblPowerAvailable.Location = new System.Drawing.Point(1092, 197);
            this.lblPowerAvailable.Name = "lblPowerAvailable";
            this.lblPowerAvailable.Size = new System.Drawing.Size(183, 18);
            this.lblPowerAvailable.TabIndex = 8;
            this.lblPowerAvailable.Text = "Налична мощност: 0 MW";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.ForeColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(12, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(277, 29);
            this.label4.TabIndex = 7;
            this.label4.Text = "Действия по мрежата:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.ForeColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(12, 156);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(313, 29);
            this.label3.TabIndex = 6;
            this.label3.Text = "Електропреносна мрежа:";
            // 
            // graphDisplay
            // 
            this.graphDisplay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(22)))), ((int)(((byte)(40)))));
            this.graphDisplay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.graphDisplay.Location = new System.Drawing.Point(3, 197);
            this.graphDisplay.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.graphDisplay.Name = "graphDisplay";
            this.graphDisplay.Size = new System.Drawing.Size(1070, 540);
            this.graphDisplay.TabIndex = 0;
            this.graphDisplay.TabStop = false;
            this.graphDisplay.Paint += new System.Windows.Forms.PaintEventHandler(this.graphDisplay_Paint);
            this.graphDisplay.MouseClick += new System.Windows.Forms.MouseEventHandler(this.graphDisplay_Click);
            this.graphDisplay.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbGraph_MouseDown);
            this.graphDisplay.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pbGraph_MouseMove);
            this.graphDisplay.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pbGraph_MouseUp);
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(22)))), ((int)(((byte)(40)))));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(39, 437);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(431, 300);
            this.dataGridView1.TabIndex = 3;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(27)))), ((int)(((byte)(42)))));
            this.ClientSize = new System.Drawing.Size(1710, 771);
            this.Controls.Add(this.splitContainer1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.Text = "GlavnaStranica";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.graphDisplay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.PictureBox graphDisplay;
        private gridProject.Forms.StyledDataGridView dataGridView1;
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
        private System.Windows.Forms.Panel panel1;
    }
}