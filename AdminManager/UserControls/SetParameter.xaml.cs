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
using AdminManager.Component;
using System.Data;
using AdminManager.Model;

namespace AdminManager.UserControls
{
    /// <summary>
    /// SetParameter.xaml 的交互逻辑
    /// </summary>
    public partial class SetParameter : UserControl
    {
        public SetParameter()
        {
            InitializeComponent();
        }

        public SetParameter(int width,int height)
        {
            InitializeComponent();
            this.Width = width;
            this.Height = height;
        }
        SystemParameterBLL spbll = new SystemParameterBLL();
        Helper help = new Helper();
        private void UserControl_Loaded_1(object sender, RoutedEventArgs e)
        {
            DataTable dt = GetTb();
            cb_WorkMonth.IsChecked=Convert.ToInt32(dt.Rows[0]["state"])==0?true:false;
            Dictionary<string, int> dic = help.GetWorkMonth();

            txt_MonthFrom.Text = dic[help.WorkMonthFrom].ToString();
            txt_MonthTo.Text = dic[help.WorkMonthTo].ToString();
        }

        private void Sure_Click_1(object sender, RoutedEventArgs e)
        {
            DataTable dt = GetTb();
            SystemParameterModel sp = spbll.GetModel(dt.Rows[0]["id"].ToString());
            sp.state = cb_WorkMonth.IsChecked==true? 0 : 1;
            sp.order = txt_MonthFrom.Text.Trim() + "-" + txt_MonthTo.Text.Trim();
           bool result=spbll.Update(sp);
           if (result)
               MessageBox.Show("修改成功");
            //这里需要记录日志
        }
        public DataTable GetTb()
        {
            DataSet ds = spbll.GetList(" and type=2");
            return ds.Tables[0];
        }
    }
}
