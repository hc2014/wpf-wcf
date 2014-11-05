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
    class EmployeeDAL
    {
        public EmployeeDAL()
        { 
        }

        EmployeeClient sc = new EmployeeClient();
        public int Login(string Account, string pwd)
        {
            
            EmployeeClient sc = new EmployeeClient();
            int i = sc.Login(Account,pwd);
           return i;
        }

        public DataSet GetUserAuthorityList(int PageSize, int PageIndex, string strWhere, string orderStr, out int totalCount)
        {
            return sc.Employee_GetUserAuthorityList(PageSize, PageIndex, strWhere, orderStr, out totalCount);
        }
        public DataSet GetUserInfo(string Account)
        {

            EmployeeClient sc = new EmployeeClient();
            DataSet ds = sc.Employee_GetUserInfo(Account);
            return ds;
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(long ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tEmployee");
            strSql.Append(" where ID=@ID");

            StringSqlParam strpam = new StringSqlParam();
            strpam.ParamName = "@ID";
            strpam.ParamValue = ID.ToString();
            strpam.DateType = "NVarChar";

            StringSqlParam[] pams = new StringSqlParam[1] { strpam };
            return sc.Employee_Exists(strSql.ToString(), pams);
        }

        public bool ExistsByUser(string Account)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(0) from tEmployee where UserID=(select ID from tUser where Account=@account)");

            StringSqlParam strpam = new StringSqlParam();
            strpam.ParamName = "@account";
            strpam.ParamValue = Account;
            strpam.DateType = "NVarChar";

            StringSqlParam[] pams = new StringSqlParam[1] { strpam };
            
            return sc.Employee_Exists(strSql.ToString(), pams);
        }



        public long Add(AdminManager.Model.EmployeeModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tEmployee(");
            strSql.Append("UserID,EmployeeGroupID,Name,IDCard,Email,QQ,Telephone,Mobile,HomeAddress,Address,Remark,Birthday,BankType,BankCode,Salary,Authorization)");
            strSql.Append(" values (");
            strSql.Append("@UserID,@EmployeeGroupID,@Name,@IDCard,@Email,@QQ,@Telephone,@Mobile,@HomeAddress,@Address,@Remark,@Birthday,@BankType,@BankCode,@Salary,@[Authorization])");
            strSql.Append(";select @@IDENTITY");

            StringSqlParam[] parameters = new StringSqlParam[16];

            parameters[0] = sc.getParams("@UserID", model.UserID, "BigInt");
            parameters[1] = sc.getParams("@EmployeeGroupID", model.EmployeeGroupID, "BigInt");
            parameters[2] = sc.getParams("@Name", model.Name, "NVarChar");
            parameters[3] = sc.getParams("@IDCard", model.IDCard, "NVarChar");
            parameters[4] = sc.getParams("@Email", model.Email, "NVarChar");
            parameters[5] = sc.getParams("@QQ", model.QQ, "NVarChar");
            parameters[6] = sc.getParams("@Telephone", model.Telephone, "NVarChar");
            parameters[7] = sc.getParams("@Mobile", model.Mobile, "NVarChar");
            parameters[8] = sc.getParams("@HomeAddress", model.HomeAddress, "NVarChar");
            parameters[9] = sc.getParams("@Address", model.Address, "NVarChar");
            parameters[10] = sc.getParams("@Remark", model.Remark, "NVarChar");
            parameters[11] = sc.getParams("@Birthday", model.Birthday, "DateTime");
            parameters[12] = sc.getParams("@BankType", model.BankType, "NVarChar");
            parameters[13] = sc.getParams("@BankCode", model.BankCode, "NVarChar");
            parameters[14] = sc.getParams("@Salary", model.Salary, "Money");
            parameters[15] = sc.getParams("@Authorization", model.Authorization, "NVarChar");

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



        public bool Update(AdminManager.Model.EmployeeModel model)
        {
            StringBuilder strSql = new StringBuilder();

            strSql.Append("update tEmployee set ");
            strSql.Append("UserID=@UserID,");
            strSql.Append("EmployeeGroupID=@EmployeeGroupID,");
            strSql.Append("Name=@Name,");
            strSql.Append("IDCard=@IDCard,");
            strSql.Append("Email=@Email,");
            strSql.Append("QQ=@QQ,");
            strSql.Append("Telephone=@Telephone,");
            strSql.Append("Mobile=@Mobile,");
            strSql.Append("HomeAddress=@HomeAddress,");
            strSql.Append("Address=@Address,");
            strSql.Append("Remark=@Remark,");
            strSql.Append("Birthday=@Birthday,");
            strSql.Append("BankType=@BankType,");
            strSql.Append("BankCode=@BankCode,");
            strSql.Append("Salary=@Salary,");
            strSql.Append("[Authorization]=@Authorization");
            strSql.Append(" where ID=@ID");


            StringSqlParam[] parameters = new StringSqlParam[17];

            parameters[0] = sc.getParams("@UserID", model.UserID, "BigInt");
            parameters[1] = sc.getParams("@EmployeeGroupID", model.EmployeeGroupID, "BigInt");
            parameters[2] = sc.getParams("@Name", model.Name, "NVarChar");
            parameters[3] = sc.getParams("@IDCard", model.IDCard, "NVarChar");
            parameters[4] = sc.getParams("@Email", model.Email, "NVarChar");
            parameters[5] = sc.getParams("@QQ", model.QQ, "NVarChar");
            parameters[6] = sc.getParams("@Telephone", model.Telephone, "NVarChar");
            parameters[7] = sc.getParams("@Mobile", model.Mobile, "NVarChar");
            parameters[8] = sc.getParams("@HomeAddress", model.HomeAddress, "NVarChar");
            parameters[9] = sc.getParams("@Address", model.Address, "NVarChar");
            parameters[10] = sc.getParams("@Remark", model.Remark, "NVarChar");
            parameters[11] = sc.getParams("@Birthday", model.Birthday, "DateTime");
            parameters[12] = sc.getParams("@BankType", model.BankType, "NVarChar");
            parameters[13] = sc.getParams("@BankCode", model.BankCode, "NVarChar");
            parameters[14] = sc.getParams("@Salary", model.Salary, "Money");
            parameters[15] = sc.getParams("@Authorization", model.Authorization, "NVarChar");
            parameters[16] = sc.getParams("@ID", model.ID, "BigInt");


            return sc.Employee_Update(strSql.ToString(), parameters);

        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public AdminManager.Model.EmployeeModel GetModel(long ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,UserID,EmployeeGroupID,Name,IDCard,Email,QQ,Telephone,Mobile,HomeAddress,Address,Remark,Birthday,BankType,BankCode,Salary,[Authorization] from tEmployee ");
            strSql.Append(" where ID=@ID");


            StringSqlParam[] parameters = new StringSqlParam[1];

            parameters[0] = sc.getParams("@ID", ID, "BigInt");


            AdminManager.Model.EmployeeModel model = new AdminManager.Model.EmployeeModel();
            DataSet ds =sc.Employee_GetModel(strSql.ToString(), parameters);
            if (ds.Tables.Count > 0)
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
        public AdminManager.Model.EmployeeModel DataRowToModel(DataRow row)
        {
            AdminManager.Model.EmployeeModel model = new AdminManager.Model.EmployeeModel();
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
                if (row["EmployeeGroupID"] != null && row["EmployeeGroupID"].ToString() != "")
                {
                    model.EmployeeGroupID = long.Parse(row["EmployeeGroupID"].ToString());
                }
                if (row["Name"] != null)
                {
                    model.Name = row["Name"].ToString();
                }
                if (row["IDCard"] != null)
                {
                    model.IDCard = row["IDCard"].ToString();
                }
                if (row["Email"] != null)
                {
                    model.Email = row["Email"].ToString();
                }
                if (row["QQ"] != null)
                {
                    model.QQ = row["QQ"].ToString();
                }
                if (row["Telephone"] != null)
                {
                    model.Telephone = row["Telephone"].ToString();
                }
                if (row["Mobile"] != null)
                {
                    model.Mobile = row["Mobile"].ToString();
                }
                if (row["HomeAddress"] != null)
                {
                    model.HomeAddress = row["HomeAddress"].ToString();
                }
                if (row["Address"] != null)
                {
                    model.Address = row["Address"].ToString();
                }
                if (row["Remark"] != null)
                {
                    model.Remark = row["Remark"].ToString();
                }
                if (row["Birthday"] != null && row["Birthday"].ToString() != "")
                {
                    model.Birthday = DateTime.Parse(row["Birthday"].ToString());
                }
                if (row["BankType"] != null)
                {
                    model.BankType = row["BankType"].ToString();
                }
                if (row["BankCode"] != null)
                {
                    model.BankCode = row["BankCode"].ToString();
                }
                if (row["Salary"] != null && row["Salary"].ToString() != "")
                {
                    model.Salary = decimal.Parse(row["Salary"].ToString());
                }
                if (row["Authorization"] != null)
                {
                    model.Authorization = row["Authorization"].ToString();
                }
            }
            return model;
        }

    }
}
