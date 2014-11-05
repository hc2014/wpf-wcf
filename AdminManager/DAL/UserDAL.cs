using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using AdminManager.WcfService;
namespace AdminManager.DAL
{
	/// <summary>
	/// 数据访问类:tUser
	/// </summary>
	public partial class UserDAL
	{
        public UserDAL()
		{}
		#region  BasicMethod
        EmployeeClient sc = new EmployeeClient();
		/// <summary>
		/// 更新一条数据
		/// </summary>
        public bool Update(AdminManager.Model.UserModel model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tUser set ");
			strSql.Append("ParentID=@ParentID,");
			strSql.Append("NickName=@NickName,");
			strSql.Append("Password=@Password,");
			strSql.Append("ParentPassword=@ParentPassword,");
			strSql.Append("QQ=@QQ,");
			strSql.Append("Gender=@Gender,");
			strSql.Append("Birthday=@Birthday,");
			strSql.Append("IsLunar=@IsLunar,");
			strSql.Append("Experience=@Experience,");
			strSql.Append("Integral=@Integral,");
			strSql.Append("BagSize=@BagSize,");
			strSql.Append("Head=@Head,");
			strSql.Append("Feel=@Feel,");
			strSql.Append("RememberPwdID=@RememberPwdID,");
			strSql.Append("IP=@IP,");
			strSql.Append("RegisterDate=@RegisterDate,");
			strSql.Append("Type=@Type,");
			strSql.Append("State=@State");
			strSql.Append(" where ID=@ID");
            StringSqlParam[] parameters = new StringSqlParam[23];
            parameters[0] = sc.getParams("@ParentID", model.ParentID, "BigInt");
            parameters[1] = sc.getParams("@NickName", model.NickName, "NVarChar");
            parameters[2] = sc.getParams("@Password", model.Password, "Char");
            parameters[3] = sc.getParams("@ParentPassword", model.ParentPassword, "Char");
            parameters[4] = sc.getParams("@QQ", model.QQ, "NVarChar");
            parameters[5] = sc.getParams("@Gender", model.Gender, "Bit");
            parameters[6] = sc.getParams("@Birthday", model.Birthday, "Date");
            parameters[7] = sc.getParams("@IsLunar", model.IsLunar, "Bit");
            parameters[8] = sc.getParams("@Experience", model.Experience, "Int");
            parameters[9] = sc.getParams("@Head", model.Head, "BigInt");
            parameters[10] = sc.getParams("@Feel", model.Feel, "NVarChar");
            parameters[11] = sc.getParams("@RememberPwdID", model.RememberPwdID, "UniqueIdentifier");
            parameters[12] = sc.getParams("@IP", model.IP, "VarChar");
            parameters[13] = sc.getParams("@RegisterDate", model.RegisterDate, "DateTime");
            parameters[14] = sc.getParams("@Type", model.Type, "TinyInt");
            parameters[15] = sc.getParams("@State", model.State, "TinyInt");
            parameters[16] = sc.getParams("@ID", model.ID, "BigInt");
            parameters[17] = sc.getParams("@Number", model.Number, "BigInt");
            parameters[18] = sc.getParams("@Account", model.Account, "NVarChar");
            parameters[19] = sc.getParams("@Email", model.Email, "NVarChar");
            parameters[20] = sc.getParams("@Mobile", model.Mobile, "NVarChar");
            parameters[21] = sc.getParams("@Integral", model.Integral, "Integral");
            parameters[22] = sc.getParams("@BagSize", model.BagSize, "Int");
            
            return sc.User_Update(strSql.ToString(), parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
        public bool Delete(long ID)
        {
            return sc.Order_Delete(ID);
        }
		/// <summary>
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tUser ");
            strSql.Append(" where ID in (" + IDlist + ")  ");
            return sc.SpreadItem_DeleteList(IDlist);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
        public AdminManager.Model.UserModel GetModel(long ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,ParentID,Number,Account,NickName,Password,ParentPassword,Email,Mobile,QQ,Gender,Birthday,IsLunar,Experience,Integral,BagSize,Head,Feel,RememberPwdID,IP,RegisterDate,Type,State from tUser ");
			strSql.Append(" where ID=@ID");
            StringSqlParam[] parameters = new StringSqlParam[1];

            parameters[0] = sc.getParams("@ID", ID, "BigInt");


            AdminManager.Model.OrderModel model = new AdminManager.Model.OrderModel();
            DataSet ds = sc.User_GetModel(strSql.ToString(), parameters);
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
        public AdminManager.Model.UserModel DataRowToModel(DataRow row)
		{
            AdminManager.Model.UserModel model = new AdminManager.Model.UserModel();
			if (row != null)
			{
				if(row["ID"]!=null && row["ID"].ToString()!="")
				{
					model.ID=long.Parse(row["ID"].ToString());
				}
				if(row["ParentID"]!=null && row["ParentID"].ToString()!="")
				{
					model.ParentID=long.Parse(row["ParentID"].ToString());
				}
				if(row["Number"]!=null && row["Number"].ToString()!="")
				{
					model.Number=long.Parse(row["Number"].ToString());
				}
				if(row["Account"]!=null)
				{
					model.Account=row["Account"].ToString();
				}
				if(row["NickName"]!=null)
				{
					model.NickName=row["NickName"].ToString();
				}
				if(row["Password"]!=null)
				{
					model.Password=row["Password"].ToString();
				}
				if(row["ParentPassword"]!=null)
				{
					model.ParentPassword=row["ParentPassword"].ToString();
				}
				if(row["Email"]!=null)
				{
					model.Email=row["Email"].ToString();
				}
				if(row["Mobile"]!=null)
				{
					model.Mobile=row["Mobile"].ToString();
				}
				if(row["QQ"]!=null)
				{
					model.QQ=row["QQ"].ToString();
				}
				if(row["Gender"]!=null && row["Gender"].ToString()!="")
				{
					if((row["Gender"].ToString()=="1")||(row["Gender"].ToString().ToLower()=="true"))
					{
						model.Gender=true;
					}
					else
					{
						model.Gender=false;
					}
				}
				if(row["Birthday"]!=null && row["Birthday"].ToString()!="")
				{
					model.Birthday=DateTime.Parse(row["Birthday"].ToString());
				}
				if(row["IsLunar"]!=null && row["IsLunar"].ToString()!="")
				{
					if((row["IsLunar"].ToString()=="1")||(row["IsLunar"].ToString().ToLower()=="true"))
					{
						model.IsLunar=true;
					}
					else
					{
						model.IsLunar=false;
					}
				}
				if(row["Experience"]!=null && row["Experience"].ToString()!="")
				{
					model.Experience=int.Parse(row["Experience"].ToString());
				}
				if(row["Integral"]!=null && row["Integral"].ToString()!="")
				{
					model.Integral=int.Parse(row["Integral"].ToString());
				}
				if(row["BagSize"]!=null && row["BagSize"].ToString()!="")
				{
					model.BagSize=int.Parse(row["BagSize"].ToString());
				}
				if(row["Head"]!=null && row["Head"].ToString()!="")
				{
					model.Head=long.Parse(row["Head"].ToString());
				}
				if(row["Feel"]!=null)
				{
					model.Feel=row["Feel"].ToString();
				}
				if(row["RememberPwdID"]!=null && row["RememberPwdID"].ToString()!="")
				{
					model.RememberPwdID= new Guid(row["RememberPwdID"].ToString());
				}
				if(row["IP"]!=null)
				{
					model.IP=row["IP"].ToString();
				}
				if(row["RegisterDate"]!=null && row["RegisterDate"].ToString()!="")
				{
					model.RegisterDate=DateTime.Parse(row["RegisterDate"].ToString());
				}
				if(row["Type"]!=null && row["Type"].ToString()!="")
				{
					model.Type=int.Parse(row["Type"].ToString());
				}
				if(row["State"]!=null && row["State"].ToString()!="")
				{
					model.State=int.Parse(row["State"].ToString());
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string where)
		{
            StringBuilder sb = new StringBuilder();
            sb.Append("select * from tuser where 1=1"+where);
            return sc.User_GetList(sb.ToString());
		}

		/// <summary>
		/// 分页获取数据列表
		/// </summary>
        public DataSet GetListByPage(int PageSize, int PageIndex, string strWhere, string orderStr, out int totalCount)
		{
            return sc.User_GetListByPage(PageSize, PageIndex, strWhere, orderStr, out totalCount);
		}

		#endregion  BasicMethod
	}
}

