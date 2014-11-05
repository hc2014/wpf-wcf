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
	public partial class AssetLogBLL
	{
        private readonly AdminManager.DAL.AssetLogDal dal = new AdminManager.DAL.AssetLogDal();
		public AssetLogBLL()
		{}
		#region  BasicMethod



		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
        public bool Exists(long ID)
        {
            return dal.Exists(ID);
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

