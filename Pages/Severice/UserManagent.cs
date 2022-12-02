using PcrNew.DBUtility;
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

namespace PcrNew.Pages.Severice
{
    public partial class UserManagent : UIForm
    {

        public UserManagent()
        {
            InitializeComponent();
            SelectAllUser(dataGridView1);
        }

        public static void SelectAllUser(DataGridView dataGridView)
        {
            //刷新界面数据
            DAL.AllTestItem AllTestItemDal = new DAL.AllTestItem();  //声明对象
            dataGridView.DataSource = AllTestItemDal.GetUserAll().Tables[0];
            if (dataGridView.DataSource != null)
            {
                dataGridView.Columns[0].HeaderText = "ID";
                dataGridView.Columns[1].HeaderText = "用户名";
                dataGridView.Columns[2].HeaderText = "是否禁用账户";
                dataGridView.Columns[3].HeaderText = "账户是否被锁定";
                dataGridView.Columns[4].HeaderText = "创建时间";
                dataGridView.Columns[5].HeaderText = "最近登录时间";
                dataGridView.Columns[6].HeaderText = "权限";
                dataGridView.Columns[7].HeaderText = "权限1";
                //dataGridView.Columns[1].Width = 150;
                //dataGridView.Columns[4].Width = 200;
                //dataGridView.Columns[5].Width = 200;
                //dataGridView.Columns[7].Width = 450;
                dataGridView.Columns[0].Visible = false;
                dataGridView.Columns[6].Visible = false;
            }
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void UserManagent_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
            AddUser.addtype = 3;
            new AddUser().ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int number = dataGridView1.SelectedRows.Count;//获取选中总行数
            if (number != 1)
            {
                MessageBox.Show("请选择一行信息进行操作", "信息提示");
                return;
            }
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (dataGridView1.Rows[i].Selected == true)
                {
                    String selectID = dataGridView1.Rows[i].Cells[0].Value.ToString();//被选中行的ID
                    string selectname = dataGridView1.Rows[i].Cells[1].Value.ToString();//被选中行的名字
                    string selectLock = dataGridView1.Rows[i].Cells[2].Value.ToString();//被选中行的锁定
                    string selectLimit = dataGridView1.Rows[i].Cells[6].Value.ToString();//权限
                    AddUser.ID = selectID;
                    AddUser.name = selectname;
                    AddUser.Lock = selectLock;
                    AddUser.limit = selectLimit;
                }
            }
            Close();
            AddUser.addtype = 1;
            new AddUser().ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
            AddUser.addtype = 2;
            new AddUser().ShowDialog();
        }
    }
}
