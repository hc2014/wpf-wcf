using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using AdminManager.WcfService;
namespace AdminManager.DAL
{
	/// <summary>
	/// 数据访问类:tProduct
	/// </summary>
	public partial class ProductDal
	{
        EmployeeClient sc = new EmployeeClient();
        public ProductDal()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(long ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from tProduct");
			strSql.Append(" where ID=@id");
            StringSqlParam[] parameters = new StringSqlParam[1];
            parameters[0] = sc.getParams("@ID", ID, "BigInt");


            return sc.Product_Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
        public long Add(AdminManager.Model.ProductModel model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tProduct(");
			strSql.Append("Name,Price,Describe,TYPE,Content,Remark,State,Exp)");
			strSql.Append(" values (");
			strSql.Append("@Name,@Price,@Describe,@TYPE,@Content,@Remark,@State,@Exp)");
			strSql.Append(";select @@IDENTITY");

            StringSqlParam[] parameters = new StringSqlParam[8];

            parameters[0] = sc.getParams("@Name", model.Name, "NVarChar");
            parameters[1] = sc.getParams("@Price", model.Price, "Money");
            parameters[2] = sc.getParams("@Describe", model.Describe, "NVarChar");
            parameters[3] = sc.getParams("@TYPE", model.TYPE, "TinyInt");
            parameters[4] = sc.getParams("@Content", model.Content, "NVarChar");
            parameters[5] = sc.getParams("@Remark", model.Remark, "NVarChar");
            parameters[6] = sc.getParams("@State", model.State, "TinyInt");
            parameters[7] = sc.getParams("@Exp", model.Exp, "Int");
            return sc.Product_Add(strSql.ToString(),parameters);
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
        public bool Update(AdminManager.Model.ProductModel model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tProduct set ");
			strSql.Append("Name=@Name,");
			strSql.Append("Price=@Price,");
			strSql.Append("Describe=@Describe,");
			strSql.Append("TYPE=@TYPE,");
			strSql.Append("Content=@Content,");
			strSql.Append("Remark=@Remark,");
			strSql.Append("State=@State,");
			strSql.Append("Exp=@Exp");
			strSql.Append(" where ID=@ID");

            StringSqlParam[] parameters = new StringSqlParam[9];

            parameters[0] = sc.getParams("@Name", model.Name, "NVarChar");
            parameters[1] = sc.getParams("@Price", model.Price, "Money");
            parameters[2] = sc.getParams("@Describe", model.Describe, "NVarChar");
            parameters[3] = sc.getParams("@TYPE", model.TYPE, "TinyInt");
            parameters[4] = sc.getParams("@Content", model.Content, "NVarChar");
            parameters[5] = sc.getParams("@Remark", model.Remark, "NVarChar");
            parameters[6] = sc.getParams("@State", model.State, "TinyInt");
            parameters[7] = sc.getParams("@Exp", model.Exp, "Int");
            parameters[8] = sc.getParams("@ID", model.ID, "BigInt");

            return sc.Product_Update(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(long ID)
		{
            return sc.Product_Delete(ID);
			
		}



		/// <summary>
		/// 得到一个对象实体
		/// </summary>
        public AdminManager.Model.ProductModel GetModel(long ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,Name,Price,Describe,TYPE,Content,Remark,State,Exp from tProduct ");
			strSql.Append(" where ID=@ID");

            StringSqlParam[] parameters = new StringSqlParam[1];
            parameters[0] = sc.getParams("@ID", ID, "BigInt");


			AdminManager.Model.ProductModel model=new AdminManager.Model.ProductModel();
			DataSet ds=sc.Product_GetModel(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
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
		public AdminManager.Model.ProductModel DataRowToModel(DataRow row)
		{
			AdminManager.Model.ProductModel model=new AdminManager.Model.ProductModel();
			if (row != null)
			{
				if(row["ID"]!=null && row["ID"].ToString()!="")
				{
					model.ID=long.Parse(row["ID"].ToString());
				}
				if(row["Name"]!=null)
				{
					model.Name=row["Name"].ToString();
				}
				if(row["Price"]!=null && row["Price"].ToString()!="")
				{
					model.Price=decimal.Parse(row["Price"].ToString());
				}
				if(row["Describe"]!=null)
				{
					model.Describe=row["Describe"].ToString();
				}
				if(row["TYPE"]!=null && row["TYPE"].ToString()!="")
				{
					model.TYPE=int.Parse(row["TYPE"].ToString());
				}
				if(row["Content"]!=null)
				{
					model.Content=row["Content"].ToString();
				}
				if(row["Remark"]!=null)
				{
					model.Remark=row["Remark"].ToString();
				}
				if(row["State"]!=null && row["State"].ToString()!="")
				{
					model.State=int.Parse(row["State"].ToString());
				}
				if(row["Exp"]!=null && row["Exp"].ToString()!="")
				{
					model.Exp=int.Parse(row["Exp"].ToString());
				}
			}
			return model;
		}


		/// <summary>
		/// 分页获取数据列表
		/// </summary>
        public DataSet GetListByPage(int PageSize, int PageIndex, string strWhere, string orderStr, out int totalCount)
		{
            return sc.Product_GetListByPage(PageSize, PageIndex, strWhere, orderStr, out totalCount);
		}

        public DataSet GetList(string where)
        {
            return sc.Product_GetList(where);
        }
		#endregion  BasicMethod
	}
}

