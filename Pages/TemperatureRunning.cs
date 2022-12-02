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
    public partial class TemperatureRunning : UIForm
    {
        public TemperatureRunning()
        {
            InitializeComponent();
            uiLineChart1.Option.Clear();
        }

        private void formsPlot1_Click(object sender, EventArgs e)
        {

        }

        private void formsPlot1_Load(object sender, EventArgs e)
        {

        }

        private void uiLineChart1_Click(object sender, EventArgs e)
        {
            ResetData();
        }

        [Description("生成数据")]
        private void ResetData()
        {
            uiLineChart1.Option.Clear();
            int[] x = new int[] {0, 10,15,20,25,30,40,60 };
            int[] y = new int[] {10,20,30,40,50,50,60,80 };
            var pointX = new List<double>();
            var pointY = new List<double>();
            for (int j = 0; j < x.Length; j++)
            {
                pointX.Add(x[j]);
                pointY.Add(y[j]);
            }
            AddChartData($"线条：{1}", pointX.ToArray(), pointY.ToArray());
            SetChartLineStyle();
        }

        /// <summary>
        /// 向图标添加数据
        /// </summary>
        /// <param name="name">线条名称</param>
        /// <param name="arrx">横轴数据</param>
        /// <param name="arry">纵轴数据</param>
        private void AddChartData(string name, double[] arrx, double[] arry)
        {
            var line = new UILineSeries(name);
            line.XData.AddRange(arrx);
            line.YData.AddRange(arry);
            uiLineChart1.Option.AddSeries(line);
        }

        [Description("设置ChartLineStyle")]
        private void SetChartLineStyle()
        {
            /**
             *    添加数据
             *    var line = new UILineSeries(name);
             *    line.XData.AddRange(arrx);//double[]
                  line.YData.AddRange(arry);//double[]
             *    uiLineChart1.Option.AddSeries(line);
             */

            uiLineChart1.Option.ShowZeroLine = false;
            uiLineChart1.Option.ShowZeroValue = false;
            uiLineChart1.Option.XAxis.Clear();

            var uiTitle = new UITitle { Text = "图表一", SubText = "温度曲线" };
            uiLineChart1.Option.Title = uiTitle;//设置图表名称

            uiLineChart1.Option.XAxis.Name = "时间";//横轴名称
            uiLineChart1.Option.YAxis.Name = "温度";//纵轴名称
            //uiLineChart1.Option.Y2Axis.Name = "金钱2";//纵轴名称

            uiLineChart1.Option.XAxis.ShowGridLine = true;//横轴网格线
            uiLineChart1.Option.YAxis.ShowGridLine = true;//纵轴网格线


            //uiLineChart1.Option.XAxisType = UIAxisType.Value;//横轴类型
            //uiLineChart1.Option.XAxis.SetRange(DateTime.Now, DateTime.Now.AddMinutes(10));//设置横轴时间范围
            uiLineChart1.Option.XAxisType = UIAxisType.Value;//横轴类型

            float xMin, xMax, yMin, yMax;
            GetAxisRange(true, out xMin, out xMax);
            GetAxisRange(false, out yMin, out yMax);
            uiLineChart1.Option.XAxis.SetRange(xMin, xMax);//设置横轴范围（1.类型为时间时需要设置时间范围；2.可通过改属性重置图表显示）
            uiLineChart1.Option.YAxis.SetRange(yMin, yMax);//设置横轴范围（1.类型为时间时需要设置时间范围；2.可通过改属性重置图表显示）

            uiLineChart1.Refresh();

        }

        /// <summary>
        /// 获取轴系范围
        /// </summary>
        /// <param name="isXAxis">是否为X轴</param>
        /// <param name="min">最大值</param>
        /// <param name="max">最小值</param>
        private void GetAxisRange(bool isXAxis, out float min, out float max)
        {
            min = isXAxis ? 0 : -10;
            max = isXAxis ? 100 : 10;
            if (uiLineChart1.Option.Series.Count < 1) return;

            var name = uiLineChart1.Option.Series.ElementAt(0).Key;
            double tempMin, tempMax;
            if (isXAxis)
            {
                tempMin = uiLineChart1.Option.Series[name].XData.Min();
                tempMax = uiLineChart1.Option.Series[name].XData.Max();
                for (int i = 1; i < uiLineChart1.Option.Series.Count; i++)
                {
                    name = uiLineChart1.Option.Series.ElementAt(i).Key;
                    tempMin = Math.Min(uiLineChart1.Option.Series[name].XData.Min(), tempMin);
                    tempMax = Math.Max(uiLineChart1.Option.Series[name].XData.Max(), tempMax);
                }
            }
            else
            {
                tempMin = uiLineChart1.Option.Series[name].YData.Min();
                tempMax = uiLineChart1.Option.Series[name].YData.Max();
                for (int i = 1; i < uiLineChart1.Option.Series.Count; i++)
                {
                    name = uiLineChart1.Option.Series.ElementAt(i).Key;
                    tempMin = Math.Min(uiLineChart1.Option.Series[name].YData.Min(), tempMin);
                    tempMax = Math.Max(uiLineChart1.Option.Series[name].YData.Max(), tempMax);
                }
                double dReservedValue = (tempMax - tempMin) * 0.2;//上下预留1/5
                tempMin -= dReservedValue;
                tempMax += dReservedValue;
            }
            min = (float)tempMin;
            max = (float)tempMax;
        }





    }
}
