using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using FileSysLib.Models;
using FileSysLib.Services;
using NUnit.Framework;

namespace FileSysTest.ServicesTest {
    class DiskConnectServiceTest {
        private DiskConnectService _diskConnectService = new DiskConnectService();
        [Test]
        public void GetDiskConnect() {
            FileStream fileStream = _diskConnectService.GetFileStream();
            string ll = "2222";
            StreamWriter streamWriter = new StreamWriter(fileStream);
            streamWriter.WriteLine(ll);
            streamWriter.Close();
            fileStream.Close();
        }

        [Test]
        public void intToByte() {
            int a = 100;
            byte[] bytes = BitConverter.GetBytes(a);
            Assert.AreEqual(4,bytes.Length);
            int b = BitConverter.ToInt32(bytes);
            Assert.AreEqual(100, b);
        }
    }
}
