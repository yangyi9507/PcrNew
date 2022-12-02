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
    public partial class RunStageSetupControl : UIPage
    {
        private UILineOption option;
        private UILineSeries series;
        private string ItemName = "";
        private int SteupID = 0;
        private int ID = 0; 


        public RunStageSetupControl()
        {
            InitializeComponent();

            //init();

            GetSteupMain();

            initaa();

            //GetSteupDetail();
            this.formsPlot1.RightClicked -= formsPlot1.DefaultRightClickEvent;
            this.formsPlot1.Configuration.RightClickDragZoom = false;
            this.formsPlot1.Configuration.ScrollWheelZoom = true;
            this.formsPlot1.Configuration.LockHorizontalAxis = true;
            this.formsPlot1.Configuration.LockVerticalAxis = true;
            this.formsPlot1.Click += FormsPlot1_Click;
        }

        private void FormsPlot1_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
        }

        private void initaa() 
        {
            formsPlot1.Plot.Clear();
            var plt = formsPlot1.Plot;
            plt.XAxis.Hide();
            BLL.TestSteup testSteup = new BLL.TestSteup();
            string strQueryaa = " ReportID = '" + TestItemFrmNew.ReportID + "'";
            //string strQueryaa = " ReportID = '20221114_092419'";
            DataTable dtlist = testSteup.GetList(strQueryaa).Tables[0];
            double[] values = new double[dtlist.Rows.Count + 1];
            for (int i = 0; i < dtlist.Rows.Count; i++)
            {
                if(i == dtlist.Rows.Count - 1)
                {
                    values[0] = 120;
                    for(int j = 0;j < dtlist.Rows.Count; j++)
                    {
                        if(j == dtlist.Rows.Count - 1)
                        {
                            values[j + 1] = 120;
                        }
                        else
                        {
                            if(dtlist.Rows[j]["SteupID"].ToString() == dtlist.Rows[j + 1]["SteupID"].ToString())
                            {
                                values[j + 1] = 100;
                            }
                            else
                            {
                                values[j + 1] = 120;
                            }
                        }
                    }
                    var lollipop = plt.AddLollipop(values);
                    lollipop.LollipopRadius = 10;
                    lollipop.BorderColor = Color.Green;//绿色
                    lollipop.LollipopColor = Color.Blue;//蓝色    
                }
                //double[] values = { 120, 120,120,100 ,120 };                    

                var bracketTop = plt.AddBracket(i, 1, i + 1, 1, "步骤：" + (i + 1).ToString());
                bracketTop.Color = Color.Blue;

                if (i == 0)
                {
                    var bracketCenterleft = plt.AddBracket(i, 18.0, i + 0.3, double.Parse(dtlist.Rows[i]["Temperature"].ToString()), "");
                    bracketCenterleft.Color = Color.Red;
                }
                else
                {
                    var bracketCenterleft = plt.AddBracket(i, double.Parse(dtlist.Rows[i - 1]["Temperature"].ToString()), i + 0.3, double.Parse(dtlist.Rows[i]["Temperature"].ToString()), "");
                    bracketCenterleft.Color = Color.Red;
                }


                if (dtlist.Rows[i]["CollectFlg"].ToString() == "1")
                {
                    var bracketCenter = plt.AddBracket(i + 0.3, double.Parse(dtlist.Rows[i]["Temperature"].ToString()), i + 1, double.Parse(dtlist.Rows[i]["Temperature"].ToString()), dtlist.Rows[i]["Temperature"].ToString() + "℃ " + dtlist.Rows[i]["SteupTime"].ToString());
                    bracketCenter.Color = Color.Blue;
                    bracketCenter.LineWidth = 5;
                }
                else
                {
                    var bracketCenter = plt.AddBracket(i + 0.3, double.Parse(dtlist.Rows[i]["Temperature"].ToString()), i + 1, double.Parse(dtlist.Rows[i]["Temperature"].ToString()), dtlist.Rows[i]["Temperature"].ToString() + "℃ " + dtlist.Rows[i]["SteupTime"].ToString());
                    bracketCenter.Color = Color.Red;
                    bracketCenter.LineWidth = 5;
                }


                var bracketMix = plt.AddBracket(i, -10, i + 1, -10, "下限");
                bracketMix.Color = Color.Blue;
                if(i == dtlist.Rows.Count - 1)
                {
                    var bracketMaxu = plt.AddBracket(0, 100, dtlist.Rows.Count, 100, "上限");
                    bracketMaxu.Color = Color.Blue;
                }
            }

          

            for (int i = 0;i < dtlist.Rows.Count; i++)
            {
                int from_dplyr = dtlist.Select("SteupID = " + dtlist.Rows[i]["SteupID"].ToString() + "and SteupFlg = " + dtlist.Rows[i]["SteupFlg"].ToString(), "SteupID desc").Length;
                if (from_dplyr > 1)//当前程序段的步数是否大于1
                {
                    if (dtlist.Rows[i]["SteupFlg"].ToString() == "1")
                    {
                        var bracketMax = plt.AddBracket(i, 120, i + from_dplyr, 120, "循环段 循环：" + double.Parse(dtlist.Rows[i]["Circle"].ToString()));
                        bracketMax.Color = Color.Blue;
                    }
                    else
                    {
                        var bracketMax = plt.AddBracket(i, 120, i + from_dplyr, 120, dtlist.Rows[i]["SteupName"].ToString());
                        bracketMax.Color = Color.Blue;
                    }
                    i += from_dplyr - 1;
                }
                else
                {
                    if (dtlist.Rows[i]["SteupFlg"].ToString() == "1")
                    {
                        var bracketMax = plt.AddBracket(i, 120, i + 1, 120, "循环段 循环：" + double.Parse(dtlist.Rows[i]["Circle"].ToString()));
                        bracketMax.Color = Color.Blue;
                    }
                    else
                    {
                        var bracketMax = plt.AddBracket(i, 120, i + 1, 120, dtlist.Rows[i]["SteupName"].ToString());
                        bracketMax.Color = Color.Blue;
                    }
                }
            }


            //缩放进行配置
            formsPlot1.Refresh();
        }

        private void GetSteupMain() 
        {
            BLL.TestSteup testSteup = new BLL.TestSteup();
            string strQuery = " ReportID = '" + TestItemFrmNew.ReportID + "'"; 
            //string strQuery = " ReportID = '20221114_092419'";
            DataTable dt =  testSteup.GetListByReportID(strQuery).Tables[0];
            if (dt != null )
            {
                dataGridView1.DataSource = dt;                
                dataGridView1.Columns[0].HeaderText = "步骤ID";
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[1].HeaderText = "阶段";

            }

            initaa();
        }

        private void init() 
        {
            // 配置LineChart
            option = new UILineOption();
            option.ToolTip.Visible = true;
            // 设置标题
            option.Title = new UITitle();
            option.Title.Text = "";
            option.Title.SubText = "";

            // 横坐标数据类型
            option.XAxisType = UIAxisType.Value;

            //Y数轴范围网格递增数
            option.YAxis.SetRange(0, 120);
            option.XAxis.SetRange(0, 36);

            //不显示网格线
            option.XAxis.ShowGridLine = false;
            option.YAxis.ShowGridLine = false;
            //X轴坐标不显示
            option.XAxis.AxisLabel.Show = false;

            #region 开始描点
            for (int i = 0; i < 2; i++)
            {

                series = option.AddSeries(new UILineSeries("步骤" + (i + 1).ToString(), Color.Blue));
                series.Add(0, 0);
                series.Add(1, 0);
                series.Symbol = UILinePointSymbol.None;
                series.SymbolSize = 10;
                series.SymbolLineWidth = 10;
                series.SymbolColor = Color.Blue;
                series.ShowLine = true;
                //数据点显示小数位数
                series.YAxisDecimalPlaces = 2;



                series = option.AddSeries(new UILineSeries("温度", Color.Red));
                series.Add(0, 37);
                series.Add(1, 37);
                series.Symbol = UILinePointSymbol.None;
                series.SymbolSize = 10;
                series.SymbolLineWidth = 10;
                series.ShowLine = true;

                series = option.AddSeries(new UILineSeries("恒温 循环数1", Color.Blue));
                series.Add(0, 100);
                series.Add(1, 100);
                series.Symbol = UILinePointSymbol.None;
                series.SymbolSize = 10;
                series.SymbolLineWidth = 10;
                series.ShowLine = true;
                option.XAxisScaleLines.Add(new UIScaleLine() { Color = Color.Blue, Name = "", Value = 1 });
                // 点的图标
                series.Symbol = UILinePointSymbol.Star;
                // 图标大小
                series.SymbolSize = 4;
                // 折线宽度
                series.SymbolLineWidth = 2;
                // 折线颜色
                series.SymbolColor = Color.Red;
                // 平滑曲线
                series.Smooth = true;

            }
            #endregion 

            // 设置系列1
            //series = option.AddSeries(new UILineSeries("Line1"));
            //float[] x = { 1, 2, 3, 4, 5, 6, 7 };
            //float[] y = { 2, 4, 6, 8, 10, 12, 14 };
            //for (int i = 0; i < x.Length; i++)
            //{
            //    series.Add(x[i], y[i]);
            //}
            //// 点的图标
            //series.Symbol = UILinePointSymbol.Square;
            //// 图标大小
            //series.SymbolSize = 4;
            //// 折线宽度
            //series.SymbolLineWidth = 2;
            //// 图标颜色
            //series.SymbolColor = Color.Red;


            //// 设置系列2
            //series = option.AddSeries(new UILineSeries("Line2", Color.Lime));

            //float[] x2 = { 1, 2, 3, 4, 5, 6, 7 };
            //float[] y2 = { 3, 6, 9, 12, 15, 18, 21 };
            //for (int i = 0; i < x.Length; i++)
            //{
            //    series.Add(x2[i], y2[i]);
            //}


            //// 设置纵坐标上限红线
            //option.GreaterWarningArea = new UILineWarningArea(3.5);
            //// 设置纵坐标下线黄线
            //option.LessWarningArea = new UILineWarningArea(2.2, Color.Gold);
            //option.YAxisScaleLines.Add(new UIScaleLine() { Color = Color.Red, Name = "上限", Value = 3.5 });
            //option.YAxisScaleLines.Add(new UIScaleLine() { Color = Color.Gold, Name = "下限", Value = 2.2 });

            // 横坐标名称
            //option.XAxis.Name = "事件";
            // 纵坐标名称
            //option.YAxis.Name = "数值";
            //option.XAxis.AxisLabel.DateTimeFormat = DateTimeEx.DateTimeFormat;
            //// 设置竖向的红线
            //option.XAxisScaleLines.Add(new UIScaleLine() { Color = Color.Red, Name = "x上界", Value = 50 });
            //option.XAxisScaleLines.Add(new UIScaleLine() { Color = Color.Red, Name = "x下界", Value = -50 });
            // 更新配置
            LineChart.SetOption(option);
        }

        private void uiSymbolButton1_Click(object sender, EventArgs e)
        {
            timer1.Stop();            

            UILineOption option = new UILineOption();
            option.ToolTip.Visible = true;
            option.Title = new UITitle();
            option.Title.Text = "";
            option.Title.SubText = "";
            option.ShowZeroLine = false;
            option.XAxis.AxisLabel.Show = false;

            option.XAxisType = UIAxisType.Value;
            //Y数轴范围网格递增数
            option.YAxis.SetRange(0,120);            
            option.XAxis.SetRange(0, 36);

            //option.YAxisScaleLines.Add(new UIScaleLine() { Color = Color.Red, Name = "上限", Value = 100 });

            //不显示网格线
            option.XAxis.ShowGridLine = false;
            option.YAxis.ShowGridLine = false;
            //X轴坐标不显示
            option.XAxis.AxisLabel.Show = false;

            var series = option.AddSeries(new UILineSeries("步骤1"));
            series.Add(0, 0);
            series.Add(1, 0);
            series.Symbol = UILinePointSymbol.None;
            series.SymbolSize = 10;
            series.SymbolLineWidth = 10;
            series.SymbolColor = Color.Red;
            series.ShowLine = true;
            //数据点显示小数位数
            series.YAxisDecimalPlaces = 2;            

            series = option.AddSeries(new UILineSeries("恒温 循环数1", Color.Blue));
            series.Add(0, 100);
            series.Add(1, 100);
            series.Symbol = UILinePointSymbol.None;
            series.SymbolSize = 10;
            series.SymbolLineWidth = 10;
            series.ShowLine = true;            

            option.XAxisScaleLines.Add(new UIScaleLine() { Color = Color.Blue, Name = "", Value = 1 });



            LineChart.SetOption(option);
        }

        private void LineChart_PointValue(object sender, UILineSelectPoint[] points)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var point in points)
            {
                sb.Append(point.Series.Name + ", " + point.Index + ", " + point.X + ", " + point.Y);
            }

            Console.WriteLine(sb.ToString());
        }

        private void uiSymbolButton2_Click(object sender, EventArgs e)
        {
            index = 0;
            UILineOption option = new UILineOption();
            option.ToolTip.Visible = true;
            option.Title = new UITitle();
            option.Title.Text = "SunnyUI";
            option.Title.SubText = "LineChart";
            var series = option.AddSeries(new UILineSeries("Line1"));

            //坐标轴显示小数位数
            option.XAxis.AxisLabel.DecimalPlaces = 1;
            option.YAxis.AxisLabel.DecimalPlaces = 1;
            LineChart.SetOption(option);
            timer1.Start();
        }

        int index = 0;
        Random random = new Random();

        private void timer1_Tick(object sender, EventArgs e)
        {
            LineChart.Option.AddData("Line1", index, random.NextDouble() * 10);
            index++;

            if (index > 50)
            {
                LineChart.Option.XAxis.SetRange(index - 50, index + 20);
            }

            LineChart.Refresh();
        }

        private void uiSymbolButton3_Click_1(object sender, EventArgs e)
        {
            timer1.Stop();

            UILineOption option = new UILineOption();
            option.ToolTip.Visible = true;
            option.Title = new UITitle();
            option.Title.Text = "";
            option.Title.SubText = "";

            var series = option.AddSeries(new UILineSeries("Line1"));
            series.Add(0, 1.2);
            series.Add(1, 2.2);
            series.Add(2, 3.2);
            series.Add(3, 4.2);
            series.Add(4, 3.2);
            series.Add(5, 2.2);
            series.Symbol = UILinePointSymbol.Square;
            series.SymbolSize = 4;
            series.SymbolLineWidth = 2;
            series.SymbolColor = Color.Red;

            series = option.AddSeries(new UILineSeries("Line2", Color.Lime, true));
            series.Add(3, 13.3);
            series.Add(4, 12.3);
            series.Add(5, 12.3);
            series.Add(6, 11.3);
            series.Add(7, 12.3);
            series.Add(8, 14.3);
            series.Symbol = UILinePointSymbol.Star;
            series.SymbolSize = 4;
            series.SymbolLineWidth = 2;

            option.XAxis.Name = "日期";
            option.YAxis.Name = "数值";
            option.Y2Axis.Name = "数值";

            option.YAxisScaleLines.Add(new UIScaleLine() { Color = Color.Red, Name = "上限", Value = 3.5 });
            option.Y2AxisScaleLines.Add(new UIScaleLine() { Color = Color.Gold, Name = "下限", Value = 12, DashDot = true });

            option.XAxisScaleLines.Add(new UIScaleLine() { Color = Color.Lime, Name = "3", Value = 3 });
            option.XAxisScaleLines.Add(new UIScaleLine() { Color = Color.Gold, Name = "6", Value = 6 });

            //设置坐标轴为自定义标签
            option.XAxis.CustomLabels = new CustomLabels(1, 1, 11);
            for (int i = 1; i <= 12; i++)
            {
                option.XAxis.CustomLabels.AddLabel(i + "月");
            }

            LineChart.SetOption(option);
        }
        #region 左键菜单
        private void uiButton1_Click(object sender, EventArgs e)
        {
            uiButton1.ShowContextMenuStrip(uiContextMenuStrip1, 0, uiButton2.Height);
        }
        #endregion

        #region 点击恒温增加恒温数据
        private void Thermostat_Click(object sender, EventArgs e)
        {
            BLL.TestSteup SteupBLL = new BLL.TestSteup();
            Model.TestSteup SteupModel = new Model.TestSteup();
            
            SteupModel.SteupID = SteupBLL.GetMaxId() ;
            SteupModel.ReportID = TestItemFrmNew.ReportID;
            SteupModel.SteupName = "恒温段";
            SteupModel.Temperature = "95";
            SteupModel.SteupTime = "00:03:00";//三分钟
            SteupModel.TouchDown = "0";
            SteupModel.TestSpeed = "2.5";
            SteupModel.CollectFlg = 0;
            SteupModel.SteupFlg = 0;
            SteupBLL.Add(SteupModel);

            GetSteupMain();
        }
        #endregion

        #region 点击循环增加循环数据
        private void Circulate_Click(object sender, EventArgs e)
        {
            BLL.TestSteup SteupBLL = new BLL.TestSteup();
            Model.TestSteup SteupModel = new Model.TestSteup();
            int steupID = SteupBLL.GetMaxId();
            SteupModel.SteupID = steupID;
            SteupModel.ReportID = TestItemFrmNew.ReportID;
            SteupModel.SteupName = "循环段";
            SteupModel.Temperature = "95";
            SteupModel.SteupTime = "00:00:10";//10秒
            SteupModel.TouchDown = "0";
            SteupModel.TestSpeed = "2.5";
            SteupModel.CollectFlg = 0;//信号采集 0:否；1：是
            SteupModel.SteupFlg = 1;
            SteupModel.Circle = 40;
            SteupBLL.Add(SteupModel);

            SteupModel.ReportID = TestItemFrmNew.ReportID;
            SteupModel.SteupID = steupID;
            SteupModel.SteupName = "循环段";
            SteupModel.Temperature = "60";
            SteupModel.SteupTime = "00:00:30";//30秒
            SteupModel.TouchDown = "0";
            SteupModel.TestSpeed = "2.5";
            SteupModel.CollectFlg = 1;//信号采集 0:否；1：是
            SteupModel.SteupFlg = 1;
            SteupModel.Circle = 40;
            SteupBLL.Add(SteupModel);

            GetSteupMain();
        }
        #endregion

        #region 删除对应的阶段
        private void uiSymbolButton4_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.SelectionMode != DataGridViewSelectionMode.FullColumnSelect && dataGridView1.CurrentRow != null)
            {
                BLL.TestSteup testSteup = new BLL.TestSteup();
                int index = dataGridView1.CurrentRow.Index; //获取选中行的行号
                SteupID = int.Parse(dataGridView1.Rows[index].Cells[0].Value.ToString());//后期用来做更新判断
                testSteup.DeleteBySteupID(SteupID);
                GetSteupMain();
            }
        }
        #endregion

        #region 删除对应的步骤
        private void uiSymbolButton5_Click(object sender, EventArgs e)
        {
            if (this.uiDataGridView1.SelectionMode != DataGridViewSelectionMode.FullColumnSelect && uiDataGridView1.CurrentRow != null)
            {
                BLL.TestSteup testSteup = new BLL.TestSteup();
                int index = uiDataGridView1.CurrentRow.Index; //获取选中行的行号
                int ID = int.Parse(uiDataGridView1.Rows[index].Cells[0].Value.ToString());//后期用来做更新判断
                testSteup.Delete(ID);
                GetSteupMain();
            }

        }
        #endregion
        #region 选中后展示具体的明细内容
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (this.dataGridView1.SelectionMode != DataGridViewSelectionMode.FullColumnSelect && dataGridView1.CurrentRow != null) 
            {
                BLL.TestSteup testSteup = new BLL.TestSteup();
                int index = dataGridView1.CurrentRow.Index; //获取选中行的行号
                SteupID = int.Parse(dataGridView1.Rows[index].Cells[0].Value.ToString());//后期用来做更新判断
                string strQuery = " SteupID  = " + SteupID + "";
                DataTable dt = testSteup.GetListBySteupID(strQuery).Tables[0];
                if (dt != null)
                {
                    uiDataGridView1.DataSource = dt;
                    uiDataGridView1.Columns[0].HeaderText = "ID";
                    uiDataGridView1.Columns[0].Visible = false;
                    uiDataGridView1.Columns[1].HeaderText = "SteupName";
                    uiDataGridView1.Columns[1].Visible = false;                    
                    uiDataGridView1.Columns[2].HeaderText = "温度(C)";
                    uiDataGridView1.Columns[3].HeaderText = "时间(H:M:S)";
                    uiDataGridView1.Columns[4].HeaderText = "TouchDown(C)";
                    uiDataGridView1.Columns[5].HeaderText = "速率(C/s)";
                    uiDataGridView1.Columns[6].HeaderText = "信号采集";
                    uiDataGridView1.Columns[7].HeaderText = "阶段标记";
                    uiDataGridView1.Columns[7].Visible = false;
                    uiDataGridView1.Columns[8].HeaderText = "循环次数";
                    uiDataGridView1.Columns[8].Visible = false;
                }
            }
        }
        #endregion
        #region 添加对应的步骤信息
        private void uiButton2_Click(object sender, EventArgs e)
        {

            if (this.dataGridView1.SelectionMode != DataGridViewSelectionMode.FullColumnSelect && dataGridView1.CurrentRow != null)
            {
                BLL.TestSteup testSteup = new BLL.TestSteup();
                int index = dataGridView1.CurrentRow.Index; //获取选中行的行号
                SteupID = int.Parse(dataGridView1.Rows[index].Cells[0].Value.ToString());//后期用来做更新判断
                BLL.TestSteup SteupBLL = new BLL.TestSteup();
                Model.TestSteup SteupModel = new Model.TestSteup();

                SteupModel.ReportID = TestItemFrmNew.ReportID;
                SteupModel.SteupID = SteupID;
                SteupModel.SteupName = "循环段";
                SteupModel.Temperature = "55";
                SteupModel.SteupTime = "00:00:30";//30秒
                SteupModel.TouchDown = "0";
                SteupModel.TestSpeed = "2.5";
                SteupModel.CollectFlg = 1;//信号采集 0:否；1：是
                SteupModel.SteupFlg = 1;
                SteupBLL.Add(SteupModel);

                GetSteupMain();
            }

        }
        #endregion
        #region 明细表信息内容 展示
        private void uiDataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (this.uiDataGridView1.SelectionMode != DataGridViewSelectionMode.FullColumnSelect && uiDataGridView1.CurrentRow != null)
            {
                int index = uiDataGridView1.CurrentRow.Index; //获取选中行的行号
                //阶段名称  
                ID = int.Parse(uiDataGridView1.Rows[index].Cells[0].Value.ToString());
                ItemName = uiDataGridView1.Rows[index].Cells[1].Value.ToString();
                //uiTextBox5.Text = uiDataGridView1.Rows[index].Cells[1].Value.ToString();
                uiDoubleUpDown1.Value = double.Parse(uiDataGridView1.Rows[index].Cells[2].Value.ToString());

                uiTimePicker1.Text = uiDataGridView1.Rows[index].Cells[3].Value.ToString();
                uiDoubleUpDown2.Value = double.Parse(uiDataGridView1.Rows[index].Cells[4].Value.ToString());
                uiDoubleUpDown3.Value = double.Parse(uiDataGridView1.Rows[index].Cells[5].Value.ToString());
                if(uiDataGridView1.Rows[index].Cells["SteupFlg"].Value.ToString() == "1")
                {
                    uiIntegerUpDown2.Value = (int)uiDataGridView1.Rows[index].Cells[8].Value;
                }
                else
                {
                    uiIntegerUpDown2.Value = 1;
                }
                if (uiDataGridView1.Rows[index].Cells[6].Value.ToString() == "是")
                {
                    uiCheckBox1.Checked = true;
                    if(uiDataGridView1.Rows[index].Cells["SteupFlg"].Value.ToString() == "2")
                    {
                        uiCheckBox1.Enabled = false;
                    }
                }
                else { uiCheckBox1.Checked = false; }
            }


        }
        #endregion
        #region 更新数据
        private void uiButton3_Click(object sender, EventArgs e)
        {
            BLL.TestSteup SteupBll = new BLL.TestSteup();
            Model.TestSteup SteupModel = new Model.TestSteup();
          
            SteupModel.Temperature = uiDoubleUpDown1.Value.ToString();
            SteupModel.SteupTime = uiTimePicker1.Value.TimeOfDay.ToString();
            SteupModel.TouchDown = uiDoubleUpDown2.Value.ToString();
            SteupModel.TestSpeed = uiDoubleUpDown3.Value.ToString();
            SteupModel.CollectFlg = uiCheckBox1.Checked == true ? 1 : 0;
            SteupBll.Update(ID,SteupModel);

            if (ItemName == "循环段")
            {
               
                int index = uiDataGridView1.RowCount; //获取总的行号

                for(int i = 0;i < index; i++)
                {
                    BLL.TestSteup SteupBll2 = new BLL.TestSteup();
                    Model.TestSteup SteupModel2 = new Model.TestSteup();
                    int u = (int)uiDataGridView1.Rows[i].Cells[0].Value;
                    SteupBll.UpdateCircle(u, uiIntegerUpDown2.Value);

                }

                //同一循环里面的循环数也要改变
                SteupModel.Circle = uiIntegerUpDown2.Value;
             

            }

            GetSteupMain();
        }
        #endregion

        private void uiButton4_Click(object sender, EventArgs e)
        {
            initaa();
        }

        private void ToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            BLL.TestSteup SteupBLL = new BLL.TestSteup();
            Model.TestSteup SteupModel = new Model.TestSteup();
            int steupID = SteupBLL.GetMaxId();
            SteupModel.SteupID = steupID;
            SteupModel.ReportID = TestItemFrmNew.ReportID;
            SteupModel.SteupName = "熔解段";
            SteupModel.Temperature = "95";
            SteupModel.SteupTime = "00:00:15";//15秒
            SteupModel.TouchDown = "0";
            SteupModel.TestSpeed = "4";
            SteupModel.CollectFlg = 0;//信号采集 0:否；1：是
            SteupModel.SteupFlg = 2;
            SteupBLL.Add(SteupModel);

            SteupModel.ReportID = TestItemFrmNew.ReportID;
            SteupModel.SteupID = steupID;
            SteupModel.SteupName = "熔解段";
            SteupModel.Temperature = "60";
            SteupModel.SteupTime = "00:01:00";//1分钟
            SteupModel.TouchDown = "0";
            SteupModel.TestSpeed = "4";
            SteupModel.CollectFlg = 0;//信号采集 0:否；1：是
            SteupModel.SteupFlg = 2;
            SteupBLL.Add(SteupModel);

            SteupModel.ReportID = TestItemFrmNew.ReportID;
            SteupModel.SteupID = steupID;
            SteupModel.SteupName = "熔解段";
            SteupModel.Temperature = "95";
            SteupModel.SteupTime = "00:00:15";//15秒
            SteupModel.TouchDown = "0";
            SteupModel.TestSpeed = "4";
            SteupModel.CollectFlg = 1;//信号采集 0:否；1：是
            SteupModel.SteupFlg = 2;
            SteupBLL.Add(SteupModel);

            GetSteupMain();
        }
    }
}
