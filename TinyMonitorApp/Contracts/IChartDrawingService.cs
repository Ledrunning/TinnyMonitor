namespace TinyMonitorApp.Contracts
{
    public interface IChartDrawingService
    {
        void UpdateChart(int indoorTemperature, int outdoorTemperature, int humidity, int lightLevel);
    }
}