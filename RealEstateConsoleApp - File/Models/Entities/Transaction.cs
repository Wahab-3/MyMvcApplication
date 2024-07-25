using RealEstateConsoleApp.Models;

namespace RealEstateConsoleApp
{
    public class Transaction : BaseEntity
    {
        public string UserEmail { get; set; }
        public double TotalPrice { get; set; }
        public int PropertyId { get; set; }
        public bool IsSucessfull { get; set; }
        public TypeOfLeases TypeOfLeases { get; set; }



        // public Transaction(int id, string userEmail, double totalPrice, int propertyId, TypeOfLeases typeOfLeases, bool isSucessfull) : base(id)
        // {
        //     Id = id;
        //     UserEmail = userEmail;
        //     TotalPrice = totalPrice;
        //     PropertyId = propertyId;
        //     TypeOfLeases = typeOfLeases;
        //     IsSucessfull = isSucessfull;
        // }



        public string ToString()
        {
            return $"{Id}\t{UserEmail}\t{TotalPrice}\t{PropertyId}\t{TypeOfLeases}\t{IsSucessfull}";
        }

        public static Transaction ToObject(string a)
        {
            var data = a.Split('\t');
            Transaction transaction = new Transaction
            {
                Id = int.Parse(data[0]),
                UserEmail = data[1],
                TotalPrice = double.Parse(data[2]),
                PropertyId = int.Parse(data[3]),
                TypeOfLeases = (TypeOfLeases)Enum.Parse(typeof(TypeOfLeases), data[4]),
                IsSucessfull = bool.Parse(data[5])
            };
            return transaction;
        }
    }
}