using System;
using System.Collections.Generic;
using TinyMonitorApp.Models;

namespace TinyMonitorApp.Contracts
{
    public interface IMainFormPresenter
    {
        IEnumerable<string> ParityValues { get; set; }
        IEnumerable<string> StopBitValues { get; set; }
        IEnumerable<string> PortNameValues { get; set; }

        event Action<ReceivedDataDto> OnSerialPortDataReceived;

        void StartSerialPort();

        void SetCurrentTransmissionType();

        void WriteData(string data);

        void CloseSerialPort();
    }
}