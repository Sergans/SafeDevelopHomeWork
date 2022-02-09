using SafeDevelopHomeWork_1.Data;
using SafeDevelopHomeWork_1.Models;

namespace SafeDevelopHomeWork_1.Services
{
    public class UserOperation : IOperationService<User>
    {

        ApplicationContext userbase = new ApplicationContext();
        public void Create(User model)
        {
            userbase.Users.Add(model);
            userbase.SaveChanges();
        }

        public bool Delete(int Id)
        {
            throw new NotImplementedException();
        }
        public bool Delete(string Name)
        {
            foreach (var user in GetAll())
            {
                if (user.UserName == Name)
                {
                    userbase.Users.Remove(user);
                    userbase.SaveChanges();
                    return true;
                }
            }
            return false;
        }


        public List<User> GetAll()
        {
            return userbase.Users.ToList();
        }

        public void UpDate()
        {
            throw new NotImplementedException();
        }
    }
}
