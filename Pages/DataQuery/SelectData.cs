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

namespace PcrNew.Pages.DataQuery
{
    public partial class SelectData : UIForm
    {
        public string sename = "";//选择的当前查询条件
        public SelectData()
        {
            InitializeComponent();
            Empty();

        }

        //显示控件
        public void Display()
        {
            textBox1.Visible = false;
            dateTimePicker1.Visible = false;
            numericUpDown1.Visible = false;
            textBox2.Visible = false;
            dateTimePicker2.Visible = false;
            numericUpDown2.Visible = false;
            textBox3.Visible = false;
            dateTimePicker3.Visible = false;
            numericUpDown3.Visible = false;
            textBox5.Visible = false;
            dateTimePicker5.Visible = false;
            numericUpDown5.Visible = false;
            textBox6.Visible = false;
            dateTimePicker6.Visible = false;
            numericUpDown6.Visible = false;
            textBox7.Visible = false;
            dateTimePicker7.Visible = false;
            numericUpDown7.Visible = false;
        }

        //清空列表
        public void Empty()
        {
            textBox1.Text = "";
            dateTimePicker1.Text = "";
            numericUpDown1.Text = "";
            textBox2.Text = "";
            dateTimePicker2.Text = "";
            numericUpDown2.Text = "";
            textBox3.Text = "";
            dateTimePicker3.Text = "";
            numericUpDown3.Text = "";
            textBox5.Text = "";
            dateTimePicker5.Text = "";
            numericUpDown5.Text = "";
            textBox6.Text = "";
            dateTimePicker6.Text = "";
            numericUpDown6.Text = "";
            textBox7.Text = "";
            dateTimePicker7.Text = "";
            numericUpDown7.Text = "";
            comboBox1.Text = "";
            comboBox3.Text = "";
            comboBox5.Text = "";
            comboBox10.Text = "";
            comboBox12.Text = "";
        }


        private void SelectData_Load(object sender, EventArgs e)
        {

        }

        private void SelectData_Load_1(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            comboBox7.Text = "";
            comboBox7.Items.Clear();
            textBox1.Text = "";
            dateTimePicker1.Text = "";
            numericUpDown1.Text = "";
            if (comboBox1.Text == "采样时间" || comboBox1.Text == "送检日期")
            {
                comboBox7.Items.AddRange(new object[] { "=", "<", "<=", ">", ">=" });
                textBox1.Visible = false;//条件一的输入框
                dateTimePicker1.Visible = true;//条件一的时间选择框
                numericUpDown1.Visible = false;//条件一的数字框
            }
            else if (comboBox1.Text == "")
            {
                comboBox7.Items.AddRange(new object[] { "=", "like" });
                textBox1.Visible = false;
                dateTimePicker1.Visible = false;
                numericUpDown1.Visible = false;
            }
            else if (comboBox1.Text == "检测结果" || comboBox1.Text == "参考值" || comboBox1.Text == "标准品浓度" || comboBox1.Text == "Ct值")
            {
                comboBox7.Items.AddRange(new object[] { "=", "<", "<=", ">", ">=" });
                textBox1.Visible = false;
                dateTimePicker1.Visible = false;
                numericUpDown1.Visible = true;
            }
            else
            {
                comboBox7.Items.AddRange(new object[] { "=", "like" });
                textBox1.Visible = true;
                dateTimePicker1.Visible = false;
                numericUpDown1.Visible = false;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            comboBox2.Text = "";
            comboBox2.Items.Clear();
            textBox2.Text = "";
            dateTimePicker2.Text = "";
            numericUpDown2.Text = "";
            if (comboBox3.Text == "采样时间" || comboBox3.Text == "送检日期")
            {
                comboBox2.Items.AddRange(new object[] { "=", "<", "<=", ">", ">=" });
                textBox2.Visible = false;//条件二的输入框
                dateTimePicker2.Visible = true;//条件二的时间选择框
                numericUpDown2.Visible = false;//条件二的数字框
            }
            else if (comboBox3.Text == "")
            {
                comboBox2.Items.AddRange(new object[] { "=", "like" });
                textBox2.Visible = false;
                dateTimePicker2.Visible = false;
                numericUpDown2.Visible = false;
            }
            else if (comboBox3.Text == "检测结果" || comboBox3.Text == "参考值" || comboBox3.Text == "标准品浓度" || comboBox3.Text == "Ct值")
            {
                comboBox2.Items.AddRange(new object[] { "=", "<", "<=", ">", ">=" });
                textBox2.Visible = false;
                dateTimePicker2.Visible = false;
                numericUpDown2.Visible = true;
            }
            else
            {
                comboBox2.Items.AddRange(new object[] { "=", "like" });
                textBox2.Visible = true;
                dateTimePicker2.Visible = false;
                numericUpDown2.Visible = false;
            }
        }

        private void comboBox5_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            comboBox4.Text = "";
            comboBox4.Items.Clear();
            textBox3.Text = "";
            dateTimePicker3.Text = "";
            numericUpDown3.Text = "";
            if (comboBox5.Text == "采样时间" || comboBox5.Text == "送检日期")
            {
                comboBox4.Items.AddRange(new object[] { "=", "<", "<=", ">", ">=" });
                textBox3.Visible = false;//条件三的输入框
                dateTimePicker3.Visible = true;//条件三的时间选择框
                numericUpDown3.Visible = false;//条件三的数字框
            }
            else if (comboBox5.Text == "")
            {
                comboBox4.Items.AddRange(new object[] { "=", "like" });
                textBox3.Visible = false;
                dateTimePicker3.Visible = false;
                numericUpDown3.Visible = false;
            }
            else if (comboBox5.Text == "检测结果" || comboBox5.Text == "参考值" || comboBox5.Text == "标准品浓度" || comboBox5.Text == "Ct值")
            {
                comboBox4.Items.AddRange(new object[] { "=", "<", "<=", ">", ">=" });
                textBox3.Visible = false;
                dateTimePicker3.Visible = false;
                numericUpDown3.Visible = true;
            }
            else
            {
                comboBox4.Items.AddRange(new object[] { "=", "like" });
                textBox3.Visible = true;
                dateTimePicker3.Visible = false;
                numericUpDown3.Visible = false;
            }
        }

