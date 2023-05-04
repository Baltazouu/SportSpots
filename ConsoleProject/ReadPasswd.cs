using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Maui1
{
    public class ReadPasswd
    {

        public ReadPasswd() {}

        public static string ReadPassword()
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
            return HashPassword(passwd);
        }
        /// <summary>
        /// Fonction De Hashage SHA256 Pour hacher les mots de passe 
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public static string HashPassword(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // Convertir le mot de passe en tableau de bytes
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));

                // Convertir le tableau de bytes en chaîne de caractères hexadécimaux
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                Console.WriteLine(builder.ToString());  
                return builder.ToString();
            }
        }

    }
}
