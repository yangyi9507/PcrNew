using System;
using System.Data;
using System.Text;
using System.Data.OleDb;
using PcrNew.DBUtility;

namespace PcrNew.DAL
{
	/// <summary>
	/// 数据访问类:SampleMain
	/// </summary>
	public partial class SampleMain
	{
		public SampleMain()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperOleDb.GetMaxID("ID", "SampleMain"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from SampleMain");
			strSql.Append(" where ID=@ID");
			OleDbParameter[] parameters = {
					new OleDbParameter("@ID", OleDbType.Integer,4)
			};
			parameters[0].Value = ID;

			return DbHelperOleDb.Exists(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public DataTable ExistsByReportIDHoleID(string ReportID, string HoleId)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("select ID from SampleMain");
			strSql.Append(" where ReportID=@ReportID");
			strSql.Append(" AND HoleID=@HoleId");
			OleDbParameter[] parameters = {
					new OleDbParameter("@ReportID", OleDbType.VarChar,255),
					new OleDbParameter("@HoleID", OleDbType.VarChar,255)
			};
			parameters[0].Value = ReportID;
			parameters[1].Value = HoleId;
			
			DataSet ds =  DbHelperOleDb.Query(strSql.ToString(), parameters);

			if (ds.Tables[0].Rows.Count > 0)
			{
				return ds.Tables[0];
			}
			else
			{
				return null;
			}
		}

		
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(PcrNew.Model.SampleMain model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into SampleMain(");
			strSql.Append("HoleID,SampleID,SampleColor,SampleName,ReportID,TestItem,HightLight,Attribute,Density,DensityUnit,CalDensity)");
			strSql.Append(" values (");
			strSql.Append("@HoleID,@SampleID,@SampleColor,@SampleName,@ReportID,@TestItem,@HightLight,@Attribute,@Density,@DensityUnit,@CalDensity)");
			OleDbParameter[] parameters = {
					new OleDbParameter("@HoleID", OleDbType.VarChar,255),
					new OleDbParameter("@SampleID", OleDbType.VarChar,255),
					new OleDbParameter("@SampleColor", OleDbType.VarChar,255),
					new OleDbParameter("@SampleName", OleDbType.VarChar,255),
					new OleDbParameter("@ReportID", OleDbType.VarChar,255),
					new OleDbParameter("@TestItem", OleDbType.VarChar,255),
					new OleDbParameter("@HightLight", OleDbType.VarChar,255),
					new OleDbParameter("@Attribute", OleDbType.VarChar,255),
					new OleDbParameter("@Density", OleDbType.VarChar,255),
					new OleDbParameter("@DensityUnit", OleDbType.VarChar,255),
					new OleDbParameter("@CalDensity", OleDbType.VarChar,255)};
			parameters[0].Value = model.HoleID;
			parameters[1].Value = model.SampleID;
			parameters[2].Value = model.SampleColor;
			parameters[3].Value = model.SampleName;
			parameters[4].Value = model.ReportID;
			parameters[5].Value = model.TestItem;
			parameters[6].Value = model.HightLight;
			parameters[7].Value = model.Attribute;
			parameters[8].Value = model.Density;
			parameters[9].Value = model.DensityUnit;
			parameters[10].Value = model.CalDensity;

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
		public bool Update(PcrNew.Model.SampleMain model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update SampleMain set ");
			strSql.Append("HoleID=@HoleID,");
			strSql.Append("SampleID=@SampleID,");
			strSql.Append("SampleColor=@SampleColor,");
			strSql.Append("SampleName=@SampleName,");
			strSql.Append("ReportID=@ReportID,");
			strSql.Append("TestItem=@TestItem,");
			strSql.Append("HightLight=@HightLight,");
			strSql.Append("Attribute=@Attribute,");
			strSql.Append("Density=@Density,");
			strSql.Append("DensityUnit=@DensityUnit,");
			strSql.Append("CalDensity=@CalDensity");
			strSql.Append(" where ID=@ID");
			OleDbParameter[] parameters = {
					new OleDbParameter("@HoleID", OleDbType.VarChar,255),
					new OleDbParameter("@SampleID", OleDbType.VarChar,255),
					new OleDbParameter("@SampleColor", OleDbType.VarChar,255),
					new OleDbParameter("@SampleName", OleDbType.VarChar,255),
					new OleDbParameter("@ReportID", OleDbType.VarChar,255),
					new OleDbParameter("@TestItem", OleDbType.VarChar,255),
					new OleDbParameter("@HightLight", OleDbType.VarChar,255),
					new OleDbParameter("@Attribute", OleDbType.VarChar,255),
					new OleDbParameter("@Density", OleDbType.VarChar,255),
					new OleDbParameter("@DensityUnit", OleDbType.VarChar,255),
					new OleDbParameter("@CalDensity", OleDbType.VarChar,255),
					new OleDbParameter("@ID", OleDbType.Integer,4)};
			parameters[0].Value = model.HoleID;
			parameters[1].Value = model.SampleID;
			parameters[2].Value = model.SampleColor;
			parameters[3].Value = model.SampleName;
			parameters[4].Value = model.ReportID;
			parameters[5].Value = model.TestItem;
			parameters[6].Value = model.HightLight;
			parameters[7].Value = model.Attribute;
			parameters[8].Value = model.Density;
			parameters[9].Value = model.DensityUnit;
			parameters[10].Value = model.CalDensity;
			parameters[11].Value = model.ID;

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
		public bool UpdateByID(PcrNew.Model.SampleMain model,int ID)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("update SampleMain set ");			
			strSql.Append("SampleID=@SampleID,");
			strSql.Append("SampleColor=@SampleColor,");
			strSql.Append("SampleName=@SampleName");			
			strSql.Append(" where ID=@ID");
			OleDbParameter[] parameters = {					
					new OleDbParameter("@SampleID", OleDbType.VarChar,255),
					new OleDbParameter("@SampleColor", OleDbType.VarChar,255),
					new OleDbParameter("@SampleName", OleDbType.VarChar,255),
					new OleDbParameter("@ID", OleDbType.Integer,4)};			
			parameters[0].Value = model.SampleID;
			parameters[1].Value = model.SampleColor;
			parameters[2].Value = model.SampleName;
			parameters[3].Value = ID;

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
			strSql.Append("delete from SampleMain ");
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
			strSql.Append("delete from SampleMain ");
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
		public PcrNew.Model.SampleMain GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID,HoleID,SampleID,SampleColor,SampleName,ReportID,TestItem,HightLight,Attribute,Density,DensityUnit,CalDensity from SampleMain ");
			strSql.Append(" where ID=@ID");
			OleDbParameter[] parameters = {
					new OleDbParameter("@ID", OleDbType.Integer,4)
			};
			parameters[0].Value = ID;

			PcrNew.Model.SampleMain model=new PcrNew.Model.SampleMain();
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
		public PcrNew.Model.SampleMain DataRowToModel(DataRow row)
		{
			PcrNew.Model.SampleMain model=new PcrNew.Model.SampleMain();
			if (row != null)
			{
				if(row["ID"]!=null && row["ID"].ToString()!="")
				{
					model.ID=int.Parse(row["ID"].ToString());
				}
				if(row["HoleID"]!=null)
				{
					model.HoleID=row["HoleID"].ToString();
				}
				if(row["SampleID"]!=null)
				{
					model.SampleID=row["SampleID"].ToString();
				}
				if(row["SampleColor"]!=null)
				{
					model.SampleColor=row["SampleColor"].ToString();
				}
				if(row["SampleName"]!=null)
				{
					model.SampleName=row["SampleName"].ToString();
				}
				if(row["ReportID"]!=null)
				{
					model.ReportID=row["ReportID"].ToString();
				}
				if(row["TestItem"]!=null)
				{
					model.TestItem=row["TestItem"].ToString();
				}
				if(row["HightLight"]!=null)
				{
					model.HightLight=row["HightLight"].ToString();
				}
				if(row["Attribute"]!=null)
				{
					model.Attribute=row["Attribute"].ToString();
				}
				if(row["Density"]!=null)
				{
					model.Density=row["Density"].ToString();
				}
				if(row["DensityUnit"]!=null)
				{
					model.DensityUnit=row["DensityUnit"].ToString();
				}
				if(row["CalDensity"]!=null)
				{
					model.CalDensity=row["CalDensity"].ToString();
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
			strSql.Append("select ID,HoleID,SampleID,SampleColor,SampleName,ReportID,TestItem,HightLight,Attribute,Density,DensityUnit,CalDensity ");
			strSql.Append(" FROM SampleMain ");
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
			strSql.Append("select count(1) FROM SampleMain ");
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
			strSql.Append(")AS Row, T.*  from SampleMain T ");
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
			parameters[0].Value = "SampleMain";
			parameters[1].Value = "ID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperOleDb.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/		
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool AddNULL(String Example,String HoleID)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("insert into SampleMain(");
			strSql.Append("HoleID,ReportID)");
			strSql.Append(" values ('" + HoleID + "' ,'");
			strSql.Append( Example + "')");
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
		/// 更新样本一条数据
		/// </summary>
		public bool UPDATESAMPLE(PcrNew.Model.SampleMain model)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("update SampleMain set ");
			strSql.Append("SampleID=@SampleID,");
			strSql.Append("SampleColor=@SampleColor,");
			strSql.Append("SampleName=@SampleName");
			strSql.Append(" where ReportID=@ReportID ");
			strSql.Append("AND HoleID=@HoleID");
			OleDbParameter[] parameters = {
					new OleDbParameter("@SampleID", OleDbType.VarChar,255),
					new OleDbParameter("@SampleColor", OleDbType.VarChar,255),
					new OleDbParameter("@SampleName", OleDbType.VarChar,255),
					new OleDbParameter("@ReportID", OleDbType.VarChar,255),
				    new OleDbParameter("@HoleID", OleDbType.VarChar,255)};
			parameters[0].Value = model.SampleID;
			parameters[1].Value = model.SampleColor;
			parameters[2].Value = model.SampleName;
			parameters[3].Value = model.ReportID;
			parameters[4].Value = model.HoleID;
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

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

