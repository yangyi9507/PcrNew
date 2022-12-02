using System;
using System.Data;
using System.Text;
using System.Data.OleDb;
using PcrNew.DBUtility;

namespace PcrNew.DAL
{
	/// <summary>
	/// 数据访问类:TestSteup
	/// </summary>
	public partial class TestSteup
	{
		public TestSteup()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperOleDb.GetMaxID("ID", "TestSteup"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from TestSteup");
			strSql.Append(" where ID=@ID");
			OleDbParameter[] parameters = {
					new OleDbParameter("@ID", OleDbType.Integer,4)
			};
			parameters[0].Value = ID;

			return DbHelperOleDb.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(PcrNew.Model.TestSteup model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into TestSteup(");
			strSql.Append(" ReportID,SteupID,SteupName,Temperature,SteupTime,TouchDown,TestSpeed,CollectFlg,SteupFlg,Circle)");
			strSql.Append(" values (");
			strSql.Append(" @ReportID,@SteupID,@SteupName,@Temperature,@SteupTime,@TouchDown,@TestSpeed,@CollectFlg,@SteupFlg,@Circle)");
			OleDbParameter[] parameters = {
				    new OleDbParameter("@ReportID", OleDbType.VarChar,255),
					new OleDbParameter("@SteupID", OleDbType.Integer,4),
					new OleDbParameter("@SteupName", OleDbType.VarChar,255),
					new OleDbParameter("@Temperature", OleDbType.VarChar,255),
					new OleDbParameter("@SteupTime", OleDbType.VarChar,255),
					new OleDbParameter("@TouchDown", OleDbType.VarChar,255),
					new OleDbParameter("@TestSpeed", OleDbType.VarChar,255),
					new OleDbParameter("@CollectFlg", OleDbType.Integer,4),
					new OleDbParameter("@SteupFlg", OleDbType.Integer,4),
			        new OleDbParameter("@Circle", OleDbType.Integer,4)};
			parameters[0].Value = model.ReportID;
			parameters[1].Value = model.SteupID;
			parameters[2].Value = model.SteupName;
			parameters[3].Value = model.Temperature;
			parameters[4].Value = model.SteupTime;
			parameters[5].Value = model.TouchDown;
			parameters[6].Value = model.TestSpeed;
			parameters[7].Value = model.CollectFlg;
			parameters[8].Value = model.SteupFlg;
			parameters[9].Value = model.Circle;

			int rows=DbHelperOleDb.ExecuteSql(strSql.ToString(),parameters);
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
		public bool Update(int SteupID, string SteupName)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("update TestSteup set ");
			strSql.Append("SteupName=@SteupName");
			strSql.Append(" where SteupID=@SteupID");
			OleDbParameter[] parameters = {
					new OleDbParameter("@SteupName", OleDbType.VarChar,255),
					new OleDbParameter("@SteupID", OleDbType.Integer,4)					
			};
			parameters[0].Value = SteupName;
			parameters[1].Value = SteupID;

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
		public bool Update(int ID ,PcrNew.Model.TestSteup model)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("update TestSteup set ");
			strSql.Append("Temperature=@Temperature,");
			strSql.Append("SteupTime=@SteupTime,");
			strSql.Append("TouchDown=@TouchDown,");
			strSql.Append("TestSpeed=@TestSpeed,");
			strSql.Append("CollectFlg=@CollectFlg");
			strSql.Append(" where ID=@ID");
			OleDbParameter[] parameters = {
					new OleDbParameter("@Temperature", OleDbType.VarChar,255),
					new OleDbParameter("@SteupTime", OleDbType.VarChar,255),
					new OleDbParameter("@TouchDown", OleDbType.VarChar,255),
					new OleDbParameter("@TestSpeed", OleDbType.VarChar,255),
					new OleDbParameter("@CollectFlg", OleDbType.Integer,4),
			        new OleDbParameter("@ID", OleDbType.Integer,4)};
			parameters[0].Value = model.Temperature;
			parameters[1].Value = model.SteupTime;
			parameters[2].Value = model.TouchDown;
			parameters[3].Value = model.TestSpeed;
			parameters[4].Value = model.CollectFlg;
			parameters[5].Value = ID;

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
		public bool UpdateCircle(int ID, int circle)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("update TestSteup set ");
			strSql.Append("Circle=" + circle);
			strSql.Append(" where ID=" + ID);

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
		/// 更新一条数据
		/// </summary>
		public bool Update(PcrNew.Model.TestSteup model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update TestSteup set ");
			strSql.Append("SteupID=@SteupID,");
			strSql.Append("SteupName=@SteupName,");
			strSql.Append("Temperature=@Temperature,");
			strSql.Append("SteupTime=@SteupTime,");
			strSql.Append("TouchDown=@TouchDown,");
			strSql.Append("TestSpeed=@TestSpeed,");
			strSql.Append("CollectFlg=@CollectFlg,");
			strSql.Append("SteupFlg=@SteupFlg");
			strSql.Append(" where ID=@ID");			
			OleDbParameter[] parameters = {
					new OleDbParameter("@SteupID", OleDbType.Integer,4),
					new OleDbParameter("@SteupName", OleDbType.VarChar,255),
					new OleDbParameter("@Temperature", OleDbType.VarChar,255),
					new OleDbParameter("@SteupTime", OleDbType.VarChar,255),
					new OleDbParameter("@TouchDown", OleDbType.VarChar,255),
					new OleDbParameter("@TestSpeed", OleDbType.VarChar,255),
					new OleDbParameter("@CollectFlg", OleDbType.Integer,4),
					new OleDbParameter("@SteupFlg", OleDbType.Integer,4),
					new OleDbParameter("@ID", OleDbType.Integer,4)};
			parameters[0].Value = model.SteupID;
			parameters[1].Value = model.SteupName;
			parameters[2].Value = model.Temperature;
			parameters[3].Value = model.SteupTime;
			parameters[4].Value = model.TouchDown;
			parameters[5].Value = model.TestSpeed;
			parameters[6].Value = model.CollectFlg;
			parameters[7].Value = model.SteupFlg;
			parameters[8].Value = model.ID;

			int rows=DbHelperOleDb.ExecuteSql(strSql.ToString(),parameters);
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
		public bool DeleteBySteupID(int SteupID)
		{

			StringBuilder strSql = new StringBuilder();
			strSql.Append("delete from TestSteup ");
			strSql.Append(" where SteupID=@SteupID");
			OleDbParameter[] parameters = {
					new OleDbParameter("@SteupID", OleDbType.Integer,4)
			};
			parameters[0].Value = SteupID;

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
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from TestSteup ");
			strSql.Append(" where ID=@ID");
			OleDbParameter[] parameters = {
					new OleDbParameter("@ID", OleDbType.Integer,4)
			};
			parameters[0].Value = ID;

			int rows=DbHelperOleDb.ExecuteSql(strSql.ToString(),parameters);
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
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from TestSteup ");
			strSql.Append(" where ID in ("+IDlist + ")  ");
			int rows=DbHelperOleDb.ExecuteSql(strSql.ToString());
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
		public PcrNew.Model.TestSteup GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID,SteupID,SteupName,Temperature,SteupTime,TouchDown,TestSpeed,CollectFlg,SteupFlg from TestSteup ");
			strSql.Append(" where ID=@ID");
			OleDbParameter[] parameters = {
					new OleDbParameter("@ID", OleDbType.Integer,4)
			};
			parameters[0].Value = ID;

			PcrNew.Model.TestSteup model=new PcrNew.Model.TestSteup();
			DataSet ds=DbHelperOleDb.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				return DataRowToModel(ds.Tables[0].Rows[0]);
			}
			else
			{
				return null;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public PcrNew.Model.TestSteup DataRowToModel(DataRow row)
		{
			PcrNew.Model.TestSteup model=new PcrNew.Model.TestSteup();
			if (row != null)
			{
				if(row["ID"]!=null && row["ID"].ToString()!="")
				{
					model.ID=int.Parse(row["ID"].ToString());
				}
				if(row["SteupID"]!=null && row["SteupID"].ToString()!="")
				{
					model.SteupID=int.Parse(row["SteupID"].ToString());
				}
				if(row["SteupName"]!=null)
				{
					model.SteupName=row["SteupName"].ToString();
				}
				if(row["Temperature"]!=null)
				{
					model.Temperature=row["Temperature"].ToString();
				}
				if(row["SteupTime"]!=null && row["SteupTime"].ToString()!="")
				{
					model.SteupTime=row["SteupTime"].ToString();
				}
				if(row["TouchDown"]!=null)
				{
					model.TouchDown=row["TouchDown"].ToString();
				}
				if(row["TestSpeed"]!=null)
				{
					model.TestSpeed=row["TestSpeed"].ToString();
				}
				if(row["CollectFlg"]!=null && row["CollectFlg"].ToString()!="")
				{
					model.CollectFlg=int.Parse(row["CollectFlg"].ToString());
				}
				if(row["SteupFlg"]!=null && row["SteupFlg"].ToString()!="")
				{
					model.SteupFlg=int.Parse(row["SteupFlg"].ToString());
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetListByReportID(string strWhere)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("select SteupID,SteupName ");
			strSql.Append(" FROM TestSteup ");
			if (strWhere.Trim() != "")
			{
				strSql.Append(" where " + strWhere);
			}
			strSql.Append(" GROUP BY SteupID,SteupName ");
			return DbHelperOleDb.Query(strSql.ToString());
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetListBySteupID(string strWhere)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("select ID,SteupName,Temperature,SteupTime,TouchDown,TestSpeed, iif(CollectFlg =0,'否','是') AS  Flg  ,SteupFlg ,Circle");
			strSql.Append(" FROM TestSteup ");
			if (strWhere.Trim() != "")
			{
				strSql.Append(" where " + strWhere);
			}
			return DbHelperOleDb.Query(strSql.ToString());
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID,SteupID,SteupName,Temperature,SteupTime,TouchDown,TestSpeed,CollectFlg,SteupFlg,Circle ");
			strSql.Append(" FROM TestSteup ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperOleDb.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM TestSteup ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			object obj = DbHelperOleDb.GetSingle(strSql.ToString());
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
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.ID desc");
			}
			strSql.Append(")AS Row, T.*  from TestSteup T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DbHelperOleDb.Query(strSql.ToString());
		}

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			OleDbParameter[] parameters = {
					new OleDbParameter("@tblName", OleDbType.VarChar, 255),
					new OleDbParameter("@fldName", OleDbType.VarChar, 255),
					new OleDbParameter("@PageSize", OleDbType.Integer),
					new OleDbParameter("@PageIndex", OleDbType.Integer),
					new OleDbParameter("@IsReCount", OleDbType.Boolean),
					new OleDbParameter("@OrderType", OleDbType.Boolean),
					new OleDbParameter("@strWhere", OleDbType.VarChar,1000),
					};
			parameters[0].Value = "TestSteup";
			parameters[1].Value = "ID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperOleDb.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

