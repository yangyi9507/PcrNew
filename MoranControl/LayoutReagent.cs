using CCWin.SkinControl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using ToolTip = System.Windows.Forms.ToolTip;

namespace PcrNew.MoranControl
{
    public partial class LayoutReagent : UserControl
    {
        public LayoutReagent()
        {
            InitializeComponent();
        }
        private Color _containerColor = Color.LightBlue;//容器填充颜色
        private int _radius = 10;//圆角大小
        private const int WM_PAINT = 0xF;//更新绘制通知
        private int _radiusCorrection = 1;//边框宽度

        [DefaultValue(typeof(Color), "223, 34, 34"), Description("容器填充颜色")]
        public Color ContainerColor
        {
            get { return _containerColor; }
            set
            {
                _containerColor = value;
                base.Invalidate();
            }
        }

        [DefaultValue(typeof(int), "10"), Description("圆角大小")]
        public int Radius
        {
            get { return _radius; }
            set
            {
                if (value < 0)
                {
                    value = 1;
                }
                _radius = value;
                base.Invalidate();
            }
        }


        [DefaultValue(typeof(int), "1"), Description("边框宽度")]
        public int RadiusCorrection
        {
            get { return _radiusCorrection; }
            set
            {
                _radiusCorrection = value;
                base.Invalidate();
            }
        }

        /// <summary>
        /// 更新绘制
        /// </summary>
        /// <param name="m"></param>
        protected override void WndProc(ref Message m)
        {
            try
            {
                base.WndProc(ref m);
                if (m.Msg == WM_PAINT)
                {
                    if (this.Radius > 0)
                    {
                        using (Graphics g = Graphics.FromHwnd(this.Handle))
                        {
                            g.SmoothingMode = SmoothingMode.HighQuality;
                            Rectangle r = new Rectangle(3, 3, this.Width - 6, this.Height - 6);
                            Pen rec_pen = new Pen(Color.FromArgb(188, 181, 181), this.RadiusCorrection);
                            Brush b = new SolidBrush(this.ContainerColor);
                            g.FillRectangle(b, r);
                            DrawBorder(g, r, this.Radius);
                            g.Dispose();
                            b.Dispose();
                            rec_pen.Dispose();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DrawBorder(Graphics g, Rectangle rect, int radius)
        {
            using (GraphicsPath path = CreatePath(rect, radius))
            {
                using (Pen pen = new Pen(this.ContainerColor))
                {
                    g.DrawPath(pen, path);
                }
            }
        }

        /// <summary>
        /// 建立带有圆角样式的路径。
        /// </summary>
        /// <param name="rect">用来建立路径的矩形。</param>
        /// <param name="radius">圆角的大小。</param>
        /// <param name="boardStyle">圆角的样式。</param>
        /// <param name="correction">是否把矩形长宽减 1,以便画出边框。</param>
        /// <returns>建立的路径。</returns>
        GraphicsPath CreatePath(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddRectangle(rect);
            path.CloseFigure(); //这句很关键，缺少会没有左边线。
            return path;
        }

        protected override CreateParams CreateParams
        {
            get
            {
                var parms = base.CreateParams;
                parms.Style &= ~0x02000000; // Turn off WS_CLIPCHILDREN
                return parms;
            }
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
        }

        //ToolTip toolTip1 = new ToolTip();

        private void LayoutReagent_Load(object sender, EventArgs e)
        {
            //foreach (Control control in this.Controls)
            //{
            //    if (control is MyLabelX)
            //    {
            //        MyLabelX mlx = control as MyLabelX;
            //        //mlx.MouseDown += new EventHandler(Control_Click);
            //        //mlx.MouseDown += Mlx_MouseDown;
            //    }
            //}
        }

        //private void Mlx_MouseDown(object sender, MouseEventArgs e)
        //{
        //    MyLabelX myLabelX = sender as MyLabelX;
        //    toolTip1.Dispose();
        //    toolTip1 = new ToolTip();
        //    string strTip = "";
        //    if (myLabelX.Tag != null)
        //    {
        //        strTip = myLabelX.Tag.ToString();
        //    }
        //    //toolTip1.Show(strTip, myLabelX);

        //    toolTip1.SetToolTip(myLabelX, strTip);
        //}

        //private void Control_Click(object sender, EventArgs e)
        //{
        //    MyLabelX myLabelX = sender as MyLabelX;
        //    toolTip1.Dispose();
        //    toolTip1 = new ToolTip();
        //    string strTip = "";
        //    if (myLabelX.Tag != null)
        //    {
        //        strTip = myLabelX.Tag.ToString();
        //    }
        //    //toolTip1.Show(strTip, myLabelX);

        //    toolTip1.SetToolTip(myLabelX, strTip);
        //}
    }
}
