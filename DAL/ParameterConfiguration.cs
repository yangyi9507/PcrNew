using System;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using PcrNew.DBUtility;

namespace PcrNew.DAL
{
	public partial class ParameterConfiguration
	{

		public bool Exists(int ID)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("select count(1) from ParameterConfiguration");
			strSql.Append(" where ");
			strSql.Append(" ID = @ID  ");
			OleDbParameter[] parameters = {
					new OleDbParameter("@ID", OleDbType.Integer,4)
			};
			parameters[0].Value = ID;

			return DbHelperOleDb.Exists(strSql.ToString(), parameters);
		}



		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(PcrNew.Model.ParameterConfiguration model)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("insert into ParameterConfiguration(");
			strSql.Append("FengHgiht,Thresholdline,PositiveControl,Ct,Amplification,Noise,NoiseNumber,FittingParameters,FengNumber");
			strSql.Append(") values (");
			strSql.Append("@FengHgiht,@Thresholdline,@PositiveControl,@Ct,@Amplification,@Noise,@NoiseNumber,@FittingParameters,@FengNumber");
			strSql.Append(") ");
			strSql.Append(";select @@IDENTITY");
			OleDbParameter[] parameters = {
						new OleDbParameter("@FengHgiht", OleDbType.VarChar,0) ,
						new OleDbParameter("@Thresholdline", OleDbType.Boolean,1) ,
						new OleDbParameter("@PositiveControl", OleDbType.Boolean,1) ,
						new OleDbParameter("@Ct", OleDbType.VarChar,255) ,
						new OleDbParameter("@Amplification", OleDbType.VarChar,255) ,
						new OleDbParameter("@Noise", OleDbType.VarChar,255) ,
						new OleDbParameter("@NoiseNumber", OleDbType.VarChar,255) ,
						new OleDbParameter("@FittingParameters", OleDbType.VarChar,255) ,
						new OleDbParameter("@FengNumber", OleDbType.VarChar,255)

			};

			parameters[0].Value = model.FengHgiht;
			parameters[1].Value = model.Thresholdline;
			parameters[2].Value = model.PositiveControl;
			parameters[3].Value = model.Ct;
			parameters[4].Value = model.Amplification;
			parameters[5].Value = model.Noise;
			parameters[6].Value = model.NoiseNumber;
			parameters[7].Value = model.FittingParameters;
			parameters[8].Value = model.FengNumber;

