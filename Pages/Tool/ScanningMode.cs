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
    public partial class ScanningMode : UIForm
    {
        public ScanningMode()
        {
            InitializeComponent();
            initdata();
        }

        private void uiCheckBox8_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void uiCheckBox7_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void uiButton2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }


        private PcrNew.BLL.ModuleScan bll_ModuleScan = new PcrNew.BLL.ModuleScan();

        private void uiButton1_Click(object sender, EventArgs e)
        {
            PcrNew.Model.ModuleScan ModuleScan = new PcrNew.Model.ModuleScan();
            ModuleScan.ID = 1;
            ModuleScan.ScanMode = uiRadioButton1.Checked == true ? 1 : 2;//1代表整版扫描 2代表分行扫描
            string check_ok = "";
            if (uiCheckBox1.Checked) {
                check_ok += "A,";
            }
            if (uiCheckBox2.Checked)
            {
                check_ok += "B,";
            }
            if (uiCheckBox3.Checked)
            {
                check_ok += "C,";
            }
            if (uiCheckBox4.Checked)
            {
                check_ok += "D,";
            }
            if (uiCheckBox5.Checked)
            {
                check_ok += "E,";
            }
            if (uiCheckBox6.Checked)
            {
                check_ok += "F,";
            }
            if (uiCheckBox7.Checked)
            {
                check_ok += "G,";
            }
            if (uiCheckBox8.Checked)
            {
                check_ok += "H,";
            }
            ModuleScan.deep = check_ok;
            bool flg = bll_ModuleScan.Update(ModuleScan);
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
        /// 复选框状态显示
        /// </summary>
        /// <param name="state"></param>
        void check_groug(Boolean state) {
            uiCheckBox1.Checked = state;
            uiCheckBox2.Checked = state;
            uiCheckBox3.Checked = state;
            uiCheckBox4.Checked = state;
            uiCheckBox5.Checked = state;
            uiCheckBox6.Checked = state;
            uiCheckBox7.Checked = state;
            uiCheckBox8.Checked = state;
        }

        private void uiRadioButton1_CheckedChanged_1(object sender, EventArgs e)
        {
            if (uiRadioButton1.Checked == true)
            {
                check_groug(true);
            }
            else
            {
                check_groug(false);
            }
        }

        void initdata() {
            BLL.ModuleScan module = new BLL.ModuleScan();
            DataTable data = module.GetAllList().Tables[0];
            if (data.Rows[0]["ScanMode"].ToString().Equals("1"))
            {
                uiRadioButton1.Checked = true;//整行扫描
            }
            else {
                uiRadioButton2.Checked = true;//分行扫描
                string[] sArray = data.Rows[0]["deep"].ToString().Split(',');
                for (int i = 0;i< sArray.Length;i++) {
                    if (sArray[i] == "A") {
                        uiCheckBox1.Checked = true;
                    }
                    if (sArray[i] == "B")
                    {
                        uiCheckBox2.Checked = true;
                    }
                    if (sArray[i] == "C")
                    {
                        uiCheckBox3.Checked = true;
                    }
                    if (sArray[i] == "D")
                    {
                        uiCheckBox4.Checked = true;
                    }
                    if (sArray[i] == "E")
                    {
                        uiCheckBox5.Checked = true;
                    }
                    if (sArray[i] == "F")
                    {
                        uiCheckBox6.Checked = true;
                    }
                    if (sArray[i] == "G")
                    {
                        uiCheckBox7.Checked = true;
                    }
                    if (sArray[i] == "H")
                    {
                        uiCheckBox8.Checked = true;
                    }

                }

            }
        }
    }
}
