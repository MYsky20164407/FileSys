using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// https://go.microsoft.com/fwlink/?LinkId=234238 上介绍了“空白页”项模板

namespace FileSys.Pages {
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page {
        public MainPage() {
            this.InitializeComponent();
        }

        /// <summary>
        /// 当用户输入的信息发生变化时，从输入关键词提示列表中。选出满足输入信息为关键词子串的提示字符串，并交给AutoSuggestBox显示提示信息。
        /// </summary>
        private List<string> ReminderStrList;
        private void AutoSuggestBox_TextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args) {
            if (args.Reason == AutoSuggestionBoxTextChangeReason.UserInput) {
                sender.ItemsSource = ReminderStrList.Where(i => i.Contains(sender.Text));
            }
                contentFrame.Navigate(typeof(SettingPage));
        }

        /// <summary>
        /// 当用户选择提示框中的某一项时，将该项对应的文字交给AutoSuggestBox显示提示信息。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void AutoSuggestBox_SuggestionChosen(AutoSuggestBox sender, AutoSuggestBoxSuggestionChosenEventArgs args) {
            sender.Text = args.SelectedItem.ToString();
        }

        /// <summary>
        /// 当用户确认输入，或键盘回车键后，对于输入信息进行处理。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void AutoSuggestBox_QuerySubmitted(AutoSuggestBox sender, AutoSuggestBoxQuerySubmittedEventArgs args) {
            string txt = args.QueryText;  //输入的文本
            if (args.ChosenSuggestion != null) {
                //从提示框中选择某一项时触发
            } else {
                //用户在输入时敲回车或者点击右边按钮确认输入时触发
            }
        }

        /// <summary>
        /// 当用户选中导航栏中某一个Item时触发。跳转到特定页面。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void nvAll_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args) {
            //先判断是否选中了setting
            if (args.IsSettingsInvoked) {
                contentFrame.Navigate(typeof(SettingPage));
            } else {
                //选中项的内容
                switch (args.InvokedItem) {
                    case "进程":
                        contentFrame.Navigate(typeof(ProgressPage));
                        break;
                    case "磁盘占用":
                        contentFrame.Navigate(typeof(MemoryPage));
                        break;
                    case "账户":
                        contentFrame.Navigate(typeof(AccountPage));
                        break;
                }
            }
        }
    }
}
