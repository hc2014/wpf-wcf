using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using AdminManager.WcfService;
namespace AdminManager.DAL
{
	/// <summary>
	/// 数据访问类:tLogistic
	/// </summary>
	public partial class LogisticDAL
	{
        public LogisticDAL()
		{}
		#region  BasicMethod


        EmployeeClient sc = new EmployeeClient();

        public long Add(AdminManager.Model.LogisticModel model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tLogistic(");
			strSql.Append("UserID,OrderID,Type,Code,State,Direction,Name,Province,City,County,Address,Telephone,Mobile)");
			strSql.Append(" values (");
			strSql.Append("@UserID,@OrderID,@Type,@Code,@State,@Direction,@Name,@Province,@City,@County,@Address,@Telephone,@Mobile)");
			strSql.Append(";select @@IDENTITY");
            StringSqlParam[] parameters = new StringSqlParam[13];

            parameters[0] = sc.getParams("@UserID", model.UserID, "BigInt");
            parameters[1] = sc.getParams("@OrderID", model.OrderID, "BigInt");
            parameters[2] = sc.getParams("@Type", model.Type, "TinyInt");
            parameters[3] = sc.getParams("@Code", model.Code, "NVarChar");
            parameters[4] = sc.getParams("@State", model.State, "TinyInt");
            parameters[5] = sc.getParams("@Direction", model.Direction, "TinyInt");
            parameters[6] = sc.getParams("@Name", model.Name, "NVarChar");
            parameters[7] = sc.getParams("@Province", model.Province, "NVarChar");
            parameters[8] = sc.getParams("@City", model.City, "NVarChar");
            parameters[9] = sc.getParams("@County", model.County, "NVarChar");
            parameters[10] = sc.getParams("@Address", model.Address, "NVarChar");
            parameters[11] = sc.getParams("@Telephone", model.Telephone, "NVarChar");
            parameters[12] = sc.getParams("@Mobile", model.Mobile, "NVarChar");

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

        public bool Update(AdminManager.Model.LogisticModel model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tLogistic set ");
			strSql.Append("UserID=@UserID,");
			strSql.Append("OrderID=@OrderID,");
			strSql.Append("Type=@Type,");
			strSql.Append("Code=@Code,");
			strSql.Append("State=@State,");
			strSql.Append("Direction=@Direction,");
			strSql.Append("Name=@Name,");
			strSql.Append("Province=@Province,");
			strSql.Append("City=@City,");
			strSql.Append("County=@County,");
			strSql.Append("Address=@Address,");
			strSql.Append("Telephone=@Telephone,");
			strSql.Append("Mobile=@Mobile");
			strSql.Append(" where ID=@ID");
            StringSqlParam[] parameters = new StringSqlParam[14];

            parameters[0] = sc.getParams("@UserID", model.UserID, "BigInt");
            parameters[1] = sc.getParams("@OrderID", model.OrderID, "BigInt");
            parameters[2] = sc.getParams("@Type", model.Type, "TinyInt");
            parameters[3] = sc.getParams("@Code", model.Code, "NVarChar");
            parameters[4] = sc.getParams("@State", model.State, "TinyInt");
            parameters[5] = sc.getParams("@Direction", model.Direction, "TinyInt");
            parameters[6] = sc.getParams("@Name", model.Name, "NVarChar");
            parameters[7] = sc.getParams("@Province", model.Province, "NVarChar");
            parameters[8] = sc.getParams("@City", model.City, "NVarChar");
            parameters[9] = sc.getParams("@County", model.County, "NVarChar");
            parameters[10] = sc.getParams("@Address", model.Address, "NVarChar");
            parameters[11] = sc.getParams("@Telephone", model.Telephone, "NVarChar");
            parameters[12] = sc.getParams("@Mobile", model.Mobile, "NVarChar");
            parameters[13] = sc.getParams("@ID", model.ID, "BigInt");
            return sc.Logistic_Update(strSql.ToString(), parameters);
		}

		public bool Delete(long ID)
		{
            return sc.Logistic_Delete(ID);
		}

		public bool DeleteList(string IDlist )
		{
            return sc.Logistic_DeleteList(IDlist);
		}

        public AdminManager.Model.LogisticModel GetModel(long ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,UserID,OrderID,Type,Code,State,Direction,Name,Province,City,County,Address,Telephone,Mobile from tLogistic ");
			strSql.Append(" where ID=@ID");
            StringSqlParam[] parameters = new StringSqlParam[1];

            parameters[0] = sc.getParams("@ID", ID, "BigInt");


            AdminManager.Model.OrderModel model = new AdminManager.Model.OrderModel();
            DataSet ds = sc.Logistic_GetModel(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
		}

        public AdminManager.Model.LogisticModel DataRowToModel(DataRow row)
		{
            AdminManager.Model.LogisticModel model = new AdminManager.Model.LogisticModel();
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
				if(row["OrderID"]!=null && row["OrderID"].ToString()!="")
				{
					model.OrderID=long.Parse(row["OrderID"].ToString());
				}
				if(row["Type"]!=null && row["Type"].ToString()!="")
				{
					model.Type=int.Parse(row["Type"].ToString());
				}
				if(row["Code"]!=null)
				{
					model.Code=row["Code"].ToString();
				}
				if(row["State"]!=null && row["State"].ToString()!="")
				{
					model.State=int.Parse(row["State"].ToString());
				}
				if(row["Direction"]!=null && row["Direction"].ToString()!="")
				{
					model.Direction=int.Parse(row["Direction"].ToString());
				}
				if(row["Name"]!=null)
				{
					model.Name=row["Name"].ToString();
				}
				if(row["Province"]!=null)
				{
					model.Province=row["Province"].ToString();
				}
				if(row["City"]!=null)
				{
					model.City=row["City"].ToString();
				}
				if(row["County"]!=null)
				{
					model.County=row["County"].ToString();
				}
				if(row["Address"]!=null)
				{
					model.Address=row["Address"].ToString();
				}
				if(row["Telephone"]!=null)
				{
					model.Telephone=row["Telephone"].ToString();
				}
				if(row["Mobile"]!=null)
				{
					model.Mobile=row["Mobile"].ToString();
				}
			}
			return model;
		}

		public DataSet GetList(string strWhere)
		{
            DataSet ds = sc.Logistic_GetList(strWhere);
            return ds;
		}

        public DataSet GetProvanceList(string strWhere)
        {
            DataSet ds = sc.Logistic_GetProvinceList(strWhere);
            return ds;
        }

        public DataSet GetCityList(string strWhere)
        {
            DataSet ds = sc.Logistic_GetCityList(strWhere);
            return ds;
        }

        public DataSet GetBoroughList(string strWhere)
        {
            DataSet ds = sc.Logistic_GetBoroughList(strWhere);
            return ds;
        }

        public DataSet GetListByPage(int PageSize, int PageIndex, string strWhere, string orderStr, out int totalCount)
		{
            DataSet ds = sc.Logistic_GetListByPage(PageSize, PageIndex, strWhere, orderStr, out totalCount);
            return ds;
		}

		#endregion  BasicMethod
	}
}

