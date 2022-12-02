using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comm
{
    public class ConversionHelper
    {
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
        public string ByteToHex(byte[] bytes, int start, int count)
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
                result[i] = Convert.ToByte(hexString.Substring(i * 2, 2).Replace(" ", ""), 16);
            }
            return result;
        }
    }
}
