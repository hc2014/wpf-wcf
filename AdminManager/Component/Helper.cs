using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web;
using System.Xml;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using AdminManager.BLL;
using System.Windows;
using AdminManager.Windows;
namespace AdminManager.Component
{
    public class Helper
    {
        EmployeeBLL embll = new EmployeeBLL();
        public Helper()
        { }
        public DataSet GetEmployeeInfo(string account)
        {
           return embll.GetUserInfo(account);
        }
        public static string GetGuid()
        {
            return Guid.NewGuid().ToString().Replace("-", "");
        }


        public string WorkMonthFrom
        {
            get { return "WorkMonthFrom"; }
        }
        public string WorkMonthTo
        {
            get { return "WorkMonthTo"; }
        }
        public Dictionary<string, int> GetWorkMonth()
        {
            SystemParameterBLL spbll = new SystemParameterBLL();
            DataSet ds=spbll.GetList(" and type=2");
            if (ds.Tables.Count== 0)
            {
                return null;
            }
            //int realFrom=0;
            int realTo=31;

            string Source = ds.Tables[0].Rows[0]["order"].ToString();
            int index = Source.IndexOf('-');
            int from = Convert.ToInt32(Source.Substring(0, index));
            int to = Convert.ToInt32(Source.Substring(index+1));

            DateTime d1 = DateTime.Now;
            DateTime d2=DateTime.Now.AddMonths(1);
            int days = ((TimeSpan)(d2 - d1)).Days;
            if (to <= days)
            {
                realTo = to;
            }
            else
            {
                realTo = days;
            }

            Dictionary<string, int> dic = new Dictionary<string, int>();
            dic.Add(WorkMonthFrom, from);
            dic.Add(WorkMonthTo, realTo);
            return dic;
        }

        public Dictionary<string, DateTime> GetDateTime()
        {
            Dictionary<string, int> dic = GetWorkMonth();
            int from = dic[WorkMonthFrom];
            int to = dic[WorkMonthTo];
            Dictionary<string, DateTime> value = new Dictionary<string, DateTime>();
            if (from < to)
            {
                string TimeFrom = DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + from + " 00:00:00";
                string TimeTo = DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + to + " 23:59:59";

                value.Add(WorkMonthFrom, Convert.ToDateTime(TimeFrom));
                value.Add(WorkMonthTo, Convert.ToDateTime(TimeTo));
                return value;
            }
            else
            {
                string TimeFrom = DateTime.Now.Year + "-" + DateTime.Now.AddMonths(-1).Month + "-" + from + " 00:00:00";
                string TimeTo = DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + to + " 23:59:59";

                value.Add(WorkMonthFrom, Convert.ToDateTime(TimeFrom));
                value.Add(WorkMonthTo, Convert.ToDateTime(TimeTo));
                return value;
            }
        }


        public Window ReturnWin(int type, long Sourceid,long taskid)
        {
            Window win = null;
            switch (type)
            {
                case 0:
                    win = new TemplateWindow(800, 600, WindowType.OrderInfo, Sourceid,taskid);
                    break;
                case 1:
                    win = new TemplateWindow(800, 600, WindowType.VerifyUser, Sourceid,taskid);
                    break;
                case 2:
                    win = new EditLogistic(500, 350, Sourceid,taskid);
                    break;
            }
            return win;
        }
    }
}