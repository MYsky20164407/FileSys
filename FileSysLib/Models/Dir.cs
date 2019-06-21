using System;
using System.Collections.Generic;
using System.Text;

namespace FileSysLib.Models {
    public class Dir {
        public List<DirItem> DirItems { get; set; }//目录项
        public int Size { get; set; }//包含的目录项大小
    }
}
