using System;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Net;
using System.Net.Sockets;
using PcrNew.Dbhelper;
using Sunny.UI;
using PcrNew.DBUtility;
using System.Threading;
using static PcrNew.Main;

namespace PcrNew.Pages.Severice
{
    public partial class AddUser : UIForm
    {
        public static int addtype = 0;//进入该界面类型：1 更新 2 修改 3 追加
        public static string ID = "";//修改用户信息的用户ID
        public static string name = "";//修改用户信息的用户名
        public static string Lock = "";
        public static string limit = "";
        public delegate void RefreshDelegate(); // 子窗口声明定义委托 refresh()
        public event RefreshDelegate refresh;

        public AddUser()
        {
            InitializeComponent();
            if (addtype == 1)
            {
                this.Text = "更新用户";
                this.panel1.Visible = false;
                this.panel2.Visible = true;
                this.panel3.Visible = false;
                this.panel4.Visible = false;
                textBox4.Text = name;
                if(Lock == "true")
                {
                    radioButton1.Checked = true;
                }
                else
                {
                    radioButton2.Checked = true;
                }
                if (limit.Contains("1"))
                    checkBox5.Checked = true;
                if (limit.Contains("2"))
                    checkBox6.Checked = true;
                if (limit.Contains("3"))
                    checkBox7.Checked = true;
                if (limit.Contains("4"))
                    checkBox8.Checked = true;
            }
            else if (addtype == 2)
            {
                this.Text = "修改密码";
                this.panel1.Visible = false;
                this.panel2.Visible = false;
                this.panel3.Visible = true;
                this.panel4.Visible = false;
            }
            else if (addtype == 3)
            {
                this.Text = "追加用户";
                this.panel1.Visible = true;
                this.panel2.Visible = false;
                this.panel3.Visible = false;
                this.panel4.Visible = false;
            }
            else if (addtype == 4)
            {
                this.Text = "用户登录";
                this.panel1.Visible = false;
                this.panel2.Visible = false;
                this.panel3.Visible = false;
                this.panel4.Visible = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String name = lab_dep.Text;
            String password = textBox1.Text;
            String ispassword = textBox2.Text;
            //获取当前电脑IP
            string localIP;
            using (Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, 0))
            {
                socket.Connect("8.8.8.8", 65530);
                IPEndPoint endPoint = socket.LocalEndPoint as IPEndPoint;
                localIP = endPoint.Address.ToString();
            }

            String power = "";
            String powerCh = "";
            if (password != ispassword)
            {
                UIMessageTip.Show(AppCode.Re_enter);
                return;
            }
            DAL.AllTestItem AllTestItemDal = new DAL.AllTestItem();  //声明对象
            bool issame = AllTestItemDal.GetUserName(lab_dep.Text);//判断用户名和密码是否正确
            if (issame)
            {
                textBox1.Text = "";
                textBox2.Text = "";
                lab_dep.Text = "";
                UIMessageTip.Show(AppCode.user_obtion);
                return;
            }

            if (checkBox1.Checked)
            {
                power += "1";
                powerCh += checkBox1.Text;
            }
            if (checkBox2.Checked)
            {
                power += "2";
                powerCh += "," + checkBox2.Text;
            }
            if (checkBox3.Checked)
            {
                power += "3";
                powerCh += "," + checkBox3.Text;
            }
            if (checkBox4.Checked)
            {
                power += "4";
                powerCh += "," + checkBox4.Text;
            }
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into department");
            strSql.Append("(username,[Password],CreateTime,LastLoginIP,Limits,LimitsCH)");//Password为一个关键字，需使用[]括起来
            strSql.Append(" values (");
            strSql.Append("@username,@password,@CreateTime,@LastLoginIP,@Limits,@LimitsCH)");
            OleDbParameter[] parameters = {
                    new OleDbParameter("@username", OleDbType.VarChar,255),
            new OleDbParameter("@password", OleDbType.VarChar,255),
            new OleDbParameter("@CreateTime", OleDbType.VarChar,255),
            new OleDbParameter("@LastLoginIP", OleDbType.VarChar,255),
            new OleDbParameter("@Limits", OleDbType.VarChar,255),
            new OleDbParameter("@LimitsCH", OleDbType.VarChar, 255) };
            parameters[0].Value =lab_dep.Text;
            parameters[1].Value = MD5.Encrypt(password);
            parameters[2].Value =DateTime.Now.ToString();
            parameters[3].Value =localIP ;
            parameters[4].Value =power;
            parameters[5].Value = powerCh;

            int rows = DbHelperOleDb.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                UIMessageTip.Show(AppCode.INSERT_SUCCESSS);
                Close();
            }
            else
            {
                UIMessageTip.Show(AppCode.INSERT_ERROR);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void AddUser_Load(object sender, EventArgs e)
        {
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            addtype = 0;//进入该界面类型：1 更新 2 修改 3 追加
            ID = "";//修改用户信息的用户ID
            name = "";//修改用户信息的用户名
            Lock = "";
            limit = "";
            Close();
        }

        private void button7_Click(object sender, EventArgs e)//用户登录
        {
            if(string.IsNullOrEmpty(textBox7.Text) || String.IsNullOrEmpty(textBox8.Text) || string.IsNullOrEmpty(comboBox1.Text))
            {
                textBox7.Text = "";
                textBox8.Text = "";
                UIMessageTip.Show(AppCode.user_empty);
                return;
            }
            DAL.AllTestItem AllTestItemDal = new DAL.AllTestItem();  //声明对象
            bool issuccess = AllTestItemDal.GetUserList(textBox8.Text, MD5.Encrypt(textBox7.Text));//判断用户名和密码是否正确
            Main.NowUsername = textBox8.Text;
            if (issuccess)
            {
                bool LoginSucceeded = AllTestItemDal.UpdateUserIP(comboBox1.Text, textBox8.Text , DateTime.Now.ToString());//更新最近登录时间
                if (LoginSucceeded)
                {
                    UIMessageTip.Show(AppCode.Login_SUCCESS);
                    this.refresh();
                    Close();
                }
                else
                {
                    UIMessageTip.Show(AppCode.Login_ERROR);
                    Close();
                }
            }
            else
            {
                textBox7.Text = "";
                textBox8.Text = "";
                UIMessageTip.Show(AppCode.user_obtion);
                return;
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if(textBox5.Text != textBox6.Text)
            {
                UIMessageTip.Show(AppCode.Re_enter);
                return;
            }
            String name = "111";
            DAL.AllTestItem AllTestItemDal = new DAL.AllTestItem();  //声明对象
            bool issuccess = AllTestItemDal.GetUserList(name, MD5.Encrypt(textBox3.Text));//判断用户名和密码是否正确
            if (issuccess)
            {
                bool ischange = AllTestItemDal.UpdateUserPowered(MD5.Encrypt(textBox5.Text), name);
                if (ischange)
                {
                    UIMessageTip.Show(AppCode.UPDATE_SUCCESSS);
                }
                else
                {
                    UIMessageTip.Show(AppCode.UPDATE_ERROR);
                }
            }
            else
            {
                UIMessageTip.Show(AppCode.Re_enter);
                return;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DAL.AllTestItem AllTestItemDal = new DAL.AllTestItem();  //声明对象
            bool u = false;
            if (radioButton1.Checked)
                u = true;
            else
                u = false;
            limit = "";
            String limitCh = "";
            if (checkBox5.Checked)
            {
                limit += "1";
                limitCh += checkBox5.Text;
            }
            if (checkBox6.Checked)
            {
                limit += "2";
                limitCh += "," + checkBox6.Text;
            }
            if (checkBox7.Checked)
            {
                limit += "3";
                limitCh += "," + checkBox7.Text;
            }
            if (checkBox8.Checked)
            {
                limit += "4";
                limitCh += "," + checkBox8.Text;
            }
            int id = Convert.ToInt32(ID);
            bool issuccess = AllTestItemDal.UpdateUser(id, textBox4.Text, u,limit,limitCh);//判断是否修改成功
            if (issuccess)
            {
                UIMessageTip.Show(AppCode.UPDATE_SUCCESSS);
                addtype = 0;//进入该界面类型：1 更新 2 修改 3 追加
                ID = "";//修改用户信息的用户ID
                name = "";//修改用户信息的用户名
                Lock = "";
                limit = "";
                Close();
            }
            else
                UIMessageTip.Show(AppCode.UPDATE_ERROR);
        }

        private void checkBox8_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
