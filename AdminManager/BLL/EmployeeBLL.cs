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
    class EmployeeBLL
    {
        public EmployeeBLL()
        { }
        EmployeeDAL emdal = new EmployeeDAL();
        public int Login(string Account, string pwd)
        {
            int i = emdal.Login(Account, pwd);
            return i;
        }
        public DataSet GetUserInfo(string Account)
        {
            return emdal.GetUserInfo(Account);
        }
        public DataSet GetUserAuthorityList(int PageSize, int PageIndex, string strWhere, string orderStr, out int totalCount)
        {
            return emdal.GetUserAuthorityList(PageSize, PageIndex, strWhere, orderStr, out totalCount);
        }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(long ID)
        {
            return emdal.Exists(ID);
        }
        public bool ExistsByUser(string Account)
        {
            return emdal.ExistsByUser(Account);
        }

        public long Add(AdminManager.Model.EmployeeModel model)
        {
            return emdal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(AdminManager.Model.EmployeeModel model)
        {
            return emdal.Update(model);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public AdminManager.Model.EmployeeModel GetModel(long ID)
        {

            return emdal.GetModel(ID);
        }
    }
}
