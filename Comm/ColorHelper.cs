using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comm
{
    public class ColorHelper
    {
        public string QueryColor() 
        {
            //随机
            Random RandomNum_First = new Random((int)DateTime.Now.Ticks);
            // C#的随机数
            System.Threading.Thread.Sleep(RandomNum_First.Next(50));
            Random RandomNum_Sencond = new Random((int)DateTime.Now.Ticks);
            System.Threading.Thread.Sleep(RandomNum_Sencond.Next(50));
            Random RandomNum_Thrid = new Random((int)DateTime.Now.Ticks);
            int int_Red = RandomNum_First.Next(256);
            int int_Green = RandomNum_Sencond.Next(256);
            //int int_white = RandomNum_Thrid.Next(256);
            int int_Blue = (int_Red + int_Green > 400) ? 0 : 400 - int_Red - int_Green;
            int_Blue = (int_Blue > 255) ? 255 : int_Blue;
            Color color = Color.FromArgb(int_Red, int_Green, int_Blue);
            string strColor = "#" + Convert.ToString(color.ToArgb(), 16).PadLeft(8, '0').Substring(2, 6);

            return strColor;

        }
    }
}
