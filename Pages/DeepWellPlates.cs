using PcrNew.MoranControl;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAO = Microsoft.Office.Interop.Access.Dao;

namespace PcrNew.Pages
{
    public partial class DeepWellPlates : UIPage
    {

        public static string ReportID = "";
        /// <summary>
        /// 孔布局
        /// </summary>
        public MoranControl.PlateLayout Playout;
        /// <summary>
        /// 微孔板信息
        /// </summary>
        public MoranControl.MicroplateSeting MicSeting;
        /// <summary>
        /// 用于界面传值的自定义委托
        /// </summary>
        /// <param name="hd"></param>
        public delegate void BackHoleData(MoranControl.HoleData hd);
        /// <summary>
        /// 用于传值的事件，将右边栏添加的孔信息传递给微孔板
        /// </summary>
        public event BackHoleData BackHole;

        public delegate void RefreshDelegate(); // 窗口声明定义委托 refresh()
        public event RefreshDelegate refresh;

        int SampleID = 0;
        int ItemId = 0;
        public DeepWellPlates()
        {
            InitializeComponent();
        }      
        private void DeepWellPlates_Load(object sender, EventArgs e)
        {            
            //初始化获取项目
            GetItemDate();
            //初始化获取样本信息
            getSampleData();
            //事件的委托复制
            BackHole += new BackHoleData(uHoleDes_BackHole);

            MicSeting = new MoranControl.MicroplateSeting();
            MicSeting.BetweenDistance = 9;
            MicSeting.Bottom = 0;
            MicSeting.Cell_Height = 11.9;
            MicSeting.Cell_Radius = 6.3;
            MicSeting.CenterDistanceH = 9;
            MicSeting.CenterDistanceV = 9;
            MicSeting.DBID = Guid.NewGuid().ToString();
            MicSeting.Height = 300;
            MicSeting.HorizontalNum = 12;
            MicSeting.Index = 0;
            MicSeting.LeftPad = 5;
            MicSeting.Lenght = 100;
            MicSeting.Name = "AloneMic";
            MicSeting.PlateOrderType = MoranControl.OrderType.TDLR;
            MicSeting.SampleStartNum = 1;
            MicSeting.SampleUsedNum = 0;
            MicSeting.Span = 12;
            MicSeting.TopPad = 5;
            MicSeting.VerticalNum = 8;
            MicSeting.Width = 100;
            MicSeting.XNum = 12;
            MicSeting.YNum = 8;
            MicSeting.TestPlateNo = 1;
            if (MicSeting.MLayout == null)
            {
                MicSeting.MLayout = new MoranControl.PlateLayout();
                MicSeting.MLayout.InItDataSet();
            }
            Playout = MicSeting.MLayout;
            uMPlate.MicSeting = MicSeting;
            BLL.Sample SampleBLL = new BLL.Sample();  //声明对象
            SampleBLL.DelCheckAll();
        }

        private void GetDeepHole()
        {
            uiDataGridView2.ClearAll();

            BLL.Sample SampleBLL = new BLL.Sample();  //声明对象
            uiDataGridView2.DataSource = SampleBLL.GetDeepHoleData(TestItemFrmNew.ReportID).Tables[0];

            uiDataGridView2.Columns[0].HeaderText = "#";            
            uiDataGridView2.Columns[1].HeaderText = "孔位";            
            uiDataGridView2.Columns[2].HeaderText = "孔位坐标";
            uiDataGridView2.Columns[2].Visible = false;
            
            uiDataGridView2.Columns[3].HeaderText = "样本ID";
            uiDataGridView2.Columns[4].HeaderText = "样本名称";
            uiDataGridView2.Columns[5].HeaderText = "样本颜色";
            uiDataGridView2.Columns[5].Visible = false;
            uiDataGridView2.Columns[6].HeaderText = "ReportID";
            uiDataGridView2.Columns[6].Visible = false;
            uiDataGridView2.Columns[7].HeaderText = "检验项目";
            uiDataGridView2.Columns[8].HeaderText = "报告荧光";
            uiDataGridView2.Columns[9].HeaderText = "属性";
            uiDataGridView2.Columns[10].HeaderText = "浓度";
            uiDataGridView2.Columns[11].HeaderText = "浓度单位";
            uiDataGridView2.Columns[12].HeaderText = "计算浓度";


        }

