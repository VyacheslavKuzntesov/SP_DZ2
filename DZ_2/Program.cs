﻿using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Text;

[DllImport("user32.dll")]
static extern IntPtr GetForegroundWindow();

[DllImport("user32.dll")]
static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int count);

[DllImport("user32.dll")]
static extern int GetWindowTextLength(IntPtr hWnd);

var strTitle1 = string.Empty;
var strTitle = string.Empty;

while (true)
{
    var handle = GetForegroundWindow();
    var intLength = GetWindowTextLength(handle) + 1;
    var stringBuilder = new StringBuilder(intLength);
    if (GetWindowText(handle, stringBuilder, intLength) > 0)
    {
        strTitle = stringBuilder.ToString();
    }
    if (strTitle != strTitle1)
    {
        /*bool isElevated;
        WindowsIdentity identity = WindowsIdentity.GetCurrent();
        WindowsPrincipal principal = new WindowsPrincipal(identity);
        isElevated = principal.IsInRole(WindowsBuiltInRole.Administrator);
        */
        Console.Clear();
        //Console.WriteLine(isElevated);
        Console.WriteLine(strTitle);
        strTitle1 = strTitle;
    }
}