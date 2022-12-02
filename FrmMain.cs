using PcrNew.Frame;
using PcrNew.SerialHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PcrNew
{
    public class FrmMain : Form
    {
        private ToolStrip sysToolBar;
        private ToolStripDropDownButton tbbHelper;
        private StatusStrip sysStatusBar;
        private ContextMenuStrip sysContextMenu;
        private NotifyIcon sysNotifyIcon;
        private ToolStripStatusLabel sysStatusLabel1;
        private ToolStripStatusLabel sysStatusTime;
        private Panel panelLeft;
        private GroupBox groupBox1;
        private Button btnOpen;
        private ComboBox txtPortName;
        private Label label1;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private Panel panelMain;
        private GroupBox groupBox5;
        private RichTextBox txtResult;
        private Splitter splitter1;
        private GroupBox groupBox4;
        private RichTextBox txtContent;
        private Button btnSend;
        private ToolStripMenuItem mnuHelper;
        private ToolStripMenuItem mnuAbout;
        private ToolStripButton tbbSave;
        private ToolStripButton tbbClear;
        private LinkLabel linkClear;
        private LinkLabel linkSelect;
        private Label label2;
        private CheckBox ckbAutoSend;
        private Label label3;
        private ComboBox txtSendEncoding;
        private Label label4;
        private ComboBox txtEncoding;
        private NumericUpDown txtInterval;
        private ComboBox txtHandshake;
        private Label label7;
        private ComboBox txtStopBits;
        private Label label8;
        private ComboBox txtParity;
        private Label label9;
        private ComboBox txtDataBits;
        private Label label6;
        private ComboBox txtBaudRate;
        private Label label5;
        private CheckBox ckbShowSend;
        private CheckBox ckbShowTime;
        private CheckBox ckbAutoLine;
        private ToolStripMenuItem mnuUpdate;
        private Panel panelSetting;
        private ToolStripStatusLabel toolStripStatusLabel3;
        private ToolStripStatusLabel toolStripStatusLabel1;

        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.sysToolBar = new System.Windows.Forms.ToolStrip();
            this.tbbHelper = new System.Windows.Forms.ToolStripDropDownButton();
            this.mnuUpdate = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHelper = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.tbbSave = new System.Windows.Forms.ToolStripButton();
            this.tbbClear = new System.Windows.Forms.ToolStripButton();
            this.sysStatusBar = new System.Windows.Forms.StatusStrip();
            this.sysStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.sysStatusTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.sysContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.sysNotifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.panelLeft = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ckbShowSend = new System.Windows.Forms.CheckBox();
            this.ckbShowTime = new System.Windows.Forms.CheckBox();
            this.ckbAutoLine = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtEncoding = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtInterval = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSendEncoding = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ckbAutoSend = new System.Windows.Forms.CheckBox();
            this.linkClear = new System.Windows.Forms.LinkLabel();
            this.linkSelect = new System.Windows.Forms.LinkLabel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panelSetting = new System.Windows.Forms.Panel();
            this.txtPortName = new System.Windows.Forms.ComboBox();
            this.txtHandshake = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtStopBits = new System.Windows.Forms.ComboBox();
            this.txtBaudRate = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtParity = new System.Windows.Forms.ComboBox();
            this.txtDataBits = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btnOpen = new System.Windows.Forms.Button();
            this.panelMain = new System.Windows.Forms.Panel();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.txtResult = new System.Windows.Forms.RichTextBox();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtContent = new System.Windows.Forms.RichTextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.sysToolBar.SuspendLayout();
            this.sysStatusBar.SuspendLayout();
            this.panelLeft.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtInterval)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.panelSetting.SuspendLayout();
            this.panelMain.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // sysToolBar
            // 
            this.sysToolBar.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.sysToolBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbbHelper,
            this.tbbSave,
            this.tbbClear});
            this.sysToolBar.Location = new System.Drawing.Point(0, 0);
            this.sysToolBar.Name = "sysToolBar";
            this.sysToolBar.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.sysToolBar.Size = new System.Drawing.Size(1176, 33);
            this.sysToolBar.TabIndex = 0;
            this.sysToolBar.Text = "toolStrip1";
            // 
            // tbbHelper
            // 
            this.tbbHelper.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tbbHelper.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuUpdate,
            this.mnuHelper,
            this.mnuAbout});
            this.tbbHelper.Image = ((System.Drawing.Image)(resources.GetObject("tbbHelper.Image")));
            this.tbbHelper.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbbHelper.Name = "tbbHelper";
            this.tbbHelper.Size = new System.Drawing.Size(88, 28);
            this.tbbHelper.Text = "帮助";
            // 
            // mnuUpdate
            // 
            this.mnuUpdate.Name = "mnuUpdate";
            this.mnuUpdate.Size = new System.Drawing.Size(182, 34);
            this.mnuUpdate.Text = "检查更新";
            // 
            // mnuHelper
            // 
            this.mnuHelper.Name = "mnuHelper";
            this.mnuHelper.Size = new System.Drawing.Size(182, 34);
            this.mnuHelper.Text = "帮助文档";
            // 
            // mnuAbout
            // 
            this.mnuAbout.Name = "mnuAbout";
            this.mnuAbout.Size = new System.Drawing.Size(182, 34);
            this.mnuAbout.Text = "关于";
            // 
            // tbbSave
            // 
            this.tbbSave.Image = ((System.Drawing.Image)(resources.GetObject("tbbSave.Image")));
            this.tbbSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbbSave.Name = "tbbSave";
            this.tbbSave.Size = new System.Drawing.Size(110, 28);
            this.tbbSave.Text = "保存内容";
            // 
            // tbbClear
            // 
            this.tbbClear.Image = ((System.Drawing.Image)(resources.GetObject("tbbClear.Image")));
            this.tbbClear.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbbClear.Name = "tbbClear";
            this.tbbClear.Size = new System.Drawing.Size(110, 28);
            this.tbbClear.Text = "清空内容";
            // 
            // sysStatusBar
            // 
            this.sysStatusBar.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.sysStatusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sysStatusLabel1,
            this.toolStripStatusLabel3,
            this.toolStripStatusLabel1,
            this.sysStatusTime});
            this.sysStatusBar.Location = new System.Drawing.Point(0, 807);
            this.sysStatusBar.Name = "sysStatusBar";
            this.sysStatusBar.Padding = new System.Windows.Forms.Padding(2, 0, 21, 0);
            this.sysStatusBar.Size = new System.Drawing.Size(1176, 35);
            this.sysStatusBar.SizingGrip = false;
            this.sysStatusBar.TabIndex = 1;
            this.sysStatusBar.Text = "statusStrip1";
            // 
            // sysStatusLabel1
            // 
            this.sysStatusLabel1.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)));
            this.sysStatusLabel1.Name = "sysStatusLabel1";
            this.sysStatusLabel1.Size = new System.Drawing.Size(823, 28);
            this.sysStatusLabel1.Spring = true;
            this.sysStatusLabel1.Text = "toolStripStatusLabel1";
            this.sysStatusLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.AutoSize = false;
            this.toolStripStatusLabel3.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)));
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(100, 28);
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.AutoSize = false;
            this.toolStripStatusLabel1.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)));
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(100, 28);
            // 
            // sysStatusTime
            // 
            this.sysStatusTime.AutoSize = false;
            this.sysStatusTime.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)));
            this.sysStatusTime.Name = "sysStatusTime";
            this.sysStatusTime.Size = new System.Drawing.Size(130, 28);
            this.sysStatusTime.Text = "2022-05-01 16:00:00";
            // 
            // sysContextMenu
            // 
            this.sysContextMenu.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.sysContextMenu.Name = "sysContextMenu";
            this.sysContextMenu.Size = new System.Drawing.Size(61, 4);
            // 
            // sysNotifyIcon
            // 
            this.sysNotifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("sysNotifyIcon.Icon")));
            this.sysNotifyIcon.Text = "notifyIcon1";
            this.sysNotifyIcon.Visible = true;
            // 
            // panelLeft
            // 
            this.panelLeft.Controls.Add(this.groupBox2);
            this.panelLeft.Controls.Add(this.groupBox3);
            this.panelLeft.Controls.Add(this.groupBox1);
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeft.Location = new System.Drawing.Point(0, 33);
            this.panelLeft.Margin = new System.Windows.Forms.Padding(4);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Padding = new System.Windows.Forms.Padding(8);
            this.panelLeft.Size = new System.Drawing.Size(300, 774);
            this.panelLeft.TabIndex = 3;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ckbShowSend);
            this.groupBox2.Controls.Add(this.ckbShowTime);
            this.groupBox2.Controls.Add(this.ckbAutoLine);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtEncoding);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(8, 332);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(284, 284);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "接收设置";
            // 
            // ckbShowSend
            // 
            this.ckbShowSend.AutoSize = true;
            this.ckbShowSend.Checked = true;
            this.ckbShowSend.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckbShowSend.Location = new System.Drawing.Point(110, 132);
            this.ckbShowSend.Margin = new System.Windows.Forms.Padding(4);
            this.ckbShowSend.Name = "ckbShowSend";
            this.ckbShowSend.Size = new System.Drawing.Size(142, 22);
            this.ckbShowSend.TabIndex = 11;
            this.ckbShowSend.Text = "显示发送内容";
            this.ckbShowSend.UseVisualStyleBackColor = true;
            // 
            // ckbShowTime
            // 
            this.ckbShowTime.AutoSize = true;
            this.ckbShowTime.Checked = true;
            this.ckbShowTime.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckbShowTime.Location = new System.Drawing.Point(110, 99);
            this.ckbShowTime.Margin = new System.Windows.Forms.Padding(4);
            this.ckbShowTime.Name = "ckbShowTime";
            this.ckbShowTime.Size = new System.Drawing.Size(142, 22);
            this.ckbShowTime.TabIndex = 10;
            this.ckbShowTime.Text = "显示接收时间";
            this.ckbShowTime.UseVisualStyleBackColor = true;
            // 
            // ckbAutoLine
            // 
            this.ckbAutoLine.AutoSize = true;
            this.ckbAutoLine.Checked = true;
            this.ckbAutoLine.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckbAutoLine.Location = new System.Drawing.Point(110, 66);
            this.ckbAutoLine.Margin = new System.Windows.Forms.Padding(4);
            this.ckbAutoLine.Name = "ckbAutoLine";
            this.ckbAutoLine.Size = new System.Drawing.Size(142, 22);
            this.ckbAutoLine.TabIndex = 9;
            this.ckbAutoLine.Text = "接收自动换行";
            this.ckbAutoLine.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(10, 27);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 34);
            this.label4.TabIndex = 8;
            this.label4.Text = "内容格式";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtEncoding
            // 
            this.txtEncoding.FormattingEnabled = true;
            this.txtEncoding.Location = new System.Drawing.Point(110, 27);
            this.txtEncoding.Margin = new System.Windows.Forms.Padding(4);
            this.txtEncoding.Name = "txtEncoding";
            this.txtEncoding.Size = new System.Drawing.Size(164, 26);
            this.txtEncoding.TabIndex = 7;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtInterval);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.txtSendEncoding);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.ckbAutoSend);
            this.groupBox3.Controls.Add(this.linkClear);
            this.groupBox3.Controls.Add(this.linkSelect);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox3.Location = new System.Drawing.Point(8, 616);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox3.Size = new System.Drawing.Size(284, 150);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "发送设置";
            // 
            // txtInterval
            // 
            this.txtInterval.Location = new System.Drawing.Point(141, 75);
            this.txtInterval.Margin = new System.Windows.Forms.Padding(4);
            this.txtInterval.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.txtInterval.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtInterval.Name = "txtInterval";
            this.txtInterval.Size = new System.Drawing.Size(82, 28);
            this.txtInterval.TabIndex = 7;
            this.txtInterval.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(10, 27);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 34);
            this.label3.TabIndex = 6;
            this.label3.Text = "内容格式";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtSendEncoding
            // 
            this.txtSendEncoding.FormattingEnabled = true;
            this.txtSendEncoding.Location = new System.Drawing.Point(110, 30);
            this.txtSendEncoding.Margin = new System.Windows.Forms.Padding(4);
            this.txtSendEncoding.Name = "txtSendEncoding";
            this.txtSendEncoding.Size = new System.Drawing.Size(164, 26);
            this.txtSendEncoding.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(232, 81);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 18);
            this.label2.TabIndex = 3;
            this.label2.Text = "毫秒";
            // 
            // ckbAutoSend
            // 
            this.ckbAutoSend.AutoSize = true;
            this.ckbAutoSend.Location = new System.Drawing.Point(24, 76);
            this.ckbAutoSend.Margin = new System.Windows.Forms.Padding(4);
            this.ckbAutoSend.Name = "ckbAutoSend";
            this.ckbAutoSend.Size = new System.Drawing.Size(106, 22);
            this.ckbAutoSend.TabIndex = 2;
            this.ckbAutoSend.Text = "自动发送";
            this.ckbAutoSend.UseVisualStyleBackColor = true;
            // 
            // linkClear
            // 
            this.linkClear.AutoSize = true;
            this.linkClear.Location = new System.Drawing.Point(144, 124);
            this.linkClear.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.linkClear.Name = "linkClear";
            this.linkClear.Size = new System.Drawing.Size(80, 18);
            this.linkClear.TabIndex = 1;
            this.linkClear.TabStop = true;
            this.linkClear.Text = "清空发送";
            // 
            // linkSelect
            // 
            this.linkSelect.AutoSize = true;
            this.linkSelect.Location = new System.Drawing.Point(21, 124);
            this.linkSelect.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.linkSelect.Name = "linkSelect";
            this.linkSelect.Size = new System.Drawing.Size(80, 18);
            this.linkSelect.TabIndex = 0;
            this.linkSelect.TabStop = true;
            this.linkSelect.Text = "选择文件";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panelSetting);
            this.groupBox1.Controls.Add(this.btnOpen);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(8, 8);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(284, 324);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "串口设置";
            // 
            // panelSetting
            // 
            this.panelSetting.Controls.Add(this.txtPortName);
            this.panelSetting.Controls.Add(this.txtHandshake);
            this.panelSetting.Controls.Add(this.label1);
            this.panelSetting.Controls.Add(this.label7);
            this.panelSetting.Controls.Add(this.label5);
            this.panelSetting.Controls.Add(this.txtStopBits);
            this.panelSetting.Controls.Add(this.txtBaudRate);
            this.panelSetting.Controls.Add(this.label8);
            this.panelSetting.Controls.Add(this.label6);
            this.panelSetting.Controls.Add(this.txtParity);
            this.panelSetting.Controls.Add(this.txtDataBits);
            this.panelSetting.Controls.Add(this.label9);
            this.panelSetting.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSetting.Location = new System.Drawing.Point(4, 25);
            this.panelSetting.Margin = new System.Windows.Forms.Padding(4);
            this.panelSetting.Name = "panelSetting";
            this.panelSetting.Size = new System.Drawing.Size(276, 237);
            this.panelSetting.TabIndex = 13;
            // 
            // txtPortName
            // 
            this.txtPortName.FormattingEnabled = true;
            this.txtPortName.Location = new System.Drawing.Point(105, 4);
            this.txtPortName.Margin = new System.Windows.Forms.Padding(4);
            this.txtPortName.Name = "txtPortName";
            this.txtPortName.Size = new System.Drawing.Size(164, 26);
            this.txtPortName.TabIndex = 1;
            // 
            // txtHandshake
            // 
            this.txtHandshake.FormattingEnabled = true;
            this.txtHandshake.Location = new System.Drawing.Point(105, 200);
            this.txtHandshake.Margin = new System.Windows.Forms.Padding(4);
            this.txtHandshake.Name = "txtHandshake";
            this.txtHandshake.Size = new System.Drawing.Size(164, 26);
            this.txtHandshake.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(6, 4);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 34);
            this.label1.TabIndex = 0;
            this.label1.Text = "串  口";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(6, 200);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(90, 34);
            this.label7.TabIndex = 11;
            this.label7.Text = "流控制";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(6, 44);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 34);
            this.label5.TabIndex = 3;
            this.label5.Text = "波特率";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtStopBits
            // 
            this.txtStopBits.FormattingEnabled = true;
            this.txtStopBits.Location = new System.Drawing.Point(105, 160);
            this.txtStopBits.Margin = new System.Windows.Forms.Padding(4);
            this.txtStopBits.Name = "txtStopBits";
            this.txtStopBits.Size = new System.Drawing.Size(164, 26);
            this.txtStopBits.TabIndex = 10;
            // 
            // txtBaudRate
            // 
            this.txtBaudRate.FormattingEnabled = true;
            this.txtBaudRate.Items.AddRange(new object[] {
            "1382400",
            "921600",
            "460800",
            "256000",
            "230400",
            "128000",
            "115200",
            "76800",
            "57600",
            "43000",
            "38400",
            "19200",
            "14400",
            "9600",
            "4800",
            "1200"});
            this.txtBaudRate.Location = new System.Drawing.Point(105, 44);
            this.txtBaudRate.Margin = new System.Windows.Forms.Padding(4);
            this.txtBaudRate.Name = "txtBaudRate";
            this.txtBaudRate.Size = new System.Drawing.Size(164, 26);
            this.txtBaudRate.TabIndex = 4;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(6, 160);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(90, 34);
            this.label8.TabIndex = 9;
            this.label8.Text = "停止位";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(6, 82);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(90, 34);
            this.label6.TabIndex = 5;
            this.label6.Text = "数据位";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtParity
            // 
            this.txtParity.FormattingEnabled = true;
            this.txtParity.Location = new System.Drawing.Point(105, 122);
            this.txtParity.Margin = new System.Windows.Forms.Padding(4);
            this.txtParity.Name = "txtParity";
            this.txtParity.Size = new System.Drawing.Size(164, 26);
            this.txtParity.TabIndex = 8;
            // 
            // txtDataBits
            // 
            this.txtDataBits.FormattingEnabled = true;
            this.txtDataBits.Items.AddRange(new object[] {
            "8",
            "7",
            "6",
            "5"});
            this.txtDataBits.Location = new System.Drawing.Point(105, 82);
            this.txtDataBits.Margin = new System.Windows.Forms.Padding(4);
            this.txtDataBits.Name = "txtDataBits";
            this.txtDataBits.Size = new System.Drawing.Size(164, 26);
            this.txtDataBits.TabIndex = 6;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(6, 122);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(90, 34);
            this.label9.TabIndex = 7;
            this.label9.Text = "校验位";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(38, 272);
            this.btnOpen.Margin = new System.Windows.Forms.Padding(4);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(219, 42);
            this.btnOpen.TabIndex = 2;
            this.btnOpen.Text = "打开";
            this.btnOpen.UseVisualStyleBackColor = true;
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.groupBox5);
            this.panelMain.Controls.Add(this.splitter1);
            this.panelMain.Controls.Add(this.groupBox4);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(300, 33);
            this.panelMain.Margin = new System.Windows.Forms.Padding(4);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(876, 774);
            this.panelMain.TabIndex = 4;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.txtResult);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox5.Location = new System.Drawing.Point(0, 0);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox5.Size = new System.Drawing.Size(876, 618);
            this.groupBox5.TabIndex = 2;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "接收内容";
            // 
            // txtResult
            // 
            this.txtResult.BackColor = System.Drawing.SystemColors.Info;
            this.txtResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtResult.Location = new System.Drawing.Point(4, 25);
            this.txtResult.Margin = new System.Windows.Forms.Padding(4);
            this.txtResult.Name = "txtResult";
            this.txtResult.ReadOnly = true;
            this.txtResult.Size = new System.Drawing.Size(868, 589);
            this.txtResult.TabIndex = 0;
            this.txtResult.Text = "";
            // 
            // splitter1
            // 
            this.splitter1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter1.Location = new System.Drawing.Point(0, 618);
            this.splitter1.Margin = new System.Windows.Forms.Padding(4);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(876, 6);
            this.splitter1.TabIndex = 1;
            this.splitter1.TabStop = false;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txtContent);
            this.groupBox4.Controls.Add(this.btnSend);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox4.Location = new System.Drawing.Point(0, 624);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox4.Size = new System.Drawing.Size(876, 150);
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "发送内容";
            // 
            // txtContent
            // 
            this.txtContent.BackColor = System.Drawing.SystemColors.Window;
            this.txtContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtContent.Location = new System.Drawing.Point(4, 25);
            this.txtContent.Margin = new System.Windows.Forms.Padding(4);
            this.txtContent.Name = "txtContent";
            this.txtContent.Size = new System.Drawing.Size(756, 121);
            this.txtContent.TabIndex = 1;
            this.txtContent.Text = "";
            // 
            // btnSend
            // 
            this.btnSend.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnSend.Location = new System.Drawing.Point(760, 25);
            this.btnSend.Margin = new System.Windows.Forms.Padding(4);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(112, 121);
            this.btnSend.TabIndex = 0;
            this.btnSend.Text = "发送";
            this.btnSend.UseVisualStyleBackColor = true;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1176, 842);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panelLeft);
            this.Controls.Add(this.sysStatusBar);
            this.Controls.Add(this.sysToolBar);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.sysToolBar.ResumeLayout(false);
            this.sysToolBar.PerformLayout();
            this.sysStatusBar.ResumeLayout(false);
            this.sysStatusBar.PerformLayout();
            this.panelLeft.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtInterval)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.panelSetting.ResumeLayout(false);
            this.panelMain.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public FrmMain()
        {
            InitializeComponent();

            this.Load += FrmMain_Load;
        }
        private static System.Timers.Timer sysTimer = new System.Timers.Timer();

        private System.Timers.Timer _SendTimer = new System.Timers.Timer();
        private SerialPortSet _SerialPortSet;
        private SerialPort _SerialPort = null;
        private void FrmMain_Load(object sender, EventArgs e)
        {
            this.Text = this.sysNotifyIcon.Text = Application.ProductName + "("+Application.ProductVersion+")";

            //this.sysStatusLabel1.Text = "欢迎使用-"+Application.ProductName+",技术支持："+ Application.CompanyName;
            this.FormClosing += FrmMain_FormClosing;
            this.sysStatusTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            this.mnuAbout.Click += MnuAbout_Click;
            this.mnuUpdate.Click += MnuUpdate_Click;
            this.btnOpen.Click += BtnOpen_Click;
            this.btnSend.Click += BtnSend_Click;

            this.tbbSave.Click += TbbSave_Click;
            this.tbbClear.Click += TbbClear_Click;

            this.linkClear.Click += LinkClear_Click;
            this.linkSelect.Click += LinkSelect_Click;

            string[] mPortNames = SerialPort.GetPortNames();
            this.txtPortName.Items.Clear();
            foreach (var item in mPortNames)
            {
                this.txtPortName.Items.Add(item);
            }

            this.txtParity.Items.Clear();
            foreach (string item in Enum.GetNames(typeof(Parity)))
            {
                this.txtParity.Items.Add(item);
            }
            this.txtParity.DropDownStyle = ComboBoxStyle.DropDownList;

            this.txtStopBits.Items.Clear();
            foreach (string item in Enum.GetNames(typeof(StopBits)))
            {
                this.txtStopBits.Items.Add(item);
            }
            this.txtStopBits.DropDownStyle = ComboBoxStyle.DropDownList;

            this.txtHandshake.Items.Clear();
            foreach (string item in Enum.GetNames(typeof(Handshake)))
            {
                this.txtHandshake.Items.Add(item);
            }
            this.txtHandshake.DropDownStyle = ComboBoxStyle.DropDownList;

            _SerialPortSet = SerialPortHelper.GetSerialPortSet();
            if(_SerialPortSet != null)
            {
                this.txtPortName.Text = _SerialPortSet.PortName;
                this.txtBaudRate.Text = _SerialPortSet.BaudRate;
                this.txtDataBits.Text = _SerialPortSet.DataBits;
                this.txtStopBits.Text = _SerialPortSet.StopBits.ToString();
                this.txtParity.Text = _SerialPortSet.Parity.ToString();
                this.txtHandshake.Text = _SerialPortSet.Handshake.ToString();
            }
            else
            {
                SerialPort serialport = new SerialPort();
                this.txtPortName.Text = txtPortName.Items[0].ToString();
                this.txtBaudRate.Text = "19200";
                this.txtDataBits.Text = "8";
                this.txtStopBits.Text = "One";
                this.txtParity.Text = "None";
                this.txtHandshake.Text = "None";
            }

            string[] mEncodings = new string[] {Encoding.Default.WebName.ToUpper()
                ,"UTF8","ASCII","16进制" };
            this.txtEncoding.Items.Clear();
            this.txtEncoding.Items.AddRange(mEncodings);
            this.txtEncoding.Text = mEncodings[3];
            this.txtEncoding.DropDownStyle = ComboBoxStyle.DropDownList;

            this.txtSendEncoding.Items.Clear();
            this.txtSendEncoding.Items.AddRange(mEncodings);
            this.txtSendEncoding.Text = mEncodings[3];
            this.txtSendEncoding.DropDownStyle = ComboBoxStyle.DropDownList;

            this._SendTimer.Elapsed += SendTimer_Elapsed;

            sysTimer.Interval = 1000;
            sysTimer.Elapsed += SysTimer_Elapsed;
            sysTimer.Start();
        }
        
        private void LinkSelect_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.InitialDirectory = System.Environment.CurrentDirectory;
            dialog.Filter = "文本文件|*.txt";
            if (dialog.ShowDialog() != DialogResult.OK)
                return;

            this.txtContent.Text = System.IO.File.ReadAllText(dialog.FileName);
        }

        private void LinkClear_Click(object sender, EventArgs e)
        {
            this.txtContent.Clear();
        }

        private void TbbClear_Click(object sender, EventArgs e)
        {
            this.txtResult.Clear();
        }

        private void TbbSave_Click(object sender, EventArgs e)
        {
            if(this.txtResult.Text.Length <= 0)
            {
                WinMessageBox.Warning("接收内容为空！");
                return;
            }
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.InitialDirectory = System.Environment.CurrentDirectory;
            dialog.Filter = "文本文件|*.txt";
            if (dialog.ShowDialog() != DialogResult.OK)
                return;
            System.IO.File.WriteAllText(dialog.FileName, this.txtResult.Text, Encoding.UTF8);
        }

        private void MnuUpdate_Click(object sender, EventArgs e)
        {
            //检查更新
           // AppUpdaterBLL.CheckUpdate();
        }
        
        private void BtnOpen_Click(object sender, EventArgs e)
        {
            if (this.btnOpen.Text == "打开")
            {
                this.btnOpen.Enabled = false;
                this.Cursor = Cursors.WaitCursor;
                try
                {
                    //打开时，保存
                    if (_SerialPortSet == null)
                        _SerialPortSet = new SerialPortSet();
                    this._SerialPortSet.PortName = this.txtPortName.Text;
                    this._SerialPortSet.BaudRate = this.txtBaudRate.Text;
                    this._SerialPortSet.DataBits = this.txtDataBits.Text;
                    this._SerialPortSet.StopBits = this.txtStopBits.Text;
                    this._SerialPortSet.Parity = this.txtParity.Text;
                    this._SerialPortSet.Handshake = this.txtHandshake.Text;

                    string fail = string.Empty;
                    _SerialPort = SerialPortHelper.GetSerialPort(this._SerialPortSet,out fail);
                    if(_SerialPort == null)
                    {
                        WinMessageBox.Warning(fail);
                        return;
                    }
                    _SerialPort.ReceivedBytesThreshold = 1;
                    _SerialPort.RtsEnable = true;
                    _SerialPort.DataReceived += SerialPort_DataReceived;

                    _SerialPort.Open();

                    //本地保存串口设置信息，便于重新启动时使用
                    SerialPortHelper.Save(this._SerialPortSet);

                    this.txtResult.Text = "Start:"+DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss fff") + "\n";
                    this.panelSetting.Enabled = false;
                    this.btnOpen.Text = "关闭";
                }
                catch (Exception ex)
                {
                    WinMessageBox.Warning("打开串口 失败：" + ex.Message);
                }
                finally
                {
                    this.btnOpen.Enabled = true;
                    this.Cursor = Cursors.Default;
                }
            }
            else
            {
                this.btnOpen.Enabled = false;
                this.Cursor = Cursors.WaitCursor;
                try
                {
                    this.Disconnect();

                    this.btnOpen.Text = "打开";
                }
                catch (Exception ex)
                {
                    WinMessageBox.Warning("关闭串口 失败：" + ex.Message);
                }
                finally
                {
                    this.btnOpen.Enabled = true;
                    this.Cursor = Cursors.Default;
                }
            }
        }

        private void BtnSend_Click(object sender, EventArgs e)
        {
            if (this._SerialPort == null || this._SerialPort.IsOpen == false)
            {
                WinMessageBox.Warning("请先打开串口！");
                this.btnOpen.Focus();
                return;
            }
            if (this.txtContent.Text.Length <= 0)
            {
                this.txtContent.Focus();
                return;
            }
            this.btnSend.Enabled = false;
            this.Cursor = Cursors.WaitCursor;
            try
            {
                //自动发送
                if (this.ckbAutoSend.Checked)
                {
                    if(this.btnSend.Text == "发送")
                    {
                        try
                        {
                            this.SendByte(this.txtContent.Text);

                            this._SendTimer.Interval = (int)this.txtInterval.Value;
                            this._SendTimer.Start();

                            this.btnSend.Text = "停止";
                        }
                        catch (Exception ex)
                        {
                            WinMessageBox.Warning("启动发送异常：" + ex.Message);
                        }
                    }
                    else
                    {
                        this._SendTimer.Stop();
                        this.btnSend.Text = "发送";
                    }
                    return;
                }

                this.SendByte(this.txtContent.Text);
            }
            finally
            {
                this.Cursor = Cursors.Default;
                this.btnSend.Enabled = true;
            }
            
        }
        private void SendTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            this.SendByte(this.txtContent.Text);
        }

        private void SendByte(string content)
        {
            try
            {
                if (this.ckbShowSend.Checked)
                    this.AppendText(content);

                byte[] buffer;
                if (this.txtSendEncoding.Text.Length <= 0)
                    buffer = Encoding.Default.GetBytes(this.txtContent.Text);
                else if (this.txtSendEncoding.Text == "16进制")
                    buffer = this.HexToByte(this.txtContent.Text);
                else
                    buffer = Encoding.GetEncoding(this.txtSendEncoding.Text).GetBytes(this.txtContent.Text);
                //向串口发送数据
                this._SerialPort.Write(buffer, 0, buffer.Length);
            }
            catch (Exception ex)
            {
                WinMessageBox.Warning("发送失败：" + ex.Message);
            }
        }

        private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            byte[] buffer = new byte[this._SerialPort.ReadBufferSize];
            int count = this._SerialPort.Read(buffer, 0, buffer.Length);
            this.AppendText(this.ByteToHex(buffer, 0, count));
            ////string str = Encoding.Default.GetString(readBuffer).TrimEnd('\0');
            //if (this.txtEncoding.Text.Length <= 0)
            //    this.AppendText(System.Text.Encoding.Default.GetString(buffer,0, count));
            //else if (this.txtEncoding.Text == "16进制")
            //    this.AppendText(this.ByteToHex(buffer,0,count));
            //else
            //    this.AppendText(System.Text.Encoding.GetEncoding(this.txtEncoding.Text).GetString(buffer,0,count));
        }

        private void Disconnect()
        {
            this._SendTimer.Stop();

            if (this._SerialPort != null && this._SerialPort.IsOpen)
                this._SerialPort.Close();

            this.panelSetting.Enabled = true;
        }

        private void MnuAbout_Click(object sender, EventArgs e)
        {
           // new AboutBox().ShowDialog();
        }

        private void SysTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            this.Invoke((EventHandler)delegate {
                this.sysStatusTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            });
        }
        /// <summary>
        /// 热插拔
        /// </summary>
        /// <param name="m"></param>
        protected override void WndProc(ref Message m)
        {
            //设备改变
            if (m.Msg == 0x0219)
            {
                //重新获取串口
                string[] ports = System.IO.Ports.SerialPort.GetPortNames();
                this.txtPortName.Items.Clear();
                //usb串口拔出
                if (m.WParam.ToInt32() == 0x8004)
                {
                    //拔出本程序串口，需要关闭串口
                    if(this.btnOpen.Text == "关闭" && this._SerialPortSet != null)
                    {
                        bool mStop = false;
                        foreach (var item in ports)
                        {
                            this.txtPortName.Items.Add(item);

                            if (this._SerialPortSet.PortName == item)
                                mStop = true;
                        }
                        if(mStop)
                        {
                            WinMessageBox.Warning("串口被拔出，需要关闭串口！");
                            this.btnOpen.PerformClick();
                        }
                    }
                    else
                        this.txtPortName.Items.AddRange(ports);
                }
                else if (m.WParam.ToInt32() == 0x8000)//usb串口连接上
                {
                    this.txtPortName.Items.AddRange(ports);
                }
            }
            base.WndProc(ref m);
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Disconnect();

            this.sysNotifyIcon.Visible = false;

            sysTimer.Stop();
        }

        private void AppendText(string text)
        {
            this.Invoke((EventHandler)delegate {
                if (this.ckbShowTime.Checked)
                    this.txtResult.AppendText(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss fff")+ "|");

                this.txtResult.AppendText(text);

                if (this.ckbAutoLine.Checked)
                    this.txtResult.AppendText("\n");

                this.txtResult.ScrollToCaret();
            });
        }
        /// <summary>
        /// 字节数组转16进制字符串
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public string ByteToHex(byte[] bytes)
        {
            return ByteToHex(bytes, 0, bytes.Length);
        }
        /// <summary>
        /// 字节数组转16进制字符串
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="start"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public string ByteToHex(byte[] bytes,int start,int count)
        {
            StringBuilder result = new StringBuilder();
            try
            {
                if (bytes != null)
                {
                    for (int i = start; i < count; i++)
                    {
                        if (bytes.Length < i)
                            break;
                        //两个16进制用空格隔开,方便看数据
                        if (i == start)
                            result.Append(bytes[i].ToString("X2"));
                        else
                            result.Append(" " + bytes[i].ToString("X2"));
                    }
                }
                return result.ToString();
            }
            catch (Exception)
            {
                return "";
            }
        }

        /// <summary>
        /// 字符串转16进制格式,不够自动前面补零
        /// </summary>
        /// <param name="hexString"></param>
        /// <returns></returns>
        public byte[] HexToByte(string hexString)
        {
            hexString = hexString.Replace(" ", "");//清除空格
            if ((hexString.Length % 2) != 0)//奇数个
                hexString = hexString + " ";

            byte[] result = new byte[(hexString.Length) / 2];
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = Convert.ToByte(hexString.Substring(i * 2, 2).Replace(" ",""), 16);
            }
            return result;
        }
    }
}
