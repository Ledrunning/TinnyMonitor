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
        private readonly Logger logger = LogManager.GetCurrentClassLogger();
        private readonly StringParser receivedStrFromComPort = new StringParser();

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

        public IEnumerable<string> ParityValues => Enum.GetNames(typeof(Parity));
        public IEnumerable<string> StopBitValues => Enum.GetNames(typeof(StopBits));
        public IEnumerable<string> PortNameValues => SerialPort.GetPortNames();

        public event Action<ReceivedDataDto> OnDataReceived = delegate { };

        public void WriteData(string msg)
        {
            switch (CurrentTransmissionType)
            {
                case TransmissionType.Text:
                    EnsurePortOpened();
                    comPort.Write(msg);
                    InputStringProcessing($"{msg}\n");
                    break;

                case TransmissionType.Hex:
                    try
                    {
                        EnsurePortOpened();
                        var newMsg = SubConverter.HexToByte(msg);

                        comPort.Write(newMsg, 0, newMsg.Length);
                        InputStringProcessing($"{SubConverter.ByteToHex(newMsg)}\n");
                    }
                    catch (FormatException ex)
                    {
                        //display error message
                        InputStringProcessing(ex.Message);
                    }

                    break;

                default:
                    EnsurePortOpened();
                    comPort.Write(msg);
                    InputStringProcessing($"{msg}\n");
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
                comPort.StopBits = (StopBits)Enum.Parse(typeof(StopBits), StopBits);
                comPort.Parity = (Parity)Enum.Parse(typeof(Parity), Parity);
                comPort.PortName = PortName;

                comPort.Open();

                InputStringProcessing($"Port opened at {DateTime.Now}\n");
                logger.Info($"Port opened at {DateTime.Now}\n");
                return true;
            }
            catch (Exception ex)
            {
                InputStringProcessing(ex.Message);
                logger.Error(ex);
                return false;
            }
        }

        public bool ClosePort()
        {
            comPort.Close();
            const string message = "Port closed at ";
            InputStringProcessing($"{message}{DateTime.Now}\n");
            logger.Info($"{message}{DateTime.Now}\n");
            return true;
        }

        private void InputStringProcessing(string msg)
        {
            var dto = new ReceivedDataDto
            {
                IndoorTemperature = receivedStrFromComPort.ParseInsideTemperature(msg),
                OutdoorTemperature = receivedStrFromComPort.ParseOutsideTemperature(msg),
                Humidity = receivedStrFromComPort.ParseHumidity(msg),
                LightLevel = receivedStrFromComPort.ParseLightLevel(msg),
                RawText = msg
            };

            OnDataReceived?.Invoke(dto);
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
                    InputStringProcessing($"{msg}\n");
                    break;

                case TransmissionType.Hex:

                    var bytes = comPort.BytesToRead;
                    var comBuffer = new byte[bytes];

                    comPort.Read(comBuffer, 0, bytes);
                    InputStringProcessing($"{SubConverter.ByteToHex(comBuffer)}\n");
                    break;

                default:
                    var str = comPort.ReadExisting();
                    InputStringProcessing($"{str}\n");
                    break;
            }
        }
    }
}