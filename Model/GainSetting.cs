using System;
using System.Text;
using System.Collections.Generic;
namespace PcrNew.Model
{
    public class GainSetting
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
        /// 增益设置：1是参考增益、2是指定增益、3自动增益
        /// </summary>		
        private string _gain;
        public string gain
        {
            get { return _gain; }
            set { _gain = value; }
        }
        /// <summary>
        /// F1
        /// </summary>		
        private string _f1;
        public string F1
        {
            get { return _f1; }
            set { _f1 = value; }
        }
        /// <summary>
        /// F2
        /// </summary>		
        private string _f2;
        public string F2
        {
            get { return _f2; }
            set { _f2 = value; }
        }
        /// <summary>
        /// F3
        /// </summary>		
        private string _f3;
        public string F3
        {
            get { return _f3; }
            set { _f3 = value; }
        }
        /// <summary>
        /// F4
        /// </summary>		
        private string _f4;
        public string F4
        {
            get { return _f4; }
            set { _f4 = value; }
        }
        /// <summary>
        /// F5
        /// </summary>		
        private string _f5;
        public string F5
        {
            get { return _f5; }
            set { _f5 = value; }
        }
        /// <summary>
        /// F6
        /// </summary>		
        private string _f6;
        public string F6
        {
            get { return _f6; }
            set { _f6 = value; }
        }

    }
}

