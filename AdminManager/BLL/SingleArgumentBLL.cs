using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdminManager.DAL;
using AdminManager.Model;
using System.Data;
using AdminManager.Component;
namespace AdminManager.BLL
{
    class SingleArgumentBLL
    {
        SingleArgumentDAL singleDal = new SingleArgumentDAL();
        public SingleArgumentBLL()
        { }

        public int SetSingleArgumen(string staffid, string staffname, int type, string fieldname)
        {
         return singleDal.SetSingleArgument(Helper.GetGuid(),staffid, staffname, type, fieldname);
        }
        public DataSet GetListByPage(int PageSize, int PageIndex, string strWhere, string orderStr, out int totalCount)
        {
            return singleDal.GetListByPage(PageSize, PageIndex, strWhere, orderStr, out totalCount);
        }
    }
}
