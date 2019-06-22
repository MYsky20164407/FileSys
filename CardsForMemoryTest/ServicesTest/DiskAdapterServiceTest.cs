using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using FileSysLib.Constant;
using FileSysLib.Models;
using FileSysLib.Services;
using NUnit.Framework;

namespace FileSysTest.ServicesTest {
    class DiskAdapterServiceTest {
        private DiskConnectService _diskConnectService = new DiskConnectService();

        [Test]
        public void WriteReadSuperBlockTest() {
            SuperBlock superBlock = new SuperBlock() {
                FreeBlock = new List<int>() { 1, 2, 3, 5 },
                FreeBlockSize = 4,
                FreeInode = new List<int>() { 5, 6 },
                FreeInodeSize = 2
            };
            DiskAdapterService diskAdapterService = new DiskAdapterService(_diskConnectService);
            diskAdapterService.WriteSuperBlock(superBlock);
            var reSuperBlock = diskAdapterService.ReadSuperBlock();

            Assert.AreEqual(reSuperBlock.FreeBlockSize, superBlock.FreeBlockSize);
            Assert.AreEqual(reSuperBlock.FreeBlock[0], superBlock.FreeBlock[0]);
            Assert.AreEqual(reSuperBlock.FreeBlock[1], superBlock.FreeBlock[1]);
            Assert.AreEqual(reSuperBlock.FreeBlock[2], superBlock.FreeBlock[2]);
            Assert.AreEqual(reSuperBlock.FreeBlock[3], superBlock.FreeBlock[3]);
            Assert.AreEqual(4, superBlock.FreeBlock.Count);
            Assert.AreEqual(reSuperBlock.FreeInodeSize, superBlock.FreeInodeSize);
            Assert.AreEqual(reSuperBlock.FreeInode[0], superBlock.FreeInode[0]);
            Assert.AreEqual(reSuperBlock.FreeInode[1], superBlock.FreeInode[1]);
        }

        [Test]
        public void WriteReadInodeTest() {
            DiskInode diskInode = new DiskInode() {
                Number = 10,
                Mode = 1,
                Size = 10,
                Addrs = new List<int>() { 1, 2, 4, 6, 13, 567, 111, 121, 111, 90, 11, 22, 33 }
            };
            DiskAdapterService diskAdapterService = new DiskAdapterService(_diskConnectService);
            diskAdapterService.WriteDiskInode(diskInode, 6);
            var reDiskInode = diskAdapterService.ReadDiskInode(6);

            Assert.AreEqual(reDiskInode.Number, diskInode.Number);
            Assert.AreEqual(reDiskInode.Mode, diskInode.Mode);
            Assert.AreEqual(reDiskInode.Size, diskInode.Size);
            for (int i = 0; i < Constant.Naddr; i++)
                Assert.AreEqual(reDiskInode.Addrs[i], diskInode.Addrs[i]);
        }

        [Test]
        public void WriteReadDataBlockTest() {
            DataBlock dataBlock = new DataBlock() {
                Bytes = new List<byte>()
            };
            for(int i = 0; i < Constant.Blocksize/4; i++)
                dataBlock.Bytes.AddRange(BitConverter.GetBytes(i));
            DiskAdapterService diskAdapterService = new DiskAdapterService(_diskConnectService);
            diskAdapterService.WriteDataBlock(dataBlock, 3, DataMode.Bytes);
            var reDataBlock = diskAdapterService.ReadDataBlock(3, DataMode.Bytes);

            for(int i = 0; i < Constant.Blocksize; i++)
                Assert.AreEqual(reDataBlock.Bytes[i], dataBlock.Bytes[i]);
        }
    }

}
