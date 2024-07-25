using System.Transactions;
using RealEstateConsoleApp.Models;

namespace RealEstateConsoleApp.Service.Interface
{
    public interface ITransactionService
    {
        public void CreateTransaction(string UserEmail, int PropertyId);
        public Transaction GetTransactionById(int Id);
        public Transaction GetTransactionByEmail(string email);
        public Transaction GetTransactionByPropertyId(int id);
        public void GetAllTransaction();
        public void UpdateTransaction(int Id,int PropertyId,bool IsSucessfull,TypeOfLeases TypeOfLeases);
        public void DeleteTransaction(int id);
    }
}