using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using AdminManager.WcfService;
namespace AdminManager.DAL
{
	/// <summary>
	/// 数据访问类:tTask
	/// </summary>
	public partial class TaskDAL
	{
        public TaskDAL()
		{}
		#region  BasicMethod

        EmployeeClient sc = new EmployeeClient();
		/// <summary>
		/// 增加一条数据
		/// </summary>
        public long Add(AdminManager.Model.TaskModel model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tTask(");
			strSql.Append("Title,Describe,Date,CompleteDate,Level,Type,Pointer,State,EmployeeID)");
			strSql.Append(" values (");
            strSql.Append("@Title,@Describe,@CompleteDate,@Level,@Type,@Pointer,@State,@EmployeeID)");
			strSql.Append(";select @@IDENTITY");


            StringSqlParam[] parameters = new StringSqlParam[9];
            parameters[0] = sc.getParams("@Title", model.Title, "NVarChar");
            parameters[1] = sc.getParams("@Describe", model.Describe, "NVarChar");
            parameters[2] = sc.getParams("@CompleteDate", model.CompleteDate, "DateTime");
            parameters[3] = sc.getParams("@Level", model.Level, "Int");
            parameters[4] = sc.getParams("@Type", model.Type, "TinyInt");
            parameters[5] = sc.getParams("@Pointer", model.Pointer, "BigInt");
            parameters[6] = sc.getParams("@State", model.State, "TinyInt");
            parameters[7] = sc.getParams("@Date", model.Date, "DateTime");
            parameters[8] = sc.getParams("@EmployeeID", model.EmployeeID, "BigInt");

            object obj = sc.Task_Add(strSql.ToString(), parameters);
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
        public bool Update(AdminManager.Model.TaskModel model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tTask set ");
			strSql.Append("Title=@Title,");
			strSql.Append("Describe=@Describe,");
			strSql.Append("CompleteDate=@CompleteDate,");
			strSql.Append("Level=@Level,");
			strSql.Append("Type=@Type,");
			strSql.Append("Pointer=@Pointer,");
			strSql.Append("State=@State,");
            strSql.Append("Date=@Date,");
            strSql.Append("EmployeeID=@EmployeeID");
			strSql.Append(" where ID=@ID");
            StringSqlParam[] parameters = new StringSqlParam[10];
            parameters[0] = sc.getParams("@Title", model.Title, "NVarChar");
            parameters[1] = sc.getParams("@Describe", model.Describe, "NVarChar");
            parameters[2] = sc.getParams("@CompleteDate", model.CompleteDate, "DateTime");
            parameters[3] = sc.getParams("@Level", model.Level, "Int");
            parameters[4] = sc.getParams("@Type", model.Type, "TinyInt");
            parameters[5] = sc.getParams("@Pointer", model.Pointer, "BigInt");
            parameters[6] = sc.getParams("@State", model.State, "TinyInt");
            parameters[7] = sc.getParams("@ID", model.ID, "BigInt");
            parameters[8] = sc.getParams("@Date", model.Date, "DateTime");
            parameters[9] = sc.getParams("@EmployeeID", model.EmployeeID, "BigInt");
            return sc.Task_Update(strSql.ToString(), parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
        public AdminManager.Model.TaskModel GetModel(long ID)
		{
			
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select  top 1 ID,Title,Describe,Date,CompleteDate,Level,Type,Pointer,State,EmployeeID from tTask ");
			strSql.Append(" where ID=@ID");
            StringSqlParam[] parameters = new StringSqlParam[1];

            parameters[0] = sc.getParams("@ID", ID, "BigInt");


            AdminManager.Model.OrderModel model = new AdminManager.Model.OrderModel();
            DataSet ds = sc.Task_GetModel(strSql.ToString(), parameters);
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
        public AdminManager.Model.TaskModel DataRowToModel(DataRow row)
		{
            AdminManager.Model.TaskModel model = new AdminManager.Model.TaskModel();
			if (row != null)
			{
				if(row["ID"]!=null && row["ID"].ToString()!="")
				{
					model.ID=long.Parse(row["ID"].ToString());
				}
                if (row["EmployeeID"] != null && row["EmployeeID"].ToString() != "")
                {
                    model.EmployeeID = long.Parse(row["EmployeeID"].ToString());
                }
				if(row["Title"]!=null)
				{
					model.Title=row["Title"].ToString();
				}
				if(row["Describe"]!=null)
				{
					model.Describe=row["Describe"].ToString();
				}
				if(row["CompleteDate"]!=null && row["CompleteDate"].ToString()!="")
				{
					model.CompleteDate=DateTime.Parse(row["CompleteDate"].ToString());
				}
                if (row["Date"] != null && row["Date"].ToString() != "")
                {
                    model.Date = DateTime.Parse(row["Date"].ToString());
                }
				if(row["Level"]!=null && row["Level"].ToString()!="")
				{
					model.Level=int.Parse(row["Level"].ToString());
				}
				if(row["Type"]!=null && row["Type"].ToString()!="")
				{
					model.Type=int.Parse(row["Type"].ToString());
				}
				if(row["Pointer"]!=null && row["Pointer"].ToString()!="")
				{
					model.Pointer=long.Parse(row["Pointer"].ToString());
				}
				if(row["State"]!=null && row["State"].ToString()!="")
				{
					model.State=int.Parse(row["State"].ToString());
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
            StringBuilder sb = new StringBuilder();
            sb.Append("select * from tTask where 1=1" + strWhere);
            return sc.Task_GetList(sb.ToString());
		}


        public DataSet GetListByEmployee(string strWhere,long id)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select * from tTask where ISNULL(employeeid,0) in ("+id+",0) " + strWhere + " order by employeeid desc ");
            return sc.Task_GetListByEmployee(sb.ToString());
        }

		/// <summary>
		/// 分页获取数据列表
		/// </summary>
        public DataSet GetListByPage(int PageSize, int PageIndex, string strWhere, string orderStr, out int totalCount)
		{
            return sc.Task_GetListByPage(PageSize, PageIndex, strWhere, orderStr, out totalCount);
		}

		#endregion  BasicMethod
	}
}

