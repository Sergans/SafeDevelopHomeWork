using SafeDevelopHomeWork_1.Data;
using SafeDevelopHomeWork_1.Models;

namespace SafeDevelopHomeWork_1.Services
{
    public class CardOperation : IOperationService<CardModel>
    {
        ApplicationContext cardbase=new ApplicationContext();
        public void Create(CardModel model)
        {
            cardbase.Cards.Add(model);
            cardbase.SaveChanges();
        }

        public bool Delete(int Id)
        {
            foreach(var card in GetAll())
            {
                if(card.Id == Id)
                {
                    cardbase.Cards.Remove(card);
                    cardbase.SaveChanges();
                    return true;
                }
            }
            return false;
        }

        public List<CardModel> GetAll()
        {
           return cardbase.Cards.ToList();
        }

        public void UpDate()
        {
            throw new NotImplementedException();
        }
    }
}
