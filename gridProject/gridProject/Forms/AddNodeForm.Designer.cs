namespace gridProject.Forms
{
    partial class AddNodeForm
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.createButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.sendRightBtn = new System.Windows.Forms.Button();
            this.sendLeftBtn = new System.Windows.Forms.Button();
            this.treeView2 = new System.Windows.Forms.TreeView();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(56, 78);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(282, 28);
            this.textBox1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(52, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(443, 66);
            this.label1.TabIndex = 1;
            this.label1.Text = "Въведете нов обект с име във формата:\r\n\r\n(SRCE/SUST/CON-име на обекта-номер на об" +
    "екта)";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDown1.Location = new System.Drawing.Point(56, 285);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(133, 28);
            this.numericUpDown1.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(52, 208);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(347, 44);
            this.label3.TabIndex = 5;
            this.label3.Text = "Моля въведете мощност/потребление и\r\nприоритет на обекта.";
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Location = new System.Drawing.Point(56, 329);
            this.numericUpDown2.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numericUpDown2.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(133, 28);
            this.numericUpDown2.TabIndex = 6;
            this.numericUpDown2.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // createButton
            // 
            this.createButton.Location = new System.Drawing.Point(657, 329);
            this.createButton.Name = "createButton";
            this.createButton.Size = new System.Drawing.Size(230, 78);
            this.createButton.TabIndex = 7;
            this.createButton.Text = "Създай обект";
            this.createButton.UseVisualStyleBackColor = true;
            this.createButton.Click += new System.EventHandler(this.createButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(52, 153);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 22);
            this.label2.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(224, 285);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(218, 44);
            this.label4.TabIndex = 9;
            this.label4.Text = "[мощност / потребление]\r\n\r\n";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(224, 329);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(106, 22);
            this.label5.TabIndex = 10;
            this.label5.Text = "[приоритет]";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(501, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(359, 22);
            this.label6.TabIndex = 11;
            this.label6.Text = "Изберете връзките на обекта в мрежата:\r\n";
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(505, 46);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(233, 245);
            this.treeView1.TabIndex = 12;
            // 
            // sendRightBtn
            // 
            this.sendRightBtn.Location = new System.Drawing.Point(744, 109);
            this.sendRightBtn.Name = "sendRightBtn";
            this.sendRightBtn.Size = new System.Drawing.Size(50, 50);
            this.sendRightBtn.TabIndex = 13;
            this.sendRightBtn.Text = "→";
            this.sendRightBtn.UseVisualStyleBackColor = true;
            this.sendRightBtn.Click += new System.EventHandler(this.sendRightBtn_Click);
            // 
            // sendLeftBtn
            // 
            this.sendLeftBtn.Location = new System.Drawing.Point(744, 165);
            this.sendLeftBtn.Name = "sendLeftBtn";
            this.sendLeftBtn.Size = new System.Drawing.Size(50, 50);
            this.sendLeftBtn.TabIndex = 14;
            this.sendLeftBtn.Text = "←";
            this.sendLeftBtn.UseVisualStyleBackColor = true;
            this.sendLeftBtn.Click += new System.EventHandler(this.sendLeftBtn_Click);
            // 
            // treeView2
            // 
            this.treeView2.Location = new System.Drawing.Point(800, 46);
            this.treeView2.Name = "treeView2";
            this.treeView2.Size = new System.Drawing.Size(233, 245);
            this.treeView2.TabIndex = 16;
            // 
            // AddNodeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1041, 484);
            this.Controls.Add(this.treeView2);
            this.Controls.Add(this.sendLeftBtn);
            this.Controls.Add(this.sendRightBtn);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.createButton);
            this.Controls.Add(this.numericUpDown2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "AddNodeForm";
            this.Text = "AddNodeForm";
            this.Load += new System.EventHandler(this.AddNodeForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.Button createButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Button sendRightBtn;
        private System.Windows.Forms.Button sendLeftBtn;
        private System.Windows.Forms.TreeView treeView2;
    }
}