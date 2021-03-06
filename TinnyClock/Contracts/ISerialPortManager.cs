﻿using System;
using System.Collections.Generic;
using TinnyClock.Enums;
using TinnyClock.Models;

namespace TinnyClock.Contracts
{
    public interface ISerialPortManager
    {
        string BaudRatesRate { get; set; }
        string Parity { get; set; }
        string StopBits { get; set; }
        string DataBits { get; set; }
        string PortName { get; set; }
        TransmissionType CurrentTransmissionType { get; set; }
        IEnumerable<string> ParityValues { get; }
        IEnumerable<string> StopBitValues { get; }
        IEnumerable<string> PortNameValues { get; }
        event Action<ReceivedDataDto> OnDataReceived;
        void WriteData(string msg);
        bool OpenPort();
        bool ClosePort();
    }
}