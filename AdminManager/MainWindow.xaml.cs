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
using AdminManager.Windows;
using AdminManager.Component;
using System.Data;
using AdminManager.Model;
namespace AdminManager
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        EmployeeBLL embll = new EmployeeBLL();
        SysLogBLL sb = new SysLogBLL();
        Helper helper = new Helper();

        public static string UserAccount;
        public static long ID;
        public static long EmployeeID;
        public static string EmployeeName;
        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            //查询user表 看是否存在信息
            int i = embll.Login(LoginText.Text, PwdText.Password);
            
           DataTable dt=new DataTable();
            if (i <= 0)
            {
                MessageBox.Show("登录失败!");
                return;
            }

            else
            {
                //检查员工表里面是否有该账户的信息
                bool exist = embll.ExistsByUser(LoginText.Text);
                if (exist)
                {
                     dt= helper.GetEmployeeInfo(LoginText.Text).Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        sb.SetSysLog(dt.Rows[0]["id"].ToString(), dt.Rows[0]["name"].ToString(), exist ? "登录成功" : "登录失败", "登录", DateTime.Now);
                    }
                }
                 //没有信息则创建该账户的信息
                else {
                    //初始化员工基本信息
                    EmployeeModel em = new EmployeeModel();
                    em.UserID = (long)dt.Rows[0]["id"];
                    //默认  可修改
                    em.Name = "61aoe";
                    em.IDCard = "420203198903143315";
                    em.Telephone = "13476110314";
                    em.Mobile = "13476110314";
                    em.Salary = 100;

                  long result=embll.Add(em);
                  //写入 创建员工信息的日志
                    sb.SetSysLog(dt.Rows[0]["id"].ToString(), dt.Rows[0]["name"].ToString(),result>=1? "第一次登陆创建员工信息成功":"第一次登陆创建员工信息失败", "登录", DateTime.Now);
                    //创建成功
                  if (result <= 1)
                  {
                      MessageBox.Show("创建员工信息失败!");
                      return;
                  }
                }
            }
            
            //登录成功
            UserAccount = LoginText.Text;
            ID = Convert.ToInt64(dt.Rows[0]["UserID"].ToString());
            EmployeeID = Convert.ToInt64(dt.Rows[0]["ID"].ToString());
            EmployeeName = dt.Rows[0]["Name"].ToString();
            Index indexwindow = new Index();
            this.Close();
            indexwindow.Show();
        }

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
            LoginText.Focus();
            //Dictionary<string, DateTime> dic = helper.GetDateTime();
        }
    }
}
