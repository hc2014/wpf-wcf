using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using AdminManager.WcfService;
namespace AdminManager.DAL
{
	/// <summary>
	/// 数据访问类:tWithdrawal
	/// </summary>
	public partial class WithdrawalDAL
	{
		public WithdrawalDAL()
		{}
		#region  BasicMethod

		/// <summary>
		/// 更新一条数据
		/// </summary>
        public bool Update(AdminManager.Model.WithdrawalModel model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tWithdrawal set ");
			strSql.Append("UserID=@UserID,");
			strSql.Append("AssetID=@AssetID,");
			strSql.Append("Money=@Money,");
			strSql.Append("Date=@Date,");
			strSql.Append("CompleteDate=@CompleteDate,");
			strSql.Append("Name=@Name,");
			strSql.Append("BankType=@BankType,");
			strSql.Append("BankCode=@BankCode,");
			strSql.Append("State=@State");
			strSql.Append(" where ID=@ID");

            StringSqlParam[] parameters = new StringSqlParam[10];

            parameters[0] = sc.getParams("@UserID", model.UserID, "BigInt");
            parameters[1] = sc.getParams("@AssetID", model.AssetID, "BigInt");
            parameters[2] = sc.getParams("@Money", model.Money, "Money");
            parameters[3] = sc.getParams("@Date", model.Date, "DateTime");
            parameters[4] = sc.getParams("@CompleteDate", model.CompleteDate, "DateTime");
            parameters[5] = sc.getParams("@Name", model.Name, "NVarChar");
            parameters[6] = sc.getParams("@BankType", model.BankType, "NVarChar");
            parameters[7] = sc.getParams("@BankCode", model.BankCode, "NVarChar");
            parameters[8] = sc.getParams("@State", model.State, "TinyInt");
            parameters[9] = sc.getParams("@ID", model.ID, "BigInt");
            return sc.Withdrawal_Update(strSql.ToString(), parameters);
		}
        EmployeeClient sc = new EmployeeClient();


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
        public AdminManager.Model.WithdrawalModel GetModel(long ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,UserID,AssetID,Money,Date,CompleteDate,Name,BankType,BankCode,State from tWithdrawal ");
			strSql.Append(" where ID=@ID");
            StringSqlParam[] parameters = new StringSqlParam[1];

            parameters[0] = sc.getParams("@ID", ID, "BigInt");


            AdminManager.Model.OrderModel model = new AdminManager.Model.OrderModel();
            DataSet ds = sc.Withdrawal_GetModel(strSql.ToString(), parameters);
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
        public AdminManager.Model.WithdrawalModel DataRowToModel(DataRow row)
		{
            AdminManager.Model.WithdrawalModel model = new AdminManager.Model.WithdrawalModel();
			if (row != null)
			{
				if(row["ID"]!=null && row["ID"].ToString()!="")
				{
					model.ID=long.Parse(row["ID"].ToString());
				}
				if(row["UserID"]!=null && row["UserID"].ToString()!="")
				{
					model.UserID=long.Parse(row["UserID"].ToString());
				}
				if(row["AssetID"]!=null && row["AssetID"].ToString()!="")
				{
					model.AssetID=long.Parse(row["AssetID"].ToString());
				}
				if(row["Money"]!=null && row["Money"].ToString()!="")
				{
					model.Money=decimal.Parse(row["Money"].ToString());
				}
				if(row["Date"]!=null && row["Date"].ToString()!="")
				{
					model.Date=DateTime.Parse(row["Date"].ToString());
				}
				if(row["CompleteDate"]!=null && row["CompleteDate"].ToString()!="")
				{
					model.CompleteDate=DateTime.Parse(row["CompleteDate"].ToString());
				}
				if(row["Name"]!=null)
				{
					model.Name=row["Name"].ToString();
				}
				if(row["BankType"]!=null)
				{
					model.BankType=row["BankType"].ToString();
				}
				if(row["BankCode"]!=null)
				{
					model.BankCode=row["BankCode"].ToString();
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
            DataSet ds = sc.Withdrawal_GetList(strWhere);
            return ds;
		}

		/// <summary>
		/// 分页获取数据列表
		/// </summary>
        public DataSet GetListByPage(int PageSize, int PageIndex, string strWhere, string orderStr, out int totalCount)
        {
            DataSet ds = sc.Withdrawal_GetListByPage(PageSize, PageIndex, strWhere, orderStr, out totalCount);
            return ds;
        }

		#endregion  BasicMethod
	}
}

