using TinyMonitorApp.Presenter;

namespace TinyMonitorApp.Contracts
{
    public interface IMainFormView
    {
        string DateLabel { get; set; }

        string TimeLabel { get; set; }

        string InsideTemperature { get; set; }

        string OutsideTemperature { get; set; }

        string Humidity { get; set; }

        string LightLevel { get; set; }

        string ConsoleDisplay { get; set; }

        object ComPort { get; set; }

        object ComPortParity { get; set; }

        object ComPortStopBit { get; set; }

        void SetPresenter(MainFormPresenter presenter);
    }
}