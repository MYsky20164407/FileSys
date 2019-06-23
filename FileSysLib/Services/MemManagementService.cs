using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FileSysLib.IServices;
using FileSysLib.Models;

namespace FileSysLib.Services {
    public class MemManagementService : IMemManagementService {
        private IDiskAdapterService _diskAdapterService;
        private static List<File> OpenningFiles;

        public MemManagementService(IDiskAdapterService diskAdapterService) {
            OpenningFiles = new List<File>();
            _diskAdapterService = diskAdapterService;

        }
    }
}
