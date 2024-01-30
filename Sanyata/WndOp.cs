using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sanyata
{
    public static class WndOp
    {
        public static HashSet<Tuple<string,string>> BanWndList = new HashSet<Tuple<string, string>>();

        public static void BanWindow(string className,string windowTitle)
        {
            BanWndList.Add(new Tuple<string,string> (className,windowTitle));
        }

        private static bool EnumWindowsCallback(IntPtr hWnd, IntPtr lParam)
        {
            // 获取窗口标题
            StringBuilder windowTitle = new StringBuilder(256);
            WINAPIS.GetWindowText(hWnd, windowTitle, windowTitle.Capacity);
            // 获取窗口类
            StringBuilder className = new StringBuilder(256);

            var wndInfo = new Tuple<string,string> (className.ToString(),windowTitle.ToString());

            if (BanWndList.Contains(wndInfo))
            {

                Program.Print($"拦截关闭窗体{windowTitle}");
            }

            // 输出窗口信息
            Console.WriteLine($"Window Handle: {hWnd}, Window Title: {windowTitle}");

            // 继续枚举下一个窗口
            return true;
        }
    }
}
