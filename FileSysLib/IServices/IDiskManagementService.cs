using System;
using System.Collections.Generic;
using System.Text;

namespace FileSysLib.IServices {
    /// <summary>
    /// 管理空闲盘块和空闲i节点，负责盘块与i节点的分配与回收
    /// </summary>
    public interface IDiskManagementService {
        /// <summary>
        /// 申请空闲盘块
        /// </summary>
        void GetFreeBlock();

        /// <summary>
        /// 申请空闲i节点
        /// </summary>
        void GetFreeInode();

        /// <summary>
        /// 回收盘块
        /// </summary>
        void RetrieveBlock(int index);

        /// <summary>
        /// 回收i节点
        /// </summary>
        void RetrieveInode(int index);
    }
}
