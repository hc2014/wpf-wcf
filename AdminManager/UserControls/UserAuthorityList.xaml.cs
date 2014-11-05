using AdminManager.BLL;
using AdminManager.Component;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using AdminManager.Windows;

namespace AdminManager.UserControls
{
    /// <summary>
    /// UserAuthorityList.xaml 的交互逻辑
    /// </summary>
    public partial class UserAuthorityList : UserControl
    {
        public UserAuthorityList()
        {
            InitializeComponent();
        }
        public UserAuthorityList(int width,int height)
        {
            InitializeComponent();
            this.Width = width;
            this.Height = height;
        }

        int pagesize = 10;
        int pagecount = 10;
        int allcount = 0;
        EmployeeBLL eb = new EmployeeBLL();
        SysLogBLL sb = new SysLogBLL();
        string order = "order by RegisterDate desc";
        private void UserControl_Loaded_1(object sender, RoutedEventArgs e)
        {
            bottom.Children.Clear();

            GetLogList(pagesize, 1,"",order, out allcount);
            int allpage = 0 == allcount % pagesize ? allcount / pagesize : allcount / pagesize + 1;
            PageControl pagecontrol = new PageControl(1, allpage, pagecount, allcount);
            pagecontrol.MyEvent += demo_MyEvent;
            bottom.Children.Add(pagecontrol);

            DataTable dt = helper.GetEmployeeInfo(MainWindow.UserAccount).Tables[0];
            if (dt.Rows.Count > 0)
            {
                sb.SetSysLog(dt.Rows[0]["id"].ToString(), dt.Rows[0]["name"].ToString(), "查看权限列表", "查看", DateTime.Now);
            }
        }

        public void GetLogList(int PageSize, int PageIndex, string strWhere, string orderStr, out int totalCount)
        {
            DataSet ds = eb.GetUserAuthorityList(PageSize, PageIndex, strWhere, orderStr, out totalCount);
            if (ds == null)
            {
                MessageBox.Show("查无数据");
                DataGrid1.ItemsSource = null;
                return;
            }
            this.DataGrid1.ItemsSource = null;
            this.DataGrid1.ItemsSource = ds.Tables[0].DefaultView;
        }
        Helper helper = new Helper();

        void demo_MyEvent(object sender, EventArgs e)
        {
            Dictionary<string, int> d = (Dictionary<string, int>)sender;
            int index = d["index"];
            int pagecount = d["pagecount"];

            GetLogList(pagesize, index == 0 ? 1 : index,"", order, out allcount);
        }

        private void DataGrid1_PreviewMouseDoubleClick_1(object sender, MouseButtonEventArgs e)
        {
            EmployeeAuth ea = new EmployeeAuth(600,400);
            
            ea.ShowDialog();
        }
    }
    public class DataConverter_Authority : IValueConverter
    {
        enum EnumValues
        {
            普通员工 = 0,
            管理员 = 1,
            超级管理员 = 8
        }
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Type t = typeof(EnumValues);

            return Enum.GetName(t, value);
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
