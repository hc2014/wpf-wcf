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
using System.Windows.Shapes;
using AdminManager.BLL;
using AdminManager.Model;
using Xceed.Wpf.Toolkit;

namespace AdminManager.Windows
{
    /// <summary>
    /// EditOrderInfo.xaml 的交互逻辑
    /// </summary>
    public partial class EditLogistic : Window
    {
        public EditLogistic()
        {
            InitializeComponent();
        }
        public EditLogistic(int width, int height, long id,long taskid=0)
        {
            InitializeComponent();
            this.Height = height;
            this.Width = width;
            this.ID = id;
            this.TaskID = taskid;
        }
        public long ID
        {
            get;
            set;
        }
        public long TaskID
        {
            set;
            get;
        }
        public event EventHandler UpdateEvent;

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
            if (TaskID == 0)
            {
                com_type.IsEnabled = false;
                Com_provance.IsEnabled = false;
                Com_city.IsEnabled = false;
                Com_borough.IsEnabled = false;
                btn_sure.IsEnabled = false;
            }

            LogisticModel lm=lb.GetModel(ID);
            txt_Mobile.Text = lm.Mobile.ToString();

            txt_Tel.Text = lm.Telephone.ToString();
            txt_UserName.Text = lm.Name;
            txt_address.Text = lm.Address;
            txt_Code.Text = lm.Code;

            DataTable dt2 = GetProvance();
            Com_provance.ItemsSource = dt2.DefaultView;
            Com_provance.DisplayMemberPath = dt2.Columns["provname"].ToString();
            Com_provance.SelectedValuePath = dt2.Columns["provcode"].ToString();
            Com_provance.Text =lm.Province;
           
        }
        ProductBLL pbll = new ProductBLL();
        OrderBLL ob = new OrderBLL();
        public DataTable GetProduct()
        {
           DataTable dt=pbll.GetList("").Tables[0];
           return dt;
        }
        LogisticBLL lb = new LogisticBLL();

        public DataTable GetProvance()
        {
            return lb.GetProvanceList("").Tables[0];
        }

        public DataTable GetCity(string id)
        {
            return lb.GetCityList(" and provcode='" + id + "'").Tables[0];
        }


        public DataTable Getborough(string id)
        {
            return lb.GetGetBoroughList(" and citycode='" + id + "'").Tables[0];
        }
        #region 合并字段
        
        //public DataTable GetOrderInfo()
        //{
        //    DataTable dt = lb.GetList("").Tables[0];
        //    DataTable newdt = dt.Copy();
        //    newdt.Columns.Remove(newdt.Columns["Province"]);
        //    newdt.Columns.Remove(newdt.Columns["City"]);
        //    newdt.Columns.Remove(newdt.Columns["County"]);
        //    newdt.Columns.Add(new DataColumn("地址"));
        //    for (int i = 0; i < newdt.Rows.Count; i++)
        //    {
        //        newdt.Rows[i]["地址"] = dt.Rows[i]["Province"] + "-" + dt.Rows[i]["City"] + "-" + dt.Rows[i]["County"];
        //    }
        //    return newdt;
        //}
        #endregion

        SysLogBLL sb = new SysLogBLL();
        private void btn_sure_Click_1(object sender, RoutedEventArgs e)
        {

            LogisticModel lm = lb.GetModel(ID);
            lm.Province = ((DataRowView)Com_provance.SelectedItem)["provname"].ToString();
            lm.City = ((DataRowView)Com_city.SelectedItem)["cityname"].ToString();
            lm.County = ((DataRowView)Com_borough.SelectedItem)["boroname"].ToString();
            lm.Name = txt_UserName.Text;
            lm.Mobile = txt_Mobile.Text;
            lm.Telephone = txt_Tel.Text;
            lm.Address = txt_address.Text;


            try
            {
              bool result=lb.Update(lm);

              if (result)
              {
                  //成功
                  sb.SetSysLog(MainWindow.EmployeeID.ToString(), MainWindow.EmployeeName, string.Format("修改ID:{0}物流信息",ID), "修改", DateTime.Now);
              }
              else
              {
                  sb.SetSysLog(MainWindow.EmployeeID.ToString(), MainWindow.EmployeeName, "修改物流信息失败", "修改", DateTime.Now);
                  System.Windows.MessageBox.Show("修改物流信息失败!请于管理员联系!");
                  return;
              }
            }
            catch (Exception ep)
            {
                sb.SetSysLog(MainWindow.EmployeeID.ToString(), MainWindow.EmployeeName, ep.Message.ToString(), "错误", DateTime.Now);
                System.Windows.MessageBox.Show(ep.Message.ToString());
                return;
            }
            if (UpdateEvent != null)
            {
                UpdateEvent(this, new EventArgs());
            }
            this.Close();
            //这里要记录日志  并且用事物
        }

        private void btn_Cancle_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Com_ProductName_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            //MessageBox.Show(Com_ProductName.SelectedValue + " " + ((DataRowView)Com_ProductName.SelectedItem)["Name"].ToString());
            //LogisticModel lm = new LogisticModel();
            //OrderModel om = new OrderModel();
            //om.Date =Convert.ToDateTime(date.Text);
            //om.Quantity = Convert.ToInt32(txt_count.Text);

            //lm.Name = txt_UserName.Text;
        }

        private void Com_provance_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            if (Com_provance.SelectedIndex != -1)
            {
                DataTable dt = GetCity(Com_provance.SelectedValue.ToString());
                Com_city.ItemsSource = dt.DefaultView;
                Com_city.DisplayMemberPath = dt.Columns["cityname"].ToString();
                Com_city.SelectedValuePath = dt.Columns["citycode"].ToString();
                Com_city.Text = dt.Rows[0]["cityname"].ToString();
            }
            
        }

        private void Com_city_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            if (Com_city.SelectedIndex != -1)
            {
                DataTable dt = Getborough(Com_city.SelectedValue.ToString());
                Com_borough.ItemsSource = dt.DefaultView;
                Com_borough.DisplayMemberPath = dt.Columns["boroname"].ToString();
                Com_borough.SelectedValuePath = dt.Columns["borocode"].ToString();
                Com_borough.Text = dt.Rows[0]["boroname"].ToString();
            }
        }
    }
}
