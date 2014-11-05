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

namespace AdminManager.UserControls
{
    /// <summary>
    /// PageControl.xaml 的交互逻辑
    /// </summary>
    public partial class PageControl : UserControl
    {
        public PageControl()
        {
            InitializeComponent();
        }

        public event EventHandler MyEvent;


        //当前页
        int index = 1;
        //总页数
        int count = 0;
        //每页显示页数
        int pagecount = 10;
        //一共多少记录
        int allcount = 0;
        private void UserControl_Loaded_1(object sender, RoutedEventArgs e)
        {
            Init();
        }
        protected void Init()
        {

            First.IsEnabled = true;
            Prev.IsEnabled = true;
            Next.IsEnabled = true;
            Last.IsEnabled = true;


            //第一页
            if (index <= 1)
            {
                First.IsEnabled = false;
                Prev.IsEnabled = false;

            }
            //最后一页
            if (index >= count)
            {
                Next.IsEnabled = false;
                Last.IsEnabled = false;
            }
            //只有一页
            if (count <= 1)
            {
                First.IsEnabled = false;
                Prev.IsEnabled = false;
                Next.IsEnabled = false;
                Last.IsEnabled = false;
            }
            page_all.Content = "【共" + count + "页】";
            page_index.Content = "【当前第" + index + "页】";
            page_count.Content = "【共" + allcount + "记录】";

            if (MyEvent != null)
            {
                Dictionary<string, int> d = new Dictionary<string, int>();
                d.Add("index", index);
                d.Add("pagecount", pagecount);
                MyEvent(d, new EventArgs());
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Index">当前页数</param>
        /// <param name="Count">总页数</param>
        /// <param name="PageCoutn">每页显示的数目</param>
        /// <param name="allcount">总共的条数</param>
        public PageControl(int Index, int Count, int PageCoutn,int allcount)
        {
            this.index = Index;
            this.pagecount = PageCoutn;
            this.count = Count;
            this.allcount = allcount;
            InitializeComponent();
        }

        private void First_Click(object sender, RoutedEventArgs e)
        {
            index = 1;
            Init();
        }

        private void Prev_Click(object sender, RoutedEventArgs e)
        {
            --index;
            Init();
        }

        private void Last_Click(object sender, RoutedEventArgs e)
        {
            index = count;
            Init();
        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            ++index;
            Init();
        }
       

    }
}
