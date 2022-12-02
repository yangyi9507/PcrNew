using System;
namespace PcrNew.Model
{
	/// <summary>
	/// ItemDetail:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class ItemDetail
	{
		public ItemDetail()
		{}
		#region Model
		private int? _mainid=0;
		private string _itemname;
		private string _reporthighlighter;
		private string _itemcolor;
		private string _mastermix;
		private string _primers;
		private string _probe;
		private string _supplies;
		private string _qcbatch;
		/// <summary>
		/// 用于和项目主表进行关联
		/// </summary>
		public int? MainID
		{
			set{ _mainid=value;}
			get{return _mainid;}
		}
		/// <summary>
		/// 项目名称(第一次创建项目有数据，其他的为空)
		/// </summary>
		public string ItemName
		{
			set{ _itemname=value;}
			get{return _itemname;}
		}
		/// <summary>
		/// 报告荧光
		/// </summary>
		public string ReportHighLighter
		{
			set{ _reporthighlighter=value;}
			get{return _reporthighlighter;}
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
		#endregion Model

	}
}

