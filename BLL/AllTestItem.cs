using System;
using System.Data;
using System.Collections.Generic;
namespace PcrNew.BLL
{
	/// <summary>
	/// AllTestItem
	/// </summary>
	public partial class AllTestItem
	{
		private readonly PcrNew.DAL.AllTestItem dal=new PcrNew.DAL.AllTestItem();
		public AllTestItem()
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
		public bool Exists(string libType, string ItemName)
		{
			return dal.Exists(libType, ItemName);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(PcrNew.Model.AllTestItem model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(string LibType,string NewName,string OldName)
		{
			return dal.Update(LibType, NewName, OldName);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(PcrNew.Model.AllTestItem model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除项目名称重复的数据
		/// </summary>
		public bool Delete(string LibType, string ItemName)
		{

			return dal.Delete(LibType,ItemName);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int ID)
		{
			
			return dal.Delete(ID);
		}
		///// <summary>
		///// 删除一条数据
		///// </summary>
		//public bool DeleteList(string IDlist )
		//{
		//	return dal.DeleteList(Maticsoft.Common.PageValidate.SafeLongFilter(IDlist,0) );
		//}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public PcrNew.Model.AllTestItem GetModel(int ID)
		{
			return dal.GetModel(ID);
		}

		///// <summary>
		///// 得到一个对象实体，从缓存中
		///// </summary>
		//public Maticsoft.Model.AllTestItem GetModelByCache(int ID)
		//{

		//	string CacheKey = "AllTestItemModel-" + ID;
		//	object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
		//	if (objModel == null)
		//	{
		//		try
		//		{
		//			objModel = dal.GetModel(ID);
		//			if (objModel != null)
		//			{
		//				int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
		//				Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
		//			}
		//		}
		//		catch{}
		//	}
		//	return (Maticsoft.Model.AllTestItem)objModel;
		//}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetItemList(string strWhere)
		{
			return dal.GetItemList(strWhere);
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}

		/// <summary>
		/// 获得数据列表两列颜色
		/// </summary>
		public DataSet GetColorList(string strWhere)
		{
			return dal.GetColorList(strWhere);
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<PcrNew.Model.AllTestItem> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<PcrNew.Model.AllTestItem> DataTableToList(DataTable dt)
		{
			List<PcrNew.Model.AllTestItem> modelList = new List<PcrNew.Model.AllTestItem>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				PcrNew.Model.AllTestItem model;
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

