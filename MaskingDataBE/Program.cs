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
            user.Password = user.Password.MaskString("*", 4);
            Console.WriteLine("Name: " + user.Name + ", Password: " + user.Password);
        }
        Console.ReadKey();
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