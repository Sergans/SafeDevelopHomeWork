using SafeDevelopHomeWork_1.Data;
using SafeDevelopHomeWork_1.Models;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Linq;

namespace SafeDevelopHomeWork_1.Services
{
    public class UserOperation : IUserServices
    {
        private readonly DataBase _dataBaseUser;
        public UserOperation(DataBase dataBaseUser)
        {
            _dataBaseUser = dataBaseUser;
        }
        public bool AddUser(User user)
        {
            if (user != null)
            {
                var models = GetAll();
                foreach(var model in models)
                {
                    if (string.Compare(model.Email,user.Email)==0)
                    {
                      return false;
                }   }
                 user.Password = HashCode(user.Password);
                _dataBaseUser.Add(user);
                _dataBaseUser.SaveChanges();
                
            }
            return true; 
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<User> GetAll()
        {
            return _dataBaseUser.Users.ToList();
        }

        public User GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void UpDate(User user)
        {
            throw new NotImplementedException();
        }
        public string? Autorize(string mail,string password)
        {
            
            if (string.IsNullOrWhiteSpace(mail) || string.IsNullOrWhiteSpace(password))
            return null;

            foreach(var user in GetAll())
            {
                if(string.CompareOrdinal(user.Email, mail) == 0 && string.CompareOrdinal(user.Password, HashCode(password)) == 0)
                {
                    var now = DateTime.UtcNow;
                    var claim = new List<Claim>()
                    {

                      new Claim(ClaimsIdentity.DefaultNameClaimType, user.Email),
                      new Claim(ClaimsIdentity.DefaultRoleClaimType,user.Role)
                      
                    };
                    var jwt = new JwtSecurityToken(UserToken.Issuser,UserToken.Audience,claim,notBefore: now,expires: now.Add(TimeSpan.FromMinutes(UserToken.LifeTime)),signingCredentials: new SigningCredentials(UserToken.GetSymmetricSecurityKey(),SecurityAlgorithms.HmacSha256));
                    var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);
                    
                    return encodedJwt;
                }
            }
           return null;
           
        }
        public string HashCode(string password)
        {
            var sha512 = SHA512.Create();
            var hash = sha512.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(hash);
        }
    }
}
