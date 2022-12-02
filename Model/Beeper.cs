using System;
using System.Text;
using System.Collections.Generic;
namespace PcrNew.Model
{
    public class Beeper
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
        /// issetting
        /// </summary>		
        private string _issetting;
        public string issetting
        {
            get { return _issetting; }
            set { _issetting = value; }
        }
        /// <summary>
        /// time
        /// </summary>		
        private string _fengmingtime;
        public string fengmingtime
        {
            get { return _fengmingtime; }
            set { _fengmingtime = value; }
        }

    }
}

