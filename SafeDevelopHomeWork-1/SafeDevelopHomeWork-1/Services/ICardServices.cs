using SafeDevelopHomeWork_1.Models;
namespace SafeDevelopHomeWork_1.Services

{
    public interface ICardServices
    {
        void AddCard(CardModel card);
        void Delete(int id);
        List<CardModel> GetAll();
        CardModel GetById(int id);
        void UpDate(int id);
    }
}
