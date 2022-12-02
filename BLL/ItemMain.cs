using System;
using System.Data;
using System.Collections.Generic;
using PcrNew.Model;
namespace PcrNew.BLL
{
	/// <summary>
	/// ItemMain
	/// </summary>
	public partial class ItemMain
	{
		private readonly PcrNew.DAL.ItemMain dal=new PcrNew.DAL.ItemMain();
		public ItemMain()
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
		public bool ExistsByReportIdItemName(string ReportID,string ItemName)
		{
			return dal.ExistsByReportIdItemName(ReportID,ItemName);
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool ExistsByReportId(string ReportID)
		{
			return dal.ExistsByReportId(ReportID);
		}
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(PcrNew.Model.ItemMain model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(int ID,string ItemName)
		{
			return dal.Update(ID, ItemName);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(PcrNew.Model.ItemMain model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(int ID)
		{

			return dal.Update(ID);
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
		public PcrNew.Model.ItemMain GetModel(int ID)
		{
			
			return dal.GetModel(ID);
		}
		

		public DataSet GetItem(string strWhere)
		{
			return dal.GetItem(strWhere);
		}

		public DataSet GetItemByReportID(string strWhere)
		{
			return dal.GetItemByReportID(strWhere);
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
		public List<PcrNew.Model.ItemMain> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<PcrNew.Model.ItemMain> DataTableToList(DataTable dt)
		{
			List<PcrNew.Model.ItemMain> modelList = new List<PcrNew.Model.ItemMain>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				PcrNew.Model.ItemMain model;
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

