using System;
using System.Diagnostics.CodeAnalysis;
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

        public IMainFormPresenter Presenter { get; private set; }


        public string DateLabel
        {
            get => dateLabel.Text;
            set => dateLabel.Text = value;
        }

        public string TimeLabel
        {
            get => timeLabel.Text;
            set => timeLabel.Text = value;
        }

        public string InsideTemperature
        {
            get => insideTemp.Text;
            set => insideTemp.Text = value;
        }

        public string OutsideTemperature
        {
            get => outsideTemp.Text;
            set => outsideTemp.Text = value;
        }

        public string Humidity
        {
            get => humidity.Text;
            set => humidity.Text = value;
        }

        public string LightLevel
        {
            get => lightLevel.Text;
            set => lightLevel.Text = value;
        }

        public string ConsoleDisplay
        {
            get => rtbDisplay.Text;
            set => Invoke((MethodInvoker)delegate { rtbDisplay.Text = value; });
        }

        public MaterialRadioButton HexOrText { get; set; }

        public ComboBox ComPortName { get; set; }

        public ComboBox ComPortParity
        {
            get => cboParity;
            set => cboParity = value;
        }

        public ComboBox ComPortStopBit
        {
            get => cboStopBits;
            set => cboStopBits = value;
        }

        public ComboBox ComPortBaudRates
        {
            get => cboBaudRates;
            set => cboBaudRates = value;
        }

        public ComboBox ComPortDataBits
        {
            get => cboDataBits;
            set => cboDataBits = value;
        }

        public void SetPresenter(MainFormPresenter presenter)
        {
            Presenter = presenter;
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
                InsideTemperature = data.IndoorTemperature;
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
            ComPortName.SelectedIndex = 0;
            ComPortBaudRates.SelectedText = "9600";
            ComPortParity.SelectedIndex = 0;
            ComPortStopBit.SelectedIndex = 1;
            ComPortDataBits.SelectedIndex = 3;
        }

        /// <summary>
        ///     methods to load our serial
        ///     port option values
        /// </summary>
        private void LoadValues()
        {
            ComPortName.DataSource = Presenter.PortNameValues;
            ComPortParity.DataSource = Presenter.ParityValues;
            ComPortStopBit.DataSource = Presenter.StopBitValues;
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
                        ComPortName.DataSource = Presenter.PortNameValues;
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
            try
            {
                Presenter.StartSerialPort();
                Presenter.OnSerialPortDataReceived += OnSerialPortDataReceived;
                portOpenButton.Enabled = false;
                portCloseButton.Enabled = true;
                portSendButton.Enabled = true;
            }
            catch (Exception ex)
            {
                ConsoleDisplay = ex.Message;
                MessageBox.Show("Error", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OnPortCloseClick(object sender, EventArgs e)
        {
            try
            {
                portOpenButton.Enabled = true;
                portCloseButton.Enabled = false;
                portSendButton.Enabled = false;

                Presenter.CloseSerialPort();
                Presenter.OnSerialPortDataReceived -= OnSerialPortDataReceived;
            }
            catch (Exception ex)
            {
                ConsoleDisplay = ex.Message;
                MessageBox.Show("Error", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OnPortCommandSendClick(object sender, EventArgs e)
        {
            try
            {
                Presenter.WriteData(txtSend.Text);
                ConsoleDisplay = txtSend.Text;
            }
            catch (Exception ex)
            {
                ConsoleDisplay = ex.Message;
                MessageBox.Show("Error", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OnCheckedChanged(object sender, EventArgs e)
        {
            Presenter.SetCurrentTransmissionType();
        }

        // Clear Console;
        private void OnConsoleClearClick(object sender, EventArgs e)
        {
            rtbDisplay.Clear();
        }

        private void OnTimerTick(object sender, EventArgs e)
        {
            Invoke((MethodInvoker)delegate
            {
                DateLabel = DateTime.Now.ToString("MM/dd/yyyy");
                TimeLabel = DateTime.Now.ToString("HH:mm:ss");
            });
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