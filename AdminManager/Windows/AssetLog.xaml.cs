using AdminManager.UserControls;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Xceed.Wpf.Toolkit;
using AdminManager.BLL;
using AdminManager.Component;

namespace AdminManager.Windows
{
    /// <summary>
    /// AssetLog.xaml 的交互逻辑
    /// </summary>
    public partial class AssetLog : Window
    {
        public AssetLog()
        {
            InitializeComponent();
        }

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
            bottom.Children.Clear();
            timeto.Format = DateTimeFormat.FullDateTime;
            timefrom.Format = DateTimeFormat.FullDateTime;
            timefrom.Text = "";
            timeto.Text = "";

            GetLogList(pagesize, 1, GetWhere(), order, out allcount);
            int allpage = 0 == allcount % pagesize ? allcount / pagesize : allcount / pagesize + 1;
            PageControl pagecontrol = new PageControl(1, allpage, pagecount, allcount);
            pagecontrol.MyEvent += demo_MyEvent;
            bottom.Children.Add(pagecontrol);

            DataTable dt = helper.GetEmployeeInfo(MainWindow.UserAccount).Tables[0];
            if (dt.Rows.Count > 0)
            {
                sb.SetSysLog(dt.Rows[0]["id"].ToString(), dt.Rows[0]["name"].ToString(), "查看用户财产记录", "查看", DateTime.Now);
            }
        }
        string GetWhere()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(" and tAsset.UserID='" + ID + "'");
            if (timefrom.Text != "")
            {
                sb.Append(" and logdate>='" + Convert.ToDateTime(timefrom.Text) + "'");
            }

            if (timeto.Text != "")
            {
                sb.Append(" and logdate<='" + Convert.ToDateTime(timeto.Text) + "'");
            }
            return sb.ToString();
        }


        int pagesize = 10;
        int pagecount = 10;
        int allcount = 0;
        SysLogBLL sb = new SysLogBLL();
        Helper helper = new Helper();
        string order = " order by logDate desc";
        AssetLogBLL al = new AssetLogBLL();
        public void GetLogList(int PageSize, int PageIndex, string strWhere, string orderStr, out int totalCount)
        {
            DataSet ds = al.GetListByPage(PageSize, PageIndex, strWhere, orderStr, out totalCount);
            if (ds == null||ds.Tables.Count==0)
            {
                System.Windows.MessageBox.Show("查无数据");
                DataGrid1.ItemsSource = null;
                return;
            }
            this.DataGrid1.ItemsSource = null;
            this.DataGrid1.ItemsSource = ds.Tables[0].DefaultView;

            UserInfoList ui = new UserInfoList(230, 310, ID);
            right.Children.Add(ui);
        }

        void demo_MyEvent(object sender, EventArgs e)
        {
            Dictionary<string, int> d = (Dictionary<string, int>)sender;
            int index = d["index"];
            int pagecount = d["pagecount"];

            GetLogList(pagesize, index == 0 ? 1 : index, GetWhere(), order, out allcount);
        }
        public AssetLog(int width,int height,string id)
        {
            InitializeComponent();
            this.Width = width;
            this.Height = height;
            this.ID = id;
        }
        public string ID
        {
            set;
            get;
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void DataGrid1_PreviewMouseDoubleClick_1(object sender, MouseButtonEventArgs e)
        {

        }

        UserBLL ub = new UserBLL();
        private void DataGrid1_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            DataRowView dr = (DataRowView)DataGrid1.SelectedItem;

            DataSet ds = ub.GetList(" and id='" + dr["用户ID"] + "'");

            if (ds != null || ds.Tables.Count > 0)
            {
                DataRow UserDr = ds.Tables[0].Rows[0];
                txt_Account.Text = UserDr["account"].ToString();
                txt_Email.Text = UserDr["email"].ToString();
                txt_Gender.Text = UserDr["gender"].ToString() == "0" ? "男" : "女";
                txt_NickName.Text = UserDr["nickname"].ToString();
                txt_QQ.Text = UserDr["qq"].ToString();
                txt_Tel.Text = UserDr["Mobile"].ToString();
            }
        }

        //private static AssetLog instance;
        //private static object _lock = new object();
        //public static AssetLog GetInstance() 
        //{ 
        //    if (instance == null) 
        //    { 
        //        lock (_lock) 
        //        { 
        //            if (instance == null)
        //            {
        //                instance = new AssetLog();
        //            }
        //        } 
        //    }
        //    return instance;
        //}
    }
}
