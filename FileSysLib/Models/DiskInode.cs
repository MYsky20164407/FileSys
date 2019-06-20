using System;
using System.Collections.Generic;
using System.Text;

namespace FileSysLib.Models {
    class DiskInode {
        public int Number;
        public int Mode; //类型：文件/目录
        public int Size; //文件大小
        public int[] Addrs = new int[Constant.Constant.Naddr]; //i节点指向数据块
    }
}
