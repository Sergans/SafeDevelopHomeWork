using Microsoft.AspNetCore.Identity;

namespace SafeDevelopHomeWork_1.Models
{
    public class CardModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Famaly { get; set; }
        public string CreatedDate { get; set; }
        public string ValidPeriod { get; set; }
        public string NomberCard { get; set; }
        public int CCV { get; set; }
    }
}
