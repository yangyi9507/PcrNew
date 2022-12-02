using System;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using PcrNew.DBUtility;

namespace PcrNew.DAL
{
	public partial class ModuleScan
	{

		public bool Exists(int ID)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("select count(1) from ModuleScan");
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
		public int Add(PcrNew.Model.ModuleScan model)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("insert into ModuleScan(");
			strSql.Append("ScanMode,deep");
			strSql.Append(") values (");
			strSql.Append("@ScanMode,@deep");
			strSql.Append(") ");
			strSql.Append(";select @@IDENTITY");
			OleDbParameter[] parameters = {
						new OleDbParameter("@ScanMode", OleDbType.Integer,4) ,
						new OleDbParameter("@deep", OleDbType.VarChar,0)

			};

			parameters[0].Value = model.ScanMode;
			parameters[1].Value = model.deep;

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
		public bool Update(PcrNew.Model.ModuleScan model)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("update ModuleScan set ");
			strSql.Append(" ScanMode = @ScanMode,");
			strSql.Append(" deep = @deep  ");
			strSql.Append(" where ID=@ID ");

			OleDbParameter[] parameters = {
						new OleDbParameter("@ScanMode", OleDbType.Integer,4) ,
						new OleDbParameter("@deep", OleDbType.VarChar,255),
						new OleDbParameter("@ID", OleDbType.Integer,4)

			};

			parameters[0].Value = model.ScanMode;
			parameters[1].Value = model.deep;
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
			strSql.Append("delete from ModuleScan ");
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
			strSql.Append("delete from ModuleScan ");
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
		public PcrNew.Model.ModuleScan GetModel(int ID)
		{

			StringBuilder strSql = new StringBuilder();
			strSql.Append("select ID, ScanMode, deep  ");
			strSql.Append("  from ModuleScan ");
			strSql.Append(" where ID=@ID");
			OleDbParameter[] parameters = {
					new OleDbParameter("@ID", OleDbType.Integer,4)
			};
			parameters[0].Value = ID;


			PcrNew.Model.ModuleScan model = new PcrNew.Model.ModuleScan();
			DataSet ds = DbHelperOleDb.Query(strSql.ToString(), parameters);

			if (ds.Tables[0].Rows.Count > 0)
			{
				if (ds.Tables[0].Rows[0]["ID"].ToString() != "")
				{
					model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
				}
				if (ds.Tables[0].Rows[0]["ScanMode"].ToString() != "")
				{
					model.ScanMode = int.Parse(ds.Tables[0].Rows[0]["ScanMode"].ToString());
				}
				model.deep = ds.Tables[0].Rows[0]["deep"].ToString();

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
			strSql.Append(" FROM ModuleScan ");
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
			strSql.Append(" FROM ModuleScan ");
			if (strWhere.Trim() != "")
			{
				strSql.Append(" where " + strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperOleDb.Query(strSql.ToString());
		}


	}
}

