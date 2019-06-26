using System.Collections.Generic;
using Windows.UI.Xaml.Controls;

// https://go.microsoft.com/fwlink/?LinkId=234238 上介绍了“空白页”项模板

namespace FileSys.Pages {
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class ProgressPage : Page {

        public class Foo {
            public int RowNumber { get; set; }

            public int Number { get; set; }
        }

        public ProgressPage() {
            this.InitializeComponent();
            int super0=40, super1=150;       //bind超级块和组长块第一块
            int nowsuper=1,oldsuper=0;       //bind当前所在超级块
            int logrownumber=0;
            var x = new List<Foo>();//超级块表格
            var y = new List<Foo>();//组长块表格
            var z = new List<Foo>();//日志块表格
            ///超级块添加
            x.Add(new Foo() { RowNumber = 0, Number = super0 });
            for (int i = 0; i < 50; i++) {
                x.Add(new Foo() { RowNumber = i+1, Number = super1-i });
            }
            SuperGrid.ItemsSource = x;

            ///组长块添加
            y.Add(new Foo() { RowNumber = 0, Number = 50 });
            for (int i = 0; i < 50; i++) {
                y.Add(new Foo() { RowNumber = i + 1, Number = super1 +50 - i });
            }
            DataGrid.ItemsSource = y;

            if(nowsuper!=oldsuper) {
                z.Add(new Foo() { RowNumber = logrownumber, Number = nowsuper });
                logrownumber = logrownumber + 1;
                oldsuper = nowsuper;
            }
            LogGrid.ItemsSource = z;
        }

        private void Button_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e) {
            this.Frame.Navigate(typeof(RountProgress));

        }

        private void Button_Click1(object sender, Windows.UI.Xaml.RoutedEventArgs e) {
            this.Frame.Navigate(typeof(SecurityPage));

        }
    }
}
