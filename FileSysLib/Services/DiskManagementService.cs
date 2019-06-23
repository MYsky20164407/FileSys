using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using FileSysLib.IServices;
using FileSysLib.Models;

namespace FileSysLib.Services {
    public class DiskManagementService : IDiskManagementService {
        private IDiskAdapterService _diskAdapterService;

        public DiskManagementService(IDiskAdapterService diskAdapterService) {
            _diskAdapterService = diskAdapterService;
        }

        public List<int> GetFreeBlocks(int num) {
            SuperBlock superBlock = _diskAdapterService.ReadSuperBlock();
            List<int> blockList = new List<int>();
            for (int i = 0; i < num; i++) {
                if (superBlock.FreeBlockSize == 1) {
                    if (superBlock.FreeBlock[0] == -1) {
                        RetrieveBlocks(blockList);
                        return null;
                        //TODO:不知此处返回什么
                        //throw new NotImplementedException();
                    }
                    else {
                        int group = superBlock.FreeBlock[0];
                        blockList.Add(group);
                        DataBlock dataBlock = _diskAdapterService.ReadDataBlock(group, DataMode.Group);
                        superBlock.FreeBlockSize = dataBlock.GroupMode[0];
                        superBlock.FreeBlock = dataBlock.GroupMode.GetRange(1, superBlock.FreeBlockSize);
                    }
                }
                else {
                    superBlock.FreeBlockSize--;
                    blockList.Add(superBlock.FreeBlock[superBlock.FreeBlock.Count - 1]);
                    superBlock.FreeBlock.RemoveAt(superBlock.FreeBlock.Count - 1);
                }

                _diskAdapterService.WriteSuperBlock(superBlock);
            }

            return blockList;
        }

        public int GetFreeInode(FileMode fileMode) {
            SuperBlock superBlock = _diskAdapterService.ReadSuperBlock();
            superBlock.FreeInodeSize--;
            int freeInode = superBlock.FreeInode[0];
            superBlock.FreeInode.RemoveAt(0);
            _diskAdapterService.WriteDiskInode(new DiskInode() {
                Number = 0,
                Mode = (int)fileMode,
                Size = 0,
                Addrs = new List<int>()
            }, freeInode);
            _diskAdapterService.WriteSuperBlock(superBlock);

            return freeInode;
        }

        public void RetrieveBlocks(List<int> blockList) {
            SuperBlock superBlock = _diskAdapterService.ReadSuperBlock();
            blockList.ForEach(delegate(int index) {
                if (superBlock.FreeBlockSize == 50) {
                    List<int> groupContent = new List<int>();
                    groupContent.Add(superBlock.FreeBlockSize);
                    groupContent.AddRange(superBlock.FreeBlock);
                    DataBlock dataBlock = new DataBlock() {
                        GroupMode = groupContent,
                        Bytes = new List<byte>()
                    };
                    _diskAdapterService.WriteDataBlock(dataBlock, index, DataMode.Group);
                    superBlock.FreeBlockSize = 1;
                    superBlock.FreeBlock.Clear();
                    superBlock.FreeBlock.Add(index);
                }
                else {
                    superBlock.FreeBlockSize++;
                    superBlock.FreeBlock.Add(index);
                }
            });
            _diskAdapterService.WriteSuperBlock(superBlock);
        }

        //TODO 未测试
        public void RetrieveInode(int index) {
            SuperBlock superBlock = _diskAdapterService.ReadSuperBlock();
            DiskInode diskInode = _diskAdapterService.ReadDiskInode(index);
            superBlock.FreeInodeSize++;
            superBlock.FreeInode.Add(index);
            _diskAdapterService.WriteSuperBlock(superBlock);
            RetrieveBlocks(diskInode.Addrs);
        }

        public Dir ReadDir(int index) {
            Dir dir = new Dir();
            dir.DirItems = new List<DirItem>();
            byte[] bytes = ReadBiteFile(index);

            int i, count = 4;
            //字节解析为目录
            dir.Size = BitConverter.ToInt32(bytes, 0);
            for (i = 0; i < dir.Size; i++) {
                DirItem dirItem = new DirItem();
                dirItem.NameSize = BitConverter.ToInt32(bytes, count);
                count += 4;
                dirItem.Name = System.Text.Encoding.Default.GetString(bytes, count, dirItem.NameSize);
                count += dirItem.NameSize;
                dirItem.Inode = BitConverter.ToInt32(bytes, count);
                count += 4;
                dir.DirItems.Add(dirItem);
            }

            return dir;
        }

        public string ReadText(int index) {
            byte[] bytes = ReadBiteFile(index);
            return BitConverter.ToString(bytes);
        }

        public void WriteDir(Dir dir, int index) {
            DiskInode diskInode = _diskAdapterService.ReadDiskInode(index);
            byte[] bytes =
                ByteConverter.ByteConverter.byteConverter.ToBytes(dir);
            RetrieveBlocks(diskInode.Addrs);
            int size = (int)(bytes.Length / Constant.Constant.Blocksize) + 1;
            List<int> freeBlock = GetFreeBlocks(size);
            //文件内容写入磁盘
            WriteBiteFile(freeBlock, bytes);
            //修改i节点并写回
            diskInode.Size = bytes.Length;
            diskInode.Number = size;
            diskInode.Addrs = freeBlock;
            _diskAdapterService.WriteDiskInode(diskInode, index);
        }

        //TODO 这里还没写
        public void WriteText(string text, int index) {
            throw new NotImplementedException();
        }

        private byte[] ReadBiteFile(int index) {
            DiskInode diskInode = _diskAdapterService.ReadDiskInode(index);
            byte[] bytes = new byte[diskInode.Size];
            int i, count = 0;
            //取该文件所有块
            for (i = 0; i < diskInode.Number; i++) {
                Array.Copy(_diskAdapterService.ReadDataBlock(diskInode.Addrs[i], DataMode.Bytes).Bytes.ToArray(),
                    0, bytes, count,
                    diskInode.Size - count >= Constant.Constant.Blocksize ? Constant.Constant.Blocksize : diskInode.Size - count);
                count += Constant.Constant.Blocksize;
            }

            return bytes;
        }

        private void WriteBiteFile(List<int> addr, byte[] bytes) {
            byte[] tBytes = new byte[Constant.Constant.Blocksize];
            int count = 0;
            addr.ForEach(delegate (int index) {
                Array.Copy(bytes, count, tBytes, 0,
                    bytes.Length - count >= Constant.Constant.Blocksize ? Constant.Constant.Blocksize : bytes.Length - count);
                count += Constant.Constant.Blocksize;
                _diskAdapterService.WriteDataBlock(
                    new DataBlock() {
                        Bytes = tBytes.ToList()
                    }, index, DataMode.Bytes);
            });
        }
    }
}
