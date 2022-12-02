using System;
namespace PcrNew.Model
{
	/// <summary>
	/// ItemMain:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class ItemMain
	{
		public ItemMain()
		{}
		#region Model
		private int _id;
		private string _reportid;
		private int _itemlibrarytype=0;
		private string _itemname;
		/// <summary>
		/// 
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 报告ID
		/// </summary>
		public string ReportID
		{
			set{ _reportid=value;}
			get{return _reportid;}
		}
		/// <summary>
		/// 项目库类别  0:绝对定量;1:相对定量;2:SNP;3:高分辨率
		/// </summary>
		public int ItemLibraryType
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
		#endregion Model

	}
}

