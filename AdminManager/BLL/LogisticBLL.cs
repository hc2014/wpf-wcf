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
	public partial class LogisticBLL
	{
        private readonly AdminManager.DAL.LogisticDAL dal = new AdminManager.DAL.LogisticDAL();
        public LogisticBLL()
		{}
		#region  BasicMethod


        public long Add(AdminManager.Model.LogisticModel model)
		{
			return dal.Add(model);
		}

        public bool Update(AdminManager.Model.LogisticModel model)
		{
			return dal.Update(model);
		}

		public bool Delete(long ID)
		{
			
			return dal.Delete(ID);
		}

		public bool DeleteList(string IDlist )
		{
			return dal.DeleteList(IDlist );
		}

        public AdminManager.Model.LogisticModel GetModel(long ID)
		{
			
			return dal.GetModel(ID);
		}

		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}

        public List<AdminManager.Model.LogisticModel> DataTableToList(DataTable dt)
		{
            List<AdminManager.Model.LogisticModel> modelList = new List<AdminManager.Model.LogisticModel>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
                AdminManager.Model.LogisticModel model;
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

        public DataSet GetListByPage(int PageSize, int PageIndex, string strWhere, string orderStr, out int totalCount)
		{
            return dal.GetListByPage(PageSize, PageIndex, strWhere, orderStr, out totalCount);
		}


        public DataSet GetProvanceList(string strWhere)
        {
           return dal.GetProvanceList(strWhere);
        }

        public DataSet GetCityList(string strWhere)
        {
            return dal.GetCityList(strWhere);
        }

        public DataSet GetGetBoroughList(string strWhere)
        {
            return dal.GetBoroughList(strWhere);
        }

		#endregion  BasicMethod
	}
}

