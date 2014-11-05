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
    class OrderBLL
    {
        public OrderBLL()
        { }
        OrderDAL emdal = new OrderDAL();
        public DataSet GetUserInfo(int PageSize, int PageIndex, string strWhere, string orderStr, out int totalCount)
        {
            return emdal.GetOrderInfo(PageSize, PageIndex, strWhere, orderStr, out totalCount);
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(long ID)
        {
            return emdal.Exists(ID);
        }


        public DataSet GetList(string where)
        { 
            return emdal.GetList(where);
        }

        public DataSet GetListInfo(string where)
        {
            return emdal.GetListInfo(where);
        }
        public long Add(AdminManager.Model.OrderModel model)
        {
            return emdal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(AdminManager.Model.OrderModel model)
        {
            return emdal.Update(model);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public AdminManager.Model.OrderModel GetModel(long ID)
        {

            return emdal.GetModel(ID);
        }
    }
}
