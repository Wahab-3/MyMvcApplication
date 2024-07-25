using RealEstateConsoleApp.Models;
using RealEstateConsoleApp___File;

namespace RealEstateConsoleApp.Repository.Implementation
{
    public class TransactionRepository : ITransactionRepository
    {

        string FilePath = Path.Combine(FileContext.FilePath, "Transaction.txt");
       
        public void CreateTransaction(Transaction Transaction)
        {
            var context = ContextClass.transactions;
            using (var str = new StreamWriter(FilePath, true))
            {
                str.WriteLine(Transaction.ToString());
            };
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


        public void RefreshTransactionFile()
        {
            using (var strm = new StreamWriter(FilePath, false))
            {
                foreach (var item in ContextClass.transactions)
                {
                    strm.WriteLine(item.ToString());
                }
            }
        }

      
    }
}