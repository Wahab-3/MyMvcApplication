using RealEstate_Mvc_.Models.Entities;

namespace RealEstateMvc.Models.Entities
{
    public class Customer : Person
    { 
        public string TagNumber { get; set; } = default!;
        public List<Transaction> Transactions { get; set; } = new List<Transaction>();
        public double Wallet { get; set; } = 0;

        public string? ProfilePicturePath { get; set; }


    }
}