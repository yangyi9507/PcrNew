using ScottPlot;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PcrNew.Pages
{
    public partial class StartGraph : UIPage
    {
        public StartGraph()
        {
            InitializeComponent();
        }

        private void uiButton7_Click(object sender, EventArgs e)
        {

        }

        private void uiButton4_Click(object sender, EventArgs e)
        {

            //x轴是浓度   Y轴是CT数值
            //4,35   4.9,29.5     5,29.5   5.9,26.25  6,26.25   6.9,23.5   7,23.5


            formsPlot1.Plot.Clear();
            var plt = formsPlot1.Plot;
            // Create some linear but noisy data
            //double[] ys = DataGen.NoisyLinear(null, pointCount: 7, noise: 30);
            //double[] xs = DataGen.Consecutive(ys.Length);
            double[] ys = { 35, 29.5, 29.5, 26.25, 23.5, 23.5 };
            double[] xs = { 4, 4.9, 5, 5.9, 6, 7 };


            double x1 = xs[0];
            double x2 = xs[xs.Length - 1];

            // use the linear regression fitter to fit these data
            var model = new ScottPlot.Statistics.LinearRegressionLine(xs, ys);

            // plot the original data and add the regression line
            plt.Title("Linear Regression\n" +
                $"Y = {model.slope:0.0000}x + {model.offset:0.0} " +
                $"(R² = {model.rSquared:0.0000})");
            plt.AddScatter(xs, ys, lineWidth: 0);
            //plt.AddLine(model.slope, model.offset, (x1, x2), lineWidth: 2);


            //缩放进行配置

            formsPlot1.Refresh();
        }

        private void uiButton6_Click(object sender, EventArgs e)
        {
            formsPlot1.Plot.Clear();
            var plt = formsPlot1.Plot;


            //double[] values = { 1.64, 1.18 , 0.4, -0.9, 1.35, -0.75,1.89,0.55 ,-0.15 ,1.95 ,1.5 ,-0.12 };

            //var bar = plt.AddBar(values);
            //bar.FillColor = Color.Green;
            //bar.FillColorNegative = Color.Red;
            //bar.BarWidth = 0.1;
            //double[] errors = { 0.1, 0.1, 0.1, 0.1, 0.1, 0.1, 0.1, 0.1, 0.1, 0.1, 0.1, 0.1 };
            //bar.ValueErrors = errors;
            //bar.ErrorCapSize = 0.1;

            Random rand = new Random(0);
            List<ScottPlot.Plottable.Bar> bars = new List<ScottPlot.Plottable.Bar>();
            for (int i = 0; i < 10; i++)
            {
                int value = rand.Next(-3, 3);
                ScottPlot.Plottable.Bar bar = new ScottPlot.Plottable.Bar()
                {
                    Value = value,
                    Position = i,
                    FillColor = ScottPlot.Palette.Category10.GetColor(i),
                    LineWidth = 1

                };
                bars.Add(bar);
            };
            plt.AddBarSeries(bars);


            double[] xs = bars.Select(x => x.Position).ToArray();
            double[] xErrs = bars.Select(x => (double)0).ToArray();
            double[] ys = bars.Select(x => x.Value).ToArray();
            double[] yErrs = bars.Select(x => (double)rand.Next(2, 20)).ToArray();
            var err = plt.AddErrorBars(xs, ys, xErrs, yErrs);
            err.LineWidth = 2;
            err.CapSize = 5;
            err.LineColor = Color.Black;

            plt.SetAxisLimitsY(-4, 4);

            //缩放进行配置

            formsPlot1.Refresh();
        }

        private void uiButton1_Click(object sender, EventArgs e)
        {

        }
    }
}
