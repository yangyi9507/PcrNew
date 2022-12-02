using Comm;
using Effort.Internal.TypeGeneration;
using Model;
using ScottPlot;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PcrNew.Pages
{
    public partial class HighLighterGraphfrm : UIPage
    {
        List<ComboBoxCamera> ComboBoxCameras;

        double[] pointListX = { };
        double[] pointListY = { };

        int CollectInt = 0;
        IntPtr handle;

        bool stopProcessing;
        bool checkTemperature;
        bool appRunning = true;
        Thread temp;

        ArtemisSetFastCallback fastCallback;
        bool fastMode;
        FastModeManager fmm;
        int fmw, fmh;
        int fastModeNmrImage;

        public int Seconds = 0;//温度时间

        public int TestSeconds = 0;//实验运行时间

        List<String> List1 = new List<String>();
        delegate void WriteGraphCallBack();

        int CollectInit = 0; //X数轴坐标
        public HighLighterGraphfrm()
        {
            InitializeComponent();
            ComboBoxCameras = new List<ComboBoxCamera>();
            ConnectCarmera();
            WriteGraph();

            timer1.Start();
            //var plt = formsPlot1.Plot;                

            ////缩放进行配置
            //formsPlot1.Refresh();
        }


        private void ConnectCarmera()
        {
            ComboBoxCameras.Clear();

            AtikPInvoke.ArtemisRefreshDevicesCount();
            for (var i = 0; i < 16; ++i)
            {
                if (AtikPInvoke.ArtemisDevicePresent(i))
                {
                    StringBuilder sbName = new StringBuilder();
                    StringBuilder sbSerial = new StringBuilder();
                    AtikPInvoke.ArtemisDeviceName(i, sbName);
                    AtikPInvoke.ArtemisDeviceSerial(i, sbSerial);

                    ComboBoxCameras.Add(new ComboBoxCamera(i, $"{sbName} {sbSerial}"));
                }
            }
            //连接摄像头是否正常
            if (ComboBoxCameras.Count == 0)
            {
                UIMessageTip.Show("摄像头连接异常!");
                return;
            }
            CameraComboBox.Items.Clear();
            foreach (var camera in ComboBoxCameras) { CameraComboBox.Items.Add(camera); }
            CameraComboBox.SelectedIndex = 0;// 默认选中第一个

            var selected = (ComboBoxCamera)CameraComboBox.SelectedItem;
            if (selected != null)
            {
                handle = AtikPInvoke.ArtemisConnect(selected.id);
                if (handle.ToInt32() != 0)
                {
                    int num = 0;
                    AtikPInvoke.ArtemisTemperatureSensorInfo(handle, 0, ref num);
                }

                if (AtikPInvoke.ArtemisHasCameraSpecificOption(handle, (ushort)AtikCameraSpecificOptions.ID_GOCustomGain) &&
                   AtikPInvoke.ArtemisHasCameraSpecificOption(handle, (ushort)AtikCameraSpecificOptions.ID_GOCustomOffset) &&
                   AtikPInvoke.ArtemisHasCameraSpecificOption(handle, (ushort)AtikCameraSpecificOptions.ID_PadData) &&
                   AtikPInvoke.ArtemisHasCameraSpecificOption(handle, (ushort)AtikCameraSpecificOptions.ID_EvenIllumination))
                {
                    int length = 0;

                    byte[] go = new byte[2];
                    AtikPInvoke.ArtemisCameraSpecificOptionGetData(handle, (ushort)AtikCameraSpecificOptions.ID_GOPresetMode, go, 2, ref length);

                    if (go[0] == 0)
                    {

                        byte[] gain = new byte[6];
                        AtikPInvoke.ArtemisCameraSpecificOptionGetData(handle, (ushort)AtikCameraSpecificOptions.ID_GOCustomGain, gain, 6, ref length);
                        var gainMax = (gain[3] << 8) + gain[2];
                        var gainVal = (gain[5] << 8) + gain[4];


                        byte[] offset = new byte[6];
                        AtikPInvoke.ArtemisCameraSpecificOptionGetData(handle, (ushort)AtikCameraSpecificOptions.ID_GOCustomOffset, offset, 6, ref length);
                        var offsetMax = (offset[3] << 8) + offset[2];
                        var offsetVal = (offset[5] << 8) + offset[4];

                    }

                    byte[] padData = new byte[1];
                    AtikPInvoke.ArtemisCameraSpecificOptionGetData(handle, (ushort)AtikCameraSpecificOptions.ID_PadData, padData, 1, ref length);


                    byte[] evenIllu = new byte[1];
                    AtikPInvoke.ArtemisCameraSpecificOptionGetData(handle, (ushort)AtikCameraSpecificOptions.ID_EvenIllumination, evenIllu, 1, ref length);
                }

                if (AtikPInvoke.ArtemisHasFastMode(handle))
                {
                    int length = 0;

                    byte[] expSpeed = new byte[2];
                    AtikPInvoke.ArtemisCameraSpecificOptionGetData(handle, (ushort)AtikCameraSpecificOptions.ID_ExposureSpeed, expSpeed, 2, ref length);

                    byte[] bitSend = new byte[2];
                    AtikPInvoke.ArtemisCameraSpecificOptionGetData(handle, (ushort)AtikCameraSpecificOptions.ID_BitSendMode, bitSend, 2, ref length);

                    AtikPInvoke.ArtemisSetFastCallback(handle, fastCallback);
                    fastMode = true;
                    Thread fastModeReceive = new Thread(DisplayFastModeImages);
                    fastModeReceive.Start();
                }
            }
        }

        private void StartExposure()
        {
            if (handle.ToInt32() != 0)
            {
                if (AtikPInvoke.ArtemisStartExposure(handle, 2) == (int)ArtemisError.OK)
                {
                    Thread t1 = new Thread(WaitForImage);
                    t1.Start();
                }
            }
        }

        private void WaitForImage()
        {
            CollectInit += 1;
            while (!AtikPInvoke.ArtemisImageReady(handle))
            {
                if (stopProcessing)
                {
                    stopProcessing = false;
                    return;
                }

                Thread.Sleep(100);
            }

            int x = 0, y = 0, w = 0, h = 0, binX = 0, binY = 0;
            AtikPInvoke.ArtemisGetImageData(handle, ref x, ref y,
                                                    ref w, ref h,
                                                    ref binX, ref binY);

            // Create memory to copy pixels into
            byte[] pix = new byte[w * h * 2];

            var intPtr = AtikPInvoke.ArtemisImageBuffer(handle);

            Marshal.Copy(intPtr, pix, 0, w * h * 2);

            // create enough space for a 24 bit per pixel bitmap of the image
            byte[] bmpBytes = new byte[w * h * 3];
            for (int i = 0, j = 0; i < w * h; ++i, j += 2)
            {
                if (stopProcessing)
                {
                    stopProcessing = false;
                    return;
                }

                var val = pix[j];
                // we have a mono image so we place the same value into each bitmap byte
                bmpBytes[i] = val;
                bmpBytes[++i] = val;
                bmpBytes[++i] = val;
            }

            var pic = new Bitmap(w, h);
            var rect = new Rectangle(0, 0, w, h);
            var picData = pic.LockBits(rect, ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);
            Marshal.Copy(bmpBytes, 0, picData.Scan0, w * 3 * h);
            pic.UnlockBits(picData);

            //pictureBox1.BeginInvoke(new Action(() => pictureBox1.Image = pic));

            Thread.Sleep(200);

            //根据坐标查询出每一坐标的荧光数值
            //
            Bitmap bm = (Bitmap)pic;
            //Console.WriteLine("开始时间:" + DateTime.Now.ToString());
            BLL.DeepHoleBase deepHole = new BLL.DeepHoleBase();
            DataTable dt =  deepHole.GetAllList().Tables[0];
            for (int i = 0; i < dt.Rows.Count; i++)
            {                

                //bm.GetPixel(int.Parse(dt.Rows[i]["HOLEXY"].ToString().Split(',')[0]), int.Parse(dt.Rows[i]["HOLEXY"].ToString().Split(',')[1]));
                //计算出对应的因光强度数值

                double R = 0.299 * int.Parse(bm.GetPixel(int.Parse(dt.Rows[i]["HOLEXY"].ToString().Split(',')[0]), int.Parse(dt.Rows[i]["HOLEXY"].ToString().Split(',')[1])).R.ToString());
                double G = 0.587 * int.Parse(bm.GetPixel(int.Parse(dt.Rows[i]["HOLEXY"].ToString().Split(',')[0]), int.Parse(dt.Rows[i]["HOLEXY"].ToString().Split(',')[1])).G.ToString());
                double B = 0.144 * int.Parse(bm.GetPixel(int.Parse(dt.Rows[i]["HOLEXY"].ToString().Split(',')[0]), int.Parse(dt.Rows[i]["HOLEXY"].ToString().Split(',')[1])).B.ToString());

                //采集数  横坐标
                double RGBValue = R + G + B;

                //double[] ys = { 35, 29.5, 29.5, 26.25, 23.5, 23.5 };
                //double[] xs = { 4, 4.9, 5, 5.9, 6, 7 };

                List<double> listx = new List<double>(pointListX);
                List<double> listy = new List<double>(pointListY);
                listx.Add(CollectInit);
                listy.Add(RGBValue + i * 10);
                pointListX = listx.ToArray();
                pointListY = listy.ToArray();
            }
            if (pointListX.Length > 1) 
            {
                WriteGraphCallBack stcb = new WriteGraphCallBack(WriteGraphNew);
                this.Invoke(stcb);
            }
        }            

        void WriteGraphNew() 
        {
            formsPlot1.Plot.Clear();
            var plt = formsPlot1.Plot;

            //double x1 = pointListX[0];
            //double x2 = pointListX[pointListX.Length - 1];
            plt.SetAxisLimitsX(0, 41);

            if (CollectInit > 1)
            {
                for (int i = 1; i <= 96; i++)
                {
                    //0 96 192
                    //1 97 193
                    //2 98
                    //3 99
                    double[] xs = { };
                    double[] ys = { };
                    for (int K = 0; K < CollectInit; K++)
                    {
                        double x  = pointListX[K * 96];
                        double y =  pointListY[K * 96];
                        List<double> listx = new List<double>(xs);
                        List<double> listy = new List<double>(ys);
                        listx.Add(x);
                        listy.Add(y);
                        xs = listx.ToArray();
                        ys = listy.ToArray();
                    }

                    plt.AddScatterLines(xs, ys, lineWidth: 3);
                }

            }
            plt.AddHorizontalLine(.85);
            //double[] xs = { 1.0, 1.0, 2.0, 2.0, 3.0, 3.0 };
            //double[] ys = { 5, 5, 10, 15, 20, 25 };            
            //plt.AddScatterLines(xs, ys, lineWidth: 3);
            //缩放进行配置
            formsPlot1.Refresh();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Seconds += 1;

            if (List1.Count > 0) 
            {
                if (Seconds == int.Parse(List1[0].Split(',')[0].ToString()))
                {
                    if (List1[0].Split(',')[2].ToString() == "1")
                    {
                        //如果需要采集的话 发送指令去获取荧光数值
                        CollectInt += 1;
                        StartExposure();

                    }
                    //发送完指令后List第一个LIST清空
                    List1.Remove(List1[0]);
                }
            }            
        }


        private void WriteGraph()
        {
            TimeConvertHelper convertHelper = new TimeConvertHelper();
            //1.首先根据reportID查询 TestSteup 程序设置的运行段根据ID进行排序  
            BLL.TestSteup testSteupBll = new BLL.TestSteup();
            string strQuery = " ReportID ='20221121_090725'";
            DataTable dt = testSteupBll.GetList(strQuery).Tables[0];
            //2.根据CollectFlg进行判断  0:不采集; 1:采集     对需要采集的时间进行判断
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (i > 0) 
                {
                    if (dt.Rows[i]["SteupID"].ToString() == dt.Rows[i - 1 ]["SteupID"].ToString()) 
                    {
                        continue;
                    }
                }
                System.Data.DataRow[] drs = dt.Select("SteupID='"+ dt.Rows[i]["SteupID"].ToString() +"'");

                if (drs.Length == 1)
                {
                    string SteupTime = dt.Rows[i]["SteupTime"].ToString();
                    string Circle = dt.Rows[i]["Circle"].ToString();
                    int CircleInt = int.Parse(Circle);
                    string CollectFlg = dt.Rows[i]["CollectFlg"].ToString();

                    int SteupTimeInt = convertHelper.TimeToSeconds(SteupTime) * CircleInt;
                    TestSeconds += SteupTimeInt;


                    for (int k = 0; k < CircleInt; k++)
                    {
                        List1.Add(TestSeconds + "," + convertHelper.TimeToSeconds(SteupTime) + "," + CollectFlg);
                    }
                }
                else 
                {
                    List<String> ListBase = new List<String>();
                    int CircleInt = 1;
                    for (int z = 0; z < drs.Length; z++)
                    {
                        CircleInt = int.Parse(drs[0]["Circle"].ToString());
                        string SteupTime = drs[z]["SteupTime"].ToString();
                        string CollectFlg = drs[z]["CollectFlg"].ToString();

                        ListBase.Add(convertHelper.TimeToSeconds(SteupTime) + "," + CollectFlg);

                    }
                    for (int x = 0; x < CircleInt; x++)
                    {
                        for (int m = 0; m < ListBase.Count; m++)
                        {
                            TestSeconds += int.Parse(ListBase[m].Split(',')[0].ToString());
                            List1.Add(TestSeconds + "," + ListBase[m].Split(',')[0].ToString() + "," + ListBase[m].Split(',')[1].ToString());
                        }
                        
                    }
                }
            }

        }

        void DisplayFastModeImages()
        {
            while (appRunning)
            {
                if (fastMode)
                {
                    byte[] rawImg = fmm.GetImage();

                    if (rawImg != null)
                    {
                        // create enough space for a 24 bit per pixel bitmap of the image
                        byte[] bmpBytes = new byte[fmw * fmh * 3];
                        for (int i = 0, j = 0; i < fmw * fmh; ++i, j += 2)
                        {
                            if (stopProcessing)
                            {
                                stopProcessing = false;
                                return;
                            }

                            var val = rawImg[j];
                            // we have a mono image so we place the same value into each bitmap byte
                            bmpBytes[i] = val;
                            bmpBytes[++i] = val;
                            bmpBytes[++i] = val;
                        }

                        var pic = new Bitmap(fmw, fmh);
                        var rect = new Rectangle(0, 0, fmw, fmh);
                        var picData = pic.LockBits(rect, ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);
                        Marshal.Copy(bmpBytes, 0, picData.Scan0, fmw * 3 * fmh);
                        pic.UnlockBits(picData);
                    }
                }
            }
        }
    }
}