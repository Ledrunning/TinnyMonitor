using OxyPlot;

namespace TinyMonitorApp.Constants
{
    public class ChartConstants
    {
        public const int IndoorTemperatureIndex = 0;
        public const int OutdoorTemperatureIndex = 1;
        public const int HumidityIndex = 2;
        public const int LightLevelIndex = 3;
        public const int MaxPoints = 200;
        public const int AxisX = 99;
        public const int AxisY = -50;
        public const int AbsoluteMaximum = 100;
        public const int AbsoluteMinimum = -51;
        public static OxyColor Black = OxyColor.FromRgb(255, 255, 255);
        public static OxyColor TextColor = OxyColor.FromRgb(74, 134, 187);
        public static OxyColor MajorGridlineColor = OxyColor.FromArgb(40, 100, 0, 139);
        public static OxyColor MinorGridlineColor = OxyColor.FromArgb(20, 0, 0, 139);
        public static OxyColor Blue = OxyColor.FromRgb(74, 134, 187);
        public static OxyColor Red = OxyColor.FromRgb(227, 0, 0);
        public static OxyColor Green = OxyColor.FromRgb(0, 127, 0);
        public static OxyColor Purple = OxyColor.FromRgb(193, 50, 255);
    }
}