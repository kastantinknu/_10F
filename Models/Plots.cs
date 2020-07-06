using OxyPlot;
using OxyPlot.Axes;
using System;
using System.Collections.Generic;
using System.Text;

namespace View.UI.Models
{
    public class Plots
    {
        public PlotModel _PlotModel { get; set; }
        public Plots()
        {
            var xAxis = new LinearAxis()
            {
                Position = AxisPosition.Bottom,
                Minimum = -2 * Math.PI,
                Maximum = 2 * Math.PI,
                Title = "x",
                MajorGridlineStyle = LineStyle.Solid
            };
            var yAxis = new LinearAxis()
            {
                Position = AxisPosition.Left,
                Minimum = -1,
                Maximum = 1,
                Title = "y",
                MajorGridlineStyle = LineStyle.Solid
            };
            _PlotModel = new PlotModel();
            _PlotModel.Axes.Add(yAxis);
            _PlotModel.Axes.Add(xAxis);
        }
    }
}
