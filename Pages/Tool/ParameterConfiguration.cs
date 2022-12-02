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
    public partial class ParameterConfiguration : UIForm
    {
        public ParameterConfiguration()
        {
            InitializeComponent();
            initdata();//初始化查询数据
        }

        #region 取消
        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
        #endregion


        private void button1_Click_1(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void uiRadioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void uiButton2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
        private PcrNew.BLL.ParameterConfiguration bll_ParameterConfiguration = new PcrNew.BLL.ParameterConfiguration();

        #region 确认
        private void uiButton1_Click(object sender, EventArgs e)
        {

            PcrNew.Model.ParameterConfiguration ParameterConfiguration = new PcrNew.Model.ParameterConfiguration();
            ParameterConfiguration.ID = 3;
            ParameterConfiguration.FengHgiht = uiDoubleUpDown4.Value.ToString();//峰高过滤比例
            ParameterConfiguration.Thresholdline = uiCheckBox1.Checked == true ? true : false;//低于阀值线显示
            ParameterConfiguration.PositiveControl = uiCheckBox2.Checked == true ? true : false;//阳控加强判断
            ParameterConfiguration.Ct = uiRadioButton1.Checked == true ? "1" : "2";//1代表基线阀值法  2代表最大二阶导数法
            ParameterConfiguration.Amplification = uiRadioButton3.Checked == true ? "1" : "2";//1代表绝对荧光法 2代表想对荧光值法
            ParameterConfiguration.Noise = uiComboBox1.Text;//噪声容限
            ParameterConfiguration.NoiseNumber = uiDoubleUpDown1.Value.ToString();//噪声绝对值
            ParameterConfiguration.FittingParameters = uiDoubleUpDown2.Value.ToString();//拟合参数
            ParameterConfiguration.FengNumber = uiDoubleUpDown3.Value.ToString();//最大峰个数
            bool flg = bll_ParameterConfiguration.Update(ParameterConfiguration);
            if (flg)
            {
                UIMessageTip.Show(AppCode.INSERT_SUCCESSS);
            }
            else
            {
                UIMessageTip.Show(AppCode.INSERT_ERROR);
            }
        }
        #endregion

        /// <summary>
        /// 初始化默认查询数据库中的数据进行界面显示
        /// </summary>
        void initdata() {
            BLL.ParameterConfiguration parameter = new BLL.ParameterConfiguration();
            DataTable data = parameter.GetAllList().Tables[0];
            uiCheckBox1.Checked = (bool)data.Rows[0]["Thresholdline"] == true;//低于阀值线显示
            uiCheckBox2.Checked = (bool)data.Rows[0]["PositiveControl"] == true;//阳控加强判断
            if (data.Rows[0]["Ct"].Equals("1"))//1代表基线阀值法  2代表最大二阶导数法
            {
                uiRadioButton1.Checked = true;
            }
            else {
                uiRadioButton2.Checked = true;
            }
            if (data.Rows[0]["Amplification"].Equals("1"))//1代表绝对荧光法 2代表想对荧光值法
            {
                uiRadioButton3.Checked = true;
            }
            else
            {
                uiRadioButton4.Checked = true;
            }
            uiComboBox1.Text = (string)data.Rows[0]["Noise"];//噪声容限
            uiDoubleUpDown1.Value = double.Parse((string)data.Rows[0]["NoiseNumber"]);//噪声绝对值
            uiDoubleUpDown2.Value = double.Parse((string)data.Rows[0]["FittingParameters"]);//拟合参数
            uiDoubleUpDown3.Value = double.Parse((string)data.Rows[0]["FengNumber"]);//最大峰个数
            uiDoubleUpDown4.Value = double.Parse((string)data.Rows[0]["FengHgiht"]);//峰高过滤比例
        }
    }
}
