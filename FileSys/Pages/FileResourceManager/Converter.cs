using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;
using FileSysLib.Models;

namespace FileSys.Pages {
    public class Converter : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, string language) {
            if ((value as int?).Value == 0)
                return "文件夹";
            return "文本文件";
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language) {
            throw new NotImplementedException();
        }
    }
}
