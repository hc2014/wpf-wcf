using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdminManager.DAL;
using AdminManager.Model;
using System.Data;
namespace AdminManager.BLL
{
    class SysLogBLL
    {
        public SysLogBLL()
        { }
        SysLogDAL syslog = new SysLogDAL();
        public DataSet GetSysLog(int PageSize, int PageIndex, string strWhere, string orderStr, out int totalCount)
        {
            return syslog.GetSysLog(PageSize, PageIndex, strWhere, orderStr, out totalCount);
        }
        public int SetSysLog(string staffid, string staffname, string content, string type, DateTime time)
        {
            return syslog.SetSysLog(staffid, staffname, content, type, time);
        }
    }
}
