using System;
using System.IO;
using System.Windows.Forms;

namespace TinnyClock
{
    public partial class MainForm : Form
    {
        private SerialPortManager _serialPort = new SerialPortManager();
        private string _transType = string.Empty;
        private int _firstTempToChart;
        private int _secondTempToChart;
        private int _humidityToChart;
        private int _lightLevelToChart;

        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadValues();
            SetDefaults();
            SetControlState();
        }

        public MainForm()
        {
            InitializeComponent();

            _serialPort.OnDataReceived += SerialPortOnDataReceived;
        }

        private void SerialPortOnDataReceived(TinnyClock.ReceivedDataDTO obj)
        {
            this.Invoke((MethodInvoker)delegate ()
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
        /// Method to initialize serial port
        /// values to standard defaults
        /// </summary>
        private void SetDefaults()
        {
#if !DEBUG
            cboPort.SelectedIndex = 0;
#endif
            cboBaud.SelectedText = "9600";
            cboParity.SelectedIndex = 0;
            cboStop.SelectedIndex = 1;
            cboData.SelectedIndex = 1;
        }

        /// <summary>
        /// methods to load our serial
        /// port option values
        /// </summary>
        private void LoadValues()
        {
            cboPort.DataSource = _serialPort.PortNameValues;
            cboParity.DataSource = _serialPort.ParityValues;
            cboStop.DataSource = _serialPort.StopBitValues;
        }

        /// <summary>
        /// method to set the state of controls
        /// when the form first loads
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
            DateLabel.Text = DateTime.Now.ToString("MM/dd/yyyy");
            TimeLabel.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        private void OpenFirmwareClick(object sender, EventArgs e)
        {
            this.FirmwBuffer.ForeColor = System.Drawing.Color.Green;
            Stream fileStream = null;
            OpenFileDialog oFile = new OpenFileDialog();

            oFile.InitialDirectory = "c:\\";
            oFile.Filter = "HEX files (*.hex)|*.hex|All files (*.*)|*.*";
            oFile.FilterIndex = 2;
            oFile.RestoreDirectory = true;

            if (oFile.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((fileStream = oFile.OpenFile()) != null)
                    {
                        using (fileStream)
                        {
                            // Insert code to read the stream here.
                            StreamReader sr = new
                            StreamReader(oFile.FileName);
                            FirmwBuffer.Text = (sr.ReadToEnd());
                            sr.Close();
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
            MemoryStream memorystream = new System.IO.MemoryStream();
            SaveFileDialog sFile = new SaveFileDialog();
            Stream fileStream;
            if (sFile.ShowDialog() == DialogResult.OK)
            {
                //ассоциируем поток с именем файла - если фйла нет создаем
                fileStream = sFile.OpenFile();
                //       memorystream.Position = 0;
                //сохраняем в поток содержимое richTextBox1
                FirmwBuffer.SaveFile(memorystream,
                      RichTextBoxStreamType.PlainText);
                //переносим в файл информацию и закрываем поток
                memorystream.WriteTo(fileStream);
                fileStream.Close();
            }
        }

        private void SaveAsButtonClick(object sender, EventArgs e)
        {
            // Create a SaveFileDialog to request a path and file name to save to.
            SaveFileDialog sFile = new SaveFileDialog();

            // Initialize the SaveFileDialog to specify the RTF extension for the file.
            // saveFile1.DefaultExt = "*.hex";
            sFile.Filter = "HEX files (*.hex)|*.hex|All files (*.*)|*.*";
            try
            {
                // Determine if the user selected a file name from the saveFileDialog.
                if (sFile.ShowDialog() == System.Windows.Forms.DialogResult.OK &&
                   sFile.FileName.Length > 0)
                {
                    // Save the contents of the RichTextBox into the file.
                    FirmwBuffer.SaveFile(sFile.FileName, RichTextBoxStreamType.PlainText);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearBufferClick(object sender, EventArgs e)
        {
            FirmwBuffer.Clear();
        }

        private void DataReadClick(object sender, EventArgs e)
        {
            // Граф
            /*
            List<int> tellemetry = new List<int>();
            tellemetry.Add(firstTempToChart);
            tellemetry.Add(secondTempToChart);
            tellemetry.Add(humidityToChart);
            tellemetry.Add(lightLevelToChart);
            */
            telemetryGraph.Series[0].Points.AddY(_firstTempToChart);
            telemetryGraph.Series[1].Points.AddY(_secondTempToChart);
            telemetryGraph.Series[2].Points.AddY(_humidityToChart);
            telemetryGraph.Series[3].Points.AddY(_lightLevelToChart);
            /*
            foreach (int item in tellemetry)
            {
                telemetryGraph.Series[0].Points.AddY(item);
            }
            */
        }
    }
}