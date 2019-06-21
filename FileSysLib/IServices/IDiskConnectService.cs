using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FileSysLib.IServices {
    /// <summary>
    /// 提供磁盘模拟文件的文件流，在文件不存在时创建文件并初始化
    /// </summary>
    public interface IDiskConnectService {
        /// <summary>
        /// 获得磁盘模拟文件流
        /// </summary>
        FileStream GetFileStream();
    }
}
