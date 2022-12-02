using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
namespace PcrNew.BLL
{
	public partial class GainSetting
	{

		private readonly PcrNew.DAL.GainSetting dal = new PcrNew.DAL.GainSetting();
		public GainSetting()
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
		public bool Add(PcrNew.Model.GainSetting model)
		{
			return dal.Add(model);

		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(PcrNew.Model.GainSetting model)
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
		public PcrNew.Model.GainSetting GetModel(int ID)
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
		public List<PcrNew.Model.GainSetting> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<PcrNew.Model.GainSetting> DataTableToList(DataTable dt)
		{
			List<PcrNew.Model.GainSetting> modelList = new List<PcrNew.Model.GainSetting>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				PcrNew.Model.GainSetting model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new PcrNew.Model.GainSetting();
					if (dt.Rows[n]["ID"].ToString() != "")
					{
						model.ID = int.Parse(dt.Rows[n]["ID"].ToString());
					}
					if (dt.Rows[n]["gain"].ToString() != "")
					{
						model.gain = dt.Rows[n]["gain"].ToString();
					}
					if (dt.Rows[n]["F1"].ToString() != "")
					{
						model.F1 = dt.Rows[n]["F1"].ToString();
					}
					if (dt.Rows[n]["F2"].ToString() != "")
					{
						model.F2 = dt.Rows[n]["F2"].ToString();
					}
					if (dt.Rows[n]["F3"].ToString() != "")
					{
						model.F3 = dt.Rows[n]["F3"].ToString();
					}
					if (dt.Rows[n]["F4"].ToString() != "")
					{
						model.F4 = dt.Rows[n]["F4"].ToString();
					}
					if (dt.Rows[n]["F5"].ToString() != "")
					{
						model.F5 = dt.Rows[n]["F5"].ToString();
					}
					if (dt.Rows[n]["F6"].ToString() != "")
					{
						model.F6 = dt.Rows[n]["F6"].ToString();
					}


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