        #region 根据报告单号获取项目信息
        public void GetItemDate()
        {
            dataGridView1.ClearAll();
            //TestItemFrmNew.ReportID
            BLL.ItemMain itemMain = new BLL.ItemMain();
            string str = " A.ReportID='" + TestItemFrmNew.ReportID + "'";

            dataGridView1.DataSource = itemMain.GetItem(str).Tables[0];//赋值

            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].HeaderText = "项目名称";
            dataGridView1.Columns[1].Visible = false;
            dataGridView1.Columns[2].HeaderText = "报告荧光";
            dataGridView1.Columns[2].Visible = false;
            dataGridView1.Columns[3].HeaderText = "检验项目";

            DataGridViewComboBoxColumn colShow = new DataGridViewComboBoxColumn();
            colShow.Name = "Attribute";
            colShow.HeaderText = "属性";
            colShow.Width = 200;
            colShow.Items.Add("U");
            colShow.Items.Add("S");
            colShow.Items.Add("N");
            colShow.Items.Add("P");
            colShow.DisplayIndex = 4;
            colShow.ReadOnly = true;
            dataGridView1.Columns.Insert(4, colShow);

            dataGridView1.AddColumn("浓度", "Density", 100, DataGridViewContentAlignment.MiddleCenter, true);
            //dataGridView1.AddColumn("浓度", "Density", 100, DataGridViewContentAlignment.MiddleCenter, false);
            dataGridView1.AddCheckBoxColumn("","",100,false);
        }
        #endregion

        #region 根据报告单号获取样本信息
        public void getSampleData()
        {
            uiDataGridView1.ClearAll();

            BLL.Sample SampleBLL = new BLL.Sample();  //声明对象
            uiDataGridView1.DataSource = null;
            uiDataGridView1.DataSource = SampleBLL.GetSampleFyb(TestItemFrmNew.ReportID).Tables[0];
            // DataTable dt1 = SampleBLL.GetSampleFyb(TestItemFrmNew.ReportID).Tables[0];
            //
            //uiDataGridView1.DataSource = dt1;
            if (uiDataGridView1.DataSource != null)
            {
                uiDataGridView1.Columns[0].HeaderText = "样本ID";
                uiDataGridView1.Columns[1].HeaderText = "SampleColor";
                uiDataGridView1.Columns[1].Visible = false;
                uiDataGridView1.Columns[2].HeaderText = "样本名称";
                uiDataGridView1.Columns[3].HeaderText = "采样时间";
                uiDataGridView1.Columns[4].HeaderText = "送检日期";
                uiDataGridView1.Columns[5].HeaderText = "id";
                uiDataGridView1.Columns[5].Visible = false;

                //DataTable dt = (DataTable)uiDataGridView1.DataSource;


                //dt.Columns.Add(new DataColumn() { ColumnName = "颜色", DataType = typeof(string) });

                //uiDataGridView1.DataSource = dt;

                uiDataGridView1.AddColumn("颜色", "", 100);

                for (int i = 0; i < uiDataGridView1.Rows.Count; i++)
                {
                    string strCol = uiDataGridView1.Rows[i].Cells[1].Value.ToString();
                    if (!String.IsNullOrEmpty(strCol))
                    {
                        Color c1 = System.Drawing.ColorTranslator.FromHtml(strCol);
                        uiDataGridView1.Rows[i].Cells[6].Value = "";
                        uiDataGridView1.Rows[i].Cells[6].Style.BackColor = c1;
                        uiDataGridView1.Rows[i].Cells[6].Style.SelectionBackColor = c1;
                    }

                }
            }
        }    
        #endregion

        private void dgPlate_MouseUp(object sender, MouseEventArgs e)
        {
            UIMessageTip.Show("aa");
        }

