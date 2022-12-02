using System;
using System.Text;
using System.Collections.Generic;
namespace PcrNew.Model
{
    public class ModuleScan
    {

        /// <summary>
        /// ID
        /// </summary>		
        private int _id;
        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }
        /// <summary>
        /// 整版扫描为1 分行扫描为2
        /// </summary>		
        private int _scanmode;
        public int ScanMode
        {
            get { return _scanmode; }
            set { _scanmode = value; }
        }
        /// <summary>
        /// 存储选中行数
        /// </summary>		
        private string _deep;
        public string deep
        {
            get { return _deep; }
            set { _deep = value; }
        }

    }
}

