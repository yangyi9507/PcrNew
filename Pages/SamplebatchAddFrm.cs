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
    public partial class SamplebatchAddFrm : UIForm
    {
        public static int startID = 0;
        public delegate void RefreshDelegate(); // 子窗口声明定义委托 refresh()
        public event RefreshDelegate refresh;
        public SamplebatchAddFrm()
        {
            InitializeComponent();
            this.ShowInTaskbar = false;
            uiTextBox2.Text = (startID).ToString();
        }

        private void uiButton2_Click(object sender, EventArgs e)
        {//添加
            for (int i = 0;i < uiIntegerUpDown1.Value ; i++)
            {
                BLL.Sample SampleBLL = new BLL.Sample();  //声明对象
                DataTable u = SampleBLL.GetSampleID(TestItemFrmNew.ReportID, (uiTextBox2.IntValue + i).ToString()).Tables[0];
                if (u.Rows.Count > 0)
                {
                    UIMessageTip.Show(AppCode.SAVEID);
                    return;
                }
                ColorHelper colorHelper = new ColorHelper();
                string color = colorHelper.QueryColor();
                Model.Sample Sample = new Model.Sample
                {
                    SamplID = ((uiTextBox2.IntValue) + i).ToString(),
                    SampleColor = color,
                    SampleName = "",
                    CreationTime = DateTime.Now.ToString(),
                    CensorshipTime = DateTime.Now.ToString(),
                    Experiment = TestItemFrmNew.ReportID
                };
                bool flg = SampleBLL.AddSample(Sample);
                if (!flg)
                {
                    UIMessageTip.Show(AppCode.INSERT_ERROR);
                }
            }
            this.refresh();//此处调用委托
            Close();
        }

        private void uiButton1_Click(object sender, EventArgs e)
        {//取消
            this.refresh();//此处调用委托
            Close();
        }

        private void SamplebatchAddFrm_Load(object sender, EventArgs e)
        {
        }
    }
}
