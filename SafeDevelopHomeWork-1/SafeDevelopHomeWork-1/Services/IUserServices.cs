using SafeDevelopHomeWork_1.Models;
namespace SafeDevelopHomeWork_1.Services
{
    public interface IUserServices
    {
        void AddUser(User user);
        void Delete(int id);
        List<User> GetAll();
        User GetById(int id);
        void UpDate(User user);
    }
}
