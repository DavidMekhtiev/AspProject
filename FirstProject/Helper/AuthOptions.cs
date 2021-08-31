using Microsoft.IdentityModel.Tokens;
using System.Text;


namespace FirstProject.Helper
{
    public class AuthOptions
    {
        public const string ISSUER = "MyAuthServer"; // издатель токена
        public const string AUDIENCE = "MyAuthClient"; // потребитель токена
        const string KEY = "ASDASDEFWEFASD!123";   // ключ для шифрации
        public const int LIFETIME = 1140; // время жизни токена - 1140 минут (24 часа)
        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }
    }

}
