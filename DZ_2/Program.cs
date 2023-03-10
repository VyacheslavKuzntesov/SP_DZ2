using DZ_2;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Text;

var strTitle1 = string.Empty;
var strTitle = string.Empty;

while (true)
{
    var handle = WinApiFunctions.GetForegroundWindow();
    var intLength = WinApiFunctions.GetWindowTextLength(handle) + 1;
    var stringBuilder = new StringBuilder(intLength);

    if (WinApiFunctions.GetWindowText(handle, stringBuilder, intLength) > 0)
    {
        strTitle = stringBuilder.ToString();
    }

    if (strTitle != strTitle1)
    {
        bool LaunchType;
        WindowsIdentity identity = WindowsIdentity.GetCurrent();
        WindowsPrincipal principal = new WindowsPrincipal(identity);
        LaunchType = principal.IsInRole(WindowsBuiltInRole.Administrator);

        Console.Clear();

        if (LaunchType == true) Console.WriteLine("Наша программа была запущена от имени администратора");
        else Console.WriteLine("Наша программа не была запущена от имени администратора");

        Console.WriteLine($"Заголовок активного окна: {strTitle}");
        strTitle1 = strTitle;
    }
}

//Практика
/*
var Result = WinApiFunctions.MessageBox(IntPtr.Zero, "Вы уверены, что хотите полететь на Марс?", "Вопрос", 4);

if (Result == 6) WinApiFunctions.MessageBox(IntPtr.Zero, "Тогда свяжитесь с Илоном!", "Полёт на марс", 0);
*/