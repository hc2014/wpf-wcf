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
    /// SpreadControl.xaml 的交互逻辑
    /// </summary>
    public partial class SpreadControl : UserControl
    {
        public SpreadControl()
        {
            InitializeComponent();
        }

        public SpreadControl(string id)
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
             DataTable dt=spbll.GetSmallList(ID).Tables[0];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                TabItem tab = new TabItem();
                tab.Header = dt.Rows[i]["name"].ToString();
                if (i == 0)
                {
                    SpreadItem sinfo = new SpreadItem(850,550);
                    tab.Content = sinfo;
                }
                if (i == 1)
                {
                    VerifyUserAuthenticate verUser = new VerifyUserAuthenticate(850, 550);
                    tab.Content = verUser;
                    
                }
                SystemLogControl_TabControl.Items.Add(tab);
                
            }
            SystemLogControl_TabControl.SelectedIndex = 0;
        }
    }
}
