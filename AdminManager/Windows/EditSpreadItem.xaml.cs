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
using AdminManager.BLL;
using AdminManager.Model;
using System.Data;
using AdminManager.Component;

namespace AdminManager.Windows
{
    /// <summary>
    /// EditSpreadItem.xaml 的交互逻辑
    /// </summary>
    public partial class EditSpreadItem : Window
    {
        public EditSpreadItem()
        {
            InitializeComponent();
        }

        public EditSpreadItem(int width,int height,long id=0)
        {
            InitializeComponent();
            this.Width = width;
            this.Height = height;
            this.ID = id;
        }
        public long ID
        {
            set;
            get;
        }
        SpreadItemBLL spb = new SpreadItemBLL();
        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
            try
            {
                DataSet ds = spi.GetList(" and tSpreadLevelInfo.SpreadItemID='" + ID + "'");
                if (ds.Tables.Count == 0)
                {
                    cb_Enable.IsChecked = false;
                    cb_Enable.IsEnabled = false;
                }
            }
            catch (Exception ep)
            {
                MessageBox.Show(ep.Message);
                return;
            }
            


            int output=0;
            DataTable dt = spb.GetListByPage(20, 1, "", " order by tSpreadItem.id ", out output).Tables[0];
            cm_SpreadItemID.ItemsSource = dt.DefaultView;
            cm_SpreadItemID.DisplayMemberPath = dt.Columns["Name"].ToString();
            cm_SpreadItemID.SelectedValuePath = dt.Columns["id"].ToString();

            cm_SpreadItemID.SelectedIndex = 0;

            DataTable product = pb.GetList("").Tables[0];
            cm_Product.ItemsSource = product.DefaultView;
            cm_Product.DisplayMemberPath = product.Columns["Name"].ToString();
            cm_Product.SelectedValuePath = product.Columns["id"].ToString();

            cm_Product.SelectedIndex = 0;

            if (ID != 0)
            {
                SpreadItemModel pm = spb.GetModel(ID);
                txt_Name.Text = pm.Name.ToString();
                txt_ParentLevelD.Text = pm.ParentLevel.ToString();
                txt_ParentQuantity.Text = pm.ParentQuantity.ToString();
                if (pm.SpreadItemID.ToString() != "")
                {
                    cm_SpreadItemID.Text = spb.GetListByPage(1, 1, " and tSpreadItem.id='" + pm.SpreadItemID.ToString() + "'", " order by tSpreadItem.id", out output).Tables[0].Rows[0]["Name"].ToString();
                }
                cm_Product.Text=pb.GetList(" and id='"+pm.ProductID+"'").Tables[0].Rows[0]["Name"].ToString();
                cb_Enable.IsChecked = pm.Enable;
            }
        }
        public event EventHandler UpdateEvent;
        SysLogBLL sb = new SysLogBLL();
        Helper helper = new Helper();
        ProductBLL pb = new ProductBLL();
        SpreadLevelInfoBLL spi = new SpreadLevelInfoBLL();
        private void Sure_Click_1(object sender, RoutedEventArgs e)
        {
            //修改的动作
            if (ID != 0)
            {
                SpreadItemModel pm = spb.GetModel(ID);
                pm.Name = txt_Name.Text;
                pm.ParentLevel = Convert.ToInt32(txt_ParentLevelD.Text);
                pm.ParentQuantity = Convert.ToInt32(txt_ParentQuantity.Text);
                pm.Enable = Convert.ToBoolean(cb_Enable.IsChecked);
                pm.SpreadItemID = Convert.ToInt64(cm_SpreadItemID.SelectedValue);
                pm.ProductID = Convert.ToInt64(cm_Product.SelectedValue);
                bool result = spb.Update(pm);
                if (result == true)
                {
                    DataTable dt = helper.GetEmployeeInfo(MainWindow.UserAccount).Tables[0];
                    sb.SetSysLog(dt.Rows[0]["id"].ToString(), dt.Rows[0]["name"].ToString(), "修改推广项【" + ID + "】", "修改", DateTime.Now);
                }
            }
            //新增动作
            else
            {
                SpreadItemModel pm = new SpreadItemModel();
                pm.SpreadItemID = Convert.ToInt64(cm_SpreadItemID.SelectedValue);
                pm.Name = txt_Name.Text;
                pm.ParentQuantity = Convert.ToInt32(txt_ParentQuantity.Text);
                pm.Enable = Convert.ToBoolean(cb_Enable.IsChecked);
                pm.ParentLevel = Convert.ToInt32(txt_ParentLevelD.Text);
                pm.ProductID = Convert.ToInt64(cm_Product.SelectedValue);
                long result = spb.Add(pm);
                if (result >= 1)
                {
                    DataTable dt = helper.GetEmployeeInfo(MainWindow.UserAccount).Tables[0];
                    sb.SetSysLog(dt.Rows[0]["id"].ToString(), dt.Rows[0]["name"].ToString(), "新增推广项【" + txt_Name.Text + "】", "新增", DateTime.Now);
                }
            }
            if (UpdateEvent != null)
            {
                UpdateEvent(this, new EventArgs());
            }
            this.Close();
        }

        private void Cancel_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
