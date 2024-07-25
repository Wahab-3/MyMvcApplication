using RealEstateConsoleApp.Models;

namespace RealEstateConsoleApp.Repository.Implementation
{
    public class TransactionRepository : ITransactionRepository
    {
        public void CreateTransaction(Transaction Transaction)
        {
            var context = ContextClass.transactions;
            context.Add(Transaction);
        }

        public List<Transaction> GetAllTransaction()
        {
            var context = ContextClass.transactions;
            return context;
        }

        public Transaction GetTransactionByEmail(string email)
        {
            var context = ContextClass.transactions;
            foreach (var item in context)
            {
                if (item.UserEmail == email)
                {
                    return item;
                }
            }
            return null;
        }

        public Transaction GetTransactionById(int Id)
        {
            var context = ContextClass.transactions;
            foreach (var item in context)
            {
                if (item.Id == Id)
                {
                    return item;
                }
            }
            return null;
        }

        public Transaction GetTransactionByPropertyId(int id)
        {
            var context = ContextClass.transactions;
            foreach (var item in context)
            {
                if (item.PropertyId == id)
                {
                    return item;
                }
            }
            return null;
        }
    }
}