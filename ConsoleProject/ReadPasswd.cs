using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maui1
{
    public class ReadPasswd
    {

        public ReadPasswd()
        
        {
        }

        public string ReadPassword()
        {
            string passwd = "";
            ConsoleKeyInfo keyinfo;
            do
            {
                keyinfo = Console.ReadKey(true);
                if (keyinfo.Key != ConsoleKey.Backspace && keyinfo.Key != ConsoleKey.Enter)
                {
                    passwd += keyinfo.KeyChar;
                    Console.Write("*");

                }
                else if (keyinfo.Key == ConsoleKey.Backspace && passwd.Length > 0)
                {
                    passwd = passwd.Remove(passwd.Length - 1);
                    Console.Write("\b \b");
                }
                else if (keyinfo.Key == ConsoleKey.Delete && passwd.Length > 0)
                {
                    passwd = passwd.Remove(0, 1);
                    Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                    Console.Write(' ');
                    Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                }
            }
            while (keyinfo.Key != ConsoleKey.Enter);

            Console.WriteLine();
            return passwd;
        }

    }
}
