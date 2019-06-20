using System;
using System.Collections.Generic;
using System.Text;

namespace FileSysLib.Models {
    class SuperBlock {
        public int FreeBlockSize;
        public int[] FreeBlock = new int[Constant.Constant.Nicfreeblk];
        public int FreeInodeSize;
        public int[] FreeInode = new int[Constant.Constant.Nicinode];
    }
}
