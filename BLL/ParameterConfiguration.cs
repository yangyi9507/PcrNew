using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
namespace PcrNew.BLL
{
	public partial class ParameterConfiguration
	{

		private readonly PcrNew.DAL.ParameterConfiguration dal = new PcrNew.DAL.ParameterConfiguration();
		public ParameterConfiguration()
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
		public int Add(PcrNew.Model.ParameterConfiguration model)
		{
			return dal.Add(model);

		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(PcrNew.Model.ParameterConfiguration model)
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
		public PcrNew.Model.ParameterConfiguration GetModel(int ID)
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
		public List<PcrNew.Model.ParameterConfiguration> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<PcrNew.Model.ParameterConfiguration> DataTableToList(DataTable dt)
		{
			List<PcrNew.Model.ParameterConfiguration> modelList = new List<PcrNew.Model.ParameterConfiguration>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				PcrNew.Model.ParameterConfiguration model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new PcrNew.Model.ParameterConfiguration();
					if (dt.Rows[n]["ID"].ToString() != "")
					{
						model.ID = int.Parse(dt.Rows[n]["ID"].ToString());
					}
					model.FengHgiht = dt.Rows[n]["FengHgiht"].ToString();
					if (dt.Rows[n]["Thresholdline"].ToString() != "")
					{
						if ((dt.Rows[n]["Thresholdline"].ToString() == "1") || (dt.Rows[n]["Thresholdline"].ToString().ToLower() == "true"))
						{
							model.Thresholdline = true;
						}
						else
						{
							model.Thresholdline = false;
						}
					}
					if (dt.Rows[n]["PositiveControl"].ToString() != "")
					{
						if ((dt.Rows[n]["PositiveControl"].ToString() == "1") || (dt.Rows[n]["PositiveControl"].ToString().ToLower() == "true"))
						{
							model.PositiveControl = true;
						}
						else
						{
							model.PositiveControl = false;
						}
					}
					model.Ct = dt.Rows[n]["Ct"].ToString();
					model.Amplification = dt.Rows[n]["Amplification"].ToString();
					model.Noise = dt.Rows[n]["Noise"].ToString();
					model.NoiseNumber = dt.Rows[n]["NoiseNumber"].ToString();
					model.FittingParameters = dt.Rows[n]["FittingParameters"].ToString();
					model.FengNumber = dt.Rows[n]["FengNumber"].ToString();


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