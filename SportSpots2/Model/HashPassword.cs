using System.Text;
using System.Security.Cryptography;
namespace Model
{
    public class HashPassword
    {

        public static string Hash(string password)
        {
            if (password.Length < 6)
            {
                InvalidInputExcept ex = new("Password Lenght Exeption");
            }
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



