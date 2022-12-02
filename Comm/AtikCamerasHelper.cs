using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Comm
{
    public class AtikCamerasHelper
    {
        const String DLLPath = "AtikCameras.dll";
        [DllImport(DLLPath)]
        #region API版本  
        public static extern int ArtemisAPIVersion();
        #endregion

        [DllImport(DLLPath)]
        #region DLL的版本  
        public static extern int ArtemisDLLVersion();
        #endregion

        [DllImport(DLLPath)]
        #region 指示给定设备是否存在  
        public static extern bool ArtemisDeviceIsPresent(int iDevice);
        #endregion

        [DllImport(DLLPath)]
        #region 将提供的“pName”变量设置为给定设备的名称。如果找到iDevice，则返回true，否则返回false
        public static extern bool ArtemisDeviceName(int iDevice, char  pName);
        #endregion

        [DllImport(DLLPath)]
        #region 将提供的“pSerial”变量设置为给定设备的序列号。如果找到iDevice，则返回true，否则返回false。
        public static extern bool ArtemisDeviceSerial(int iDevice, char pSerial);
        #endregion


        [DllImport(DLLPath)]
        #region 连接到给定的相机。ArtemisHandle实际上是一个“void”，所有相机特定的方法都需要它。如果此方法失败，它将返回0。
        //连接到给定的相机。ArtemisHandle实际上是一个“void”，所有相机特定的方法都需要它。如果此方法失败，它将返回0。您可以使用“-1”调用此方法，在这种情况下，您将收到第一个当前未使用的相机（由任何应用程序）。注意：不同的应用程序可以连接到同一台相机。
        public static extern void ArtemisConnect(int iDevice);
        #endregion


        [DllImport(DLLPath)]
        #region 此方法用于在完成后释放相机。它将允许其他应用程序连接到如上所列的相机
        public static extern bool ArtemisDisconnectAll();
        #endregion


        public int Aaa() 
        {
            int i = ArtemisDLLVersion();
            return i;
        }
        public string Aaaaa()
        {
            string a = "a";
            if (ArtemisDeviceIsPresent(2020))
            {
                a = "b";
            }
            else { a = "C"; }
            return a;
        }

    }
}
