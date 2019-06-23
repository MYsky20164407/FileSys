using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FileSysLib.Models;

namespace FileSysLib.ByteConverter {
    //TODO:待测试
    class ByteConverter {
        /// <summary>
        /// 转换器单件
        /// </summary>
        public static readonly ByteConverter byteConverter = new ByteConverter();

        /// <summary>
        /// 私有构造
        /// </summary>
        private ByteConverter() { }

        public byte[] ToBytes(Dir dir) {
            List<byte> bytes = new List<byte>();
            bytes.AddRange(BitConverter.GetBytes(dir.Size).ToList());
            dir.DirItems.ForEach(delegate(DirItem dirItem) {
                bytes.AddRange(ToBytes(dirItem).ToList());
            });
            return bytes.ToArray();
        }

        public byte[] ToBytes(DirItem dirItem) {
            List<byte> bytes = new List<byte>();
            bytes.AddRange(BitConverter.GetBytes(dirItem.NameSize).ToList());
            bytes.AddRange(System.Text.Encoding.Default.GetBytes(dirItem.Name).ToList());
            bytes.AddRange(BitConverter.GetBytes(dirItem.Inode));

            return bytes.ToArray();
        }
    }
}
