using System;
using System.Collections.Generic;
using System.Text;
using FileSysLib.Models;
using FileSysLib.Services;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace FileSysTest.ServicesTest {
    class CoreServiceTest {
        private DiskAdapterService diskAdapterService = 
            new DiskAdapterService(new DiskConnectService());
        private DiskManagementService diskManagementService = 
            new DiskManagementService(new DiskAdapterService(new DiskConnectService()));
        private CoreService coreService = 
            new CoreService(new DiskManagementService(new DiskAdapterService(new DiskConnectService())), new MemManagementService(new DiskAdapterService(new DiskConnectService())));
        [Test]
        public void CreatFileTest() {
            SuperBlock superBlock = new SuperBlock() {
                FreeBlockSize = 3,
                FreeBlock = new List<int>() { 1, 2, 3 },
                FreeInodeSize = 3,
                FreeInode = new List<int>() { 1, 2, 3 }
            };
            Dir dir = new Dir() {
                Size = 0,
                DirItems = new List<DirItem>()
            };
            diskAdapterService.WriteSuperBlock(superBlock);
            diskManagementService.WriteDir(dir, 0);
            coreService.CreatFile(new User(), "newFile", 0);

            SuperBlock reSuperBlock = diskAdapterService.ReadSuperBlock();
            Dir reDir = diskManagementService.ReadDir(0);

            Assert.AreEqual(1, reDir.Size);
            Assert.AreEqual("newFile", reDir.DirItems[0].Name);
            Assert.AreEqual(1, reDir.DirItems[0].Inode);
            Assert.AreEqual(2, reSuperBlock.FreeInodeSize);

            coreService.DeleteFile(new User(), "newFile", 0);

            reSuperBlock = diskAdapterService.ReadSuperBlock();
            reDir = diskManagementService.ReadDir(0);
            Assert.AreEqual(superBlock.FreeInodeSize,reSuperBlock.FreeInodeSize);
            Assert.AreEqual(dir.Size, reDir.Size);
            Assert.AreEqual(0, reDir.DirItems.Count);
        }
    }
}
