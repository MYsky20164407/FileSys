using System;
using System.Collections.Generic;
using System.Text;
using GalaSoft.MvvmLight;

namespace FileSysLibrary {
    class test {
        private int _i;

        public int I {
            get => _i;
            set => Set();
        }
    }
}
