using System;
using System.Collections.Generic;
using System.Text;
using GalaSoft.MvvmLight;

namespace FileSysLib.ViewModels {
    class FrontEndViewModel :ViewModelBase{
        private List<Models.File> _dirList;

        public List<Models.File> DirList {
            get => _dirList;
            set => Set(nameof(DirList), ref _dirList, value);
        }
    }
}
