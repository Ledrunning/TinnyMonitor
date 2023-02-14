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

        public void UpdateChart(int indoorTemperature, int outdoorTemperature, int humidity, int lightLevel)
        {
            var indoorSeries = (LineSeries) plotModel.Model.Series[ChartConstants.IndoorTemperatureIndex];
            var outdoorSeries = (LineSeries) plotModel.Model.Series[ChartConstants.OutdoorTemperatureIndex];
            var humiditySeries = (LineSeries) plotModel.Model.Series[ChartConstants.HumidityIndex];
            var lightLevelSeries = (LineSeries) plotModel.Model.Series[ChartConstants.LightLevelIndex];
            
            indoorSeries.Points.Add(new DataPoint(FormatPoints(indoorSeries), indoorTemperature));
            outdoorSeries.Points.Add(new DataPoint(FormatPoints(outdoorSeries), outdoorTemperature));
            humiditySeries.Points.Add(new DataPoint(FormatPoints(humiditySeries), humidity));
            lightLevelSeries.Points.Add(new DataPoint(FormatPoints(lightLevelSeries), lightLevel));
        }

        private static double FormatPoints(DataPointSeries series)
        {
            var x = series.Points.Count > 0 ? series.Points[series.Points.Count - 1].X + 1 : 0;

            if (series.Points.Count >= ChartConstants.MaxPoints)
            {
                series.Points.RemoveAt(0);
            }

            return x;
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

            AddSeries();
        }

        private void AddSeries()
        {
            //Indoor temperature
            plotModel.Model.Series.Add(new LineSeries
            {
                LineStyle = LineStyle.Solid,
                Color = ChartConstants.Blue
            });

            //Outdoor temperature
            plotModel.Model.Series.Add(new LineSeries
            {
                LineStyle = LineStyle.Solid,
                Color = ChartConstants.Red
            });

            //Humidity
            plotModel.Model.Series.Add(new LineSeries
            {
                LineStyle = LineStyle.Solid,
                Color = ChartConstants.Green
            });

            //LightLevel
            plotModel.Model.Series.Add(new LineSeries
            {
                LineStyle = LineStyle.Solid,
                Color = ChartConstants.Purple
            });
        }
    }
}