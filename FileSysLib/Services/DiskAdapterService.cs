using System;
using System.Collections.Generic;
using System.Text;
using FileSysLib.IServices;
using FileSysLib.Models;

namespace FileSysLib.Services {
    public class DiskAdapterService : IDiskAdapterService {
        public void WriteSuperBlock(SuperBlock superblock) {
            throw new NotImplementedException();
        }

        public void WriteDiskInode(DiskInode diskInode, int index) {
            throw new NotImplementedException();
        }

        public void WriteDataBlock(DataBlock dataBlock, int index) {
            throw new NotImplementedException();
        }

        public SuperBlock ReadSuperBlock() {
            throw new NotImplementedException();
        }

        public DiskInode ReaDiskInode(int index) {
            throw new NotImplementedException();
        }

        public DataBlock ReaDataBlock(int index) {
            throw new NotImplementedException();
        }
    }
}
