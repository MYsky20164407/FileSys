using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using FileSysLib.IServices;

namespace FileSysLib.Services {
    public class DiskConnectService : IDiskConnectService {

        public DiskConnectService() {
            //if (!File.Exists("C:\\Users\\ZJH\\Desktop\\Disk.txt")) {
            //    FileStream fileStream = new FileStream("C:\\Users\\ZJH\\Desktop\\Disk.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            //    //TODO 格式化
            //    byte[] bytes = new byte[20 * 1024 * 1024];
            //    fileStream.Write(bytes, 0, bytes.Length);
            //    fileStream.Close();
            //}
        }

        public FileStream GetFileStream() {
            return new FileStream("C:\\Users\\ZJH\\Desktop\\Disk.txt", FileMode.Open);
        }
    }
}
