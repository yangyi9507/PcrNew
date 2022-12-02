using PcrNew.DBUtility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PcrNew.DAL
{
	/// <summary>
	/// 数据访问类:Sample
	/// </summary>
	public partial class Sample
	{
		public Sample()
		{ }

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool AddSample(Model.Sample model)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("insert into SampleInformation(");
			strSql.Append("SamplID,SampleColor,SampleName,CreationTime,CensorshipTime,Experiment)");
			strSql.Append(" values (");
			strSql.Append("@SamplID,@SampleColor,@SampleName,@CreationTime,@CensorshipTime,@Experiment)");
			OleDbParameter[] parameters = {
					new OleDbParameter("@SamplID", OleDbType.Integer,4),
					new OleDbParameter("@SampleColor", OleDbType.VarChar,255),
					new OleDbParameter("@SampleName", OleDbType.VarChar,255),
					new OleDbParameter("@CreationTime", OleDbType.VarChar,255),
					new OleDbParameter("@CensorshipTime", OleDbType.VarChar,255),
					new OleDbParameter("@Experiment", OleDbType.VarChar,255)};
			parameters[0].Value = model.SamplID;
			parameters[1].Value = model.SampleColor;
			parameters[2].Value = model.SampleName;
			parameters[3].Value = model.CreationTime;
			parameters[4].Value = model.CensorshipTime;
			parameters[5].Value = model.Experiment;

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
		/// 增加一条数据
		/// </summary>
		public bool AddSampcheck(Model.Sample model)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("insert into CheckItemInformation(");
			strSql.Append("HoleSite,CheckItem,Attribute,Concentration)");
			strSql.Append(" values (");
			strSql.Append("@HoleSite,@CheckItem,@Attribute,@Concentration)");
			OleDbParameter[] parameters = {
					new OleDbParameter("@HoleSite", OleDbType.VarChar,255),
					new OleDbParameter("@CheckItem", OleDbType.VarChar,255),
					new OleDbParameter("@Attribute", OleDbType.VarChar,255),
					new OleDbParameter("@Concentration", OleDbType.VarChar,255)};

			parameters[0].Value = model.HoleSite;
			parameters[1].Value = model.CheckItem;
			parameters[2].Value = model.Attribute;
			parameters[3].Value = model.Concentration;

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
		/// 删除数据列表
		/// </summary>
		public bool DelCheckItem(String holeSite)
		{
			//删除对应ID行数据
			StringBuilder strSql = new StringBuilder();
			strSql.Append("delete from CheckItemInformation ");
			//strSql.Append(" where HoleSite in (" + holeSite + ")");

			strSql.Append(" where HoleSite = '" + holeSite + "'");

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
		/// 删除数据列表
		/// </summary>
		public bool DelCheckAll()
		{
			//删除对应ID行数据
			StringBuilder strSql = new StringBuilder();
			strSql.Append("delete from CheckItemInformation ");
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
		/// 获取查询数据列表
		/// </summary>
		public DataSet GetCheckItem(String holeSite)
		{
			string SQLString = "SELECT CheckItem,Attribute,Concentration FROM CheckItemInformation Where HoleSite = '" + holeSite + "'";
			return DBUtility.DbHelperOleDb.Query(SQLString);
		}

		/// <summary>
		/// 获取查询数据列表
		/// </summary>
		public DataSet GetSampleFyb(String TestName)
		{
			string SQLString = "SELECT SamplID,SampleColor,SampleName,CreationTime,CensorshipTime,ID FROM SampleInformation Where Experiment = '" + TestName + "'";
			return DBUtility.DbHelperOleDb.Query(SQLString);
		}

		/// <summary>
		/// 获取查询数据列表
		/// </summary>
		public DataSet GetDeepHoleData(String ReportID)
		{
			string SQLString = "select  A.HOLEID,HOLENAME,HOLEXY,SampleID,SampleName,SampleColor,ReportID,TestItem,HightLight,Attribute,Density,DensityUnit,CalDensity ";
			SQLString += " FROM DeepHoleBase AS A";
			SQLString += " LEFT JOIN SampleMAin AS B on A.HOLEXY = B.HOLEID";

			SQLString += " WHERE B.ReportID = '" + ReportID + "'";
			SQLString += " GROUP BY A.HOLEID,HOLENAME,HOLEXY,SampleID,SampleName,SampleColor,ReportID,TestItem,HightLight,Attribute,Density,DensityUnit,CalDensity";

			return DBUtility.DbHelperOleDb.Query(SQLString);
		}


		/// <summary>
		/// 获取查询数据列表
		/// </summary>
		public DataSet GetSample(String TestName)
		{
			string SQLString = "SELECT SamplID,SampleColor,SampleName,CreationTime,CensorshipTime,ID,SampleColor FROM SampleInformation Where Experiment = '" + TestName + "'";
			return DBUtility.DbHelperOleDb.Query(SQLString);
		}


		/// <summary>
		/// 获取查询数据id列表
		/// </summary>
		public DataSet GetSampleId(string id, string TestName)
		{
			string SQLString = "SELECT SamplID FROM SampleInformation Where Experiment = '" + TestName + "' AND SamplID in (" + id + ")";
			return DBUtility.DbHelperOleDb.Query(SQLString);
		}

		/// <summary>
		/// 获取查询数据列表
		/// </summary>
		public DataSet GetSampleID(string TestName, string Id)
		{
			string SQLString = "SELECT SamplID,SampleColor,SampleName,CreationTime,CensorshipTime,ID FROM SampleInformation Where Experiment = '" + TestName + "' AND SamplID = '" + Id + "'";
			return DBUtility.DbHelperOleDb.Query(SQLString);
		}
		public DataSet GetExportData(String TestName)
		{
			StringBuilder strSql = new StringBuilder();
			string SQLString = "SELECT SamplID AS 样本ID,SampleColor AS 样本颜色,SampleName AS 样本名称,CreationTime AS 采集时间,CensorshipTime AS 送检时间 FROM SampleInformation Where Experiment = '" + TestName + "'";
			return DBUtility.DbHelperOleDb.Query(SQLString);
		}

		/// <summary>
		/// 获取查询数据列表
		/// </summary>
		public bool DelSample(String id)
		{
			//删除对应ID行数据
			StringBuilder strSql = new StringBuilder();
			strSql.Append("delete from SampleInformation ");
			strSql.Append(" where ID in (" + id + ")");
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
		/// 获取查询数据列表
		/// </summary>
		public bool DelSampleAll(String Experiment)
		{
			//删除对应ID行数据
			StringBuilder strSql = new StringBuilder();
			strSql.Append("delete from SampleInformation ");
			strSql.Append(" where Experiment = '" + Experiment + "'");
			int rows = DBUtility.DbHelperOleDb.ExecuteSql(strSql.ToString());
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
		/// 更新样本信息一条数据
		/// </summary>
		public bool UpdateSample(String name, String color, String CreationTime, String giveTime, String Expriment, String id)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("update SampleInformation set ");
			strSql.Append("SampleName = '" + name + "',");
			strSql.Append("SampleColor = '" + color + "',");
			strSql.Append("CreationTime = '" + CreationTime + "',");
			strSql.Append("CensorshipTime = '" + giveTime + "'");
			strSql.Append(" where Experiment = '" + Expriment + "' AND ");
			strSql.Append("ID = " + id);
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

	}
}