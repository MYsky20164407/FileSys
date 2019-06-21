using System;
using System.Collections.Generic;
using System.Text;

namespace FileSysLib.Models {
    class SuperBlock {
        public int FreeBlockSize;
        public List<int> FreeBlock;
        public int FreeInodeSize;
        public List<int> FreeInode;
    }
}
