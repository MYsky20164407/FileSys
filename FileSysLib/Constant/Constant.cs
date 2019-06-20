using System;
using System.Collections.Generic;
using System.Text;

namespace FileSysLib.Constant {
    class Constant {
        public const int BLOCKSIZE = 512;  //块大小
        public const int SYSOPENFILE = 40; //系统打开文件表最大项数
        public const int DIRNUM = 128;     //每个目录最大包含目录项数
        public const int NOFILE = 20;      //用户打开文件最大次数
        public const int NADDR = 10;       //每个i节点指向块数
        public const int USERNUM = 8;      //用户个数
        public const int DINODESIZE = 32;  //磁盘i节点大小
        public const int DINODEBLK = 32;   //磁盘i节点块数
        public const int FILEBLK = 512;    //数据块个数
        public const int NICINODE = 50;    //超级块空闲节点最大块数
        public const int NICFREEBLK = 50;  //超级块空闲块最大块数
        public const int DINODESTART = 0;  //i节点起始地址
        public const int DATASTART = 0;    //数据区起始地址
    }
}
