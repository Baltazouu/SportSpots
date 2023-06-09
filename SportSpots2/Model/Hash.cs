    
using System.Security.Cryptography;
using System.Text;

namespace Model
{
    /// <summary>
    /// Static Class to hash Passwords for users security
    /// </summary>
    public static class Hash
    {
        /// <summary>
        /// Method For HashPassord
        /// </summary>
        /// <param name="password">raw and clear password to hash</param>
        /// <returns>hashed password</returns>
        public static string HashPassword(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));
                    
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
