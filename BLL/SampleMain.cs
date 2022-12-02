using System;
using System.Data;
using System.Collections.Generic;
using PcrNew.Model;
namespace PcrNew.BLL
{
	/// <summary>
	/// SampleMain
	/// </summary>
	public partial class SampleMain
	{
		private readonly PcrNew.DAL.SampleMain dal=new PcrNew.DAL.SampleMain();
		public SampleMain()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			return dal.GetMaxId();
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			return dal.Exists(ID);
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public DataTable ExistsByReportIDHoleID(string ReportID, string HoleId)
		{
			return dal.ExistsByReportIDHoleID(ReportID, HoleId);
		}
		
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(PcrNew.Model.SampleMain model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(PcrNew.Model.SampleMain model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool UpdateByID(PcrNew.Model.SampleMain model, int ID)
		{
			return dal.UpdateByID(model,ID);
		}
		

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int ID)
		{
			
			return dal.Delete(ID);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public PcrNew.Model.SampleMain GetModel(int ID)
		{
			
			return dal.GetModel(ID);
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<PcrNew.Model.SampleMain> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<PcrNew.Model.SampleMain> DataTableToList(DataTable dt)
		{
			List<PcrNew.Model.SampleMain> modelList = new List<PcrNew.Model.SampleMain>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				PcrNew.Model.SampleMain model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = dal.DataRowToModel(dt.Rows[n]);
					if (model != null)
					{
						modelList.Add(model);
					}
				}
			}
			return modelList;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}

		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			return dal.GetRecordCount(strWhere);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			return dal.GetListByPage( strWhere,  orderby,  startIndex,  endIndex);
		}

		/// <summary>
		/// 初始化添加样本列表信息
		/// </summary>
		public bool AddNULL(string strWhere,string holeid)
		{
			return dal.AddNULL(strWhere,holeid);
		}

		/// <summary>
		/// 更新列表样本信息
		/// </summary>
		public bool UPDATESAMPLE(PcrNew.Model.SampleMain model)
		{
			return dal.UPDATESAMPLE(model);
		}

		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
		//return dal.GetList(PageSize,PageIndex,strWhere);
		//}

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

