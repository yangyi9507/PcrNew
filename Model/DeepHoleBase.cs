using System;
namespace PcrNew.Model
{
	/// <summary>
	/// DeepHoleBase:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class DeepHoleBase
	{
		public DeepHoleBase()
		{}
		#region Model
		private int? _holeid=0;
		private string _holename;
		private string _holexy;
		/// <summary>
		/// 孔位ID
		/// </summary>
		public int? HOLEID
		{
			set{ _holeid=value;}
			get{return _holeid;}
		}
		/// <summary>
		/// 孔位名称
		/// </summary>
		public string HOLENAME
		{
			set{ _holename=value;}
			get{return _holename;}
		}
		/// <summary>
		/// 空位坐标
		/// </summary>
		public string HOLEXY
		{
			set{ _holexy=value;}
			get{return _holexy;}
		}
		#endregion Model

	}
}

