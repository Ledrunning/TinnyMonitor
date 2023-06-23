namespace TinyMonitorApp.View
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.materialTabSelector1 = new MaterialSkin.Controls.MaterialTabSelector();
            this.materialTabControl1 = new MaterialSkin.Controls.MaterialTabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.timeLabel = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel11 = new MaterialSkin.Controls.MaterialLabel();
            this.lightLevel = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel9 = new MaterialSkin.Controls.MaterialLabel();
            this.outsideTemp = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel7 = new MaterialSkin.Controls.MaterialLabel();
            this.dateLabel = new MaterialSkin.Controls.MaterialLabel();
            this.humidity = new MaterialSkin.Controls.MaterialLabel();
            this.insideTemp = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.lb = new MaterialSkin.Controls.MaterialLabel();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.rtbDisplay = new System.Windows.Forms.RichTextBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.clearButton = new MaterialSkin.Controls.MaterialRaisedButton();
            this.portSendButton = new MaterialSkin.Controls.MaterialRaisedButton();
            this.txtSend = new System.Windows.Forms.RichTextBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.drawChartButton = new MaterialSkin.Controls.MaterialRaisedButton();
            this.plotView = new OxyPlot.WindowsForms.PlotView();
            this.ComPortName = new System.Windows.Forms.ComboBox();
            this.cboBaudRates = new System.Windows.Forms.ComboBox();
            this.cboParity = new System.Windows.Forms.ComboBox();
            this.cboStopBits = new System.Windows.Forms.ComboBox();
            this.cboDataBits = new System.Windows.Forms.ComboBox();
            this.materialLabel13 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel14 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel15 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel16 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel17 = new MaterialSkin.Controls.MaterialLabel();
            this.portOpenButton = new MaterialSkin.Controls.MaterialRaisedButton();
            this.portCloseButton = new MaterialSkin.Controls.MaterialRaisedButton();
            this.rdoHex = new MaterialSkin.Controls.MaterialRadioButton();
            this.rdoText = new MaterialSkin.Controls.MaterialRadioButton();
            this.themeButton = new MaterialSkin.Controls.MaterialRaisedButton();
            this.colorButton = new MaterialSkin.Controls.MaterialRaisedButton();
            this.materialTabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.OnTimerTick);
            // 
            // materialTabSelector1
            // 
            this.materialTabSelector1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.materialTabSelector1.BaseTabControl = this.materialTabControl1;
            this.materialTabSelector1.Depth = 0;
            this.materialTabSelector1.Location = new System.Drawing.Point(0, 79);
            this.materialTabSelector1.Margin = new System.Windows.Forms.Padding(4);
            this.materialTabSelector1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialTabSelector1.Name = "materialTabSelector1";
            this.materialTabSelector1.Size = new System.Drawing.Size(987, 59);
            this.materialTabSelector1.TabIndex = 18;
            this.materialTabSelector1.Text = "materialTabSelector1";
            // 
            // materialTabControl1
            // 
            this.materialTabControl1.Controls.Add(this.tabPage1);
            this.materialTabControl1.Controls.Add(this.tabPage2);
            this.materialTabControl1.Controls.Add(this.tabPage3);
            this.materialTabControl1.Depth = 0;
            this.materialTabControl1.Location = new System.Drawing.Point(0, 143);
            this.materialTabControl1.Margin = new System.Windows.Forms.Padding(4);
            this.materialTabControl1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialTabControl1.Name = "materialTabControl1";
            this.materialTabControl1.SelectedIndex = 0;
            this.materialTabControl1.Size = new System.Drawing.Size(777, 460);
            this.materialTabControl1.TabIndex = 19;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.timeLabel);
            this.tabPage1.Controls.Add(this.materialLabel11);
            this.tabPage1.Controls.Add(this.lightLevel);
            this.tabPage1.Controls.Add(this.materialLabel9);
            this.tabPage1.Controls.Add(this.outsideTemp);
            this.tabPage1.Controls.Add(this.materialLabel7);
            this.tabPage1.Controls.Add(this.dateLabel);
            this.tabPage1.Controls.Add(this.humidity);
            this.tabPage1.Controls.Add(this.insideTemp);
            this.tabPage1.Controls.Add(this.materialLabel3);
            this.tabPage1.Controls.Add(this.materialLabel2);
            this.tabPage1.Controls.Add(this.lb);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage1.Size = new System.Drawing.Size(769, 431);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Monitor";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // timeLabel
            // 
            this.timeLabel.AutoSize = true;
            this.timeLabel.Depth = 0;
            this.timeLabel.Font = new System.Drawing.Font("Roboto", 11F);
            this.timeLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.timeLabel.Location = new System.Drawing.Point(605, 267);
            this.timeLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.timeLabel.MouseState = MaterialSkin.MouseState.HOVER;
            this.timeLabel.Name = "timeLabel";
            this.timeLabel.Size = new System.Drawing.Size(50, 24);
            this.timeLabel.TabIndex = 11;
            this.timeLabel.Text = "--:--:--";
            // 
            // materialLabel11
            // 
            this.materialLabel11.AutoSize = true;
            this.materialLabel11.Depth = 0;
            this.materialLabel11.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel11.Location = new System.Drawing.Point(605, 197);
            this.materialLabel11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.materialLabel11.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel11.Name = "materialLabel11";
            this.materialLabel11.Size = new System.Drawing.Size(53, 24);
            this.materialLabel11.TabIndex = 10;
            this.materialLabel11.Text = "Time";
            // 
            // lightLevel
            // 
            this.lightLevel.AutoSize = true;
            this.lightLevel.Depth = 0;
            this.lightLevel.Font = new System.Drawing.Font("Roboto", 11F);
            this.lightLevel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lightLevel.Location = new System.Drawing.Point(333, 267);
            this.lightLevel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lightLevel.MouseState = MaterialSkin.MouseState.HOVER;
            this.lightLevel.Name = "lightLevel";
            this.lightLevel.Size = new System.Drawing.Size(65, 24);
            this.lightLevel.TabIndex = 9;
            this.lightLevel.Text = "-----------";
            // 
            // materialLabel9
            // 
            this.materialLabel9.AutoSize = true;
            this.materialLabel9.Depth = 0;
            this.materialLabel9.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel9.Location = new System.Drawing.Point(333, 197);
            this.materialLabel9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.materialLabel9.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel9.Name = "materialLabel9";
            this.materialLabel9.Size = new System.Drawing.Size(101, 24);
            this.materialLabel9.TabIndex = 8;
            this.materialLabel9.Text = "Light Level";
            // 
            // outsideTemp
            // 
            this.outsideTemp.AutoSize = true;
            this.outsideTemp.Depth = 0;
            this.outsideTemp.Font = new System.Drawing.Font("Roboto", 11F);
            this.outsideTemp.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.outsideTemp.Location = new System.Drawing.Point(57, 267);
            this.outsideTemp.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.outsideTemp.MouseState = MaterialSkin.MouseState.HOVER;
            this.outsideTemp.Name = "outsideTemp";
            this.outsideTemp.Size = new System.Drawing.Size(65, 24);
            this.outsideTemp.TabIndex = 7;
            this.outsideTemp.Text = "-----------";
            // 
            // materialLabel7
            // 
            this.materialLabel7.AutoSize = true;
            this.materialLabel7.Depth = 0;
            this.materialLabel7.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel7.Location = new System.Drawing.Point(57, 197);
            this.materialLabel7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.materialLabel7.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel7.Name = "materialLabel7";
            this.materialLabel7.Size = new System.Drawing.Size(182, 24);
            this.materialLabel7.TabIndex = 6;
            this.materialLabel7.Text = "Outside temperature";
            // 
            // dateLabel
            // 
            this.dateLabel.AutoSize = true;
            this.dateLabel.Depth = 0;
            this.dateLabel.Font = new System.Drawing.Font("Roboto", 11F);
            this.dateLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.dateLabel.Location = new System.Drawing.Point(605, 122);
            this.dateLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.dateLabel.MouseState = MaterialSkin.MouseState.HOVER;
            this.dateLabel.Name = "dateLabel";
            this.dateLabel.Size = new System.Drawing.Size(60, 24);
            this.dateLabel.TabIndex = 5;
            this.dateLabel.Text = "--.--.----";
            // 
            // humidity
            // 
            this.humidity.AutoSize = true;
            this.humidity.Depth = 0;
            this.humidity.Font = new System.Drawing.Font("Roboto", 11F);
            this.humidity.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.humidity.Location = new System.Drawing.Point(333, 122);
            this.humidity.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.humidity.MouseState = MaterialSkin.MouseState.HOVER;
            this.humidity.Name = "humidity";
            this.humidity.Size = new System.Drawing.Size(65, 24);
            this.humidity.TabIndex = 4;
            this.humidity.Text = "-----------";
            // 
            // insideTemp
            // 
            this.insideTemp.AutoSize = true;
            this.insideTemp.Depth = 0;
            this.insideTemp.Font = new System.Drawing.Font("Roboto", 11F);
            this.insideTemp.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.insideTemp.Location = new System.Drawing.Point(57, 122);
            this.insideTemp.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.insideTemp.MouseState = MaterialSkin.MouseState.HOVER;
            this.insideTemp.Name = "insideTemp";
            this.insideTemp.Size = new System.Drawing.Size(65, 24);
            this.insideTemp.TabIndex = 3;
            this.insideTemp.Text = "-----------";
            this.insideTemp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // materialLabel3
            // 
            this.materialLabel3.AutoSize = true;
            this.materialLabel3.Depth = 0;
            this.materialLabel3.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel3.Location = new System.Drawing.Point(605, 46);
            this.materialLabel3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel3.Name = "materialLabel3";
            this.materialLabel3.Size = new System.Drawing.Size(48, 24);
            this.materialLabel3.TabIndex = 2;
            this.materialLabel3.Text = "Date";
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel2.Location = new System.Drawing.Point(333, 46);
            this.materialLabel2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(87, 24);
            this.materialLabel2.TabIndex = 1;
            this.materialLabel2.Text = "Humidity";
            // 
            // lb
            // 
            this.lb.AutoSize = true;
            this.lb.Depth = 0;
            this.lb.Font = new System.Drawing.Font("Roboto", 11F);
            this.lb.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lb.Location = new System.Drawing.Point(57, 46);
            this.lb.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb.MouseState = MaterialSkin.MouseState.HOVER;
            this.lb.Name = "lb";
            this.lb.Size = new System.Drawing.Size(168, 24);
            this.lb.TabIndex = 0;
            this.lb.Text = "Inside temperature";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.tableLayoutPanel1);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage2.Size = new System.Drawing.Size(769, 431);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Console";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.rtbDisplay, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(4, 4);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 85F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(761, 423);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // rtbDisplay
            // 
            this.rtbDisplay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbDisplay.Location = new System.Drawing.Point(4, 4);
            this.rtbDisplay.Margin = new System.Windows.Forms.Padding(4);
            this.rtbDisplay.Name = "rtbDisplay";
            this.rtbDisplay.Size = new System.Drawing.Size(753, 351);
            this.rtbDisplay.TabIndex = 0;
            this.rtbDisplay.Text = "";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 63.94316F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 36.05684F));
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.txtSend, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(4, 363);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(753, 56);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.clearButton, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.portSendButton, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(485, 4);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(264, 48);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // clearButton
            // 
            this.clearButton.Depth = 0;
            this.clearButton.Location = new System.Drawing.Point(136, 4);
            this.clearButton.Margin = new System.Windows.Forms.Padding(4);
            this.clearButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.clearButton.Name = "clearButton";
            this.clearButton.Primary = true;
            this.clearButton.Size = new System.Drawing.Size(116, 38);
            this.clearButton.TabIndex = 36;
            this.clearButton.Text = "Clear";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.OnConsoleClearClick);
            // 
            // portSendButton
            // 
            this.portSendButton.Depth = 0;
            this.portSendButton.Location = new System.Drawing.Point(4, 4);
            this.portSendButton.Margin = new System.Windows.Forms.Padding(4);
            this.portSendButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.portSendButton.Name = "portSendButton";
            this.portSendButton.Primary = true;
            this.portSendButton.Size = new System.Drawing.Size(116, 38);
            this.portSendButton.TabIndex = 36;
            this.portSendButton.Text = "Send";
            this.portSendButton.UseVisualStyleBackColor = true;
            this.portSendButton.Click += new System.EventHandler(this.OnPortCommandSendClick);
            // 
            // txtSend
            // 
            this.txtSend.Location = new System.Drawing.Point(4, 4);
            this.txtSend.Margin = new System.Windows.Forms.Padding(4);
            this.txtSend.Name = "txtSend";
            this.txtSend.Size = new System.Drawing.Size(469, 41);
            this.txtSend.TabIndex = 1;
            this.txtSend.Text = "";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.drawChartButton);
            this.tabPage3.Controls.Add(this.plotView);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(769, 431);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Charts";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // drawChartButton
            // 
            this.drawChartButton.Depth = 0;
            this.drawChartButton.Location = new System.Drawing.Point(343, 386);
            this.drawChartButton.Margin = new System.Windows.Forms.Padding(4);
            this.drawChartButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.drawChartButton.Name = "drawChartButton";
            this.drawChartButton.Primary = true;
            this.drawChartButton.Size = new System.Drawing.Size(116, 38);
            this.drawChartButton.TabIndex = 36;
            this.drawChartButton.Text = "Draw";
            this.drawChartButton.UseVisualStyleBackColor = true;
            this.drawChartButton.Click += new System.EventHandler(this.OnDrawChartClick);
            // 
            // plotView
            // 
            this.plotView.Location = new System.Drawing.Point(4, 4);
            this.plotView.Margin = new System.Windows.Forms.Padding(4);
            this.plotView.Name = "plotView";
            this.plotView.PanCursor = System.Windows.Forms.Cursors.Hand;
            this.plotView.Size = new System.Drawing.Size(763, 382);
            this.plotView.TabIndex = 0;
            this.plotView.Text = "plotView1";
            this.plotView.ZoomHorizontalCursor = System.Windows.Forms.Cursors.SizeWE;
            this.plotView.ZoomRectangleCursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.plotView.ZoomVerticalCursor = System.Windows.Forms.Cursors.SizeNS;
            // 
            // cboPortName
            // 
            this.ComPortName.FormattingEnabled = true;
            this.ComPortName.Location = new System.Drawing.Point(807, 170);
            this.ComPortName.Margin = new System.Windows.Forms.Padding(4);
            this.ComPortName.Name = "ComPortName";
            this.ComPortName.Size = new System.Drawing.Size(160, 24);
            this.ComPortName.TabIndex = 20;
            // 
            // cboBaudRates
            // 
            this.cboBaudRates.FormattingEnabled = true;
            this.cboBaudRates.Items.AddRange(new object[] {
            "2400",
            "4800",
            "9600",
            "19200",
            "38400",
            "57600",
            "115200 "});
            this.cboBaudRates.Location = new System.Drawing.Point(807, 229);
            this.cboBaudRates.Margin = new System.Windows.Forms.Padding(4);
            this.cboBaudRates.Name = "cboBaudRates";
            this.cboBaudRates.Size = new System.Drawing.Size(160, 24);
            this.cboBaudRates.TabIndex = 21;
            // 
            // cboParity
            // 
            this.cboParity.FormattingEnabled = true;
            this.cboParity.Location = new System.Drawing.Point(807, 286);
            this.cboParity.Margin = new System.Windows.Forms.Padding(4);
            this.cboParity.Name = "cboParity";
            this.cboParity.Size = new System.Drawing.Size(160, 24);
            this.cboParity.TabIndex = 22;
            // 
            // cboStopBits
            // 
            this.cboStopBits.FormattingEnabled = true;
            this.cboStopBits.Location = new System.Drawing.Point(807, 342);
            this.cboStopBits.Margin = new System.Windows.Forms.Padding(4);
            this.cboStopBits.Name = "cboStopBits";
            this.cboStopBits.Size = new System.Drawing.Size(160, 24);
            this.cboStopBits.TabIndex = 23;
            // 
            // cboDataBits
            // 
            this.cboDataBits.FormattingEnabled = true;
            this.cboDataBits.Items.AddRange(new object[] {
            "5",
            "6",
            "7",
            "8"});
            this.cboDataBits.Location = new System.Drawing.Point(807, 399);
            this.cboDataBits.Margin = new System.Windows.Forms.Padding(4);
            this.cboDataBits.Name = "cboDataBits";
            this.cboDataBits.Size = new System.Drawing.Size(160, 24);
            this.cboDataBits.TabIndex = 24;
            // 
            // materialLabel13
            // 
            this.materialLabel13.AutoSize = true;
            this.materialLabel13.Depth = 0;
            this.materialLabel13.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel13.Location = new System.Drawing.Point(801, 143);
            this.materialLabel13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.materialLabel13.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel13.Name = "materialLabel13";
            this.materialLabel13.Size = new System.Drawing.Size(45, 24);
            this.materialLabel13.TabIndex = 25;
            this.materialLabel13.Text = "Port";
            // 
            // materialLabel14
            // 
            this.materialLabel14.AutoSize = true;
            this.materialLabel14.Depth = 0;
            this.materialLabel14.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel14.Location = new System.Drawing.Point(801, 199);
            this.materialLabel14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.materialLabel14.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel14.Name = "materialLabel14";
            this.materialLabel14.Size = new System.Drawing.Size(90, 24);
            this.materialLabel14.TabIndex = 26;
            this.materialLabel14.Text = "Baud rate";
            // 
            // materialLabel15
            // 
            this.materialLabel15.AutoSize = true;
            this.materialLabel15.Depth = 0;
            this.materialLabel15.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel15.Location = new System.Drawing.Point(801, 258);
            this.materialLabel15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.materialLabel15.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel15.Name = "materialLabel15";
            this.materialLabel15.Size = new System.Drawing.Size(58, 24);
            this.materialLabel15.TabIndex = 27;
            this.materialLabel15.Text = "Parity";
            // 
            // materialLabel16
            // 
            this.materialLabel16.AutoSize = true;
            this.materialLabel16.Depth = 0;
            this.materialLabel16.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel16.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel16.Location = new System.Drawing.Point(801, 315);
            this.materialLabel16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.materialLabel16.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel16.Name = "materialLabel16";
            this.materialLabel16.Size = new System.Drawing.Size(87, 24);
            this.materialLabel16.TabIndex = 28;
            this.materialLabel16.Text = "Stop Bits";
            // 
            // materialLabel17
            // 
            this.materialLabel17.AutoSize = true;
            this.materialLabel17.Depth = 0;
            this.materialLabel17.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel17.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel17.Location = new System.Drawing.Point(801, 372);
            this.materialLabel17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.materialLabel17.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel17.Name = "materialLabel17";
            this.materialLabel17.Size = new System.Drawing.Size(86, 24);
            this.materialLabel17.TabIndex = 29;
            this.materialLabel17.Text = "Data Bits";
            // 
            // portOpenButton
            // 
            this.portOpenButton.Depth = 0;
            this.portOpenButton.Location = new System.Drawing.Point(833, 437);
            this.portOpenButton.Margin = new System.Windows.Forms.Padding(4);
            this.portOpenButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.portOpenButton.Name = "portOpenButton";
            this.portOpenButton.Primary = true;
            this.portOpenButton.Size = new System.Drawing.Size(116, 38);
            this.portOpenButton.TabIndex = 30;
            this.portOpenButton.Text = "Open Port";
            this.portOpenButton.UseVisualStyleBackColor = true;
            this.portOpenButton.Click += new System.EventHandler(this.OnOpenPortClick);
            // 
            // portCloseButton
            // 
            this.portCloseButton.Depth = 0;
            this.portCloseButton.Location = new System.Drawing.Point(833, 494);
            this.portCloseButton.Margin = new System.Windows.Forms.Padding(4);
            this.portCloseButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.portCloseButton.Name = "portCloseButton";
            this.portCloseButton.Primary = true;
            this.portCloseButton.Size = new System.Drawing.Size(116, 38);
            this.portCloseButton.TabIndex = 31;
            this.portCloseButton.Text = "Close Port";
            this.portCloseButton.UseVisualStyleBackColor = true;
            this.portCloseButton.Click += new System.EventHandler(this.OnPortCloseClick);
            // 
            // rdoHex
            // 
            this.rdoHex.AutoSize = true;
            this.rdoHex.Depth = 0;
            this.rdoHex.Font = new System.Drawing.Font("Roboto", 10F);
            this.rdoHex.Location = new System.Drawing.Point(781, 561);
            this.rdoHex.Margin = new System.Windows.Forms.Padding(0);
            this.rdoHex.MouseLocation = new System.Drawing.Point(-1, -1);
            this.rdoHex.MouseState = MaterialSkin.MouseState.HOVER;
            this.rdoHex.Name = "rdoHex";
            this.rdoHex.Ripple = true;
            this.rdoHex.Size = new System.Drawing.Size(63, 30);
            this.rdoHex.TabIndex = 32;
            this.rdoHex.TabStop = true;
            this.rdoHex.Text = "HEX";
            this.rdoHex.UseVisualStyleBackColor = true;
            this.rdoHex.CheckedChanged += new System.EventHandler(this.OnCheckedChanged);
            // 
            // rdoText
            // 
            this.rdoText.AutoSize = true;
            this.rdoText.Depth = 0;
            this.rdoText.Font = new System.Drawing.Font("Roboto", 10F);
            this.rdoText.Location = new System.Drawing.Point(881, 561);
            this.rdoText.Margin = new System.Windows.Forms.Padding(0);
            this.rdoText.MouseLocation = new System.Drawing.Point(-1, -1);
            this.rdoText.MouseState = MaterialSkin.MouseState.HOVER;
            this.rdoText.Name = "rdoText";
            this.rdoText.Ripple = true;
            this.rdoText.Size = new System.Drawing.Size(64, 30);
            this.rdoText.TabIndex = 33;
            this.rdoText.TabStop = true;
            this.rdoText.Text = "Text";
            this.rdoText.UseVisualStyleBackColor = true;
            this.rdoText.CheckedChanged += new System.EventHandler(this.OnCheckedChanged);
            // 
            // themeButton
            // 
            this.themeButton.Depth = 0;
            this.themeButton.Location = new System.Drawing.Point(568, 96);
            this.themeButton.Margin = new System.Windows.Forms.Padding(4);
            this.themeButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.themeButton.Name = "themeButton";
            this.themeButton.Primary = true;
            this.themeButton.Size = new System.Drawing.Size(100, 28);
            this.themeButton.TabIndex = 34;
            this.themeButton.Text = "Theme";
            this.themeButton.UseVisualStyleBackColor = true;
            this.themeButton.Click += new System.EventHandler(this.OnThemeClick);
            // 
            // colorButton
            // 
            this.colorButton.Depth = 0;
            this.colorButton.Location = new System.Drawing.Point(707, 96);
            this.colorButton.Margin = new System.Windows.Forms.Padding(4);
            this.colorButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.colorButton.Name = "colorButton";
            this.colorButton.Primary = true;
            this.colorButton.Size = new System.Drawing.Size(100, 28);
            this.colorButton.TabIndex = 35;
            this.colorButton.Text = "Color";
            this.colorButton.UseVisualStyleBackColor = true;
            this.colorButton.Click += new System.EventHandler(this.OnColorChangedClick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(984, 628);
            this.Controls.Add(this.colorButton);
            this.Controls.Add(this.themeButton);
            this.Controls.Add(this.rdoText);
            this.Controls.Add(this.rdoHex);
            this.Controls.Add(this.portCloseButton);
            this.Controls.Add(this.portOpenButton);
            this.Controls.Add(this.materialLabel17);
            this.Controls.Add(this.materialLabel16);
            this.Controls.Add(this.materialLabel15);
            this.Controls.Add(this.materialLabel14);
            this.Controls.Add(this.materialLabel13);
            this.Controls.Add(this.cboDataBits);
            this.Controls.Add(this.cboStopBits);
            this.Controls.Add(this.cboParity);
            this.Controls.Add(this.cboBaudRates);
            this.Controls.Add(this.ComPortName);
            this.Controls.Add(this.materialTabControl1);
            this.Controls.Add(this.materialTabSelector1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(984, 628);
            this.MinimumSize = new System.Drawing.Size(984, 628);
            this.Name = "MainForm";
            this.Sizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tinny Clock Monitor 1.0.0";
            this.Load += new System.EventHandler(this.OnMainFormLoad);
            this.materialTabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private MaterialSkin.Controls.MaterialTabSelector materialTabSelector1;
        private MaterialSkin.Controls.MaterialTabControl materialTabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private MaterialSkin.Controls.MaterialLabel materialLabel3;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private MaterialSkin.Controls.MaterialLabel lb;
        private MaterialSkin.Controls.MaterialLabel timeLabel;
        private MaterialSkin.Controls.MaterialLabel materialLabel11;
        private MaterialSkin.Controls.MaterialLabel lightLevel;
        private MaterialSkin.Controls.MaterialLabel materialLabel9;
        private MaterialSkin.Controls.MaterialLabel outsideTemp;
        private MaterialSkin.Controls.MaterialLabel materialLabel7;
        private MaterialSkin.Controls.MaterialLabel dateLabel;
        private MaterialSkin.Controls.MaterialLabel humidity;
        private MaterialSkin.Controls.MaterialLabel insideTemp;
        private System.Windows.Forms.ComboBox cboBaudRates;
        private System.Windows.Forms.ComboBox cboParity;
        private System.Windows.Forms.ComboBox cboStopBits;
        private System.Windows.Forms.ComboBox cboDataBits;
        private MaterialSkin.Controls.MaterialLabel materialLabel13;
        private MaterialSkin.Controls.MaterialLabel materialLabel14;
        private MaterialSkin.Controls.MaterialLabel materialLabel15;
        private MaterialSkin.Controls.MaterialLabel materialLabel16;
        private MaterialSkin.Controls.MaterialLabel materialLabel17;
        private MaterialSkin.Controls.MaterialRaisedButton portOpenButton;
        private MaterialSkin.Controls.MaterialRaisedButton portCloseButton;
        private MaterialSkin.Controls.MaterialRadioButton rdoHex;
        private MaterialSkin.Controls.MaterialRadioButton rdoText;
        private MaterialSkin.Controls.MaterialRaisedButton themeButton;
        private MaterialSkin.Controls.MaterialRaisedButton colorButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.RichTextBox rtbDisplay;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private MaterialSkin.Controls.MaterialRaisedButton clearButton;
        private MaterialSkin.Controls.MaterialRaisedButton portSendButton;
        private System.Windows.Forms.RichTextBox txtSend;
        private MaterialSkin.Controls.MaterialRaisedButton drawChartButton;
        private OxyPlot.WindowsForms.PlotView plotView;
    }
}