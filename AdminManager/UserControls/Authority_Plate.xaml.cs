using AdminManager.BLL;
using AdminManager.Component;
using System;
using System.Collections;
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
    /// Authority_Plate.xaml 的交互逻辑
    /// </summary>
    public partial class Authority_Plate : UserControl
    {
        public Authority_Plate()
        {
            InitializeComponent();
        }
        public Authority_Plate(int width,int height)
        {
            InitializeComponent();
            this.Width = width;
            this.Height = height;
        }

        SystemParameterBLL spbll = new SystemParameterBLL();
        UserBLL ub = new UserBLL();
        ArrayList al = new ArrayList();
        private void UserControl_Loaded_1(object sender, RoutedEventArgs e)
        {
            DataTable userdt = ub.GetList(" and id='" + MainWindow.ID + "'").Tables[0];
            UniformGrid1.Children.Clear();
            DataTable dt = spbll.GetList().Tables[0];

            int output = 0;
            DataTable userAuth = sab.GetListByPage(10, 1, " and staffid='" + MainWindow.ID + "'", " order by id ", out output).Tables[0];
            string fieldname = userAuth.Rows[0]["fieldname"].ToString();

            UniformGrid1.Rows = 1;
            UniformGrid1.Columns = dt.Rows.Count;
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    CheckBox cb = new CheckBox();
                    cb.Name = "cb_" + dt.Rows[i]["id"].ToString();
                    cb.Margin = new Thickness(5);
                    cb.Tag = dt.Rows[i]["id"].ToString();
                    cb.Content = dt.Rows[i]["name"].ToString();
                    UniformGrid1.Children.Add(cb);
                    if (fieldname.IndexOf(cb.Tag.ToString()) != -1)
                    {
                        cb.IsChecked = true;
                    }
                    if (userdt.Rows[0]["type"].ToString() == "8")
                    {
                        if (cb.Content.ToString() == "权限设置")
                        {
                            cb.IsChecked = true;
                            cb.IsEnabled = false;
                        }
                    }
                }
            }

           
        }
        SingleArgumentBLL sab = new SingleArgumentBLL();
        public event EventHandler UpdateEvent;
        private void sure_Click_1(object sender, RoutedEventArgs e)
        {

            EnumVisual(UniformGrid1);
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
            sab.SetSingleArgumen(dt.Rows[0]["userid"].ToString(), dt.Rows[0]["name"].ToString(), 0, fieldname);

            
            if (UpdateEvent != null)
            {
                UpdateEvent(this, new EventArgs());
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

        private void cancle_Click_1(object sender, RoutedEventArgs e)
        {
            if (UpdateEvent != null)
            {
                UpdateEvent(this, new EventArgs());
            }
        }
    }
}
