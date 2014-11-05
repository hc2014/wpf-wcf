using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdminManager.WcfService;
using AdminManager.Component;
using System.Data;
namespace AdminManager.DAL
{
   public class SystemParameterDAL
    {
       public SystemParameterDAL()
       { }

       public DataSet GetList()
       {
           DataSet ds = sc.SystemParameter_GetList();
           return ds;
       }

       public DataSet GetList(string where)
       {
           EmployeeClient sc = new EmployeeClient();
           DataSet ds = sc.SystemParameter_GetListByWhere(where);
           return ds;
       }
       public DataSet GetSmallList(string id)
       {
          
           DataSet ds = sc.SystemParameter_GetSmallList(id);
           return ds;
       }

       EmployeeClient sc = new EmployeeClient();

       public bool Update(AdminManager.Model.SystemParameterModel model)
       {

           StringBuilder strSql = new StringBuilder();
           strSql.Append("update SystemParameter set ");
           strSql.Append("[type]=@type,");
           strSql.Append("name=@name,");
           strSql.Append("[order]=@order,");
           strSql.Append("[state]=@state,");
           strSql.Append("parentid=@parentid");
           strSql.Append(" where ID=@ID");

           StringSqlParam[] parameters = new StringSqlParam[6];

           parameters[0] = sc.getParams("@type", model.type, "Int");
           parameters[1] = sc.getParams("@name", model.name, "NVarChar");
           parameters[2] = sc.getParams("@order", model.order, "NVarChar");
           parameters[3] = sc.getParams("@state", model.state, "Int");
           parameters[4] = sc.getParams("@parentid", model.parentid, "NVarChar");
           parameters[5] = sc.getParams("@ID", model.id, "NVarChar");

           return sc.SystemParameter_Update(strSql.ToString(), parameters);

       }
       public AdminManager.Model.SystemParameterModel GetModel(string ID)
       {
           StringBuilder strSql = new StringBuilder();
           strSql.Append("select  top 1 * from SystemParameter ");
           strSql.Append(" where ID=@ID");


           StringSqlParam[] parameters = new StringSqlParam[1];

           parameters[0] = sc.getParams("@ID", ID, "NVarChar");


           AdminManager.Model.OrderModel model = new AdminManager.Model.OrderModel();
           DataSet ds = sc.SystemParameter_GetModel(strSql.ToString(), parameters);
           if (ds.Tables[0].Rows.Count > 0)
           {
               return DataRowToModel(ds.Tables[0].Rows[0]);
           }
           else
           {
               return null;
           }
       }
       public AdminManager.Model.SystemParameterModel DataRowToModel(DataRow row)
       {
           AdminManager.Model.SystemParameterModel model = new AdminManager.Model.SystemParameterModel();
           if (row != null)
           {
               if (row["id"] != null)
               {
                   model.id = row["id"].ToString();
               }
               if (row["type"] != null && row["type"].ToString() != "")
               {
                   model.type = int.Parse(row["type"].ToString());
               }
               if (row["name"] != null)
               {
                   model.name = row["name"].ToString();
               }
               if (row["order"] != null)
               {
                   model.order = row["order"].ToString();
               }
               if (row["state"] != null && row["state"].ToString() != "")
               {
                   model.state = int.Parse(row["state"].ToString());
               }
               if (row["parentid"] != null)
               {
                   model.parentid = row["parentid"].ToString();
               }
           }
           return model;
       }
    }
}
