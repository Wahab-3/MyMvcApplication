
using RealEstateConsoleApp.Models;


namespace RealEstateConsoleApp.Repository
{
    public interface ITransactionRepository
    {
       public void CreateTransaction(Transaction  Transaction); 
       public Transaction GetTransactionById(int Id); 
       public Transaction GetTransactionByEmail( string email);
        public Transaction GetTransactionByPropertyId( int id);
       public List<Transaction> GetAllTransaction(); 

    }
}