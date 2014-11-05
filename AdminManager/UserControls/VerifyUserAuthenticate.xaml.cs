using AdminManager.BLL;
using AdminManager.Component;
using AdminManager.Windows;
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
using Xceed.Wpf.Toolkit;
using AdminManager.Model;

namespace AdminManager.UserControls
{
    /// <summary>
    /// VerifyUserAuthenticate.xaml 的交互逻辑
    /// </summary>
    public partial class VerifyUserAuthenticate : UserControl
    {
        public VerifyUserAuthenticate()
        {
            InitializeComponent();
        }
        public VerifyUserAuthenticate(int width,int height,long taskid=0,long id=0)
        {
            InitializeComponent();
            this.Width = width;
            this.Height = height;
            this.ID = id;
            this.TaskID = taskid;
        }

        long ID
        {
            get;
            set;
        }
        long TaskID
        {
            get;
            set;
        }
        int pagesize = 10;
        int pagecount = 10;
        int allcount = 0;
        int First = 0;
        private void UserControl_Loaded_1(object sender, RoutedEventArgs e)
        {
            bottom.Children.Clear();
            timeto.Format = DateTimeFormat.FullDateTime;
            timefrom.Format = DateTimeFormat.FullDateTime;
            timefrom.Text = "";
            timeto.Text = "";
            GetLogList(pagesize, 1, GetWhere(), order, out allcount);

            int allpage = 0 == allcount % pagesize ? allcount / pagesize : allcount / pagesize + 1;
            PageControl pagecontrol = new PageControl(1, allpage, pagecount, allcount);
            pagecontrol.MyEvent += demo_MyEvent;
            bottom.Children.Add(pagecontrol);

            DataTable dt = helper.GetEmployeeInfo(MainWindow.UserAccount).Tables[0];
            if (dt.Rows.Count > 0)
            {
                sb.SetSysLog(dt.Rows[0]["id"].ToString(), dt.Rows[0]["name"].ToString(), "查看实名审核信息", "查看", DateTime.Now);
            }
            
        }
        UserBLL ub = new UserBLL();
        SysLogBLL sb = new SysLogBLL();
        AssetBLL ab = new AssetBLL();
        UserAuthenticateBLL uabll = new UserAuthenticateBLL();
        string order = " order by CompleteDate desc";

        public void GetLogList(int PageSize, int PageIndex, string strWhere, string orderStr, out int totalCount)
        {
            First++;
            DataSet ds = uabll.GetListByPage(PageSize, PageIndex, strWhere, orderStr, out totalCount);
            if (ds == null||ds.Tables.Count==0)
            {
                System.Windows.MessageBox.Show("查无数据");
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
            if (ID != 0)
            {
                sb.Append(" and tUserAuthenticate.ID='" + ID + "'");
            }
            if(txtname.Text.Trim() != "")
            {
                sb.Append(" and Name like '%" + txtname.Text.Trim() + "%'");
            }
            if (combox.SelectedIndex!=0)
            {
                sb.Append(" and tUserAuthenticate.state='" + combox.SelectedValue + "'");
            }
            if (timefrom.Text != "")
            {
                sb.Append(" and date>='" + Convert.ToDateTime(timefrom.Text) + "'");
            }

            if (timeto.Text != "")
            {
                sb.Append(" and date<='" + Convert.ToDateTime(timeto.Text) + "'");
            }
            return sb.ToString();
        }
        void demo_MyEvent(object sender, EventArgs e)
        {
            Dictionary<string, int> d = (Dictionary<string, int>)sender;
            int index = d["index"];
            int pagecount = d["pagecount"];
            if (First <= 1)
            {
                return;
            }
            GetLogList(pagesize, index == 0 ? 1 : index, GetWhere(), order, out allcount);
        }

        private void DataGrid1_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            DataRowView dr = (DataRowView)DataGrid1.SelectedItem;
            if (dr == null)
            {
                return;
            }
            CheckBox cb = DataGrid1.Columns[0].GetCellContent(dr) as CheckBox;
            if (cb.IsChecked == true)
            {
                cb.IsChecked = false;
            }
            else
                cb.IsChecked = true;

            right.Children.Clear();
            UserInfoList userlist = new UserInfoList(220, 500,dr["UserID"].ToString());
            right.Children.Add(userlist);
        }
       
        private void DataGrid1_PreviewMouseDoubleClick_1(object sender, MouseButtonEventArgs e)
        {
            
        }
        
