using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using FileSysLib.IServices;

namespace FileSysLib.Services {
    public class DiskConnectService : IDiskConnectService {
        private const string FileName = "C:\\Users\\ZJH\\Desktop\\Disk.txt";

        static DiskConnectService() {
            if (!File.Exists(FileName)) {
                FileStream fileStream = new FileStream(FileName, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                //TODO 修改文件大小
                fileStream.Close();
            }
        }

        public FileStream GetFileStream() {
            return new FileStream(FileName, FileMode.Open, FileAccess.ReadWrite);
        }
    }
}
