using System;
using System.Collections.Generic;
using System.Text;

namespace FileSysLib.Models {
    public class DirItem {
        public string Name; //文件名
        //TODO：限制文件名长度
        public int Inode; //i节点编号
    }
}
