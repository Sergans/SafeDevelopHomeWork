using SafeDevelopHomeWork_1.Data;
using SafeDevelopHomeWork_1.Models;

namespace SafeDevelopHomeWork_1.Services
{
    public class UserOperation : IUserServices
    {
        private readonly DataBase _dataBaseUser;
        public UserOperation(DataBase dataBaseUser)
        {
            _dataBaseUser = dataBaseUser;
        }
        public void AddUser(User user)
        {
            if (user != null)
            {
                _dataBaseUser.Add(user);
                _dataBaseUser.SaveChanges();
            }
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
        public User Autorize(string mail,string password)
        {
            if (string.IsNullOrWhiteSpace(mail) || string.IsNullOrWhiteSpace(password))
            return null;

            foreach(var user in GetAll())
            {
                if(string.CompareOrdinal(user.Email, mail) == 0 && string.CompareOrdinal(user.Password, password) == 0)
                {
                    return user;
                }
            }
           return null;
            
        }
    }
}
