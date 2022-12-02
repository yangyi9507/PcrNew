using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comm
{
    public class TimeConvertHelper
    {


        #region 时间转化为秒
        public int TimeToSeconds(string strTime)
        {
            int Seconds = 0;
            try
            {
                string[] times = strTime.Split(':');
                Seconds = (Convert.ToInt32(times[0]) * 3600) + (Convert.ToInt32(times[1]) * 60) + Convert.ToInt32(times[2]);
                return Seconds;
            }
            catch (Exception)
            {

                return Seconds;
            }
        }
        #endregion

    }
}
