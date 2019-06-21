using System;
using System.Collections.Generic;
using System.Text;

namespace FileSysLib.Models {
    [Serializable]
    public class SuperBlock {
        public int FreeBlockSize { get; set; }
        public List<int> FreeBlock { get; set; }
        public int FreeInodeSize { get; set; }
        public List<int> FreeInode { get; set; }
    }
}
