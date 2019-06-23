using System;
using System.Collections.Generic;
using System.Text;

namespace FileSysLib.Constant {
    public class Constant {
        public const int Blocksize = 512;  //块大小
        public const int Sysopenfile = 40; //系统打开文件表最大项数
        public const int Dirnum = 128;     //每个目录最大包含目录项数
        public const int FileName = 16;    //文件名长度
        public const int Nofile = 20;      //用户打开文件最大次数
        public const int Naddr = 12;       //每个i节点指向块数
        public const int Usernum = 8;      //用户个数
        public const int Dinodesize = 64;  //磁盘i节点大小
        public const int Dinodeblk = 32;   //磁盘i节点块数
        public const int Fileblk = 512;    //数据块个数
        public const int Nicinode = 32;    //超级块空闲节点最大块数
        public const int Nicfreeblk = 50;  //超级块空闲块最大块数
        public const int Dinodestart = Blocksize;  //i节点起始地址
        public const int Datastart = Dinodestart + Dinodesize * Dinodeblk;    //数据区起始地址
        //40955
    }
}
