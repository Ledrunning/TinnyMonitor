namespace TinnyClock
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.cboData = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cmdClose = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rdoText = new System.Windows.Forms.RadioButton();
            this.rdoHex = new System.Windows.Forms.RadioButton();
            this.cmdOpen = new System.Windows.Forms.Button();
            this.cboStop = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboParity = new System.Windows.Forms.ComboBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.cboBaud = new System.Windows.Forms.ComboBox();
            this.cboPort = new System.Windows.Forms.ComboBox();
            this.monitor = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.TimeLabel = new System.Windows.Forms.Label();
            this.DateLabel = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lightLevel = new System.Windows.Forms.Label();
            this.huMidity = new System.Windows.Forms.Label();
            this.outsideTemp = new System.Windows.Forms.Label();
            this.insideTemp = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.ConsoleClear = new System.Windows.Forms.Button();
            this.cmdSend = new System.Windows.Forms.Button();
            this.txtSend = new System.Windows.Forms.TextBox();
            this.rtbDisplay = new System.Windows.Forms.RichTextBox();
            this.graphView = new System.Windows.Forms.TabPage();
            this.readData = new System.Windows.Forms.Button();
            this.telemetryGraph = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.clearBuffer = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.FirmwBuffer = new System.Windows.Forms.RichTextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.sAsButton = new System.Windows.Forms.Button();
            this.OpenFrmw = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.monitor.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.GroupBox1.SuspendLayout();
            this.graphView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.telemetryGraph)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // cboData
            // 
            this.cboData.FormattingEnabled = true;
            this.cboData.Items.AddRange(new object[] {
            "7",
            "8",
            "9"});
            this.cboData.Location = new System.Drawing.Point(9, 195);
            this.cboData.Name = "cboData";
            this.cboData.Size = new System.Drawing.Size(100, 21);
            this.cboData.TabIndex = 14;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 139);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "Stop Bits";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 179);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "Data Bits";
            // 
            // cmdClose
            // 
            this.cmdClose.Location = new System.Drawing.Point(632, 285);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(55, 37);
            this.cmdClose.TabIndex = 5;
            this.cmdClose.Text = "Close Port";
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.ComPortCloseClick);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rdoText);
            this.groupBox3.Controls.Add(this.rdoHex);
            this.groupBox3.Controls.Add(this.cmdOpen);
            this.groupBox3.Location = new System.Drawing.Point(574, 240);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(113, 88);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Mode";
            // 
            // rdoText
            // 
            this.rdoText.AutoSize = true;
            this.rdoText.Location = new System.Drawing.Point(6, 38);
            this.rdoText.Name = "rdoText";
            this.rdoText.Size = new System.Drawing.Size(46, 17);
            this.rdoText.TabIndex = 1;
            this.rdoText.TabStop = true;
            this.rdoText.Text = "Text";
            this.rdoText.UseVisualStyleBackColor = true;
            // 
            // rdoHex
            // 
            this.rdoHex.AutoSize = true;
            this.rdoHex.Location = new System.Drawing.Point(6, 16);
            this.rdoHex.Name = "rdoHex";
            this.rdoHex.Size = new System.Drawing.Size(44, 17);
            this.rdoHex.TabIndex = 0;
            this.rdoHex.TabStop = true;
            this.rdoHex.Text = "Hex";
            this.rdoHex.UseVisualStyleBackColor = true;
            this.rdoHex.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // cmdOpen
            // 
            this.cmdOpen.Location = new System.Drawing.Point(58, 0);
            this.cmdOpen.Name = "cmdOpen";
            this.cmdOpen.Size = new System.Drawing.Size(55, 41);
            this.cmdOpen.TabIndex = 8;
            this.cmdOpen.Text = "Open Port";
            this.cmdOpen.UseVisualStyleBackColor = true;
            this.cmdOpen.Click += new System.EventHandler(this.ComPortOpenClick);
            // 
            // cboStop
            // 
            this.cboStop.FormattingEnabled = true;
            this.cboStop.Location = new System.Drawing.Point(9, 155);
            this.cboStop.Name = "cboStop";
            this.cboStop.Size = new System.Drawing.Size(100, 21);
            this.cboStop.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Parity";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.cboData);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.cboStop);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.cboParity);
            this.groupBox2.Controls.Add(this.Label1);
            this.groupBox2.Controls.Add(this.cboBaud);
            this.groupBox2.Controls.Add(this.cboPort);
            this.groupBox2.Location = new System.Drawing.Point(578, 13);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(109, 221);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Options";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Baud Rate";
            // 
            // cboParity
            // 
            this.cboParity.FormattingEnabled = true;
            this.cboParity.Location = new System.Drawing.Point(9, 114);
            this.cboParity.Name = "cboParity";
            this.cboParity.Size = new System.Drawing.Size(100, 21);
            this.cboParity.TabIndex = 12;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(6, 18);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(26, 13);
            this.Label1.TabIndex = 15;
            this.Label1.Text = "Port";
            // 
            // cboBaud
            // 
            this.cboBaud.FormattingEnabled = true;
            this.cboBaud.Items.AddRange(new object[] {
            "300",
            "600",
            "1200",
            "2400",
            "4800",
            "9600",
            "14400",
            "28800",
            "36000",
            "115000"});
            this.cboBaud.Location = new System.Drawing.Point(9, 74);
            this.cboBaud.Name = "cboBaud";
            this.cboBaud.Size = new System.Drawing.Size(100, 21);
            this.cboBaud.TabIndex = 11;
            // 
            // cboPort
            // 
            this.cboPort.FormattingEnabled = true;
            this.cboPort.Location = new System.Drawing.Point(9, 34);
            this.cboPort.Name = "cboPort";
            this.cboPort.Size = new System.Drawing.Size(100, 21);
            this.cboPort.TabIndex = 10;
            // 
            // monitor
            // 
            this.monitor.Controls.Add(this.tabPage1);
            this.monitor.Controls.Add(this.tabPage2);
            this.monitor.Controls.Add(this.graphView);
            this.monitor.Controls.Add(this.tabPage3);
            this.monitor.Location = new System.Drawing.Point(3, -2);
            this.monitor.Name = "monitor";
            this.monitor.SelectedIndex = 0;
            this.monitor.Size = new System.Drawing.Size(569, 330);
            this.monitor.TabIndex = 8;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label15);
            this.tabPage1.Controls.Add(this.label16);
            this.tabPage1.Controls.Add(this.TimeLabel);
            this.tabPage1.Controls.Add(this.DateLabel);
            this.tabPage1.Controls.Add(this.label13);
            this.tabPage1.Controls.Add(this.label12);
            this.tabPage1.Controls.Add(this.label11);
            this.tabPage1.Controls.Add(this.label10);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.lightLevel);
            this.tabPage1.Controls.Add(this.huMidity);
            this.tabPage1.Controls.Add(this.outsideTemp);
            this.tabPage1.Controls.Add(this.insideTemp);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(561, 304);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Monitor";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label15.Location = new System.Drawing.Point(384, 124);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(43, 20);
            this.label15.TabIndex = 16;
            this.label15.Text = "Time";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label16.Location = new System.Drawing.Point(384, 25);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(44, 20);
            this.label16.TabIndex = 14;
            this.label16.Text = "Date";
            // 
            // TimeLabel
            // 
            this.TimeLabel.BackColor = System.Drawing.Color.Transparent;
            this.TimeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TimeLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.TimeLabel.Location = new System.Drawing.Point(384, 153);
            this.TimeLabel.Name = "TimeLabel";
            this.TimeLabel.Size = new System.Drawing.Size(89, 48);
            this.TimeLabel.TabIndex = 13;
            this.TimeLabel.Text = "--:--:--";
            this.TimeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DateLabel
            // 
            this.DateLabel.BackColor = System.Drawing.Color.Transparent;
            this.DateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DateLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.DateLabel.Location = new System.Drawing.Point(384, 56);
            this.DateLabel.Name = "DateLabel";
            this.DateLabel.Size = new System.Drawing.Size(89, 48);
            this.DateLabel.TabIndex = 12;
            this.DateLabel.Text = "--.--.----";
            this.DateLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label13.Location = new System.Drawing.Point(316, 170);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(23, 20);
            this.label13.TabIndex = 11;
            this.label13.Text = "%";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label12.Location = new System.Drawing.Point(316, 74);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(23, 20);
            this.label12.TabIndex = 10;
            this.label12.Text = "%";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label11.Location = new System.Drawing.Point(143, 172);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(25, 20);
            this.label11.TabIndex = 9;
            this.label11.Text = "°C";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label10.Location = new System.Drawing.Point(143, 74);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(25, 20);
            this.label10.TabIndex = 8;
            this.label10.Text = "°C";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.Location = new System.Drawing.Point(207, 124);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(79, 20);
            this.label9.TabIndex = 7;
            this.label9.Text = "Light level";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(207, 23);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(70, 20);
            this.label8.TabIndex = 6;
            this.label8.Text = "Humidity";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(32, 125);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(155, 20);
            this.label7.TabIndex = 5;
            this.label7.Text = "Outside temperature";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(33, 23);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(143, 20);
            this.label6.TabIndex = 4;
            this.label6.Text = "Inside temperature";
            // 
            // lightLevel
            // 
            this.lightLevel.BackColor = System.Drawing.Color.Transparent;
            this.lightLevel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lightLevel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lightLevel.Location = new System.Drawing.Point(207, 159);
            this.lightLevel.Name = "lightLevel";
            this.lightLevel.Size = new System.Drawing.Size(89, 48);
            this.lightLevel.TabIndex = 3;
            this.lightLevel.Text = "----------------";
            this.lightLevel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // huMidity
            // 
            this.huMidity.BackColor = System.Drawing.Color.Transparent;
            this.huMidity.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.huMidity.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.huMidity.Location = new System.Drawing.Point(207, 56);
            this.huMidity.Name = "huMidity";
            this.huMidity.Size = new System.Drawing.Size(89, 48);
            this.huMidity.TabIndex = 2;
            this.huMidity.Text = "----------------";
            this.huMidity.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // outsideTemp
            // 
            this.outsideTemp.BackColor = System.Drawing.Color.Transparent;
            this.outsideTemp.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.outsideTemp.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.outsideTemp.Location = new System.Drawing.Point(34, 159);
            this.outsideTemp.Name = "outsideTemp";
            this.outsideTemp.Size = new System.Drawing.Size(94, 48);
            this.outsideTemp.TabIndex = 1;
            this.outsideTemp.Text = "-----------------";
            this.outsideTemp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // insideTemp
            // 
            this.insideTemp.BackColor = System.Drawing.Color.Transparent;
            this.insideTemp.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.insideTemp.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.insideTemp.Location = new System.Drawing.Point(34, 56);
            this.insideTemp.Name = "insideTemp";
            this.insideTemp.Size = new System.Drawing.Size(94, 48);
            this.insideTemp.TabIndex = 0;
            this.insideTemp.Text = "-----------------";
            this.insideTemp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.GroupBox1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(561, 304);
            this.tabPage2.TabIndex = 0;
            this.tabPage2.Text = "Console";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.ConsoleClear);
            this.GroupBox1.Controls.Add(this.cmdSend);
            this.GroupBox1.Controls.Add(this.txtSend);
            this.GroupBox1.Controls.Add(this.rtbDisplay);
            this.GroupBox1.Location = new System.Drawing.Point(2, 8);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(556, 288);
            this.GroupBox1.TabIndex = 9;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "Serial Port Communication";
            // 
            // ConsoleClear
            // 
            this.ConsoleClear.Location = new System.Drawing.Point(475, 260);
            this.ConsoleClear.Name = "ConsoleClear";
            this.ConsoleClear.Size = new System.Drawing.Size(75, 23);
            this.ConsoleClear.TabIndex = 6;
            this.ConsoleClear.Text = "Clear";
            this.ConsoleClear.UseVisualStyleBackColor = true;
            this.ConsoleClear.Click += new System.EventHandler(this.ConsoleClearClick);
            // 
            // cmdSend
            // 
            this.cmdSend.Location = new System.Drawing.Point(380, 259);
            this.cmdSend.Name = "cmdSend";
            this.cmdSend.Size = new System.Drawing.Size(75, 23);
            this.cmdSend.TabIndex = 5;
            this.cmdSend.Text = "Send";
            this.cmdSend.UseVisualStyleBackColor = true;
            this.cmdSend.Click += new System.EventHandler(this.SendToComPortClick);
            // 
            // txtSend
            // 
            this.txtSend.Location = new System.Drawing.Point(7, 259);
            this.txtSend.Name = "txtSend";
            this.txtSend.Size = new System.Drawing.Size(367, 20);
            this.txtSend.TabIndex = 4;
            // 
            // rtbDisplay
            // 
            this.rtbDisplay.Location = new System.Drawing.Point(7, 19);
            this.rtbDisplay.Name = "rtbDisplay";
            this.rtbDisplay.Size = new System.Drawing.Size(543, 234);
            this.rtbDisplay.TabIndex = 3;
            this.rtbDisplay.Text = "";
            // 
            // graphView
            // 
            this.graphView.Controls.Add(this.readData);
            this.graphView.Controls.Add(this.telemetryGraph);
            this.graphView.Location = new System.Drawing.Point(4, 22);
            this.graphView.Name = "graphView";
            this.graphView.Padding = new System.Windows.Forms.Padding(3);
            this.graphView.Size = new System.Drawing.Size(561, 304);
            this.graphView.TabIndex = 1;
            this.graphView.Text = "Graph";
            this.graphView.UseVisualStyleBackColor = true;
            // 
            // readData
            // 
            this.readData.Location = new System.Drawing.Point(380, 252);
            this.readData.Name = "readData";
            this.readData.Size = new System.Drawing.Size(75, 23);
            this.readData.TabIndex = 1;
            this.readData.Text = "Read data";
            this.readData.UseVisualStyleBackColor = true;
            this.readData.Click += new System.EventHandler(this.DataReadClick);
            // 
            // telemetryGraph
            // 
            chartArea1.Name = "ChartArea1";
            this.telemetryGraph.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.telemetryGraph.Legends.Add(legend1);
            this.telemetryGraph.Location = new System.Drawing.Point(0, 7);
            this.telemetryGraph.Name = "telemetryGraph";
            series1.BorderWidth = 3;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.LabelBorderWidth = 2;
            series1.Legend = "Legend1";
            series1.Name = "Inside Temperature";
            series2.BorderWidth = 3;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Color = System.Drawing.Color.Lime;
            series2.LabelBorderWidth = 2;
            series2.Legend = "Legend1";
            series2.Name = "Outside Temperature";
            series3.BorderWidth = 3;
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series3.LabelBorderWidth = 2;
            series3.Legend = "Legend1";
            series3.Name = "Humidity";
            series4.BorderWidth = 3;
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series4.EmptyPointStyle.Color = System.Drawing.Color.Red;
            series4.LabelBorderWidth = 2;
            series4.Legend = "Legend1";
            series4.Name = "Light Level";
            this.telemetryGraph.Series.Add(series1);
            this.telemetryGraph.Series.Add(series2);
            this.telemetryGraph.Series.Add(series3);
            this.telemetryGraph.Series.Add(series4);
            this.telemetryGraph.Size = new System.Drawing.Size(555, 300);
            this.telemetryGraph.TabIndex = 0;
            this.telemetryGraph.Text = "Diagramm";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.clearBuffer);
            this.tabPage3.Controls.Add(this.saveButton);
            this.tabPage3.Controls.Add(this.progressBar);
            this.tabPage3.Controls.Add(this.FirmwBuffer);
            this.tabPage3.Controls.Add(this.button2);
            this.tabPage3.Controls.Add(this.sAsButton);
            this.tabPage3.Controls.Add(this.OpenFrmw);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(561, 304);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Flash Device";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // clearBuffer
            // 
            this.clearBuffer.Location = new System.Drawing.Point(0, 160);
            this.clearBuffer.Name = "clearBuffer";
            this.clearBuffer.Size = new System.Drawing.Size(177, 37);
            this.clearBuffer.TabIndex = 6;
            this.clearBuffer.Text = "Clear buffer";
            this.clearBuffer.UseVisualStyleBackColor = true;
            this.clearBuffer.Click += new System.EventHandler(this.ClearBufferClick);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(67, 4);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(55, 41);
            this.saveButton.TabIndex = 5;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.SaveButtonClick);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(0, 278);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(183, 23);
            this.progressBar.TabIndex = 4;
            // 
            // FirmwBuffer
            // 
            this.FirmwBuffer.Location = new System.Drawing.Point(226, 3);
            this.FirmwBuffer.Name = "FirmwBuffer";
            this.FirmwBuffer.Size = new System.Drawing.Size(335, 299);
            this.FirmwBuffer.TabIndex = 3;
            this.FirmwBuffer.Text = "";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(0, 224);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(177, 37);
            this.button2.TabIndex = 2;
            this.button2.Text = "Flash!";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // sAsButton
            // 
            this.sAsButton.Location = new System.Drawing.Point(128, 3);
            this.sAsButton.Name = "sAsButton";
            this.sAsButton.Size = new System.Drawing.Size(55, 41);
            this.sAsButton.TabIndex = 1;
            this.sAsButton.Text = "Save As";
            this.sAsButton.UseVisualStyleBackColor = true;
            this.sAsButton.Click += new System.EventHandler(this.SaveAsButtonClick);
            // 
            // OpenFrmw
            // 
            this.OpenFrmw.Location = new System.Drawing.Point(6, 3);
            this.OpenFrmw.Name = "OpenFrmw";
            this.OpenFrmw.Size = new System.Drawing.Size(55, 41);
            this.OpenFrmw.TabIndex = 0;
            this.OpenFrmw.Text = "Open ";
            this.OpenFrmw.UseVisualStyleBackColor = true;
            this.OpenFrmw.Click += new System.EventHandler(this.OpenFirmwareClick);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.OnTimerTick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(710, 334);
            this.Controls.Add(this.monitor);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tinny Clock Monitor 1.0.0";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.monitor.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.graphView.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.telemetryGraph)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cboData;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button cmdClose;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton rdoText;
        private System.Windows.Forms.RadioButton rdoHex;
        private System.Windows.Forms.ComboBox cboStop;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboParity;
        private System.Windows.Forms.Label Label1;
        private System.Windows.Forms.ComboBox cboBaud;
        private System.Windows.Forms.ComboBox cboPort;
        private System.Windows.Forms.Button cmdOpen;
        private System.Windows.Forms.TabControl monitor;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox GroupBox1;
        private System.Windows.Forms.Button cmdSend;
        private System.Windows.Forms.TextBox txtSend;
        private System.Windows.Forms.RichTextBox rtbDisplay;
        private System.Windows.Forms.Button ConsoleClear;
        private System.Windows.Forms.TabPage graphView;
        private System.Windows.Forms.DataVisualization.Charting.Chart telemetryGraph;
        private System.Windows.Forms.Label insideTemp;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lightLevel;
        private System.Windows.Forms.Label huMidity;
        private System.Windows.Forms.Label outsideTemp;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.RichTextBox FirmwBuffer;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button sAsButton;
        private System.Windows.Forms.Button OpenFrmw;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label TimeLabel;
        private System.Windows.Forms.Label DateLabel;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button clearBuffer;
        private System.Windows.Forms.Button readData;
    }
}