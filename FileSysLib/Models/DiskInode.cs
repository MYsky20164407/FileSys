using System;
using System.Collections.Generic;
using System.Text;

namespace FileSysLib.Models {
    class DiskInode {
        int Number;
        int Mode;
        int Uid;
        int Gid;
        int Size;
        int[] Addrs = new int[Constant.Constant.NADDR];
    }
}
