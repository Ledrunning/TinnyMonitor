using System;
using System.IO;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using OxyPlot.WindowsForms;
using TinnyClock.Models;

namespace TinnyClock
{
    public partial class MainForm : MaterialForm
    {
        private readonly Timer graphChangeTimer = new Timer();
        private readonly MaterialSkinManager _materialSkinManager;
        private readonly SerialPortManager _serialPort = new SerialPortManager();
        private int colorSchemeIndex;
        private int firstTempToChart;
        private int humidityToChart;
        private int lightLevelToChart;
        private int secondTempToChart;
        private string transType = string.Empty;

        private bool isClicked = true;

        public MainForm()
        {
            InitializeComponent();
            _materialSkinManager = MaterialSkinManager.Instance;
            _materialSkinManager.AddFormToManage(this);
            _materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            _materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900,
                Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
            _serialPort.OnDataReceived += OnSerialPortDataReceived;

            SetupChartModel();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadValues();
            SetDefaults();
            SetControlState();
        }

        private void OnSerialPortDataReceived(ReceivedDataDto obj)
        {
            Invoke((MethodInvoker) delegate
            {
                insideTemp.Text = obj.IndorTemperature;
                outsideTemp.Text = obj.OutdoorTemperature;
                huMidity.Text = obj.Humidity;
                lightLevel.Text = obj.LightLevel;
                rtbDisplay.AppendText(obj.RawText + Environment.NewLine);
                try
                {
                    if (obj.IndorTemperature != "NONE" && obj.OutdoorTemperature != "NONE" && obj.Humidity
                        != "NONE" && obj.LightLevel != "NONE")
                    {
                        firstTempToChart = Convert.ToInt32(obj.IndorTemperature);
                        secondTempToChart = Convert.ToInt32(obj.OutdoorTemperature);
                        humidityToChart = Convert.ToInt32(obj.Humidity);
                        lightLevelToChart = Convert.ToInt32(obj.LightLevel);
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show("Error", e.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            cboPort.DataSource = _serialPort.PortNameValues;
            cboParity.DataSource = _serialPort.ParityValues;
            cboStop.DataSource = _serialPort.StopBitValues;
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
            _serialPort.Parity = cboParity.Text;
            _serialPort.StopBits = cboStop.Text;
            _serialPort.DataBits = cboData.Text;
            _serialPort.BaudRatesRate = cboBaud.Text;
            _serialPort.PortName = cboPort.Text;
            _serialPort.OpenPort();
            cmdOpen.Enabled = false;
            cmdClose.Enabled = true;
            cmdSend.Enabled = true;
        }

        private void ComPortCloseClick(object sender, EventArgs e)
        {
            cmdOpen.Enabled = true;
            cmdClose.Enabled = false;
            cmdSend.Enabled = false;
            _serialPort.ClosePort();
        }

        private void SendToComPortClick(object sender, EventArgs e)
        {
            _serialPort.WriteData(txtSend.Text);
        }

        private void CheckedChanged(object sender, EventArgs e)
        {
            if (rdoHex.Checked)
            {
                _serialPort.CurrentTransmissionType = SerialPortManager.TransmissionType.Hex;
            }
            else
            {
                _serialPort.CurrentTransmissionType = SerialPortManager.TransmissionType.Text;
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

        private void SaveButtonClick(object sender, EventArgs e)
        {
            var memorystream = new MemoryStream();
            var sFile = new SaveFileDialog();

            if (sFile.ShowDialog() == DialogResult.OK)
            {
                var fileStream = sFile.OpenFile();
                memorystream.WriteTo(fileStream);
                fileStream.Close();
            }
        }

        private void OnThemeClick(object sender, EventArgs e)
        {
            _materialSkinManager.Theme = _materialSkinManager.Theme == MaterialSkinManager.Themes.DARK
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
                    _materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900,
                        Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
                    break;
                case 1:
                    _materialSkinManager.ColorScheme = new ColorScheme(Primary.Indigo500, Primary.Indigo700,
                        Primary.Indigo100, Accent.Pink200, TextShade.WHITE);
                    break;
                case 2:
                    _materialSkinManager.ColorScheme = new ColorScheme(Primary.Green600, Primary.Green700,
                        Primary.Green200, Accent.Red100, TextShade.WHITE);
                    break;
                case 3:
                    _materialSkinManager.ColorScheme = new ColorScheme(Primary.Red200, Primary.Red800, Primary.Red300,
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

            InitializeCharts(plotView, "Telemetry data");
        }

        private void InitializeCharts(PlotView plotModel, string title)
        {
            plotModel.Model.Title = title;
            plotModel.Model.PlotAreaBorderColor = OxyColor.FromRgb(255, 255, 255);
            plotModel.Model.TitleColor = OxyColor.FromRgb(255, 255, 255);

            plotModel.Model.LegendPosition = LegendPosition.RightBottom;
            //Y
            plotModel.Model.Axes.Add(new LinearAxis
            {
                IsPanEnabled = false, // отключение скролинга
                IsZoomEnabled = false, // отключение зума 
                Position = AxisPosition.Left,
                Minimum = -10,
                Maximum = 10,
                TextColor = OxyColor.FromRgb(74, 134, 187),
                AxislineColor = OxyColor.FromRgb(255, 255, 255),
                MajorGridlineColor = OxyColor.FromArgb(40, 100, 0, 139),
                MajorGridlineStyle = LineStyle.Solid,
                MinorGridlineColor = OxyColor.FromArgb(20, 0, 0, 139),
                MinorGridlineStyle = LineStyle.Solid,
                TicklineColor = OxyColor.FromRgb(255, 255, 255)
            });

            //X
            plotModel.Model.Axes.Add(new LinearAxis
            {
                IsPanEnabled = false, // отключение скролинга
                IsZoomEnabled = false, // отключение зума
                Position = AxisPosition.Bottom,
                TextColor = OxyColor.FromRgb(74, 134, 187),
                AxislineColor = OxyColor.FromRgb(255, 255, 255),
                MajorGridlineColor = OxyColor.FromArgb(40, 100, 0, 139),
                MajorGridlineStyle = LineStyle.Solid,
                MinorGridlineColor = OxyColor.FromArgb(20, 0, 0, 139),
                MinorGridlineStyle = LineStyle.Solid,
                TicklineColor = OxyColor.FromRgb(255, 255, 255)
            });

            plotModel.Model.Series.Add(new LineSeries
            {
                LineStyle = LineStyle.Solid, Color = OxyColor.FromRgb(74, 134, 187)
            }); //rgb(74,134,187) #4a86bb

            plotModel.Model.Series.Add(new LineSeries
            {
                LineStyle = LineStyle.Solid,
                Color = OxyColor.FromRgb(227, 64, 64)
            });
        }

        private void UpdateChart()
        {
            PrintTemperatureChart();
        }

        private void PrintTemperatureChart()
        {
            var lineSeries = (LineSeries) plotView.Model.Series[0];

            var x = lineSeries.Points.Count > 0 ? lineSeries.Points[lineSeries.Points.Count - 1].X + 1 : 0;
            if (lineSeries.Points.Count >= 200)
            {
                lineSeries.Points.RemoveAt(0);
            }

            double y = 0;
            var m = 5;
            for (var j = 0; j < m; j++)
            {
                y += Math.Cos(20 * x * j * j);
            }

            //y /= m;
            lineSeries.Points.Add(new DataPoint(x, y));
        }

        private void OnGraphChangeTimerTick(object sender, EventArgs e)
        {
            lock (plotView.Model.SyncRoot)
            {
                UpdateChart();
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