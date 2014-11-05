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
using AdminManager.Model;
using AdminManager.BLL;
using AdminManager.Component;
using System.Data;
using System.Globalization;
using AdminManager.Windows;

namespace AdminManager.UserControls
{
    /// <summary>
    /// EditOrderInfo.xaml 的交互逻辑
    /// </summary>
    public partial class EditOrderInfo : UserControl
    {
        public EditOrderInfo()
        {
            InitializeComponent();
        }

        public EditOrderInfo(int widht,int height,long id,long taskind)
        {
            InitializeComponent();
            this.Width = widht;
            this.Height = height;
            this.ID = id;
            this.TaskID = taskind;
        }
        public long ID
        {
            get;
            set;
        }
        public long TaskID
        {
            get;
            set;
        }
        OrderBLL ob = new OrderBLL();
        LogisticBLL lb = new LogisticBLL();
        private void UserControl_Loaded_1(object sender, RoutedEventArgs e)
        {

            if (TaskID == 0)
            {
                com_State.IsEnabled = false;
                bt_Sure.IsEnabled = false;
            }

          Window w=this.Parent as Window;
          w.Title = "编辑订单详情";
            DataSet ds=ob.GetListInfo(" and tOrder.ID='"+ID+"'");
            if (ds.Tables.Count == 0)
            {
                return;
            }
            txt_Account.Text = ds.Tables[0].Rows[0]["Account"].ToString();
            txt_ComData.Text = ds.Tables[0].Rows[0]["CompleteDate"].ToString();
            txt_Data.Text = ds.Tables[0].Rows[0]["Date"].ToString();
            txt_Employee.Text = ds.Tables[0].Rows[0]["EmployeeID"].ToString();
            txt_IP.Text = ds.Tables[0].Rows[0]["IP"].ToString();
            txt_NickName.Text = ds.Tables[0].Rows[0]["NickName"].ToString();
            txt_Number.Text = ds.Tables[0].Rows[0]["Number"].ToString();
            txt_Page.Text = ds.Tables[0].Rows[0]["Page"].ToString();
            txt_PayBank.Text = ds.Tables[0].Rows[0]["PayBank"].ToString();
            txt_PayGold.Text = ds.Tables[0].Rows[0]["PayGold"].ToString();
            txt_PayMoney.Text = ds.Tables[0].Rows[0]["PayMoney"].ToString();

            DataTable dt = GetProduct();
            txt_Rember.Text = ds.Tables[0].Rows[0]["Remark"].ToString();
            txt_Reward.Text = ds.Tables[0].Rows[0]["EmployeeReward"].ToString();
            com_State.SelectedIndex = Convert.ToInt32(ds.Tables[0].Rows[0]["state"].ToString())+1;
            DataSet LogisticDs = lb.GetList(" and OrderID='" + ID + "'");
            if (LogisticDs.Tables.Count == 0)
            {
                return;
            }
            this.DataGrid1.ItemsSource = LogisticDs.Tables[0].DefaultView;

        }
        ProductBLL pbll = new ProductBLL();
        public DataTable GetProduct()
        {
            DataTable dt = pbll.GetList("").Tables[0];
            return dt;
        }


        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Button bt = (Button)sender;
            EditLogistic el = new EditLogistic(500, 350, Convert.ToInt64(bt.Tag));
            el.UpdateEvent += el_UpdateEvent;
            el.ShowDialog();
        }
        SysLogBLL sb = new SysLogBLL();
        private void bt_Sure_Click_1(object sender, RoutedEventArgs e)
        {
            OrderModel om = ob.GetModel(ID);
            om.State = Convert.ToInt32(((ListBoxItem)com_State.SelectedValue).Tag.ToString());
            om.Remark = txt_Rember.Text.ToString();


             DataSet LogisticDs = lb.GetList(" and OrderID='" + ID + "' and state=0");


            //如何对于订单的 物流表 没有数据 并且修改订单的状态为 正在发货
            if (LogisticDs.Tables.Count == 0&&om.State==1)
            {
                MessageBoxResult YesOrNo = MessageBox.Show("该订单是没有物流信息的，订单状态默认改成'完成'.点击'确定'继续,'取消'返回", "提示", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (YesOrNo == MessageBoxResult.Cancel)
                {
                    return;
                }
                //修改状态为 完成
                om.State = 3;
            }


            bool result=ob.Update(om);
            if (result == true)
            {
                //记录日志
                sb.SetSysLog(MainWindow.EmployeeID.ToString(), MainWindow.EmployeeName, "修改订单号" + ID + "的State为" + om.State + ";Remark为"+om.Remark, "修改", DateTime.Now);


                //如何存在状态为“未发货”的物流    添加物流任务
               if(LogisticDs.Tables.Count>0)
               {
                   TaskBLL tb = new TaskBLL();
                   TaskModel tm = new TaskModel();
                   tm.Date = DateTime.Now;
                   tm.Level = 1;
                   tm.Title = "发货任务";
                   tm.Type = 1;
                   tm.Pointer =Convert.ToInt64(LogisticDs.Tables[0].Rows[0]["ID"]);
                   tm.Describe = "确认订单，填写物流信息发货";

                   try
                   {
                       long i=tb.Add(tm);
                       if (i > 0)
                       {
                           sb.SetSysLog(MainWindow.EmployeeID.ToString(), MainWindow.EmployeeName, "新增任务成功,任务ID："+i, "新增", DateTime.Now);
                       }
                       else
                       {
                           sb.SetSysLog(MainWindow.EmployeeID.ToString(), MainWindow.EmployeeName, "新增任务失败", "新增", DateTime.Now);
                           MessageBox.Show("新增任务失败!请于管理员联系!");
                           return;
                       }
                   }
                   catch (Exception ep)
                   {
                       sb.SetSysLog(MainWindow.EmployeeID.ToString(), MainWindow.EmployeeName, string.Format("新增任务记录信息错误，错误信息是{0}", ep.Message.ToString()), "错误", DateTime.Now);
                       MessageBox.Show(ep.Message.ToString());
                       return;
                   }
               }

                //添加任务记录信息
                TaskLogBLL tl = new TaskLogBLL();
                TaskLogModel tlm = new TaskLogModel();
                tlm.Date = DateTime.Now;
                tlm.Remark = "修改订单状态为" + om.State;
                tlm.EmployeeID = MainWindow.EmployeeID;
                tlm.TaskID = TaskID;

                //如果TaskID为0  那么反查Task表中的任务ID
                if (TaskID == 0)
                { 
                
                }
                try
                {
                    long i = tl.Add(tlm);
                   if (i >= 1)
                   {
                       //成功
                       sb.SetSysLog(MainWindow.EmployeeID.ToString(), MainWindow.EmployeeName, "新增任务记录信息成功,任务ID:"+i
, "新增", DateTime.Now);
                   }
                   else
                   {
                       sb.SetSysLog(MainWindow.EmployeeID.ToString(), MainWindow.EmployeeName, "新增任务记录信息失败", "新增", DateTime.Now);
                       MessageBox.Show("新增任务记录信息失败!请于管理员联系!");
                       return;
                   }
                }
                catch (Exception ep)
                {
                    sb.SetSysLog(MainWindow.EmployeeID.ToString(), MainWindow.EmployeeName,string.Format("新增任务记录信息错误，错误信息是{0}",ep.Message.ToString()), "错误", DateTime.Now);
                    MessageBox.Show(ep.Message.ToString());
                    return;
                }
                
            }
            else
            {
                MessageBox.Show("修改失败");
                return;
            }
            MessageBoxResult confirmToDel = MessageBox.Show("修改完成后是否执行物流操作?", "提示", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (confirmToDel == MessageBoxResult.Yes)
            {
                return;
            }
            else
            {
                if (UpdateEvent != null)
                {
                    UpdateEvent(this, new EventArgs());
                }
                if (UpdateOrder != null)
                {
                    UpdateOrder(this, new EventArgs());
                }
            }    
        }
        public event EventHandler UpdateEvent;
        public event EventHandler UpdateOrder;
        private void bt_Print_Click_1(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("打印功能还未开放!");
        }

        private void DataGrid1_PreviewMouseDoubleClick_1(object sender, MouseButtonEventArgs e)
        {
            DataRowView dr = (DataRowView)DataGrid1.SelectedItem;
            if (dr == null)
            {
                return;
            }
            EditLogistic el = new EditLogistic(500, 350, Convert.ToInt64(dr["ID"]));
            el.UpdateEvent += el_UpdateEvent;
            el.ShowDialog();
        }

        void el_UpdateEvent(object sender, EventArgs e)
        {
            DataSet LogisticDs = lb.GetList(" and OrderID='" + ID + "'");
            if (LogisticDs.Tables.Count == 0)
            {
                return;
            }
            this.DataGrid1.ItemsSource = LogisticDs.Tables[0].DefaultView;
        }

        private void DataGrid1_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }

        private void bt_Sure_Click_2(object sender, RoutedEventArgs e)
        {
            if (UpdateEvent != null)
            {
                UpdateEvent(this, new EventArgs());
            }
        }
    }

    public class LogisticDataConverter : IValueConverter
    {
        enum EnumValues
        {
            顺丰 = 0,
            Ems = 1,
            宅急送 = 2,
            韵达 = 3,
            圆通=4,
            申通,
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
