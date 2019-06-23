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
using FileMode = FileSysLib.Models.FileMode;

namespace FileSysTest.ServicesTest {
    class DiskManagementServiceTest {
        private DiskAdapterService diskAdapterService = new DiskAdapterService(new DiskConnectService());
        private DiskManagementService diskManagementService = new DiskManagementService(
            new DiskAdapterService(new DiskConnectService()));

        [Test]
        public void GetRetrieveBlock() {
            SuperBlock superBlock = new SuperBlock() {
                FreeBlockSize = 1,
                FreeBlock = new List<int>() { 0 },
                FreeInodeSize = 3,
                FreeInode = new List<int>() { 1, 2, 3 }
            };
            diskAdapterService.WriteSuperBlock(superBlock);
            DataBlock dataBlock = new DataBlock() {
                GroupMode = new List<int>() { 3, -1, 2, 1 }
            };
            diskAdapterService.WriteDataBlock(dataBlock, 0, DataMode.Group);
            List<int> tFreeBlock = diskManagementService.GetFreeBlocks(2);
            Assert.AreEqual(0, tFreeBlock[0]);
            Assert.AreEqual(1, tFreeBlock[1]);
            tFreeBlock = diskManagementService.GetFreeBlocks(10);
            Assert.IsNull(tFreeBlock);
            superBlock = diskAdapterService.ReadSuperBlock();
            Assert.AreEqual(2, superBlock.FreeBlockSize);
            Assert.AreEqual(2, superBlock.FreeBlock[1]);
        }

        [Test]
        public void GetFreeInodeTest() {
            SuperBlock superBlock = new SuperBlock() {
                FreeBlockSize = 3,
                FreeBlock = new List<int>() { 1, 2, 3 },
                FreeInodeSize = 3,
                FreeInode = new List<int>() { 1, 2, 3 }
            };
            diskAdapterService.WriteSuperBlock(superBlock);
            int tFreeInode = diskManagementService.GetFreeInode(FileMode.Text);
            Assert.AreEqual(tFreeInode, 1);
            DiskInode diskInode = diskAdapterService.ReadDiskInode(tFreeInode);
            Assert.AreEqual(diskInode.Size, 0);
            Assert.AreEqual(diskInode.Number, 0);
            Assert.AreEqual(diskInode.Mode, 1);
        }

        [Test]
        public void ReadWriteDir() {
            Dir dir = new Dir() {
                Size = 2,
                DirItems = new List<DirItem>() {
                    new DirItem() {NameSize = 3, Name = "111", Inode = 9},
                    new DirItem() {NameSize = 4, Name = "1121", Inode = 90}
                }
            };
            diskManagementService.WriteDir(dir, 0);
            Dir redir = diskManagementService.ReadDir(0);
            Assert.AreEqual(dir.Size, redir.Size);
            for (int i = 0; i < 2; i++) {
                Assert.AreEqual(dir.DirItems[i].NameSize, redir.DirItems[i].NameSize);
                Assert.AreEqual(dir.DirItems[i].Name, redir.DirItems[i].Name);
                Assert.AreEqual(dir.DirItems[i].Inode, redir.DirItems[i].Inode);
            }
        }
    }
}
