using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using FileSysLib.IServices;
using FileSysLib.Models;

namespace FileSysLib.Services {
    //TODO 待测试
    public class CoreService : ICoreService {
        private IDiskManagementService _diskManagementService;
        private IMemManagementService _memManagementService;

        public CoreService(IDiskManagementService diskManagementService,
                           IMemManagementService memManagementService) {
            _diskManagementService = diskManagementService;
            _memManagementService = memManagementService;
        }

        public void CreatFile(User user, string fileName, int curDirIndex) {
            Dir curDir = _diskManagementService.ReadDir(curDirIndex);
            if (curDir.DirItems.Exists(i => i.Name == fileName))
                return;
            int newInode = _diskManagementService.GetFreeInode(FileMode.Text);
            curDir.Size++;
            curDir.DirItems.Add(new DirItem() {
                NameSize = fileName.Length,
                Name = fileName,
                Inode = newInode
            });
            _diskManagementService.WriteDir(curDir, curDirIndex);
        }

        public void DeleteFile(User user, string fileName, int curDirIndex) {
            Dir curDir = _diskManagementService.ReadDir(curDirIndex);
            int tIndex = curDir.DirItems.FindIndex(i => i.Name == fileName);
            int curIndex = curDir.DirItems[tIndex].Inode;
            //修改文件所在目录，写回
            curDir.DirItems.RemoveAt(tIndex);
            curDir.Size--;
            _diskManagementService.WriteDir(curDir, curDirIndex);
            //回收文件对应的i节点
            _diskManagementService.RetrieveInode(curIndex);
        }

        public void OpenFile() {
            throw new NotImplementedException();
        }

        public void CloseFIle() {
            throw new NotImplementedException();
        }

        public void ReadFile() {
            throw new NotImplementedException();
        }

        public void WriteFile() {
            throw new NotImplementedException();
        }

        public void MakeDir() {
            throw new NotImplementedException();
        }

        public void DeleteDir() {
            throw new NotImplementedException();
        }

        public void OpenDir() {
            throw new NotImplementedException();
        }

        public void CloseDir() {
            throw new NotImplementedException();
        }

        public void Select() {
            throw new NotImplementedException();
        }
    }
}
