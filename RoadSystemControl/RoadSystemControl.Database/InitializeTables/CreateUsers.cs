using System.Security.Cryptography;
using RoadSystemControl.Domains.Enums;
using RoadSystemControl.Domains.Models;

namespace RoadSystemControl.Database.InitializeTables;

public class CreateUsers
{
    public static void Init(RscContext dbContext)
    {
        var entity1 = new User { Login = "CherryPick", Role = UserRole.Operator, Password = HashPassword("1231") };
        var entity2 = new User { Login = "Rostat", Role = UserRole.User, Password = HashPassword("1232") };
        var entity3 = new User { Login = "RSCLog", Role = UserRole.Operator, Password = HashPassword("1233") };
        var entity4 = new User { Login = "Root", Role = UserRole.Admin, Password = HashPassword("1234") };

        dbContext.Users.Add(entity1);
        dbContext.Users.Add(entity2);
        dbContext.Users.Add(entity3);
        dbContext.Users.Add(entity4);

        dbContext.SaveChanges();
    }

    private static string HashPassword(string password)
    {
        byte[] salt;
        
        new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);
        
        var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 100000);
        var hash = pbkdf2.GetBytes(20);
        var hashBytes = new byte[36];
        
        Array.Copy(salt, 0, hashBytes, 0, 16);
        Array.Copy(hash, 0, hashBytes, 16, 20);
        
        return Convert.ToBase64String(hashBytes);
    }
}