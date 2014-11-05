using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using AdminManager.WcfService;
namespace AdminManager.DAL
{
	/// <summary>
	/// 数据访问类:tTaskLog
	/// </summary>
	public partial class TaskLogDAL
	{
		public TaskLogDAL()
		{}
		#region  BasicMethod

        EmployeeClient sc = new EmployeeClient();
		/// <summary>
		/// 增加一条数据
		/// </summary>
        public long Add(AdminManager.Model.TaskLogModel model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tTaskLog(");
			strSql.Append("EmployeeID,TaskID,Date,Remark)");
			strSql.Append(" values (");
			strSql.Append("@EmployeeID,@TaskID,@Date,@Remark)");
			strSql.Append(";select @@IDENTITY");

            StringSqlParam[] parameters = new StringSqlParam[4];
            parameters[0] = sc.getParams("@EmployeeID", model.EmployeeID, "BigInt");
            parameters[1] = sc.getParams("@TaskID", model.TaskID, "BigInt");
            parameters[2] = sc.getParams("@Date", model.Date, "DateTime");
            parameters[3] = sc.getParams("@Remark", model.Remark, "NVarChar");

            object obj = sc.TaskLog_Add(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt64(obj);
            }
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
        public bool Update(AdminManager.Model.TaskLogModel model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tTaskLog set ");
			strSql.Append("EmployeeID=@EmployeeID,");
			strSql.Append("TaskID=@TaskID,");
			strSql.Append("Date=@Date,");
			strSql.Append("Remark=@Remark");
			strSql.Append(" where ID=@ID");
            StringSqlParam[] parameters = new StringSqlParam[5];
            parameters[0] = sc.getParams("@EmployeeID", model.EmployeeID, "BigInt");
            parameters[1] = sc.getParams("@TaskID", model.TaskID, "BigInt");
            parameters[2] = sc.getParams("@Date", model.Date, "DateTime");
            parameters[3] = sc.getParams("@Remark", model.Remark, "NVarChar");
            parameters[4] = sc.getParams("@ID", model.ID, "BigInt");

            return sc.TaskLog_Update(strSql.ToString(), parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
        public AdminManager.Model.TaskLogModel GetModel(long ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,EmployeeID,TaskID,Date,Remark from tTaskLog ");
			strSql.Append(" where ID=@ID");
            StringSqlParam[] parameters = new StringSqlParam[1];

            parameters[0] = sc.getParams("@ID", ID, "BigInt");


            AdminManager.Model.OrderModel model = new AdminManager.Model.OrderModel();
            DataSet ds = sc.TaskLog_GetModel(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
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
        public AdminManager.Model.TaskLogModel DataRowToModel(DataRow row)
		{
            AdminManager.Model.TaskLogModel model = new AdminManager.Model.TaskLogModel();
			if (row != null)
			{
				if(row["ID"]!=null && row["ID"].ToString()!="")
				{
					model.ID=long.Parse(row["ID"].ToString());
				}
				if(row["EmployeeID"]!=null && row["EmployeeID"].ToString()!="")
				{
					model.EmployeeID=long.Parse(row["EmployeeID"].ToString());
				}
				if(row["TaskID"]!=null && row["TaskID"].ToString()!="")
				{
					model.TaskID=long.Parse(row["TaskID"].ToString());
				}
				if(row["Date"]!=null && row["Date"].ToString()!="")
				{
					model.Date=DateTime.Parse(row["Date"].ToString());
				}
				if(row["Remark"]!=null)
				{
					model.Remark=row["Remark"].ToString();
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
			strSql.Append("select ID,EmployeeID,TaskID,Date,Remark ");
			strSql.Append(" FROM tTaskLog ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
            return sc.TaskLog_GetList(strSql.ToString());
		}

		/// <summary>
		/// 分页获取数据列表
		/// </summary>
        public DataSet GetListByPage(int PageSize, int PageIndex, string strWhere, string orderStr, out int totalCount)
		{
            return sc.TaskLog_GetListByPage(PageSize, PageIndex, strWhere, orderStr, out totalCount);
		}
		#endregion  BasicMethod
	}
}

