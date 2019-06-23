using System;
using System.Collections.Generic;
using System.Text;
using FileSysLib.Models;

namespace FileSysLib.IServices {
    /// <summary>
    /// 管理空闲盘块和空闲i节点，负责盘块与i节点的分配与回收
    /// </summary>
    public interface IDiskManagementService {
        /// <summary>
        /// 申请空闲盘块
        /// </summary>
        List<int> GetFreeBlocks(int num);

        /// <summary>
        /// 申请空闲i节点
        /// </summary>
        int GetFreeInode(FileMode fileMode);

        /// <summary>
        /// 回收盘块
        /// </summary>
        void RetrieveBlocks(List<int> blockList);

        /// <summary>
        /// 回收i节点
        /// </summary>
        void RetrieveInode(int index);

        /// <summary>
        /// 读取目录文件
        /// </summary>
        /// <param name="index"> i节点编号 </param>
        Dir ReadDir(int index);

        /// <summary>
        /// 读取文本文件
        /// </summary>
        /// <param name="index"> i节点编号 </param>
        string ReadText(int index);

        /// <summary>
        /// 写回目录文件
        /// </summary>
        void WriteDir(Dir dir, int index);

        /// <summary>
        /// 写回文本文件
        /// </summary>
        void WriteText(string text, int index);
    }
}
