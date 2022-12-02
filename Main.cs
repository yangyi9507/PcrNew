using PcrNew.Pages;
using PcrNew.Pages.DataQuery;
using PcrNew.Pages.Equipment;
using PcrNew.Pages.Severice;
using PcrNew.Pages.Tool;
using Comm;
using Model;
using Sunny.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PcrNew
{
    public partial class Main : UIForm
    {
        public static string NowUsername = "";

        public static string TestName = "";

        public int Seconds = 0;//温度时间

        public int TestSeconds = 0;//实验运行时间

        List<String> List1 = new List<String>();

        public Main()
        {
            InitializeComponent();                
        }        
        private void uiNavMenu2_MenuItemClick(TreeNode node, NavMenuItem item, int pageIndex)
        {
            uiTabControl1.TabPages.Clear();            
            switch (node.Text)
            {
                case "检验项目":                   
                    AddPage(new TestItemFrmNew());
                    SelectPage(1003);
                    break;
                case "样本信息":
                    AddPage(new SampleInfoFrm());
                    break;
                case "反应板":
                    AddPage(new DeepWellPlates());
                    break;
                case "程序设置":
                    AddPage(new RunStageSetupControl());
                    break;
                case "荧光曲线":
                    AddPage(new HighLighterGraphfrm());
                    break;
                case "温度曲线":
                    AddPage(new TemperatureGraphfrm());
                    break;
                case "运行程序":
                    AddPage(new StartGraph());                    
                    break;
                default:
                    break;
            }            
        }

        #region 获取datatable数据源
        public DataTable ExportData()
        {
            BLL.Sample SampleBLL = new BLL.Sample();
            DataTable dt = SampleBLL.GetExportData(TestItemFrmNew.ReportID).Tables[0];
            if (dt.Rows.Count > 0)
            {
                return dt;
            }
            else { return null; }
        }
        #endregion

        private void uiNavBar1_MenuItemClick(string itemText, int menuIndex, int pageIndex)
        {
            switch (itemText)
            {
                case "绝对定量":
                    TestItemFrmNew.ItemLibraryType = 0;
                    lblTestType.Text = "绝对定量";
                    TestItemFrmNew.ReportID = DateTime.Now.ToString("yyyyMMdd") + "_" + DateTime.Now.ToString("HHmmss");
                    lblTestName.Text = TestItemFrmNew.ReportID;
                    uiTabControl1.TabPages.Clear();
                    AddPage(new TestItemFrmNew());
                    SelectPage(10000);
                    AddPage(new SampleInfoFrm());
                    AddPage(new DeepWellPlates());
                    AddPage(new RunStageSetupControl());
                    AddPage(new HighLighterGraphfrm());
                    AddPage(new StartGraph());
                    break;
                case "相对定量":
                    TestItemFrmNew.ItemLibraryType = 1;
                    lblTestType.Text = "相对定量";
                    TestItemFrmNew.ReportID = DateTime.Now.ToString("yyyyMMdd") + "_" + DateTime.Now.ToString("HHmmss");
                    lblTestName.Text = TestItemFrmNew.ReportID;
                    uiTabControl1.TabPages.Clear();
                    AddPage(new TestItemFrmNew());
                    SelectPage(1003);
                    AddPage(new SampleInfoFrm());
                    AddPage(new DeepWellPlates());
                    AddPage(new RunStageSetupControl());
                    AddPage(new HighLighterGraphfrm());
                    break;
                case "高分辨率":
                    TestItemFrmNew.ItemLibraryType = 2;
                    lblTestType.Text = "高分辨率";
                    TestItemFrmNew.ReportID = DateTime.Now.ToString("yyyyMMdd") + "_" + DateTime.Now.ToString("HHmmss");
                    lblTestName.Text = TestItemFrmNew.ReportID;
                    uiTabControl1.TabPages.Clear();
                    AddPage(new TestItemFrmNew());
                    SelectPage(1003);
                    AddPage(new SampleInfoFrm());
                    AddPage(new DeepWellPlates());
                    AddPage(new RunStageSetupControl());
                    AddPage(new HighLighterGraphfrm());
                    break;
                case "SNP":
                    TestItemFrmNew.ItemLibraryType = 3;
                    lblTestType.Text = "SNP";
                    TestItemFrmNew.ReportID = DateTime.Now.ToString("yyyyMMdd") + "_" + DateTime.Now.ToString("HHmmss");
                    lblTestName.Text = TestItemFrmNew.ReportID;
                    uiTabControl1.TabPages.Clear();
                    AddPage(new TestItemFrmNew());
                    SelectPage(1003);
                    AddPage(new SampleInfoFrm());
                    AddPage(new DeepWellPlates());
                    AddPage(new RunStageSetupControl());
                    AddPage(new HighLighterGraphfrm());
                    break;
                case "基因研究":
                    TestItemFrmNew.ItemLibraryType = 4;
                    lblTestType.Text = "基因研究";
                    TestItemFrmNew.ReportID = DateTime.Now.ToString("yyyyMMdd") + "_" + DateTime.Now.ToString("HHmmss");
                    lblTestName.Text = TestItemFrmNew.ReportID;
                    uiTabControl1.TabPages.Clear();
                    AddPage(new TestItemFrmNew());
                    SelectPage(1003);
                    AddPage(new SampleInfoFrm());
                    AddPage(new DeepWellPlates());
                    AddPage(new RunStageSetupControl());
                    AddPage(new HighLighterGraphfrm());
                    break;
                case "退出":
                    this.Dispose();
                    this.Close();
                    break;
                case "打开":

                    break;
                case "保存":
                    // 
                    SaveFileDialog sfd = new SaveFileDialog();
                    sfd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory); //默认保存目录为桌面
                    sfd.RestoreDirectory = true; //对话框记忆之前保存的目录
                    sfd.Filter = "PCR文件(*.bkc)|*.bkc";                    
                    sfd.FileName = DateTime.Now.ToString("yyyyMMdd") +  ".bkc"; //设置默认保存的名称
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        string filePath = sfd.FileName;
        
                        Stream myStream;
                        myStream = sfd.OpenFile();
                        StreamWriter sw = new StreamWriter(myStream, System.Text.Encoding.GetEncoding("GB2312"));

                        string columnTitle = "";
                        try
                        {
                            if(TestItemFrmNew.ReportID == "")
                            {
                                UIMessageTip.Show(AppCode.INSERT_PROGRAM);
                            }
                            else
                            {
                                //写入列标题   
                                columnTitle += "程序名称";
                                sw.WriteLine(columnTitle);
                                //写入列内容   
                                string columnValue = TestItemFrmNew.ReportID;
                                sw.WriteLine(columnValue);
                                sw.Close();
                                myStream.Close();
                            }
                        }
                        catch (Exception e)
                        {
                            MessageBox.Show(e.ToString());
                        }
                        finally
                        {
                            sw.Close();
                            myStream.Close();
                            UIMessageTip.Show(AppCode.SAVE_SUCCESS);
                        }
                    }
                    break;
                case "另存为":
                    // 
                    //SaveFileDialog sfd = new SaveFileDialog();
                    //sfd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory); //默认保存目录为桌面
                    //sfd.RestoreDirectory = true; //对话框记忆之前保存的目录
                    //sfd.Filter = "PCR文件(*.bkc)|*.bkc";
                    //sfd.FileName = DateTime.Now.ToString("yyyyMMdd") + ".bkc"; //设置默认保存的名称
                    //if (sfd.ShowDialog() == DialogResult.OK)
                    //{
                    //    string filePath = sfd.FileName;
                    //}
                    break;
                case "另存为模板":
                    break;
                case "用户管理":
                    new UserManagent().ShowDialog();                    
                    break;
                case "蜂鸣器报警":
                    new BeeperSetup().ShowDialog();
                    break;
                case "仪器信息":
                    new InstrumentInformation().ShowDialog();
                    break;
                case "搜索仪器":
                    new SearchInstrument().ShowDialog();
                    break;
                case "增益设置":
                    new GainSetting().ShowDialog();
                    break;
                case "默认法分析参数配置":
                    new ParameterConfiguration().ShowDialog();
                    break;
                case "模块扫描方式":
                    new ScanningMode().ShowDialog();
                    break;
                case "检测项目库":
                    AllTestItem.AddFlg = false;
                    new AllTestItem().ShowDialog();
                    break;
                case "数据查询":
                    new SelectData().ShowDialog();
                    break;
                case "用户登陆":
                    AddUser.addtype = 4;
                    AddUser testItemBase = new AddUser();
                    testItemBase.refresh += Username; // 父窗口加入委托
                    testItemBase.Owner = this;
                    testItemBase.Show();
                    break;
                case "修改密码":
                    AddUser.addtype = 2;
                    new AddUser().ShowDialog();
                    break; 
                default:
                    break;
            }
        }

        //刷新用户名
        public void Username()
        {
            label2.Text = NowUsername;
        }

        private void uiTitlePanel2_Click(object sender, EventArgs e)
        {

        }

        private void uiButton5_Click(object sender, EventArgs e)
        {
            //new TemperatureRunning().ShowDialog();

            uiTabControl1.TabPages.Clear();
            AddPage(new HighLighterGraphfrm());
            AddPage(new StartGraph());



        }

        private void Main_Load(object sender, EventArgs e)
        {
        }

        public void DoSomething() 
        {
            label1.Text = NowUsername;
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void WriteGraph() 
        {
            //1.首先根据reportID查询 TestSteup 程序设置的运行段根据ID进行排序  
            BLL.TestSteup testSteupBll = new BLL.TestSteup();
            string strQuery = " ReportID ='" + lblTestName.Text + "'";
            DataTable dt =  testSteupBll.GetList(strQuery).Tables[0];
            //2.根据CollectFlg进行判断  0:不采集; 1:采集     对需要采集的时间进行判断
            //

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string SteupTime = dt.Rows[i]["SteupTime"].ToString();
                
                string Circle = dt.Rows[i]["Circle"].ToString();
                int CircleInt = int.Parse(Circle);
                string CollectFlg = dt.Rows[i]["CollectFlg"].ToString();

                int SteupTimeInt = int.Parse(SteupTime) * CircleInt;
                TestSeconds += SteupTimeInt;


                for (int k = 0; k < CircleInt; k++)
                {
                    List1.Add(TestSeconds + "," + CollectFlg);
                }
                
            }

        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            Seconds += 1;
            //if (Seconds == int.Parse(List1[0].Split(',')[0].ToString())) 
            //{
            //    if (List1[0].Split(',')[1].ToString() == "1") 
            //    {
            //        //如果需要采集的话 发送指令去获取荧光数值


            //        //发送完指令后List第一个LIST清空
            //        List1.Remove(List1[0]);
            //    }
            //}
        }

        private void uiButton4_Click(object sender, EventArgs e)
        {

        }

        private void uiButton2_Click(object sender, EventArgs e)
        {

        }

        private void uiTextBox11_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