        private void comboBox4_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            comboBox9.Text = "";
            comboBox9.Items.Clear();
            textBox5.Text = "";
            dateTimePicker5.Text = "";
            numericUpDown5.Text = "";
            if (comboBox10.Text == "采样时间" || comboBox10.Text == "送检日期")
            {
                comboBox9.Items.AddRange(new object[] { "=", "<", "<=", ">", ">=" });
                textBox5.Visible = false;//条件四的输入框
                dateTimePicker5.Visible = true;//条件四的时间选择框
                numericUpDown5.Visible = false;//条件四的数字框
            }
            else if (comboBox10.Text == "")
            {
                comboBox9.Items.AddRange(new object[] { "=", "like" });
                textBox5.Visible = false;
                dateTimePicker5.Visible = false;
                numericUpDown5.Visible = false;
            }
            else if (comboBox10.Text == "检测结果" || comboBox10.Text == "参考值" || comboBox10.Text == "标准品浓度" || comboBox10.Text == "Ct值")
            {
                comboBox9.Items.AddRange(new object[] { "=", "<", "<=", ">", ">=" });
                textBox5.Visible = false;
                dateTimePicker5.Visible = false;
                numericUpDown5.Visible = true;
            }
            else
            {
                comboBox9.Items.AddRange(new object[] { "=", "like" });
                textBox5.Visible = true;
                dateTimePicker5.Visible = false;
                numericUpDown5.Visible = false;
            }
        }

