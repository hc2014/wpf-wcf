using System;
using System.Collections.Generic;
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
using AdminManager.BLL;
using System.Data;
using AdminManager.Component;
namespace AdminManager.UserControls
{
    /// <summary>
    /// SysLogInfo.xaml 的交互逻辑
    /// </summary>
    public partial class SysLogInfo : UserControl
    {
        SysLogBLL sysbll = new SysLogBLL();
        public SysLogInfo()
        {
            InitializeComponent();
            
        }

        public SysLogInfo(int width,int height)
        {
            
            InitializeComponent();
            this.Width = width;
            this.Height = height;
           
        }
        int pagesize = 10;
        int pagecount = 10;
        int allcount = 0;


        SysLogBLL sb = new SysLogBLL();
        Helper helper = new Helper();
        private void UserControl_Loaded_1(object sender, RoutedEventArgs e)
        {
            bottom.Children.Clear();
            GetLogList(pagesize, 1, GetWhere(), "order by operateTime desc", out allcount);

            AddPage();

            DataTable dt = helper.GetEmployeeInfo(MainWindow.UserAccount).Tables[0];
            if (dt.Rows.Count > 0)
            {
                sb.SetSysLog(dt.Rows[0]["id"].ToString(), dt.Rows[0]["name"].ToString(), "查看系统日志", "查看", DateTime.Now);
            }
        }

        public void AddPage()
        {
            bottom.Children.Clear();
            int allpage = 0 == allcount % pagesize ? allcount / pagesize : allcount / pagesize + 1;
            PageControl pagecontrol = new PageControl(1, allpage, pagecount, allcount);
            pagecontrol.MyEvent += demo_MyEvent;
            bottom.Children.Add(pagecontrol);
        }
        string GetWhere()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(" where 1=1 ");
            if (txtname.Text.Trim() != "")
            {
                sb.Append(" and staffname='"+txtname.Text.Trim()+"'");
            }
            if (combox.SelectedIndex > 0)
            {
                sb.Append(" and type='"+combox.Text+"'");
            }
            return sb.ToString();
        }
        void demo_MyEvent(object sender, EventArgs e)
        {
            Dictionary<string, int> d = (Dictionary<string, int>)sender;
            int index = d["index"];
            int pagecount = d["pagecount"];

            GetLogList(pagesize, index==0?1:index, GetWhere(), " order by operateTime desc", out allcount);
        }

        public void GetLogList(int PageSize, int PageIndex, string strWhere, string orderStr, out int totalCount)
        {
            DataSet ds=sysbll.GetSysLog(PageSize, PageIndex, strWhere, orderStr, out totalCount);
            if(ds==null||ds.Tables.Count==0)
            {
                MessageBox.Show("查无数据");
                DataGrid1.ItemsSource = null;
                return;
            }
            
           this.DataGrid1.ItemsSource = ds.Tables[0].DefaultView;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
              GetLogList(pagesize, 1, GetWhere(), "order by operateTime", out allcount);
              AddPage();
        }
    }
}
