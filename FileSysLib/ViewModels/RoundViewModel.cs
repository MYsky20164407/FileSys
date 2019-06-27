using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Text;

namespace FileSysLib.ViewModels {
    public class RoundViewModel : ViewModelBase {
        private string _number;
        public string Number {
            get => _number;
            set => Set(nameof(Number), ref _number, value);
        }
    }
}
