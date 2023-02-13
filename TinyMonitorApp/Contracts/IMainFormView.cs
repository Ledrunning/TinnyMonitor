using MaterialSkin.Controls;
using System.Windows.Forms;
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

        MaterialRadioButton HexOrText { get; set; }

        ComboBox ComPortName { get; set; }

        ComboBox ComPortParity { get; set; }

        ComboBox ComPortStopBit { get; set; }

        ComboBox ComPortBaudRates { get; set; }

        ComboBox ComPortDataBits { get; set; }

        void SetPresenter(MainFormPresenter presenter);
    }
}