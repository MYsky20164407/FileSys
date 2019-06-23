using System;
using System.Collections.Generic;
using System.Text;
using FileSysLib.Models;

namespace FileSysLib.IServices {
    /// <summary>
    /// 文件系统内核，提供系统调用服务
    /// </summary>
    public interface ICoreService {
        /// <summary>
        /// 创建文件
        /// </summary>
        /// <param name="user"> 用户 </param>
        /// <param name="fileName"> 文件名 </param>
        /// <param name="curDirIndex"> 所在目录的i节点 </param>
        void CreatFile(User user, string fileName, int curDirIndex);

        /// <summary>
        /// 删除文件
        /// </summary>
        /// <param name="user"> 用户 </param>
        /// <param name="fileName"> 文件名 </param>
        /// <param name="curDirIndex"> 所在目录的i节点 </param>
        void DeleteFile(User user, string fileName, int curDirIndex);

        void OpenFile();
        void ReadFile();
        void WriteFile();
        void CloseFIle();
        void MakeDir();
        void OpenDir();
        void CloseDir();

        void Select();
    }
}
