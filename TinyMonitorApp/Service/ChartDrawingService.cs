using System;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using OxyPlot.WindowsForms;
using TinyMonitorApp.Constants;
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

        public void UpdateChart(double inputTemperature)
        {
            PrintTemperatureChart(inputTemperature);
        }

        private void PrintTemperatureChart(double inputTemperature)
        {
            var indoorSeries = (LineSeries) plotModel.Model.Series[0];
            var outdoorSeries = (LineSeries) plotModel.Model.Series[1];

            var x = indoorSeries.Points.Count > 0 ? indoorSeries.Points[indoorSeries.Points.Count - 1].X + 1 : 0;
            
            if (indoorSeries.Points.Count >= 200)
            {
                indoorSeries.Points.RemoveAt(0);
            }

            var x1 = outdoorSeries.Points.Count > 0 ? outdoorSeries.Points[outdoorSeries.Points.Count - 1].X + 1 : 0;
            
            if (outdoorSeries.Points.Count >= 200)
            {
                outdoorSeries.Points.RemoveAt(0);
            }

            indoorSeries.Points.Add(new DataPoint(x, inputTemperature));
            outdoorSeries.Points.Add(new DataPoint(x1, 20));
        }

        private void InitializeCharts(string title)
        {
            plotModel.Model.Title = title;
            plotModel.Model.PlotAreaBorderColor = ChartConstants.Black;
            plotModel.Model.TitleColor = ChartConstants.Black;

            plotModel.Model.LegendPosition = LegendPosition.RightBottom;
            //Y
            plotModel.Model.Axes.Add(new LinearAxis
            {
                IsPanEnabled = true, // отключение скролинга
                IsZoomEnabled = true, // отключение зума 
                AbsoluteMaximum = ChartConstants.AbsoluteMaximum,
                AbsoluteMinimum = ChartConstants.AbsoluteMinimum,
                Position = AxisPosition.Left,
                Maximum = ChartConstants.AxisX,
                Minimum = ChartConstants.AxisY,
                TextColor = ChartConstants.TextColor,
                AxislineColor = ChartConstants.Black,
                MajorGridlineColor = ChartConstants.MajorGridlineColor,
                MajorGridlineStyle = LineStyle.Solid,
                MinorGridlineColor = ChartConstants.MinorGridlineColor,
                MinorGridlineStyle = LineStyle.Solid,
                TicklineColor = ChartConstants.Black
            });

            //X
            plotModel.Model.Axes.Add(new LinearAxis
            {
                IsPanEnabled = false, // отключение скролинга
                IsZoomEnabled = false, // отключение зума
                Position = AxisPosition.Bottom,
                TextColor = ChartConstants.TextColor,
                AxislineColor = ChartConstants.Black,
                MajorGridlineColor = ChartConstants.MajorGridlineColor,
                MajorGridlineStyle = LineStyle.Solid,
                MinorGridlineColor = ChartConstants.MinorGridlineColor,
                MinorGridlineStyle = LineStyle.Solid,
                TicklineColor = ChartConstants.Black
            });

            plotModel.Model.Series.Add(new LineSeries
            {
                LineStyle = LineStyle.Solid,
                Color = ChartConstants.Blue
            }); 

            plotModel.Model.Series.Add(new LineSeries
            {
                LineStyle = LineStyle.Solid,
                Color = ChartConstants.Red
            });
        }
    }
}