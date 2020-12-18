using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using TinnyClock.Models;

namespace TinnyClock
{
    public partial class MainForm : MaterialForm
    {
        private readonly MaterialSkinManager _materialSkinManager;
        private int _colorSchemeIndex;
        private int _firstTempToChart;
        private int _humidityToChart;
        private int _lightLevelToChart;
        private int _secondTempToChart;
        private readonly SerialPortManager _serialPort = new SerialPortManager();
        private string _transType = string.Empty;
        private const string HexFilesFilter = "HEX files (*.hex)|*.hex|All files (*.*)|*.*";

        public MainForm()
        {
            InitializeComponent();
            _materialSkinManager = MaterialSkinManager.Instance;
            _materialSkinManager.AddFormToManage(this);
            _materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            _materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900,
                Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
            _serialPort.OnDataReceived += SerialPortOnDataReceived;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadValues();
            SetDefaults();
            SetControlState();
        }

        private void SerialPortOnDataReceived(ReceivedDataDto obj)
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
                        _firstTempToChart = Convert.ToInt32(obj.IndorTemperature);
                        _secondTempToChart = Convert.ToInt32(obj.OutdoorTemperature);
                        _humidityToChart = Convert.ToInt32(obj.Humidity);
                        _lightLevelToChart = Convert.ToInt32(obj.LightLevel);
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

        private void OpenFirmwareClick(object sender, EventArgs e)
        {
            firmwBuffer.ForeColor = Color.Green;
            Stream fileStream = null;
            var openFile = new OpenFileDialog();

            openFile.InitialDirectory = "c:\\";
            openFile.Filter = HexFilesFilter;
            openFile.FilterIndex = 2;
            openFile.RestoreDirectory = true;

            if (openFile.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((fileStream = openFile.OpenFile()) != null)
                    {
                        using (fileStream)
                        {
                            // Insert code to read the stream here.
                            var reader = new StreamReader(openFile.FileName);
                            firmwBuffer.Text = reader.ReadToEnd();
                            reader.Close();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($@"Error: Could not read file from disk. Original error: {ex.Message}");
                }
            }
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

        private void SaveAsButtonClick(object sender, EventArgs e)
        {
            // Create a SaveFileDialog to request a path and file name to save to.
            var sFile = new SaveFileDialog();

            // Initialize the SaveFileDialog to specify the RTF extension for the file.
            // saveFile1.DefaultExt = "*.hex";
            sFile.Filter = HexFilesFilter;
            try
            {
                // Determine if the user selected a file name from the saveFileDialog.
                if (sFile.ShowDialog() == DialogResult.OK &&
                    sFile.FileName.Length > 0)
                {
                    // Save the contents of the RichTextBox into the file.
                    //FirmwBuffer.SaveFile(sFile.FileName, RichTextBoxStreamType.PlainText);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearBufferClick(object sender, EventArgs e)
        {
            firmwBuffer.Clear();
        }

        private void OnThemeClick(object sender, EventArgs e)
        {
            _materialSkinManager.Theme = _materialSkinManager.Theme == MaterialSkinManager.Themes.DARK
                ? MaterialSkinManager.Themes.LIGHT
                : MaterialSkinManager.Themes.DARK;
        }

        private void OnColorChangedClick(object sender, EventArgs e)
        {
            _colorSchemeIndex++;
            if (_colorSchemeIndex > 3)
            {
                _colorSchemeIndex = 0;
            }

            //These are just example color schemes
            switch (_colorSchemeIndex)
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

        private void OnDrawChartClick(object sender, EventArgs e)
        {
            PrintChart();
        }

        #region Test Chart drawing

        private void PrintChart()
        {
            var plotModel = new PlotModel
            {
                // set here main properties such as the legend, the title, etc. example :
                Title = "Test Graph",
                TitleHorizontalAlignment = TitleHorizontalAlignment.CenteredWithinPlotArea,
                LegendTitle = "f/t",
                LegendOrientation = LegendOrientation.Horizontal,
                LegendPlacement = LegendPlacement.Inside,
                LegendPosition = LegendPosition.TopRight
            };

            // now let's define X and Y axis for the plot model

            var xAxis = new LinearAxis();
            xAxis.Position = AxisPosition.Bottom;
            xAxis.Title = "Time (hours)";

            var yAxis = new LinearAxis();
            yAxis.Position = AxisPosition.Left;
            yAxis.Title = "Humidity";

            plotModel.Axes.Add(xAxis);
            plotModel.Axes.Add(yAxis);

            // Finally let's define a LineSerie

            var lineSerie = new LineSeries
            {
                StrokeThickness = 2,
                CanTrackerInterpolatePoints = false,
                Title = "Value",
                Smooth = false
            };
            plotModel.Series.Add(lineSerie);
            plotView.Model = plotModel;
            plotView.Model.Series.Add(GetFunction());
        }

        private FunctionSeries GetFunction()
        {
            var n = 10;
            var fs = new FunctionSeries();
            for (var x = -10; x <= n; x++)
            {
                for (var y = -10; y <= n; y++)
                {
                    var dataPoint = new DataPoint(x, GetValue(x, y));
                    fs.Points.Add(dataPoint);
                }
            }

            return fs;
        }

        private double GetValue(int x, int y)
        {
            return -1 * x * x + 50;
        }

        #endregion
    }
}