namespace PaintTool
{
    partial class Form2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.panel1 = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbWid = new System.Windows.Forms.TextBox();
            this.tbHei = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.trackBarW = new System.Windows.Forms.TrackBar();
            this.trackBarH = new System.Windows.Forms.TrackBar();
            this.tbBru = new System.Windows.Forms.NumericUpDown();
            this.btnLock = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarW)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbBru)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.menuStrip1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(613, 590);
            this.panel1.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.closeToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(613, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.closeToolStripMenuItem.Text = "Close";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(623, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(181, 31);
            this.label1.TabIndex = 1;
            this.label1.Text = "ITEM_NAME";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(619, 154);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "WIDTH:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(619, 245);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "HEIGHT:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(626, 331);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "BRUSH:";
            // 
            // tbWid
            // 
            this.tbWid.Location = new System.Drawing.Point(704, 147);
            this.tbWid.Name = "tbWid";
            this.tbWid.Size = new System.Drawing.Size(100, 20);
            this.tbWid.TabIndex = 5;
            this.tbWid.Leave += new System.EventHandler(this.tbWid_Leave);
            // 
            // tbHei
            // 
            this.tbHei.Location = new System.Drawing.Point(704, 242);
            this.tbHei.Name = "tbHei";
            this.tbHei.Size = new System.Drawing.Size(100, 20);
            this.tbHei.TabIndex = 6;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(641, 515);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(170, 54);
            this.button1.TabIndex = 8;
            this.button1.Text = "GENERATE";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // trackBarW
            // 
            this.trackBarW.Location = new System.Drawing.Point(622, 173);
            this.trackBarW.Maximum = 1000;
            this.trackBarW.Name = "trackBarW";
            this.trackBarW.Size = new System.Drawing.Size(182, 45);
            this.trackBarW.TabIndex = 9;
            this.trackBarW.Scroll += new System.EventHandler(this.scroll);
            // 
            // trackBarH
            // 
            this.trackBarH.Location = new System.Drawing.Point(622, 268);
            this.trackBarH.Maximum = 1000;
            this.trackBarH.Name = "trackBarH";
            this.trackBarH.Size = new System.Drawing.Size(182, 45);
            this.trackBarH.TabIndex = 10;
            this.trackBarH.Scroll += new System.EventHandler(this.scroll);
            // 
            // tbBru
            // 
            this.tbBru.Location = new System.Drawing.Point(704, 331);
            this.tbBru.Name = "tbBru";
            this.tbBru.Size = new System.Drawing.Size(75, 20);
            this.tbBru.TabIndex = 11;
            this.tbBru.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // btnLock
            // 
            this.btnLock.Location = new System.Drawing.Point(677, 208);
            this.btnLock.Name = "btnLock";
            this.btnLock.Size = new System.Drawing.Size(75, 28);
            this.btnLock.TabIndex = 12;
            this.btnLock.Text = "LOCK";
            this.btnLock.UseVisualStyleBackColor = true;
            this.btnLock.Click += new System.EventHandler(this.btnLock_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(831, 590);
            this.Controls.Add(this.btnLock);
            this.Controls.Add(this.tbBru);
            this.Controls.Add(this.trackBarH);
            this.Controls.Add(this.trackBarW);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tbHei);
            this.Controls.Add(this.tbWid);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form2";
            this.Text = "Properties";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarW)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbBru)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbWid;
        private System.Windows.Forms.TextBox tbHei;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TrackBar trackBarW;
        private System.Windows.Forms.TrackBar trackBarH;
        private System.Windows.Forms.NumericUpDown tbBru;
        private System.Windows.Forms.Button btnLock;
    }
}