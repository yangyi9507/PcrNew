using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PcrNew.BLL
{

	/// <summary>
	/// Sample
	/// </summary>
	public partial class Sample
	{
		private readonly PcrNew.DAL.Sample dal = new PcrNew.DAL.Sample();
		public Sample()
		{ }
		#region  BasicMethod


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool AddSample(Model.Sample model)
		{
			return dal.AddSample(model);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool AddSampcheck(Model.Sample model)
		{
			return dal.AddSampcheck(model);
		}

		/// <summary>
		/// 查询一条数据
		/// </summary>
		public DataSet GetSample(string Experiment)
		{
			return dal.GetSample(Experiment);
		}

		/// <summary>
		/// 查询一条数据
		/// </summary>
		public DataSet GetCheckItem(string holeSite)
		{
			return dal.GetCheckItem(holeSite);
		}

		/// <summary>
		/// 查询一条数据
		/// </summary>
		public DataSet GetSampleFyb(string Experiment)
		{
			return dal.GetSampleFyb(Experiment);
		}


		/// <summary>
		/// 查询一条数据
		/// </summary>
		public DataSet GetDeepHoleData(string ReportID)
		{
			return dal.GetDeepHoleData(ReportID);
		}

		/// <summary>
		/// 查询一条数据
		/// </summary>
		public DataSet GetSampleID(string experiment, string ID)
		{
			return dal.GetSampleID(experiment, ID);
		}

		public DataSet GetExportData(String Experiment)
		{
			return dal.GetExportData(Experiment);
		}

		/// <summary>
		/// 查询样本id数据
		/// </summary>
		public DataSet GetSampleId(string id, string Experiment)
		{
			return dal.GetSampleId(id, Experiment);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DelSample(string id)
		{
			return dal.DelSample(id);
		}

		/// <summary>
		/// 删除全部数据
		/// </summary>
		public bool DelSampleAll(string Experiment)
		{
			return dal.DelSampleAll(Experiment);
		}

		/// <summary>
		/// 删除全部数据
		/// </summary>
		public bool DelCheckAll()
		{
			return dal.DelCheckAll();
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DelCheckItem(string holeSite)
		{
			return dal.DelCheckItem(holeSite);
		}

		/// <summary>
		/// 更新样本信息一条数据
		/// </summary>
		public bool UpdateSample(String name, String color, String CreationTime, String giveTime, String Expriment, String id)
		{
			return dal.UpdateSample(name, color, CreationTime, giveTime, Expriment, id);
		}

		#endregion  BasicMethod

	}
}
