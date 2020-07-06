using OxyPlot;
using OxyPlot.Series;
using System;
using System.Collections.Generic;
using System.Text;

namespace View.UI.Models
{
    public class Cotangens : Function
    {
        public override LineSeries Funk()
        {
            IList<DataPoint> Points = new List<DataPoint>();
            for (double i = -30000; i < 30000; i++)// tg(π/2 − x)
            {
                Points.Add(new DataPoint(Math.PI * i * 0.001, Math.Tan((Math.PI / 2) - Math.PI * i * 0.001) * Amplitude));
            }
            const int N = 10;
            var customMarkerOutline = new ScreenPoint[N];
            for (int i = 0; i < N; i++)
            {
                double th = Math.PI * (4.0 * i / (N - 1) - 0.5);
                customMarkerOutline[i] = new ScreenPoint(Math.Cos(th) * 0.5, Math.Sin(th) * 5);
            }
            var series = new LineSeries
            {
                MarkerType = MarkerType.Custom,
                MarkerOutline = customMarkerOutline,
                MarkerFill = OxyColors.Blue,
                MarkerSize = 1
            };
            foreach (DataPoint p in Points)
            {
                series.Points.Add(p);
            }
            return series;
        }
    }
}
