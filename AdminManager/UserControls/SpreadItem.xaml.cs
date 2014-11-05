using AdminManager.BLL;
using AdminManager.Component;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
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
using AdminManager.Windows;

namespace AdminManager.UserControls
{
    /// <summary>
    /// SpreadItem.xaml 的交互逻辑
    /// </summary>
    public partial class SpreadItem : UserControl
    {
        public SpreadItem()
        {
            InitializeComponent();
        }
        public SpreadItem(int width, int height)
        {
            
            InitializeComponent();
            this.Width = width;
            this.Height = height;
          
        }
        private void UserControl_Loaded_1(object sender, RoutedEventArgs e)
        {
            GetLogList(pagesize, 1, GetWhere(), order, out allcount);

            DataTable dt = helper.GetEmployeeInfo(MainWindow.UserAccount).Tables[0];
            if (dt.Rows.Count > 0)
            {
                sb.SetSysLog(dt.Rows[0]["id"].ToString(), dt.Rows[0]["name"].ToString(), "查看推广项", "查看", DateTime.Now);
            }
        }
        int pagesize = 10;
        int allcount = 0;
        SpreadItemBLL ob = new SpreadItemBLL();
        SysLogBLL sb = new SysLogBLL();
        string order = "order by tSpreadItem.id";
        public void GetLogList(int PageSize, int PageIndex, string strWhere, string orderStr, out int totalCount)
        {
            DataSet ds = ob.GetListByPage(PageSize, PageIndex, strWhere, orderStr, out totalCount);
            if (ds == null)
            {
                MessageBox.Show("查无数据");
                DataGrid1.ItemsSource = null;
                return;
            }
            this.DataGrid1.ItemsSource = null;
            this.DataGrid1.ItemsSource = ds.Tables[0].DefaultView;
        }
        Helper helper = new Helper();
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            GetLogList(pagesize, 1, GetWhere(), order, out allcount);
        }

        string GetWhere()
        {
            StringBuilder sb = new StringBuilder();
            //sb.Append(" where 1=1 ");
            //if (txtname.Text.Trim() != "")
            //{
            //    sb.Append(" and staffname='" + txtname.Text.Trim() + "'");
            //}

            return sb.ToString();
        }

        private void btnAdd_Click_1(object sender, RoutedEventArgs e)
        {
            EditSpreadItem ep = new EditSpreadItem(410, 180);
            ep.UpdateEvent+=ep_UpdateEvent;
            ep.ShowDialog();
        }

        private void DataGrid1_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            DataRowView dr = (DataRowView)DataGrid1.SelectedItem;
            if (dr == null)
            {
                return;
            }

            DataSet ds = plbll.GetList(" and tSpreadLevelInfo.SpreadItemID='" + dr["id"] + "'");
            if (ds == null || ds.Tables.Count == 0)
            {
                DataGrid2.ItemsSource = null;
                return;
            }
            DataGrid2.ItemsSource = ds.Tables[0].DefaultView;
            ID = Convert.ToInt64(dr["id"].ToString());
        }

        static long ID = 0;

        SpreadLevelInfoBLL plbll = new SpreadLevelInfoBLL();

        private void btnDel_Click_1(object sender, RoutedEventArgs e)
        {
            string id = "";
            for (int i = 0; i < DataGrid1.Items.Count; i++)
            {
                CheckBox cb = DataGrid1.Columns[0].GetCellContent(DataGrid1.Items[i]) as CheckBox;
                if (cb.IsChecked == true)
                { 
                    DataRowView dr=DataGrid1.Items[i] as DataRowView;
                    id += dr["ID"].ToString();
                }
            }
            MessageBox.Show(id);
        }

        private void DataGrid1_PreviewMouseDoubleClick_1(object sender, MouseButtonEventArgs e)
        {
            DataRowView dr=(DataRowView)DataGrid1.SelectedItem;
            if(dr==null)
            {
            return;
            }
            EditSpreadItem ep=new EditSpreadItem(410,180,Convert.ToInt64(dr["id"].ToString()));
            ep.UpdateEvent += ep_UpdateEvent;
            ep.ShowDialog();
        }

        void ep_UpdateEvent(object sender, EventArgs e)
        {
             GetLogList(pagesize, 1, GetWhere(), order, out allcount);
        }

        private void Info_btnAdd_Click_1(object sender, RoutedEventArgs e)
        {
            EditSpreadLevelInfo epi = new EditSpreadLevelInfo(410, 230);
            epi.UpdateEvent += epi_UpdateEvent;
            epi.ShowDialog();
        }

        void epi_UpdateEvent(object sender, EventArgs e)
        {
            DataSet ds = plbll.GetList(" and tSpreadLevelInfo.SpreadItemID='" + ID + "'");
            if (ds == null || ds.Tables.Count == 0)
            {
                DataGrid2.ItemsSource = null;
                return;
            }
            DataGrid2.ItemsSource = ds.Tables[0].DefaultView;
        }

        private void DataGrid2_PreviewMouseDoubleClick_1(object sender, MouseButtonEventArgs e)
        {
            DataRowView dr = (DataRowView)DataGrid2.SelectedItem;
            if (dr == null)
            {
                return;
            }
            EditSpreadLevelInfo ep = new EditSpreadLevelInfo(410, 230, Convert.ToInt64(dr["id"].ToString()), Convert.ToInt64(dr["SpreadItemID"].ToString()));
            ep.UpdateEvent += ep_UpdateEvent;
            ep.ShowDialog();
        }

        private void DataGrid2_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Button but = (Button)sender;
            EditSpreadItem ep = new EditSpreadItem(410, 180, Convert.ToInt64(but.Tag));
            ep.UpdateEvent += ep_UpdateEvent;
            ep.ShowDialog();
        }

    }
    public class DataConverter_SpreadItem : IValueConverter
    {
        enum EnumValues
        {
            启用 = 1,
            禁止 = 0
        }
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Type t = typeof(EnumValues);

            return Enum.GetName(t, value);
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
