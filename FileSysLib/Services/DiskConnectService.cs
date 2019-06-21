using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using FileSysLib.IServices;

namespace FileSysLib.Services {
    class DiskConnectService : IDiskConnectService {
        private const string FileName = "Disk.txt";

        static DiskConnectService() {
            if (!File.Exists(FileName)) {
                FileStream fileStream = new FileStream(FileName, FileMode.Create);
                //TODO 修改文件大小
                fileStream.Close();
            }
        }

        public FileStream GetFileStream() {
            throw new NotImplementedException();
        }
    }
}
