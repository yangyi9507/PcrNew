using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PcrNew.Pages.Tool
{
    public partial class AllTestItemBase : UIForm
    {
        int ID = 0;
        string HighLighter = "";
        string SelectColor = "";
        public delegate void RefreshDelegate(); // 子窗口声明定义委托 refresh()
        public event RefreshDelegate refreshu;

        public AllTestItemBase()
        {
            InitializeComponent();
            GetInitData();
        }
        public void GetInitData()
        {            
            BLL.AllTestItem AllTestItemBll = new BLL.AllTestItem();  //声明对象            

            uiDataGridView1.ClearAll();
            
            string str = "ItemLibraryType = 0";
            uiDataGridView1.DataSource = AllTestItemBll.GetItemList(str).Tables[0];//赋值
            uiDataGridView1.Columns[0].HeaderText = "项目名称";
        }
        private void uiButton2_Click(object sender, EventArgs e)
        {
            AllTestItem item = (AllTestItem)this.Owner;            
            BLL.AllTestItem AllTestItemBLL = new BLL.AllTestItem();  //声明对象

            #region 循环判断项目名称和下拉框内容是否选择是否存在
            if (string.IsNullOrEmpty(uiComboBox1.SelectedText)) { UIMessageTip.Show(AppCode.ITEM_EMPTIY_ERROR); return; }
            //if (AllTestItemBLL.Exists(item.strItemLibraryType, uitextBox1.Text)) 
            //{
            //    UIMessageTip.Show(AppCode.ITEM_EXIT_ERROR);
            //    return;
            //}
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (uiComboBox1.SelectedText == dataGridView1.Rows[i].Cells[9].Value.ToString())
                {
                    UIMessageTip.Show(AppCode.ITEM_EXIT_ERROR);
                    return;
                }
            }
            #endregion

            Model.AllTestItem AllTestItem = new Model.AllTestItem
            {
                ItemLibraryType = int.Parse(item.strItemLibraryType),
                ItemName = uitextBox1.Text,
                ReportHighLighter = uiComboBox1.SelectedText.ToString(),
                ItemColor = SelectColor,
                MasterMix = uiTextBox7.Text,
                Primers = uiTextBox4.Text,
                Probe = uiTextBox5.Text,
                Supplies = uiTextBox6.Text,
                QCBatch = uiTextBox3.Text
            };

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
        #region 选中行数据展示
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (this.dataGridView1.SelectionMode != DataGridViewSelectionMode.FullColumnSelect && dataGridView1.CurrentRow != null)
            {
                int index = dataGridView1.CurrentRow.Index; //获取选中行的行号
                ID = int.Parse(dataGridView1.Rows[index].Cells[0].Value.ToString());
                //HighLighter = dataGridView1.Rows[index].Cells[9].Value.ToString();

                uitextBox1.Text = dataGridView1.Rows[index].Cells[2].Value.ToString();
                uiComboBox1.Text = dataGridView1.Rows[index].Cells[9].Value.ToString();
                uiTextBox7.Text = dataGridView1.Rows[index].Cells[4].Value.ToString();
                uiTextBox4.Text = dataGridView1.Rows[index].Cells[5].Value.ToString();
                uiTextBox5.Text = dataGridView1.Rows[index].Cells[6].Value.ToString();
                uiTextBox6.Text = dataGridView1.Rows[index].Cells[7].Value.ToString();
                uiTextBox3.Text = dataGridView1.Rows[index].Cells[8].Value.ToString();

                string str = dataGridView1.Rows[index].Cells[10].Value.ToString();
                if (str.Contains("#"))
                {
                    SelectColor = str;
                    Color c1 = System.Drawing.ColorTranslator.FromHtml(str);
                    uiColorPicker1.Value = c1;
                }

                //ID = int.Parse(dataGridView1.Rows[index].Cells[0].Value.ToString());//接收科室ID用于后续的更新
            };

        }
        #endregion
        #region 选中左侧的项目列表
        private void uiDataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (this.uiDataGridView1.SelectionMode != DataGridViewSelectionMode.FullColumnSelect && uiDataGridView1.CurrentRow != null)
            {
                int index = uiDataGridView1.CurrentRow.Index; //获取选中行的行号

                string itemName = uiDataGridView1.Rows[index].Cells[0].Value.ToString();

                BLL.AllTestItem AllTestItemBll = new BLL.AllTestItem();  //声明对象      
                string str = "ItemLibraryType = 0 AND ItemName = '" + itemName + "'";
                dataGridView1.ClearAll();
                dataGridView1.DataSource = AllTestItemBll.GetColorList(str).Tables[0];//赋值
                                                                                 //设置列的列标题
                dataGridView1.Columns[0].HeaderText = "ID";
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[1].HeaderText = "项目库类别";
                dataGridView1.Columns[1].Visible = false;
                dataGridView1.Columns[2].HeaderText = "项目名称";
                dataGridView1.Columns[2].Visible = false;
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

            };

        }
        #endregion
        #region 删除检验项
        private void uiSymbolButton1_Click(object sender, EventArgs e)
        {
            BLL.AllTestItem AllTestItemBll = new BLL.AllTestItem();  //声明对象   

            bool flg = AllTestItemBll.Delete(ID);
            if (flg)
            {
                UIMessageTip.Show(AppCode.DELETE_SUCCESSS);
                GetInitData();
            }
            else
            {
                UIMessageTip.Show(AppCode.DELETE_ERROR);
            }
        }
        #endregion
        #region 更新检验项目
        private void uiButton1_Click(object sender, EventArgs e)
        {
            AllTestItem item = (AllTestItem)this.Owner;
            BLL.AllTestItem AllTestItemBLL = new BLL.AllTestItem();  //声明对象

            #region 循环判断项目名称和下拉框内容是否选择是否存在
            if (string.IsNullOrEmpty(uiComboBox1.SelectedText)) { UIMessageTip.Show(AppCode.ITEM_EMPTIY_ERROR); return; }
            //if (AllTestItemBLL.Exists(item.strItemLibraryType, uitextBox1.Text)) 
            //{
            //    UIMessageTip.Show(AppCode.ITEM_EXIT_ERROR);
            //    return;
            //}
            if (HighLighter != uiComboBox1.SelectedText) 
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    if (uiComboBox1.SelectedText == dataGridView1.Rows[i].Cells[9].Value.ToString())
                    {
                        UIMessageTip.Show(AppCode.ITEM_EXIT_ERROR);
                        return;
                    }
                }
            }

            #endregion

            Model.AllTestItem AllTestItem = new Model.AllTestItem
            {
                ID = ID,
                ItemLibraryType = int.Parse(item.strItemLibraryType),
                ItemName = uitextBox1.Text,
                ReportHighLighter = uiComboBox1.SelectedText.ToString(),
                ItemColor = SelectColor,
                MasterMix = uiTextBox7.Text,
                Primers = uiTextBox4.Text,
                Probe = uiTextBox5.Text,
                Supplies = uiTextBox6.Text,
                QCBatch = uiTextBox3.Text
            };

            bool flg = AllTestItemBLL.Update(AllTestItem);
            if (flg)
            {
                UIMessageTip.Show(AppCode.UPDATE_SUCCESSS);
                GetInitData();
            }
            else
            {
                UIMessageTip.Show(AppCode.UPDATE_SUCCESSS);
            }
        }
        #endregion

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void uiColorPicker1_ValueChanged(object sender, Color value)
        {
            SelectColor = "#" + value.Name;
        }

    }
}
