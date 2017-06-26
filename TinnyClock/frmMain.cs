using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PCComm;
using TinnyClock;

namespace PCComm
{
    public partial class frmMain : Form
    {
        private CommunicationManager comm = new CommunicationManager();
        private string transType = string.Empty;
        private int firstTempToChart;
        private int secondTempToChart;
        private int humidityToChart;
        private int lightLevelToChart;

        private void frmMain_Load(object sender, EventArgs e)
        {
            LoadValues();
            SetDefaults();
            SetControlState();
        }


        public frmMain()
        {
            InitializeComponent();

            comm.OnDataReceived += Comm_OnDataReceived;

        }

        

        private void Comm_OnDataReceived(TinnyClock.ReceivedDataDTO obj)
        {
            this.Invoke((MethodInvoker)delegate ()
            {
                insideTemp.Text = obj.Temp1;
                outsideTemp.Text = obj.Temp2;
                huMidity.Text = obj.Humidity;
                lightLevel.Text = obj.LightLevel;
                rtbDisplay.AppendText(obj.RawText + Environment.NewLine);
            try
                {
                  if (obj.Temp1 != "NONE" && obj.Temp2 != "NONE" && obj.Humidity
                  != "NONE" && obj.LightLevel != "NONE")
                    {
                        firstTempToChart = Convert.ToInt32(obj.Temp1);
                        secondTempToChart = Convert.ToInt32(obj.Temp2);
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

        
        private void cmdOpen_Click(object sender, EventArgs e)
        {
            comm.Parity = cboParity.Text;
            comm.StopBits = cboStop.Text;
            comm.DataBits = cboData.Text;
            comm.BaudRate = cboBaud.Text;
            comm.PortName = cboPort.Text;
            comm.OpenPort();
            cmdOpen.Enabled = false;
            cmdClose.Enabled = true;
            cmdSend.Enabled = true;
        }
        // Close Com port;
        private void cmdClose_Click(object sender, EventArgs e)
        {
            cmdOpen.Enabled = true;
            cmdClose.Enabled = false;
            cmdSend.Enabled = false;
            comm.ClosePort();
        }

        /// <summary>
        /// Method to initialize serial port
        /// values to standard defaults
        /// </summary>
        private void SetDefaults()
        {
            //cboPort.SelectedIndex = 0;  // Тут закомментить при отладке;
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
            cboPort.DataSource = comm.PortNameValues;
            cboParity.DataSource = comm.ParityValues;
            cboStop.DataSource = comm.StopBitValues;
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

        private void cmdSend_Click(object sender, EventArgs e)
        {
            comm.WriteData(txtSend.Text);
        }

        private void rdoHex_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoHex.Checked == true)
            {
                comm.CurrentTransmissionType = PCComm.CommunicationManager.TransmissionType.Hex;
            }
            else
            {
                comm.CurrentTransmissionType = PCComm.CommunicationManager.TransmissionType.Text;
            }
        }
        // Clear Console;
        private void ConsoleClear_Click(object sender, EventArgs e)
        {
            rtbDisplay.Clear();
        }
        
        // Time and date;
        private void timer1_Tick(object sender, EventArgs e)
        {
            int h = DateTime.Now.Hour;
            int m = DateTime.Now.Minute;
            int s = DateTime.Now.Second;

            string time = "";

            if (h < 10)
            {
                time += "0" + h;
            }
                else
                {
                    time += h;
                }

                   time += ":";

            if (m < 10)
            {
                time += "0" + m;
            }
                else
                {
                    time += m;
                }

                    time += ":";

                if (s < 10)
                {
                    time += "0" + s;
                }
                    else
                    {
                        time += s;
                    }

                           this.TimeLabel.Text = time;

            string data = "";

            int day = DateTime.Now.Day;
            int month = DateTime.Now.Month;
            int year = DateTime.Now.Year;

            if (day < 10)
            {
                data += "0" + day;
            }
                else
                {
                    data += day;
                }

                    data += ".";

            if (month < 10)
            {
                data += "0" + month;
            }
                else
                {
                    data += month;
                }

                data += ".";
                data += year;
            this.DateLabel.Text = data;
      }

        private void OpenFrmw_Click(object sender, EventArgs e)
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
                            System.IO.StreamReader sr = new
                            System.IO.StreamReader(oFile.FileName);
                            FirmwBuffer.Text = (sr.ReadToEnd());
                            sr.Close();
                           
                         }
                    }
                }

                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
           }
        }

        private void saveButton_Click(object sender, EventArgs e)
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

        private void sAsButton_Click(object sender, EventArgs e)
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

        private void clearBuffer_Click(object sender, EventArgs e)
        {
            FirmwBuffer.Clear();
        }

        private void readData_Click(object sender, EventArgs e)
        {
            // Граф
            /*
            List<int> tellemetry = new List<int>();
            tellemetry.Add(firstTempToChart);
            tellemetry.Add(secondTempToChart);
            tellemetry.Add(humidityToChart);
            tellemetry.Add(lightLevelToChart);
            */
            telemetryGraph.Series[0].Points.AddY(firstTempToChart);
            telemetryGraph.Series[1].Points.AddY(secondTempToChart);
            telemetryGraph.Series[2].Points.AddY(humidityToChart);
            telemetryGraph.Series[3].Points.AddY(lightLevelToChart);
            /*
            foreach (int item in tellemetry)
            {
                telemetryGraph.Series[0].Points.AddY(item);

            }
            */
        }

       
    }
}