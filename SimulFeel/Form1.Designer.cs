namespace SimulFeel
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
            this.components = new System.ComponentModel.Container();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.deviceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.connectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button1 = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.textStart = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textEnd = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.textSpeed = new System.Windows.Forms.TextBox();
            this.textDelay = new System.Windows.Forms.TextBox();
            this.button9 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.textMin = new System.Windows.Forms.TextBox();
            this.textMax = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.trackSpeed = new System.Windows.Forms.TrackBar();
            this.button11 = new System.Windows.Forms.Button();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.button12 = new System.Windows.Forms.Button();
            this.timer3 = new System.Windows.Forms.Timer(this.components);
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackSpeed)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2});
            this.statusStrip1.Location = new System.Drawing.Point(0, 207);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(613, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.toolStripStatusLabel1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(538, 17);
            this.toolStripStatusLabel1.Spring = true;
            this.toolStripStatusLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(60, 17);
            this.toolStripStatusLabel2.Text = "No device";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deviceToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(613, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // deviceToolStripMenuItem
            // 
            this.deviceToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.connectToolStripMenuItem,
            this.scanToolStripMenuItem});
            this.deviceToolStripMenuItem.Name = "deviceToolStripMenuItem";
            this.deviceToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.deviceToolStripMenuItem.Text = "Device";
            // 
            // connectToolStripMenuItem
            // 
            this.connectToolStripMenuItem.Name = "connectToolStripMenuItem";
            this.connectToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.connectToolStripMenuItem.Text = "Connect to Intiface";
            this.connectToolStripMenuItem.Click += new System.EventHandler(this.ConnectToolStripMenuItem_ClickAsync);
            // 
            // scanToolStripMenuItem
            // 
            this.scanToolStripMenuItem.Enabled = false;
            this.scanToolStripMenuItem.Name = "scanToolStripMenuItem";
            this.scanToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.scanToolStripMenuItem.Text = "Scan for device";
            this.scanToolStripMenuItem.Click += new System.EventHandler(this.ScanToolStripMenuItem_ClickAsync);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(22, 102);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(66, 31);
            this.button1.TabIndex = 2;
            this.button1.Text = "Full";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_ClickAsync);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(99, 56);
            this.progressBar1.Maximum = 99;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(349, 31);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(99, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(493, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Visualizer";
            // 
            // timer2
            // 
            this.timer2.Interval = 25;
            this.timer2.Tick += new System.EventHandler(this.Timer2_Tick);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(526, 56);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(66, 31);
            this.button2.TabIndex = 7;
            this.button2.Text = "Stop";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button2_ClickAsync);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(94, 102);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(66, 31);
            this.button3.TabIndex = 9;
            this.button3.Text = "Top";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.Button3_ClickAsync);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(166, 102);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(66, 31);
            this.button4.TabIndex = 10;
            this.button4.Text = "Bottom";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.Button4_ClickAsync);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(238, 102);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(66, 31);
            this.button5.TabIndex = 11;
            this.button5.Text = "Mix1";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.Button5_ClickAsync);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(310, 102);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(66, 31);
            this.button6.TabIndex = 12;
            this.button6.Text = "Mix 2";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.Button6_ClickAsync);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(382, 102);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(66, 31);
            this.button7.TabIndex = 13;
            this.button7.Text = "Tease";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.Button7_ClickAsync);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(454, 102);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(66, 31);
            this.button8.TabIndex = 14;
            this.button8.Text = "Edge 1";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.Button8_ClickAsync);
            // 
            // textStart
            // 
            this.textStart.Location = new System.Drawing.Point(22, 165);
            this.textStart.Name = "textStart";
            this.textStart.Size = new System.Drawing.Size(49, 22);
            this.textStart.TabIndex = 17;
            this.textStart.Text = "49";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 145);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 16);
            this.label2.TabIndex = 18;
            this.label2.Text = "Start";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(74, 145);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 16);
            this.label3.TabIndex = 19;
            this.label3.Text = "End";
            // 
            // textEnd
            // 
            this.textEnd.Location = new System.Drawing.Point(77, 165);
            this.textEnd.Name = "textEnd";
            this.textEnd.Size = new System.Drawing.Size(49, 22);
            this.textEnd.TabIndex = 20;
            this.textEnd.Text = "99";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(129, 145);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 16);
            this.label6.TabIndex = 21;
            this.label6.Text = "Speed";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(184, 145);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 16);
            this.label7.TabIndex = 22;
            this.label7.Text = "Delay";
            // 
            // textSpeed
            // 
            this.textSpeed.Location = new System.Drawing.Point(132, 165);
            this.textSpeed.Name = "textSpeed";
            this.textSpeed.Size = new System.Drawing.Size(49, 22);
            this.textSpeed.TabIndex = 24;
            this.textSpeed.Text = "49";
            // 
            // textDelay
            // 
            this.textDelay.Location = new System.Drawing.Point(187, 165);
            this.textDelay.Name = "textDelay";
            this.textDelay.Size = new System.Drawing.Size(49, 22);
            this.textDelay.TabIndex = 25;
            this.textDelay.Text = "500";
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(248, 156);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(66, 31);
            this.button9.TabIndex = 27;
            this.button9.Text = "Start";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.Button9_ClickAsync);
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(320, 156);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(66, 31);
            this.button10.TabIndex = 28;
            this.button10.Text = "Stop";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.Button10_ClickAsync);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(396, 167);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(187, 20);
            this.checkBox1.TabIndex = 29;
            this.checkBox1.Text = "Send commands to device";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // textMin
            // 
            this.textMin.Location = new System.Drawing.Point(58, 36);
            this.textMin.Name = "textMin";
            this.textMin.Size = new System.Drawing.Size(30, 22);
            this.textMin.TabIndex = 30;
            this.textMin.Text = "49";
            // 
            // textMax
            // 
            this.textMax.Location = new System.Drawing.Point(58, 64);
            this.textMax.Name = "textMax";
            this.textMax.Size = new System.Drawing.Size(30, 22);
            this.textMax.TabIndex = 31;
            this.textMax.Text = "99";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(19, 41);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 16);
            this.label5.TabIndex = 32;
            this.label5.Text = "Min";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(19, 67);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(33, 16);
            this.label8.TabIndex = 33;
            this.label8.Text = "Max";
            // 
            // trackSpeed
            // 
            this.trackSpeed.AutoSize = false;
            this.trackSpeed.LargeChange = 1;
            this.trackSpeed.Location = new System.Drawing.Point(448, 146);
            this.trackSpeed.Maximum = 2;
            this.trackSpeed.Name = "trackSpeed";
            this.trackSpeed.Size = new System.Drawing.Size(144, 22);
            this.trackSpeed.TabIndex = 34;
            this.trackSpeed.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.trackSpeed.Value = 1;
            this.trackSpeed.Scroll += new System.EventHandler(this.TrackSpeed_Scroll);
            // 
            // button11
            // 
            this.button11.Location = new System.Drawing.Point(526, 102);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(66, 31);
            this.button11.TabIndex = 36;
            this.button11.Text = "Edge 2";
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.Button11_ClickAsync);
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(396, 147);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(55, 20);
            this.checkBox2.TabIndex = 38;
            this.checkBox2.Text = "Vary";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.CheckBox2_CheckedChanged);
            // 
            // timer1
            // 
            this.timer1.Interval = 3000;
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // button12
            // 
            this.button12.Location = new System.Drawing.Point(454, 56);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(66, 31);
            this.button12.TabIndex = 39;
            this.button12.Text = "Auto";
            this.button12.UseVisualStyleBackColor = true;
            this.button12.Click += new System.EventHandler(this.Button12_ClickAsync);
            // 
            // timer3
            // 
            this.timer3.Interval = 1000;
            this.timer3.Tick += new System.EventHandler(this.Timer3_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(613, 229);
            this.Controls.Add(this.button12);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.button11);
            this.Controls.Add(this.trackSpeed);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textMax);
            this.Controls.Add(this.textMin);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.button10);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.textDelay);
            this.Controls.Add(this.textSpeed);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textEnd);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textStart);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "SimulFeel";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackSpeed)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        public System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripMenuItem deviceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem connectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scanToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.TextBox textStart;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textEnd;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textSpeed;
        private System.Windows.Forms.TextBox textDelay;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.TextBox textMin;
        private System.Windows.Forms.TextBox textMax;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TrackBar trackSpeed;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.Timer timer3;
    }
}

