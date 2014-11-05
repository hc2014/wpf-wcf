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
using AdminManager.UserControls;

namespace AdminManager.Windows
{
    /// <summary>
    /// TemplateWindow.xaml 的交互逻辑
    /// </summary>
    public partial class TemplateWindow : Window
    {
        public TemplateWindow()
        {
            InitializeComponent();
        }

        public TemplateWindow(int width, int height, WindowType type,long id,long taskid)
        {
            InitializeComponent();
            this.Height = height;
            this.Width = width;
            this.ID = id;
            this.Type = type;
            this.TaskID = taskid;
        }
        public WindowType Type
        {
            set;
            get;
        }
        public long ID
        {
            set;
            get;
        }
        public long TaskID
        {
            set;
            get;
        }
        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
            if (Type == WindowType.OrderInfo)
            {
                EditOrderInfo eo = new EditOrderInfo(700, 500, ID,TaskID);
                eo.UpdateEvent += eo_UpdateEvent;
                eo.UpdateOrder += eo_UpdateOrder;
                this.Content=eo;
            }
            else if (Type == WindowType.VerifyUser)
            {
                VerifyUserAuthenticate eo = new VerifyUserAuthenticate(850, 550,TaskID,ID);
                //eo.UpdateEvent += eo_UpdateEvent;
                //eo.UpdateOrder += eo_UpdateOrder;
                this.Content = eo;
            }
        }

        public event EventHandler UpdateEvent;
        void eo_UpdateOrder(object sender, EventArgs e)
        {
            if (UpdateEvent != null)
            {
                UpdateEvent(this, new EventArgs());
            }
        }

        void eo_UpdateEvent(object sender, EventArgs e)
        {
            this.Close();
        }
    }
    public enum WindowType
    { 
        OrderInfo=0,//订单
        Logistic=1,//物流
        VerifyUser=2,//实名审核
    }
}
