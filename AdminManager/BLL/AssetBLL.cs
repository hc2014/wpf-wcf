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
	public partial class AssetBLL
	{
        private readonly AdminManager.DAL.AssetDAL dal = new AdminManager.DAL.AssetDAL();
        public AssetBLL()
		{}
		#region  BasicMethod



		/// <summary>
		/// 更新一条数据
		/// </summary>
        public bool Update(AdminManager.Model.AssetModel model)
		{
			return dal.Update(model);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
        public AdminManager.Model.AssetModel GetModel(long ID)
		{
			
			return dal.GetModel(ID);
		}


		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
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

