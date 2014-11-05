using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using AdminManager.WcfService;
namespace AdminManager.DAL
{
	/// <summary>
	/// 数据访问类:tAssetLog
	/// </summary>
	public partial class AssetLogDal
	{
		public AssetLogDal()
		{}
		#region  BasicMethod

        EmployeeClient sc = new EmployeeClient();


		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
            DataSet ds = sc.AssetLog_GetList(strWhere);
            return ds;
		}

        //检查用户是否存在财产记录
        public bool Exists(long ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(0) from tAsset a,tAssetLog al,tUser u where   al.AssetID=a.ID and  u.ID=a.UserID and UserID=@UserID");

            StringSqlParam strpam = new StringSqlParam();
            strpam.ParamName = "@UserID";
            strpam.ParamValue = ID.ToString();
            strpam.DateType = "NVarChar";

            StringSqlParam[] pams = new StringSqlParam[1] { strpam };
            return sc.AssetLog_Exists(strSql.ToString(), pams);
        }

		/// <summary>
		/// 分页获取数据列表
		/// </summary>
        public DataSet GetListByPage(int PageSize, int PageIndex, string strWhere, string orderStr, out int totalCount)
        {
            DataSet ds = sc.AssetLog_GetListByPage(PageSize, PageIndex, strWhere, orderStr, out totalCount);
            return ds;
        }

		#endregion  BasicMethod
	}
}

