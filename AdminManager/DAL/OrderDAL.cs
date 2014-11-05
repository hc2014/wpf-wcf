using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdminManager.WcfService;
using AdminManager.Component;
using System.Data;
using System.Data.SqlClient;
namespace AdminManager.DAL
{
    class OrderDAL
    {
        public OrderDAL()
        { 
        }

        EmployeeClient sc = new EmployeeClient();

        public DataSet GetOrderInfo(int PageSize, int PageIndex, string strWhere, string orderStr, out int totalCount)
        {

            DataSet ds = sc.Order_GetOrderInfo(PageSize, PageIndex, strWhere, orderStr, out totalCount);
            return ds;
        }



        public bool Delete(long ID)
        {
            return sc.Order_Delete(ID);
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(long ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tOrder");
            strSql.Append(" where ID=@ID");

            StringSqlParam strpam = new StringSqlParam();
            strpam.ParamName = "@ID";
            strpam.ParamValue = ID.ToString();
            strpam.DateType = "NVarChar";

            StringSqlParam[] pams = new StringSqlParam[1] { strpam };
            return sc.Employee_Exists(strSql.ToString(), pams);
        }


        public long Add(AdminManager.Model.OrderModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tOrder(");
            strSql.Append("UserID,Number,ProductLogID,ProductName,Quantity,IP,Describe,Unit,Price,Date,CompleteDate,Page,Source,Remark,State,PayMoney,PayGold,PayBank,EmployeeID,EmployeeReward)");
            strSql.Append(" values (");
            strSql.Append("@UserID,@Number,@ProductLogID,@ProductName,@Quantity,@IP,@Describe,@Unit,@Price,@Date,@CompleteDate,@Page,@Source,@Remark,@State,@PayMoney,@PayGold,@PayBank,@EmployeeID,@EmployeeReward)");
            strSql.Append(";select @@IDENTITY");

            StringSqlParam[] parameters = new StringSqlParam[20];

            parameters[0] = sc.getParams("@UserID", model.UserID, "BigInt");
            parameters[1] = sc.getParams("@ProductLogID", model.ProductLogID, "BigInt");
            parameters[2] = sc.getParams("@ProductName", model.ProductName, "NVarChar");
            parameters[3] = sc.getParams("@Quantity", model.Quantity, "Int");
            parameters[4] = sc.getParams("@IP", model.IP, "VarChar");
            parameters[5] = sc.getParams("@Describe", model.Describe, "NVarChar");
            parameters[6] = sc.getParams("@Unit", model.Unit, "NVarChar");
            parameters[7] = sc.getParams("@Price", model.Price, "Money");
            parameters[8] = sc.getParams("@Date", model.Date, "DateTime");
            parameters[9] = sc.getParams("@CompleteDate", model.CompleteDate, "DateTime");
            parameters[10] = sc.getParams("@Page", model.Page, "NVarChar");
            parameters[11] = sc.getParams("@Source", model.Source, "NVarChar");
            parameters[12] = sc.getParams("@Remark", model.Remark, "NVarChar");
            parameters[13] = sc.getParams("@State", model.State, "TinyInt");
            parameters[14] = sc.getParams("@EmployeeID", model.EmployeeID, "BigInt");
            parameters[15] = sc.getParams("@EmployeeReward", model.EmployeeReward, "Money");
            parameters[16] = sc.getParams("@Number", model.Number, "BigInt");
            parameters[17] = sc.getParams("@PayBank", model.PayBank, "Money");
            parameters[18] = sc.getParams("@PayGold", model.PayGold, "Money");
            parameters[19] = sc.getParams("@PayMoney", model.PayMoney, "Money");

            object obj = sc.Employee_Add(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt64(obj);
            }
        }

        public DataSet GetList(string strWhere)
        {
            DataSet ds = sc.Order_GetList(strWhere);
            return ds;
        }


        public DataSet GetListInfo(string strWhere)
        {
            DataSet ds = sc.Order_GetListInfo(strWhere);
            return ds;
        }

        public bool Update(AdminManager.Model.OrderModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tOrder set ");
            strSql.Append("UserID=@UserID,");
            strSql.Append("Number=@Number,");
            strSql.Append("ProductLogID=@ProductLogID,");
            strSql.Append("ProductName=@ProductName,");
            strSql.Append("Quantity=@Quantity,");
            strSql.Append("IP=@IP,");
            strSql.Append("Describe=@Describe,");
            strSql.Append("Unit=@Unit,");
            strSql.Append("Price=@Price,");
            strSql.Append("Date=@Date,");
            strSql.Append("CompleteDate=@CompleteDate,");
            strSql.Append("Page=@Page,");
            strSql.Append("Source=@Source,");
            strSql.Append("Remark=@Remark,");
            strSql.Append("State=@State,");
            strSql.Append("EmployeeID=@EmployeeID,");
            strSql.Append("EmployeeReward=@EmployeeReward,");
            strSql.Append("PayMoney=@PayMoney,");
            strSql.Append("PayGold=@PayGold,");
            strSql.Append("PayBank=@PayBank");
            strSql.Append(" where ID=@ID");


            StringSqlParam[] parameters = new StringSqlParam[21];

            parameters[0] = sc.getParams("@UserID", model.UserID, "BigInt");
            parameters[1] = sc.getParams("@ProductLogID", model.ProductLogID, "BigInt");
            parameters[2] = sc.getParams("@ProductName", model.ProductName, "NVarChar");
            parameters[3] = sc.getParams("@Quantity", model.Quantity, "Int");
            parameters[4] = sc.getParams("@IP", model.IP, "VarChar");
            parameters[5] = sc.getParams("@Describe", model.Describe, "NVarChar");
            parameters[6] = sc.getParams("@Unit", model.Unit, "NVarChar");
            parameters[7] = sc.getParams("@Price", model.Price, "Money");
            parameters[8] = sc.getParams("@Date", model.Date, "DateTime");
            parameters[9] = sc.getParams("@CompleteDate", model.CompleteDate, "DateTime");
            parameters[10] = sc.getParams("@Page", model.Page, "NVarChar");
            parameters[11] = sc.getParams("@Source", model.Source, "NVarChar");
            parameters[12] = sc.getParams("@Remark", model.Remark, "NVarChar");
            parameters[13] = sc.getParams("@State", model.State, "TinyInt");
            parameters[14] = sc.getParams("@EmployeeID", model.EmployeeID, "BigInt");
            parameters[15] = sc.getParams("@EmployeeReward", model.EmployeeReward, "Money");
            parameters[16] = sc.getParams("@ID", model.ID, "BigInt");
            parameters[17] = sc.getParams("@Number", model.Number, "BigInt");
            parameters[18] = sc.getParams("@PayGold", model.PayGold, "Money");
            parameters[19] = sc.getParams("@PayMoney", model.PayMoney, "Money");
            parameters[20] = sc.getParams("@PayBank", model.PayBank, "Money");

            return sc.Order_Update(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public AdminManager.Model.OrderModel GetModel(long ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 * from torder ");
            strSql.Append(" where ID=@ID");


            StringSqlParam[] parameters = new StringSqlParam[1];

            parameters[0] = sc.getParams("@ID", ID, "BigInt");


            AdminManager.Model.OrderModel model = new AdminManager.Model.OrderModel();
            DataSet ds =sc.Employee_GetModel(strSql.ToString(), parameters);
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
        public AdminManager.Model.OrderModel DataRowToModel(DataRow row)
        {
            AdminManager.Model.OrderModel model = new AdminManager.Model.OrderModel();
            if (row != null)
            {
                if (row["ID"] != null && row["ID"].ToString() != "")
                {
                    model.ID = long.Parse(row["ID"].ToString());
                }
                if (row["Number"] != null && row["Number"].ToString() != "")
                {
                    model.Number = long.Parse(row["Number"].ToString());
                }
                if (row["UserID"] != null && row["UserID"].ToString() != "")
                {
                    model.UserID = long.Parse(row["UserID"].ToString());
                }
                if (row["ProductLogID"] != null && row["ProductLogID"].ToString() != "")
                {
                    model.ProductLogID = long.Parse(row["ProductLogID"].ToString());
                }
                if (row["ProductName"] != null)
                {
                    model.ProductName = row["ProductName"].ToString();
                }
                if (row["Quantity"] != null && row["Quantity"].ToString() != "")
                {
                    model.Quantity = int.Parse(row["Quantity"].ToString());
                }
                if (row["IP"] != null)
                {
                    model.IP = row["IP"].ToString();
                }
                if (row["Describe"] != null)
                {
                    model.Describe = row["Describe"].ToString();
                }
                if (row["Unit"] != null)
                {
                    model.Unit = row["Unit"].ToString();
                }
                if (row["Price"] != null && row["Price"].ToString() != "")
                {
                    model.Price = decimal.Parse(row["Price"].ToString());
                }
                
                if (row["Date"] != null && row["Date"].ToString() != "")
                {
                    model.Date = DateTime.Parse(row["Date"].ToString());
                }
                if (row["CompleteDate"] != null && row["CompleteDate"].ToString() != "")
                {
                    model.CompleteDate = DateTime.Parse(row["CompleteDate"].ToString());
                }
                if (row["Page"] != null)
                {
                    model.Page = row["Page"].ToString();
                }
                if (row["Source"] != null)
                {
                    model.Source = row["Source"].ToString();
                }
                if (row["Remark"] != null)
                {
                    model.Remark = row["Remark"].ToString();
                }
                if (row["State"] != null && row["State"].ToString() != "")
                {
                    model.State = int.Parse(row["State"].ToString());
                }
                if (row["PayMoney"] != null && row["PayMoney"].ToString() != "")
                {
                    model.PayMoney = int.Parse(row["PayMoney"].ToString());
                }
                if (row["PayGold"] != null && row["PayGold"].ToString() != "")
                {
                    model.PayGold = int.Parse(row["PayGold"].ToString());
                }
                if (row["PayBank"] != null && row["PayBank"].ToString() != "")
                {
                    model.PayBank = int.Parse(row["PayBank"].ToString());
                }
                if (row["EmployeeID"] != null && row["EmployeeID"].ToString() != "")
                {
                    model.EmployeeID = long.Parse(row["EmployeeID"].ToString());
                }
                if (row["EmployeeReward"] != null && row["EmployeeReward"].ToString() != "")
                {
                    model.EmployeeReward = decimal.Parse(row["EmployeeReward"].ToString());
                }
            }
            return model;
        }

    }
}
