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

namespace PcrNew.Pages.Tool
{
    public partial class AllTestItem : UIForm
    {
        public string strItemLibraryType = "";//项目库类别  0:绝对定量;1:相对定量;2:SNP;3:高分辨率
        public string strItemName = "";//项目名称
        public static bool AddFlg = false;//是否显示引用项目

        public delegate void RefreshDelegate(); // 子窗口声明定义委托 refresh()
        public event RefreshDelegate refresh;



        public AllTestItem()
        {
            InitializeComponent();
            
            uiComboBox1.SelectedIndex = 0;            //默认选择绝对定量

            GetInitData();//获取数据

            if (AddFlg) { uiButton5.Visible = true; }
        }
        #region 数据的初始化
        public void GetInitData() 
        {
            DAL.AllTestItem AllTestItemDal = new DAL.AllTestItem();  //声明对象            
            
            dataGridView1.ClearAll();

            string str = "ItemLibraryType = " + uiComboBox1.SelectedIndex.ToString() ;
            dataGridView1.DataSource = AllTestItemDal.GetColorList(str).Tables[0];//赋值
                                                                            //设置列的列标题
            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].HeaderText = "项目库类别";
            dataGridView1.Columns[1].Visible = false;
            dataGridView1.Columns[2].HeaderText = "项目名称";
            dataGridView1.Columns[3].HeaderText = "颜色";
            dataGridView1.Columns[4].HeaderText = "MasterMix";
            dataGridView1.Columns[5].HeaderText = "引物";
            dataGridView1.Columns[6].HeaderText = "探针";
            dataGridView1.Columns[7].HeaderText = "耗材";
            dataGridView1.Columns[8].HeaderText = "批号";
            dataGridView1.Columns[9].HeaderText = "报告荧光";
            dataGridView1.Columns[10].HeaderText = "颜色";
            dataGridView1.Columns[10].Visible = false;

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                string strCol = dataGridView1.Rows[i].Cells[3].Value.ToString();
                if (strCol.Contains("#"))
                {
                    Color c1 = System.Drawing.ColorTranslator.FromHtml(strCol);
                    dataGridView1.Rows[i].Cells[3].Value = "";
                    dataGridView1.Rows[i].Cells[3].Style.BackColor = c1;
                    dataGridView1.Rows[i].Cells[3].Style.SelectionBackColor = c1;
                }
                else
                {
                    UIMessageTip.Show(AppCode.Color_ERROR);
                }

            }
        }

        #endregion

        #region 下拉框更改事件
        private void uiComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            strItemLibraryType = uiComboBox1.SelectedIndex.ToString();
            GetInitData();


        }
        #endregion

        #region 添加项目
        private void uiButton1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(strItemLibraryType)) { UIMessageTip.Show(AppCode.LIB_EMPTIY_ERROR); return; }//项目库类别必须是非空
            if (string.IsNullOrEmpty(uitextBox1.Text)) { UIMessageTip.Show(AppCode.ITEM_EMPTIY_ERROR); return; }//项目名称类别必须是非空

            #region 循环判断项目名称是否存在            
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (uitextBox1.Text == dataGridView1.Rows[i].Cells[2].Value.ToString())
                {
                    UIMessageTip.Show(AppCode.ITEM_EXIT_ERROR);
                    return;
                }
            }
            #endregion
            ColorHelper colorHelper = new ColorHelper();
            string color = colorHelper.QueryColor();
            Model.AllTestItem AllTestItem = new Model.AllTestItem
            {

                ItemLibraryType = int.Parse(strItemLibraryType),
                ItemName = uitextBox1.Text,
                ReportHighLighter = "FAM",
                ItemColor = color,
                MasterMix = "",
                Primers = "",
                Probe = "",
                Supplies = "",
                QCBatch = ""
            };
            BLL.AllTestItem AllTestItemBLL = new BLL.AllTestItem();  //声明对象
            bool flg = AllTestItemBLL.Add(AllTestItem);
            if (flg)
            {
                UIMessageTip.Show(AppCode.INSERT_SUCCESSS);
                GetInitData();
            }
            else
            {
                UIMessageTip.Show(AppCode.INSERT_ERROR);
            }

        }
        #endregion

        #region 编辑项目
        private void uiButton2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(strItemLibraryType)) { UIMessageTip.Show(AppCode.LIB_EMPTIY_ERROR); return; }

            AllTestItemBase testItemBase = new AllTestItemBase();

            testItemBase.refreshu += GetInitData; // 父窗口加入委托

           // testItemBase.Owner = this;
            testItemBase.Show(this);

          /*  AllTestItemBase testItemBase = new AllTestItemBase();
            testItemBase.Show(this);*/
        }
        #endregion

        #region 选中对应数据
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (this.dataGridView1.SelectionMode != DataGridViewSelectionMode.FullColumnSelect && dataGridView1.CurrentRow != null)
            {
                int index = dataGridView1.CurrentRow.Index; //获取选中行的行号

                uitextBox1.Text = dataGridView1.Rows[index].Cells[2].Value.ToString();
                uiTextBox2.Text = dataGridView1.Rows[index].Cells[9].Value.ToString();

                strItemName = uitextBox1.Text;
            };
        }
        #endregion

        #region 删除对应的项目
        private void uiSymbolButton2_Click(object sender, EventArgs e)
        {
            BLL.AllTestItem AllTestItemBLL = new BLL.AllTestItem();  //声明对象
            bool flg = AllTestItemBLL.Delete(strItemLibraryType, uitextBox1.Text);

            if (flg)
            {
                UIMessageTip.Show(AppCode.DELETE_SUCCESSS);
                GetInitData();//获取数据
            }
            else
            {
                UIMessageTip.Show(AppCode.DELETE_ERROR);
            }
        }
        #endregion

        #region 更新项目名称
        private void uiButton3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(uitextBox1.Text)) { UIMessageTip.Show(AppCode.ITEM_EMPTIY_ERROR); return; }//项目名称类别必须是非空

            #region 循环判断项目名称是否存在            
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (uitextBox1.Text == dataGridView1.Rows[i].Cells[2].Value.ToString())
                {
                    UIMessageTip.Show(AppCode.ITEM_EXIT_ERROR);
                    return;
                }
            }
            #endregion
            BLL.AllTestItem AllTestItemBLL = new BLL.AllTestItem();  //声明对象
            bool flg = AllTestItemBLL.Update(strItemLibraryType, uitextBox1.Text, strItemName);
            if (flg)
            {
                UIMessageTip.Show(AppCode.UPDATE_SUCCESSS);
                GetInitData();
            }
            else
            {
                UIMessageTip.Show(AppCode.UPDATE_ERROR);
            }
        }
        #endregion

        #region 引用按钮 数据插入到对应的数据库内
        private void uiButton5_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.SelectionMode != DataGridViewSelectionMode.FullColumnSelect && dataGridView1.CurrentRow != null)
            {
                int index = dataGridView1.CurrentRow.Index; //获取选中行的行号
                //int ID = int.Parse(dataGridView1.Rows[index].Cells[0].Value.ToString());
                string ItemName = dataGridView1.Rows[index].Cells[2].Value.ToString();

                //stItemFrmNew.ReportID
                //1.首先判断是否存在重复的数据  (根据报告单号去查询对应的数据)
                BLL.ItemMain itemMain = new BLL.ItemMain();
                if (itemMain.ExistsByReportIdItemName(TestItemFrmNew.ReportID, ItemName))
                {
                    UIMessageTip.Show(AppCode.ITEM_EXISTS);
                    this.Close();
                }
                else
                {
                    //如果项目中数据清空了,必须先更新主表中的ItemName  再往明细表面查数据
                    if (TestItemFrmNew.DataRowsIsNull)
                    {
                        //根据报告单号去查询ID
                        BLL.ItemMain itemMain1 = new BLL.ItemMain();

                        DataTable dt = itemMain1.GetList("ReportID = '" + TestItemFrmNew.ReportID + "'").Tables[0];

                        //更新主表信息
                        Model.ItemMain itemMain2 = new Model.ItemMain
                        {
                            ID = int.Parse(dt.Rows[0]["ID"].ToString()),
                            ItemLibraryType = TestItemFrmNew.ItemLibraryType,
                            ReportID = TestItemFrmNew.ReportID,
                            ItemName = ItemName
                        };
                        itemMain1.Update(itemMain2);
                        TestItemFrmNew.DataRowsIsNull = false;

                        //根据报告类型和项目名称查询对应明细
                        BLL.AllTestItem allTestItem = new BLL.AllTestItem();
                        string Querystr = " ItemLibraryType = " + TestItemFrmNew.ItemLibraryType + "";
                        Querystr += " AND ItemName = '" + ItemName + "'";

                        DataTable dtItem = allTestItem.GetList(Querystr).Tables[0];
                        //根据查询出来的数据进行循环插入操作
                        for (int i = 0; i < dtItem.Rows.Count; i++)
                        {
                            string color = dtItem.Rows[i]["ItemColor"].ToString();
                            string MasterMix = dtItem.Rows[i]["MasterMix"].ToString();
                            string Primers = dtItem.Rows[i]["Primers"].ToString();
                            string Probe = dtItem.Rows[i]["Probe"].ToString();
                            string Supplies = dtItem.Rows[i]["Supplies"].ToString();
                            string QCBatch = dtItem.Rows[i]["QCBatch"].ToString();
                            string ReportHight = dtItem.Rows[i]["ReportHighLighter"].ToString();
                            //明细表新增数据
                            BLL.ItemDetail itemDetail = new BLL.ItemDetail();
                            //新增明细表数据
                            if (i != 0) { ItemName = ""; }
                            Model.ItemDetail itemDetail1 = new Model.ItemDetail
                            {
                                MainID = int.Parse(dt.Rows[0]["ID"].ToString()),
                                ItemName = ItemName,
                                ReportHighLighter = ReportHight,
                                ItemColor = color,
                                MasterMix = MasterMix,
                                Primers = Primers,
                                Probe = Probe,
                                Supplies = Supplies,
                                QCBatch = QCBatch
                            };
                            //插入明细表
                            itemDetail.Add(itemDetail1);
                        }
                        UIMessageTip.Show(AppCode.ITEM_IMPORT_SUCCESS);

                        this.refresh();//此处调用委托

                        this.Close();
                    }
                    else
                    {
                        //根据报告单号去查询ID
                        BLL.ItemMain itemMain1 = new BLL.ItemMain();

                        DataTable dt = itemMain1.GetList("ReportID = '" + TestItemFrmNew.ReportID + "'").Tables[0];

                        //更新主表信息
                        Model.ItemMain itemMain2 = new Model.ItemMain
                        {
                            ItemLibraryType = TestItemFrmNew.ItemLibraryType,
                            ReportID = TestItemFrmNew.ReportID,
                            ItemName = ItemName
                        };
                        itemMain1.Add(itemMain2);
                        TestItemFrmNew.DataRowsIsNull = false;

                        //根据报告类型和项目名称查询对应明细
                        BLL.AllTestItem allTestItem = new BLL.AllTestItem();
                        string Querystr = " ItemLibraryType = " + TestItemFrmNew.ItemLibraryType + "";
                        Querystr += " AND ItemName = '" + ItemName + "'";

                        DataTable dtItem = allTestItem.GetList(Querystr).Tables[0];
                        //根据查询出来的数据进行循环插入操作
                        for (int i = 0; i < dtItem.Rows.Count; i++)
                        {
                            string color = dtItem.Rows[i]["ItemColor"].ToString();
                            string MasterMix = dtItem.Rows[i]["MasterMix"].ToString();
                            string Primers = dtItem.Rows[i]["Primers"].ToString();
                            string Probe = dtItem.Rows[i]["Probe"].ToString();
                            string Supplies = dtItem.Rows[i]["Supplies"].ToString();
                            string QCBatch = dtItem.Rows[i]["QCBatch"].ToString();
                            string ReportHight = dtItem.Rows[i]["ReportHighLighter"].ToString();
                            //明细表新增数据
                            BLL.ItemDetail itemDetail = new BLL.ItemDetail();
                            //新增明细表数据
                            if (i != 0) { ItemName = ""; }
                            Model.ItemDetail itemDetail1 = new Model.ItemDetail
                            {
                                MainID = itemMain1.GetMaxId() -1 ,
                                ItemName = ItemName,
                                ReportHighLighter = ReportHight,
                                ItemColor = color,
                                MasterMix = MasterMix,
                                Primers = Primers,
                                Probe = Probe,
                                Supplies = Supplies,
                                QCBatch = QCBatch
                            };
                            //插入明细表
                            itemDetail.Add(itemDetail1);
                        }
                        UIMessageTip.Show(AppCode.ITEM_IMPORT_SUCCESS);

                        this.refresh();//此处调用委托

                        //this.Close();
                    }

                }
            }
        }
        #endregion

    }
}
