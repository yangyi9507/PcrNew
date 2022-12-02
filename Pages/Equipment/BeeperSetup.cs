using Sunny.UI;
using System;
using System.Data;

namespace PcrNew.Pages.Equipment
{
    public partial class BeeperSetup : UIForm
    {
        public BeeperSetup()
        {
            InitializeComponent();
            initdata();
        }
        private PcrNew.BLL.Beeper bll_Beeper = new PcrNew.BLL.Beeper();
        private void uiButton1_Click(object sender, EventArgs e)
        {
            PcrNew.Model.Beeper Beeper = new PcrNew.Model.Beeper();
            Beeper.ID = 1;
            Beeper.issetting = uiCheckBox1.Checked == true ? "1" : "0";//是否启用蜂鸣器报警设置
            Beeper.fengmingtime = uiDoubleUpDown1.Value.ToString();//报警时间
            bool flg = bll_Beeper.Update(Beeper);
            if (flg)
            {
                UIMessageTip.Show(AppCode.INSERT_SUCCESSS);
            }
            else
            {
                UIMessageTip.Show(AppCode.INSERT_ERROR);
            }
        }

        /// <summary>
        /// 初始化刷新数据
        /// </summary>
        void initdata() {
            BLL.Beeper beeper = new BLL.Beeper();
            DataTable data = beeper.GetAllList().Tables[0];
            if (data.Rows[0]["issetting"].Equals("1"))
            {
                uiCheckBox1.Checked = true;
            }
            uiDoubleUpDown1.Value = double.Parse(data.Rows[0]["fengmingtime"].ToString());
        }
    }
}
