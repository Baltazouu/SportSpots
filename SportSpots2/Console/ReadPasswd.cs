using Model;

namespace ConsoleProject
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
            return Hash.HashPassword(passwd);
        }
        /// <summary>
        /// Fonction De Hashage SHA256 Pour hacher les mots de passe 
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
       
    }
}
