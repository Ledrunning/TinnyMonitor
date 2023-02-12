using System;
using System.Collections.Generic;
using TinyMonitorApp.Enums;
using TinyMonitorApp.Models;

namespace TinyMonitorApp.Contracts
{
    public interface ISerialPortManager
    {
        TransmissionType CurrentTransmissionType { get; set; }
        event Action<ReceivedDataDto> OnDataReceived;
        void WriteData(string msg);
        bool OpenPort();
        void ClosePort();
    }
}