using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Sanyata
{
    public static class Commands
    {
        public static void Exit()
        {
            Program.Feeling = false;
        }

        public static void Msg(string message)
        {
            MessageBox.Show(message);
        }

        //弹窗拦截
        /// <summary>
        /// 捕捉并且拦截弹窗
        /// </summary>
        public static void BanWnd()
        {

        }

        /// <summary>
        /// 显示弹窗拦截列表
        /// </summary>
        public static void ShowWndBanList()
        {

        }
    }
}
