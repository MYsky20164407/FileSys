using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using FileSysLib.IServices;
using FileSysLib.Models;

namespace FileSysLib.Services {
    public class DiskAdapterService : IDiskAdapterService {
        private IDiskConnectService _diskConnectService;
        private FileStream fileStream;
        private StreamWriter streamWriter;
        private StreamReader streamReader;

        public DiskAdapterService(IDiskConnectService diskConnectService) {
            _diskConnectService = diskConnectService;
        }

        public void WriteSuperBlock(SuperBlock superBlock) {
            //超级块字节化
            byte[] bytes = new byte[Constant.Constant.Blocksize];
            int count = 0;
            List<int> blockInfo = new List<int>();
            blockInfo.Add(superBlock.FreeBlockSize);
            blockInfo.AddRange(superBlock.FreeBlock);
            blockInfo.Add(superBlock.FreeInodeSize);
            blockInfo.AddRange(superBlock.FreeInode);
            blockInfo.ForEach(delegate (int index){
                Array.Copy(BitConverter.GetBytes(index),
                    0, bytes, count, 4);
                count += 4;
            });
            //超级块写入虚拟磁盘
            fileStream = _diskConnectService.GetFileStream();
            fileStream.Seek(0, SeekOrigin.Begin);
            fileStream.Write(bytes, 0, bytes.Length);
            fileStream.Close();
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
