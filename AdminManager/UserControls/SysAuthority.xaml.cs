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
    /// SysAuthority.xaml 的交互逻辑
    /// </summary>
    public partial class SysAuthority : UserControl
    {
        public SysAuthority()
        {
            InitializeComponent();
        }

        
        public SysAuthority(string id)
        {
            InitializeComponent();
            this.ID = id;
            //this.Height = height;
            //this.Width = width;
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
                    UserAuthorityList sinfo = new UserAuthorityList(850,550);
                    tab.Content = sinfo;

                }
                if (i == 1)
                {
                    SetParameter sp = new SetParameter(800,500);
                    tab.Content = sp;
                }
                tab.GotFocus += tab_GotFocus;
                SysAuthority_Tab.Items.Add(tab);
            }
            SysAuthority_Tab.SelectedIndex = 0;
        }
        void tab_GotFocus(object sender, RoutedEventArgs e)
        {

        }

    }
}
