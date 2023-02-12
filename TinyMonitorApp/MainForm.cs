using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;
using NLog;
using OxyPlot;
using TinyMonitorApp.Contracts;
using TinyMonitorApp.Enums;
using TinyMonitorApp.Models;
using TinyMonitorApp.Presenter;
using TinyMonitorApp.Service;

namespace TinyMonitorApp
{
    public partial class MainForm : MaterialForm, IMainFormView
    {
        private const int ThemeQuantity = 3;
        private const int ChartDrawingIntervalInMs = 100;
        private const string NoneMessage = "NONE";
        private readonly Timer graphChangeTimer = new Timer();

        private readonly Logger logger = LogManager.GetCurrentClassLogger();
        private readonly MaterialSkinManager materialSkinManager;
        private ChartDrawingService chartService;
        private int colorSchemeIndex;
        private int firstTempToChart;
        private int humidityToChart;

        private bool isClicked = true;
        private int lightLevelToChart;
        private int secondTempToChart;
        private SerialPortManager serialPortManager;
        public MainForm()
        {
            InitializeComponent();
            materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900,
                Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);

            SetupChartModel();
        }

        public IEnumerable<string> ParityValues => Enum.GetNames(typeof(Parity));
        public IEnumerable<string> StopBitValues => Enum.GetNames(typeof(StopBits));
        public IEnumerable<string> PortNameValues => SerialPort.GetPortNames();

        public string DateLabel
        {
            get => dateLabel.Text;
            set => Invoke((MethodInvoker)delegate { dateLabel.Text = value; });
        }

        public string TimeLabel
        {
            get => timeLabel.Text;
            set => Invoke((MethodInvoker)delegate { timeLabel.Text = value; });
        }

        public string InsideTemperature
        {
            get => insideTemp.Text;
            set => Invoke((MethodInvoker)delegate { insideTemp.Text = value; });
        }

        public string OutsideTemperature
        {
            get => outsideTemp.Text;
            set => Invoke((MethodInvoker)delegate { outsideTemp.Text = value; });
        }

        public string Humidity
        {
            get => humidity.Text;
            set => Invoke((MethodInvoker)delegate { humidity.Text = value; });
        }

        public string LightLevel
        {
            get => lightLevel.Text;
            set => Invoke((MethodInvoker)delegate { lightLevel.Text = value; });
        }

        public string ConsoleDisplay
        {
            get => rtbDisplay.Text;
            set => Invoke((MethodInvoker)delegate { rtbDisplay.Text = value; });
        }

        public object ComPort
        {
            get => cboPortName.DataSource = PortNameValues;
            set => cboPortName.DataSource = value;
        }

        public object ComPortParity
        {
            get => cboParity.DataSource = ParityValues;
            set => cboParity.DataSource = value;
        }

        public object ComPortStopBit
        {
            get => cboStopBits.DataSource = StopBitValues;
            set => cboStopBits.DataSource = value;
        }

        public void SetPresenter(MainFormPresenter presenter)
        {
            throw new NotImplementedException();
        }

        private void OnMainFormLoad(object sender, EventArgs e)
        {
            LoadValues();
            SetControlState();
            logger.Info("Application started!");
        }

