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
using System.Windows.Shapes;
using AdminManager.BLL;
using System.Data;
using AdminManager.Component;
using AdminManager.UserControls;
using AdminManager.Report;
namespace AdminManager.Windows
{
    /// <summary>
    /// Index.xaml 的交互逻辑
    /// </summary>
    public partial class Index : Window
    {
        public Index()
        {
            InitializeComponent();
        }

        SingleArgumentBLL sab = new SingleArgumentBLL();
        SystemParameterBLL spbll = new SystemParameterBLL();
        private void Window_Loaded_1(object sender, RoutedEventArgs e) 
        {
           int output = 0;
           DataTable userAuth = sab.GetListByPage(10, 1, " and staffid='" + MainWindow.ID + "'", " order by id ", out output).Tables[0];
           string fieldname = userAuth.Rows[0]["fieldname"].ToString();
           DataTable dt=spbll.GetList(" order by [order] ").Tables[0];
           for (int i = 0; i < dt.Rows.Count; i++)
           {
               if (fieldname.IndexOf(dt.Rows[i]["id"].ToString())!=-1)
               {
                   Button b = new Button();
                   b.Content = dt.Rows[i]["name"].ToString();
                   b.Width = 100;
                   b.Name = "Button_" + dt.Rows[i]["id"].ToString();
                   b.Click += b_Click;
                   Menu.Children.Add(b);
               }
           }
           TaskPool tp = new TaskPool(850, 600);
           ContentWindow.Children.Add(tp);
        }

        void b_Click(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;
            ContentWindow.Children.Clear();
            if (b.Content.ToString().TrimEnd() =="日志板块")
            {
                int i = b.Name.IndexOf("_");
                string id=b.Name.Substring(i+1,b.Name.Length-i-1);
                SystemLogControl syslog = new SystemLogControl(id);
                ContentWindow.Children.Add(syslog);
            }
            if (b.Content.ToString().TrimEnd() == "权限设置")
            {
                int i = b.Name.IndexOf("_");
                string id = b.Name.Substring(i + 1, b.Name.Length - i - 1);
                SysAuthority syslog = new SysAuthority(id);
                ContentWindow.Children.Add(syslog);
            }
            if (b.Content.ToString().TrimEnd() == "订单查询")
            {
                int i = b.Name.IndexOf("_");
                string id = b.Name.Substring(i + 1, b.Name.Length - i - 1);
                OrderControl order = new OrderControl(id);
                ContentWindow.Children.Add(order);
            }

            if (b.Content.ToString().TrimEnd() == "代理管理")
            {
                int i = b.Name.IndexOf("_");
                string id = b.Name.Substring(i + 1, b.Name.Length - i - 1);
                SpreadControl spr = new SpreadControl(id);
                ContentWindow.Children.Add(spr);
            }
            if (b.Content.ToString().TrimEnd() == "客户管理")
            {
                int i = b.Name.IndexOf("_");
                string id = b.Name.Substring(i + 1, b.Name.Length - i - 1);
                UserInfoControl spr = new UserInfoControl(id);
                ContentWindow.Children.Add(spr);
            }
            if (b.Content.ToString().TrimEnd() == "报表分析")
            {
                int i = b.Name.IndexOf("_");
                string id = b.Name.Substring(i + 1, b.Name.Length - i - 1);
                ReportControl spr = new ReportControl(id);
                ContentWindow.Children.Add(spr);
            }
            if (b.Content.ToString().TrimEnd() == "我的任务")
            {
                int i = b.Name.IndexOf("_");
                string id = b.Name.Substring(i + 1, b.Name.Length - i - 1);
                TaskControl spr = new TaskControl(id);
                ContentWindow.Children.Add(spr);
            }
        }
    }
} 
