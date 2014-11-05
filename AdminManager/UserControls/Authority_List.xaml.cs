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
using System.Collections;
using System.Windows.Controls.Primitives;
using AdminManager.Component;

namespace AdminManager.UserControls
{
    /// <summary>
    /// Authority_List.xaml 的交互逻辑
    /// </summary>
    public partial class Authority_List : UserControl
    {
        public Authority_List()
        {
            InitializeComponent();
        }

        public Authority_List(int width,int height)
        {
            InitializeComponent();
            this.Width = width;
            this.Height = Height;
        }
        private void sure_Click_1(object sender, RoutedEventArgs e)
        {
            //EnumVisual(tabconttrol);
            check();
            string fieldname = "";
            if (al.Count > 0)
            {

                for (int i = 0; i < al.Count; i++)
                {
                    fieldname += al[i].ToString() + ",";
                }
            }
            Helper help = new Helper();
            DataTable dt = help.GetEmployeeInfo(MainWindow.UserAccount).Tables[0];
            sab.SetSingleArgumen(dt.Rows[0]["userid"].ToString(), dt.Rows[0]["name"].ToString(), 1, fieldname);


            if (UpdateEvent != null)
            {
                UpdateEvent(this, new EventArgs());
            }
        }

        private void cancle_Click_1(object sender, RoutedEventArgs e)
        {
            if (UpdateEvent != null)
            {
                UpdateEvent(this, new EventArgs());
            }
        }

        SystemParameterBLL spbll = new SystemParameterBLL();
        SingleArgumentBLL sab = new SingleArgumentBLL();
        UserBLL ub = new UserBLL();
        ArrayList al = new ArrayList();
        public event EventHandler UpdateEvent;
        private void UserControl_Loaded_1(object sender, RoutedEventArgs e)
        {
            tabconttrol.Items.Clear();
            DataTable userdt = ub.GetList(" and id='" + MainWindow.ID + "'").Tables[0];
            int output = 0;
            DataSet ds = sab.GetListByPage(10, 1, " and staffid='" + MainWindow.ID + "' and type=1 ", " order by id ", out output);
            DataTable userAuth=new DataTable();
            if (ds.Tables.Count > 0)
            {
                userAuth = ds.Tables[0];
            }
            string fieldname="";
            if (userAuth.Rows.Count > 0)
            {
                fieldname = userAuth.Rows[0]["fieldname"].ToString();
            }
           
            DataTable dt = spbll.GetList().Tables[0];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                TabItem tb = new TabItem();
                tb.Header = dt.Rows[i]["name"].ToString();
                tb.Tag = dt.Rows[i]["id"].ToString();
                DataTable smalldt = spbll.GetSmallList(tb.Tag.ToString()).Tables[0];
                UniformGrid ug=new UniformGrid();
                for (int j = 0; j < smalldt.Rows.Count; j++)
                {
                    CheckBox cb = new CheckBox();
                    cb.Content = smalldt.Rows[j]["name"].ToString();
                    cb.Name = "cb_" + smalldt.Rows[j]["id"].ToString();
                    cb.Tag = smalldt.Rows[j]["id"].ToString();
                    if (fieldname.IndexOf(cb.Tag.ToString()) != -1)
                    {
                        cb.IsChecked = true;
                    }
                    if (userdt.Rows[0]["type"].ToString() == "8")
                    {
                        if (cb.Content.ToString() == "系统权限")
                        {
                            cb.IsChecked = true;
                            cb.IsEnabled = false;
                        }
                    }
                    ug.Children.Add(cb);
                }
                tb.Content = ug;
                
                tabconttrol.Items.Add(tb);
            }
            
        }

        private void EnumVisual(Visual myVisual)
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(myVisual); i++)
            {
                Visual childVisual = (Visual)VisualTreeHelper.GetChild(myVisual, i);
                if (childVisual != null)
                {
                    if (childVisual is CheckBox)
                    {
                        CheckBox c = childVisual as CheckBox;
                        if (c.IsChecked == true)
                        {
                            int j = c.Name.IndexOf("_");
                            string id = c.Name.Substring(j + 1, c.Name.Length - j - 1);
                            al.Add(id);
                        }
                    }
                    EnumVisual(childVisual);
                }
            }
        }
        public void check()
        {
            foreach (TabItem tb in tabconttrol.Items)
            {
                EnumVisual((Visual)tb.Content);
            }
        }
    }
}
