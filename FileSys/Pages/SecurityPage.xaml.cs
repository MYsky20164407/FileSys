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
using FileSys.Models;
using FileSysLib.ViewModels;
using FileSys.Locator;

// https://go.microsoft.com/fwlink/?LinkId=234238 上介绍了“空白页”项模板

namespace FileSys.Pages
{

    public class AccountSetting {
        public string Number { get; set; }
        public string Objectnumber { get; set; }
    }

    public class AccountSettingManager {
        public static AccountSetting GetAccountSetting() {
            var sample = new AccountSetting();
            sample.Number = "用户一";
            sample.Objectnumber = "C:/";
            return sample;
        }
    }


    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class SecurityPage : Page
        {

        private AccountViewModel vm = ViewModelLocator.Instance.AccountViewModel;
        public List<Account> Accounts;
        public AccountSetting Sample;

        public SecurityPage()
        {
            this.InitializeComponent();
            Accounts = AccountManager.GetAccounts();
            Sample = AccountSettingManager.GetAccountSetting();
            DataContext = vm;
        }

        private void ListView_ItemClick(object sender, ItemClickEventArgs e) {

            ((AccountViewModel)DataContext).LoadedCommand.Execute(e.ClickedItem);

        }




                
        
    }














}
