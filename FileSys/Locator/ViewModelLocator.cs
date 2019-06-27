using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileSysLib.IServices;
using FileSysLib.Services;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using FileSysLib.ViewModels;

namespace FileSys.Locator {
    class ViewModelLocator {
        /// <summary>
        ///     ViewModel定位器单件
        /// </summary>
        public static readonly ViewModelLocator Instance = new ViewModelLocator();

        public FrontEndViewModel FrontEndViewModel => SimpleIoc.Default.GetInstance<FrontEndViewModel>();
        public AccountViewModel AccountViewModel => SimpleIoc.Default.GetInstance<AccountViewModel>();

        /// <summary>
        ///     私有构造
        /// </summary>
        private ViewModelLocator() {
            SimpleIoc.Default.Register<IDiskConnectService, DiskConnectService>();
            SimpleIoc.Default.Register<IDiskAdapterService, DiskAdapterService>();
            SimpleIoc.Default.Register<IDiskManagementService, DiskManagementService>();
            SimpleIoc.Default.Register<ICoreService, CoreService>();
            SimpleIoc.Default.Register<IMemManagementService, MemManagementService>();

            SimpleIoc.Default.Register<FrontEndViewModel>();
            SimpleIoc.Default.Register<AccountViewModel>();


        }

    }
}
