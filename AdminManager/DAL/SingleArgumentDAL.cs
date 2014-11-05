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
   public class SingleArgumentDAL
    {
       public SingleArgumentDAL()
       { }
       EmployeeClient sc = new EmployeeClient();
       public int SetSingleArgument(string id, string staffid, string staffname, int type, string fieldname)
       {
           
           int ds = sc.SetSingleArgument(id, staffid, staffname, type, fieldname);
           return ds;
       }
       public DataSet GetListByPage(int PageSize, int PageIndex, string strWhere, string orderStr, out int totalCount)
       {
           return sc.SingleArgument_GetListByPage(PageSize, PageIndex, strWhere, orderStr, out totalCount);
       }
    }
}
