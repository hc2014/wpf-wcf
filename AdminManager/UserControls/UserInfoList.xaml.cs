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
using System.Windows.Navigation;
using System.Windows.Shapes;
using AdminManager.BLL;

namespace AdminManager.UserControls
{
    /// <summary>
    /// UserInfoList.xaml 的交互逻辑
    /// </summary>
    public partial class UserInfoList : UserControl
    {
        public UserInfoList()
        {
            InitializeComponent();
        }
        public UserInfoList(int width,int height,string userid)
        {
            InitializeComponent(); 
            this.Width = width;
            this.Height = height;
            this.UserID = userid;
        }
        public string UserID
        {
            get;
            set;
        }

        UserBLL ub = new UserBLL();
        AssetBLL ab = new AssetBLL();
        private void UserControl_Loaded_1(object sender, RoutedEventArgs e)
        {
            DataSet userinfo = ub.GetList(" and id='" + UserID + "'");
            
            if (userinfo != null&&userinfo.Tables.Count>0)
            {

                DataRow UserDr = userinfo.Tables[0].Rows[0];
                txt_Account.Text = UserDr["account"].ToString();
                txt_Email.Text = UserDr["email"].ToString();
                txt_Gender.Text = UserDr["gender"].ToString() == "0" ? "男" : "女";
                txt_NickName.Text = UserDr["nickname"].ToString();
                txt_QQ.Text = UserDr["qq"].ToString();
                txt_Tel.Text = UserDr["Mobile"].ToString();
            }

            DataSet asset = ab.GetList(" and userid='"+UserID+"'");

            if (asset != null&&asset.Tables.Count>0)
            {
                DataRow AssetDr = asset.Tables[0].Rows[0];
                txt_Money.Text = AssetDr["money"].ToString();
                txt_Gold.Text = AssetDr["gold"].ToString();
            }
        }
    }
}