        private void comboBox2_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            comboBox11.Text = "";
            comboBox11.Items.Clear();
            textBox6.Text = "";
            dateTimePicker6.Text = "";
            numericUpDown6.Text = "";
            if (comboBox12.Text == "采样时间" || comboBox12.Text == "送检日期")
            {
                comboBox11.Items.AddRange(new object[] { "=", "<", "<=", ">", ">=" });
                textBox6.Visible = false;//条件五的输入框
                dateTimePicker6.Visible = true;//条件五的时间选择框
                numericUpDown6.Visible = false;//条件五的数字框
            }
            else if (comboBox12.Text == "")
            {
                comboBox11.Items.AddRange(new object[] { "=", "like" });
                textBox6.Visible = false;
                dateTimePicker6.Visible = false;
                numericUpDown6.Visible = false;
            }
            else if (comboBox12.Text == "检测结果" || comboBox12.Text == "参考值" || comboBox12.Text == "标准品浓度" || comboBox12.Text == "Ct值")
            {
                comboBox11.Items.AddRange(new object[] { "=", "<", "<=", ">", ">=" });
                textBox6.Visible = false;
                dateTimePicker6.Visible = false;
                numericUpDown6.Visible = true;
            }
            else
            {
                comboBox11.Items.AddRange(new object[] { "=", "like" });
                textBox6.Visible = true;
                dateTimePicker6.Visible = false;
                numericUpDown6.Visible = false;
            }
        }

        private void comboBox6_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            comboBox13.Text = "";
            comboBox13.Items.Clear();
            textBox7.Text = "";
            dateTimePicker7.Text = "";
            numericUpDown7.Text = "";
            if (comboBox14.Text == "采样时间" || comboBox14.Text == "送检日期")
            {
                comboBox13.Items.AddRange(new object[] { "=", "<", "<=", ">", ">=" });
                textBox7.Visible = false;//条件六的输入框
                dateTimePicker7.Visible = true;//条件六的时间选择框
                numericUpDown7.Visible = false;//条件六的数字框
            }
            else if (comboBox14.Text == "")
            {
                comboBox13.Items.AddRange(new object[] { "=", "like" });
                textBox7.Visible = false;
                dateTimePicker7.Visible = false;
                numericUpDown7.Visible = false;
            }
            else if (comboBox14.Text == "检测结果" || comboBox14.Text == "参考值" || comboBox14.Text == "标准品浓度" || comboBox14.Text == "Ct值")
            {
                comboBox13.Items.AddRange(new object[] { "=", "<", "<=", ">", ">=" });
                textBox7.Visible = false;
                dateTimePicker7.Visible = false;
                numericUpDown7.Visible = true;
            }
            else
            {
                comboBox13.Items.AddRange(new object[] { "=", "like" });
                textBox7.Visible = true;
                dateTimePicker7.Visible = false;
                numericUpDown7.Visible = false;
            }
        }

        private void uiButton1_Click(object sender, EventArgs e)
        {
            Empty();
        }

        private void uiButton2_Click(object sender, EventArgs e)
        {
            string[] a = new string[6];
            sename = "";//选择的当前查询条件
            foreach (Control item in groupBox3.Controls)
            {
                if(item.Text == "文件名")
                {
                    a[0] = "AND FileName ";
                    sename = item.Text;
                }
                else if(item.Text == "样本ID")
                {
                    a[0] = "AND SampleID ";
                    sename = item.Text;
                }
                else if(item.Text == "样本名称")
                {
                    a[0] = "AND SampleName ";
                    sename = item.Text;
                }
                else if (item.Text == "检测项目")
                {
                    a[0] = "AND TestItems ";
                    sename = item.Text;
                }
                else if (item.Text == "采样时间")
                {
                    a[0] = "AND SamplingTime ";
                    sename = item.Text;
                }
                else if (item.Text == "检测结果")
                {
                    a[0] = "AND DetectionResult ";
                    sename = item.Text;
                }
                else if (item.Text == "参考值")
                {
                    a[0] = "AND ReferenceValue ";
                    sename = item.Text;
                }
                else if (item.Text == "标准品浓度")
                {
                    a[0] = "AND StandardConcentration ";
                    sename = item.Text;
                }
                else if (item.Text == "浓度单位")
                {
                    a[0] = "AND ConcentrationUnit ";
                    sename = item.Text;
                }
                else if (item.Text == "结论")
                {
                    a[0] = "AND Conclusion ";
                    sename = item.Text;
                }
                else if (item.Text == "Ct值")
                {
                    a[0] = "AND Ct ";
                    sename = item.Text;
                }
                else if (item.Text == "检验者")
                {
                    a[0] = "AND Examiner ";
                    sename = item.Text;
                }
                else if (item.Text == "送检日期")
                {
                    a[0] = "AND SubmissionTime ";
                    sename = item.Text;
                }
                else if (item.Text == "报告名称")
                {
                    a[0] = "AND ReportName ";
                    sename = item.Text;
                }
                else if (item.Text == "备注")
                {
                    a[0] = "AND Notes ";
                    sename = item.Text;
                }
                else if (item.Text == "审核者")
                {
                    a[0] = "AND Reviewer ";
                    sename = item.Text;
                }
                else if (item.Text == "化验项")
                {
                    a[0] = " AND Analysis ";
                    sename = item.Text;
                }
                else if(item.Text == "=" || item.Text == "<" || item.Text == "like" || item.Text == "<=" || item.Text == ">" || item.Text == ">=")
                {
                    a[0] = a[0] + item.Text + " ";
                }
                else if (item.Text == "" && item is ComboBox)
                {
                    a[0] = "";
                }

                if (item is TextBox || item is DateTimePicker || item is NumericUpDown)
                {
                    if(sename == "采样时间" || sename == "送检日期")
                    {
                        if(item is DateTimePicker )
                        {
                            if (!string.IsNullOrEmpty(item.Text) && a[0] != "")
                            {
                                if (a[0].Contains("like"))
                                {
                                    a[0] = a[0] + "'%" + item.Text + "%'";
                                }
                                else
                                {
                                    a[0] = a[0] + "'" + item.Text + "'";
                                }
                            }
                               
                            else
                                a[0] = "";
                        }
                    }
                    else if(sename == "检测结果" || sename == "参考值" || sename == "标准品浓度" || sename == "Ct值")
                    {
                        if(item is NumericUpDown )
                        {
                            if (!string.IsNullOrEmpty(item.Text) && a[0] != "")
                            {
                                if (a[0].Contains("like"))
                                {
                                    a[0] = a[0] + "'%" + item.Text + "%'";
                                }
                                else
                                {
                                    a[0] = a[0] + "'" + item.Text + "'";
                                }
                            }
                            else
                                a[0] = "";
                        }
                    }
                    else
                    {
                        if (item is TextBox)
                        {
                            if (!string.IsNullOrEmpty(item.Text) && a[0] != "")
                            {
                                if (a[0].Contains("like"))
                                {
                                    a[0] = a[0] + "'%" + item.Text + "%'";
                                }
                                else
                                {
                                    a[0] = a[0] + "'" + item.Text + "'";
                                }
                            }
                            else
                                a[0] = "";
                        }
                    }
                }
            }
            sename = "";
            foreach (Control item in groupBox4.Controls)
            {
                if (item.Text == "文件名")
                {
                    a[1] = "AND FileName ";
                    sename = item.Text;
                }
                else if (item.Text == "样本ID")
                {
                    a[1] = "AND SampleID ";
                    sename = item.Text;
                }
                else if (item.Text == "样本名称")
                {
                    a[1] = "AND SampleName ";
                    sename = item.Text;
                }
                else if (item.Text == "检测项目")
                {
                    a[1] = "AND TestItems ";
                    sename = item.Text;
                }
                else if (item.Text == "采样时间")
                {
                    a[1] = "AND SamplingTime ";
                    sename = item.Text;
                }
                else if (item.Text == "检测结果")
                {
                    a[1] = "AND DetectionResult ";
                    sename = item.Text;
                }
                else if (item.Text == "参考值")
                {
                    a[1] = "AND ReferenceValue ";
                    sename = item.Text;
                }
                else if (item.Text == "标准品浓度")
                {
                    a[1] = "AND StandardConcentration ";
                    sename = item.Text;
                }
                else if (item.Text == "浓度单位")
                {
                    a[1] = "AND ConcentrationUnit ";
                    sename = item.Text;
                }
                else if (item.Text == "结论")
                {
                    a[1] = "AND Conclusion ";
                    sename = item.Text;
                }
                else if (item.Text == "Ct值")
                {
                    a[1] = "AND Ct ";
                    sename = item.Text;
                }
                else if (item.Text == "检验者")
                {
                    a[1] = "AND Examiner ";
                    sename = item.Text;
                }
                else if (item.Text == "送检日期")
                {
                    a[1] = "AND SubmissionTime ";
                    sename = item.Text;
                }
                else if (item.Text == "报告名称")
                {
                    a[1] = "AND ReportName ";
                    sename = item.Text;
                }
                else if (item.Text == "备注")
                {
                    a[1] = "AND Notes ";
                    sename = item.Text;
                }
                else if (item.Text == "审核者")
                {
                    a[1] = "AND Reviewer ";
                    sename = item.Text;
                }
                else if (item.Text == "化验项")
                {
                    a[1] = " AND Analysis ";
                    sename = item.Text;
                }
                else if (item.Text == "=" || item.Text == "like" || item.Text == "<" || item.Text == "<=" || item.Text == ">" || item.Text == ">=")
                {
                    a[1] = a[1] + item.Text + " ";
                }
                else if (item.Text == null && item is ComboBox)
                {
                    a[1] = "";
                }

                if (item is TextBox || item is DateTimePicker || item is NumericUpDown)
                {
                    if (sename == "采样时间" || sename == "送检日期")
                    {
                        if (item is DateTimePicker)
                        {
                            if (!string.IsNullOrEmpty(item.Text) && a[1] != "")
                            {
                                if (a[1].Contains("like"))
                                {
                                    a[1] = a[1] + "'%" + item.Text + "%'";
                                }
                                else
                                {
                                    a[1] = a[1] + "'" + item.Text + "'";
                                }
                            }
                            else
                                a[1] = "";
                        }
                    }
                    else if (sename == "检测结果" || sename == "参考值" || sename == "标准品浓度" || sename == "Ct值")
                    {
                        if (item is NumericUpDown)
                        {
                            if (!string.IsNullOrEmpty(item.Text) && a[1] != "")
                            {
                                if (a[1].Contains("like"))
                                {
                                    a[1] = a[1] + "'%" + item.Text + "%'";
                                }
                                else
                                {
                                    a[1] = a[1] + "'" + item.Text + "'";
                                }
                            }
                            else
                                a[1] = "";
                        }
                    }
                    else
                    {
                        if (item is TextBox)
                        {
                            if (!string.IsNullOrEmpty(item.Text) && a[1] != "")
                            {
                                if (a[1].Contains("like"))
                                {
                                    a[1] = a[1] + "'%" + item.Text + "%'";
                                }
                                else
                                {
                                    a[1] = a[1] + "'" + item.Text + "'";
                                }
                            }
                            else
                                a[1] = "";
                        }
                    }
                }
            }
            sename = "";
            foreach (Control item in groupBox5.Controls)
            {
                if (item.Text == "文件名")
                {
                    a[2] = "AND FileName ";
                    sename = item.Text;
                }
                else if (item.Text == "样本ID")
                {
                    a[2] = "AND SampleID ";
                    sename = item.Text;
                }
                else if (item.Text == "样本名称")
                {
                    a[2] = "AND SampleName ";
                    sename = item.Text;
                }
                else if (item.Text == "检测项目")
                {
                    a[2] = "AND TestItems ";
                    sename = item.Text;
                }
                else if (item.Text == "采样时间")
                {
                    a[2] = "AND SamplingTime ";
                    sename = item.Text;
                }
                else if (item.Text == "检测结果")
                {
                    a[2] = "AND DetectionResult ";
                    sename = item.Text;
                }
                else if (item.Text == "参考值")
                {
                    a[2] = "AND ReferenceValue ";
                    sename = item.Text;
                }
                else if (item.Text == "标准品浓度")
                {
                    a[2] = "AND StandardConcentration ";
                    sename = item.Text;
                }
                else if (item.Text == "浓度单位")
                {
                    a[2] = "AND ConcentrationUnit ";
                    sename = item.Text;
                }
                else if (item.Text == "结论")
                {
                    a[2] = "AND Conclusion ";
                    sename = item.Text;
                }
                else if (item.Text == "Ct值")
                {
                    a[2] = "AND Ct ";
                    sename = item.Text;
                }
                else if (item.Text == "检验者")
                {
                    a[2] = "AND Examiner ";
                    sename = item.Text;
                }
                else if (item.Text == "送检日期")
                {
                    a[2] = "AND SubmissionTime ";
                    sename = item.Text;
                }
                else if (item.Text == "报告名称")
                {
                    a[2] = "AND ReportName ";
                    sename = item.Text;
                }
                else if (item.Text == "备注")
                {
                    a[2] = "AND Notes ";
                    sename = item.Text;
                }
                else if (item.Text == "审核者")
                {
                    a[2] = "AND Reviewer ";
                    sename = item.Text;
                }
                else if (item.Text == "化验项")
                {
                    a[2] = " AND Analysis ";
                    sename = item.Text;
                }
                else if (item.Text == "=" || item.Text == "like" || item.Text == "<" || item.Text == "<=" || item.Text == ">" || item.Text == ">=")
                {
                    a[2] = a[2] + item.Text + " ";
                }
                else if (item.Text == null && item is ComboBox)
                {
                    a[2] = "";
                }

                if (item is TextBox || item is DateTimePicker || item is NumericUpDown)
                {
                    if (sename == "采样时间" || sename == "送检日期")
                    {
                        if (item is DateTimePicker)
                        {
                            if (!string.IsNullOrEmpty(item.Text) && a[2] != "")
                            {
                                if (a[2].Contains("like"))
                                {
                                    a[2] = a[2] + "'%" + item.Text + "%'";
                                }
                                else
                                {
                                    a[2] = a[2] + "'" + item.Text + "'";
                                }
                            }
                            else
                                a[2] = "";
                        }
                    }
                    else if (sename == "检测结果" || sename == "参考值" || sename == "标准品浓度" || sename == "Ct值")
                    {
                        if (item is NumericUpDown)
                        {
                            if (!string.IsNullOrEmpty(item.Text) && a[2] != "")
                            {
                                if (a[2].Contains("like"))
                                {
                                    a[2] = a[2] + "'%" + item.Text + "%'";
                                }
                                else
                                {
                                    a[2] = a[2] + "'" + item.Text + "'";
                                }
                            }
                            else
                                a[2] = "";
                        }
                    }
                    else
                    {
                        if (item is TextBox)
                        {
                            if (!string.IsNullOrEmpty(item.Text) && a[2] != "")
                            {
                                if (a[2].Contains("like"))
                                {
                                    a[2] = a[2] + "'%" + item.Text + "%'";
                                }
                                else
                                {
                                    a[2] = a[2] + "'" + item.Text + "'";
                                }
                            }
                            else
                                a[2] = "";
                        }
                    }
                }
            }
            sename = "";
            foreach (Control item in groupBox7.Controls)
            {
                if (item.Text == "文件名")
                {
                    a[3] = "AND FileName ";
                    sename = item.Text;
                }
                else if (item.Text == "样本ID")
                {
                    a[3] = "AND SampleID ";
                    sename = item.Text;
                }
                else if (item.Text == "样本名称")
                {
                    a[3] = "AND SampleName ";
                    sename = item.Text;
                }
                else if (item.Text == "检测项目")
                {
                    a[3] = "AND TestItems ";
                    sename = item.Text;
                }
                else if (item.Text == "采样时间")
                {
                    a[3] = "AND SamplingTime ";
                    sename = item.Text;
                }
                else if (item.Text == "检测结果")
                {
                    a[3] = "AND DetectionResult ";
                    sename = item.Text;
                }
                else if (item.Text == "参考值")
                {
                    a[3] = "AND ReferenceValue ";
                    sename = item.Text;
                }
                else if (item.Text == "标准品浓度")
                {
                    a[3] = "AND StandardConcentration ";
                    sename = item.Text;
                }
                else if (item.Text == "浓度单位")
                {
                    a[3] = "AND ConcentrationUnit ";
                    sename = item.Text;
                }
                else if (item.Text == "结论")
                {
                    a[3] = "AND Conclusion ";
                    sename = item.Text;
                }
                else if (item.Text == "Ct值")
                {
                    a[3] = "AND Ct ";
                    sename = item.Text;
                }
                else if (item.Text == "检验者")
                {
                    a[3] = "AND Examiner ";
                    sename = item.Text;
                }
                else if (item.Text == "送检日期")
                {
                    a[3] = "AND SubmissionTime ";
                    sename = item.Text;
                }
                else if (item.Text == "报告名称")
                {
                    a[3] = "AND ReportName ";
                    sename = item.Text;
                }
                else if (item.Text == "备注")
                {
                    a[3] = "AND Notes ";
                    sename = item.Text;
                }
                else if (item.Text == "审核者")
                {
                    a[3] = "AND Reviewer ";
                    sename = item.Text;
                }
                else if (item.Text == "化验项")
                {
                    a[3] = " AND Analysis ";
                    sename = item.Text;
                }
                else if (item.Text == "=" || item.Text == "like" || item.Text == "<" || item.Text == "<=" || item.Text == ">" || item.Text == ">=")
                {
                    a[3] = a[3] + item.Text + " ";
                }
                else if (item.Text == null && item is ComboBox)
                {
                    a[3] = "";
                }

                if (item is TextBox || item is DateTimePicker || item is NumericUpDown)
                {
                    if (sename == "采样时间" || sename == "送检日期")
                    {
                        if (item is DateTimePicker)
                        {
                            if (!string.IsNullOrEmpty(item.Text) && a[3] != "")
                            {
                                if (a[3].Contains("like"))
                                {
                                    a[3] = a[3] + "'%" + item.Text + "%'";
                                }
                                else
                                {
                                    a[3] = a[3] + "'" + item.Text + "'";
                                }
                            }
                            else
                                a[3] = "";
                        }
                    }
                    else if (sename == "检测结果" || sename == "参考值" || sename == "标准品浓度" || sename == "Ct值")
                    {
                        if (item is NumericUpDown)
                        {
                            if (!string.IsNullOrEmpty(item.Text) && a[3] != "")
                            {
                                if (a[3].Contains("like"))
                                {
                                    a[3] = a[3] + "'%" + item.Text + "%'";
                                }
                                else
                                {
                                    a[3] = a[3] + "'" + item.Text + "'";
                                }
                            }
                            else
                                a[3] = "";
                        }
                    }
                    else
                    {
                        if (item is TextBox)
                        {
                            if (!string.IsNullOrEmpty(item.Text) && a[3] != "")
                            {
                                if (a[3].Contains("like"))
                                {
                                    a[3] = a[3] + "'%" + item.Text + "%'";
                                }
                                else
                                {
                                    a[3] = a[3] + "'" + item.Text + "'";
                                }
                            }
                            else
                                a[3] = "";
                        }
                    }
                }
            }
            sename = "";
            foreach (Control item in groupBox8.Controls)
            {
                if (item.Text == "文件名")
                {
                    a[4] = "AND FileName ";
                    sename = item.Text;
                }
                else if (item.Text == "样本ID")
                {
                    a[4] = "AND SampleID ";
                    sename = item.Text;
                }
                else if (item.Text == "样本名称")
                {
                    a[4] = "AND SampleName ";
                    sename = item.Text;
                }
                else if (item.Text == "检测项目")
                {
                    a[4] = "AND TestItems ";
                    sename = item.Text;
                }
                else if (item.Text == "采样时间")
                {
                    a[4] = "AND SamplingTime ";
                    sename = item.Text;
                }
                else if (item.Text == "检测结果")
                {
                    a[4] = "AND DetectionResult ";
                    sename = item.Text;
                }
                else if (item.Text == "参考值")
                {
                    a[4] = "AND ReferenceValue ";
                    sename = item.Text;
                }
                else if (item.Text == "标准品浓度")
                {
                    a[4] = "AND StandardConcentration ";
                    sename = item.Text;
                }
                else if (item.Text == "浓度单位")
                {
                    a[4] = "AND ConcentrationUnit ";
                    sename = item.Text;
                }
                else if (item.Text == "结论")
                {
                    a[4] = "AND Conclusion ";
                    sename = item.Text;
                }
                else if (item.Text == "Ct值")
                {
                    a[4] = "AND Ct ";
                    sename = item.Text;
                }
                else if (item.Text == "检验者")
                {
                    a[4] = "AND Examiner ";
                    sename = item.Text;
                }
                else if (item.Text == "送检日期")
                {
                    a[4] = "AND SubmissionTime ";
                    sename = item.Text;
                }
                else if (item.Text == "报告名称")
                {
                    a[4] = "AND ReportName ";
                    sename = item.Text;
                }
                else if (item.Text == "备注")
                {
                    a[4] = "AND Notes ";
                    sename = item.Text;
                }
                else if (item.Text == "审核者")
                {
                    a[4] = "AND Reviewer ";
                    sename = item.Text;
                }
                else if (item.Text == "化验项")
                {
                    a[4] = " AND Analysis ";
                    sename = item.Text;
                }
                else if (item.Text == "=" || item.Text == "like" || item.Text == "<" || item.Text == "<=" || item.Text == ">" || item.Text == ">=")
                {
                    a[4] = a[4] + item.Text + " ";
                }
                else if (item.Text == null && item is ComboBox)
                {
                    a[4] = "";
                }

                if (item is TextBox || item is DateTimePicker || item is NumericUpDown)
                {
                    if (sename == "采样时间" || sename == "送检日期")
                    {
                        if (item is DateTimePicker)
                        {
                            if (!string.IsNullOrEmpty(item.Text) && a[4] != "")
                            {
                                if (a[4].Contains("like"))
                                {
                                    a[4] = a[4] + "'%" + item.Text + "%'";
                                }
                                else
                                {
                                    a[4] = a[4] + "'" + item.Text + "'";
                                }
                            }
                            else
                                a[4] = "";
                        }
                    }
                    else if (sename == "检测结果" || sename == "参考值" || sename == "标准品浓度" || sename == "Ct值")
                    {
                        if (item is NumericUpDown)
                        {
                            if (!string.IsNullOrEmpty(item.Text) && a[4] != "")
                            {
                                if (a[4].Contains("like"))
                                {
                                    a[4] = a[4] + "'%" + item.Text + "%'";
                                }
                                else
                                {
                                    a[4] = a[4] + "'" + item.Text + "'";
                                }
                            }
                            else
                                a[4] = "";
                        }
                    }
                    else
                    {
                        if (item is TextBox)
                        {
                            if (!string.IsNullOrEmpty(item.Text) && a[4] != "")
                            {
                                if (a[4].Contains("like"))
                                {
                                    a[4] = a[4] + "'%" + item.Text + "%'";
                                }
                                else
                                {
                                    a[4] = a[4] + "'" + item.Text + "'";
                                }
                            }
                            else
                                a[4] = "";
                        }
                    }
                }
            }
            sename = "";
            foreach (Control item in groupBox9.Controls)
            {
                if (item.Text == "文件名")
                {
                    a[5] = "AND FileName ";
                    sename = item.Text;
                }
                else if (item.Text == "样本ID")
                {
                    a[5] = "AND SampleID ";
                    sename = item.Text;
                }
                else if (item.Text == "样本名称")
                {
                    a[5] = "AND SampleName ";
                    sename = item.Text;
                }
                else if (item.Text == "检测项目")
                {
                    a[5] = "AND TestItems ";
                    sename = item.Text;
                }
                else if (item.Text == "采样时间")
                {
                    a[5] = "AND SamplingTime ";
                    sename = item.Text;
                }
                else if (item.Text == "检测结果")
                {
                    a[5] = "AND DetectionResult ";
                    sename = item.Text;
                }
                else if (item.Text == "参考值")
                {
                    a[5] = "AND ReferenceValue ";
                    sename = item.Text;
                }
                else if (item.Text == "标准品浓度")
                {
                    a[5] = "AND StandardConcentration ";
                    sename = item.Text;
                }
                else if (item.Text == "浓度单位")
                {
                    a[5] = "AND ConcentrationUnit ";
                    sename = item.Text;
                }
                else if (item.Text == "结论")
                {
                    a[5] = "AND Conclusion ";
                    sename = item.Text;
                }
                else if (item.Text == "Ct值")
                {
                    a[5] = "AND Ct ";
                    sename = item.Text;
                }
                else if (item.Text == "检验者")
                {
                    a[5] = "AND Examiner ";
                    sename = item.Text;
                }
                else if (item.Text == "送检日期")
                {
                    a[5] = "AND SubmissionTime ";
                    sename = item.Text;
                }
                else if (item.Text == "报告名称")
                {
                    a[5] = "AND ReportName ";
                    sename = item.Text;
                }
                else if (item.Text == "备注")
                {
                    a[5] = "AND Notes ";
                    sename = item.Text;
                }
                else if (item.Text == "审核者")
                {
                    a[5] = "AND Reviewer ";
                    sename = item.Text;
                }
                else if (item.Text == "化验项")
                {
                    a[5] = " AND Analysis ";
                    sename = item.Text;
                }
                else if (item.Text == "=" || item.Text == "like" || item.Text == "<" || item.Text == "<=" || item.Text == ">" || item.Text == ">=")
                {
                    a[5] = a[5] + item.Text + " ";
                }
                else if (item.Text == null && item is ComboBox)
                {
                    a[5] = "";
                }

                if (item is TextBox || item is DateTimePicker || item is NumericUpDown)
                {
                    if (sename == "采样时间" || sename == "送检日期")
                    {
                        if (item is DateTimePicker)
                        {
                            if (!string.IsNullOrEmpty(item.Text) && a[5] != "")
                            {
                                if (a[5].Contains("like"))
                                {
                                    a[5] = a[5] + "'%" + item.Text + "%'";
                                }
                                else
                                {
                                    a[5] = a[5] + "'" + item.Text + "'";
                                }
                            }
                            else
                                a[5] = "";
                        }
                    }
                    else if (sename == "检测结果" || sename == "参考值" || sename == "标准品浓度" || sename == "Ct值")
                    {
                        if (item is NumericUpDown)
                        {
                            if (!string.IsNullOrEmpty(item.Text) && a[5] != "")
                            {
                                if (a[5].Contains("like"))
                                {
                                    a[5] = a[5] + "'%" + item.Text + "%'";
                                }
                                else
                                {
                                    a[5] = a[5] + "'" + item.Text + "'";
                                }
                            }
                            else
                                a[5] = "";
                        }
                    }
                    else
                    {
                        if (item is TextBox)
                        {
                            if (!string.IsNullOrEmpty(item.Text) && a[5] != "")
                            {
                                if (a[5].Contains("like"))
                                {
                                    a[5] = a[5] + "'%" + item.Text + "%'";
                                }
                                else
                                {
                                    a[5] = a[5] + "'" + item.Text + "'";
                                }
                            }
                            else
                                a[5] = "";
                        }
                    }
                }
            }
            string sql = a[0] + a[1] + a[2] + a[3] + a[4] + a[5];
            a[0] = "";
            a[1] = "";
            a[2] = "";
            a[3] = "";
            a[4] = "";
            a[5] = "";
            DAL.AllTestItem AllTestItemDal = new DAL.AllTestItem();  //声明对象
            dataGridView1.DataSource = null;
            if(sql == "")
                dataGridView1.DataSource = AllTestItemDal.GetSampleListAll().Tables[0];//赋值
            else
                dataGridView1.DataSource = AllTestItemDal.GetSampleList(sql).Tables[0];//赋值
                                                                                       //设置列的列标题
            dataGridView1.Columns[0].HeaderText = "文件名";
            dataGridView1.Columns[1].HeaderText = "样本ID";
            dataGridView1.Columns[2].HeaderText = "样本名称";
            dataGridView1.Columns[3].HeaderText = "检测项目";
            dataGridView1.Columns[4].HeaderText = "采样时间";
            dataGridView1.Columns[5].HeaderText = "检测结果";
            dataGridView1.Columns[6].HeaderText = "参考值";
            dataGridView1.Columns[7].HeaderText = "标准品浓度";
            dataGridView1.Columns[8].HeaderText = "浓度单位";
            dataGridView1.Columns[9].HeaderText = "结论";
            dataGridView1.Columns[10].HeaderText = "Ct值";
            dataGridView1.Columns[11].HeaderText = "检验者";
            dataGridView1.Columns[12].HeaderText = "送检日期";
            dataGridView1.Columns[13].HeaderText = "报告名称";
            dataGridView1.Columns[14].HeaderText = "备注";
            dataGridView1.Columns[15].HeaderText = "审核者";
            dataGridView1.Columns[16].HeaderText = "化验项";
        }
    }
}
