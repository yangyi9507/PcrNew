using System;
using System.Data;
using System.Text;
using System.Data.OleDb;
using PcrNew.DBUtility;//Please add references
namespace PcrNew.DAL
{
	/// <summary>
	/// 数据访问类:DeepHoleBase
	/// </summary>
	public partial class DeepHoleBase
	{
		public DeepHoleBase()
		{}
		#region  BasicMethod



		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(PcrNew.Model.DeepHoleBase model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into DeepHoleBase(");
			strSql.Append("HOLEID,HOLENAME,HOLEXY)");
			strSql.Append(" values (");
			strSql.Append("@HOLEID,@HOLENAME,@HOLEXY)");
			OleDbParameter[] parameters = {
					new OleDbParameter("@HOLEID", OleDbType.Integer,4),
					new OleDbParameter("@HOLENAME", OleDbType.VarChar,255),
					new OleDbParameter("@HOLEXY", OleDbType.VarChar,255)};
			parameters[0].Value = model.HOLEID;
			parameters[1].Value = model.HOLENAME;
			parameters[2].Value = model.HOLEXY;

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
		public bool Update(PcrNew.Model.DeepHoleBase model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update DeepHoleBase set ");
			strSql.Append("HOLEID=@HOLEID,");
			strSql.Append("HOLENAME=@HOLENAME,");
			strSql.Append("HOLEXY=@HOLEXY");
			strSql.Append(" where ");
			OleDbParameter[] parameters = {
					new OleDbParameter("@HOLEID", OleDbType.Integer,4),
					new OleDbParameter("@HOLENAME", OleDbType.VarChar,255),
					new OleDbParameter("@HOLEXY", OleDbType.VarChar,255)};
			parameters[0].Value = model.HOLEID;
			parameters[1].Value = model.HOLENAME;
			parameters[2].Value = model.HOLEXY;

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
		public bool Delete()
		{
			//该表无主键信息，请自定义主键/条件字段
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from DeepHoleBase ");
			strSql.Append(" where ");
			OleDbParameter[] parameters = {
			};

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
		/// 得到一个对象实体
		/// </summary>
		public PcrNew.Model.DeepHoleBase GetModel()
		{
			//该表无主键信息，请自定义主键/条件字段
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select HOLEID,HOLENAME,HOLEXY from DeepHoleBase ");
			strSql.Append(" where ");
			OleDbParameter[] parameters = {
			};

			PcrNew.Model.DeepHoleBase model=new PcrNew.Model.DeepHoleBase();
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
		public PcrNew.Model.DeepHoleBase DataRowToModel(DataRow row)
		{
			PcrNew.Model.DeepHoleBase model=new PcrNew.Model.DeepHoleBase();
			if (row != null)
			{
				if(row["HOLEID"]!=null && row["HOLEID"].ToString()!="")
				{
					model.HOLEID=int.Parse(row["HOLEID"].ToString());
				}
				if(row["HOLENAME"]!=null)
				{
					model.HOLENAME=row["HOLENAME"].ToString();
				}
				if(row["HOLEXY"]!=null)
				{
					model.HOLEXY=row["HOLEXY"].ToString();
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select HOLEID,HOLENAME,HOLEXY ");
			strSql.Append(" FROM DeepHoleBase ");
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
			strSql.Append("select count(1) FROM DeepHoleBase ");
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
				strSql.Append("order by T. desc");
			}
			strSql.Append(")AS Row, T.*  from DeepHoleBase T ");
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
			parameters[0].Value = "DeepHoleBase";
			parameters[1].Value = "";
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

