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
	public partial class TaskBLL
	{
        private readonly AdminManager.DAL.TaskDAL dal = new AdminManager.DAL.TaskDAL();
        public TaskBLL()
		{}
		#region  BasicMethod

		/// <summary>
		/// 增加一条数据
		/// </summary>
        public long Add(AdminManager.Model.TaskModel model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
        public bool Update(AdminManager.Model.TaskModel model)
		{
			return dal.Update(model);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
        public AdminManager.Model.TaskModel GetModel(long ID)
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

        public DataSet GetListByEmployee(string strWhere,long id)
        {
            return dal.GetListByEmployee(strWhere,id);
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

