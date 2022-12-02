using System;
namespace PcrNew.Model
{
	/// <summary>
	/// TestSteup:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class TestSteup
	{
		public TestSteup()
		{}
		#region Model
		private int _id;
		private string _reportid;
		private int? _steupid=0;
		private string _steupname;
		private string _temperature;
		private string _steuptime;
		private string _touchdown;
		private string _testspeed;
		private int? _collectflg=0;
		private int? _steupflg=0;
		private int? _circle = 0;
		/// <summary>
		/// 
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 步骤ID(根据MaxID产生)
		/// </summary>
		public int? SteupID
		{
			set{ _steupid=value;}
			get{return _steupid;}
		}
		/// <summary>
		/// 报告单号
		/// </summary>
		public string ReportID
		{
			set { _reportid = value; }
			get { return _reportid; }
		}

		/// <summary>
		/// 阶段名称
		/// </summary>
		public string SteupName
		{
			set{ _steupname=value;}
			get{return _steupname;}
		}
		/// <summary>
		/// 温度
		/// </summary>
		public string Temperature
		{
			set{ _temperature=value;}
			get{return _temperature;}
		}
		/// <summary>
		/// 时间
		/// </summary>
		public string SteupTime
		{
			set{ _steuptime=value;}
			get{return _steuptime;}
		}
		/// <summary>
		/// TouchDown
		/// </summary>
		public string TouchDown
		{
			set{ _touchdown=value;}
			get{return _touchdown;}
		}
		/// <summary>
		/// 速率
		/// </summary>
		public string TestSpeed
		{
			set{ _testspeed=value;}
			get{return _testspeed;}
		}
		/// <summary>
		/// 信号采集 0：不采集 ； 1：采集
		/// </summary>
		public int? CollectFlg
		{
			set{ _collectflg=value;}
			get{return _collectflg;}
		}
		/// <summary>
		/// 0:恒温；1是循环
		/// </summary>
		public int? SteupFlg
		{
			set{ _steupflg=value;}
			get{return _steupflg;}
		}

		public int? Circle
		{
			set { _circle = value; }
			get { return _circle; }
		}
		#endregion Model

	}
}

