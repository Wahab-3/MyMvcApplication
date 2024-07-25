using RealEstateMvc.Models.Entities;
using RealEstateMvc.Models.Enum;

namespace RealEstate_Mvc_.Dtos
{
    public class TransactionRequestModel
    {
        public string Email { get; set; } = default!;
        public TYpeOfLeases TypeOfLeases { get; set; }
        public string PropertyId { get; set; } = default!;
        public string SellersEmail { get; set; } = default!;
        public bool IsSucessfull { get; set; }

    }
    public class TransactionResponseModel
    {
        public string RefNumber { get; set; } = default!;
        public string Email { get; set; } = default!;
        public double Price { get; set; }
        public string SellersEmail { get; set; } = default!;
        public string PropertyId { get; set; } = default!;
        public bool IsSucessfull { get; set; }
        public TYpeOfLeases TypeOfLeases { get; set; }
    }
}
