using AdminManager.BLL;
using AdminManager.Component;
using AdminManager.Windows;
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

namespace AdminManager.UserControls
{
    /// <summary>
    /// UserInfo.xaml 的交互逻辑
    /// </summary>
    public partial class UserInfo : UserControl
    {
        public UserInfo()
        {
            InitializeComponent();
        }
        public UserInfo(int width, int height)
        {
            
            InitializeComponent();
            this.Width = width;
            this.Height = height;
          
        }
        int pagesize = 10;
        int pagecount = 10;
        int allcount = 0;
        private void UserControl_Loaded_1(object sender, RoutedEventArgs e)
        {
            bottom.Children.Clear();
            GetLogList(pagesize, 1, GetWhere(), order, out allcount);

            int allpage = 0 == allcount % pagesize ? allcount / pagesize : allcount / pagesize + 1;
            PageControl pagecontrol = new PageControl(1, allpage, pagecount, allcount);
            pagecontrol.MyEvent += demo_MyEvent;
            bottom.Children.Add(pagecontrol);

            DataTable dt = helper.GetEmployeeInfo(MainWindow.UserAccount).Tables[0];
            if (dt.Rows.Count > 0)
            {
                sb.SetSysLog(dt.Rows[0]["id"].ToString(), dt.Rows[0]["name"].ToString(), "查看用户信息详情", "查看", DateTime.Now);
            }
        }
        UserBLL ob = new UserBLL();
        SysLogBLL sb = new SysLogBLL();
        string order = "order by RegisterDate desc";
        public void GetLogList(int PageSize, int PageIndex, string strWhere, string orderStr, out int totalCount)
        {
            DataSet ds = ob.GetListByPage(PageSize, PageIndex, strWhere, orderStr, out totalCount);
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
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            GetLogList(pagesize, 1, GetWhere(), order, out allcount);
        }

        string GetWhere()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(" where 1=1 ");
            if (txtname.Text.Trim() != "")
            {
                sb.Append(" and NickName like '%" + txtname.Text.Trim() + "%'");
            }
            if (txt_Num.Text.Trim() != "")
            {
                sb.Append(" and Number like '%" + txt_Num.Text.Trim() + "%'");
            }

            DateTime time = DateTime.Now;
            if (timefrom.Text!="")
            {
                DateTime.TryParse(timefrom.Text, out time);
                sb.Append(" and RegieterDate>='"+time+"'");
            }
            if (timeto.Text != "")
            { 
                DateTime.TryParse(timeto.Text, out time);
                sb.Append(" and RegieterDate<='"+time+"'");
            }
            return sb.ToString();
        }
        void demo_MyEvent(object sender, EventArgs e)
        {
            Dictionary<string, int> d = (Dictionary<string, int>)sender;
            int index = d["index"];
            int pagecount = d["pagecount"];

            GetLogList(pagesize, index == 0 ? 1 : index, GetWhere(), order, out allcount);
        }

        private void btn_Click_1(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            string id = btn.Tag.ToString();
            RegisterEmployee re = new RegisterEmployee(id, 380,160);
            re.ShowDialog();
        }

        AssetLogBLL alb = new AssetLogBLL();
        private void DataGrid1_PreviewMouseDoubleClick_1(object sender, MouseButtonEventArgs e)
        {
            DataRowView dr = (DataRowView)DataGrid1.SelectedItem;
            bool result=alb.Exists(Convert.ToInt64(dr["id"]));
            if (result)
            {
                AssetLog al = new AssetLog(800, 500, dr["id"].ToString());
                al.ShowDialog();
            }
            else
            {
                MessageBox.Show("该用户没有财产信息");
            }
        }

        AssetBLL ab = new AssetBLL();
        private void DataGrid1_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            DataRowView drv = (DataRowView)DataGrid1.SelectedItem;
            if (drv == null)
            {
                return;
            }
            DataSet ds=ab.GetList(" and userid='"+drv["id"]+"'");
            if (ds != null && ds.Tables.Count > 0)
            {
                DataRow AssetDr = ds.Tables[0].Rows[0];
                txt_Money.Text = AssetDr["money"].ToString();
                txt_Gold.Text = AssetDr["gold"].ToString();
            }
        }

    }
    public class DataConverter_UserType : IValueConverter
    {
        enum EnumValues
        {
            用户 = 0,
            员工 = 1,
            管理员 = 2
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

    public class DataConverter_UserState : IValueConverter
    {
        enum EnumValues
        {
            禁用 = 0,
            正常 = 1,
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
