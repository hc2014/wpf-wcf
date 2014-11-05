using System;
using System.Data;
using System.Collections.Generic;
using AdminManager.Component;
using AdminManager.Model;
namespace AdminManager.BLL
{
	/// <summary>
	/// 1
	/// </summary>
	public partial class ProductBLL
	{
        private readonly AdminManager.DAL.ProductDal dal = new AdminManager.DAL.ProductDal();
        public ProductBLL()
		{}
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(long ID)
		{
			return dal.Exists(ID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
        public long Add(AdminManager.Model.ProductModel model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
        public bool Update(AdminManager.Model.ProductModel model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(long ID)
		{
			
			return dal.Delete(ID);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
        public AdminManager.Model.ProductModel GetModel(long ID)
		{
			
			return dal.GetModel(ID);
		}

        public DataSet GetList(string where)
        {
            return dal.GetList(where);
        }

		/// <summary>
		/// 分页获取数据列表
		/// </summary>
        public DataSet GetListByPage(int PageSize, int PageIndex, string strWhere, string orderStr, out int totalCount)
		{
            return dal.GetListByPage(PageSize, PageIndex, strWhere, orderStr, out totalCount);
		}

		#endregion  BasicMethod
	}
}

