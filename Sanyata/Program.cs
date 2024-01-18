using System;
using System.IO;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Newtonsoft.Json;
using FancyBit;

namespace Sanyata
{
    public class Program
    {
        public static bool Feeling = true;
        public static Dictionary<string, MethodInfo> CmdTable
            = new Dictionary<string, MethodInfo>();
        public const string ChecksumFileName = "checksum.dat";

        static void Main(string[] args)
        {
            var methods = typeof(Commands).GetMethods(BindingFlags.Static | BindingFlags.Public);
            foreach (var method in methods)
            {
                CmdTable.Add(method.Name.ToLower(), method);
            }

            Print(DateTime.Now.ToString());
            Print("feeling...");
            Task.Run(() =>
            {
                while (Feeling)
                {
                    SelfCheck();
                }
            });

            Task.Run(() =>
            {
                while (Feeling)
                {
                    OPCheck();
                }
            });

            Task.Run(() =>
            {
                while (Feeling)
                {
                    UICheck();
                }
            });

            Task.Run(() =>
            {
                while (Feeling)
                {
                    SpyCheck();
                }
            });

            Task.Run(() =>
            {
                while (Feeling)
                {
                    NetworkCheck();
                }
            });

            while (Feeling)
            {
                Console.WriteLine("请输入指令：");
                var inputCmd = Console.ReadLine();
                inputCmd = inputCmd.Trim();
                var secs = inputCmd.Split().Select(x => x as object).ToList();
                var cmdName = secs[0].ToString();
                secs.RemoveAt(0);
                var parm = string.Join(" ", secs.Select(x => x.ToString()).ToArray());
                if (Feeling && CmdTable.TryGetValue(cmdName, out var method))
                {
                    Print(DateTime.Now.ToString());
                    try
                    {
                        if (secs.Count > 1)
                        {
                            method.Invoke(null, new object[] { parm });
                        }
                        else
                        {
                            method.Invoke(null, new object[] { });
                        }
                    }
                    catch (Exception ex)
                    {
                        Print(ex.Message);
                        Print(ex.StackTrace);
                    }
                }
            }
            Print(DateTime.Now.ToString());
            Print("Stopped.");
            Console.ReadKey();
        }

        public static void Print(string text)
        {
            Console.WriteLine(text);
        }

        private static void SelfCheck()
        {
            //获取校验码
            Dictionary<string, string> hashes = new Dictionary<string, string>();
            if (File.Exists(ChecksumFileName))
            {
                hashes = JsonConvert.DeserializeObject<Dictionary<string, string>>(File.ReadAllText(ChecksumFileName));
            }

            // 获取当前进程
            Process currentProcess = Process.GetCurrentProcess();
            //Console.WriteLine("模块自检中:", currentProcess.ProcessName);
            foreach (ProcessModule module in currentProcess.Modules)
            {
                //Console.WriteLine("\t{0} - {1}", module.ModuleName, module.FileName);
                var hash = FileHash.GetFileMD5Hash(module.FileName);
                if (!hashes.TryGetValue(module.FileName, out string oldHash))
                {
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
            File.WriteAllText(ChecksumFileName, JsonConvert.SerializeObject(hashes));
            //Console.WriteLine("模块自检完成。");
        }

        private static void OPCheck()
        {

        }

        private static void UICheck()
        {
            //弹窗拦截

        }

        private static void SpyCheck()
        {

        }

        private static void NetworkCheck()
        {

        }
    }
}
