namespace TinyMonitorApp.Contracts
{
    public interface IChartDrawingService
    {
        void UpdateChart(double indoorTemperature, double outdoorTemperature);
    }
}