        private void uiButton5_Click(object sender, EventArgs e)
        {
            getSampleData();

        }
        #region 样本双击事件,给反应版增加颜色，并且插入到指定的数据库内
        private void uiDataGridView1_DoubleClick(object sender, EventArgs e)
        {
            //获取当前选中行的行号 以此来获取颜色
            if (this.uiDataGridView1.SelectionMode != DataGridViewSelectionMode.FullColumnSelect && uiDataGridView1.CurrentRow != null)
            {
                int index = uiDataGridView1.CurrentRow.Index; //获取选中行的行号
                string strColor = uiDataGridView1.Rows[index].Cells[1].Value.ToString();
                string strSampleID = uiDataGridView1.Rows[index].Cells[0].Value.ToString();
                string strName = uiDataGridView1.Rows[index].Cells[2].Value.ToString();
                HoleData hlData = new HoleData();

                hlData.ThisHoleType = HoleType.Sample;
                hlData.SampleID = strSampleID;
                hlData.SampleColor = strColor;
                hlData.SampleName = strName;
                BackHole(hlData);
            }
        }
        #endregion

        #region 添加右侧功能布局的相关代码。
        void uHoleDes_BackHole(HoleData hd)
        {
            if (uMPlate == null) return;
            for (int i = 0; i < uMPlate.dgPlate.SelectedCells.Count; i++)
            {
                HoleData cellHole = uMPlate.MicSeting.MLayout.getHoleData(uMPlate.dgPlate.SelectedCells[i].RowIndex, uMPlate.dgPlate.SelectedCells[i].ColumnIndex);
                cellHole.ThisHoleType = hd.ThisHoleType;
                cellHole.SampleColor = hd.SampleColor;
                cellHole.SampleID = hd.SampleID;

                //更新数据库样本信息
                String holeid = cellHole.X.ToString() + "," + cellHole.Y.ToString();
                BLL.SampleMain sampleBll = new BLL.SampleMain();
                PcrNew.Model.SampleMain SampleModel = new PcrNew.Model.SampleMain();

                SampleModel.HoleID = holeid;
                SampleModel.SampleID = hd.SampleID;
                SampleModel.SampleColor = hd.SampleColor;
                SampleModel.SampleName = hd.SampleName.ToString();
                SampleModel.ReportID = TestItemFrmNew.ReportID;
                SampleModel.TestItem = "";
                SampleModel.HightLight = "";
                SampleModel.Attribute = "";
                SampleModel.Density = "";
                SampleModel.DensityUnit = "";
                SampleModel.CalDensity = "";

                //根据报告单号和HoleID去查询数据  如果有就更新没有插入DataSet
                DataTable dt = sampleBll.ExistsByReportIDHoleID(TestItemFrmNew.ReportID, holeid);

                if (dt != null)
                {
                    if (!sampleBll.UpdateByID(SampleModel, int.Parse(dt.Rows[0]["ID"].ToString())))
                    {
                        UIMessageTip.Show(AppCode.INSERT_ERROR);
                    }
                }
                else
                {
                    if (!sampleBll.Add(SampleModel))
                    {
                        UIMessageTip.Show(AppCode.INSERT_ERROR);
                    }
                    else
                    {

                    }
                }

                //var t2 = Task.Run(() =>
                //{
                //    //根据报告单号和HoleID去查询数据  如果有就更新没有插入DataSet
                //    DataTable dt = sampleBll.ExistsByReportIDHoleID(TestItemFrmNew.ReportID, holeid);

                //    if (dt != null)
                //    {
                //        if (!sampleBll.UpdateByID(SampleModel, int.Parse(dt.Rows[0]["ID"].ToString())))
                //        {
                //            UIMessageTip.Show(AppCode.INSERT_ERROR);
                //        }
                //    }
                //    else {
                //        if (!sampleBll.Add(SampleModel))
                //        {
                //            UIMessageTip.Show(AppCode.INSERT_ERROR);
                //        }
                //        else {

                //        }
                //    }
                //});                

            }
            uMPlate.dgPlate.Refresh();
            GetDeepHole();
        }
        #endregion
        private void 清除样本设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HoleData hlData = new HoleData();

