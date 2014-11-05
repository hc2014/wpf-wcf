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
using AdminManager.UserControls;
using AdminManager.BLL;
using System.Collections;
using System.Data;
using AdminManager.Component;
namespace AdminManager.Windows
{
    /// <summary>
    /// EmployeeAuth.xaml 的交互逻辑
    /// </summary>
    public partial class EmployeeAuth : Window
    {
        public EmployeeAuth()
        {
            InitializeComponent();
        }
        public EmployeeAuth(int width,int height)
        {
            InitializeComponent();
            this.Width = width;
            this.Height = height;
        }
        SystemParameterBLL spbll = new SystemParameterBLL();
        UserBLL ub = new UserBLL();
        ArrayList al = new ArrayList();
        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
            Authority_List al = new Authority_List(400, 300);
            al.UpdateEvent += ap_UpdateEvent;
            firstDrid.Children.Add(al);
            Authority_Plate ap = new Authority_Plate();
            ap.UpdateEvent += ap_UpdateEvent;
            secondDrid.Children.Add(ap);
            
        }

        void ap_UpdateEvent(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
