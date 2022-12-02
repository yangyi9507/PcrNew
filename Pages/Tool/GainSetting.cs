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
    public partial class GainSetting : UIForm
    {
        public GainSetting()
        {
            InitializeComponent();
            uiRadioButton1.Checked = true;
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void uiButton2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private PcrNew.BLL.GainSetting bll_GainSetting = new PcrNew.BLL.GainSetting();

        private void uiButton1_Click(object sender, EventArgs e)
        {

            if (!uiRadioButton1.Checked && !uiRadioButton2.Checked && !uiRadioButton3.Checked) {
                UIMessageTip.Show(AppCode.NOSELECT_GAIN);
                return;
            }
            PcrNew.Model.GainSetting GainSetting = new PcrNew.Model.GainSetting();
            if (uiRadioButton1.Checked)
            {
                //参考增益
                GainSetting.ID = 1;
                GainSetting.gain = "1";
            }
            else if (uiRadioButton2.Checked)
            {
                //指定增益
                GainSetting.ID = 2;
                GainSetting.gain = "2";
            }
            else if (uiRadioButton3.Checked)
            {
                //自动增益
                GainSetting.ID = 3;
                GainSetting.gain = "3";
            }
          
            GainSetting.F1 = uiDoubleUpDown1.Value.ToString();
            GainSetting.F2 = uiDoubleUpDown3.Value.ToString();
            GainSetting.F3 = uiDoubleUpDown4.Value.ToString();
            GainSetting.F4 = uiDoubleUpDown2.Value.ToString();
            GainSetting.F5 = uiDoubleUpDown5.Value.ToString();
            GainSetting.F6 = uiDoubleUpDown6.Value.ToString();
            bool flg = bll_GainSetting.Update(GainSetting);
            if (flg)
            {
                UIMessageTip.Show(AppCode.INSERT_SUCCESSS);
            }
            else
            {
                UIMessageTip.Show(AppCode.INSERT_ERROR);
            }

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        #region 参考增益
        private void uiRadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (uiRadioButton1.Checked)
            {
                BLL.GainSetting gain = new BLL.GainSetting();
                DataTable data = gain.GetAllList().Tables[0];
                uiDoubleUpDown1.Value = double.Parse(data.Rows[0]["F1"].ToString());
                uiDoubleUpDown3.Value = double.Parse(data.Rows[0]["F2"].ToString());
                uiDoubleUpDown4.Value = double.Parse(data.Rows[0]["F3"].ToString());
                uiDoubleUpDown2.Value = double.Parse(data.Rows[0]["F4"].ToString());
                uiDoubleUpDown5.Value = double.Parse(data.Rows[0]["F5"].ToString());
                uiDoubleUpDown6.Value = double.Parse(data.Rows[0]["F6"].ToString());
            }
           
        }
        #endregion

        #region 指定增益
        private void uiRadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (uiRadioButton2.Checked)
            {
                BLL.GainSetting gain = new BLL.GainSetting();
                DataTable data = gain.GetAllList().Tables[0];
                uiDoubleUpDown1.Value = double.Parse(data.Rows[1]["F1"].ToString());
                uiDoubleUpDown3.Value = double.Parse(data.Rows[1]["F2"].ToString());
                uiDoubleUpDown4.Value = double.Parse(data.Rows[1]["F3"].ToString());
                uiDoubleUpDown2.Value = double.Parse(data.Rows[1]["F4"].ToString());
                uiDoubleUpDown5.Value = double.Parse(data.Rows[1]["F5"].ToString());
                uiDoubleUpDown6.Value = double.Parse(data.Rows[1]["F6"].ToString());
            }
        }
        #endregion

        #region 自动增益
        private void uiRadioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (uiRadioButton3.Checked)
            {
                BLL.GainSetting gain = new BLL.GainSetting();
                DataTable data = gain.GetAllList().Tables[0];
                uiDoubleUpDown1.Value = double.Parse(data.Rows[2]["F1"].ToString());
                uiDoubleUpDown3.Value = double.Parse(data.Rows[2]["F2"].ToString());
                uiDoubleUpDown4.Value = double.Parse(data.Rows[2]["F3"].ToString());
                uiDoubleUpDown2.Value = double.Parse(data.Rows[2]["F4"].ToString());
                uiDoubleUpDown5.Value = double.Parse(data.Rows[2]["F5"].ToString());
                uiDoubleUpDown6.Value = double.Parse(data.Rows[2]["F6"].ToString());
            }
        }
        #endregion
    }
}
