using System;
using System.Collections.Generic;
using System.Text;
using FileSysLib.IServices;
using FileSysLib.Models;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace FileSysLib.ViewModels {
    public class FrontEndViewModel :ViewModelBase {
        private ICoreService _coreService;
        private IDiskAdapterService _diskAdapterService;
        private IDiskManagementService _diskManagementService;
        private int curDirInode;
        private User curUser;
        private string fileName;

        public FrontEndViewModel(ICoreService coreService, IDiskAdapterService diskAdapterService,
                                 IDiskManagementService diskManagementService) {
            _coreService = coreService;
            _diskAdapterService = diskAdapterService;
            _diskManagementService = diskManagementService;
            curDirInode = 0;
        }

        /// <summary>
        /// 目录列表
        /// </summary>
        private List<ViewFile> _dirList = new List<ViewFile>() {
            new ViewFile(){Name = "root", FileMode = 0, Inode = 0}
        };
        public List<ViewFile> DirList {
            get => _dirList;
            set => Set(nameof(DirList), ref _dirList, value);
        }

        private RelayCommand _creatFile;
        public RelayCommand CreatFile => _creatFile ?? (_creatFile = new RelayCommand(() => {
            _coreService.CreatFile(curUser, fileName, curDirInode);
            Dir dir = _diskManagementService.ReadDir(curDirInode);
            List<ViewFile> tDirList = new List<ViewFile>();
            dir.DirItems.ForEach(delegate(DirItem dirItem) {
                tDirList.Add(new ViewFile() {
                    Name = dirItem.Name,
                    Inode = dirItem.Inode,
                    FileMode = _diskAdapterService.ReadDiskInode(dirItem.Inode).Mode
                });
            });
            DirList = tDirList;
        }));
    }
}
