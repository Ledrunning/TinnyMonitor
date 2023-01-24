using System;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using OxyPlot.WindowsForms;
using TinyMonitorApp.Contracts;

namespace TinyMonitorApp.Service
{
    public class ChartDrawingService : IChartDrawingService
    {
        private readonly PlotView plotModel;
        private string chartName;

        public ChartDrawingService(PlotView plotModel, string chartName)
        {
            this.chartName = chartName;
            this.plotModel = plotModel;
            InitializeCharts(chartName);
        }

        public void UpdateChart()
        {
            PrintTemperatureChart();
        }

        private void PrintTemperatureChart()
        {
            var lineSeries = (LineSeries) plotModel.Model.Series[0];

            var x = lineSeries.Points.Count > 0 ? lineSeries.Points[lineSeries.Points.Count - 1].X + 1 : 0;
            if (lineSeries.Points.Count >= 200)
            {
                lineSeries.Points.RemoveAt(0);
            }

            double y = 0;
            var m = 5;
            for (var j = 0; j < m; j++)
            {
                y += Math.Cos(20 * x * j * j);
            }

            //y /= m;
            lineSeries.Points.Add(new DataPoint(x, y));
        }

        private void InitializeCharts(string title)
        {
            plotModel.Model.Title = title;
            plotModel.Model.PlotAreaBorderColor = OxyColor.FromRgb(255, 255, 255);
            plotModel.Model.TitleColor = OxyColor.FromRgb(255, 255, 255);

            plotModel.Model.LegendPosition = LegendPosition.RightBottom;
            //Y
            plotModel.Model.Axes.Add(new LinearAxis
            {
                IsPanEnabled = false, // отключение скролинга
                IsZoomEnabled = false, // отключение зума 
                Position = AxisPosition.Left,
                Minimum = -10,
                Maximum = 10,
                TextColor = OxyColor.FromRgb(74, 134, 187),
                AxislineColor = OxyColor.FromRgb(255, 255, 255),
                MajorGridlineColor = OxyColor.FromArgb(40, 100, 0, 139),
                MajorGridlineStyle = LineStyle.Solid,
                MinorGridlineColor = OxyColor.FromArgb(20, 0, 0, 139),
                MinorGridlineStyle = LineStyle.Solid,
                TicklineColor = OxyColor.FromRgb(255, 255, 255)
            });

            //X
            plotModel.Model.Axes.Add(new LinearAxis
            {
                IsPanEnabled = false, // отключение скролинга
                IsZoomEnabled = false, // отключение зума
                Position = AxisPosition.Bottom,
                TextColor = OxyColor.FromRgb(74, 134, 187),
                AxislineColor = OxyColor.FromRgb(255, 255, 255),
                MajorGridlineColor = OxyColor.FromArgb(40, 100, 0, 139),
                MajorGridlineStyle = LineStyle.Solid,
                MinorGridlineColor = OxyColor.FromArgb(20, 0, 0, 139),
                MinorGridlineStyle = LineStyle.Solid,
                TicklineColor = OxyColor.FromRgb(255, 255, 255)
            });

            plotModel.Model.Series.Add(new LineSeries
            {
                LineStyle = LineStyle.Solid,
                Color = OxyColor.FromRgb(74, 134, 187)
            }); //rgb(74,134,187) #4a86bb

            plotModel.Model.Series.Add(new LineSeries
            {
                LineStyle = LineStyle.Solid,
                Color = OxyColor.FromRgb(227, 64, 64)
            });
        }
    }
}