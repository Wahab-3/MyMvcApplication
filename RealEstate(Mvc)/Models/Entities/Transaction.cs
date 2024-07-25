using RealEstateMvc.Models.Enum;

namespace RealEstateMvc.Models.Entities
{
    public class Transaction
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string RefNumber { get; set; } = default!;
        public string Email { get; set; } = default!;
        public double Price { get; set; }
        public string SellersEmail { get; set; } = default!;
        public string PropertyId { get; set; }= default!;
        public Property Property { get; set; }= default!;
        public string? CustomerId { get; set; }
        public Customer? Customer { get; set; } 
        public bool IsSucessfull { get; set; }
        public string? DeletedBy { get; set; }
        public DateTime DateDeleted { get; set; } = DateTime.Now;
        public string? CreatedBy { get; set; }
        public DateTime? DateCrated { get; set; }
        public TYpeOfLeases TypeOfLeases { get; set; }
        public bool IsDeleted { get; set; }

    }
}