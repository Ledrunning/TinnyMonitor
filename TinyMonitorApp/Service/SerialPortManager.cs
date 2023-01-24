using System;
using System.Collections.Generic;
using System.IO.Ports;
using NLog;
using TinyMonitorApp.Contracts;
using TinyMonitorApp.Converters;
using TinyMonitorApp.Enums;
using TinyMonitorApp.Helpers;
using TinyMonitorApp.Models;

namespace TinyMonitorApp.Service
{
    internal class SerialPortManager : ISerialPortManager
    {
        private readonly SerialPort comPort = new SerialPort();
        private readonly StringParser recievedStrFromComPort = new StringParser();
        private readonly Logger logger = LogManager.GetCurrentClassLogger();

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
                    DisplayData(MessageType.Outgoing, $"{msg}\n");
                    break;

                case TransmissionType.Hex:
                    try
                    {
                        EnsurePortOpened();
                        var newMsg = SubConverter.HexToByte(msg);
                        
                        comPort.Write(newMsg, 0, newMsg.Length);
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
                    DisplayData(MessageType.Outgoing, $"{msg}\n");
                    break;
            }
        }

        public bool OpenPort()
        {
            try
            {
                if (comPort.IsOpen)
                {
                    comPort.Close();
                }

                comPort.BaudRate = int.Parse(BaudRatesRate);
                comPort.DataBits = int.Parse(DataBits);
                comPort.StopBits = (StopBits) Enum.Parse(typeof(StopBits), StopBits); 
                comPort.Parity = (Parity) Enum.Parse(typeof(Parity), Parity); 
                comPort.PortName = PortName; 
                
                comPort.Open();
                
                DisplayData(MessageType.Normal, $"Port opened at {DateTime.Now}\n");
                logger.Info($"Port opened at {DateTime.Now}\n");
                return true;
            }
            catch (Exception ex)
            {
                DisplayData(MessageType.Error, ex.Message);
                logger.Error(ex);
                return false;
            }
        }

        public bool ClosePort()
        {
            comPort.Close();
            var message = "Port closed at ";
            DisplayData(MessageType.Closed, $"{message}{DateTime.Now}\n");
            logger.Info($"{message}{DateTime.Now}\n");
            return true;
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

        private void EnsurePortOpened()
        {
            if (!comPort.IsOpen)
            {
                comPort.Open();
            }
        }

        private void SerialPortDataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            switch (CurrentTransmissionType)
            {
                case TransmissionType.Text:
                    
                    var msg = comPort.ReadExisting();
                    DisplayData(MessageType.Incoming, $"{msg}\n");
                    break;

                case TransmissionType.Hex:
                   
                    var bytes = comPort.BytesToRead;
                    var comBuffer = new byte[bytes];
                    
                    comPort.Read(comBuffer, 0, bytes);
                    DisplayData(MessageType.Incoming, $"{SubConverter.ByteToHex(comBuffer)}\n");
                    break;

                default:
                    var str = comPort.ReadExisting();
                    DisplayData(MessageType.Incoming, $"{str}\n");
                    break;
            }
        }
    }
}