﻿using System;
using System.Data;
using System.Collections.Generic;
using AdminManager.Component;
using AdminManager.Model;
namespace AdminManager.BLL
{
	/// <summary>
	/// 1
	/// </summary>
	public partial class UserAuthenticateBLL
	{
        private readonly AdminManager.DAL.UserAuthenticateDAL dal = new AdminManager.DAL.UserAuthenticateDAL();
        public UserAuthenticateBLL()
		{}
		#region  BasicMethod




		/// <summary>
		/// 更新一条数据
		/// </summary>
        public bool Update(AdminManager.Model.UserAuthenticateModel model)
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
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string IDlist )
		{
			return dal.DeleteList(IDlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
        public AdminManager.Model.UserAuthenticateModel GetModel(long ID)
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
		/// 获得数据列表
		/// </summary>
        public List<AdminManager.Model.UserAuthenticateModel> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
        public List<AdminManager.Model.UserAuthenticateModel> DataTableToList(DataTable dt)
		{
            List<AdminManager.Model.UserAuthenticateModel> modelList = new List<AdminManager.Model.UserAuthenticateModel>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
                AdminManager.Model.UserAuthenticateModel model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = dal.DataRowToModel(dt.Rows[n]);
					if (model != null)
					{
						modelList.Add(model);
					}
				}
			}
			return modelList;
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

