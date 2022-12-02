﻿using Sunny.UI;
using System;

namespace PcrNew
{
    public partial class FDoughnutChart : UIPage
    {
        public FDoughnutChart()
        {
            InitializeComponent();
        }

        private void uiSymbolButton1_Click(object sender, System.EventArgs e)
        {
            var option = new UIDoughnutOption();

            //设置Title
            option.Title = new UITitle();
            option.Title.Text = "SunnyUI";
            option.Title.SubText = "Star";
            option.Title.Left = UILeftAlignment.Center;

            //设置ToolTip
            option.ToolTip.Visible = true;

            //设置Legend
            option.Legend = new UILegend();
            option.Legend.Orient = UIOrient.Vertical;
            option.Legend.Top = UITopAlignment.Top;
            option.Legend.Left = UILeftAlignment.Left;

            option.Legend.AddData("2020-05-19");
            option.Legend.AddData("2020-05-20");
            option.Legend.AddData("2020-05-21");
            option.Legend.AddData("2020-05-22");
            option.Legend.AddData("2020-05-23");
            option.Legend.AddData("2020-05-24");
            option.Legend.AddData("2020-05-25");

            //设置Series
            var series = new UIDoughnutSeries();
            series.Name = "StarCount";
            series.Center = new UICenter(50, 55);
            series.Radius.Inner = 40;
            series.Radius.Outer = 70;
            series.Label.Show = true;
            series.Label.Position = UIPieSeriesLabelPosition.Center;

            //增加数据
            series.AddData("2020-05-19", 38);
            series.AddData("2020-05-20", 21);
            series.AddData("2020-05-21", 11);
            series.AddData("2020-05-22", 52);
            series.AddData("2020-05-23", 23);
            series.AddData("2020-05-24", 26);
            series.AddData("2020-05-25", 27);

            //增加Series
            option.Series.Clear();
            option.Series.Add(series);

            //显示数据小数位数
            option.DecimalPlaces = 1;

            //设置Option
            DoughnutChart.SetOption(option);
            uiSymbolButton2.Enabled = true;
        }

        private void uiImageButton1_Click(object sender, System.EventArgs e)
        {
            DoughnutChart.ChartStyleType = UIChartStyleType.Default;
        }

        private void uiImageButton2_Click(object sender, System.EventArgs e)
        {
            DoughnutChart.ChartStyleType = UIChartStyleType.Plain;
        }

        private void uiImageButton3_Click(object sender, System.EventArgs e)
        {
            DoughnutChart.ChartStyleType = UIChartStyleType.Dark;
        }

        private void uiSymbolButton2_Click(object sender, System.EventArgs e)
        {
            Random random = new Random(DateTime.Now.Millisecond);
            DoughnutChart.Update("StarCount", "2020-05-19", random.Next(50));
            DoughnutChart.Update("StarCount", "2020-05-20", random.Next(50));
            DoughnutChart.Update("StarCount", "2020-05-21", random.Next(50));
            DoughnutChart.Update("StarCount", "2020-05-22", random.Next(50));
            DoughnutChart.Update("StarCount", "2020-05-23", random.Next(50));
            DoughnutChart.Update("StarCount", "2020-05-24", random.Next(50));
            DoughnutChart.Update("StarCount", "2020-05-25", random.Next(50));

            DoughnutChart.Refresh();
        }
    }
}