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
