using System;
using System.Data;
using System.Text;
using System.Data.OleDb;
using PcrNew.DBUtility;//Please add references
namespace PcrNew.DAL
{
	/// <summary>
	/// 数据访问类:ItemMain
	/// </summary>
	public partial class ItemMain
	{
		public ItemMain()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperOleDb.GetMaxID("ID", "ItemMain"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool ExistsByReportIdItemName(string ReportId,string ItemName)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("select count(1) from ItemMain");
			strSql.Append(" where ReportID=@ReportId");
			strSql.Append(" AND ItemName=@ItemName");
			OleDbParameter[] parameters = {
					new OleDbParameter("@ReportID", OleDbType.VarChar,255),
					new OleDbParameter("@ItemName", OleDbType.VarChar,255)
			};
			parameters[0].Value = ReportId;
			parameters[1].Value = ItemName;

			return DbHelperOleDb.Exists(strSql.ToString(), parameters);
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool ExistsByReportId(string ReportId)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("select count(1) from ItemMain");
			strSql.Append(" where ReportID=@ReportId");
			OleDbParameter[] parameters = {
					new OleDbParameter("@ReportID", OleDbType.VarChar,255)
			};
			parameters[0].Value = ReportId;

			return DbHelperOleDb.Exists(strSql.ToString(), parameters);
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from ItemMain");
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
		public bool Add(PcrNew.Model.ItemMain model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into ItemMain(");
			strSql.Append("ReportID,ItemName)");
			strSql.Append(" values (");
			strSql.Append("@ReportID,@ItemName)");
			OleDbParameter[] parameters = {
					new OleDbParameter("@ReportID", OleDbType.VarChar,255),
					new OleDbParameter("@ItemName", OleDbType.VarChar,255)};
			parameters[0].Value = model.ReportID;
			parameters[1].Value = model.ItemName;

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
		public bool Update(int ID,string ItemName)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("update ItemMain set ");			
			strSql.Append("ItemName=@ItemName");
			strSql.Append(" where ID=@ID");
			OleDbParameter[] parameters = {
					new OleDbParameter("@ItemName", OleDbType.VarChar,255),
					new OleDbParameter("@ID", OleDbType.Integer,4)
			};
			parameters[0].Value = ItemName;
			parameters[1].Value = ID;

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
		public bool Update(PcrNew.Model.ItemMain model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update ItemMain set ");
			strSql.Append("ReportID=@ReportID,");
			strSql.Append("ItemName=@ItemName");
			strSql.Append(" where ID=@ID");
			OleDbParameter[] parameters = {
					new OleDbParameter("@ReportID", OleDbType.VarChar,255),
					new OleDbParameter("@ItemName", OleDbType.VarChar,255),
					new OleDbParameter("@ID", OleDbType.Integer,4),
					new OleDbParameter("@ItemLibraryType", OleDbType.Integer,4)};
			parameters[0].Value = model.ReportID;
			parameters[1].Value = model.ItemName;
			parameters[2].Value = model.ID;
			parameters[3].Value = model.ItemLibraryType;

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
		public bool Update(int ID)
		{

			StringBuilder strSql = new StringBuilder();
			strSql.Append("Update ItemMain set ");
			strSql.Append("ItemName=''");
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
		/// 删除一条数据
		/// </summary>
		public bool Delete(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from ItemMain ");
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
			strSql.Append("delete from ItemMain ");
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
		public PcrNew.Model.ItemMain GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID,ReportID,ItemLibraryType,ItemName from ItemMain ");
			strSql.Append(" where ID=@ID");
			OleDbParameter[] parameters = {
					new OleDbParameter("@ID", OleDbType.Integer,4)
			};
			parameters[0].Value = ID;

			PcrNew.Model.ItemMain model=new PcrNew.Model.ItemMain();
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
		public PcrNew.Model.ItemMain DataRowToModel(DataRow row)
		{
			PcrNew.Model.ItemMain model=new PcrNew.Model.ItemMain();
			if (row != null)
			{
				if(row["ID"]!=null && row["ID"].ToString()!="")
				{
					model.ID=int.Parse(row["ID"].ToString());
				}
				if(row["ReportID"]!=null)
				{
					model.ReportID=row["ReportID"].ToString();
				}
				if(row["ItemLibraryType"]!=null && row["ItemLibraryType"].ToString()!="")
				{
					model.ItemLibraryType=int.Parse(row["ItemLibraryType"].ToString());
				}
				if(row["ItemName"]!=null)
				{
					model.ItemName=row["ItemName"].ToString();
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetItem(string strWhere)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.AppendLine("SELECT A.ID,A.ItemName,B.ReportHighLighter,(A.ItemName + ' - ' + B.ReportHighLighter ) AS ItemName");
			strSql.AppendLine("FROM ItemMain AS A");
			strSql.AppendLine("LEFT JOIN ItemDetail AS B ON A.ID = B.MainID");			
			if (strWhere.Trim() != "")
			{
				strSql.AppendLine(" where " + strWhere);
			}
			return DbHelperOleDb.Query(strSql.ToString());
		}



		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetItemByReportID(string strWhere)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.AppendLine("select A.ID,A.ReportID, ");
			strSql.AppendLine("B.ItemName,B.ReportHighLighter,B.ItemColor,B.MasterMix,B.Primers,B.Probe,B.Supplies,B.QCBatch,A.ItemName,B.ItemColor ");
			strSql.AppendLine(" FROM ItemMain AS A");
			strSql.AppendLine(" LEFT JOIN ItemDetail AS B ON A.ID = B.MainID");
			if (strWhere.Trim() != "")
			{
				strSql.AppendLine(" where " + strWhere);
			}
			return DbHelperOleDb.Query(strSql.ToString());
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID,ReportID,ItemLibraryType,ItemName ");
			strSql.Append(" FROM ItemMain ");
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
			strSql.Append("select count(1) FROM ItemMain ");
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
			strSql.Append(")AS Row, T.*  from ItemMain T ");
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
			parameters[0].Value = "ItemMain";
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

