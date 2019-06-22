using System;
using System.Collections.Generic;
using System.Text;

namespace FileSysLib.Models {
    public class DataBlock {
        public List<byte> Bytes;
        public List<int> GroupMode;
    }

    public enum DataMode {
        Bytes = 0,
        Group = 1
    }
}