        void order_UpdateEvent(object sender, EventArgs e)
        {
            GetLogList(pagesize, 1, GetWhere(), order, out allcount);
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
                        if (c.Name == "All")
                        {
                            return;
                        }
                        c.IsChecked = this.All.IsChecked;
                    }
                    EnumVisual(childVisual);
                }
            }
        }

        TaskBLL tb = new TaskBLL();
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {


            MessageBoxResult confirmToDel = System.Windows.MessageBox.Show("确认要通过审核吗？", "提示", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (confirmToDel == MessageBoxResult.Yes)
            {
                //DataTable dt = helper.GetEmployeeInfo(MainWindow.UserAccount).Tables[0];
                for (int i = 0; i < DataGrid1.Items.Count; i++)
                {
                    CheckBox cb = DataGrid1.Columns[0].GetCellContent(DataGrid1.Items[i]) as CheckBox;

                    if (cb.IsChecked == true)
                    {
                        DataRowView dr = DataGrid1.Items[i] as DataRowView;
                        //状态为2的直接跳过
                        if (dr["State"].ToString() == "2")
                        {
                            continue;
                        }
                        UserAuthenticateModel um = uabll.GetModel(Convert.ToInt64(dr["ID"].ToString()));
                        um.State = 2;
                        um.CompleteDate = DateTime.Now;
                        try
                        {
                            bool result = uabll.Update(um);
                            if (result)
                            {
                                sb.SetSysLog(MainWindow.EmployeeID.ToString(), MainWindow.EmployeeName, string.Format("修改用户实名认证,ID:{0},State:{1}",ID,um.State),"修改", DateTime.Now);

                                //审核完成 同时 完成对应的审核任务
                                DataSet ds=tb.GetList(" and type=1 and state=0");
                                if (ds.Tables.Count == 0)
                                {
                                    return;
                                }
                                for (int k = 0; k < ds.Tables[0].Rows.Count; k++)
                                {
                                    //如何 批量审核的数据中 在任务表中有对应的记录  那么就该任务的状态为1
                                    if (Convert.ToInt64(ds.Tables[0].Rows[k]["Pointer"]) == Convert.ToInt64(dr["ID"].ToString()))
                                    {
                                        TaskModel tm = tb.GetModel(Convert.ToInt64(ds.Tables[0].Rows[k]["ID"]));
                                        tm.State = 1;
                                        tm.EmployeeID = MainWindow.EmployeeID;
                                        try
                                        {
                                            bool _result = tb.Update(tm);
                                        }
                                        catch (Exception ep)
                                        {
                                            System.Windows.MessageBox.Show(ep.Message);
                                            return;
                                        }
                                    }
                                }
                                
                            }
                            else
                            {
                                System.Windows.MessageBox.Show("审核错误！请联系管理员");
                                return;
                            }
                        }
                        catch (Exception ep)
                        {
                            System.Windows.MessageBox.Show(ep.Message.ToString());
                            return;
                        }
                        
                    }
                }
                System.Windows.MessageBox.Show("审核完成!");
                GetLogList(pagesize, 1, GetWhere(), order, out allcount);
            }
            else
            {
                //此处加不删除的操作
            }      
            
        }

        private void All_Click_1(object sender, RoutedEventArgs e)
        {
            //this.DataGrid1.SelectAll();
            EnumVisual(DataGrid1);
        }

        private void Grid_State_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

            if (DataGrid1.CurrentCell.Column == null)
            {
                return;
            }

            MessageBoxResult YesOrNo = System.Windows.MessageBox.Show("确认修改审核信息状态吗?", "提示", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (YesOrNo == MessageBoxResult.Cancel)
            {
                return;
            }

            int index = DataGrid1.CurrentCell.Column.DisplayIndex;
            DataGridTemplateColumn templeColumn = DataGrid1.Columns[index] as DataGridTemplateColumn;

            if (templeColumn == null) return;

            DataRowView item = (DataRowView)DataGrid1.CurrentCell.Item;

            FrameworkElement element = templeColumn.GetCellContent(item);
            ComboBox com = (ComboBox)templeColumn.CellTemplate.FindName("Grid_State", element);
            ListBoxItem cb = (ListBoxItem)com.SelectedValue;
            string state = cb.Tag.ToString();


            string strvalue = Enum.GetName(typeof(AdminManager.UserControls.DataConverter_VerifyUserInfo.EnumValues), Convert.ToInt32(state));

            //MessageBoxResult YesOrNo = System.Windows.MessageBox.Show("确认修改审核信息状态为:" + strvalue, "提示", MessageBoxButton.YesNo, MessageBoxImage.Question);


            try
            {
                UserAuthenticateModel ua = uabll.GetModel(Convert.ToInt64(item["id"].ToString()));
                ua.State = Convert.ToInt32(state);
                ua.CompleteDate = DateTime.Now;
              bool result=uabll.Update(ua);
              if (result)
              {
                  if (state == "2")
                  {
                      com.IsEnabled = false;
                  }
                  sb.SetSysLog(MainWindow.EmployeeID.ToString(), MainWindow.EmployeeName, "实名审核" + ID + "的State为" + strvalue, "修改", DateTime.Now);
                  return;
              }
              System.Windows.MessageBox.Show("实名审核" + ID + "的State为" + strvalue+"时发生错误，请联系管理员!");
            }
            catch (Exception ep)
            {
                System.Windows.MessageBox.Show(ep.Message);
                return;
            }

            
        }

    }

    public class DataConverter_VerifyUserInfo : IValueConverter
    {
      public  enum EnumValues
        {
            正在审核 = 0,
            信息错误 = 1,
            审核通过 = 2
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

    public class EnableConverter_VerifyUserInfo : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (System.Convert.ToInt32(value) == 2)
            {
                return false;
            }
            return true;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
