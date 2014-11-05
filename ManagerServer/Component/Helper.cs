using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerServer
{
    class Helper
    {
        /// <summary>
        /// 将密码进行MD5 SHA1 加密
        /// </summary>
        /// <param name="password">加密前的密码</param>
        /// <returns>加密后的密码</returns>
        public static string Password(string password)
        {
            password = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(password
                , System.Web.Configuration.FormsAuthPasswordFormat.MD5.ToString());
            password = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(password
                , System.Web.Configuration.FormsAuthPasswordFormat.SHA1.ToString());
            return password;
        }

        /// <summary>
        /// 获取分页的sql语句
        /// </summary>
        /// <param name="count"></param>
        /// <param name="selectCmd"></param>
        /// <param name="fromCmd"></param>
        /// <param name="orderStr"></param>
        /// <param name="pageindex"></param>
        /// <returns></returns>
        public static string GetPagedSQL(int count, string selectCmd, string fromCmd, string orderStr, int pageindex)
        {
            string sb = "with tmpTab as (select " + selectCmd + ",row_number() OVER(" + orderStr + ") as row from " + fromCmd + " ) SELECT * FROM tmpTab WHERE row between " +
                (Convert.ToString((pageindex - 1) * count) == "0" ? Convert.ToString((pageindex - 1) * count) : Convert.ToString((pageindex - 1) * count + 1)) + " and " +
                Convert.ToString((pageindex) * count); //+ ";";
            return sb;
        }
    }
}
