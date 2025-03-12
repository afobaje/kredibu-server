using System.Security.Cryptography;
using System.Text;

class Utils
{
    public static string HashPassword(string password)
    {

        using (SHA256 sha256 = SHA256.Create())
        {
            byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            StringBuilder builder = new StringBuilder();
            foreach (var item in bytes)
            {
                builder.Append(item.ToString("x2"));

            }
            return builder.ToString();
        }
    }

    public bool verifyPassword(string hash, string passwordHash)
    {
        string hashedInput = HashPassword(hash);
        return hashedInput == passwordHash;

    }
}