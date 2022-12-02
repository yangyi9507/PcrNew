using System;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Data.OleDb;
using PcrNew.DBUtility;

namespace PcrNew.DAL
{
	public partial class GainSetting
	{

		public bool Exists(int ID)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("select count(1) from GainSetting");
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
        public Boolean Add(Model.GainSetting model)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("insert into GainSetting(");
			strSql.Append("gain,F1,F2,F3,F4,F5,F6");
			strSql.Append(") values (");
			strSql.Append("@gain,@F1,@F2,@F3,@F4,@F5,@F6");
			strSql.Append(")");
			OleDbParameter[] parameters = {
						new OleDbParameter("@gain", OleDbType.VarChar,255) ,
						new OleDbParameter("@F1", OleDbType.VarChar,255) ,
						new OleDbParameter("@F2", OleDbType.VarChar,255) ,
						new OleDbParameter("@F3", OleDbType.VarChar,255) ,
						new OleDbParameter("@F4", OleDbType.VarChar,255) ,
						new OleDbParameter("@F5", OleDbType.VarChar,255) ,
						new OleDbParameter("@F6", OleDbType.VarChar,255)
			};

			parameters[0].Value = model.gain;
			parameters[1].Value = model.F1;
			parameters[2].Value = model.F2;
			parameters[3].Value = model.F3;
			parameters[4].Value = model.F4;
			parameters[5].Value = model.F5;
			parameters[6].Value = model.F6;

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
		/// 更新一条数据
		/// </summary>
		public bool Update(PcrNew.Model.GainSetting model)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("update GainSetting set ");
			strSql.Append(" gain = @gain , ");
			strSql.Append(" F1 = @F1 , ");
			strSql.Append(" F2 = @F2 , ");
			strSql.Append(" F3 = @F3 , ");
			strSql.Append(" F4 = @F4 , ");
			strSql.Append(" F5 = @F5 , ");
			strSql.Append(" F6 = @F6  ");
			strSql.Append(" where ID=@ID ");

			OleDbParameter[] parameters = {
						
						new OleDbParameter("@gain", OleDbType.VarChar,255) ,
						new OleDbParameter("@F1", OleDbType.VarChar,255) ,
						new OleDbParameter("@F2", OleDbType.VarChar,255) ,
						new OleDbParameter("@F3", OleDbType.VarChar,255) ,
						new OleDbParameter("@F4", OleDbType.VarChar,255) ,
						new OleDbParameter("@F5", OleDbType.VarChar,255) ,
						new OleDbParameter("@F6", OleDbType.VarChar,255),
						new OleDbParameter("@ID", OleDbType.Integer,4)

			};

			parameters[0].Value = model.gain;
			parameters[1].Value = model.F1;
			parameters[2].Value = model.F2;
			parameters[3].Value = model.F3;
			parameters[4].Value = model.F4;
			parameters[5].Value = model.F5;
			parameters[6].Value = model.F6;
			parameters[7].Value = model.ID;
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
			strSql.Append("delete from GainSetting ");
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
			strSql.Append("delete from GainSetting ");
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
		public PcrNew.Model.GainSetting GetModel(int ID)
		{

			StringBuilder strSql = new StringBuilder();
			strSql.Append("select ID, gain, F1, F2, F3, F4, F5, F6  ");
			strSql.Append("  from GainSetting ");
			strSql.Append(" where ID=@ID");
			OleDbParameter[] parameters = {
					new OleDbParameter("@ID", OleDbType.Integer,4)
			};
			parameters[0].Value = ID;


			PcrNew.Model.GainSetting model = new PcrNew.Model.GainSetting();
			DataSet ds = DbHelperOleDb.Query(strSql.ToString(), parameters);

			if (ds.Tables[0].Rows.Count > 0)
			{
				if (ds.Tables[0].Rows[0]["ID"].ToString() != "")
				{
					model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
				}
				if (ds.Tables[0].Rows[0]["gain"].ToString() != "")
				{
					model.gain = ds.Tables[0].Rows[0]["gain"].ToString();
				}
				if (ds.Tables[0].Rows[0]["F1"].ToString() != "")
				{
					model.F1 = ds.Tables[0].Rows[0]["F1"].ToString();
				}
				if (ds.Tables[0].Rows[0]["F2"].ToString() != "")
				{
					model.F2 = ds.Tables[0].Rows[0]["F2"].ToString();
				}
				if (ds.Tables[0].Rows[0]["F3"].ToString() != "")
				{
					model.F3 = ds.Tables[0].Rows[0]["F3"].ToString();
				}
				if (ds.Tables[0].Rows[0]["F4"].ToString() != "")
				{
					model.F4 = ds.Tables[0].Rows[0]["F4"].ToString();
				}
				if (ds.Tables[0].Rows[0]["F5"].ToString() != "")
				{
					model.F5 = ds.Tables[0].Rows[0]["F5"].ToString();
				}
				if (ds.Tables[0].Rows[0]["F6"].ToString() != "")
				{
					model.F6 = ds.Tables[0].Rows[0]["F6"].ToString();
				}

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
			strSql.Append(" FROM GainSetting ");
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
			strSql.Append(" FROM GainSetting ");
			if (strWhere.Trim() != "")
			{
				strSql.Append(" where " + strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperOleDb.Query(strSql.ToString());
		}


	}
}

