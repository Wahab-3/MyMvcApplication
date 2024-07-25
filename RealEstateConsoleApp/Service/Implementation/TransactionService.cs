


using RealEstateConsoleApp.Models;
using RealEstateConsoleApp.Repository;
using RealEstateConsoleApp.Repository.Implementation;
using RealEstateConsoleApp.Repository.InterFace;
using RealEstateConsoleApp.Service.Interface;

namespace RealEstateConsoleApp.Service.Implementation
{
    public class TransactionService : ITransactionService
    {
        ITransactionRepository transactionRepository = new TransactionRepository();
        IPropertyRepository propertyRepository = new PropertyRepository();

        public void CreateTransaction(string UserEmail, int PropertyId)
        {
            var property = propertyRepository.GetPropertyById(PropertyId);
            var newTransaction = new Transaction(ContextClass.transactions.Count + 1, UserEmail, property.Price, PropertyId, property.TypeOfLeases, true);
            transactionRepository.CreateTransaction(newTransaction);
        }

        public void DeleteTransaction(int id)
        {
            var getTransactionById = transactionRepository.GetTransactionById(id);
            if (getTransactionById == null)
            {
                System.Console.WriteLine("transaction does not exist");
            }
            ContextClass.transactions.Remove(getTransactionById);
        }

        public void GetAllTransaction()
        {
            var getAll = transactionRepository.GetAllTransaction();
            if (getAll == null)
            {
                System.Console.WriteLine(" no transaction added yet");
            }
            else
            {
                foreach (var item in getAll)
                {
                    System.Console.WriteLine($"{item.Id}. TransactionUserEmail :{item.UserEmail} PropertyId : {item.PropertyId} PropertyPrice :{item.TotalPrice}  PropertyLeaseType : {item.TypeOfLeases} ");

                }
            }

        }

        public Transaction GetTransactionByEmail(string email)
        {
            var getTransactionByemail = transactionRepository.GetTransactionByEmail(email);
            if (getTransactionByemail == null)
            {
                System.Console.WriteLine("transaction does not exist");
                return null;
            }
            return getTransactionByemail;
        }

        public Transaction GetTransactionById(int Id)
        {
            var getTransactionById = transactionRepository.GetTransactionById(Id);
            if (getTransactionById == null)
            {
                System.Console.WriteLine("transaction does not exist");
                return null;
            }
            return getTransactionById;
        }

        public Transaction GetTransactionByPropertyId(int id)
        {
            var getTransactionByPropertyId = transactionRepository.GetTransactionByPropertyId(id);
            if (getTransactionByPropertyId == null)
            {
                System.Console.WriteLine("transaction does not exist");
                return null;
            }
            return getTransactionByPropertyId;
        }

        public void UpdateTransaction(int Id, int PropertyId, bool IsSucessfull, TypeOfLeases TypeOfLeases)
        {
            var getTransactionById = transactionRepository.GetTransactionById(Id);
            if (getTransactionById == null)
            {
                System.Console.WriteLine(" transaction does not exist");

            }
            getTransactionById.IsSucessfull = IsSucessfull;
            getTransactionById.TypeOfLeases = TypeOfLeases;
        }
    }
}