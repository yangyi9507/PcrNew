using System;
namespace PcrNew.Model
{
	/// <summary>
	/// AllTestItem:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class AllTestItem
	{
		public AllTestItem()
		{}
		#region Model
		private int _id;
		private int? _itemlibrarytype=0;
		private string _itemname;
		private string _itemcolor;
		private string _mastermix;
		private string _primers;
		private string _probe;
		private string _supplies;
		private string _qcbatch;
		private string _reporthighlighter;
		/// <summary>
		/// 
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 项目库类别  0:绝对定量;1:相对定量;2:SNP;3:高分辨率
		/// </summary>
		public int? ItemLibraryType
		{
			set{ _itemlibrarytype=value;}
			get{return _itemlibrarytype;}
		}
		/// <summary>
		/// 项目名称
		/// </summary>
		public string ItemName
		{
			set{ _itemname=value;}
			get{return _itemname;}
		}
		/// <summary>
		/// 颜色
		/// </summary>
		public string ItemColor
		{
			set{ _itemcolor=value;}
			get{return _itemcolor;}
		}
		/// <summary>
		/// MasterMix
		/// </summary>
		public string MasterMix
		{
			set{ _mastermix=value;}
			get{return _mastermix;}
		}
		/// <summary>
		/// 引物
		/// </summary>
		public string Primers
		{
			set{ _primers=value;}
			get{return _primers;}
		}
		/// <summary>
		/// 探针
		/// </summary>
		public string Probe
		{
			set{ _probe=value;}
			get{return _probe;}
		}
		/// <summary>
		/// 耗材
		/// </summary>
		public string Supplies
		{
			set{ _supplies=value;}
			get{return _supplies;}
		}
		/// <summary>
		/// 批号
		/// </summary>
		public string QCBatch
		{
			set{ _qcbatch=value;}
			get{return _qcbatch;}
		}
		/// <summary>
		/// 报告荧光
		/// </summary>
		public string ReportHighLighter
		{
			set { _reporthighlighter = value; }
			get { return _reporthighlighter; }
		}
		#endregion Model

	}
}

