using System;
using System.Collections.Generic;
using System.Text;

namespace FileSysLib.Models {
    public class Dir {
        public int Size { get; set; }//包含的目录项大小
        public List<DirItem> DirItems { get; set; }//目录项
    }
}
