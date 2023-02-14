using System;
using System.IO.Ports;
using NLog;
using TinyMonitorApp.Contracts;
using TinyMonitorApp.Converters;
using TinyMonitorApp.Enums;
using TinyMonitorApp.Extensions;
using TinyMonitorApp.Helpers;
using TinyMonitorApp.Models;

namespace TinyMonitorApp.Service
{
    internal class SerialPortManager : SerialPort, ISerialPortManager
    {
        private readonly Logger logger = LogManager.GetCurrentClassLogger();
        private readonly StringParser receivedStrFromComPort = new StringParser();

        public SerialPortManager(int baudRates, string parity, string stopBits, int dataBits, string name)
        {
            BaudRate = baudRates;
            Parity = parity.ToEnum(Parity);
            StopBits = stopBits.ToEnum(StopBits);
            DataBits = dataBits;
            PortName = name;
        }

        public SerialPortManager() : this(default, string.Empty, string.Empty, default, string.Empty)
        {
        }

        public TransmissionType CurrentTransmissionType { get; set; }


        public event Action<ReceivedDataDto> OnDataReceived = delegate { };

        public void WriteData(string msg)
        {
            switch (CurrentTransmissionType)
            {
                case TransmissionType.Text:
                    EnsurePortOpened();
                    Write(msg);
                    InputStringProcessing($"{msg}\n");
                    break;

                case TransmissionType.Hex:
                    try
                    {
                        EnsurePortOpened();
                        var newMsg = SubConverter.HexToByte(msg);

                        Write(newMsg, 0, newMsg.Length);
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
                    Write(msg);
                    InputStringProcessing($"{msg}\n");
                    break;
            }
        }

        public bool OpenPort()
        {
            try
            {
                EnsurePortOpened();
                DataReceived += SerialPortDataReceived;
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

        public void ClosePort()
        {
            if (!IsOpen)
            {
                return;
            }

            DataReceived -= SerialPortDataReceived;
            DiscardInBuffer();
            Close();

            const string message = "Port closed at ";
            InputStringProcessing($"{message}{DateTime.Now}\n");
            logger.Info($"{message}{DateTime.Now}\n");
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

            OnDataReceived(dto);
        }

        private void EnsurePortOpened()
        {
            if (!IsOpen)
            {
                Open();
            }
        }

        private void SerialPortDataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            switch (CurrentTransmissionType)
            {
                case TransmissionType.Text:

                    var receivedString = ReadExisting();
                    InputStringProcessing($"{receivedString}\n");
                    break;

                case TransmissionType.Hex:

                    var bytes = BytesToRead;
                    var comBuffer = new byte[bytes];

                    Read(comBuffer, 0, bytes);
                    InputStringProcessing($"{SubConverter.ByteToHex(comBuffer)}\n");
                    break;

                default:
                    var str = ReadExisting();
                    InputStringProcessing($"{str}\n");
                    break;
            }
        }
    }
}