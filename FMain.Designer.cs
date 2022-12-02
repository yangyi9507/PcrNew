using Sunny.UI;

namespace PcrNew
{
    partial class FMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("控件");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("窗体");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("图表");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("工控");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("主题");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FMain));
            this.StyleManager = new Sunny.UI.UIStyleManager(this.components);
            this.uiContextMenuStrip1 = new Sunny.UI.UIContextMenuStrip();
            this.关于ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关于ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.uiContextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Aside
            // 
            this.Aside.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.Aside.ItemHeight = 36;
            this.Aside.LineColor = System.Drawing.Color.Black;
            this.Aside.Location = new System.Drawing.Point(2, 76);
            this.Aside.MenuStyle = Sunny.UI.UIMenuStyle.Custom;
            this.Aside.ScrollBarColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.Aside.ScrollBarHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.Aside.ScrollBarPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.Aside.ShowOneNode = true;
            this.Aside.ShowSecondBackColor = true;
            this.Aside.ShowTips = true;
            this.Aside.Size = new System.Drawing.Size(250, 642);
            this.Aside.Style = Sunny.UI.UIStyle.Custom;
            // 
            // Header
            // 
            this.Header.Location = new System.Drawing.Point(2, 36);
            treeNode1.ImageIndex = 1;
            treeNode1.Name = "节点0";
            treeNode1.Text = "控件";
            treeNode2.Name = "节点1";
            treeNode2.Text = "窗体";
            treeNode3.Name = "节点2";
            treeNode3.Text = "图表";
            treeNode4.Name = "节点0";
            treeNode4.Text = "工控";
            treeNode5.Name = "节点2";
            treeNode5.Text = "主题";
            this.Header.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4,
            treeNode5});
            this.Header.NodeSize = new System.Drawing.Size(110, 45);
            this.Header.SelectedIndex = 0;
            this.Header.Size = new System.Drawing.Size(1020, 40);
            this.Header.Style = Sunny.UI.UIStyle.Custom;
            this.Header.MenuItemClick += new Sunny.UI.UINavBar.OnMenuItemClick(this.Header_MenuItemClick);
            // 
            // StyleManager
            // 
            this.StyleManager.DPIScale = true;
            // 
            // uiContextMenuStrip1
            // 
            this.uiContextMenuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            this.uiContextMenuStrip1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiContextMenuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.uiContextMenuStrip1.IsScaled = true;
            this.uiContextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.关于ToolStripMenuItem,
            this.关于ToolStripMenuItem1});
            this.uiContextMenuStrip1.Name = "uiContextMenuStrip1";
            this.uiContextMenuStrip1.Size = new System.Drawing.Size(137, 80);
            this.uiContextMenuStrip1.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // 关于ToolStripMenuItem
            // 
            this.关于ToolStripMenuItem.Name = "关于ToolStripMenuItem";
            this.关于ToolStripMenuItem.Size = new System.Drawing.Size(136, 38);
            this.关于ToolStripMenuItem.Text = "主页";
            this.关于ToolStripMenuItem.Click += new System.EventHandler(this.关于ToolStripMenuItem_Click);
            // 
            // 关于ToolStripMenuItem1
            // 
            this.关于ToolStripMenuItem1.Name = "关于ToolStripMenuItem1";
            this.关于ToolStripMenuItem1.Size = new System.Drawing.Size(136, 38);
            this.关于ToolStripMenuItem1.Text = "关于";
            this.关于ToolStripMenuItem1.Click += new System.EventHandler(this.关于ToolStripMenuItem1_Click);
            // 
            // FMain
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1024, 720);
            this.ExtendBox = true;
            this.ExtendMenu = this.uiContextMenuStrip1;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1024, 720);
            this.Name = "FMain";
            this.Padding = new System.Windows.Forms.Padding(2, 36, 2, 2);
            this.ShowDragStretch = true;
            this.ShowRadius = false;
            this.ShowShadow = true;
            this.Text = "PcrNew";
            this.ZoomScaleRect = new System.Drawing.Rectangle(15, 15, 1024, 720);
            this.Selecting += new Sunny.UI.UIMainFrame.OnSelecting(this.FMain_Selecting);
            this.HotKeyEventHandler += new Sunny.UI.HotKeyEventHandler(this.FMain_HotKeyEventHandler);
            this.ReceiveParams += new Sunny.UI.OnReceiveParams(this.FMain_ReceiveParams);
            this.Controls.SetChildIndex(this.Header, 0);
            this.Controls.SetChildIndex(this.Aside, 0);
            this.uiContextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private UIStyleManager StyleManager;
        private UIContextMenuStrip uiContextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 关于ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关于ToolStripMenuItem1;
    }
}