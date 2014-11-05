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

namespace AdminManager.UserControls
{
    /// <summary>
    /// SystemLogControl.xaml 的交互逻辑
    /// </summary>
    public partial class SystemLogControl : UserControl
    {
        SystemParameterBLL spbll = new SystemParameterBLL();
        public SystemLogControl()
        {
            InitializeComponent();
        }

        public SystemLogControl(string id)
        {
            InitializeComponent();
            this.ID = id;
        }

        public string ID
        {
            get;
            set;
        }
        private void UserControl_Loaded_1(object sender, RoutedEventArgs e)
        {
            DataTable dt=spbll.GetSmallList(ID).Tables[0];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                TabItem tab = new TabItem();
                tab.Header = dt.Rows[i]["name"].ToString();
                if (i == 0)
                {
                    SysLogInfo sinfo = new SysLogInfo();
                    tab.Content = sinfo;
                    
                }
                tab.GotFocus += tab_GotFocus;
                SystemLogControl_TabControl.Items.Add(tab);
                
            }
            SystemLogControl_TabControl.SelectedIndex = 0;
        }

        void tab_GotFocus(object sender, RoutedEventArgs e)
        {
            //TabItem tab = (TabItem)sender;
            //SysLogInfo sinfo = new SysLogInfo();
            //tab.Content = sinfo;

        }
    }
}
