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
            _dataBaseCard.SaveChanges();
        }

        public void Delete(int id)
        {
            var card = GetById(id);
           _dataBaseCard.Cards.Remove(card);
           _dataBaseCard.SaveChanges();
        }

        public List<CardModel> GetAll()
        {
           return _dataBaseCard.Cards.ToList();
        }

        public CardModel GetById(int id)
        {
            var cards = GetAll();
            foreach (var card in cards)
            {
                if (card.Id == id)
                {
                    return card;
                }
            }
            return null;
          
        }

        public void UpDate(CardModel model)
        {
            var cards = GetAll();
            foreach (var card in cards)
            {
                if (card.Id == model.Id)
                {
                    card.Name = model.Name;
                    card.Famaly = model.Famaly;
                    card.CreatedDate = model.CreatedDate;
                    card.ValidPeriod = model.ValidPeriod;
                    card.CCV = model.CCV;
                    card.NomberCard = model.NomberCard;
                    _dataBaseCard.SaveChanges();
                }
            }
        }
    }
}
