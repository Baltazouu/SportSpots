    
using System.Security.Cryptography;
using System.Text;

namespace Model
{
    public static class Hash
    {
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
                //Console.WriteLine(builder.ToString());
                return builder.ToString();
            }
        }

    }
}
