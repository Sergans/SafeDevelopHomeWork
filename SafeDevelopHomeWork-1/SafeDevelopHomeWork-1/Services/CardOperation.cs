using SafeDevelopHomeWork_1.Models;
using SafeDevelopHomeWork_1.Data;

namespace SafeDevelopHomeWork_1.Services
{

    public class CardOperation : ICardServices
    {
        private readonly DataBaseCard _dataBaseCard;
        public CardOperation(DataBaseCard dataBaseCard)
        {
            _dataBaseCard= dataBaseCard;
        }
        public void AddCard(CardModel card)
        {
            _dataBaseCard.Cards.Add(card);
        }

        public void Delete()
        {
            throw new NotImplementedException();
        }

        public List<CardModel> GetAll()
        {
           return _dataBaseCard.Cards.ToList();
        }

        public CardModel GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void UpDate(int id)
        {
            throw new NotImplementedException();
        }
    }
}
