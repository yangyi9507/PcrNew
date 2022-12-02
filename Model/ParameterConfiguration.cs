using System;
using System.Text;
using System.Collections.Generic;
namespace PcrNew.Model
{
    public class ParameterConfiguration
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
        /// 低于阀值线显示
        /// </summary>		
        private bool _thresholdline;
        public bool Thresholdline
        {
            get { return _thresholdline; }
            set { _thresholdline = value; }
        }
        /// <summary>
        /// 阳控加强判断
        /// </summary>		
        private bool _positivecontrol;
        public bool PositiveControl
        {
            get { return _positivecontrol; }
            set { _positivecontrol = value; }
        }
        /// <summary>
        /// 1代表基线阀值法  2代表最大二阶导数法
        /// </summary>		
        private string _ct;
        public string Ct
        {
            get { return _ct; }
            set { _ct = value; }
        }
        /// <summary>
        /// 1代表绝对荧光法 2代表想对荧光值法
        /// </summary>		
        private string _amplification;
        public string Amplification
        {
            get { return _amplification; }
            set { _amplification = value; }
        }
        /// <summary>
        /// 噪声容限
        /// </summary>		
        private string _noise;
        public string Noise
        {
            get { return _noise; }
            set { _noise = value; }
        }
        /// <summary>
        /// 噪声绝对值
        /// </summary>		
        private string _noisenumber;
        public string NoiseNumber
        {
            get { return _noisenumber; }
            set { _noisenumber = value; }
        }
        /// <summary>
        /// 拟合参数
        /// </summary>		
        private string _fittingparameters;
        public string FittingParameters
        {
            get { return _fittingparameters; }
            set { _fittingparameters = value; }
        }
        /// <summary>
        /// 最大峰个数
        /// </summary>		
        private string _fengnumber;
        public string FengNumber
        {
            get { return _fengnumber; }
            set { _fengnumber = value; }
        }
        /// <summary>
        /// 峰高过滤比例
        /// </summary>		
        private string _fenghgiht;
        public string FengHgiht
        {
            get { return _fenghgiht; }
            set { _fenghgiht = value; }
        }

    }
}

