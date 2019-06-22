using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using FileSysLib.IServices;
using FileSysLib.Models;

namespace FileSysLib.Services {
    public class DiskAdapterService : IDiskAdapterService {
        /// <summary>
        /// 磁盘连接器
        /// </summary>
        private IDiskConnectService _diskConnectService;
        /// <summary>
        /// 文件流、读写流
        /// </summary>
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
            blockInfo.ForEach(delegate (int index) {
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
            //i节点字节化
            byte[] bytes = new byte[Constant.Constant.Blocksize];
            int count = 0;
            List<int> blockInfo = new List<int>();
            blockInfo.Add(diskInode.Number);
            blockInfo.Add(diskInode.Mode);
            blockInfo.Add(diskInode.Size);
            blockInfo.AddRange(diskInode.Addrs);
            blockInfo.ForEach(delegate (int inodeIndex) {
                Array.Copy(BitConverter.GetBytes(inodeIndex),
                    0, bytes, count, 4);
                count += 4;
            });
            //i节点写入虚拟磁盘
            fileStream = _diskConnectService.GetFileStream();
            fileStream.Seek(
                Constant.Constant.Dinodestart + Constant.Constant.Dinodesize * index,
                SeekOrigin.Begin);
            fileStream.Write(bytes, 0, bytes.Length);
            fileStream.Close();
        }

        public void WriteDataBlock(DataBlock dataBlock, int index, DataMode mode) {
            int count = 0;
            byte[] bytes = new byte[Constant.Constant.Blocksize];
            //组长块转换
            if (mode == DataMode.Group) {
                dataBlock.GroupMode.ForEach(delegate (int i) {
                    Array.Copy(BitConverter.GetBytes(i),
                        0, bytes, count, 4);
                    count += 4;
                });
                dataBlock.Bytes = bytes.ToList();
            }
            //数据块写入虚拟磁盘
            fileStream = _diskConnectService.GetFileStream();
            fileStream.Seek(
                Constant.Constant.Datastart + Constant.Constant.Blocksize * index,
                SeekOrigin.Begin);
            fileStream.Write(dataBlock.Bytes.ToArray(), 0, Constant.Constant.Blocksize);
            fileStream.Close();
        }

        public SuperBlock ReadSuperBlock() {
            int index = 0;
            //超级块容器
            SuperBlock superBlock = new SuperBlock();
            superBlock.FreeBlock = new List<int>();
            superBlock.FreeInode = new List<int>();
            byte[] bytes = new byte[Constant.Constant.Blocksize];
            //读虚拟磁盘
            fileStream = _diskConnectService.GetFileStream();
            fileStream.Seek(0, SeekOrigin.Begin);
            fileStream.Read(bytes, 0, Constant.Constant.Blocksize);
            fileStream.Close();
            //字节转换
            superBlock.FreeBlockSize = BitConverter.ToInt32(bytes, index);
            for (index = 1; index < 1 + superBlock.FreeBlockSize; index++)
                superBlock.FreeBlock.Add(BitConverter.ToInt32(bytes, 4 * index));
            superBlock.FreeInodeSize = BitConverter.ToInt32(bytes, 4 * index);
            for (index++; index < 2 + superBlock.FreeBlockSize + superBlock.FreeInodeSize; index++)
                superBlock.FreeInode.Add(BitConverter.ToInt32(bytes, 4 * index));
            return superBlock;
        }

        public DiskInode ReadDiskInode(int inodeIndex) {
            int index;
            //i节点容器
            DiskInode diskInode = new DiskInode();
            diskInode.Addrs = new List<int>();
            byte[] bytes = new byte[Constant.Constant.Dinodesize];
            //读虚拟磁盘
            fileStream = _diskConnectService.GetFileStream();
            fileStream.Seek(
                Constant.Constant.Dinodestart + Constant.Constant.Dinodesize * inodeIndex, 
                SeekOrigin.Begin
                );
            fileStream.Read(bytes, 0, Constant.Constant.Dinodesize);
            fileStream.Close();
            //字节转换
            diskInode.Number = BitConverter.ToInt32(bytes, 0);
            diskInode.Mode = BitConverter.ToInt32(bytes, 4);
            diskInode.Size = BitConverter.ToInt32(bytes, 8);
            for (index = 0; index < Constant.Constant.Naddr; index++)
                diskInode.Addrs.Add(BitConverter.ToInt32(bytes, 12 + 4 * index));
            return diskInode;
        }

        public DataBlock ReadDataBlock(int index, DataMode mode) {
            DataBlock dataBlock = new DataBlock();
            dataBlock.GroupMode = new List<int>();
            byte[] bytes = new byte[Constant.Constant.Blocksize];
            //读取数据块
            fileStream = _diskConnectService.GetFileStream();
            fileStream.Seek(
                Constant.Constant.Datastart + Constant.Constant.Blocksize * index,
                SeekOrigin.Begin
            );
            fileStream.Read(bytes, 0, Constant.Constant.Blocksize);
            fileStream.Close();
            dataBlock.Bytes = bytes.ToList();
            //组长块转换
            if (mode == DataMode.Group) {
                for(int i = 0; i < Constant.Constant.Blocksize; i += 4)
                    dataBlock.GroupMode.Add(BitConverter.ToInt32(bytes, i));
            }
            return dataBlock;
        }
    }
}
