﻿using System;
using System.Collections.Generic;
using System.Text;

namespace FileSysLib.Models {
    class Dir {
        public DirItem[] DirItems = new DirItem[Constant.Constant.Dirnum];//目录项
        public int Size;//包含的目录项大小
    }
}
