using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using AdminManager.WcfService;
namespace AdminManager.DAL 
{
	/// <summary>
	/// 数据访问类:tAsset
	/// </summary>
	public partial class AssetDAL
	{
        public AssetDAL()
		{}
		#region  BasicMethod
        EmployeeClient sc = new EmployeeClient();

		/// <summary>
		/// 更新一条数据
		/// </summary>
        public bool Update(AdminManager.Model.AssetModel model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tAsset set ");
			strSql.Append("UserID=@UserID,");
			strSql.Append("Money=@Money,");
			strSql.Append("Gold=@Gold,");
			strSql.Append(" where ID=@ID");
            StringSqlParam[] parameters = new StringSqlParam[5];

            parameters[0] = sc.getParams("@UserID", model.UserID, "BigInt");
            parameters[1] = sc.getParams("@Money", model.Money, "Money");
            parameters[2] = sc.getParams("@Gold", model.Gold, "Money");
            parameters[3] = sc.getParams("@ID", model.ID, "BigInt");
            return sc.Asset_Update(strSql.ToString(), parameters);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
        public AdminManager.Model.AssetModel GetModel(long ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,UserID,Money,Gold from tAsset ");
			strSql.Append(" where ID=@ID");
            StringSqlParam[] parameters = new StringSqlParam[1];

            parameters[0] = sc.getParams("@ID", ID, "BigInt");


            AdminManager.Model.OrderModel model = new AdminManager.Model.OrderModel();
            DataSet ds = sc.Asset_GetModel(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
        public AdminManager.Model.AssetModel DataRowToModel(DataRow row)
		{
            AdminManager.Model.AssetModel model = new AdminManager.Model.AssetModel();
			if (row != null)
			{
				if(row["ID"]!=null && row["ID"].ToString()!="")
				{
					model.ID=long.Parse(row["ID"].ToString());
				}
				if(row["UserID"]!=null && row["UserID"].ToString()!="")
				{
					model.UserID=long.Parse(row["UserID"].ToString());
				}
				if(row["Money"]!=null && row["Money"].ToString()!="")
				{
					model.Money=decimal.Parse(row["Money"].ToString());
				}
				if(row["Gold"]!=null && row["Gold"].ToString()!="")
				{
					model.Gold=decimal.Parse(row["Gold"].ToString());
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
        public DataSet GetList(string strWhere)
        {
            DataSet ds = sc.Asset_GetList(strWhere);
            return ds;
        }

		/// <summary>
		/// 分页获取数据列表
		/// </summary>
        public DataSet GetListByPage(int PageSize, int PageIndex, string strWhere, string orderStr, out int totalCount)
        {
            DataSet ds = sc.Asset_GetListByPage(PageSize, PageIndex, strWhere, orderStr, out totalCount);
            return ds;
        }

		#endregion  BasicMethod
	}
}

