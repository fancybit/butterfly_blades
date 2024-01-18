using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Reflection;
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
            //获取校验码
            Dictionary<string, string> hashes = new Dictionary<string, string>();
            if(File.Exists(ChecksumFileName)){
                hashes = JsonConvert.DeserializeObject<Dictionary<string, string>>(File.ReadAllText(ChecksumFileName));
            }

            // 获取当前进程
            Process currentProcess = Process.GetCurrentProcess();
            Console.WriteLine("模块自检中:", currentProcess.ProcessName);
            foreach (ProcessModule module in currentProcess.Modules)
            {
                //Console.WriteLine("\t{0} - {1}", module.ModuleName, module.FileName);
                var hash = FileHash.GetFileMD5Hash(module.FileName);
                if (!hashes.TryGetValue(module.FileName,out string oldHash)){
                    hashes[module.FileName] = hash;
                    Console.WriteLine($"文件{module.FileName}哈希不存在,已记录新哈希值：{hash}");
                }
                if (oldHash != hash)
                {
                    hashes[module.FileName] = hash;
                    Console.WriteLine($"文件{module.FileName}哈希改变,新哈希值：{hash}");
                }
            }
            //记录校验码
            File.WriteAllText(ChecksumFileName,JsonConvert.SerializeObject(hashes));

            Console.WriteLine("模块自检完成。");
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
