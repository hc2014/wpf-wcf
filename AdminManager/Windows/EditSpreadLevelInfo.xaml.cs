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
using AdminManager.Component;
using AdminManager.Model;
using System.Data;

namespace AdminManager.Windows
{
    /// <summary>
    /// EditSpreadLevelInfo.xaml 的交互逻辑
    /// </summary>
    public partial class EditSpreadLevelInfo : Window
    {
        public EditSpreadLevelInfo()
        {
            InitializeComponent();
        }

        public EditSpreadLevelInfo(int width, int height, long id = 0,long spreadid=0)
        {
            InitializeComponent();
            this.Width = width;
            this.Height = height;
            this.ID = id;
            this.SpreadID = spreadid;
        }
        public long ID
        {
            set;
            get;
        }
        public long SpreadID
        {
            set;
            get;
        }
        SpreadLevelInfoBLL pli = new SpreadLevelInfoBLL();
        SpreadItemBLL spb = new SpreadItemBLL();
        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {


            int output = 0;
            DataTable dt = spb.GetListByPage(20, 1, "", " order by tSpreadItem.id ", out output).Tables[0];
            cm_SpreadItemID.ItemsSource = dt.DefaultView;
            cm_SpreadItemID.DisplayMemberPath = dt.Columns["Name"].ToString();
            cm_SpreadItemID.SelectedValuePath = dt.Columns["id"].ToString();

            cm_SpreadItemID.SelectedIndex = 0;
            if (ID != 0)
            {
                SpreadLevelInfoModel pm = pli.GetModel(ID);
                txt_Describe.Text = pm.Describe;
                txt_Experience.Text = pm.Experience.ToString();
                txt_Level.Text = pm.Level.ToString();
                txt_Rebate.Text = pm.Rebate.ToString();
                cb_Enable.IsChecked = Convert.ToBoolean(pm.Enable);

                cm_SpreadItemID.Text = spb.GetListByPage(1, 1, " and tSpreadItem.id='" + pm.SpreadItemID.ToString() + "'", " order by tSpreadItem.id", out output).Tables[0].Rows[0]["Name"].ToString();
            }
        }
        public event EventHandler UpdateEvent;
        SysLogBLL sb = new SysLogBLL();
        Helper helper = new Helper();
        private void Sure_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                DataSet ds = pli.GetList(" and tSpreadLevelInfo.SpreadItemID='" + SpreadID + "' order by Level desc");
                if (ds.Tables.Count == 0)
                {
                    MessageBox.Show("数据错误，请联系管理员!");
                    return;
                }


                if (Convert.ToInt32(txt_Level.Text) >= Convert.ToInt32(ds.Tables[0].Rows[0]["Level"].ToString()))
                {
                    MessageBox.Show("所属等级必须大于当前推荐项最大所属等级!");
                    txt_Level.Focus();
                    return;
                }

                if (ID != 0)
                {
                    SpreadLevelInfoModel pm = pli.GetModel(ID);
                    pm.Enable = Convert.ToBoolean(cb_Enable.IsChecked);
                    pm.Level = Convert.ToInt32(txt_Level.Text);
                    pm.Rebate = Convert.ToDecimal(txt_Rebate.Text);
                    pm.SpreadItemID = Convert.ToInt64(cm_SpreadItemID.SelectedValue);
                    pm.Experience = Convert.ToInt32(txt_Experience.Text);
                    pm.Describe = txt_Describe.Text;
                    bool result = pli.Update(pm);
                    if (result == true)
                    {
                        DataTable dt = helper.GetEmployeeInfo(MainWindow.UserAccount).Tables[0];
                        sb.SetSysLog(dt.Rows[0]["id"].ToString(), dt.Rows[0]["name"].ToString(), "修改推广项等级【" + ID + "】", "修改", DateTime.Now);
                    }

                }
                else
                {
                    SpreadLevelInfoModel pm = new SpreadLevelInfoModel();
                    pm.Enable = Convert.ToBoolean(cb_Enable.IsChecked);
                    pm.Level = Convert.ToInt32(txt_Level.Text);
                    pm.Rebate = Convert.ToDecimal(txt_Rebate.Text);
                    pm.SpreadItemID = Convert.ToInt64(cm_SpreadItemID.SelectedValue);
                    pm.Experience = Convert.ToInt32(txt_Experience.Text);
                    pm.Describe = txt_Describe.Text;
                    long result = pli.Add(pm);
                    if (result >= 1)
                    {
                        DataTable dt = helper.GetEmployeeInfo(MainWindow.UserAccount).Tables[0];
                        sb.SetSysLog(dt.Rows[0]["id"].ToString(), dt.Rows[0]["name"].ToString(), "新增推广项等级", "新增", DateTime.Now);
                    }
                }

            }
            catch (Exception ep)
            {
                MessageBox.Show(ep.Message);
                return;
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
