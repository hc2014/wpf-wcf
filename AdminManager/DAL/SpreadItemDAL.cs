using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using AdminManager.WcfService;
namespace AdminManager.DAL
{
	/// <summary>
	/// 数据访问类:tSpreadItem
	/// </summary>
    public partial class SpreadItemDAL
	{
		public SpreadItemDAL()
		{}
		#region  BasicMethod


        EmployeeClient sc = new EmployeeClient();
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(long ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from tSpreadItem");
			strSql.Append(" where ID=@ID");
            StringSqlParam strpam = new StringSqlParam();
            strpam.ParamName = "@ID";
            strpam.ParamValue = ID.ToString();
            strpam.DateType = "BigInt";

            StringSqlParam[] pams = new StringSqlParam[1] { strpam };
            return sc.SpreadItem_Exists(strSql.ToString(), pams);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
        public long Add(AdminManager.Model.SpreadItemModel model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tSpreadItem(");
            strSql.Append("SpreadItemID,ParentLevel,Name,ParentQuantity,Enable,ProductID)");
			strSql.Append(" values (");
            strSql.Append("@SpreadItemID,@ParentLevel,@Name,@ParentQuantity,@Enable,@ProductID)");
			strSql.Append(";select @@IDENTITY");

            StringSqlParam[] parameters = new StringSqlParam[6];

            parameters[0] = sc.getParams("@SpreadItemID", model.SpreadItemID, "BigInt");
            parameters[1] = sc.getParams("@ParentLevel", model.ParentLevel, "Int");
            parameters[2] = sc.getParams("@Name", model.Name, "NVarChar");
            parameters[3] = sc.getParams("@ParentQuantity", model.ParentQuantity, "Int");
            parameters[4] = sc.getParams("@Enable", model.Enable, "Bit");
            parameters[5] = sc.getParams("@ProductID", model.ProductID, "BigInt");

            object obj = sc.SpreadItem_Add(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt64(obj);
            }
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
        public bool Update(AdminManager.Model.SpreadItemModel model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tSpreadItem set ");
			strSql.Append("SpreadItemID=@SpreadItemID,");
            strSql.Append("ProductID=@ProductID,");
            strSql.Append("ParentLevel=@ParentLevel,");
			strSql.Append("Name=@Name,");
			strSql.Append("ParentQuantity=@ParentQuantity,");
			strSql.Append("Enable=@Enable");
			strSql.Append(" where ID=@ID");

            StringSqlParam[] parameters = new StringSqlParam[7];

            parameters[0] = sc.getParams("@SpreadItemID", model.SpreadItemID, "BigInt");
            parameters[1] = sc.getParams("@ParentLevel", model.ParentLevel, "Int");
            parameters[2] = sc.getParams("@Name", model.Name, "NVarChar");
            parameters[3] = sc.getParams("@ParentQuantity", model.ParentQuantity, "Int");
            parameters[4] = sc.getParams("@Enable", model.Enable, "Bit");
            parameters[5] = sc.getParams("@ProductID", model.ProductID, "BigInt");
            parameters[6] = sc.getParams("@ID", model.ID, "BigInt");
            return sc.SpreadItem_Update(strSql.ToString(), parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
        public bool Delete(long ID)
        {
            return sc.SpreadItem_Delete(ID);
        }

        /// <summary>
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string IDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tSpreadItem ");
            strSql.Append(" where ID in (" + IDlist + ")  ");
            return sc.SpreadItem_DeleteList(IDlist);
        }

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
        public AdminManager.Model.SpreadItemModel GetModel(long ID)
		{
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,SpreadItemID,ProductID,ParentLevel,Name,ParentQuantity,Enable from tSpreadItem ");
            strSql.Append(" where ID=@ID");


            StringSqlParam[] parameters = new StringSqlParam[1];

            parameters[0] = sc.getParams("@ID", ID, "BigInt");


            AdminManager.Model.OrderModel model = new AdminManager.Model.OrderModel();
            DataSet ds = sc.SpreadItem_GetModel(strSql.ToString(), parameters);
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
        public AdminManager.Model.SpreadItemModel DataRowToModel(DataRow row)
		{
            AdminManager.Model.SpreadItemModel model = new AdminManager.Model.SpreadItemModel();
			if (row != null)
			{
				if(row["ID"]!=null && row["ID"].ToString()!="")
				{
					model.ID=long.Parse(row["ID"].ToString());
				}
                if (row["ParentLevel"] != null && row["ParentLevel"].ToString() != "")
				{
                    model.ParentLevel = int.Parse(row["ParentLevel"].ToString());
				}
				if(row["SpreadItemID"]!=null && row["SpreadItemID"].ToString()!="")
				{
					model.SpreadItemID=long.Parse(row["SpreadItemID"].ToString());
				}
                if (row["ProductID"] != null && row["ProductID"].ToString() != "")
                {
                    model.ProductID = long.Parse(row["ProductID"].ToString());
                }
				if(row["Name"]!=null)
				{
					model.Name=row["Name"].ToString();
				}
				if(row["ParentQuantity"]!=null && row["ParentQuantity"].ToString()!="")
				{
					model.ParentQuantity=int.Parse(row["ParentQuantity"].ToString());
				}
				if(row["Enable"]!=null && row["Enable"].ToString()!="")
				{
					if((row["Enable"].ToString()=="1")||(row["Enable"].ToString().ToLower()=="true"))
					{
						model.Enable=true;
					}
					else
					{
						model.Enable=false;
					}
				}
			}
			return model;
		}

		/// <summary>
		/// 分页获取数据列表
		/// </summary>
        public DataSet GetListByPage(int PageSize, int PageIndex, string strWhere, string orderStr, out int totalCount)
		{
            DataSet ds = sc.SpreadItem_GetListByPage(PageSize, PageIndex, strWhere, orderStr, out totalCount);
            return ds;
		}

		#endregion  BasicMethod
	}
}

