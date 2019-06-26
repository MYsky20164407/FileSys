using System;
using System.Collections.Generic;
using System.Text;

namespace FileSysLib.Models {
    public class DirItem {
        public int NameSize; //文件名长度
        public string Name { get; set; } //文件名
        public int Inode { get; set; } //i节点编号
    }
}