            hlData.ThisHoleType = HoleType.Sample;
            hlData.SampleID = "";
            hlData.SampleColor = "";
            hlData.SampleName = "";
            BackHole(hlData);
        }

        private void UITabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetDeepHole();
        }

        private void uiTitlePanel2_Click(object sender, EventArgs e)
        {

        }


        private void uiDataGridView1_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            for (int i = 0; i < uiDataGridView1.Rows.Count; i++)
            {
                string strCol = uiDataGridView1.Rows[i].Cells[1].Value.ToString();
                if (!String.IsNullOrEmpty(strCol))
                {
                    Color c1 = System.Drawing.ColorTranslator.FromHtml(strCol);
                    uiDataGridView1[6, i].Style.BackColor = c1;
                    uiDataGridView1[6, i].Style.SelectionBackColor = c1;
                }
            }
        }

        #region CheckBox点击事件，控制检测项目
        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1_CellContentClick(sender, e);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            switch (e.ColumnIndex)
            {
                case 2:
                    // 控制浓度框为不可使用
                    dataGridView1.Rows[e.RowIndex].Cells[1].ReadOnly = true;

                    // 获取选择行的检测项目
                    string checkItem = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();

                    // 判断选择行是检测项目还是检测项
                    if (checkItem.Contains("FAM"))
                    {
                        for (int i = 0; i < dataGridView1.Rows.Count; i++)
                        {
                            // 循环数据是被选中的数据
                            if (i == e.RowIndex)
                            {
                                // checkbox按下后是选择状态还是非选择状态
                                string checkFlg = dataGridView1.Rows[i].Cells[2].EditedFormattedValue.ToString();

                                // 选择状态的场合
                                if (checkFlg == "True")
                                {
                                    // 设置combox为可用状态
                                    dataGridView1.Rows[e.RowIndex].Cells[0].ReadOnly = false;

                                    // 反应板输出
                                    foreach (DataGridViewCell cell in uMPlate.dgPlate.SelectedCells)
                                    {
                                        HoleData hd = (HoleData)cell.Value;
                                        hd.ProName = hd.LiquidName = string.Empty;
                                        hd.ThisHoleType = HoleType.Sample;

                                        hd.ItemName = checkItem;
                                        hd.ItemAttribute = "未知";
                                        hd.ItemViscosity = null;
                                    }
                                    uMPlate.dgPlate.Invalidate();

                                    // 设置combox为未知
                                    dataGridView1.Rows[i].Cells[0].Value = "U";

                                    // 循环其他检测项目
                                    for (int j = 0; j < dataGridView1.Rows.Count; j++)
                                    {
                                        // 获取检测项目名
                                        string checkItemOther = dataGridView1.Rows[j].Cells[6].Value.ToString();

                                        // 设置其他检测项目的状态
                                        if (j != i && checkItemOther.Contains("FAM"))
                                        {
                                            dataGridView1.Rows[j].Cells[0].ReadOnly = true;
                                            dataGridView1.Rows[j].Cells[2].Value = false;
                                            dataGridView1.Rows[j].Cells[0].Value = "";
                                            dataGridView1.Rows[j].Cells[1].Value = "";
                                        }
                                    }
                                }
                                else
                                {
                                    // 取消反应板输出内容
                                    foreach (DataGridViewCell cell in uMPlate.dgPlate.SelectedCells)
                                    {
                                        HoleData hd = (HoleData)cell.Value;
                                        hd.ProName = hd.LiquidName = string.Empty;
                                        hd.ThisHoleType = HoleType.Null;
                                    }

                                    uMPlate.dgPlate.Invalidate();

                                    // 设置当前选择行属性，浓度
                                    dataGridView1.Rows[i].Cells[0].Value = "";
                                    dataGridView1.Rows[i].Cells[1].Value = "";
                                }
                            }
                        }
                    }
                    else
                    {
                        string checkBoxOther = dataGridView1.Rows[e.RowIndex].Cells[2].EditedFormattedValue.ToString();

                        // checkbox按下后是选择状态还是非选择状态
                        if (checkBoxOther == "True")
                        {
                            // 设置combox的状态
                            dataGridView1.Rows[e.RowIndex].Cells[0].ReadOnly = false;

                            // 输出反应板
                            foreach (DataGridViewCell cell in uMPlate.dgPlate.SelectedCells)
                            {
                                HoleData hd = (HoleData)cell.Value;
                                hd.ProName = hd.LiquidName = string.Empty;
                                hd.ThisHoleType = HoleType.Sample;

                                hd.ItemName = checkItem;
                                hd.ItemAttribute = "未知";
                                hd.ItemViscosity = null;
                            }
                            uMPlate.dgPlate.Invalidate();

                            // 属性
                            dataGridView1.Rows[e.RowIndex].Cells[0].Value = "U";
                        }
                        else
                        {
                            // 设置combox的状态
                            dataGridView1.Rows[e.RowIndex].Cells[0].ReadOnly = true;

                            // 取消反应板的输出
                            foreach (DataGridViewCell cell in uMPlate.dgPlate.SelectedCells)
                            {
                                HoleData hd = (HoleData)cell.Value;
                                hd.ProName = hd.LiquidName = string.Empty;
                                hd.ThisHoleType = HoleType.Null;
                            }
                            uMPlate.dgPlate.Invalidate();

                            // 属性
                            dataGridView1.Rows[e.RowIndex].Cells[0].Value = "";
                        }
                    }
                    Thread.Sleep(100);
                    break;
                default:
                    break;
            }
        }
        #endregion

        #region ComBox触发事件 更改属性值
        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;

            //判断相应的列
            if (dgv.CurrentCell.GetType().Name == "DataGridViewComboBoxCell" && dgv.CurrentCell.RowIndex != -1)
            {

                //给这个DataGridViewComboBoxCell加上下拉事件
                (e.Control as ComboBox).SelectedIndexChanged += new EventHandler(cb_SelectedIndexChanged);

            }
        }

        void cb_SelectedIndexChanged(object sender, EventArgs e)
        {

            ComboBox combox = sender as ComboBox;

            // 追加撤销事件，防止多次触发
            combox.Leave += new EventHandler(combox_Leave);
            try
            {
                // combox值发生变更的场合
                if (combox.SelectedItem != null)
                {
                    // 获取当前选择行
                    int row = this.dataGridView1.CurrentRow.Index;

                    // 获取选择行的检测项目
                    string checkItem = dataGridView1.Rows[row].Cells[6].Value.ToString();

                    // 获取重新选择后的combox的值
                    string comFlg = dataGridView1.Rows[row].Cells[0].EditedFormattedValue.ToString();

                    // 输出反应板
                    foreach (DataGridViewCell cell in uMPlate.dgPlate.SelectedCells)
                    {
                        HoleData hd = (HoleData)cell.Value;
                        hd.ProName = hd.LiquidName = string.Empty;
                        hd.ThisHoleType = HoleType.Sample;
                        hd.ItemName = checkItem;
                        if (comFlg == "U")
                        {
                            hd.ItemAttribute = "未知";
                            hd.ItemViscosity = null;
                            dataGridView1.Rows[row].Cells[1].Value = "";
                        }
                        else if (comFlg == "S")
                        {
                            dataGridView1.Rows[row].Cells[1].Value = "1.00e+01";
                            dataGridView1.Rows[row].Cells[1].ReadOnly = false;
                            hd.ItemAttribute = "标准";
                            hd.ItemViscosity = "1.00e+01";
                        }
                        else if (comFlg == "N")
                        {
                            hd.ItemAttribute = "阴性";
                            hd.ItemViscosity = null;
                            dataGridView1.Rows[row].Cells[1].Value = "";
                        }
                        else
                        {
                            hd.ItemAttribute = "阳性";
                            hd.ItemViscosity = null;
                            dataGridView1.Rows[row].Cells[1].Value = "";
                        }

                    }
                    uMPlate.dgPlate.Invalidate();
                }
                Thread.Sleep(100);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void combox_Leave(object sender, EventArgs e)
        {
            ComboBox combox = sender as ComboBox;
            //做完处理，须撤销动态事件
            combox.SelectedIndexChanged -= new EventHandler(cb_SelectedIndexChanged);
        }
        #endregion

        #region 浓度值发生变更后 输出反应板
        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            switch (e.ColumnIndex)
            {
                case 1:

                    // 获取当前选择行
                    int row = this.dataGridView1.CurrentRow.Index;

                    // 获取选择行的检测项目
                    string checkItem = dataGridView1.Rows[row].Cells[6].Value.ToString();

                    // 获取重新输出后的浓度的值
                    string viscosity = dataGridView1.Rows[row].Cells[1].EditedFormattedValue.ToString();

                    // 输出打印版
                    foreach (DataGridViewCell cell in uMPlate.dgPlate.SelectedCells)
                    {
                        HoleData hd = (HoleData)cell.Value;
                        hd.ProName = hd.LiquidName = string.Empty;
                        hd.ThisHoleType = HoleType.Sample;

                        hd.ItemName = checkItem;
                        hd.ItemAttribute = "标准";
                        hd.ItemViscosity = viscosity;

                    }
                    uMPlate.dgPlate.Invalidate();
                    break;
                default:
                    break;

            }
        }
        #endregion

        #region 鼠标点击时，进行数据库操作
        private void uMPlate_MouseUp(object sender, MouseEventArgs e)
        {
            // 鼠标左键点击的场合
            if (e.Button == MouseButtons.Left)
            {
                foreach (DataGridViewCell cell in uMPlate.dgPlate.SelectedCells)
                {
                    string rowCell = "";
                    // 获取当前选择位置的坐标
                    rowCell = cell.RowIndex.ToString() + "," + cell.ColumnIndex.ToString();
                    BLL.Sample SampleBLL = new BLL.Sample();  //声明对象

                    // 获取当前坐标下数据库存在的检测项目
                    DataTable dt1 = SampleBLL.GetCheckItem(rowCell).Tables[0];

                    // 初始化dataGridView1
                    for (int j = 0; j < dataGridView1.Rows.Count; j++)
                    {
                        dataGridView1.Rows[j].Cells[0].ReadOnly = true;
                        dataGridView1.Rows[j].Cells[2].Value = false;
                        dataGridView1.Rows[j].Cells[0].Value = "";
                        dataGridView1.Rows[j].Cells[1].Value = "";
                    }

                    // 数据库存在数据的场合
                    if (dt1.Rows.Count != 0)
                    {
                        for (int i = 0; i < dt1.Rows.Count; i++)
                        {
                            for (int j = 0; j < dataGridView1.Rows.Count; j++)
                            {
                                // 根据数据库的值设置dataGridView1的状态
                                if (dataGridView1.Rows[j].Cells[6].Value.ToString() == dt1.Rows[i][0].ToString())
                                {
                                    dataGridView1.Rows[j].Cells[0].ReadOnly = false;
                                    dataGridView1.Rows[j].Cells[2].Value = true;
                                    dataGridView1.Rows[j].Cells[0].Value = dt1.Rows[i][1].ToString();
                                    dataGridView1.Rows[j].Cells[1].Value = dt1.Rows[i][2].ToString();
                                }
                            }
                        }
                    }
                }
            }
        }

        private void uMPlate_MouseDown(object sender, MouseEventArgs e)
        {
            string rowCell = "";

            foreach (DataGridViewCell cell in uMPlate.dgPlate.SelectedCells)
            {
                // 获取当前选择位置的坐标
                rowCell = cell.RowIndex.ToString() + "," + cell.ColumnIndex.ToString();
            }
            BLL.Sample SampleBLL = new BLL.Sample();  //声明对象

            // 先删除数据库数据
            SampleBLL.DelCheckItem(rowCell);

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                // checkbox按下后是选择状态还是非选择状态
                string checkFlg = dataGridView1.Rows[i].Cells[2].EditedFormattedValue.ToString();

                if (checkFlg == "True")
                {
                    // 登录数据库
                    Model.Sample Sample = new Model.Sample
                    {
                        HoleSite = rowCell,
                        CheckItem = dataGridView1.Rows[i].Cells[6].Value.ToString(),
                        Attribute = dataGridView1.Rows[i].Cells[0].EditedFormattedValue.ToString(),
                        Concentration = dataGridView1.Rows[i].Cells[1].EditedFormattedValue.ToString(),
                    };

                    SampleBLL.AddSampcheck(Sample);
                }
            }
        }
        #endregion
    }
}
