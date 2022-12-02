using PcrNew.Pages.Tool;
using Comm;
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
    public partial class TestItemFrmNew : UIPage
    {
        public static string ReportID = "";

        public static int ItemLibraryType = 0;//0:绝对定量,1:相对定量，2：高分辨率，3：SNP，4：基因研究

        public static bool DataRowsIsNull = false;//网格数据是否全部删除

        private string ItemName = "";

        private int IDSelected = 0;

        private string ReportHL = "";//报告银光

        private string strColor = "";//报告颜色
       
        Object cellTempValue = null;//用来存放修改之前的数据

        public TestItemFrmNew()
        {
            InitializeComponent();            
            uiComboBox2.SelectedIndex = 0;
            uitextBox1.Text = ReportID;
            uiTextBox2.Text = Main.NowUsername;
            uiButton1_Click(null, null);
        }

        private void init()
        {
            try
            {
                string ItemName = "项目" + DateTime.Now.ToString("HHmmss");
                #region 项目主表增加数据
                Model.ItemMain itemModel = new Model.ItemMain
                {
                    ReportID = ReportID,
                    ItemLibraryType = ItemLibraryType,
                    ItemName = ItemName
                };
                BLL.ItemMain item = new BLL.ItemMain();
                item.Add(itemModel);
                #endregion

                #region 项目明细增加数据
                int mainID = item.GetMaxId() - 1;
                ColorHelper colorHelper = new ColorHelper();
                string color = colorHelper.QueryColor();

                Model.ItemDetail detailmodel = new Model.ItemDetail
                {
                    MainID = mainID,
                    ItemName = ItemName,
                    ReportHighLighter = "FAM",
                    ItemColor = color,
                    MasterMix = "",
                    Primers = "",
                    Probe = "",
                    Supplies = "",
                    QCBatch = ""
                };
                BLL.ItemDetail detail = new BLL.ItemDetail();
                detail.Add(detailmodel);

                #endregion

                ShowData();
            }
            catch (Exception)
            {

                throw;
            }
        }

        #region 展示数据

        public void InitData() 
        {
            BLL.ItemMain itemMain = new BLL.ItemMain();
            Model.ItemMain itemMain1 = new Model.ItemMain();
            itemMain1.ReportID = ReportID;
            itemMain1.ItemLibraryType = ItemLibraryType;
            itemMain1.ItemName = "";
            itemMain.Add(itemMain1);
        }

        public void ShowData()
        {

            BLL.ItemMain item = new BLL.ItemMain();
            string str = "ReportID = '" + ReportID +"' AND A.ITEMNAME <> '' ";


            dataGridView1.DataSource = item.GetItemByReportID(str).Tables[0];//赋值

            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].HeaderText = "ReportID";
            dataGridView1.Columns[1].Visible = false;
            dataGridView1.Columns[2].HeaderText = "项目名称";
            dataGridView1.Columns[3].HeaderText = "报告荧光";            
            dataGridView1.Columns[4].HeaderText = "颜色";
            dataGridView1.Columns[4].Visible = false;
            dataGridView1.Columns[5].HeaderText = "MasterMix";
            dataGridView1.Columns[6].HeaderText = "引物";
            dataGridView1.Columns[7].HeaderText = "探针";
            dataGridView1.Columns[8].HeaderText = "耗材";
            dataGridView1.Columns[9].HeaderText = "批号";
            dataGridView1.Columns[10].HeaderText = "ItemName";
            dataGridView1.Columns[10].Visible = false;
            dataGridView1.Columns[11].HeaderText = "颜色";            

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                string[] strCol = dataGridView1.Rows[i].Cells[4].Value.ToString().Split(',');
                if (strCol.Length == 1)
                {
                   // Color c1 =  Color;//Color. ();
                    Color c1 = System.Drawing.ColorTranslator.FromHtml(strCol[0]);
                    dataGridView1.Rows[i].Cells[11].Value = "";
                    dataGridView1.Rows[i].Cells[11].Style.BackColor = c1;
                    dataGridView1.Rows[i].Cells[11].Style.SelectionBackColor = c1;
                }

            }
        }
        #endregion
        #region 添加检验项目
        private void uiButton1_Click(object sender, EventArgs e)
        {
            try
            {
                string ItemName = "项目" + DateTime.Now.ToString("HHmmss");
                #region 项目主表增加数据
                Model.ItemMain itemModel = new Model.ItemMain
                {
                    ReportID = ReportID,
                    ItemLibraryType = ItemLibraryType,
                    ItemName = ItemName
                };
                BLL.ItemMain item = new BLL.ItemMain();
                item.Add(itemModel);
                #endregion

                #region 项目明细增加数据
                int mainID = item.GetMaxId()-1;
                ColorHelper colorHelper = new ColorHelper();
                string color = colorHelper.QueryColor();

                Model.ItemDetail detailmodel = new Model.ItemDetail
                {
                    MainID = mainID,
                    ItemName = ItemName,
                    ReportHighLighter = "FAM",
                    ItemColor = color,
                    MasterMix = "",
                    Primers = "",
                    Probe = "",
                    Supplies = "",
                    QCBatch = ""
                };
                BLL.ItemDetail detail = new BLL.ItemDetail();
                detail.Add(detailmodel);

                #endregion

                ShowData();
            }
            catch (Exception)
            {

                throw;
            }         
        }
        #endregion

        #region 增加检验项目
        private void uiButton2_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.SelectionMode != DataGridViewSelectionMode.FullColumnSelect && dataGridView1.CurrentRow != null)
            {
                int index = dataGridView1.CurrentRow.Index; //获取选中行的行号
                int ID = int.Parse(dataGridView1.Rows[index].Cells[0].Value.ToString());

                #region 项目明细增加数据
                ColorHelper colorHelper = new ColorHelper();
                string color = colorHelper.QueryColor();
                Model.ItemDetail detailmodel = new Model.ItemDetail
                {
                    MainID = ID,
                    ItemName = "",
                    ItemColor = color,
                    MasterMix = "",
                    Primers = "",
                    Probe = "",
                    Supplies = "",
                    QCBatch = ""
                };


                string[] list = { "FAM", "SYBR", "HEX", "VIC", "JOE", "ROX", "Cy5", "Cy5.5", "TAMRA" };
                BLL.ItemDetail detail2 = new BLL.ItemDetail();
             
                for (int i = 0;i < list.Length; i++)
                {
                    DataTable dt = detail2.GetRList(ID, list[i]).Tables[0];//赋值
                    if(dt.Rows.Count == 0)
                    {
                        detailmodel.ReportHighLighter = list[i];
                        break;
                    }else if(i == list.Length - 1)
                    {
                        return;
                    }
                }
                BLL.ItemDetail detail = new BLL.ItemDetail();
                detail.Add(detailmodel);
                ShowData();
                #endregion
            }
        }
        #endregion

        #region 单元格开始编辑时触发的事件
        private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            cellTempValue = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
        }
        #endregion

        #region  单元格结束编辑时触发的事件
        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            //判断编辑前后的值是否一样（是否修改了内容）
            if (Object.Equals(cellTempValue, dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value)) 
            {
                //如果没有修改，则返回
                return;
            }
            //判断用户是否确定修改
            if (ShowAskDialog("确定修改?"))
            {
                
            }
            else
            {
                //如果不修改，恢复原来的值
                dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = cellTempValue;
                return;
            }
        }
        #endregion

        #region 删除检验项
        private void uiSymbolButton1_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.SelectionMode != DataGridViewSelectionMode.FullColumnSelect && dataGridView1.CurrentRow != null)
            {
                int index = dataGridView1.CurrentRow.Index; //获取选中行的行号
                int ID = int.Parse(dataGridView1.Rows[index].Cells[0].Value.ToString());

                #region 首先删除对应明细表内的内容
                BLL.ItemDetail itemDetail = new BLL.ItemDetail();
                itemDetail.Delete(ID, dataGridView1.Rows[index].Cells[3].Value.ToString());
                #endregion

                #region 删除主表信息
                //判断是否还存在项目  不存在话就把主表内的数据删除
                BLL.ItemMain itemmain = new BLL.ItemMain();
                if (!itemDetail.Exists(ID.ToString()))
                {
                    if (dataGridView1.RowCount == 1) 
                    {
                        itemmain.Update(ID);
                    }
                    else{
                        itemmain.Delete(ID);
                    }
                    
                    
                }
                #endregion                

                ShowData();
            }
        }
        #endregion

        #region 删除选中的检验项目
        private void uiSymbolButton2_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.SelectionMode != DataGridViewSelectionMode.FullColumnSelect && dataGridView1.CurrentRow != null) 
            {
                int index = dataGridView1.CurrentRow.Index; //获取选中行的行号
                int ID = int.Parse(dataGridView1.Rows[index].Cells[0].Value.ToString());
                #region 首先删除项目主表内的内容
                BLL.ItemDetail itemDetail = new BLL.ItemDetail();
                if (!itemDetail.ExistsByReportID(ReportID, ID.ToString()))
                {
                    BLL.ItemMain itemmain = new BLL.ItemMain();
                    itemmain.Update(ID);
                }
                else {
                    BLL.ItemMain itemmain = new BLL.ItemMain();
                    itemmain.Delete(ID);
                }
                #endregion

                #region 删除对应明细表内的内容
               
                itemDetail.Delete(ID,"");
                #endregion

                ShowData();
            }
        }
        #endregion

        #region 引用检验项目库中的项目
        private void uiButton5_Click(object sender, EventArgs e)
        {
            Tool.AllTestItem.AddFlg = true;
            if (dataGridView1.RowCount == 0) { DataRowsIsNull = true; }

            AllTestItem testItemBase = new AllTestItem();

            testItemBase.refresh += ShowData; // 父窗口加入委托

            testItemBase.Owner = this;
            testItemBase.Show();
        }
        #endregion

        private void uiColorPicker1_Click(object sender, EventArgs e)
        {
            UIMessageTip.Show(uiColorPicker1.Value.ToString());
        }

        private void uiColorPicker1_ValueChanged(object sender, System.Drawing.Color value)
        {
            strColor = "#" + value.Name;
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (this.dataGridView1.SelectionMode != DataGridViewSelectionMode.FullColumnSelect && dataGridView1.CurrentRow != null)
            {
                int index = dataGridView1.CurrentRow.Index; //获取选中行的行号
                IDSelected = int.Parse(dataGridView1.Rows[index].Cells[0].Value.ToString());//后期用来做更新判断
                ItemName = dataGridView1.Rows[index].Cells[10].Value.ToString();//后期用来做更新判断
                ReportHL = dataGridView1.Rows[index].Cells[3].Value.ToString();//后期用来做更新
                uiTextBox4.Text = dataGridView1.Rows[index].Cells[10].Value.ToString();
                uiTextBox5.Text = dataGridView1.Rows[index].Cells[5].Value.ToString();
                uiTextBox6.Text = dataGridView1.Rows[index].Cells[6].Value.ToString();
                uiTextBox7.Text = dataGridView1.Rows[index].Cells[7].Value.ToString();
                uiTextBox8.Text = dataGridView1.Rows[index].Cells[8].Value.ToString();
                uiTextBox9.Text = dataGridView1.Rows[index].Cells[9].Value.ToString();
                uiComboBox2.Text = dataGridView1.Rows[index].Cells[3].Value.ToString();

                string[] str = dataGridView1.Rows[index].Cells[4].Value.ToString().Split(',');
                if (str.Length == 1) 
                {
                    strColor = str[0];
                    Color c1 = System.Drawing.ColorTranslator.FromHtml(str[0]);
                        //Color.FromArgb(int.Parse(str[0]), int.Parse(str[1]), int.Parse(str[2]), int.Parse(str[3]));
                    uiColorPicker1.Value = c1;
                }
            }
        }

        private void uiButton3_Click(object sender, EventArgs e)
        {
            //首先判断项目名称是否已经存在
            if (string.IsNullOrEmpty(uiTextBox4.Text)) { UIMessageTip.Show("项目名称不能为空！"); }
            if (ItemName != uiTextBox4.Text) 
            {
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    if (uiTextBox4.Text == dataGridView1.Rows[i].Cells[10].Value.ToString())
                    {
                        UIMessageTip.Show("该报告下面已经存在对应的项目ID，无法更新！！");
                        return;
                    }
                }
                //根据ID更新主表的项目名称
                BLL.ItemMain itemMain = new BLL.ItemMain();
                itemMain.Update(IDSelected, uiTextBox4.Text);
                //根据ID更新明细表数据  改掉项目名称
                BLL.ItemDetail itemDetail = new BLL.ItemDetail();
                itemDetail.Update(IDSelected, uiTextBox4.Text);
            }
            //更新明细表
            BLL.ItemDetail detail = new BLL.ItemDetail();
            Model.ItemDetail detailModel = new Model.ItemDetail();
            detailModel.ReportHighLighter = uiComboBox2.Text;
            detailModel.ItemColor = strColor; 
            detailModel.MasterMix = uiTextBox5.Text;
            detailModel.Primers = uiTextBox6.Text;
            detailModel.Probe = uiTextBox7.Text;
            detailModel.Supplies = uiTextBox8.Text;
            detailModel.QCBatch = uiTextBox9.Text;
            detail.Update(IDSelected, ReportHL, detailModel);

            ShowData();
        }

        private void TestItemFrmNew_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < this.dataGridView1.Columns.Count; i++)
            {
                this.dataGridView1.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                string[] strCol = dataGridView1.Rows[i].Cells[4].Value.ToString().Split(',');
                if (strCol.Length == 1)
                {
                    // Color c1 =  Color;//Color. ();
                    Color c1 = System.Drawing.ColorTranslator.FromHtml(strCol[0]);
                    dataGridView1.Rows[i].Cells[11].Value = "";
                    dataGridView1.Rows[i].Cells[11].Style.BackColor = c1;
                    dataGridView1.Rows[i].Cells[11].Style.SelectionBackColor = c1;
                }

            }
        }

        private void uiLabel5_Click(object sender, EventArgs e)
        {

        }
    }
}
