using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using FileSysLib.Services;
using NUnit.Framework;

namespace FileSysTest.ServicesTest {
    class DiskConnectServiceTest {
        private DiskConnectService _iDiskAdapterService = new DiskConnectService();
        [Test]
        public void GetDiskConnect() {
            FileStream fileStream = _iDiskAdapterService.GetFileStream();
            string ll = "2222";
            StreamWriter streamWriter = new StreamWriter(fileStream);
            streamWriter.WriteLine(ll);
            streamWriter.Close();
            fileStream.Close();
        }
    }
}
