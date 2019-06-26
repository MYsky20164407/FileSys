using System;
using System.Collections.Generic;
using System.Text;

namespace FileSysLib.Models {
    public class DiskInode {
        public int Number { get; set; } //块数量
        public int Mode { get; set; } //类型：文件/目录
        public int Size { get; set; } //字节数量
        public List<int> Addrs { get; set; } //i节点指向数据块
    }
}
