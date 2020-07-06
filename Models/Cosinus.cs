using OxyPlot;
using OxyPlot.Series;
using System;
using System.Collections.Generic;
using System.Text;

namespace View.UI.Models
{
    public class Cosinus : Function
    {
        public override LineSeries Funk()
        {
            IList<DataPoint> Points = new List<DataPoint>();
            for (double i = -1000; i < 1000; i++)//
            {
                Points.Add(new DataPoint(i * 0.1, Math.Cos(i * 0.1) * Amplitude));
            }
            var series = new LineSeries
            {
                Color = OxyColors.Green,
                LineStyle = LineStyle.Solid,
            };
            foreach (DataPoint p in Points)
            {
                series.Points.Add(p);
            }
            return series;
        }
    }
}
