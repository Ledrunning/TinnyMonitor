using System;
using System.Collections.Generic;
using System.IO.Ports;
using OxyPlot;
using TinyMonitorApp.Contracts;
using TinyMonitorApp.Enums;
using TinyMonitorApp.Models;
using TinyMonitorApp.Service;

namespace TinyMonitorApp.Presenter
{
    public class MainFormPresenter : IMainFormPresenter
    {
        private readonly IMainFormView view;
        private ChartDrawingService chartService;
        private SerialPortManager serialPortManager;

        public MainFormPresenter(IMainFormView view)
        {
            this.view = view;
            view.SetPresenter(this);
        }


        public event Action<ReceivedDataDto> OnSerialPortDataReceived = delegate { };

        public IEnumerable<string> ParityValues { get; set; } = Enum.GetNames(typeof(Parity));
        public IEnumerable<string> StopBitValues { get; set; } = Enum.GetNames(typeof(StopBits));
        public IEnumerable<string> PortNameValues { get; set; } = SerialPort.GetPortNames();

        public void StartSerialPort()
        {
            int.TryParse(view.ComPortBaudRates.Text, out var baudRates);
            int.TryParse(view.ComPortDataBits.Text, out var dataBits);
            serialPortManager = new SerialPortManager(baudRates, view.ComPortParity.Text, view.ComPortStopBit.Text,
                dataBits, view.ComPortName.Text);
            serialPortManager.OnDataReceived += OnSerialDataReceived;
            serialPortManager.OpenPort();
        }


        public void SetCurrentTransmissionType()
        {
            if (serialPortManager != null)
            {
                serialPortManager.CurrentTransmissionType =
                    view.HexOrText.Checked ? TransmissionType.Hex : TransmissionType.Text;
            }
        }

        public void WriteData(string data)
        {
            serialPortManager.WriteData(data);
        }

        public void CloseSerialPort()
        {
            serialPortManager.ClosePort();
            serialPortManager.OnDataReceived -= OnSerialDataReceived;
        }

        public void SetupChartModel()
        {
            if (view.Plot.Model == null)
            {
                view.Plot.Model = new PlotModel();
            }

            chartService = new ChartDrawingService(view.Plot, "Telemetry Data");
        }

        public void UpdateChart(int firstTempToChart, int secondTempToChart, int humidityToChart, int lightLevelToChart)
        {
            lock (view.Plot.Model.SyncRoot)
            {
                chartService.UpdateChart(firstTempToChart, secondTempToChart, humidityToChart, lightLevelToChart);
                view.Plot.Model.InvalidatePlot(true);
            }
        }

        private void OnSerialDataReceived(ReceivedDataDto args)
        {
            OnSerialPortDataReceived?.Invoke(args);
        }
    }
}