using System;
using System.Collections.Generic;
using System.Text;

namespace FileSysLib.Models {
    public class File {
        public int Inode { get; set; }
        public int count { get; set; }
    }

    public enum FileMode {
        Dir = 0,
        Text = 1
    }
}
