using System;
using System.Collections.Generic;
using System.Text;

namespace FileSysLib.IServices {
    /// <summary>
    /// 文件系统内核，提供系统调用服务
    /// </summary>
    public interface ICoreService {
        void CreatFile();
        void OpenFile();
        void ReadFile();
        void WriteFile();
        void CloseFIle();
        void DeleteFile();
        void MakeDir();
        void OpenDir();

        void Select();
    }
}
