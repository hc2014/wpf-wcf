using AdminManager.BLL;
using AdminManager.Component;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Xceed.Wpf.Toolkit;

namespace AdminManager.UserControls
{
    /// <summary>
    /// TaskAllxaml.xaml 的交互逻辑
    /// </summary>
    public partial class TaskAll : UserControl
    {
        public TaskAll()
        {
            InitializeComponent();
        }


        public TaskAll(int width, int height)
        {
            InitializeComponent();
            this.Width = width;
            this.Height = height;
        }


        int pagesize = 10;
        int pagecount = 10;
        int allcount = 0;
        int First = 0;
        private void UserControl_Loaded_1(object sender, RoutedEventArgs e)
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
                sb.SetSysLog(dt.Rows[0]["id"].ToString(), dt.Rows[0]["name"].ToString(), "查看所有任务", "查看", DateTime.Now);
            }
        }
        SysLogBLL sb = new SysLogBLL();
        TaskBLL tb = new TaskBLL();
        string order = " order by [State] desc ";

        public void GetLogList(int PageSize, int PageIndex, string strWhere, string orderStr, out int totalCount)
        {

            First++;
            DataSet ds = new DataSet();
            totalCount = 0;
            try
            {
                ds = tb.GetListByPage(PageSize, PageIndex, strWhere, orderStr, out totalCount);
            }
            catch (Exception ep)
            {

                System.Windows.MessageBox.Show(ep.Message);
                return;
            }
            if (ds == null || ds.Tables.Count == 0)
            {
                System.Windows.MessageBox.Show("查无数据");
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


        SystemParameterBLL spb = new SystemParameterBLL();
        string GetWhere()
        {
            StringBuilder sb = new StringBuilder();
            //sb.Append(" and ISNULL(employeeid,0) in (" + MainWindow.ID + ",0)");

            if (combox.SelectedIndex > 0)
            {
                ListBoxItem cb = (ListBoxItem)combox.SelectedValue;

                //sb.Append(" and o.type='" + cb.Tag.ToString() + "'");
            }
            if (txt_ID.Text != "")
            {
                sb.Append(" and tEmployee.ID='" + txt_ID.Text + "");
            }
            if (txt_Name.Text != "")
            {
                sb.Append(" and tEmployee.Name like '%" + txt_Name.Text + "%'");
            }
            if (txt_Num.Text != "")
            {
                long Num = 0;
                long.TryParse(txt_Num.Text, out Num);
                sb.Append(" and ID ='" + Num + "'");
            }
            if (timefrom.Text != "" || timeto.Text != "")
            {
                if (timefrom.Text != "")
                {
                    sb.Append(" and CompleteDate>='" + Convert.ToDateTime(timefrom.Text) + "'");
                }
                if (timeto.Text != "")
                {
                    sb.Append(" and CompleteDate<='" + Convert.ToDateTime(timeto.Text) + "'");
                }
            }
            else
            {
                //启动了工作月
                DataTable dt = spb.GetList(" and type=2").Tables[0];
                if (dt.Rows[0]["state"].ToString() == "0")
                {
                    Dictionary<string, DateTime> dic = helper.GetDateTime();
                    DateTime from = dic[helper.WorkMonthFrom];
                    DateTime to = dic[helper.WorkMonthTo];
                    sb.Append(" and CompleteDate>='" + from + "' and CompleteDate<= '" + to + "'");
                }
            }
            return sb.ToString();
        }
        void demo_MyEvent(object sender, EventArgs e)
        {
            Dictionary<string, int> d = (Dictionary<string, int>)sender;
            int index = d["index"];
            int pagecount = d["pagecount"];
            if (First <= 1)
            {
                return;
            }
            GetLogList(pagesize, index == 0 ? 1 : index, GetWhere(), order, out allcount);
        }


        private void DataGrid1_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            DataRowView dr = (DataRowView)DataGrid1.SelectedItem;

        }

        private void DataGrid1_PreviewMouseDoubleClick_1(object sender, MouseButtonEventArgs e)
        {
            DataRowView dr = (DataRowView)DataGrid1.SelectedItem;

        }

        void order_UpdateEvent(object sender, EventArgs e)
        {
            GetLogList(pagesize, 1, GetWhere(), order, out allcount);
        }

        private void Print_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Button bt = (Button)sender;
            Dictionary<string, string> dic = (Dictionary<string, string>)bt.Tag;

            if (dic.ContainsKey("EmployeeID"))
            {

            }
        }
    }
}
