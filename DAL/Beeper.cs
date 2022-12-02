using System;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using PcrNew.DBUtility;

namespace PcrNew.DAL
{
	public partial class Beeper
	{

		public bool Exists(int ID)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("select count(1) from Beeper");
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
		public int Add(PcrNew.Model.Beeper model)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("insert into Beeper(");
			strSql.Append("issetting,fengmingtime");
			strSql.Append(") values (");
			strSql.Append("@issetting,@fengmingtime");
			strSql.Append(") ");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
						new SqlParameter("@issetting", SqlDbType.VarChar,0) ,
						new SqlParameter("@fengmingtime", SqlDbType.VarChar,0)

			};

			parameters[0].Value = model.issetting;
			parameters[1].Value = model.fengmingtime;

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
		public bool Update(PcrNew.Model.Beeper model)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("update Beeper set ");

			strSql.Append(" issetting = @issetting , ");
			strSql.Append(" fengmingtime = @fengmingtime  ");
			strSql.Append(" where ID=@ID ");

			OleDbParameter[] parameters = {
						new OleDbParameter("@issetting", OleDbType.VarChar,255) ,
						new OleDbParameter("@fengmingtime", OleDbType.VarChar,255),
						new OleDbParameter("@ID", OleDbType.Integer,4)

			};

			
			parameters[0].Value = model.issetting;
			parameters[1].Value = model.fengmingtime;
			parameters[2].Value = model.ID;
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
			strSql.Append("delete from Beeper ");
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
			strSql.Append("delete from Beeper ");
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
		public PcrNew.Model.Beeper GetModel(int ID)
		{

			StringBuilder strSql = new StringBuilder();
			strSql.Append("select ID, issetting, fengmingtime  ");
			strSql.Append("  from Beeper ");
			strSql.Append(" where ID=@ID");
			OleDbParameter[] parameters = {
					new OleDbParameter("@ID", OleDbType.Integer,4)
			};
			parameters[0].Value = ID;


			PcrNew.Model.Beeper model = new PcrNew.Model.Beeper();
			DataSet ds = DbHelperOleDb.Query(strSql.ToString(), parameters);

			if (ds.Tables[0].Rows.Count > 0)
			{
				if (ds.Tables[0].Rows[0]["ID"].ToString() != "")
				{
					model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
				}
				model.issetting = ds.Tables[0].Rows[0]["issetting"].ToString();
				model.fengmingtime = ds.Tables[0].Rows[0]["fengmingtime"].ToString();

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
			strSql.Append(" FROM Beeper ");
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
			strSql.Append(" FROM Beeper ");
			if (strWhere.Trim() != "")
			{
				strSql.Append(" where " + strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperOleDb.Query(strSql.ToString());
		}


	}
}

