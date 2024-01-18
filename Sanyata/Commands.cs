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

    }
}
