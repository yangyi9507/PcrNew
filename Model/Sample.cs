using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PcrNew.Model
{

	/// <summary>
	/// Sample:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Sample
	{
		public Sample()
		{ }
		#region Model
		private int _id;
		private string _SamplID;
		private string _SampleColor;
		private string _SampleName;
		private string _CreationTime;
		private string _CensorshipTime;
		private string _Experiment;
		private string _HoleSite;
		private string _CheckItem;
		private string _Attribute;
		private string _Concentration;
		/// <summary>
		/// 
		/// </summary>
		public int ID
		{
			set { _id = value; }
			get { return _id; }
		}
		/// <summary>
		/// 样本ID
		/// </summary>
		public string SamplID
		{
			set { _SamplID = value; }
			get { return _SamplID; }
		}
		/// <summary>
		/// 样本颜色
		/// </summary>
		public string SampleColor
		{
			set { _SampleColor = value; }
			get { return _SampleColor; }
		}
		/// <summary>
		/// 样本名称
		/// </summary>
		public string SampleName
		{
			set { _SampleName = value; }
			get { return _SampleName; }
		}
		/// <summary>
		/// 创建时间
		/// </summary>
		public string CreationTime
		{
			set { _CreationTime = value; }
			get { return _CreationTime; }
		}
		/// <summary>
		/// 送检日期
		/// </summary>
		public string CensorshipTime
		{
			set { _CensorshipTime = value; }
			get { return _CensorshipTime; }
		}
		/// <summary>
		/// 项目名称
		/// </summary>
		public string Experiment
		{
			set { _Experiment = value; }
			get { return _Experiment; }
		}
		/// <summary>
		/// 孔位ID
		/// </summary>
		public string HoleSite
		{
			set { _HoleSite = value; }
			get { return _HoleSite; }
		}
		/// <summary>
		/// 检测项目
		/// </summary>
		public string CheckItem
		{
			set { _CheckItem = value; }
			get { return _CheckItem; }
		}
		/// <summary>
		/// 属性
		/// </summary>
		public string Attribute
		{
			set { _Attribute = value; }
			get { return _Attribute; }
		}
		/// <summary>
		/// 浓度
		/// </summary>
		public string Concentration
		{
			set { _Concentration = value; }
			get { return _Concentration; }
		}
		#endregion Model

	}
}
