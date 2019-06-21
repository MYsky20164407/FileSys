using System;
using System.Collections.Generic;
using System.Text;

namespace FileSysLib.Models {
    public class DirItem {
        public string Name { get; set; } //文件名
        //TODO：限制文件名长度
        public int Inode { get; set; } //i节点编号
    }
}
