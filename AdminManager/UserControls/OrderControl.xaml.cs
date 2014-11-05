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
    /// OrderControl.xaml 的交互逻辑
    /// </summary>
    public partial class OrderControl : UserControl
    {
        public OrderControl()
        {
            InitializeComponent();
        }

        public OrderControl(string id)
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
        SingleArgumentBLL sab = new SingleArgumentBLL();
        private void UserControl_Loaded_1(object sender, RoutedEventArgs e)
        {
            DataTable dt = spbll.GetSmallList(ID).Tables[0];

            string fieldname = "";
            int output = 0;
            DataSet ds = sab.GetListByPage(10, 1, " and staffid='" + MainWindow.ID + "' and type=1 ", " order by id ", out output);
            DataTable userAuth = new DataTable();
            if (ds.Tables.Count > 0)
            {
                userAuth = ds.Tables[0];
            }
            if (userAuth.Rows.Count > 0)
            {
                fieldname = userAuth.Rows[0]["fieldname"].ToString();
            }
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (fieldname.IndexOf(dt.Rows[i]["id"].ToString()) != -1)
                {
                    TabItem tab = new TabItem();
                    tab.Header = dt.Rows[i]["name"].ToString();
                    if (i == 0)
                    {
                        OrderInfo sinfo = new OrderInfo(850, 550);

                        tab.Content = sinfo;

                    }
                    tab.GotFocus += tab_GotFocus;
                    OrderControl_TabControl.Items.Add(tab);
                }

            }
            OrderControl_TabControl.SelectedIndex = 0;
        }
        void tab_GotFocus(object sender, RoutedEventArgs e)
        {

        }
    }
}
