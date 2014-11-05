using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ManagerServer
{
    [ServiceContract]
    public interface IEmployee
    {
        #region Employee

        [OperationContract]
        DataSet Employee_GetList(int PageSize, int PageIndex, string strWhere, string orderStr, out int totalCount);

        [OperationContract]
        DataSet Employee_GetUserInfo(string account);

        [OperationContract]
        DataSet Employee_GetUserAuthorityList(int PageSize, int PageIndex, string strWhere, string orderStr, out int totalCount);

        [OperationContract]
        long Employee_Add(string sql, params StringSqlParam[] cmdParms);


        [OperationContract]
        bool Employee_Update(string sql, params StringSqlParam[] cmdParms);

        [OperationContract]
        bool Employee_Exists(string sql, params StringSqlParam[] cmdParms);


        [OperationContract]
        StringSqlParam getParams(string name, object value, string type);

        [OperationContract]
        DataSet Employee_GetModel(string sql, params StringSqlParam[] cmdParms);

        #endregion

        #region SystemParameter

        [OperationContract]
        DataSet SystemParameter_GetList();

        [OperationContract]
        bool SystemParameter_Update(string sql, params StringSqlParam[] cmdParms);

        [OperationContract]
        DataSet SystemParameter_GetListByWhere(string where);

        [OperationContract]
        DataSet SystemParameter_GetSmallList(string id);


        [OperationContract]
        DataSet SystemParameter_GetModel(string sql, params StringSqlParam[] cmdParms);
        #endregion


        #region SystemLog
        [OperationContract]
        int Login(string Account, string pwd);


        [OperationContract]
        DataSet GetSysLog(int PageSize, int PageIndex, string strWhere, string orderStr, out int totalCount);

        [OperationContract]
        int SetSysLog(string id,string name,string  content,string type,DateTime time);
        #endregion


        #region SingleArgument
        [OperationContract]
        int SetSingleArgument(string id,string staffid, string staffname, int type, string fieldname);

        [OperationContract]
        DataSet SingleArgument_GetListByPage(int PageSize, int PageIndex, string strWhere, string orderStr, out int totalCount);


        #endregion

        #region Withdrawal

        [OperationContract]
        bool Withdrawal_Update(string sql, params StringSqlParam[] cmdParms);

        [OperationContract]
        DataSet Withdrawal_GetListByPage(int PageSize, int PageIndex, string strWhere, string orderStr, out int totalCount);

        [OperationContract]
        DataSet Withdrawal_GetList(string where);

        [OperationContract]
        DataSet Withdrawal_GetModel(string sql, params StringSqlParam[] cmdParms);

        #endregion


        #region Product

        [OperationContract]
        long Product_Add(string sql, params StringSqlParam[] cmdParms);

        [OperationContract]
        bool Product_Update(string sql, params StringSqlParam[] cmdParms);

        [OperationContract]
        bool Product_Delete(long id);

        [OperationContract]
        bool Product_Exists(string sql, params StringSqlParam[] cmdParms);

        [OperationContract]
        DataSet Product_GetModel(string sql, params StringSqlParam[] cmdParms);

        [OperationContract]
        DataSet Product_GetListByPage(int PageSize, int PageIndex, string strWhere, string orderStr, out int totalCount);

        [OperationContract]
        DataSet Product_GetList(string where);
        
        #endregion

        #region Order


        [OperationContract]
        DataSet Order_GetList(string where);

        [OperationContract]
        DataSet Order_GetListInfo(string where);

        [OperationContract]
        bool Order_Exists(string sql, params StringSqlParam[] cmdParms);

        [OperationContract]
        long Order_Add(string sql, params StringSqlParam[] cmdParms);

        [OperationContract]
        bool Order_Delete(long id);


        [OperationContract]
        DataSet Order_GetListByPage(int PageSize, int PageIndex, string strWhere, string orderStr, out int totalCount);


        [OperationContract]
        DataSet Order_GetOrderInfo(int PageSize, int PageIndex, string strWhere, string orderStr, out int totalCount);

        [OperationContract]
        bool Order_Update(string sql, params StringSqlParam[] cmdParms);

        #endregion
        #region SpreadItem

        [OperationContract]
        bool SpreadItem_Exists(string sql, params StringSqlParam[] cmdParms);

        [OperationContract]
        long SpreadItem_Add(string sql, params StringSqlParam[] cmdParms);

        [OperationContract]
        bool SpreadItem_Delete(long id);

        [OperationContract]
        bool SpreadItem_DeleteList(string idlist);

        [OperationContract]
        DataSet SpreadItem_GetListByPage(int PageSize, int PageIndex, string strWhere, string orderStr, out int totalCount);


        [OperationContract]
        bool SpreadItem_Update(string sql, params StringSqlParam[] cmdParms);


        [OperationContract]
        DataSet SpreadItem_GetModel(string sql, params StringSqlParam[] cmdParms);
        #endregion

        #region SpreadLevelInfo


        [OperationContract]
        long SpreadLevelInfo_Add(string sql, params StringSqlParam[] cmdParms);

        [OperationContract]
        DataSet SpreadLevelInfo_GetListByPage(int PageSize, int PageIndex, string strWhere, string orderStr, out int totalCount);

        [OperationContract]
        bool SpreadLevelInfo_Update(string sql, params StringSqlParam[] cmdParms);

        [OperationContract]
        DataSet SpreadLevelInfo_GetModel(string sql, params StringSqlParam[] cmdParms);

        [OperationContract]
        DataSet SpreadLevelInfo_GetList(string strWhere);

        #endregion

        #region User

        [OperationContract]
        bool User_Delete(long id);

        [OperationContract]
        bool User_DeleteList(string idlist);

        [OperationContract]
        DataSet User_GetListByPage(int PageSize, int PageIndex, string strWhere, string orderStr, out int totalCount);


        [OperationContract]
        bool User_Update(string sql, params StringSqlParam[] cmdParms);

        [OperationContract]
        DataSet User_GetList(string strWhere);

        [OperationContract]
        DataSet User_GetModel(string sql, params StringSqlParam[] cmdParms);

        #endregion

        #region Logistic

        [OperationContract]
        bool Logistic_Delete(long id);

        [OperationContract]
        bool Logistic_DeleteList(string idlist);

        [OperationContract]
        DataSet Logistic_GetListByPage(int PageSize, int PageIndex, string strWhere, string orderStr, out int totalCount);

        [OperationContract]
        bool Logistic_Update(string sql, params StringSqlParam[] cmdParms);

        [OperationContract]
        DataSet Logistic_GetList(string strWhere);

        [OperationContract]
        DataSet Logistic_GetModel(string sql, params StringSqlParam[] cmdParms);

        [OperationContract]
        DataSet Logistic_GetProvinceList(string where);

        [OperationContract]
        DataSet Logistic_GetCityList(string where);

        [OperationContract]
        DataSet Logistic_GetBoroughList(string where);

        [OperationContract]
        long Logistic_Add(string sql, params StringSqlParam[] cmdParms);
        #endregion


        #region UserAuthenticate
        [OperationContract]
        bool UserAuthenticate_Delete(long id);

        [OperationContract]
        bool UserAuthenticate_DeleteList(string idlist);

        [OperationContract]
        DataSet UserAuthenticate_GetListByPage(int PageSize, int PageIndex, string strWhere, string orderStr, out int totalCount);

        [OperationContract]
        bool UserAuthenticate_Update(string sql, params StringSqlParam[] cmdParms);

        [OperationContract]
        DataSet UserAuthenticate_GetList(string strWhere);

        [OperationContract]
        DataSet UserAuthenticate_GetModel(string sql, params StringSqlParam[] cmdParms);

        #endregion
        #region Asset
        [OperationContract]
        DataSet Asset_GetListByPage(int PageSize, int PageIndex, string strWhere, string orderStr, out int totalCount);

        [OperationContract]
        bool Asset_Update(string sql, params StringSqlParam[] cmdParms);

        [OperationContract]
        DataSet Asset_GetList(string strWhere);

        [OperationContract]
        DataSet Asset_GetModel(string sql, params StringSqlParam[] cmdParms);
        #endregion

        #region AssetLog

        [OperationContract]
        bool AssetLog_Exists(string sql, params StringSqlParam[] cmdParms);

        [OperationContract]
        DataSet AssetLog_GetListByPage(int PageSize, int PageIndex, string strWhere, string orderStr, out int totalCount);

        [OperationContract]
        DataSet AssetLog_GetList(string strWhere);

        [OperationContract]
        DataSet AssetLog_GetModel(string sql, params StringSqlParam[] cmdParms);

        #endregion


        #region Task

        [OperationContract]
        bool Task_Update(string sql, params StringSqlParam[] cmdParms);

        [OperationContract]
        DataSet Task_GetListByPage(int PageSize, int PageIndex, string strWhere, string orderStr, out int totalCount);

        [OperationContract]
        DataSet Task_GetList(string strWhere);

        [OperationContract]
        DataSet Task_GetListByEmployee(string strWhere);


        [OperationContract]
        DataSet Task_GetModel(string sql, params StringSqlParam[] cmdParms);

        [OperationContract]
        long Task_Add(string sql, params StringSqlParam[] cmdParms);

        #endregion

        #region TaskLog

        [OperationContract]
        bool TaskLog_Update(string sql, params StringSqlParam[] cmdParms);

        [OperationContract]
        DataSet TaskLog_GetListByPage(int PageSize, int PageIndex, string strWhere, string orderStr, out int totalCount);

        [OperationContract]
        DataSet TaskLog_GetList(string strWhere);

        [OperationContract]
        DataSet TaskLog_GetModel(string sql, params StringSqlParam[] cmdParms);

        [OperationContract]
        long TaskLog_Add(string sql, params StringSqlParam[] cmdParms);


        #endregion
    }


    [DataContract]
    [KnownType(typeof(StringSqlParam))]
    public class StringSqlParam
    {
        string paramName = "";
        object paramValue = "";
        string datetype = "";

        public StringSqlParam(string name, object value, string type)
        {
            this.paramName = name;
            this.paramValue = value;
            this.datetype = type;
        }
        [DataMember]
        public string ParamName
        {
            get { return paramName; }
            set { paramName = value; }
        }

        [DataMember]
        public object ParamValue
        {
            get { return paramValue; }
            set { paramValue = value; }
        }

        [DataMember]
        public string DateType
        {
            get { return datetype; }
            set { datetype = value; }
        }
    }
}
