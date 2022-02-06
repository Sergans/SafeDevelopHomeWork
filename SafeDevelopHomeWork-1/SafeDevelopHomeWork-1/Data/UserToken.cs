using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace SafeDevelopHomeWork_1.Data
{
    public class UserToken
    {
        public const string Issuser = "https://localhost:7075";
        public const string Audience = Issuser;
        public const string Key = "secret_key_token_my_secret_big_secret";
        public const int LifeTime = 20;
        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Key));
        }
    }
}
