using System;
using System.IO;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;
using NLog;
using OxyPlot;
using TinnyClock.Enums;
using TinnyClock.Models;
using TinnyClock.Service;

namespace TinnyClock
{
    public partial class MainForm : MaterialForm
    {
        private readonly Timer graphChangeTimer = new Timer();
        private readonly MaterialSkinManager materialSkinManager;
        private readonly SerialPortManager serialPort = new SerialPortManager();
        private ChartDrawingService chartService;
        private int colorSchemeIndex;
        private int firstTempToChart;
        private int humidityToChart;

        private bool isClicked = true;
        private int lightLevelToChart;

        private readonly Logger logger = LogManager.GetCurrentClassLogger();
        private int secondTempToChart;
        private string transType = string.Empty;

        public MainForm()
        {
            InitializeComponent();
            materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900,
                Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
            serialPort.OnDataReceived += OnSerialPortDataReceived;

            SetupChartModel();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadValues();
            SetDefaults();
            SetControlState();
            logger.Info("Application started!");
        }

        private void OnSerialPortDataReceived(ReceivedDataDto data)
        {
            Invoke((MethodInvoker) delegate
            {
                insideTemp.Text = data.IndorTemperature;
                outsideTemp.Text = data.OutdoorTemperature;
                huMidity.Text = data.Humidity;
                lightLevel.Text = data.LightLevel;
                rtbDisplay.AppendText(data.RawText + Environment.NewLine);
                try
                {
                    if (data.IndorTemperature != "NONE" && data.OutdoorTemperature != "NONE" && data.Humidity
                        != "NONE" && data.LightLevel != "NONE")
                    {
                        firstTempToChart = Convert.ToInt32(data.IndorTemperature);
                        secondTempToChart = Convert.ToInt32(data.OutdoorTemperature);
                        humidityToChart = Convert.ToInt32(data.Humidity);
                        lightLevelToChart = Convert.ToInt32(data.LightLevel);
                        logger.Info(
                            $"Indoor:{firstTempToChart}, Outdoor:{secondTempToChart}, Humidity:{humidityToChart}, Light:{lightLevelToChart}");
                    }
                    else
                    {
                        logger.Info("No data...");
                    }
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
#if !DEBUG
            cboPort.SelectedIndex = 0;
#endif
            cboBaud.SelectedText = "9600";
            cboParity.SelectedIndex = 0;
            cboStop.SelectedIndex = 1;
            cboData.SelectedIndex = 3;
        }

        /// <summary>
        ///     methods to load our serial
        ///     port option values
        /// </summary>
        private void LoadValues()
        {
            cboPort.DataSource = serialPort.PortNameValues;
            cboParity.DataSource = serialPort.ParityValues;
            cboStop.DataSource = serialPort.StopBitValues;
        }

        /// <summary>
        ///     method to set the state of controls
        ///     when the form first loads
        /// </summary>
        private void SetControlState()
        {
            rdoText.Checked = true;
            cmdSend.Enabled = false;
            cmdClose.Enabled = false;
        }

        private void ComPortOpenClick(object sender, EventArgs e)
        {
            serialPort.Parity = cboParity.Text;
            serialPort.StopBits = cboStop.Text;
            serialPort.DataBits = cboData.Text;
            serialPort.BaudRatesRate = cboBaud.Text;
            serialPort.PortName = cboPort.Text;
            serialPort.OpenPort();
            cmdOpen.Enabled = false;
            cmdClose.Enabled = true;
            cmdSend.Enabled = true;
        }

        private void ComPortCloseClick(object sender, EventArgs e)
        {
            cmdOpen.Enabled = true;
            cmdClose.Enabled = false;
            cmdSend.Enabled = false;
            serialPort.ClosePort();
        }

        private void SendToComPortClick(object sender, EventArgs e)
        {
            serialPort.WriteData(txtSend.Text);
        }

        private void CheckedChanged(object sender, EventArgs e)
        {
            if (rdoHex.Checked)
            {
                serialPort.CurrentTransmissionType = TransmissionType.Hex;
            }
            else
            {
                serialPort.CurrentTransmissionType = TransmissionType.Text;
            }
        }

        // Clear Console;
        private void ConsoleClearClick(object sender, EventArgs e)
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
            if (colorSchemeIndex > 3)
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
            graphChangeTimer.Interval = 100;
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
                chartService.UpdateChart();
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

            //PrintChart();
        }

        #region Test Chart drawing

        #endregion
    }
}