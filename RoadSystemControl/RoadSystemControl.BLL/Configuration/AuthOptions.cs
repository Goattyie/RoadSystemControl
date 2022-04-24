using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace RoadSystemControl.BLL.Configuration;

public class AuthOptions
{
    public const string ISSUER = "RscApi";
    public const string AUDIENCE = "RscClient";
    public const int LIFETIME = 1;
    const string KEY = "RscSuperSecretKey123321OSGOATTYIE";
    public static SymmetricSecurityKey GetSymmetricSecurityKey()
    {
        return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(KEY));
    }
}