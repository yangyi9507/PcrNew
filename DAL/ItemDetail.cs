using System;
using System.Data;
using System.Text;
using System.Data.OleDb;
using PcrNew.DBUtility;//Please add references
namespace PcrNew.DAL
{
	/// <summary>
	/// 数据访问类:ItemDetail
	/// </summary>
	public partial class ItemDetail
	{
		public ItemDetail()
		{}
		#region  BasicMethod



		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(PcrNew.Model.ItemDetail model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into ItemDetail(");
			strSql.Append("MainID,ItemName,ReportHighLighter,ItemColor,MasterMix,Primers,Probe,Supplies,QCBatch)");
			strSql.Append(" values (");
			strSql.Append("@MainID,@ItemName,@ReportHighLighter,@ItemColor,@MasterMix,@Primers,@Probe,@Supplies,@QCBatch)");
			OleDbParameter[] parameters = {
					new OleDbParameter("@MainID", OleDbType.Integer,4),
					new OleDbParameter("@ItemName", OleDbType.VarChar,255),
					new OleDbParameter("@ReportHighLighter", OleDbType.VarChar,255),
					new OleDbParameter("@ItemColor", OleDbType.VarChar,255),
					new OleDbParameter("@MasterMix", OleDbType.VarChar,255),
					new OleDbParameter("@Primers", OleDbType.VarChar,255),
					new OleDbParameter("@Probe", OleDbType.VarChar,255),
					new OleDbParameter("@Supplies", OleDbType.VarChar,255),
					new OleDbParameter("@QCBatch", OleDbType.VarChar,255)};
			parameters[0].Value = model.MainID;
			parameters[1].Value = model.ItemName;
			parameters[2].Value = model.ReportHighLighter;
			parameters[3].Value = model.ItemColor;
			parameters[4].Value = model.MasterMix;
			parameters[5].Value = model.Primers;
			parameters[6].Value = model.Probe;
			parameters[7].Value = model.Supplies;
			parameters[8].Value = model.QCBatch;

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
		public bool Update(int ID, string ItemName)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("update ItemDetail set ");
			strSql.Append(" ItemName=@ItemName");
			strSql.Append(" where ");
			strSql.Append(" MainID=@MainID AND ");
			strSql.Append(" ItemName <> '' ");

			OleDbParameter[] parameters = {
					new OleDbParameter("@ItemName", OleDbType.VarChar,255),
					new OleDbParameter("@MainID", OleDbType.Integer,4)
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
		public bool Update(int IDSelected, string ReportHL, PcrNew.Model.ItemDetail model)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("update ItemDetail set ");						
			strSql.Append("ReportHighLighter=@ReportHighLighter,");
			strSql.Append("ItemColor=@ItemColor,");
			strSql.Append("MasterMix=@MasterMix,");
			strSql.Append("Primers=@Primers,");
			strSql.Append("Probe=@Probe,");
			strSql.Append("Supplies=@Supplies,");
			strSql.Append("QCBatch=@QCBatch");
			strSql.Append(" where ");
			strSql.Append(" MainID=@MainID AND ");
			strSql.Append(" ReportHighLighter=@ReportHL");
			OleDbParameter[] parameters = {										
					new OleDbParameter("@ReportHighLighter", OleDbType.VarChar,255),
					new OleDbParameter("@ItemColor", OleDbType.VarChar,255),
					new OleDbParameter("@MasterMix", OleDbType.VarChar,255),
					new OleDbParameter("@Primers", OleDbType.VarChar,255),
					new OleDbParameter("@Probe", OleDbType.VarChar,255),
					new OleDbParameter("@Supplies", OleDbType.VarChar,255),
					new OleDbParameter("@QCBatch", OleDbType.VarChar,255),
					new OleDbParameter("@MainID", OleDbType.Integer,4),
					new OleDbParameter("@ReportHL", OleDbType.VarChar,255)
			};

			parameters[0].Value = model.ReportHighLighter;
			parameters[1].Value = model.ItemColor;
			parameters[2].Value = model.MasterMix;
			parameters[3].Value = model.Primers;
			parameters[4].Value = model.Probe;
			parameters[5].Value = model.Supplies;
			parameters[6].Value = model.QCBatch;
			parameters[7].Value = IDSelected;
			parameters[8].Value = ReportHL;

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
		public bool Update(PcrNew.Model.ItemDetail model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update ItemDetail set ");
			strSql.Append("MainID=@MainID,");
			strSql.Append("ItemName=@ItemName,");
			strSql.Append("ReportHighLighter=@ReportHighLighter,");
			strSql.Append("ItemColor=@ItemColor,");
			strSql.Append("MasterMix=@MasterMix,");
			strSql.Append("Primers=@Primers,");
			strSql.Append("Probe=@Probe,");
			strSql.Append("Supplies=@Supplies,");
			strSql.Append("QCBatch=@QCBatch");
			strSql.Append(" where ");
			OleDbParameter[] parameters = {
					new OleDbParameter("@MainID", OleDbType.Integer,4),
					new OleDbParameter("@ItemName", OleDbType.VarChar,255),
					new OleDbParameter("@ReportHighLighter", OleDbType.VarChar,255),
					new OleDbParameter("@ItemColor", OleDbType.VarChar,255),
					new OleDbParameter("@MasterMix", OleDbType.VarChar,255),
					new OleDbParameter("@Primers", OleDbType.VarChar,255),
					new OleDbParameter("@Probe", OleDbType.VarChar,255),
					new OleDbParameter("@Supplies", OleDbType.VarChar,255),
					new OleDbParameter("@QCBatch", OleDbType.VarChar,255)};
			parameters[0].Value = model.MainID;
			parameters[1].Value = model.ItemName;
			parameters[2].Value = model.ReportHighLighter;
			parameters[3].Value = model.ItemColor;
			parameters[4].Value = model.MasterMix;
			parameters[5].Value = model.Primers;
			parameters[6].Value = model.Probe;
			parameters[7].Value = model.Supplies;
			parameters[8].Value = model.QCBatch;

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
		/// 是否存在该记录
		/// </summary>
		public bool ExistsByReportID(string ReportID, string MainID)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("select count(1) from ItemMain AS A");
			strSql.Append(" Left JOIN ItemDetail AS B ON A.ID = B.MAINID");
			strSql.Append(" where ReportID=@ReportID ");
			strSql.Append(" AND B.MainID <>@MainID ");
			OleDbParameter[] parameters = {
				new OleDbParameter("@ReportID", OleDbType.VarChar,255),
					new OleDbParameter("@MainID", OleDbType.Integer,4)
				};
			parameters[0].Value = ReportID;
			parameters[1].Value = MainID;

			return DbHelperOleDb.Exists(strSql.ToString(), parameters);
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string MainID)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("select count(1) from ItemDetail");
			strSql.Append(" where MainID=@MainID ");
			OleDbParameter[] parameters = {
					new OleDbParameter("@MainID", OleDbType.Integer,4)
				};
			parameters[0].Value = MainID;			

			return DbHelperOleDb.Exists(strSql.ToString(), parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int ID,string ReportHighLighter)
		{
			int rows = 0;
			//该表无主键信息，请自定义主键/条件字段
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from ItemDetail ");
			strSql.Append(" where ");
			strSql.Append(" MainID = @MainID");
			if (string.IsNullOrEmpty(ReportHighLighter))
			{
				OleDbParameter[] parameters = {
					new OleDbParameter("@MainID", OleDbType.Integer,4)				
				};
				parameters[0].Value = ID;
				rows = DbHelperOleDb.ExecuteSql(strSql.ToString(), parameters);
			}
			else {
				strSql.Append(" AND  ReportHighLighter = @ReportHighLighter");
				OleDbParameter[] parameters = {
				new OleDbParameter("@MainID", OleDbType.Integer,4),
				new OleDbParameter("@ReportHighLighter", OleDbType.VarChar,255)
			};
				parameters[0].Value = ID;
				parameters[1].Value = ReportHighLighter;
				rows = DbHelperOleDb.ExecuteSql(strSql.ToString(), parameters);
			}			 
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
		public PcrNew.Model.ItemDetail GetModel()
		{
			//该表无主键信息，请自定义主键/条件字段
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select MainID,ItemName,ReportHighLighter,ItemColor,MasterMix,Primers,Probe,Supplies,QCBatch from ItemDetail ");
			strSql.Append(" where ");
			OleDbParameter[] parameters = {
			};

			PcrNew.Model.ItemDetail model=new PcrNew.Model.ItemDetail();
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
		public PcrNew.Model.ItemDetail DataRowToModel(DataRow row)
		{
			PcrNew.Model.ItemDetail model=new PcrNew.Model.ItemDetail();
			if (row != null)
			{
				if(row["MainID"]!=null && row["MainID"].ToString()!="")
				{
					model.MainID=int.Parse(row["MainID"].ToString());
				}
				if(row["ItemName"]!=null)
				{
					model.ItemName=row["ItemName"].ToString();
				}
				if(row["ReportHighLighter"]!=null)
				{
					model.ReportHighLighter=row["ReportHighLighter"].ToString();
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
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select MainID,ItemName,ReportHighLighter,ItemColor,MasterMix,Primers,Probe,Supplies,QCBatch ");
			strSql.Append(" FROM ItemDetail ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperOleDb.Query(strSql.ToString());
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetRList(int id ,string ReportHighLighter)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("select ReportHighLighter");
			strSql.Append(" FROM ItemDetail");
			strSql.Append(" where MainID = " + id + "AND ReportHighLighter = '" + ReportHighLighter + "'");
			return DbHelperOleDb.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM ItemDetail ");
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
			strSql.Append(")AS Row, T.*  from ItemDetail T ");
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
			parameters[0].Value = "ItemDetail";
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

