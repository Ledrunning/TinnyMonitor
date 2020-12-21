using System;
using System.Collections.Generic;
using System.IO.Ports;
using TinnyClock.Converters;
using TinnyClock.Enums;
using TinnyClock.Helpers;
using TinnyClock.Models;

namespace TinnyClock.Service
{
    internal class SerialPortManager
    {
        private readonly SerialPort comPort = new SerialPort();
        private readonly StringParser recievedStrFromComPort = new StringParser();

        public SerialPortManager(string baudRates, string parity, string stopBits, string dataBits, string name)
        {
            BaudRatesRate = baudRates;
            Parity = parity;
            StopBits = stopBits;
            DataBits = dataBits;
            PortName = name;

            comPort.DataReceived += SerialPortDataReceived;
        }

        public SerialPortManager() : this(string.Empty, string.Empty, string.Empty, string.Empty, string.Empty)
        {
        }

        public string BaudRatesRate { get; set; }

        public string Parity { get; set; }

        public string StopBits { get; set; }

        public string DataBits { get; set; }

        public string PortName { get; set; }

        public TransmissionType CurrentTransmissionType { get; set; }

        public IEnumerable<string> ParityValues => System.Enum.GetNames(typeof(Parity));
        public IEnumerable<string> StopBitValues => System.Enum.GetNames(typeof(StopBits));
        public IEnumerable<string> PortNameValues => SerialPort.GetPortNames();

        public event Action<ReceivedDataDto> OnDataReceived = delegate { };

        public void WriteData(string msg)
        {
            switch (CurrentTransmissionType)
            {
                case TransmissionType.Text:
                    EnsurePortOpened();
                    comPort.Write(msg);
                    //display the message
                    DisplayData(MessageType.Outgoing, $"{msg}\n");
                    break;

                case TransmissionType.Hex:
                    try
                    {
                        EnsurePortOpened();
                        //convert the message to byte array
                        var newMsg = SubConverter.HexToByte(msg);
                        //send the message to the port
                        comPort.Write(newMsg, 0, newMsg.Length);
                        //convert back to hex and display
                        DisplayData(MessageType.Outgoing, $"{SubConverter.ByteToHex(newMsg)}\n");
                    }
                    catch (FormatException ex)
                    {
                        //display error message
                        DisplayData(MessageType.Error, ex.Message);
                    }

                    break;

                default:
                    EnsurePortOpened();
                    comPort.Write(msg);
                    //display the message
                    DisplayData(MessageType.Outgoing, $"{msg}\n");
                    break;
            }
        }

        private void DisplayData(MessageType type, string msg)
        {
            var dto = new ReceivedDataDto
            {
                IndorTemperature = recievedStrFromComPort.ParseInsideTemperature(msg),
                OutdoorTemperature = recievedStrFromComPort.ParseOutsideTemperature(msg),
                Humidity = recievedStrFromComPort.ParseHumidity(msg),
                LightLevel = recievedStrFromComPort.ParseLightLevel(msg),
                RawText = msg
            };

            OnDataReceived(dto);
        }

        public bool OpenPort()
        {
            try
            {
                if (comPort.IsOpen)
                {
                    comPort.Close();
                }

                //set the properties of our SerialPort Object
                comPort.BaudRate = int.Parse(BaudRatesRate); //BaudRatesRate
                comPort.DataBits = int.Parse(DataBits); //DataBits
                comPort.StopBits = (StopBits) Enum.Parse(typeof(StopBits), StopBits); //StopBits
                comPort.Parity = (Parity) Enum.Parse(typeof(Parity), Parity); //Parity
                comPort.PortName = PortName; //PortName
                //now open the port
                comPort.Open();
                //display message
                DisplayData(MessageType.Normal, $"Port opened at {DateTime.Now}\n");
                // Что бы не выводилась надпись при открытии порта.
                return true;
            }
            catch (Exception ex)
            {
                DisplayData(MessageType.Error, ex.Message);
                return false;
            }
        }

        public bool ClosePort()
        {
            comPort.Close();
            //display message
            var message = "Port closed at ";
            DisplayData(MessageType.Closed, $"{message}{DateTime.Now}\n");
            return true;
        }

        private void EnsurePortOpened()
        {
            if (!comPort.IsOpen)
            {
                comPort.Open();
            }
        }

        private void SerialPortDataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            //determine the mode the user selected (binary/string)
            switch (CurrentTransmissionType)
            {
                //user chose string
                case TransmissionType.Text:
                    //read data waiting in the buffer
                    var msg = comPort.ReadExisting();
                    //display the data to the user
                    DisplayData(MessageType.Incoming, $"{msg}\n");
                    break;

                //user chose binary
                case TransmissionType.Hex:
                    //retrieve number of bytes in the buffer
                    var bytes = comPort.BytesToRead;
                    //create a byte array to hold the awaiting data
                    var comBuffer = new byte[bytes];
                    //read the data and store it
                    comPort.Read(comBuffer, 0, bytes);
                    //display the data to the user
                    DisplayData(MessageType.Incoming, $"{SubConverter.ByteToHex(comBuffer)}\n");
                    break;

                default:
                    //read data waiting in the buffer
                    var str = comPort.ReadExisting();
                    //display the data to the user
                    DisplayData(MessageType.Incoming, $"{str}\n");
                    break;
            }
        }
    }
}