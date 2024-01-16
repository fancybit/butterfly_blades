using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using FancyBit;

namespace Sanyata
{
    public class Program
    {
        public static bool Feeling = true;
        public const string ChecksumFileName = "checksum.dat";

        static void Main(string[] args)
        {
            Console.WriteLine("feeling...");
            while (Feeling)
            {
                SelfCheck();
                OPCheck();
                UICheck();
                SpyCheck();
                NetworkCheck();
            }
            Console.WriteLine("stopped.");
        }

        private static void SelfCheck()
        {
            Dictionary<string, string> hashes = new Dictionary<string, string>();
            //获取校验码
            if(File.Exists(ChecksumFileName)){
                hashes = JsonConvert.DeserializeObject<Dictionary<string, string>>(File.ReadAllText(ChecksumFileName));
            }

            // 获取当前进程
            Process currentProcess = Process.GetCurrentProcess();

            Console.WriteLine("当前进程({0})加载的模块:", currentProcess.ProcessName);

            // 遍历所有模块
            foreach (ProcessModule module in currentProcess.Modules)
            {
                Console.WriteLine("\t{0} - {1}", module.ModuleName, module.FileName);
                var hash = FileHash.GetFileMD5Hash(module.FileName);
                Console.WriteLine($"计算结果:{hash}");
                if (!hashes.TryGetValue(module.FileName,out string oldHash)){
                    hashes[module.FileName] = hash;
                    Console.WriteLine($"文件{module.FileName}哈希不存在,已记录新哈希值：{hash}");
                }

            }

            Console.ReadLine();
        }

        private static void OPCheck()
        {

        }

        private static void UICheck()
        {

        }

        private static void SpyCheck()
        {

        }

        private static void NetworkCheck()
        {

        }
    }
}
