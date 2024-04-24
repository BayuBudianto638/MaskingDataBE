using System.Security.Cryptography;
using System.Text;

static class Program
{
    static void Main(string[] args)
    {
        List<User> users = new List<User>
        {
            new User { Name = "John Doe", Password = "secret123" },
            new User { Name = "Jane Smith", Password = "password456" }
        };

        foreach (User user in users)
        {
            //var length = user.Password.Length - 4;
            //user.Password = GetSHA256Hash(user.Password.Substring(0, length));
            user.Password = user.Password.MaskString("*", 4);
            Console.WriteLine("Name: " + user.Name + ", Password: " + user.Password);
        }
        Console.ReadKey();
    }

    public static string GetSHA256Hash(string data)
    {
        using (var sha256 = SHA256.Create())
        {
            byte[] dataBytes = Encoding.UTF8.GetBytes(data);
            byte[] hash = sha256.ComputeHash(dataBytes);
            string hashString = Convert.ToHexString(hash);

            return hashString;
        }
    }
}


public static class ExtensionMethods
{
    public static string MaskString(this string stringToMask, string mask, int show)
    {
        return stringToMask.ToCharArray().Aggregate("", (maskedString, nextValueToMask) =>
            maskedString + (maskedString.Length < stringToMask.Length - show ? mask : nextValueToMask.ToString()));
    }
}

public class User
{
    public string Name { get; set; }
    public string Password { get; set; }
}