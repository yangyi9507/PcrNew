using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
namespace PcrNew.BLL
{
	public partial class ModuleScan
	{

		private readonly PcrNew.DAL.ModuleScan dal = new PcrNew.DAL.ModuleScan();
		public ModuleScan()
		{ }

		#region  Method
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
		public int Add(PcrNew.Model.ModuleScan model)
		{
			return dal.Add(model);

		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(PcrNew.Model.ModuleScan model)
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
		/// 批量删除一批数据
		/// </summary>
		public bool DeleteList(string IDlist)
		{
			return dal.DeleteList(IDlist);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public PcrNew.Model.ModuleScan GetModel(int ID)
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
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top, string strWhere, string filedOrder)
		{
			return dal.GetList(Top, strWhere, filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<PcrNew.Model.ModuleScan> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<PcrNew.Model.ModuleScan> DataTableToList(DataTable dt)
		{
			List<PcrNew.Model.ModuleScan> modelList = new List<PcrNew.Model.ModuleScan>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				PcrNew.Model.ModuleScan model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new PcrNew.Model.ModuleScan();
					if (dt.Rows[n]["ID"].ToString() != "")
					{
						model.ID = int.Parse(dt.Rows[n]["ID"].ToString());
					}
					if (dt.Rows[n]["ScanMode"].ToString() != "")
					{
						model.ScanMode = int.Parse(dt.Rows[n]["ScanMode"].ToString());
					}
					model.deep = dt.Rows[n]["deep"].ToString();


					modelList.Add(model);
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
		#endregion

	}
}