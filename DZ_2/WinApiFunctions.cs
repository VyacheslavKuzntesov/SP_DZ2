using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DZ_2
{
    internal class WinApiFunctions
    {
        [DllImport("User32.dll")]
        public static extern int MessageBox(IntPtr hwnd, string message, string caption, uint decoration);
    }
}
