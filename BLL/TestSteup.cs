using System;
using System.Data;
using System.Collections.Generic;
using PcrNew.Model;
namespace PcrNew.BLL
{
	/// <summary>
	/// TestSteup
	/// </summary>
	public partial class TestSteup
	{
		private readonly PcrNew.DAL.TestSteup dal=new PcrNew.DAL.TestSteup();
		public TestSteup()
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
		/// 增加一条数据
		/// </summary>
		public bool Add(PcrNew.Model.TestSteup model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(int SteupID, string SteupName)
		{
			return dal.Update(SteupID, SteupName);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(int ID,PcrNew.Model.TestSteup model)
		{
			return dal.Update(ID,model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool UpdateCircle(int ID, int circle)
		{
			return dal.UpdateCircle(ID, circle);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(PcrNew.Model.TestSteup model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int ID)
		{

			return dal.Delete(ID);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteBySteupID(int SteupID)
		{
			
			return dal.DeleteBySteupID(SteupID);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public PcrNew.Model.TestSteup GetModel(int ID)
		{
			
			return dal.GetModel(ID);
		}
		
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetListByReportID(string strWhere)
		{
			return dal.GetListByReportID(strWhere);
		}      
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetListBySteupID(string strWhere)
		{
			return dal.GetListBySteupID(strWhere);
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
		public List<PcrNew.Model.TestSteup> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<PcrNew.Model.TestSteup> DataTableToList(DataTable dt)
		{
			List<PcrNew.Model.TestSteup> modelList = new List<PcrNew.Model.TestSteup>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				PcrNew.Model.TestSteup model;
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

