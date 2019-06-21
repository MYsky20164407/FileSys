using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using FileSysLib.Models;
using FileSysLib.Services;
using NUnit.Framework;

namespace FileSysTest.ServicesTest {
    class DiskAdapterServiceTest {
        private DiskConnectService _diskConnectService = new DiskConnectService();

        [Test]
        public void WriteSuperBlockTest() {
            SuperBlock superBlock = new SuperBlock() {
                FreeBlock = new List<int>() { 1, 2, 3, 5 },
                FreeBlockSize = 4,
                FreeInode = new List<int>() { 5, 6 },
                FreeInodeSize = 2
            };
            DiskAdapterService diskAdapterService = new DiskAdapterService(_diskConnectService);
            diskAdapterService.WriteSuperBlock(superBlock);
        }
    }
}
