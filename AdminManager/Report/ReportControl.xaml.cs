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
using AdminManager.BLL;

namespace AdminManager.Report
{
    /// <summary>
    /// ReportControl.xaml 的交互逻辑
    /// </summary>
    public partial class ReportControl : UserControl
    {
        public ReportControl()
        {
            InitializeComponent();
        }

        public ReportControl(string id)
        {
            InitializeComponent();
            this.ID = id;
        }
        public string ID
        {
            set;
            get;
        }
        SystemParameterBLL spb = new SystemParameterBLL();
        private void UserControl_Loaded_1(object sender, RoutedEventArgs e)
        {
            DataTable dt = spb.GetSmallList(ID).Tables[0];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                TabItem tab = new TabItem();
                tab.Header = dt.Rows[i]["name"].ToString();
                if (i == 0)
                {
                    //SpreadItem sinfo = new SpreadItem(600, 850);
                    //tab.Content = sinfo;
                }

                ReportControl_TabControl.Items.Add(tab);

            }
            ReportControl_TabControl.SelectedIndex = 0;
        }
    }
}
