using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography;
using System.Text;
using BCrypt.Net;
using Microsoft.Extensions.ObjectPool;

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

    public static string encryptPassword(string password)
    {
        // using (SHA256 sha256 = SHA256.Create())
        // {
        //     byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
        //     byte[] saltedPassword = new byte[passwordBytes.Length + salt.Length];
        //     Buffer.BlockCopy(passwordBytes, 0, saltedPassword, 0, passwordBytes.Length);
        //     Buffer.BlockCopy(salt, 0, saltedPassword, passwordBytes.Length, salt.Length);
        //     byte[] hashedBytes = sha256.ComputeHash(saltedPassword);
        //     byte[] hashedPasswordWithSalt = new byte[hashedBytes.Length + salt.Length];
        //     Buffer.BlockCopy(salt, 0, hashedPasswordWithSalt, 0, salt.Length);
        //     Buffer.BlockCopy(hashedBytes, 0, hashedPasswordWithSalt, salt.Length, hashedBytes.Length);
        //     return Convert.ToBase64String(hashedPasswordWithSalt);
        // }
        try
        {
            
            var hashedPassword= BCrypt.Net.BCrypt.HashPassword(password,workFactor:13);
            return hashedPassword;
        }
        catch (System.Exception ex)
        {
            WriteLine($"Encounted an exception {ex}");
            return ex.ToString();
            // throw;
        }

    }

    

  public bool compareHash(string enteredpassword,string hashedPassword)
  {
    var compared=BCrypt.Net.BCrypt.Verify(enteredpassword,hashedPassword);
    return compared;
  }  

   

    public bool verifyPassword(string hash, string passwordHash)
    {
        string hashedInput = HashPassword(hash);
        return hashedInput == passwordHash;

    }
}