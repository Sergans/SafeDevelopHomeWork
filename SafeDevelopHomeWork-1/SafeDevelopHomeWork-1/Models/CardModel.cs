﻿namespace SafeDevelopHomeWork_1.Models
{
    public class CardModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Famaly { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ValidPeriod { get; set; }
        public int NomberCard { get; set; }
        public int CCV { get; set; }
    }
}
