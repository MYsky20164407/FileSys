using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace FileSysLib.ViewModels {
    public class AccountViewModel : ViewModelBase {
        private string _number;
        public string Number {
            get => _number;
            set => Set(nameof(Number), ref _number, value);
        }

        private RelayCommand<string> _loadedCommand;
        public RelayCommand<string> LoadedCommand =>
            _loadedCommand ?? (_loadedCommand =
                new RelayCommand<string>(number => {
                    Number = number;
                }));
    }
    
}
