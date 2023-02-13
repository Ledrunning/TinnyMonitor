using System;
using System.Collections.Generic;
using System.IO.Ports;
using TinyMonitorApp.Contracts;
using TinyMonitorApp.Enums;
using TinyMonitorApp.Models;
using TinyMonitorApp.Service;

namespace TinyMonitorApp.Presenter
{
    public class MainFormPresenter : IMainFormPresenter
    {
        private readonly IMainFormView view;
        private SerialPortManager serialPortManager;

        public event Action<ReceivedDataDto> OnSerialPortDataReceived = delegate { };

        public IEnumerable<string> ParityValues { get; set; } = Enum.GetNames(typeof(Parity));
        public IEnumerable<string> StopBitValues { get; set; } = Enum.GetNames(typeof(StopBits));
        public IEnumerable<string> PortNameValues { get; set; } = SerialPort.GetPortNames();

        public MainFormPresenter(IMainFormView view)
        {
            this.view = view;
            view.SetPresenter(this);
        }

        public void StartSerialPort()
        {
            int.TryParse(view.ComPortBaudRates.Text, out var baudRates);
            int.TryParse(view.ComPortDataBits.Text, out var dataBits);
            serialPortManager = new SerialPortManager(baudRates, view.ComPortParity.Text, view.ComPortStopBit.Text, dataBits, view.ComPortName.Text);
            serialPortManager.OnDataReceived += OnSerialDataReceived;
            serialPortManager.OpenPort();
        }

        
        public void SetCurrentTransmissionType()
        {
            if (serialPortManager != null)
            {
                serialPortManager.CurrentTransmissionType = view.HexOrText.Checked ? TransmissionType.Hex : TransmissionType.Text;
            }
        }

        //txtSend.Text
        public void WriteData(string data)
        {
            serialPortManager.WriteData(data);
        }

        public void CloseSerialPort()
        {
            serialPortManager.ClosePort();
            serialPortManager.OnDataReceived -= OnSerialDataReceived;
        }

        private void OnSerialDataReceived(ReceivedDataDto args)
        {
            OnSerialPortDataReceived?.Invoke(args);
        }
    }
}