			object obj = DbHelperOleDb.GetSingle(strSql.ToString(), parameters);
			if (obj == null)
			{
				return 0;
			}
			else
			{

				return Convert.ToInt32(obj);

			}

		}


		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(PcrNew.Model.ParameterConfiguration model)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("update ParameterConfiguration set ");

			strSql.Append(" FengHgiht = @FengHgiht , ");
			strSql.Append(" Thresholdline = @Thresholdline , ");
			strSql.Append(" PositiveControl = @PositiveControl , ");
			strSql.Append(" Ct = @Ct , ");
			strSql.Append(" Amplification = @Amplification , ");
			strSql.Append(" Noise = @Noise , ");
			strSql.Append(" NoiseNumber = @NoiseNumber , ");
			strSql.Append(" FittingParameters = @FittingParameters , ");
			strSql.Append(" FengNumber = @FengNumber  ");
			strSql.Append(" where ID=@ID ");

			OleDbParameter[] parameters = {
						new OleDbParameter("@FengHgiht", OleDbType.VarChar,255) ,
						new OleDbParameter("@Thresholdline", OleDbType.Boolean,1) ,
						new OleDbParameter("@PositiveControl", OleDbType.Boolean,1) ,
						new OleDbParameter("@Ct", OleDbType.VarChar,255) ,
						new OleDbParameter("@Amplification", OleDbType.VarChar,255) ,
						new OleDbParameter("@Noise", OleDbType.VarChar,255) ,
						new OleDbParameter("@NoiseNumber", OleDbType.VarChar,255) ,
						new OleDbParameter("@FittingParameters", OleDbType.VarChar,255) ,
						new OleDbParameter("@FengNumber", OleDbType.VarChar,255),
						new OleDbParameter("@ID", OleDbType.Integer,4) 

			};

			parameters[0].Value = model.FengHgiht;
			parameters[1].Value = model.Thresholdline;
			parameters[2].Value = model.PositiveControl;
			parameters[3].Value = model.Ct;
			parameters[4].Value = model.Amplification;
			parameters[5].Value = model.Noise;
			parameters[6].Value = model.NoiseNumber;
			parameters[7].Value = model.FittingParameters;
			parameters[8].Value = model.FengNumber;
			parameters[9].Value = model.ID;
			int rows = DbHelperOleDb.ExecuteSql(strSql.ToString(), parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}


		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int ID)
		{

			StringBuilder strSql = new StringBuilder();
			strSql.Append("delete from ParameterConfiguration ");
			strSql.Append(" where ID=@ID");
			OleDbParameter[] parameters = {
					new OleDbParameter("@ID", OleDbType.Integer,4)
			};
			parameters[0].Value = ID;


			int rows = DbHelperOleDb.ExecuteSql(strSql.ToString(), parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// 批量删除一批数据
		/// </summary>
		public bool DeleteList(string IDlist)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("delete from ParameterConfiguration ");
			strSql.Append(" where ID in (" + IDlist + ")  ");
			int rows = DbHelperOleDb.ExecuteSql(strSql.ToString());
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public PcrNew.Model.ParameterConfiguration GetModel(int ID)
		{

			StringBuilder strSql = new StringBuilder();
			strSql.Append("select ID, FengHgiht, Thresholdline, PositiveControl, Ct, Amplification, Noise, NoiseNumber, FittingParameters, FengNumber  ");
			strSql.Append("  from ParameterConfiguration ");
			strSql.Append(" where ID=@ID");
			OleDbParameter[] parameters = {
					new OleDbParameter("@ID", OleDbType.Integer,4)
			};
			parameters[0].Value = ID;


			PcrNew.Model.ParameterConfiguration model = new PcrNew.Model.ParameterConfiguration();
			DataSet ds = DbHelperOleDb.Query(strSql.ToString(), parameters);

			if (ds.Tables[0].Rows.Count > 0)
			{
				if (ds.Tables[0].Rows[0]["ID"].ToString() != "")
				{
					model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
				}
				model.FengHgiht = ds.Tables[0].Rows[0]["FengHgiht"].ToString();
				if (ds.Tables[0].Rows[0]["Thresholdline"].ToString() != "")
				{
					if ((ds.Tables[0].Rows[0]["Thresholdline"].ToString() == "1") || (ds.Tables[0].Rows[0]["Thresholdline"].ToString().ToLower() == "true"))
					{
						model.Thresholdline = true;
					}
					else
					{
						model.Thresholdline = false;
					}
				}
				if (ds.Tables[0].Rows[0]["PositiveControl"].ToString() != "")
				{
					if ((ds.Tables[0].Rows[0]["PositiveControl"].ToString() == "1") || (ds.Tables[0].Rows[0]["PositiveControl"].ToString().ToLower() == "true"))
					{
						model.PositiveControl = true;
					}
					else
					{
						model.PositiveControl = false;
					}
				}
				model.Ct = ds.Tables[0].Rows[0]["Ct"].ToString();
				model.Amplification = ds.Tables[0].Rows[0]["Amplification"].ToString();
				model.Noise = ds.Tables[0].Rows[0]["Noise"].ToString();
				model.NoiseNumber = ds.Tables[0].Rows[0]["NoiseNumber"].ToString();
				model.FittingParameters = ds.Tables[0].Rows[0]["FittingParameters"].ToString();
				model.FengNumber = ds.Tables[0].Rows[0]["FengNumber"].ToString();

				return model;
			}
			else
			{
				return null;
			}
		}


		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("select * ");
			strSql.Append(" FROM ParameterConfiguration ");
			if (strWhere.Trim() != "")
			{
				strSql.Append(" where " + strWhere);
			}
			return DbHelperOleDb.Query(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top, string strWhere, string filedOrder)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("select ");
			if (Top > 0)
			{
				strSql.Append(" top " + Top.ToString());
			}
			strSql.Append(" * ");
			strSql.Append(" FROM ParameterConfiguration ");
			if (strWhere.Trim() != "")
			{
				strSql.Append(" where " + strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperOleDb.Query(strSql.ToString());
		}


	}
}

