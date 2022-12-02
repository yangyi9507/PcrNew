using System;
using System.Data;
using System.Collections.Generic;
using PcrNew.Model;
namespace PcrNew.BLL
{
	/// <summary>
	/// ItemDetail
	/// </summary>
	public partial class ItemDetail
	{
		private readonly PcrNew.DAL.ItemDetail dal=new PcrNew.DAL.ItemDetail();
		public ItemDetail()
		{}
		#region  BasicMethod

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(PcrNew.Model.ItemDetail model)
		{
			return dal.Add(model);
		}

		//
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(int IDSelected,string ReportHL, PcrNew.Model.ItemDetail model)
		{
			return dal.Update(IDSelected, ReportHL, model);
		}



		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(int ID, string ItemName)
		{
			return dal.Update(ID, ItemName);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(PcrNew.Model.ItemDetail model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int ID,string ReportHighLighter)
		{
			//该表无主键信息，请自定义主键/条件字段
			return dal.Delete(ID,ReportHighLighter);
		}
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string MainID)
		{
			return dal.Exists(MainID);
		}
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool ExistsByReportID(string ReportID, string MainID )
		{
			return dal.ExistsByReportID(ReportID,MainID);
		}

		
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public PcrNew.Model.ItemDetail GetModel()
		{
			//该表无主键信息，请自定义主键/条件字段
			return dal.GetModel();
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
		public DataSet GetRList(int strWhere ,string R)
		{
			return dal.GetRList(strWhere,R);
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<PcrNew.Model.ItemDetail> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<PcrNew.Model.ItemDetail> DataTableToList(DataTable dt)
		{
			List<PcrNew.Model.ItemDetail> modelList = new List<PcrNew.Model.ItemDetail>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				PcrNew.Model.ItemDetail model;
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

