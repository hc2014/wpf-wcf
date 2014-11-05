using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using AdminManager.WcfService;
namespace AdminManager.DAL
{
	/// <summary>
	/// 数据访问类:tUserAuthenticate
	/// </summary>
	public partial class UserAuthenticateDAL
	{
        public UserAuthenticateDAL()
		{}
		#region  BasicMethod

        EmployeeClient sc = new EmployeeClient();
		/// <summary>
		/// 更新一条数据
		/// </summary>
        public bool Update(AdminManager.Model.UserAuthenticateModel model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tUserAuthenticate set ");
			strSql.Append("UserID=@UserID,");
			strSql.Append("Name=@Name,");
			strSql.Append("IDCard=@IDCard,");
			strSql.Append("Date=@Date,");
			strSql.Append("CompleteDate=@CompleteDate,");
			strSql.Append("State=@State");
			strSql.Append(" where ID=@ID");
            StringSqlParam[] parameters = new StringSqlParam[7];

            parameters[0] = sc.getParams("@UserID", model.UserID, "BigInt");
            parameters[1] = sc.getParams("@Name", model.Name, "NVarChar");
            parameters[2] = sc.getParams("@IDCard", model.IDCard, "NVarChar");
            parameters[3] = sc.getParams("@Date", model.Date, "DateTime");
            parameters[4] = sc.getParams("@CompleteDate", model.CompleteDate, "DateTime");
            parameters[5] = sc.getParams("@State", model.State, "TinyInt");
            parameters[6] = sc.getParams("@ID", model.ID, "BigInt");
            return sc.UserAuthenticate_Update(strSql.ToString(), parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
        public bool Delete(long ID)
        {
            return sc.UserAuthenticate_Delete(ID);
        }
		/// <summary>
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string IDlist )
		{
            return sc.UserAuthenticate_DeleteList(IDlist);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
        public AdminManager.Model.UserAuthenticateModel GetModel(long ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,UserID,Name,IDCard,Date,CompleteDate,State from tUserAuthenticate ");
			strSql.Append(" where ID=@ID");
            StringSqlParam[] parameters = new StringSqlParam[1];

            parameters[0] = sc.getParams("@ID", ID, "BigInt");

            AdminManager.Model.UserAuthenticateModel model = new AdminManager.Model.UserAuthenticateModel();
            DataSet ds = sc.UserAuthenticate_GetModel(strSql.ToString(), parameters);
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
        public AdminManager.Model.UserAuthenticateModel DataRowToModel(DataRow row)
        {
            AdminManager.Model.UserAuthenticateModel model = new AdminManager.Model.UserAuthenticateModel();
            if (row != null)
            {
                if (row["ID"] != null && row["ID"].ToString() != "")
                {
                    model.ID = long.Parse(row["ID"].ToString());
                }
                if (row["UserID"] != null && row["UserID"].ToString() != "")
                {
                    model.UserID = long.Parse(row["UserID"].ToString());
                }
                if (row["Name"] != null)
                {
                    model.Name = row["Name"].ToString();
                }
                if (row["IDCard"] != null)
                {
                    model.IDCard = row["IDCard"].ToString();
                }
                if (row["Date"] != null && row["Date"].ToString() != "")
                {
                    model.Date = DateTime.Parse(row["Date"].ToString());
                }
                if (row["CompleteDate"] != null && row["CompleteDate"].ToString() != "")
                {
                    model.CompleteDate = DateTime.Parse(row["CompleteDate"].ToString());
                }
                if (row["State"] != null && row["State"].ToString() != "")
                {
                    model.State = int.Parse(row["State"].ToString());
                }
            }
            return model;
        }

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
            DataSet ds = sc.UserAuthenticate_GetList(strWhere);
            return ds;
		}


		/// <summary>
		/// 分页获取数据列表
		/// </summary>
        public DataSet GetListByPage(int PageSize, int PageIndex, string strWhere, string orderStr, out int totalCount)
        {
            DataSet ds = sc.UserAuthenticate_GetListByPage(PageSize, PageIndex, strWhere, orderStr, out totalCount);
            return ds;
        }

		#endregion  BasicMethod
	}
}

