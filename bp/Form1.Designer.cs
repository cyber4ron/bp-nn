namespace bp
{
    partial class Form1
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
            this.BtnTrain = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.comboBox4 = new System.Windows.Forms.ComboBox();
            this.comboBox5 = new System.Windows.Forms.ComboBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.BtnPause = new System.Windows.Forms.Button();
            this.BtnResume = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openTrainingDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openGeneralizingDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.Parameter = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.Method = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.comboBox6 = new System.Windows.Forms.ComboBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.BtnStop = new System.Windows.Forms.Button();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.Error = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.Fitting = new System.Windows.Forms.TabPage();
            this.Network = new System.Windows.Forms.TabPage();
            this.network1 = new bp.Network();
            this.menuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.Parameter.SuspendLayout();
            this.panel1.SuspendLayout();
            this.Method.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.Error.SuspendLayout();
            this.Network.SuspendLayout();
            this.SuspendLayout();
            // 
            // BtnTrain
            // 
            this.BtnTrain.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnTrain.Location = new System.Drawing.Point(839, 0);
            this.BtnTrain.Name = "BtnTrain";
            this.BtnTrain.Size = new System.Drawing.Size(75, 23);
            this.BtnTrain.TabIndex = 3;
            this.BtnTrain.Text = "Train";
            this.BtnTrain.UseVisualStyleBackColor = true;
            this.BtnTrain.Click += new System.EventHandler(this.BtnTrain_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(110, 5);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 20);
            this.comboBox1.TabIndex = 10;
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(326, 5);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(121, 20);
            this.comboBox2.TabIndex = 11;
            // 
            // comboBox3
            // 
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(614, 5);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(121, 20);
            this.comboBox3.TabIndex = 12;
            // 
            // comboBox4
            // 
            this.comboBox4.FormattingEnabled = true;
            this.comboBox4.Location = new System.Drawing.Point(914, 5);
            this.comboBox4.Name = "comboBox4";
            this.comboBox4.Size = new System.Drawing.Size(121, 20);
            this.comboBox4.TabIndex = 13;
            // 
            // comboBox5
            // 
            this.comboBox5.FormattingEnabled = true;
            this.comboBox5.Location = new System.Drawing.Point(188, 37);
            this.comboBox5.Name = "comboBox5";
            this.comboBox5.Size = new System.Drawing.Size(121, 20);
            this.comboBox5.TabIndex = 14;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(324, 6);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(31, 21);
            this.textBox2.TabIndex = 15;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(468, 6);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(31, 21);
            this.textBox3.TabIndex = 16;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(685, 6);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(100, 21);
            this.textBox4.TabIndex = 17;
            // 
            // BtnPause
            // 
            this.BtnPause.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnPause.Location = new System.Drawing.Point(920, 0);
            this.BtnPause.Name = "BtnPause";
            this.BtnPause.Size = new System.Drawing.Size(75, 23);
            this.BtnPause.TabIndex = 21;
            this.BtnPause.Text = "Pause";
            this.BtnPause.UseVisualStyleBackColor = true;
            this.BtnPause.Click += new System.EventHandler(this.BtnPause_Click);
            // 
            // BtnResume
            // 
            this.BtnResume.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnResume.Location = new System.Drawing.Point(1001, 0);
            this.BtnResume.Name = "BtnResume";
            this.BtnResume.Size = new System.Drawing.Size(75, 23);
            this.BtnResume.TabIndex = 22;
            this.BtnResume.Text = "Resume";
            this.BtnResume.UseVisualStyleBackColor = true;
            this.BtnResume.Click += new System.EventHandler(this.BtnResume_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 12);
            this.label1.TabIndex = 23;
            this.label1.Text = "Network Construct";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 12);
            this.label2.TabIndex = 24;
            this.label2.Text = "Transer Function";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(237, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 12);
            this.label3.TabIndex = 25;
            this.label3.Text = "ErrorFunction";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(453, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(155, 12);
            this.label4.TabIndex = 26;
            this.label4.Text = "Network Initialize Method";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(741, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(167, 12);
            this.label5.TabIndex = 27;
            this.label5.Text = "Learning Rate Modify Method";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 41);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(179, 12);
            this.label6.TabIndex = 28;
            this.label6.Text = "Momentum Factor Modify Method";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(232, 10);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(83, 12);
            this.label7.TabIndex = 29;
            this.label7.Text = "Learning Rate";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(364, 10);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(95, 12);
            this.label8.TabIndex = 30;
            this.label8.Text = "Momentum Factor";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(508, 10);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(167, 12);
            this.label9.TabIndex = 31;
            this.label9.Text = "Max Relative Error(Percent)";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(5, 6);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(47, 12);
            this.label11.TabIndex = 33;
            this.label11.Text = "label11";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(315, 41);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(77, 12);
            this.label14.TabIndex = 40;
            this.label14.Text = "Train Method";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1190, 25);
            this.menuStrip1.TabIndex = 19;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openTrainingDataToolStripMenuItem,
            this.openGeneralizingDataToolStripMenuItem});
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(53, 21);
            this.menuToolStripMenuItem.Text = "&Menu";
            // 
            // openTrainingDataToolStripMenuItem
            // 
            this.openTrainingDataToolStripMenuItem.Name = "openTrainingDataToolStripMenuItem";
            this.openTrainingDataToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.openTrainingDataToolStripMenuItem.Text = "Open &Training data";
            this.openTrainingDataToolStripMenuItem.Click += new System.EventHandler(this.openTrainingDataToolStripMenuItem_Click);
            // 
            // openGeneralizingDataToolStripMenuItem
            // 
            this.openGeneralizingDataToolStripMenuItem.Name = "openGeneralizingDataToolStripMenuItem";
            this.openGeneralizingDataToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.openGeneralizingDataToolStripMenuItem.Text = "Open &Generalizing data";
            this.openGeneralizingDataToolStripMenuItem.Click += new System.EventHandler(this.openGeneralizingDataToolStripMenuItem_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.Parameter);
            this.tabControl1.Controls.Add(this.Method);
            this.tabControl1.Location = new System.Drawing.Point(15, 29);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1163, 111);
            this.tabControl1.TabIndex = 20;
            // 
            // Parameter
            // 
            this.Parameter.Controls.Add(this.panel1);
            this.Parameter.Location = new System.Drawing.Point(4, 22);
            this.Parameter.Name = "Parameter";
            this.Parameter.Padding = new System.Windows.Forms.Padding(3);
            this.Parameter.Size = new System.Drawing.Size(1155, 85);
            this.Parameter.TabIndex = 0;
            this.Parameter.Text = "Parameter";
            this.Parameter.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.textBox4);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.textBox3);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.textBox2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1149, 79);
            this.panel1.TabIndex = 0;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(123, 6);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 21);
            this.textBox1.TabIndex = 21;
            // 
            // Method
            // 
            this.Method.Controls.Add(this.panel2);
            this.Method.Location = new System.Drawing.Point(4, 22);
            this.Method.Name = "Method";
            this.Method.Padding = new System.Windows.Forms.Padding(3);
            this.Method.Size = new System.Drawing.Size(1155, 85);
            this.Method.TabIndex = 1;
            this.Method.Text = "Method";
            this.Method.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.comboBox6);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.comboBox5);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label14);
            this.panel2.Controls.Add(this.comboBox1);
            this.panel2.Controls.Add(this.comboBox4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.comboBox2);
            this.panel2.Controls.Add(this.comboBox3);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1149, 79);
            this.panel2.TabIndex = 0;
            // 
            // comboBox6
            // 
            this.comboBox6.FormattingEnabled = true;
            this.comboBox6.Location = new System.Drawing.Point(398, 37);
            this.comboBox6.Name = "comboBox6";
            this.comboBox6.Size = new System.Drawing.Size(121, 20);
            this.comboBox6.TabIndex = 41;
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.Controls.Add(this.BtnStop);
            this.panel4.Controls.Add(this.label11);
            this.panel4.Controls.Add(this.BtnTrain);
            this.panel4.Controls.Add(this.BtnPause);
            this.panel4.Controls.Add(this.BtnResume);
            this.panel4.Location = new System.Drawing.Point(15, 145);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1163, 27);
            this.panel4.TabIndex = 22;
            // 
            // BtnStop
            // 
            this.BtnStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnStop.Location = new System.Drawing.Point(1082, 0);
            this.BtnStop.Name = "BtnStop";
            this.BtnStop.Size = new System.Drawing.Size(75, 23);
            this.BtnStop.TabIndex = 34;
            this.BtnStop.Text = "Stop";
            this.BtnStop.UseVisualStyleBackColor = true;
            this.BtnStop.Click += new System.EventHandler(this.BtnStop_Click);
            // 
            // tabControl2
            // 
            this.tabControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl2.Controls.Add(this.Error);
            this.tabControl2.Controls.Add(this.Fitting);
            this.tabControl2.Controls.Add(this.Network);
            this.tabControl2.Location = new System.Drawing.Point(15, 178);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(1163, 254);
            this.tabControl2.TabIndex = 24;
            // 
            // Error
            // 
            this.Error.Controls.Add(this.tableLayoutPanel2);
            this.Error.Location = new System.Drawing.Point(4, 22);
            this.Error.Name = "Error";
            this.Error.Padding = new System.Windows.Forms.Padding(3);
            this.Error.Size = new System.Drawing.Size(1155, 228);
            this.Error.TabIndex = 0;
            this.Error.Text = "Error";
            this.Error.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoScroll = true;
            this.tableLayoutPanel2.AutoScrollMargin = new System.Drawing.Size(10, 10);
            this.tableLayoutPanel2.AutoScrollMinSize = new System.Drawing.Size(10, 10);
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1149, 222);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // Fitting
            // 
            this.Fitting.Location = new System.Drawing.Point(4, 22);
            this.Fitting.Name = "Fitting";
            this.Fitting.Padding = new System.Windows.Forms.Padding(3);
            this.Fitting.Size = new System.Drawing.Size(1155, 228);
            this.Fitting.TabIndex = 1;
            this.Fitting.Text = "Fitting";
            this.Fitting.UseVisualStyleBackColor = true;
            // 
            // Network
            // 
            this.Network.Controls.Add(this.network1);
            this.Network.Location = new System.Drawing.Point(4, 22);
            this.Network.Name = "Network";
            this.Network.Size = new System.Drawing.Size(1155, 228);
            this.Network.TabIndex = 3;
            this.Network.Text = "Network";
            this.Network.UseVisualStyleBackColor = true;
            // 
            // network1
            // 
            this.network1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.network1.Location = new System.Drawing.Point(0, 0);
            this.network1.Name = "network1";
            this.network1.Size = new System.Drawing.Size(1155, 228);
            this.network1.TabIndex = 0;
            this.network1.Text = "network1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1190, 444);
            this.Controls.Add(this.tabControl2);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.Parameter.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.Method.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.tabControl2.ResumeLayout(false);
            this.Error.ResumeLayout(false);
            this.Network.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnTrain;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.ComboBox comboBox4;
        private System.Windows.Forms.ComboBox comboBox5;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Button BtnPause;
        private System.Windows.Forms.Button BtnResume;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage Parameter;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TabPage Method;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage Error;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TabPage Fitting;
        private System.Windows.Forms.TabPage Network;
        private System.Windows.Forms.ComboBox comboBox6;
        private System.Windows.Forms.ToolStripMenuItem openTrainingDataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openGeneralizingDataToolStripMenuItem;
        private Network network1;
        private System.Windows.Forms.Button BtnStop;
    }
}

