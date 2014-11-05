using Microsoft;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerServer
{
    public  class Employee : IEmployee
    {
        public Employee()
        { }
        static readonly string constr = ConfigurationManager.ConnectionStrings["SQLConnString"].ConnectionString;

        #region Employee
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="Account"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public int Login(string Account, string pwd)
        {
            string sqlstr = "select count(0) from tUser where tUser.Account=@sid and tUser.[Password]=@pwd";
            int i = (int)SqlHelper.ExecuteScalar(constr, CommandType.Text, sqlstr, new SqlParameter("@sid", Account), new SqlParameter("@pwd", Helper.Password(pwd)));
            return i;
        }


        /// <summary>
        /// 获取员工表信息
        /// </summary>
        /// <returns></returns>
        public DataSet Employee_GetList(int PageSize, int PageIndex, string strWhere, string orderStr, out int totalCount)
        {
            StringBuilder sbSelect = new StringBuilder();
            sbSelect.Append(" * ");

            StringBuilder sbFrom = new StringBuilder();
            sbFrom.Append(" tEmployee ");
            if (strWhere.Trim().Length > 0)
            {
                sbFrom.Append(strWhere);
            }

            //生成分页SQL语句
            string strSqlPage = Helper.GetPagedSQL(PageSize, sbSelect.ToString(), sbFrom.ToString(), orderStr, PageIndex);
            StringBuilder strSqlCount = new StringBuilder();
            strSqlCount.Append("select count(0) from tEmployee ");
            if (strWhere.Trim().Length > 0)
            {
                strSqlCount.Append(strWhere);
            }

            //获取总记录数
            totalCount = Convert.ToInt32(GetSingle(strSqlCount.ToString()));
            //获取分页数据
            return Query(strSqlPage);
        }
        public DataSet Employee_GetUserAuthorityList(int PageSize, int PageIndex, string strWhere, string orderStr, out int totalCount)
        {
            StringBuilder sbSelect = new StringBuilder();
            sbSelect.Append(" tEmployee.Name,tUser.Type ");

            StringBuilder sbFrom = new StringBuilder();
            sbFrom.Append(" tUser,tEmployee where tEmployee.UserID=tUser.ID ");
            if (strWhere.Trim().Length > 0)
            {
                sbFrom.Append(strWhere);
            }

            //生成分页SQL语句
            string strSqlPage = Helper.GetPagedSQL(PageSize, sbSelect.ToString(), sbFrom.ToString(), orderStr, PageIndex);
            StringBuilder strSqlCount = new StringBuilder();
            strSqlCount.Append("select count(0) from tUser,tEmployee where tEmployee.UserID=tUser.ID ");
            if (strWhere.Trim().Length > 0)
            {
                strSqlCount.Append(strWhere);
            }

            //获取总记录数
            totalCount = Convert.ToInt32(GetSingle(strSqlCount.ToString()));
            //获取分页数据
            return Query(strSqlPage);
        }

        public DataSet Employee_GetUserInfo(string account)
        {
            string sqlstr = "select * from tEmployee where UserID=(select ID from tUser where Account=@account)";
            DataSet ds = SqlHelper.ExecuteDataset(constr, CommandType.Text, sqlstr, new SqlParameter("@account", account));
            if (ds != null)
            {
                return ds;
            }
            else
            {
                return null;
            }
        }


        public long Employee_Add(string sql, params StringSqlParam[] cmdParms)
        {
            SqlParameter[] parameters =new SqlParameter[cmdParms.Length];

            for (int i = 0; i < cmdParms.Length; i++)
            { 
                SqlDbType d = (SqlDbType)Enum.Parse(typeof(SqlDbType), cmdParms[i].DateType);
                SqlParameter parmer = new SqlParameter(cmdParms[i].ParamName,d);
                parmer.Value = cmdParms[i].ParamValue;
                parameters[i] = parmer;
            }

            long j = (long)SqlHelper.ExecuteScalar(constr, CommandType.Text, sql, parameters);
            return j;
        }
        public bool Employee_Exists(string sql, params StringSqlParam[] cmdParms)
        {
            SqlDbType d=(SqlDbType)Enum.Parse(typeof(SqlDbType), cmdParms[0].DateType);
            SqlParameter[] parameters = {
					new SqlParameter(cmdParms[0].ParamName,d)
			};
            parameters[0].Value = cmdParms[0].ParamValue;
            return ExecuteScalar(sql, parameters);
        }


        public bool Employee_Update(string sql, params StringSqlParam[] cmdParms)
        {

            SqlParameter[] parameters = new SqlParameter[cmdParms.Length];
            for (int i = 0; i < cmdParms.Length; i++)
            {
                SqlDbType d = (SqlDbType)Enum.Parse(typeof(SqlDbType), cmdParms[i].DateType);
                SqlParameter parmer = new SqlParameter(cmdParms[i].ParamName, d);
                parmer.Value = cmdParms[i].ParamValue;
                parameters[i] = parmer;
            }
            parameters[0].Value = cmdParms[0].ParamValue;
            return ExecuteNonQuery(sql, parameters);
        }

        public DataSet Employee_GetModel(string sqlstr, params StringSqlParam[] cmdParms)
        {
            SqlDbType d = (SqlDbType)Enum.Parse(typeof(SqlDbType), cmdParms[0].DateType);
            SqlParameter[] parameters = {
					new SqlParameter(cmdParms[0].ParamName,d)
			};
            parameters[0].Value = cmdParms[0].ParamValue;
            return Query(sqlstr, parameters);
        }


        public StringSqlParam getParams(string name,object value,string type)
        {

            StringSqlParam par = new StringSqlParam(name,value,type);
            return par;
        }



        #endregion

        #region SystemParameter
        
       
        /// <summary>
        /// 获取系统参数表信息
        /// </summary>
        /// <returns></returns>
        public DataSet SystemParameter_GetList()
        {
            string sqlstr = "select * from [SystemParameter] where [type]=0 and [state]=0 and ISNULL(parentid,'')=''";
            DataSet ds = SqlHelper.ExecuteDataset(constr, CommandType.Text, sqlstr);
            if (ds != null)
            {
                return ds;
            }
            else {
                return null;
            }
        }

        public DataSet SystemParameter_GetListByWhere(string where)
        {

            string sqlstr = "select * from [SystemParameter] where 1=1 "+where;
            DataSet ds = SqlHelper.ExecuteDataset(constr, CommandType.Text, sqlstr);
            if (ds != null)
            {
                return ds;
            }
            else
            {
                return null;
            }
        }
        public   DataSet SystemParameter_GetSmallList(string id)
        {

            string sqlstr = "select * from [SystemParameter] where [type]=0 and [state]=0 and parentid=@parentid";
            DataSet ds = SqlHelper.ExecuteDataset(constr, CommandType.Text, sqlstr, new SqlParameter("@parentid", id));
            if (ds != null)
            {
                return ds;
            }
            else
            {
                return null;
            }
        }


        public bool SystemParameter_Update(string sql, params StringSqlParam[] cmdParms)
        {
            SqlParameter[] parameters = new SqlParameter[cmdParms.Length];
            for (int i = 0; i < cmdParms.Length; i++)
            {
                SqlDbType d = (SqlDbType)Enum.Parse(typeof(SqlDbType), cmdParms[i].DateType);
                SqlParameter parmer = new SqlParameter(cmdParms[i].ParamName, d);
                parmer.Value = cmdParms[i].ParamValue;
                parameters[i] = parmer;
            }
            parameters[0].Value = cmdParms[0].ParamValue;
            return ExecuteNonQuery(sql, parameters);
        }
        public DataSet SystemParameter_GetModel(string sqlstr, params StringSqlParam[] cmdParms)
        {
            SqlDbType d = (SqlDbType)Enum.Parse(typeof(SqlDbType), cmdParms[0].DateType);
            SqlParameter[] parameters = {
					new SqlParameter(cmdParms[0].ParamName,d)
			};
            parameters[0].Value = cmdParms[0].ParamValue;
            return Query(sqlstr, parameters);
        }
        #endregion

        #region syslog
        
       
        /// <summary>
        /// 获取系统日志
        /// </summary>
        /// <returns></returns>
     public DataSet GetSysLog(int PageSize, int PageIndex, string strWhere, string orderStr, out int totalCount)
        {
            StringBuilder sbSelect = new StringBuilder();
            sbSelect.Append(" * ");

            StringBuilder sbFrom = new StringBuilder();
            sbFrom.Append(" systemlog ");
            if (strWhere.Trim().Length > 0)
            {
                sbFrom.Append(strWhere);
            }

            //生成分页SQL语句
            string strSqlPage = Helper.GetPagedSQL(PageSize, sbSelect.ToString(), sbFrom.ToString(), orderStr, PageIndex);
            StringBuilder strSqlCount = new StringBuilder();
            strSqlCount.Append("select count(0) from systemlog ");
            if (strWhere.Trim().Length > 0)
            {
                strSqlCount.Append(strWhere);
            }

            //获取总记录数
            totalCount = Convert.ToInt32(GetSingle(strSqlCount.ToString()));
            //获取分页数据
            return Query(strSqlPage);
        }


         

        public int SetSysLog(string staffid, string staffname, string content, string type, DateTime time)
        {
            string sqlstr = "insert into SystemLog values('" + Guid.NewGuid().ToString().Replace("-", "") + "',@staffid,@staffname,@content,@type,@operateTime)";
            int i = (int)SqlHelper.ExecuteNonQuery(constr, CommandType.Text, sqlstr, new SqlParameter("@staffid", staffid), new SqlParameter("@staffname",
                staffname), new SqlParameter("@content", content), new SqlParameter("@type", type), new SqlParameter("@operateTime", time));
            return i;
        }

    #endregion

        #region SingleArgument

        public DataSet SingleArgument_GetListByPage(int PageSize, int PageIndex, string strWhere, string orderStr, out int totalCount)
        {
            StringBuilder sbSelect = new StringBuilder();
            sbSelect.Append(" * ");

            StringBuilder sbFrom = new StringBuilder();
            sbFrom.Append(" SingleArgument where 1=1 ");
            if (strWhere.Trim().Length > 0)
            {
                sbFrom.Append(strWhere);
            }

            //生成分页SQL语句
            string strSqlPage = Helper.GetPagedSQL(PageSize, sbSelect.ToString(), sbFrom.ToString(), orderStr, PageIndex);
            StringBuilder strSqlCount = new StringBuilder();
            strSqlCount.Append("select count(0) from SingleArgument where 1=1");
            if (strWhere.Trim().Length > 0)
            {
                strSqlCount.Append(strWhere);
            }

            //获取总记录数
            totalCount = Convert.ToInt32(GetSingle(strSqlCount.ToString()));
            //获取分页数据
            return Query(strSqlPage);
        }

       public int SetSingleArgument(string id, string staffid, string staffname, int type, string fieldname)
        {
            string sqlstr = "select count(0) from SingleArgument where staffid=@staffid and type=@type";
            int i = (int)SqlHelper.ExecuteScalar(constr, CommandType.Text, sqlstr, new SqlParameter("@staffid", staffid), new SqlParameter("@type", type));
            //执行修改
            if (i >= 1)
            {
                sqlstr = "update SingleArgument set fieldname=@fieldname where staffid=@staffid and type=@type";
                i = (int)SqlHelper.ExecuteNonQuery(constr, CommandType.Text, sqlstr, new SqlParameter("@staffid", staffid), new SqlParameter("@fieldname", fieldname), new SqlParameter("@type", type));
            }
            //执行添加
            else {
                sqlstr = "insert into SingleArgument values(@id,@staffid,@staffname,@type,@fieldname)";
                i = (int)SqlHelper.ExecuteNonQuery(constr, CommandType.Text, sqlstr, new SqlParameter("@id", id), new SqlParameter("@staffid", staffid), new SqlParameter("@staffname", staffname), new SqlParameter("@type", type), new SqlParameter("@fieldname", fieldname));
            }
            return i;
        }
        #endregion

        #region Product
       public long Product_Add(string sql, params StringSqlParam[] cmdParms)
       {

           SqlParameter[] parameters = new SqlParameter[cmdParms.Length];

           for (int i = 0; i < cmdParms.Length; i++)
           {
               SqlDbType d = (SqlDbType)Enum.Parse(typeof(SqlDbType), cmdParms[i].DateType);
               SqlParameter parmer = new SqlParameter(cmdParms[i].ParamName, d);
               parmer.Value = cmdParms[i].ParamValue;
               parameters[i] = parmer;
           }
           long j = (long)SqlHelper.ExecuteScalar(constr, CommandType.Text, sql,parameters);
           return j;
       }
       public bool Product_Exists(string sql, params StringSqlParam[] cmdParms)
       {
           SqlDbType d = (SqlDbType)Enum.Parse(typeof(SqlDbType), cmdParms[0].DateType);
           SqlParameter[] parameters = {
					new SqlParameter(cmdParms[0].ParamName,d)
			};
           parameters[0].Value = cmdParms[0].ParamValue;
           return ExecuteScalar(sql,parameters);
       }
       public bool Product_Update(string sql, params StringSqlParam[] cmdParms)
       {
           SqlParameter[] parameters = new SqlParameter[cmdParms.Length];
           for (int i = 0; i < cmdParms.Length; i++)
           {
               SqlDbType d = (SqlDbType)Enum.Parse(typeof(SqlDbType), cmdParms[i].DateType);
               SqlParameter parmer = new SqlParameter(cmdParms[i].ParamName, d);
               parmer.Value = cmdParms[i].ParamValue;
               parameters[i] = parmer;
           }
           parameters[0].Value = cmdParms[0].ParamValue;
           return ExecuteNonQuery(sql, parameters);
       }

       public DataSet Product_GetModel(string sqlstr, params StringSqlParam[] cmdParms)
       {
           SqlDbType d = (SqlDbType)Enum.Parse(typeof(SqlDbType), cmdParms[0].DateType);
           SqlParameter[] parameters = {
					new SqlParameter(cmdParms[0].ParamName,d)
			};
           parameters[0].Value = cmdParms[0].ParamValue;
           return Query(sqlstr,parameters);
       }


       public DataSet Product_GetList(string where)
       {
           StringBuilder sb = new StringBuilder();
           sb.Append(" select * from tproduct where 1=1");
           sb.Append(where);
           return Query(sb.ToString());
       }

       public bool Product_Delete(long ID)
       {
           StringBuilder strSql = new StringBuilder();
           strSql.Append("delete from tProduct ");
           strSql.Append(" where ID=@ID");
           SqlParameter[] parameters = {
					new SqlParameter("@ID", ID)
			};
           parameters[0].Value = ID;
           return ExecuteNonQuery(strSql.ToString());
       }


       public DataSet Product_GetListByPage(int PageSize, int PageIndex, string strWhere, string orderStr, out int totalCount)
       {
           StringBuilder sbSelect = new StringBuilder();
           sbSelect.Append(" * ");

           StringBuilder sbFrom = new StringBuilder();
           sbFrom.Append(" tproduct ");
           if (strWhere.Trim().Length > 0)
           {
               sbFrom.Append(strWhere);
           }

           //生成分页SQL语句
           string strSqlPage = Helper.GetPagedSQL(PageSize, sbSelect.ToString(), sbFrom.ToString(), orderStr, PageIndex);
           StringBuilder strSqlCount = new StringBuilder();
           strSqlCount.Append("select count(0) from tproduct ");
           if (strWhere.Trim().Length > 0)
           {
               strSqlCount.Append(strWhere);
           }

           //获取总记录数
           totalCount = Convert.ToInt32(GetSingle(strSqlCount.ToString()));
           //获取分页数据
           return Query(strSqlPage);
       }
        #endregion

        #region order
       public bool Order_Exists(string sql, params StringSqlParam[] cmdParms)
       {
           SqlDbType d = (SqlDbType)Enum.Parse(typeof(SqlDbType), cmdParms[0].DateType);
           SqlParameter[] parameters = {
					new SqlParameter(cmdParms[0].ParamName,d)
			};
           parameters[0].Value = cmdParms[0].ParamValue;
           return ExecuteScalar(sql, parameters);
       }
       public long Order_Add(string sql, params StringSqlParam[] cmdParms)
       {
           SqlParameter[] parameters = new SqlParameter[cmdParms.Length];

           for (int i = 0; i < cmdParms.Length; i++)
           {
               SqlDbType d = (SqlDbType)Enum.Parse(typeof(SqlDbType), cmdParms[i].DateType);
               SqlParameter parmer = new SqlParameter(cmdParms[i].ParamName, d);
               parmer.Value = cmdParms[i].ParamValue;
               parameters[i] = parmer;
           }
           long j = (long)SqlHelper.ExecuteScalar(constr, CommandType.Text, sql, parameters);
           return j;
       }


       public DataSet Order_GetList(string where)
       {
           StringBuilder sb = new StringBuilder();
           sb.Append(" select * from tOrder where 1=1 ");
           sb.Append(where);
           return Query(sb.ToString());
       }

       public DataSet Order_GetListInfo(string where)
       {
           StringBuilder sb = new StringBuilder();
           sb.Append(" select tUser.NickName,tUser.Account,tOrder.* from tOrder,tUser  where tOrder.UserID=tUser.ID ");
           sb.Append(where);
           return Query(sb.ToString());
       }


       public bool Order_Delete(long ID)
       {
           StringBuilder strSql = new StringBuilder();
           strSql.Append("delete from torder ");
           strSql.Append(" where ID=@ID");
           SqlParameter[] parameters = {
					new SqlParameter("@ID", ID)
			};
           parameters[0].Value = ID;
           return ExecuteNonQuery(strSql.ToString());
       }
       public DataSet Order_GetOrderInfo(int PageSize, int PageIndex, string strWhere, string orderStr, out int totalCount)
       {
           StringBuilder sbSelect = new StringBuilder();
           sbSelect.Append(" tUser.NickName,tUser.Account,tOrder.* ");

           StringBuilder sbFrom = new StringBuilder();
           sbFrom.Append(" tOrder join tUser on tOrder.UserID=tUser.ID  where 1=1 ");
           if (strWhere.Trim().Length > 0)
           {
               sbFrom.Append(strWhere);
           }

           //生成分页SQL语句
           string strSqlPage = Helper.GetPagedSQL(PageSize, sbSelect.ToString(), sbFrom.ToString(), orderStr, PageIndex);
           StringBuilder strSqlCount = new StringBuilder();
           strSqlCount.Append(" select count(0) from tOrder join tUser on tOrder.UserID=tUser.ID");
           if (strWhere.Trim().Length > 0)
           {
               strSqlCount.Append(strWhere);
           }

           //获取总记录数
           totalCount = Convert.ToInt32(GetSingle(strSqlCount.ToString()));
           //获取分页数据
           return Query(strSqlPage);
       }
       public DataSet Order_GetListByPage(int PageSize, int PageIndex, string strWhere, string orderStr, out int totalCount)
       {
           StringBuilder sbSelect = new StringBuilder();
           sbSelect.Append(" * ");

           StringBuilder sbFrom = new StringBuilder();
           sbFrom.Append(" torder ");
           if (strWhere.Trim().Length > 0)
           {
               sbFrom.Append(strWhere);
           }

           //生成分页SQL语句
           string strSqlPage = Helper.GetPagedSQL(PageSize, sbSelect.ToString(), sbFrom.ToString(), orderStr, PageIndex);
           StringBuilder strSqlCount = new StringBuilder();
           strSqlCount.Append("select count(0) from torder ");
           if (strWhere.Trim().Length > 0)
           {
               strSqlCount.Append(strWhere);
           }

           //获取总记录数
           totalCount = Convert.ToInt32(GetSingle(strSqlCount.ToString()));
           //获取分页数据
           return Query(strSqlPage);
       }
       public bool Order_Update(string sql, params StringSqlParam[] cmdParms)
       {
           SqlParameter[] parameters = new SqlParameter[cmdParms.Length];
           for (int i = 0; i < cmdParms.Length; i++)
           {
               SqlDbType d = (SqlDbType)Enum.Parse(typeof(SqlDbType), cmdParms[i].DateType);
               SqlParameter parmer = new SqlParameter(cmdParms[i].ParamName, d);
               parmer.Value = cmdParms[i].ParamValue;
               parameters[i] = parmer;
           }
           parameters[0].Value = cmdParms[0].ParamValue;
           return ExecuteNonQuery(sql, parameters);
       }
       #endregion

        #region SpreadItem


       public bool SpreadItem_Exists(string sql, params StringSqlParam[] cmdParms)
       {
           SqlDbType d = (SqlDbType)Enum.Parse(typeof(SqlDbType), cmdParms[0].DateType);
           SqlParameter[] parameters = {
					new SqlParameter(cmdParms[0].ParamName,d)
			};
           parameters[0].Value = cmdParms[0].ParamValue;
           return ExecuteScalar(sql, parameters);
       }

       public long SpreadItem_Add(string sql, params StringSqlParam[] cmdParms)
       {
           SqlParameter[] parameters = new SqlParameter[cmdParms.Length];

           for (int i = 0; i < cmdParms.Length; i++)
           {
               SqlDbType d = (SqlDbType)Enum.Parse(typeof(SqlDbType), cmdParms[i].DateType);
               SqlParameter parmer = new SqlParameter(cmdParms[i].ParamName, d);
               parmer.Value = cmdParms[i].ParamValue;
               parameters[i] = parmer;
           }
           long j = (long)SqlHelper.ExecuteNonQuery(constr, CommandType.Text, sql, parameters);
           return j;
       }

       public bool SpreadItem_Delete(long ID)
       {
           StringBuilder strSql = new StringBuilder();
           strSql.Append("delete from tSpreadItem ");
           strSql.Append(" where ID=@ID");
           SqlParameter[] parameters = {
					new SqlParameter("@ID", ID)
			};
           parameters[0].Value = ID;
           return ExecuteNonQuery(strSql.ToString());
       }

       public bool SpreadItem_DeleteList(string idlist)
       {
           StringBuilder strSql = new StringBuilder();
           strSql.Append("delete from tSpreadItem ");
           strSql.Append(" where ID in (" + idlist + ")  ");
           return ExecuteNonQuery(strSql.ToString());
       }

       public DataSet SpreadItem_GetListByPage(int PageSize, int PageIndex, string strWhere, string orderStr, out int totalCount)
       {
           StringBuilder sbSelect = new StringBuilder();
           sbSelect.Append(" tSpreadItem.*,tProduct.Name ProductName");

           StringBuilder sbFrom = new StringBuilder();
           sbFrom.Append(" tSpreadItem,tProduct where tSpreadItem.ProductID=tProduct.id ");
           if (strWhere.Trim().Length > 0)
           {
               sbFrom.Append(strWhere);
           }

           //生成分页SQL语句
           string strSqlPage = Helper.GetPagedSQL(PageSize, sbSelect.ToString(), sbFrom.ToString(), orderStr, PageIndex);
           StringBuilder strSqlCount = new StringBuilder();
           strSqlCount.Append("select count(0) from tSpreadItem,tProduct where tSpreadItem.ProductID=tProduct.id ");
           if (strWhere.Trim().Length > 0)
           {
               strSqlCount.Append(strWhere);
           }

           //获取总记录数
           totalCount = Convert.ToInt32(GetSingle(strSqlCount.ToString()));
           //获取分页数据
           return Query(strSqlPage);
       }
       public bool SpreadItem_Update(string sql, params StringSqlParam[] cmdParms)
       {
           SqlParameter[] parameters = new SqlParameter[cmdParms.Length];
           for (int i = 0; i < cmdParms.Length; i++)
           {
               SqlDbType d = (SqlDbType)Enum.Parse(typeof(SqlDbType), cmdParms[i].DateType);
               SqlParameter parmer = new SqlParameter(cmdParms[i].ParamName, d);
               parmer.Value = cmdParms[i].ParamValue;
               parameters[i] = parmer;
           }
           parameters[0].Value = cmdParms[0].ParamValue;
           return ExecuteNonQuery(sql, parameters);
       }


       public DataSet SpreadItem_GetModel(string sqlstr, params StringSqlParam[] cmdParms)
       {
           SqlDbType d = (SqlDbType)Enum.Parse(typeof(SqlDbType), cmdParms[0].DateType);
           SqlParameter[] parameters = {
					new SqlParameter(cmdParms[0].ParamName,d)
			};
           parameters[0].Value = cmdParms[0].ParamValue;
           return Query(sqlstr, parameters);
       }

        #endregion


       #region SpreadLevelInfo


       public long SpreadLevelInfo_Add(string sql, params StringSqlParam[] cmdParms)
       {
           SqlParameter[] parameters = new SqlParameter[cmdParms.Length];

           for (int i = 0; i < cmdParms.Length; i++)
           {
               SqlDbType d = (SqlDbType)Enum.Parse(typeof(SqlDbType), cmdParms[i].DateType);
               SqlParameter parmer = new SqlParameter(cmdParms[i].ParamName, d);
               parmer.Value = cmdParms[i].ParamValue;
               parameters[i] = parmer;
           }
           long j = (long)SqlHelper.ExecuteNonQuery(constr, CommandType.Text, sql, parameters);
           return j;
       }

       public DataSet SpreadLevelInfo_GetListByPage(int PageSize, int PageIndex, string strWhere, string orderStr, out int totalCount)
       {
           StringBuilder sbSelect = new StringBuilder();
           sbSelect.Append(" tSpreadItem.Name  SpreadItemName,tSpreadLevelInfo.* ");

           StringBuilder sbFrom = new StringBuilder();
           sbFrom.Append(" tSpreadItem,tSpreadLevelInfo where tSpreadItem.ID=tSpreadLevelInfo.SpreadItemID ");
           if (strWhere.Trim().Length > 0)
           {
               sbFrom.Append(strWhere);
           }

           //生成分页SQL语句
           string strSqlPage = Helper.GetPagedSQL(PageSize, sbSelect.ToString(), sbFrom.ToString(), orderStr, PageIndex);
           StringBuilder strSqlCount = new StringBuilder();
           strSqlCount.Append("select count(0) from tSpreadItem,tSpreadLevelInfo where tSpreadItem.ID=tSpreadLevelInfo.SpreadItemID ");
           if (strWhere.Trim().Length > 0)
           {
               strSqlCount.Append(strWhere);
           }

           //获取总记录数
           totalCount = Convert.ToInt32(GetSingle(strSqlCount.ToString()));
           //获取分页数据
           return Query(strSqlPage);
       }

       public bool SpreadLevelInfo_Update(string sql, params StringSqlParam[] cmdParms)
       {
           SqlParameter[] parameters = new SqlParameter[cmdParms.Length];
           for (int i = 0; i < cmdParms.Length; i++)
           {
               SqlDbType d = (SqlDbType)Enum.Parse(typeof(SqlDbType), cmdParms[i].DateType);
               SqlParameter parmer = new SqlParameter(cmdParms[i].ParamName, d);
               parmer.Value = cmdParms[i].ParamValue;
               parameters[i] = parmer;
           }
           parameters[0].Value = cmdParms[0].ParamValue;
           return ExecuteNonQuery(sql, parameters);
       }


       public DataSet SpreadLevelInfo_GetModel(string sqlstr, params StringSqlParam[] cmdParms)
       {
           SqlDbType d = (SqlDbType)Enum.Parse(typeof(SqlDbType), cmdParms[0].DateType);
           SqlParameter[] parameters = {
					new SqlParameter(cmdParms[0].ParamName,d)
			};
           parameters[0].Value = cmdParms[0].ParamValue;
           return Query(sqlstr, parameters);
       }


       public DataSet SpreadLevelInfo_GetList(string where)
       {
           StringBuilder sb = new StringBuilder();
           sb.Append(" select tSpreadItem.Name  SpreadItemName,tSpreadLevelInfo.* from tSpreadItem,tSpreadLevelInfo where tSpreadItem.ID=tSpreadLevelInfo.SpreadItemID ");
           sb.Append(where);
           return Query(sb.ToString());
       }


       #endregion
       #region Logistic

       public long Logistic_Add(string sql, params StringSqlParam[] cmdParms)
       {
           SqlParameter[] parameters = new SqlParameter[cmdParms.Length];

           for (int i = 0; i < cmdParms.Length; i++)
           {
               SqlDbType d = (SqlDbType)Enum.Parse(typeof(SqlDbType), cmdParms[i].DateType);
               SqlParameter parmer = new SqlParameter(cmdParms[i].ParamName, d);
               parmer.Value = cmdParms[i].ParamValue;
               parameters[i] = parmer;
           }
           long j = (long)SqlHelper.ExecuteScalar(constr, CommandType.Text, sql, parameters);
           return j;
       }

       public bool Logistic_Delete(long ID)
       {
           StringBuilder strSql = new StringBuilder();
           strSql.Append("delete from tLogistic ");
           strSql.Append(" where ID=@ID");
           SqlParameter[] parameters = {
					new SqlParameter("@ID", ID)
			};
           parameters[0].Value = ID;
           return ExecuteNonQuery(strSql.ToString());
       }

       public bool Logistic_DeleteList(string idlist)
       {
           StringBuilder strSql = new StringBuilder();
           strSql.Append("delete from tLogistic ");
           strSql.Append(" where ID in (" + idlist + ")  ");
           return ExecuteNonQuery(strSql.ToString());
       }

       public DataSet Logistic_GetListByPage(int PageSize, int PageIndex, string strWhere, string orderStr, out int totalCount)
       {
           StringBuilder sbSelect = new StringBuilder();
           sbSelect.Append(" * ");

           StringBuilder sbFrom = new StringBuilder();
           sbFrom.Append(" tLogistic where 1=1");
           if (strWhere.Trim().Length > 0)
           {
               sbFrom.Append(strWhere);
           }

           //生成分页SQL语句
           string strSqlPage = Helper.GetPagedSQL(PageSize, sbSelect.ToString(), sbFrom.ToString(), orderStr, PageIndex);
           StringBuilder strSqlCount = new StringBuilder();
           strSqlCount.Append("select count(0) from tUserAuthenticate where 1=1");
           if (strWhere.Trim().Length > 0)
           {
               strSqlCount.Append(strWhere);
           }

           //获取总记录数
           totalCount = Convert.ToInt32(GetSingle(strSqlCount.ToString()));
           //获取分页数据
           return Query(strSqlPage);
       }

       public bool Logistic_Update(string sql, params StringSqlParam[] cmdParms)
       {
           SqlParameter[] parameters = new SqlParameter[cmdParms.Length];
           for (int i = 0; i < cmdParms.Length; i++)
           {
               SqlDbType d = (SqlDbType)Enum.Parse(typeof(SqlDbType), cmdParms[i].DateType);
               SqlParameter parmer = new SqlParameter(cmdParms[i].ParamName, d);
               parmer.Value = cmdParms[i].ParamValue;
               parameters[i] = parmer;
           }
           parameters[0].Value = cmdParms[0].ParamValue;
           return ExecuteNonQuery(sql, parameters);
       }

       public DataSet Logistic_GetModel(string sqlstr, params StringSqlParam[] cmdParms)
       {
           SqlDbType d = (SqlDbType)Enum.Parse(typeof(SqlDbType), cmdParms[0].DateType);
           SqlParameter[] parameters = {
					new SqlParameter(cmdParms[0].ParamName,d)
			};
           parameters[0].Value = cmdParms[0].ParamValue;
           return Query(sqlstr, parameters);
       }

       public DataSet Logistic_GetList(string where)
       {
           StringBuilder sb = new StringBuilder();
           sb.Append(" select * from tLogistic where 1=1");
           sb.Append(where);
           return Query(sb.ToString());
       }

       public DataSet Logistic_GetProvinceList(string where)
       {
           StringBuilder sb = new StringBuilder();
           sb.Append(" select * from t_pub_province where 1=1");
           sb.Append(where);
           return Query(sb.ToString());
       }

       public DataSet Logistic_GetCityList(string where)
       {
           StringBuilder sb = new StringBuilder();
           sb.Append(" select * from t_pub_city where 1=1 ");
           sb.Append(where);
           return Query(sb.ToString());
       }
       public DataSet Logistic_GetBoroughList(string where)
       {
           StringBuilder sb = new StringBuilder();
           sb.Append(" select * from t_pub_borough where 1=1");
           sb.Append(where);
           return Query(sb.ToString());
       }
       #endregion


       #region UserAuthenticate
       public bool UserAuthenticate_Delete(long ID)
       {
           StringBuilder strSql = new StringBuilder();
           strSql.Append("delete from tUserAuthenticate ");
           strSql.Append(" where ID=@ID");
           SqlParameter[] parameters = {
					new SqlParameter("@ID", ID)
			};
           parameters[0].Value = ID;
           return ExecuteNonQuery(strSql.ToString());
       }

       public bool UserAuthenticate_DeleteList(string idlist)
       {
           StringBuilder strSql = new StringBuilder();
           strSql.Append("delete from tUserAuthenticate ");
           strSql.Append(" where ID in (" + idlist + ")  ");
           return ExecuteNonQuery(strSql.ToString());
       }

       public DataSet UserAuthenticate_GetListByPage(int PageSize, int PageIndex, string strWhere, string orderStr, out int totalCount)
       {
           StringBuilder sbSelect = new StringBuilder();
           sbSelect.Append(" tUserAuthenticate.*,tUser.NickName ");

           StringBuilder sbFrom = new StringBuilder();
           sbFrom.Append(" tUserAuthenticate,tUser where tUser.ID=tUserAuthenticate.UserID ");
           if (strWhere.Trim().Length > 0)
           {
               sbFrom.Append(strWhere);
           }

           //生成分页SQL语句
           string strSqlPage = Helper.GetPagedSQL(PageSize, sbSelect.ToString(), sbFrom.ToString(), orderStr, PageIndex);
           StringBuilder strSqlCount = new StringBuilder();
           strSqlCount.Append("select count(0) from tUserAuthenticate,tUser where tUser.ID=tUserAuthenticate.UserID ");
           if (strWhere.Trim().Length > 0)
           {
               strSqlCount.Append(strWhere);
           }

           //获取总记录数
           totalCount = Convert.ToInt32(GetSingle(strSqlCount.ToString()));
           //获取分页数据
           return Query(strSqlPage);
       }

       public bool UserAuthenticate_Update(string sql, params StringSqlParam[] cmdParms)
       {
           SqlParameter[] parameters = new SqlParameter[cmdParms.Length];
           for (int i = 0; i < cmdParms.Length; i++)
           {
               SqlDbType d = (SqlDbType)Enum.Parse(typeof(SqlDbType), cmdParms[i].DateType);
               SqlParameter parmer = new SqlParameter(cmdParms[i].ParamName, d);
               parmer.Value = cmdParms[i].ParamValue;
               parameters[i] = parmer;
           }
           parameters[0].Value = cmdParms[0].ParamValue;
           return ExecuteNonQuery(sql, parameters);
       }

       public DataSet UserAuthenticate_GetModel(string sqlstr, params StringSqlParam[] cmdParms)
       {
           SqlDbType d = (SqlDbType)Enum.Parse(typeof(SqlDbType), cmdParms[0].DateType);
           SqlParameter[] parameters = {
					new SqlParameter(cmdParms[0].ParamName,d)
			};
           parameters[0].Value = cmdParms[0].ParamValue;
           return Query(sqlstr, parameters);
       }

       public DataSet UserAuthenticate_GetList(string where)
       {
           StringBuilder sb = new StringBuilder();
           sb.Append(" select * from tUserAuthenticate,tUser where tUser.ID=tUserAuthenticate.UserID ");
           sb.Append(where);
           return Query(sb.ToString());
       }

       #endregion

       #region Asset

       public DataSet Asset_GetListByPage(int PageSize, int PageIndex, string strWhere, string orderStr, out int totalCount)
       {
           StringBuilder sbSelect = new StringBuilder();
           sbSelect.Append(" * ");

           StringBuilder sbFrom = new StringBuilder();
           sbFrom.Append(" tAsset where 1=1");
           if (strWhere.Trim().Length > 0)
           {
               sbFrom.Append(strWhere);
           }

           //生成分页SQL语句
           string strSqlPage = Helper.GetPagedSQL(PageSize, sbSelect.ToString(), sbFrom.ToString(), orderStr, PageIndex);
           StringBuilder strSqlCount = new StringBuilder();
           strSqlCount.Append("select count(0) from tAsset where 1=1");
           if (strWhere.Trim().Length > 0)
           {
               strSqlCount.Append(strWhere);
           }

           //获取总记录数
           totalCount = Convert.ToInt32(GetSingle(strSqlCount.ToString()));
           //获取分页数据
           return Query(strSqlPage);
       }

       public bool Asset_Update(string sql, params StringSqlParam[] cmdParms)
       {
           SqlParameter[] parameters = new SqlParameter[cmdParms.Length];
           for (int i = 0; i < cmdParms.Length; i++)
           {
               SqlDbType d = (SqlDbType)Enum.Parse(typeof(SqlDbType), cmdParms[i].DateType);
               SqlParameter parmer = new SqlParameter(cmdParms[i].ParamName, d);
               parmer.Value = cmdParms[i].ParamValue;
               parameters[i] = parmer;
           }
           parameters[0].Value = cmdParms[0].ParamValue;
           return ExecuteNonQuery(sql, parameters);
       }

       public DataSet Asset_GetModel(string sqlstr, params StringSqlParam[] cmdParms)
       {
           SqlDbType d = (SqlDbType)Enum.Parse(typeof(SqlDbType), cmdParms[0].DateType);
           SqlParameter[] parameters = {
					new SqlParameter(cmdParms[0].ParamName,d)
			};
           parameters[0].Value = cmdParms[0].ParamValue;
           return Query(sqlstr, parameters);
       }

       public DataSet Asset_GetList(string where)
       {
           StringBuilder sb = new StringBuilder();
           sb.Append(" select * from tAsset where 1=1");
           sb.Append(where);
           return Query(sb.ToString());
       }

       #endregion


       #region AssetLog

       public DataSet AssetLog_GetListByPage(int PageSize, int PageIndex, string strWhere, string orderStr, out int totalCount)
       {
           StringBuilder sbSelect = new StringBuilder();
           sbSelect.Append("  tAssetLog.*,u.NickName 用户名,u2.NickName 操作人,u.ID 用户ID");

           StringBuilder sbFrom = new StringBuilder();
           sbFrom.Append(" tAsset,tAssetLog,tUser u,tUser u2 where tAssetLog.AssetID=tAsset.ID and u.ID=tAsset.UserID and u2.ID=tAssetLog.logOperator");
           if (strWhere.Trim().Length > 0)
           {
               sbFrom.Append(strWhere);
           }

           //生成分页SQL语句
           string strSqlPage = Helper.GetPagedSQL(PageSize, sbSelect.ToString(), sbFrom.ToString(), orderStr, PageIndex);
           StringBuilder strSqlCount = new StringBuilder();
           strSqlCount.Append("select count(0) from tAsset,tAssetLog,tUser u,tUser u2 where tAssetLog.AssetID=tAsset.ID and u.ID=tAsset.UserID and u2.ID=tAssetLog.logOperator ");
           if (strWhere.Trim().Length > 0)
           {
               strSqlCount.Append(strWhere);
           }

           //获取总记录数
           totalCount = Convert.ToInt32(GetSingle(strSqlCount.ToString()));
           //获取分页数据
           return Query(strSqlPage);
       }


       public bool AssetLog_Exists(string sql, params StringSqlParam[] cmdParms)
       {
           SqlDbType d = (SqlDbType)Enum.Parse(typeof(SqlDbType), cmdParms[0].DateType);
           SqlParameter[] parameters = {
					new SqlParameter(cmdParms[0].ParamName,d)
			};
           parameters[0].Value = cmdParms[0].ParamValue;
           return ExecuteScalar(sql,parameters);
       }

       public DataSet AssetLog_GetModel(string sqlstr, params StringSqlParam[] cmdParms)
       {
           SqlDbType d = (SqlDbType)Enum.Parse(typeof(SqlDbType), cmdParms[0].DateType);
           SqlParameter[] parameters = {
					new SqlParameter(cmdParms[0].ParamName,d)
			};
           parameters[0].Value = cmdParms[0].ParamValue;
           return Query(sqlstr, parameters);
       }

       public DataSet AssetLog_GetList(string where)
       {
           StringBuilder sb = new StringBuilder();
           sb.Append(" select * from tAsset,tAssetLog where tAssetLog.AssetID=tAsset.ID ");
           sb.Append(where);
           return Query(sb.ToString());
       }

         

       #endregion

       #region Withdrawal


       public bool Withdrawal_Update(string sql, params StringSqlParam[] cmdParms)
       {
           SqlParameter[] parameters = new SqlParameter[cmdParms.Length];
           for (int i = 0; i < cmdParms.Length; i++)
           {
               SqlDbType d = (SqlDbType)Enum.Parse(typeof(SqlDbType), cmdParms[i].DateType);
               SqlParameter parmer = new SqlParameter(cmdParms[i].ParamName, d);
               parmer.Value = cmdParms[i].ParamValue;
               parameters[i] = parmer;
           }
           parameters[0].Value = cmdParms[0].ParamValue;
           return ExecuteNonQuery(sql, parameters);
       }

       public DataSet Withdrawal_GetModel(string sqlstr, params StringSqlParam[] cmdParms)
       {
           SqlDbType d = (SqlDbType)Enum.Parse(typeof(SqlDbType), cmdParms[0].DateType);
           SqlParameter[] parameters = {
					new SqlParameter(cmdParms[0].ParamName,d)
			};
           parameters[0].Value = cmdParms[0].ParamValue;
           return Query(sqlstr, parameters);
       }

       public DataSet Withdrawal_GetList(string where)
       {
           StringBuilder sb = new StringBuilder();
           sb.Append(" select * from tWithdrawal where 1=1");
           sb.Append(where);
           return Query(sb.ToString());
       }


       public DataSet Withdrawal_GetListByPage(int PageSize, int PageIndex, string strWhere, string orderStr, out int totalCount)
       {
           StringBuilder sbSelect = new StringBuilder();
           sbSelect.Append(" * ");

           StringBuilder sbFrom = new StringBuilder();
           sbFrom.Append(" tWithdrawal whree 1=1");
           if (strWhere.Trim().Length > 0)
           {
               sbFrom.Append(strWhere);
           }

           //生成分页SQL语句
           string strSqlPage = Helper.GetPagedSQL(PageSize, sbSelect.ToString(), sbFrom.ToString(), orderStr, PageIndex);
           StringBuilder strSqlCount = new StringBuilder();
           strSqlCount.Append("select count(0) from tWithdrawal where 1=1");
           if (strWhere.Trim().Length > 0)
           {
               strSqlCount.Append(strWhere);
           }

           //获取总记录数
           totalCount = Convert.ToInt32(GetSingle(strSqlCount.ToString()));
           //获取分页数据
           return Query(strSqlPage);
       }

       #endregion
       #region User


       public bool User_Delete(long ID)
       {
           StringBuilder strSql = new StringBuilder();
           strSql.Append("delete from tuser ");
           strSql.Append(" where ID=@ID");
           SqlParameter[] parameters = {
					new SqlParameter("@ID", ID)
			};
           parameters[0].Value = ID;
           return ExecuteNonQuery(strSql.ToString());
       }

       public bool User_DeleteList(string idlist)
       {
           StringBuilder strSql = new StringBuilder();
           strSql.Append("delete from tuser ");
           strSql.Append(" where ID in (" + idlist + ")  ");
           return ExecuteNonQuery(strSql.ToString());
       }

       public DataSet User_GetListByPage(int PageSize, int PageIndex, string strWhere, string orderStr, out int totalCount)
       {
           StringBuilder sbSelect = new StringBuilder();
           sbSelect.Append(" * ");

           StringBuilder sbFrom = new StringBuilder();
           sbFrom.Append(" tuser ");
           if (strWhere.Trim().Length > 0)
           {
               sbFrom.Append(strWhere);
           }

           //生成分页SQL语句
           string strSqlPage = Helper.GetPagedSQL(PageSize, sbSelect.ToString(), sbFrom.ToString(), orderStr, PageIndex);
           StringBuilder strSqlCount = new StringBuilder();
           strSqlCount.Append("select count(0) from tuser ");
           if (strWhere.Trim().Length > 0)
           {
               strSqlCount.Append(strWhere);
           }

           //获取总记录数
           totalCount = Convert.ToInt32(GetSingle(strSqlCount.ToString()));
           //获取分页数据
           return Query(strSqlPage);
       }

       public bool User_Update(string sql, params StringSqlParam[] cmdParms)
       {
           SqlParameter[] parameters = new SqlParameter[cmdParms.Length];
           for (int i = 0; i < cmdParms.Length; i++)
           {
               SqlDbType d = (SqlDbType)Enum.Parse(typeof(SqlDbType), cmdParms[i].DateType);
               SqlParameter parmer = new SqlParameter(cmdParms[i].ParamName, d);
               parmer.Value = cmdParms[i].ParamValue;
               parameters[i] = parmer;
           }
           return ExecuteNonQuery(sql, parameters);
       }

       public DataSet User_GetModel(string sqlstr, params StringSqlParam[] cmdParms)
       {
           SqlDbType d = (SqlDbType)Enum.Parse(typeof(SqlDbType), cmdParms[0].DateType);
           SqlParameter[] parameters = {
					new SqlParameter(cmdParms[0].ParamName,d)
			};
           parameters[0].Value = cmdParms[0].ParamValue;
           return Query(sqlstr, parameters);
       }

       public DataSet User_GetList(string sql)
       {
           return Query(sql);
       }

       #endregion


       #region Task
       public DataSet Task_GetListByPage(int PageSize, int PageIndex, string strWhere, string orderStr, out int totalCount)
       {
           StringBuilder sbSelect = new StringBuilder();
           sbSelect.Append(" * ");

           StringBuilder sbFrom = new StringBuilder();
           sbFrom.Append(" tTask where 1=1");
           if (strWhere.Trim().Length > 0)
           {
               sbFrom.Append(strWhere);
           }

           //生成分页SQL语句
           string strSqlPage = Helper.GetPagedSQL(PageSize, sbSelect.ToString(), sbFrom.ToString(), orderStr, PageIndex);
           StringBuilder strSqlCount = new StringBuilder();
           strSqlCount.Append("select count(0) from tTask where 1=1 ");
           if (strWhere.Trim().Length > 0)
           {
               strSqlCount.Append(strWhere);
           }

           //获取总记录数
           totalCount = Convert.ToInt32(GetSingle(strSqlCount.ToString()));
           //获取分页数据
           return Query(strSqlPage);
       }

       public bool Task_Update(string sql, params StringSqlParam[] cmdParms)
       {
           SqlParameter[] parameters = new SqlParameter[cmdParms.Length];
           for (int i = 0; i < cmdParms.Length; i++)
           {
               SqlDbType d = (SqlDbType)Enum.Parse(typeof(SqlDbType), cmdParms[i].DateType);
               SqlParameter parmer = new SqlParameter(cmdParms[i].ParamName, d);
               parmer.Value = cmdParms[i].ParamValue;
               parameters[i] = parmer;
           }
           return ExecuteNonQuery(sql, parameters);
       }

       public DataSet Task_GetModel(string sqlstr, params StringSqlParam[] cmdParms)
       {
           SqlDbType d = (SqlDbType)Enum.Parse(typeof(SqlDbType), cmdParms[0].DateType);
           SqlParameter[] parameters = {
					new SqlParameter(cmdParms[0].ParamName,d)
			};
           parameters[0].Value = cmdParms[0].ParamValue;
           return Query(sqlstr, parameters);
       }

       public DataSet Task_GetList(string sql)
       {
           return Query(sql);
       }

       public DataSet Task_GetListByEmployee(string sql)
       {
           return Query(sql);
       }

       public long Task_Add(string sql, params StringSqlParam[] cmdParms)
       {
           SqlParameter[] parameters = new SqlParameter[cmdParms.Length];

           for (int i = 0; i < cmdParms.Length; i++)
           {
               SqlDbType d = (SqlDbType)Enum.Parse(typeof(SqlDbType), cmdParms[i].DateType);
               SqlParameter parmer = new SqlParameter(cmdParms[i].ParamName, d);
               parmer.Value = cmdParms[i].ParamValue;
               parameters[i] = parmer;
           }

           long j = (long)SqlHelper.ExecuteScalar(constr, CommandType.Text, sql, parameters);
           return j;
       }


       #endregion


       #region TaskLog


       public DataSet TaskLog_GetListByPage(int PageSize, int PageIndex, string strWhere, string orderStr, out int totalCount)
       {
           StringBuilder sbSelect = new StringBuilder();
           sbSelect.Append(" * ");

           StringBuilder sbFrom = new StringBuilder();
           sbFrom.Append(" tTaskLog ");
           if (strWhere.Trim().Length > 0)
           {
               sbFrom.Append(strWhere);
           }

           //生成分页SQL语句
           string strSqlPage = Helper.GetPagedSQL(PageSize, sbSelect.ToString(), sbFrom.ToString(), orderStr, PageIndex);
           StringBuilder strSqlCount = new StringBuilder();
           strSqlCount.Append("select count(0) from tTaskLog ");
           if (strWhere.Trim().Length > 0)
           {
               strSqlCount.Append(strWhere);
           }

           //获取总记录数
           totalCount = Convert.ToInt32(GetSingle(strSqlCount.ToString()));
           //获取分页数据
           return Query(strSqlPage);
       }

       public bool TaskLog_Update(string sql, params StringSqlParam[] cmdParms)
       {
           SqlParameter[] parameters = new SqlParameter[cmdParms.Length];
           for (int i = 0; i < cmdParms.Length; i++)
           {
               SqlDbType d = (SqlDbType)Enum.Parse(typeof(SqlDbType), cmdParms[i].DateType);
               SqlParameter parmer = new SqlParameter(cmdParms[i].ParamName, d);
               parmer.Value = cmdParms[i].ParamValue;
               parameters[i] = parmer;
           }
           return ExecuteNonQuery(sql, parameters);
       }

       public DataSet TaskLog_GetModel(string sqlstr, params StringSqlParam[] cmdParms)
       {
           SqlDbType d = (SqlDbType)Enum.Parse(typeof(SqlDbType), cmdParms[0].DateType);
           SqlParameter[] parameters = {
					new SqlParameter(cmdParms[0].ParamName,d)
			};
           parameters[0].Value = cmdParms[0].ParamValue;
           return Query(sqlstr, parameters);
       }

       public DataSet TaskLog_GetList(string sql)
       {
           return Query(sql);
       }


       public long TaskLog_Add(string sql, params StringSqlParam[] cmdParms)
       {
           SqlParameter[] parameters = new SqlParameter[cmdParms.Length];

           for (int i = 0; i < cmdParms.Length; i++)
           {
               SqlDbType d = (SqlDbType)Enum.Parse(typeof(SqlDbType), cmdParms[i].DateType);
               SqlParameter parmer = new SqlParameter(cmdParms[i].ParamName, d);
               parmer.Value = cmdParms[i].ParamValue;
               parameters[i] = parmer;
           }

           long j = (long)SqlHelper.ExecuteScalar(constr, CommandType.Text, sql, parameters);
           return j;
       }
       #endregion

       #region 通用方法
       /// <summary>
         /// 执行一条计算查询结果语句，返回查询结果（object）。
         /// </summary>
         /// <param name="SQLString">计算查询结果语句</param>
         /// <returns>查询结果（object）</returns>
         public static object GetSingle(string SQLString)
         {
             object i = SqlHelper.ExecuteScalar(constr, CommandType.Text, SQLString);
             return i;
         }
         public DataSet Query(string strSqlPage, params SqlParameter[] cmdParms)
         {
             DataSet ds = SqlHelper.ExecuteDataset(constr, CommandType.Text, strSqlPage,cmdParms);
             if (ds.Tables[0].Rows.Count > 0)
             {
                 return ds;
             }
             return new DataSet();
         }
         public bool ExecuteScalar(string strSqlPage, params SqlParameter[] cmdParms)
         {
             int i = (int)SqlHelper.ExecuteScalar(constr, CommandType.Text, strSqlPage, cmdParms);
             if (i <= 0)
             {
                 return false;
             }
             else
             {
                 return true;
             }
         }


         public bool ExecuteNonQuery(string strSqlPage, params SqlParameter[] cmdParms)
         {
             int i = (int)SqlHelper.ExecuteNonQuery(constr, CommandType.Text, strSqlPage, cmdParms);
             if (i <= 0)
             {
                 return false;
             }
             else
             {
                 return true;
             }
         }
        #endregion
    }
}
