using Aspose.Cells;
using PcrNew.BLL;
using PcrNew.Comm;
using PcrNew.Frame;
using Comm;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PcrNew.Pages
{
    public partial class SampleInfoFrm : UIPage
    {
        private String id = "";//样本信息的数据库id号
        private string selectcolor = "";//选中的颜色名
        public SampleInfoFrm()
        {
            InitializeComponent();
            Samplelist(TestItemFrmNew.ReportID);
        }

        #region 批量添加
        private void uiButton2_Click(object sender, EventArgs e)
        {
            SamplebatchAddFrm.startID = uitextBox1.IntValue;
            uitextBox1.Text = "";

            this.uitextBox1.Enabled = false;
            this.uiButton1.Enabled = false;
            this.uiButton2.Enabled = false;
            this.uiButton3.Enabled = false;
            this.uiSymbolButton1.Enabled = false;
            this.uiSymbolButton2.Enabled = false;

            SamplebatchAddFrm testItemBase = new SamplebatchAddFrm();
            testItemBase.refresh += SamplelistAll; // 父窗口加入委托
            testItemBase.Owner = this;
            testItemBase.Show();
        }
        #endregion

        private void uitextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if(uitextBox1.Text != "")
                {
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        if (dataGridView1.Rows[i].Cells[0].Value.ToString() == uitextBox1.Text)
                        {
                            UIMessageTip.Show(AppCode.SAVEID);
                            return;
                        }
                    }
                    ColorHelper colorHelper = new ColorHelper();
                    string color = colorHelper.QueryColor();
                    BLL.Sample SampleBLL = new BLL.Sample();  //声明对象
                    Model.Sample Sample = new Model.Sample
                    {
                        SamplID = uitextBox1.Text,
                        SampleColor = color,
                        SampleName = "",
                        CreationTime = DateTime.Now.ToString(),
                        CensorshipTime = DateTime.Now.ToString(),
                        Experiment = TestItemFrmNew.ReportID
                    };
                    bool flg = SampleBLL.AddSample(Sample);
                    if (flg)
                    {
                        Samplelist(TestItemFrmNew.ReportID);
                    }
                    else
                    {
                        UIMessageTip.Show(AppCode.INSERT_ERROR);
                    }
                    uitextBox1.Text = "";
                }
            }
        }

        //查询样本列表
        private void Samplelist(String testname)
        {
            //刷新界面数据
            BLL.Sample SampleBLL = new BLL.Sample();  //声明对象
            dataGridView1.DataSource = SampleBLL.GetSample(TestItemFrmNew.ReportID).Tables[0];
            if (dataGridView1.DataSource != null)
            {
                dataGridView1.Columns[0].HeaderText = "样本ID";
                dataGridView1.Columns[1].HeaderText = "颜色";
                dataGridView1.Columns[2].HeaderText = "样本名称";
                dataGridView1.Columns[3].HeaderText = "采样时间";
                dataGridView1.Columns[4].HeaderText = "送检日期";
                dataGridView1.Columns[5].HeaderText = "id";
                dataGridView1.Columns[5].Visible = false;
                dataGridView1.Columns[6].HeaderText = "颜色";
                dataGridView1.Columns[6].Visible = false;
            }

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                string strCol = dataGridView1.Rows[i].Cells[1].Value.ToString();
                if (strCol.Contains("#"))
                {
                    Color c1 = System.Drawing.ColorTranslator.FromHtml(strCol);
                    dataGridView1.Rows[i].Cells[1].Value = "";
                    dataGridView1.Rows[i].Cells[1].Style.BackColor = c1;
                    dataGridView1.Rows[i].Cells[1].Style.SelectionBackColor = c1;
                }
                else
                {
                    UIMessageTip.Show(AppCode.Color_ERROR);
                }
           
            }
        }

        //查询样本列表
        private void SamplelistAll()
        {
            //刷新界面数据
            this.uitextBox1.Enabled = true;
            this.uiButton1.Enabled = true;
            this.uiButton2.Enabled = true;
            this.uiButton3.Enabled = true;
            this.uiSymbolButton1.Enabled = true;
            this.uiSymbolButton2.Enabled = true;

            BLL.Sample SampleBLL = new BLL.Sample();  //声明对象
            dataGridView1.DataSource = SampleBLL.GetSample(TestItemFrmNew.ReportID).Tables[0];
            if (dataGridView1.DataSource != null)
            {
                dataGridView1.Columns[0].HeaderText = "样本ID";
                dataGridView1.Columns[1].HeaderText = "颜色";
                dataGridView1.Columns[2].HeaderText = "样本名称";
                dataGridView1.Columns[3].HeaderText = "采样时间";
                dataGridView1.Columns[4].HeaderText = "送检日期";
                dataGridView1.Columns[5].HeaderText = "id";
                dataGridView1.Columns[5].Visible = false;
                dataGridView1.Columns[6].HeaderText = "颜色";
                dataGridView1.Columns[6].Visible = false;
            }

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                string strCol = dataGridView1.Rows[i].Cells[1].Value.ToString();
                if (strCol.Contains("#"))
                {
                    Color c1 = System.Drawing.ColorTranslator.FromHtml(strCol);
                    dataGridView1.Rows[i].Cells[1].Value = "";
                    dataGridView1.Rows[i].Cells[1].Style.BackColor = c1;
                    dataGridView1.Rows[i].Cells[1].Style.SelectionBackColor = c1;
                }
                else
                {
                    UIMessageTip.Show(AppCode.Color_ERROR);
                }

            }


        }

        private void uiSymbolButton1_Click(object sender, EventArgs e)
        {
            if(dataGridView1.CurrentRow != null)
            {
                //删除对应ID行数据
                int u = dataGridView1.CurrentRow.Index;
                String selectID = dataGridView1.Rows[u].Cells[5].Value.ToString();//被选中行的ID
                BLL.Sample sample = new BLL.Sample();
                bool isdelete = sample.DelSample(selectID);
                Samplelist(TestItemFrmNew.ReportID);
                if (isdelete)
                {
                    UIMessageTip.Show(AppCode.DELETE_SUCCESSS);
                }
                else
                {
                    UIMessageTip.Show(AppCode.DELETE_ERROR);
                }
                //刷新界面数据
                Samplelist(TestItemFrmNew.ReportID);
            }
            else
            {
                UIMessageTip.Show(AppCode.ONEROW);
            }
        }

        private void uiSymbolButton2_Click(object sender, EventArgs e)
        {
            BLL.Sample sample = new BLL.Sample();
            bool isdelete = sample.DelSampleAll(TestItemFrmNew.ReportID);
            Samplelist(TestItemFrmNew.ReportID);
            if (isdelete)
            {
                UIMessageTip.Show(AppCode.DELETE_SUCCESSS);
            }
            else
                UIMessageTip.Show(AppCode.DELETE_ERROR);
        }

        private void uiTitlePanel2_Click(object sender, EventArgs e)
        {
       
        }
        #region 导入数据
        private void uiButton1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "CSV files (*.csv)|*.csv";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string strFname = openFileDialog.FileName;

                DataTable dtBill;
                try
                {
                    CsvHelper csvHelper = new CsvHelper();
                    dtBill = csvHelper.csvTodt(strFname, 0);
                }
                catch (Exception err)
                {
                    UIMessageTip.Show(err.ToString());
                    return;
                }

                if (dtBill == null)
                {
                    UIMessageTip.Show(AppCode.EXPORT_EMPTY);
                    return;
                }
                else
                {
                    #region 数据库操作
                    BLL.Sample sample = new BLL.Sample();
                    //1.先根据报告单号判断当前所有ID在数据库是是否存在 存在则跳出 不存在执行插入操作
                    string Sqllist = "";//id号数组
                    for(int i = 0;i < dtBill.Rows.Count; i++)
                    {
                        Sqllist +=  "'" + dtBill.Rows[i][0].ToString() + "',";
                    }
                    DataTable SQLSame = sample.GetSampleId(Sqllist.Substring(0, Sqllist.Length - 1), TestItemFrmNew.ReportID).Tables[0];
                    if(SQLSame.Rows.Count > 0)
                    {
                        UIMessageTip.Show(AppCode.SAME_ID + SQLSame.Rows[0][0].ToString());
                        return;
                    }
                    else
                    {
                        //2.循环执行插入操作
                        BLL.Sample sample1 = new BLL.Sample();
                        for (int i = 0; i < dtBill.Rows.Count; i++)
                        {
                            Model.Sample Sample = new Model.Sample
                            {
                                SamplID = dtBill.Rows[i]["样本ID"].ToString(),
                                SampleColor = dtBill.Rows[i]["样本颜色"].ToString(),
                                SampleName = dtBill.Rows[i]["样本名称"].ToString(),
                                CreationTime = dtBill.Rows[i]["采集时间"].ToString(),
                                CensorshipTime = dtBill.Rows[i]["送检时间"].ToString(),
                                Experiment = TestItemFrmNew.ReportID
                            };
                            bool flg2 = sample1.AddSample(Sample);
                            if (!flg2)
                            {
                                UIMessageTip.Show(AppCode.UP_ERROR);
                                return;
                            }
                        }
                            UIMessageTip.Show(AppCode.UP_SUCCESS);
                    }
                    //3.页面进行刷新
                    Samplelist(TestItemFrmNew.ReportID);
                    #endregion
                }
            }
            else { return; }
        }
        #endregion

        #region 导出数据CSV
        private void uiButton3_Click(object sender, EventArgs e)
        {
            DataTable dt = ExportData();//获取datatable数据源
            string title = "BKC_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".CSV";//导出的文件名            
            if (dt != null)
            {
                DataTableToExcel(dt);
            }
            else { UIMessageTip.Show(AppCode.EXPORT_ERROR); }
            
        }

        private void DataTableToExcel(DataTable dt)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "Execl files (*.csv)|*.csv";
            dlg.CheckFileExists = false;
            dlg.CheckPathExists = false;
            dlg.FilterIndex = 0;
            dlg.RestoreDirectory = true;
            dlg.CreatePrompt = false;
            dlg.Title = "保存为Excel文件";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                Stream myStream;
                myStream = dlg.OpenFile();
                StreamWriter sw = new StreamWriter(myStream, System.Text.Encoding.GetEncoding("GB2312"));

                string columnTitle = "";
                try
                {
                    //写入列标题   
                    for (int i = 0; i < dt.Columns.Count; i++)
                    {
                        if (i > 0)
                        {
                            columnTitle += "\t";
                        }
                        columnTitle += dt.Columns[i].ColumnName;
                    }
                    sw.WriteLine(columnTitle);
                    //写入列内容   
                    for (int j = 0; j < dt.Rows.Count; j++)
                    {
                        string columnValue = "";
                        for (int k = 0; k < dt.Columns.Count; k++)
                        {
                            if (k > 0)
                            {
                                columnValue += "\t";
                            }
                            if (dt.Rows[j][k] == null)
                                columnValue += "";
                            else
                                columnValue += dt.Rows[j][k].ToString().Trim();
                        }
                        sw.WriteLine(columnValue);
                    }
                    sw.Close();
                    myStream.Close();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString());
                }
                finally
                {
                    sw.Close();
                    myStream.Close();
                }
            }
        }

        #endregion
        #region 获取datatable数据源
        public DataTable ExportData()
        {
            BLL.Sample SampleBLL = new BLL.Sample();
            DataTable dt =  SampleBLL.GetExportData(TestItemFrmNew.ReportID).Tables[0];
            if (dt.Rows.Count > 0) 
            {
                return dt;
            }
            else { return null; }
        }

        #endregion

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (this.dataGridView1.SelectionMode != DataGridViewSelectionMode.FullColumnSelect && dataGridView1.CurrentRow != null)
            {
                int Rows = dataGridView1.CurrentRow.Index; //获取选中行的行号
                id = dataGridView1.Rows[Rows].Cells[5].Value.ToString();//该行数据在数据库记录的id
                uiTextBox3.Text = dataGridView1.Rows[Rows].Cells[2].Value.ToString();//获取所选行样本名称
                uiDatetimePicker1.Value = Convert.ToDateTime(dataGridView1.Rows[Rows].Cells[3].Value.ToString());//采样时间
                uiDatetimePicker2.Value = Convert.ToDateTime(dataGridView1.Rows[Rows].Cells[4].Value.ToString());//送检时间

                string str = dataGridView1.Rows[Rows].Cells[6].Value.ToString();
                if (str.Contains("#"))
                {
                    selectcolor = str;
                    Color c1 = System.Drawing.ColorTranslator.FromHtml(str);
                    uiColorPicker1.Value = c1;
                }

                // 窗口加入委托
                DeepWellPlates deepWellrefresh = new DeepWellPlates();
                deepWellrefresh.Show();
                deepWellrefresh.refresh += new DeepWellPlates.RefreshDelegate(deepWellrefresh.getSampleData);

            }
        }

        private void uiButton6_Click(object sender, EventArgs e)
        {
            string color = selectcolor;
            BLL.Sample SampleBLL = new BLL.Sample();  //声明对象
            bool flg = SampleBLL.UpdateSample(uiTextBox3.Text.ToString(), color, uiDatetimePicker1.Text.ToString(), uiDatetimePicker2.Text.ToString(), TestItemFrmNew.ReportID, id);
            if (flg)
            {
                Samplelist(TestItemFrmNew.ReportID);
                uitextBox1.Text = "";
            }
            else
            {
                UIMessageTip.Show(AppCode.UPDATE_ERROR);
            }
        }

        private void uiColorPicker1_ValueChanged(object sender, Color value)
        {
            selectcolor = "#" + value.Name;
        }

        private void SampleInfoFrm_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < this.dataGridView1.Columns.Count; i++)
            {
                this.dataGridView1.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }
    }
}
