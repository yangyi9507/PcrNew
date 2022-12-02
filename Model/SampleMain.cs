using System;
namespace PcrNew.Model
{
	/// <summary>
	/// SampleMain:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class SampleMain
	{
		public SampleMain()
		{}
		#region Model
		private int _id;
		private string _holeid;
		private string _sampleid;
		private string _samplecolor;
		private string _samplename;
		private string _reportid;
		private string _testitem;
		private string _hightlight;
		private string _attribute;
		private string _density;
		private string _densityunit;
		private string _caldensity;
		/// <summary>
		/// 
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 孔位ID
		/// </summary>
		public string HoleID
		{
			set{ _holeid=value;}
			get{return _holeid;}
		}
		/// <summary>
		/// 样本ID
		/// </summary>
		public string SampleID
		{
			set{ _sampleid=value;}
			get{return _sampleid;}
		}
		/// <summary>
		/// 样本颜色
		/// </summary>
		public string SampleColor
		{
			set{ _samplecolor=value;}
			get{return _samplecolor;}
		}
		/// <summary>
		/// 样本名称
		/// </summary>
		public string SampleName
		{
			set{ _samplename=value;}
			get{return _samplename;}
		}
		/// <summary>
		/// 用于和ReportMain中的reportID进行关联
		/// </summary>
		public string ReportID
		{
			set{ _reportid=value;}
			get{return _reportid;}
		}
		/// <summary>
		/// 检测项目
		/// </summary>
		public string TestItem
		{
			set{ _testitem=value;}
			get{return _testitem;}
		}
		/// <summary>
		/// 报告荧光
		/// </summary>
		public string HightLight
		{
			set{ _hightlight=value;}
			get{return _hightlight;}
		}
		/// <summary>
		/// 属性 U S N P
		/// </summary>
		public string Attribute
		{
			set{ _attribute=value;}
			get{return _attribute;}
		}
		/// <summary>
		/// 浓度
		/// </summary>
		public string Density
		{
			set{ _density=value;}
			get{return _density;}
		}
		/// <summary>
		/// 浓度单位
		/// </summary>
		public string DensityUnit
		{
			set{ _densityunit=value;}
			get{return _densityunit;}
		}
		/// <summary>
		/// 计算浓度
		/// </summary>
		public string CalDensity
		{
			set{ _caldensity=value;}
			get{return _caldensity;}
		}
		#endregion Model

	}
}

