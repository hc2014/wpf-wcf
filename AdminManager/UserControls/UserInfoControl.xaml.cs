using AdminManager.BLL;
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

namespace AdminManager.UserControls
{
    /// <summary>
    /// UserControl.xaml 的交互逻辑
    /// </summary>
    public partial class UserInfoControl : UserControl
    {
        public UserInfoControl()
        {
            InitializeComponent();
        }
        public UserInfoControl(string id)
        {
            InitializeComponent();
            this.ID = id;
        }

        public string ID
        {
            get;
            set;
        }

        SystemParameterBLL spbll = new SystemParameterBLL();
        private void UserControl_Loaded_1(object sender, RoutedEventArgs e)
        {
            DataTable dt = spbll.GetSmallList(ID).Tables[0];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                TabItem tab = new TabItem();
                tab.Header = dt.Rows[i]["name"].ToString();
                if (i == 0)
                {
                    UserInfo sinfo = new UserInfo(850, 700);
                    
                    tab.Content = sinfo;

                }
                OrderControl_TabControl.Items.Add(tab);

            }
            OrderControl_TabControl.SelectedIndex = 0;
        }
    }
}
