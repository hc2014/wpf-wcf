using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using AdminManager.WcfService;
namespace AdminManager.DAL
{
	/// <summary>
	/// 数据访问类:tSpreadLevelInfo
	/// </summary>
	public partial class SpreadLevelInfoDAL
	{
        public SpreadLevelInfoDAL()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>

        public long Add(AdminManager.Model.SpreadLevelInfoModel model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tSpreadLevelInfo(");
            strSql.Append("SpreadItemID,Level,Experience,Rebate,Enable,Describe)");
			strSql.Append(" values (");
            strSql.Append("@SpreadItemID,@Level,@Experience,@Rebate,@Describe,@Enable)");
			strSql.Append(";select @@IDENTITY");
            StringSqlParam[] parameters = new StringSqlParam[6];

            parameters[0] = sc.getParams("@SpreadItemID", model.SpreadItemID, "BigInt");
            parameters[1] = sc.getParams("@Level", model.Level, "Int");
            parameters[2] = sc.getParams("@Experience", model.Experience, "Int");
            parameters[3] = sc.getParams("@Rebate", model.Rebate, "Money");
            parameters[4] = sc.getParams("@Enable", model.Enable, "Bit");
            parameters[5] = sc.getParams("@Describe", model.Describe, "NVarChar");

            object obj = sc.SpreadItem_Add(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt64(obj);
            }
		}
        EmployeeClient sc = new EmployeeClient();
        public bool Update(AdminManager.Model.SpreadLevelInfoModel model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tSpreadLevelInfo set ");
			strSql.Append("SpreadItemID=@SpreadItemID,");
			strSql.Append("Level=@Level,");
			strSql.Append("Experience=@Experience,");
			strSql.Append("Rebate=@Rebate,");
            strSql.Append("Enable=@Enable,");
            strSql.Append("Describe=@Describe");
            strSql.Append(" where ID=@ID");
            StringSqlParam[] parameters = new StringSqlParam[7];
            parameters[0] = sc.getParams("@SpreadItemID", model.SpreadItemID, "BigInt");
            parameters[1] = sc.getParams("@Level", model.Level, "Int");
            parameters[2] = sc.getParams("@Experience", model.Experience, "Int");
            parameters[3] = sc.getParams("@Rebate", model.Rebate, "Money");
            parameters[4] = sc.getParams("@ID", model.ID, "BigInt");
            parameters[5] = sc.getParams("@Enable", model.Enable, "BigInt");
            parameters[6] = sc.getParams("@Describe", model.Describe, "NVarChar");
            return sc.Asset_Update(strSql.ToString(), parameters);

		}

        public AdminManager.Model.SpreadLevelInfoModel GetModel(long ID)
		{
			
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select  top 1 ID,SpreadItemID,Level,Experience,Rebate,Enable,Describe from tSpreadLevelInfo ");
			strSql.Append(" where ID=@ID");
            StringSqlParam[] parameters = new StringSqlParam[1];

            parameters[0] = sc.getParams("@ID", ID, "BigInt");


            AdminManager.Model.OrderModel model = new AdminManager.Model.OrderModel();
            DataSet ds = sc.Asset_GetModel(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
		}


        public AdminManager.Model.SpreadLevelInfoModel DataRowToModel(DataRow row)
		{
            AdminManager.Model.SpreadLevelInfoModel model = new AdminManager.Model.SpreadLevelInfoModel();
			if (row != null)
			{
				if(row["ID"]!=null && row["ID"].ToString()!="")
				{
					model.ID=long.Parse(row["ID"].ToString());
				}
                if (row["Enable"] != null && row["Enable"].ToString() != "")
				{
                    model.Enable = bool.Parse(row["Enable"].ToString());
				}
                if (row["SpreadItemID"] != null && row["SpreadItemID"].ToString() != "")
                {
                    model.SpreadItemID = long.Parse(row["SpreadItemID"].ToString());
                }
                if (row["Describe"] != null && row["Describe"].ToString() != "")
                {
                    model.Describe = row["Describe"].ToString();
                }
				if(row["Level"]!=null && row["Level"].ToString()!="")
				{
					model.Level=int.Parse(row["Level"].ToString());
				}
				if(row["Experience"]!=null && row["Experience"].ToString()!="")
				{
					model.Experience=int.Parse(row["Experience"].ToString());
				}
				if(row["Rebate"]!=null && row["Rebate"].ToString()!="")
				{
					model.Rebate=decimal.Parse(row["Rebate"].ToString());
				}
			}
			return model;
		}

        public DataSet GetList(string where)
        {
            return sc.SpreadLevelInfo_GetList(where);
        }

        public DataSet GetListByPage(int PageSize, int PageIndex, string strWhere, string orderStr, out int totalCount)
        {
            return sc.SpreadLevelInfo_GetListByPage(PageSize, PageIndex, strWhere, orderStr, out totalCount);
        }
		#endregion  BasicMethod
	}
}

