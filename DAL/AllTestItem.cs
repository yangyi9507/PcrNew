using System;
using System.Data;
using System.Text;
using System.Data.OleDb;
using PcrNew.DBUtility;//Please add references
namespace PcrNew.DAL
{
	/// <summary>
	/// 数据访问类:AllTestItem
	/// </summary>
	public partial class AllTestItem
	{
		public AllTestItem()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperOleDb.GetMaxID("ID", "AllTestItem"); 
		}
		

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string libType, string ItemName)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("select count(1) from AllTestItem");
			strSql.Append(" where ItemLibraryType=@libType");
			strSql.Append(" AND ItemName=@ItemName");
			OleDbParameter[] parameters = {
					new OleDbParameter("@libType", OleDbType.Integer,4),
					new OleDbParameter("@ItemName", OleDbType.VarChar,255),
			};
			parameters[0].Value = libType;
			parameters[1].Value = ItemName;

			return DbHelperOleDb.Exists(strSql.ToString(), parameters);
		}
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from AllTestItem");
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
		public bool Add(PcrNew.Model.AllTestItem model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into AllTestItem(");
			strSql.Append("ItemLibraryType,ItemName,ItemColor,MasterMix,Primers,Probe,Supplies,QCBatch,ReportHighLighter)");
			strSql.Append(" values (");
			strSql.Append("@ItemLibraryType,@ItemName,@ItemColor,@MasterMix,@Primers,@Probe,@Supplies,@QCBatch,@ReportHighLighter)");
			OleDbParameter[] parameters = {
					new OleDbParameter("@ItemLibraryType", OleDbType.Integer,4),
					new OleDbParameter("@ItemName", OleDbType.VarChar,255),
					new OleDbParameter("@ItemColor", OleDbType.VarChar,255),
					new OleDbParameter("@MasterMix", OleDbType.VarChar,255),
					new OleDbParameter("@Primers", OleDbType.VarChar,255),
					new OleDbParameter("@Probe", OleDbType.VarChar,255),
					new OleDbParameter("@Supplies", OleDbType.VarChar,255),
					new OleDbParameter("@QCBatch", OleDbType.VarChar,255),
			new OleDbParameter("@ReportHighLighter", OleDbType.VarChar,255)};
			parameters[0].Value = model.ItemLibraryType;
			parameters[1].Value = model.ItemName;
			parameters[2].Value = model.ItemColor;
			parameters[3].Value = model.MasterMix;
			parameters[4].Value = model.Primers;
			parameters[5].Value = model.Probe;
			parameters[6].Value = model.Supplies;
			parameters[7].Value = model.QCBatch;
			parameters[8].Value = model.ReportHighLighter;

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
		public bool Update(string LibType, string NewName, string OldName)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("update AllTestItem set ");			
			strSql.Append("ItemName=@NewName");
			strSql.Append(" where ItemLibraryType=@LibType");
			strSql.Append(" AND ItemName=@OldName");			
			OleDbParameter[] parameters = {
					new OleDbParameter("@NewName", OleDbType.VarChar,255),
					new OleDbParameter("@LibType", OleDbType.Integer,4),
					new OleDbParameter("@OldName", OleDbType.VarChar,255),};
			parameters[0].Value = NewName;
			parameters[1].Value = LibType;
			parameters[2].Value = OldName;

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
		public bool Update(PcrNew.Model.AllTestItem model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update AllTestItem set ");
			strSql.Append("ItemLibraryType=@ItemLibraryType,");
			strSql.Append("ItemName=@ItemName,");
			strSql.Append("ItemColor=@ItemColor,");
			strSql.Append("MasterMix=@MasterMix,");
			strSql.Append("Primers=@Primers,");
			strSql.Append("Probe=@Probe,");
			strSql.Append("Supplies=@Supplies,");
			strSql.Append("QCBatch=@QCBatch,");
			strSql.Append("ReportHighLighter=@ReportHighLighter");
			strSql.Append(" where ID=@ID");
			OleDbParameter[] parameters = {
					new OleDbParameter("@ItemLibraryType", OleDbType.Integer,4),
					new OleDbParameter("@ItemName", OleDbType.VarChar,255),
					new OleDbParameter("@ItemColor", OleDbType.VarChar,255),
					new OleDbParameter("@MasterMix", OleDbType.VarChar,255),
					new OleDbParameter("@Primers", OleDbType.VarChar,255),
					new OleDbParameter("@Probe", OleDbType.VarChar,255),
					new OleDbParameter("@Supplies", OleDbType.VarChar,255),
					new OleDbParameter("@QCBatch", OleDbType.VarChar,255),
					new OleDbParameter("@ReportHighLighter", OleDbType.VarChar,255),
					new OleDbParameter("@ID", OleDbType.Integer,4)};
			parameters[0].Value = model.ItemLibraryType;
			parameters[1].Value = model.ItemName;
			parameters[2].Value = model.ItemColor;
			parameters[3].Value = model.MasterMix;
			parameters[4].Value = model.Primers;
			parameters[5].Value = model.Probe;
			parameters[6].Value = model.Supplies;
			parameters[7].Value = model.QCBatch;
			parameters[8].Value = model.ReportHighLighter;
			parameters[9].Value = model.ID;

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
		public bool Delete(string LibType,string ItemName)
		{

			StringBuilder strSql = new StringBuilder();
			strSql.Append("delete from AllTestItem ");
			strSql.Append(" where ItemName=@ItemName");
			strSql.Append(" AND ItemLibraryType=@LibType");
			OleDbParameter[] parameters = {
					new OleDbParameter("@ItemName", OleDbType.VarChar,255),
					new OleDbParameter("@ItemLibraryType", OleDbType.VarChar,255)
			};
			parameters[0].Value = ItemName;
			parameters[1].Value = LibType;

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
			strSql.Append("delete from AllTestItem ");
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
			strSql.Append("delete from AllTestItem ");
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
		public PcrNew.Model.AllTestItem GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID,ItemLibraryType,ItemName,ItemColor,MasterMix,Primers,Probe,Supplies,QCBatch,ReportHighLighter from AllTestItem ");
			strSql.Append(" where ID=@ID");
			OleDbParameter[] parameters = {
					new OleDbParameter("@ID", OleDbType.Integer,4)
			};
			parameters[0].Value = ID;

			PcrNew.Model.AllTestItem model=new PcrNew.Model.AllTestItem();
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
		public PcrNew.Model.AllTestItem DataRowToModel(DataRow row)
		{
			PcrNew.Model.AllTestItem model=new PcrNew.Model.AllTestItem();
			if (row != null)
			{
				if(row["ID"]!=null && row["ID"].ToString()!="")
				{
					model.ID=int.Parse(row["ID"].ToString());
				}
				if(row["ItemLibraryType"]!=null && row["ItemLibraryType"].ToString()!="")
				{
					model.ItemLibraryType=int.Parse(row["ItemLibraryType"].ToString());
				}
				if(row["ItemName"]!=null)
				{
					model.ItemName=row["ItemName"].ToString();
				}
				if(row["ItemColor"]!=null)
				{
					model.ItemColor=row["ItemColor"].ToString();
				}
				if(row["MasterMix"]!=null)
				{
					model.MasterMix=row["MasterMix"].ToString();
				}
				if(row["Primers"]!=null)
				{
					model.Primers=row["Primers"].ToString();
				}
				if(row["Probe"]!=null)
				{
					model.Probe=row["Probe"].ToString();
				}
				if(row["Supplies"]!=null)
				{
					model.Supplies=row["Supplies"].ToString();
				}
				if(row["QCBatch"]!=null)
				{
					model.QCBatch=row["QCBatch"].ToString();
				}
				if (row["ReportHighLighter"] != null)
				{
					model.QCBatch = row["ReportHighLighter"].ToString();
				}
				
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetItemList(string strWhere)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("select ItemName");
			strSql.Append(" FROM AllTestItem ");
			if (strWhere.Trim() != "")
			{
				strSql.Append(" where " + strWhere);
			}
			strSql.Append(" group by ItemName");
			return DbHelperOleDb.Query(strSql.ToString());
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID,ItemLibraryType,ItemName,ItemColor,MasterMix,Primers,Probe,Supplies,QCBatch,ReportHighLighter ");
			strSql.Append(" FROM AllTestItem ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperOleDb.Query(strSql.ToString());
		}

		/// <summary>
		/// 获得两列颜色数据列表
		/// </summary>
		public DataSet GetColorList(string strWhere)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("select ID,ItemLibraryType,ItemName,ItemColor,MasterMix,Primers,Probe,Supplies,QCBatch,ReportHighLighter,ItemColor ");
			strSql.Append(" FROM AllTestItem ");
			if (strWhere.Trim() != "")
			{
				strSql.Append(" where " + strWhere);
			}
			return DbHelperOleDb.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM AllTestItem ");
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
			strSql.Append(")AS Row, T.*  from AllTestItem T ");
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
			parameters[0].Value = "AllTestItem";
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

		//用户信息数据库条用方法

		/// <summary>
		/// 获得样本数据列表（条件查询）
		/// </summary>
		public DataSet GetSampleList(String strWhere )
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("select FileName,SampleID,SampleName,TestItems,SamplingTime,DetectionResult,ReferenceValue,StandardConcentration,ConcentrationUnit,Conclusion,Ct,Examiner,SubmissionTime,ReportName,Notes,Reviewer,Analysis ");
			strSql.Append("FROM Sample Where 1 = 1 ");
			strSql.Append(strWhere);
			return DbHelperOleDb.Query(strSql.ToString());
		}

		/// <summary>
		/// 获得样本数据列表(全部)
		/// </summary>
		public DataSet GetSampleListAll()
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("select FileName,SampleID,SampleName,TestItems,SamplingTime,DetectionResult,ReferenceValue,StandardConcentration,ConcentrationUnit,Conclusion,Ct,Examiner,SubmissionTime,ReportName,Notes,Reviewer,Analysis ");
			strSql.Append("FROM Sample ");
			return DbHelperOleDb.Query(strSql.ToString());
		}

		/// <summary>
		/// 查询登录用户名和密码是否正确
		/// </summary>
		public bool GetUserList(String strWhere1, String strWhere2)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("select username ");
			strSql.Append("FROM department Where username = '");
			strSql.Append(strWhere1 + "'");
			strSql.Append(" AND Password = '");
			strSql.Append(strWhere2 + "'");
			DataSet ds = DbHelperOleDb.Query(strSql.ToString());
			if (ds.Tables[0].Rows.Count > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		//查询用户名是否存在
		public bool GetUserName(String strWher)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("select username ");
			strSql.Append("From department Where username = '");
			strSql.Append(strWher + "'");
			DataSet ds = DbHelperOleDb.Query(strSql.ToString());
			if (ds.Tables[0].Rows.Count > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// 更新用户信息IP地址和最近登录时间一条数据
		/// </summary>
		public bool UpdateUserIP(String IP, String name, String time)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("update department set ");
			strSql.Append("LastLoginIP = '");
			strSql.Append(IP + "',");
			strSql.Append("LastLogonTime = '" + time + "'");
			strSql.Append(" where username = '");
			strSql.Append(name + "'");
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
		/// 更新用户登录密码一条数据
		/// </summary>
		public bool UpdateUserPowered(String powered, String name)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("update department set ");
			strSql.Append("[Password] = '");
			strSql.Append(powered + "'");
			strSql.Append(" where username = '");
			strSql.Append(name + "'");
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
		/// 更新用户信息
		/// </summary>
		public bool UpdateUser(int id, String name, bool lock1, String limit, String LimitCh)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("update department set ");
			strSql.Append("username = '" + name + "',");
			strSql.Append("is_Disable = " + lock1 + ",");
			strSql.Append("Limits = '" + limit + "',");
			strSql.Append("LimitsCh = '" + LimitCh + "'");
			strSql.Append(" where ID = ");
			strSql.Append(id);
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
		/// 获取用户信息一条数据
		/// </summary>
		public DataSet GetUser(String id)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("select username,is_Locking,Limits");
			strSql.Append("FROM department Where '");
			strSql.Append(id + "'");
			return DbHelperOleDb.Query(strSql.ToString());
		}

		/// <summary>
		/// 用户获取查询数据列表
		/// </summary>
		public DataSet GetUserAll()
		{
			StringBuilder strSql = new StringBuilder();
			string SQLString = "SELECT ID,username,is_Disable,is_Locking,CreateTime,LastLogonTime,Limits,LimitsCH FROM department";
			return DBUtility.DbHelperOleDb.Query(SQLString);
		}
	}
}

