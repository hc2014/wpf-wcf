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
    class SystemParameterBLL
    {
        SystemParameterDAL systemparDal = new SystemParameterDAL();
        public SystemParameterBLL()
        { }

        public DataSet GetList()
        {
           return systemparDal.GetList();
        }
        public DataSet GetList(string where)
        {
            return systemparDal.GetList(where);
        }

        public DataSet GetSmallList(string id)
        {
            return systemparDal.GetSmallList(id);
        }
        public bool Update(AdminManager.Model.SystemParameterModel model)
        {
            return systemparDal.Update(model);
        }
        public AdminManager.Model.SystemParameterModel GetModel(string ID)
        {

            return systemparDal.GetModel(ID);
        }
    }
}