        private void OnSerialPortDataReceived(ReceivedDataDto data)
        {
            Invoke((MethodInvoker)delegate
            {
                insideTemp.Text = data.IndoorTemperature;
                outsideTemp.Text = data.OutdoorTemperature;
                humidity.Text = data.Humidity;
                lightLevel.Text = data.LightLevel;
                rtbDisplay.AppendText(data.RawText + Environment.NewLine);
                try
                {
                    if (data.IndoorTemperature == NoneMessage || data.OutdoorTemperature == NoneMessage ||
                        data.Humidity == NoneMessage || data.LightLevel == NoneMessage)
                    {
                        return;
                    }

                    firstTempToChart = Convert.ToInt32(data.IndoorTemperature);
                    secondTempToChart = Convert.ToInt32(data.OutdoorTemperature);
                    humidityToChart = Convert.ToInt32(data.Humidity);
                    lightLevelToChart = Convert.ToInt32(data.LightLevel);
                    logger.Info(
                        $"Indoor:{firstTempToChart}, Outdoor:{secondTempToChart}, Humidity:{humidityToChart}, Light:{lightLevelToChart}");
                }
                catch (Exception e)
                {
                    MessageBox.Show("Error", e.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    logger.Error(e);
                }
            });
        }

        /// <summary>
        ///     Method to initialize serial port
        ///     values to standard defaults
        /// </summary>
        private void SetDefaults()
        {
            cboPortName.SelectedIndex = 0;
            cboBaudRates.SelectedText = "9600";
            cboParity.SelectedIndex = 0;
            cboStopBits.SelectedIndex = 1;
            cboDataBits.SelectedIndex = 3;
        }

        /// <summary>
        ///     methods to load our serial
        ///     port option values
        /// </summary>
        private void LoadValues()
        {
            cboPortName.DataSource = PortNameValues;
            cboParity.DataSource = ParityValues;
            cboStopBits.DataSource = StopBitValues;
        }

        /// <summary>
        ///     Windows Device manager handler
        /// </summary>
        /// <param name="m"></param>
        //
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            if (m.Msg == (int)WindowsMessages.WM_DEVICECHANGE)
            {
                try
                {
                    //New usb-device connection
                    if (m.WParam.ToInt32() == (int)WindowsMessages.WM_APP)
                    {
                        cboPortName.DataSource = PortNameValues;
                        SetDefaults();
                    }

                    //Usb device disconnect
                    if (m.WParam.ToInt32() == (int)WindowsMessageParams.DBT_DEVICEREMOVECOMPLETE)
                    {
                        MessageBox.Show("Error", "Port unavailable", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        ///     method to set the state of controls
        ///     when the form first loads
        /// </summary>
        private void SetControlState()
        {
            rdoText.Checked = true;
            portSendButton.Enabled = false;
            portCloseButton.Enabled = false;
        }

        private void OnOpenPortClick(object sender, EventArgs e)
        {
            int.TryParse(cboBaudRates.Text, out var baudRates);
            int.TryParse(cboDataBits.Text, out var dataBits);

            var serialPort = new SerialPortManager(baudRates, cboParity.Text, cboStopBits.Text, dataBits, cboPortName.Text);

            serialPort.OnDataReceived += OnSerialPortDataReceived;

            serialPort.OpenPort();
            portOpenButton.Enabled = false;
            portCloseButton.Enabled = true;
            portSendButton.Enabled = true;
        }

        private void OnPortCloseClick(object sender, EventArgs e)
        {
            serialPortManager.OnDataReceived -= OnSerialPortDataReceived;

            portOpenButton.Enabled = true;
            portCloseButton.Enabled = false;
            portSendButton.Enabled = false;
            serialPortManager.ClosePort();
        }

        private void OnPortCommandSendClick(object sender, EventArgs e)
        {
            try
            {
                serialPortManager.WriteData(txtSend.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OnCheckedChanged(object sender, EventArgs e)
        {
            if (serialPortManager != null)
            {
                serialPortManager.CurrentTransmissionType = rdoHex.Checked ? TransmissionType.Hex : TransmissionType.Text;
            }
        }

        // Clear Console;
        private void OnConsoleClearClick(object sender, EventArgs e)
        {
            rtbDisplay.Clear();
        }

        // Time and date;
        private void OnTimerTick(object sender, EventArgs e)
        {
            dateLabel.Text = DateTime.Now.ToString("MM/dd/yyyy");
            timeLabel.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        private void OnThemeClick(object sender, EventArgs e)
        {
            materialSkinManager.Theme = materialSkinManager.Theme == MaterialSkinManager.Themes.DARK
                ? MaterialSkinManager.Themes.LIGHT
                : MaterialSkinManager.Themes.DARK;
        }

        private void OnColorChangedClick(object sender, EventArgs e)
        {
            colorSchemeIndex++;
            if (colorSchemeIndex > ThemeQuantity)
            {
                colorSchemeIndex = 0;
            }

            //These are just example color schemes
            switch (colorSchemeIndex)
            {
                case 0:
                    materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900,
                        Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
                    break;
                case 1:
                    materialSkinManager.ColorScheme = new ColorScheme(Primary.Indigo500, Primary.Indigo700,
                        Primary.Indigo100, Accent.Pink200, TextShade.WHITE);
                    break;
                case 2:
                    materialSkinManager.ColorScheme = new ColorScheme(Primary.Green600, Primary.Green700,
                        Primary.Green200, Accent.Red100, TextShade.WHITE);
                    break;
                case 3:
                    materialSkinManager.ColorScheme = new ColorScheme(Primary.Red200, Primary.Red800, Primary.Red300,
                        Accent.Red200, TextShade.WHITE);
                    break;
            }
        }

        private void InitializeGraphTimer()
        {
            graphChangeTimer.Enabled = true;
            graphChangeTimer.Interval = ChartDrawingIntervalInMs;
            graphChangeTimer.Tick += OnGraphChangeTimerTick;
        }

        private void SetupChartModel()
        {
            if (plotView.Model == null)
            {
                plotView.Model = new PlotModel();
            }

            chartService = new ChartDrawingService(plotView, "Telemetry Data");
        }

        private void OnGraphChangeTimerTick(object sender, EventArgs e)
        {
            lock (plotView.Model.SyncRoot)
            {
                chartService.UpdateChart(firstTempToChart, secondTempToChart, humidityToChart, lightLevelToChart);
                plotView.Model.InvalidatePlot(true);
            }
        }

        private void OnDrawChartClick(object sender, EventArgs e)
        {
            if (isClicked)
            {
                drawChart.Text = "Stop Drawing";
                InitializeGraphTimer();
                graphChangeTimer.Start();
                isClicked = false;
            }
            else
            {
                drawChart.Text = "Draw";
                graphChangeTimer.Enabled = false;
                graphChangeTimer.Stop();
                isClicked = true;
            }
        }
    }
}