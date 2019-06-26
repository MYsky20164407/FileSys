using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSys.Pages
{
    public class Account
    {
        public string author { get; set; }
        public string yes { get; set; }
        public string no { get; set; }
    }

    public class AccountManager {
        public static List<Account> GetAccounts() {
            var Accounts = new List<Account>();
            Accounts.Add(new Account { author = "完全控制",yes= "Assets/1.png", no= "Assets/0.png" });
            Accounts.Add(new Account { author = "修改", yes = "Assets/0.png", no = "Assets/1.png" });
            Accounts.Add(new Account { author = "读取和执行", yes = "Assets/1.png", no = "Assets/0.png" });
            Accounts.Add(new Account { author = "列出文件夹内容", yes = "Assets/0.png", no = "Assets/1.png" });
            Accounts.Add(new Account { author = "读取", yes = "Assets/1.png", no = "Assets/0.png" });
            Accounts.Add(new Account { author = "写入", yes = "Assets/0.png", no = "Assets/0.png" });
            Accounts.Add(new Account { author = "特殊权限", yes = "Assets/0.png", no = "Assets/1.png" });
            return Accounts;
        }
    }
}
