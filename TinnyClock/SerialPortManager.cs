using System;
using System.Collections.Generic;
using System.IO.Ports;
using TinnyClock.Converters;
using TinnyClock.Helpers;

namespace TinnyClock
{
	internal class SerialPortManager
	{
		public enum TransmissionType { Text, Hex }

		public enum MessageType { Incoming, Outgoing, Normal, Warning, Error, Closed };

		private SerialPort _comPort = new SerialPort();
		private StringParser _recievedStrFromComPort = new StringParser();

		public string BaudRatesRate { get; set; }

		public string Parity { get; set; }

		public string StopBits { get; set; }

		public string DataBits { get; set; }

		public string PortName { get; set; }

		public TransmissionType CurrentTransmissionType { get; set; }

		public IEnumerable<string> ParityValues => Enum.GetNames(typeof(Parity));
		public IEnumerable<string> StopBitValues => Enum.GetNames(typeof(StopBits));
		public IEnumerable<string> PortNameValues => SerialPort.GetPortNames();

		public event Action<ReceivedDataDTO> OnDataReceived = delegate { };

		public SerialPortManager(string baudRates, string parity, string stopBits, string dataBits, string name)
		{
			BaudRatesRate = baudRates;
			Parity = parity;
			StopBits = stopBits;
			DataBits = dataBits;
			PortName = name;

			_comPort.DataReceived += SerialPortDataReceived;
		}

		public SerialPortManager() : this(string.Empty, string.Empty, string.Empty, string.Empty, string.Empty)
		{
		}

		public void WriteData(string msg)
		{
			switch (CurrentTransmissionType)
			{
				case TransmissionType.Text:
					EnsurePortOpened();
					_comPort.Write(msg);
					//display the message
					DisplayData(MessageType.Outgoing, $"{msg}\n");
					break;

				case TransmissionType.Hex:
					try
					{
						EnsurePortOpened();
						//convert the message to byte array
						byte[] newMsg = SubConverter.HexToByte(msg);
						//send the message to the port
						_comPort.Write(newMsg, 0, newMsg.Length);
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
					_comPort.Write(msg);
					//display the message
					DisplayData(MessageType.Outgoing, $"{msg}\n");
					break;
			}
		}

		private void DisplayData(MessageType type, string msg)
		{
			var dto = new ReceivedDataDTO
			{
				IndorTemperature = _recievedStrFromComPort.ParseInsideTemperature(msg),
				OutdoorTemperature = _recievedStrFromComPort.ParseOutsideTemperature(msg),
				Humidity = _recievedStrFromComPort.ParseHumidity(msg),
				LightLevel = _recievedStrFromComPort.ParseLightLevel(msg),
				RawText = msg
			};

			this.OnDataReceived(dto);
		}

		public bool OpenPort()
		{
			try
			{
				if (_comPort.IsOpen)
				{
					_comPort.Close();
				}

				//set the properties of our SerialPort Object
				_comPort.BaudRate = int.Parse(BaudRatesRate);    //BaudRatesRate
				_comPort.DataBits = int.Parse(DataBits);    //DataBits
				_comPort.StopBits = (StopBits)Enum.Parse(typeof(StopBits), StopBits);    //StopBits
				_comPort.Parity = (Parity)Enum.Parse(typeof(Parity), Parity);    //Parity
				_comPort.PortName = PortName;   //PortName
												//now open the port
				_comPort.Open();
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
			_comPort.Close();
			//display message
			string message = "Port closed at ";
			DisplayData(MessageType.Closed, $"{message}{DateTime.Now}\n");
			return true;
		}

		private void EnsurePortOpened()
		{
			if (!_comPort.IsOpen)
			{
				_comPort.Open();
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
					string msg = _comPort.ReadExisting();
					//display the data to the user
					DisplayData(MessageType.Incoming, $"{msg}\n");
					break;

				//user chose binary
				case TransmissionType.Hex:
					//retrieve number of bytes in the buffer
					int bytes = _comPort.BytesToRead;
					//create a byte array to hold the awaiting data
					byte[] comBuffer = new byte[bytes];
					//read the data and store it
					_comPort.Read(comBuffer, 0, bytes);
					//display the data to the user
					DisplayData(MessageType.Incoming, $"{SubConverter.ByteToHex(comBuffer)}\n");
					break;

				default:
					//read data waiting in the buffer
					string str = _comPort.ReadExisting();
					//display the data to the user
					DisplayData(MessageType.Incoming, $"{str}\n");
					break;
			}
		}
	}
}