using System;
using System.Text;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using TinnyClock;
using System.Collections.Generic;
//*****************************************************************************************
//                           LICENSE INFORMATION
//*****************************************************************************************
//   PCCom.SerialCommunication Version 1.0.0.0
//   Class file for managing serial port communication
//
//   Copyright (C) 2007  
//   Richard L. McCutchen 
//   Email: richard@psychocoder.net
//   Created: 20OCT07
//
//   This program is free software: you can redistribute it and/or modify
//   it under the terms of the GNU General Public License as published by
//   the Free Software Foundation, either version 3 of the License, or
//   (at your option) any later version.
//
//   This program is distributed in the hope that it will be useful,
//   but WITHOUT ANY WARRANTY; without even the implied warranty of
//   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//   GNU General Public License for more details.
//
//   You should have received a copy of the GNU General Public License
//   along with this program.  If not, see <http://www.gnu.org/licenses/>.
//*****************************************************************************************
namespace PCComm
{
    class CommunicationManager
    {
        public enum TransmissionType { Text, Hex }

        public enum MessageType { Incoming, Outgoing, Normal, Warning, Error, Closed };

        private string _baudRate = string.Empty;
        private string _parity = string.Empty;
        private string _stopBits = string.Empty;
        private string _dataBits = string.Empty;
        private string _portName = string.Empty;
        private TransmissionType _transType;

        private SerialPort comPort = new SerialPort();
        private StringParser recievedStrFromComPort = new StringParser();

        public string BaudRate
        {
            get { return _baudRate; }
            set { _baudRate = value; }
        }

        public string Parity
        {
            get { return _parity; }
            set { _parity = value; }
        }

        public string StopBits
        {
            get { return _stopBits; }
            set { _stopBits = value; }
        }

        public string DataBits
        {
            get { return _dataBits; }
            set { _dataBits = value; }
        }

        public string PortName
        {
            get { return _portName; }
            set { _portName = value; }
        }

        public TransmissionType CurrentTransmissionType
        {
            get { return _transType; }
            set { _transType = value; }
        }

        public IEnumerable<string> ParityValues   => Enum.GetNames(typeof(Parity));
        public IEnumerable<string> StopBitValues  => Enum.GetNames(typeof(StopBits));
        public IEnumerable<string> PortNameValues => SerialPort.GetPortNames();

        public event Action<ReceivedDataDTO> OnDataReceived = delegate { };

        public CommunicationManager(string baud, string par, string sBits, string dBits, string name)
        {
            _baudRate = baud;
            _parity = par;
            _stopBits = sBits;
            _dataBits = dBits;
            _portName = name;

            comPort.DataReceived += new SerialDataReceivedEventHandler(comPort_DataReceived);
        }

        public CommunicationManager() : this(String.Empty, String.Empty, String.Empty, String.Empty, String.Empty)
        {

        }

        public void WriteData(string msg)
        {
            switch (CurrentTransmissionType)
            {
                case TransmissionType.Text:
                    ensurePortOpened();
                    comPort.Write(msg);
                    //display the message
                    DisplayData(MessageType.Outgoing, msg + "\n");
                    break;

                case TransmissionType.Hex:
                    try
                    {
                        ensurePortOpened();
                        //convert the message to byte array
                        byte[] newMsg = HexToByte(msg);
                        //send the message to the port
                        comPort.Write(newMsg, 0, newMsg.Length);
                        //convert back to hex and display
                        DisplayData(MessageType.Outgoing, ByteToHex(newMsg) + "\n");
                    } catch (FormatException ex) {
                        //display error message
                        DisplayData(MessageType.Error, ex.Message);
                    }
                    break;

                default:
                    ensurePortOpened();
                    comPort.Write(msg);
                    //display the message
                    DisplayData(MessageType.Outgoing, msg + "\n");
                    break;
                    
            }
        }

        private byte[] HexToByte(string msg)
        {
            //remove any spaces from the string
            msg = msg.Replace(" ", "");
            //create a byte array the length of the
            //divided by 2 (Hex is 2 characters in length)
            byte[] comBuffer = new byte[msg.Length / 2];
            //loop through the length of the provided string
            for (int i = 0; i < msg.Length; i += 2)
                //convert each set of 2 characters to a byte
                //and add to the array
                comBuffer[i / 2] = (byte)Convert.ToByte(msg.Substring(i, 2), 16);
            //return the array
            return comBuffer;
        }

        private string ByteToHex(byte[] comByte)
        {
            //create a new StringBuilder object
            StringBuilder builder = new StringBuilder(comByte.Length * 3);
            //loop through each byte in the array
            foreach (byte data in comByte)
                //convert the byte to a string and add to the stringbuilder
                builder.Append(Convert.ToString(data, 16).PadLeft(2, '0').PadRight(3, ' '));
            //return the converted value
            return builder.ToString().ToUpper();
        }

        private void DisplayData(MessageType type, string msg)
        {
            var dto = new ReceivedDataDTO
            {
                Temp1 = recievedStrFromComPort.ParseInsideTemperature(msg),
                Temp2 = recievedStrFromComPort.ParseOutsideTemperature(msg),
                Humidity = recievedStrFromComPort.ParseHumidity(msg),
                LightLevel = recievedStrFromComPort.ParseLightLevel(msg),
                RawText = msg
            };

            this.OnDataReceived(dto);
        }

        public bool OpenPort()
        {
            try {
                    if (comPort.IsOpen)
                    {
                        comPort.Close();
                    }

                    //set the properties of our SerialPort Object
                    comPort.BaudRate = int.Parse(_baudRate);    //BaudRate
                    comPort.DataBits = int.Parse(_dataBits);    //DataBits
                    comPort.StopBits = (StopBits)Enum.Parse(typeof(StopBits), _stopBits);    //StopBits
                    comPort.Parity = (Parity)Enum.Parse(typeof(Parity), _parity);    //Parity
                    comPort.PortName = _portName;   //PortName
                    //now open the port
                    comPort.Open();
                    //display message
                    DisplayData(MessageType.Normal, "Port opened at " + DateTime.Now + "\n");
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
            string message = "Port closed at ";
            DisplayData(MessageType.Closed, message + DateTime.Now + "\n");
            return true;
        }

        private void ensurePortOpened()
        {
            if (!comPort.IsOpen)
            {
                comPort.Open();
            }
        }

        private void comPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            //determine the mode the user selected (binary/string)
            switch (CurrentTransmissionType)
            {
                //user chose string
                case TransmissionType.Text:
                    //read data waiting in the buffer
                    string msg = comPort.ReadExisting();
                    //display the data to the user
                    DisplayData(MessageType.Incoming, msg + "\n");
                    break;

                //user chose binary
                case TransmissionType.Hex:
                    //retrieve number of bytes in the buffer
                    int bytes = comPort.BytesToRead;
                    //create a byte array to hold the awaiting data
                    byte[] comBuffer = new byte[bytes];
                    //read the data and store it
                    comPort.Read(comBuffer, 0, bytes);
                    //display the data to the user
                    DisplayData(MessageType.Incoming, ByteToHex(comBuffer) + "\n");
                    break;

                default:
                    //read data waiting in the buffer
                    string str = comPort.ReadExisting();
                    //display the data to the user
                    DisplayData(MessageType.Incoming, str + "\n");
                    break;
            }
        }
    }
}
