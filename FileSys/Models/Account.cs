using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSys.Models
{
    public class Account
    {
        public string Author { get; set; }
        public string Yes { get; set; }
        public string No { get; set; }
    }

    public class AccountManager {
        public static List<Account> GetAccounts() {
            var Accounts = new List<Account>();
            Accounts.Add(new Account { Author = "完全控制",Yes= "/Assets/1.png", No= "/Assets/2.png" });
            Accounts.Add(new Account { Author = "修改", Yes = "/Assets/2.png", No = "/Assets/1.png" });
            Accounts.Add(new Account { Author = "读取和执行", Yes = "/Assets/1.png", No = "/Assets/2.png" });
            Accounts.Add(new Account { Author = "列出文件夹内容", Yes = "/Assets/2.png", No = "/Assets/1.png" });
            Accounts.Add(new Account { Author = "读取", Yes = "/Assets/1.png", No = "/Assets/2.png" });
            Accounts.Add(new Account { Author = "写入", Yes = "/Assets/2.png", No = "/Assets/2.png" });
            Accounts.Add(new Account { Author = "特殊权限", Yes = "/Assets/2.png", No = "/Assets/1.png" });
            return Accounts;
        }
    }

    public class AccountSetting 
    {
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
}
