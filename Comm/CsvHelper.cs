using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PcrNew.Comm
{
    public class CsvHelper
    {
        #region 将Csv读入DataTable
        /// <summary>
        /// 将Csv读入DataTable
        /// </summary>
        /// <param name="filePath">csv文件路径</param>
        /// <param name="n">表示第n行是字段title,第n+1行是记录开始</param>
        /// <param name="k">可选参数表示最后K行不算记录默认0</param>
        public DataTable csvTodt(string filePath, int n)
        {
            DataTable dt = new DataTable();
            StreamReader reader = new StreamReader(filePath, System.Text.Encoding.Default, false);
            int i = 0, m = 0;
            reader.Peek();
            while (reader.Peek() > 0)
            {
                m = m + 1;
                string str = reader.ReadLine();
                if (m >= n + 1)
                {
                    if (m == n + 1) //如果是字段行，则自动加入字段。
                    {
                        string[] strHeaderName = str.Split('\t');
                        for (int z = 0; z < strHeaderName.Length; z++)
                        {
                            dt.Columns.Add(strHeaderName[z].ToString()); //增加列标题
                        }
                    }
                    else
                    {
                        string[] strDAtaValue = str.Split('\t');
                        i = 0;
                        System.Data.DataRow dr = dt.NewRow();
                        for (int z = 0; z < strDAtaValue.Length; z++)
                        {
                            dr[i] = strDAtaValue[z].ToString();
                            i++;
                        }
                        dt.Rows.Add(dr);  //DataTable 增加一行     
                    }

                }
            }
            return dt;
        }
        #endregion
    }
}
