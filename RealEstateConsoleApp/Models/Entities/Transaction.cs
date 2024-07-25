using RealEstateConsoleApp.Models;

namespace RealEstateConsoleApp
{
    public class Transaction  : BaseEntity
    {
        public string UserEmail { get; set;}
        public double TotalPrice { get; set; }
        public int PropertyId { get; set; }
        public bool IsSucessfull{get; set;}
        public TypeOfLeases TypeOfLeases { get; set; }



        public Transaction(int id,string userEmail,double totalPrice,int propertyId,TypeOfLeases typeOfLeases,bool isSucessfull ) : base(id)
        {
            Id = id;
            UserEmail = userEmail;
            TotalPrice = totalPrice;
            PropertyId = propertyId;
            TypeOfLeases = typeOfLeases;
            IsSucessfull = isSucessfull;
        }
    }
}