using AdminManager.BLL;
using AdminManager.Model;
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

namespace AdminManager.Windows
{
    /// <summary>
    /// RegisterEmployee.xaml 的交互逻辑
    /// </summary>
    public partial class RegisterEmployee : Window
    {
        public RegisterEmployee()
        {
            InitializeComponent();
        }
        public RegisterEmployee(string id, int width, int height)
        {
            InitializeComponent();
            this.ID = id;
            this.Width = width;
            this.Height = height;
            txt_account.Text = ID.ToString();
        }

        public string ID
        {
            get;
            set;
        }
        SysLogBLL sb = new SysLogBLL();
        EmployeeBLL embll = new EmployeeBLL();
        private void btn_sure_Click_1(object sender, RoutedEventArgs e)
        {
            //Application.Current.Properties["app"] = "aaa";
            EmployeeModel em = new EmployeeModel();
            em.UserID = Convert.ToInt64(ID);
            em.Name = txt_name.Text;
            em.IDCard = txt_IDcard.Text;
            em.Telephone = txt_Tel.Text;
            em.Mobile = txt_Mobile.Text;
            long result = embll.Add(em);

            if (result <= 1)
            {
                MessageBox.Show("创建员工信息失败!");
                return;
            }
            MessageBox.Show("创建员工信息成功!");
        }

        private void btn_Cancel_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
