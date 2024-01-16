using System;
using System.IO;
using System.Security.Cryptography;

namespace FancyBit
{
    public class FileHash
    {
        public static string GetFileMD5Hash(string filePath)
        {
            using (var md5 = MD5.Create())
            {
                using (var stream = File.OpenRead(filePath))
                {
                    // 计算文件的MD5哈希值
                    var hashBytes = md5.ComputeHash(stream);

                    // 将哈希字节数组转换为十六进制字符串表示形式
                    return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
                }
            }
        }
    }
}
