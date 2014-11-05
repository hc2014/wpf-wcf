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
    class SysLogDAL
    {
        public SysLogDAL()
        { 
        }
        public DataSet GetSysLog(int PageSize, int PageIndex, string strWhere, string orderStr, out int totalCount)
        {
            EmployeeClient ec = new EmployeeClient();
           return ec.GetSysLog(PageSize,PageIndex,strWhere,orderStr,out totalCount);
        }
        public int SetSysLog(string staffid, string staffname, string content, string type, DateTime time)
        {
            EmployeeClient ec = new EmployeeClient();
            return ec.SetSysLog(staffid,staffname,content,type,time);
        }
    }
}
