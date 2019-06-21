using System;
using System.Collections.Generic;
using System.Text;

namespace FileSysLib.Models {
    public class DiskInode {
        public int Number { get; set; }
        public int Mode { get; set; } //类型：文件/目录
        public int Size { get; set; } //文件大小
        public List<int> Addrs { get; set; } //i节点指向数据块
    }
}
