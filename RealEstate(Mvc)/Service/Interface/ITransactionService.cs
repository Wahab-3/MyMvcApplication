using RealEstate_Mvc_.Dtos;

namespace RealEstate_Mvc_.Service.Interface
{
    public interface ITransactionService
    {
        BaseResponce<TransactionResponseModel> Create(TransactionRequestModel transaction);
        BaseResponce<TransactionResponseModel> GetByRefNumber(string RefNumber);
        BaseResponce<List<TransactionResponseModel>> GetByCustomerEmail(string CustomerEmail);
        BaseResponce<List<TransactionResponseModel>> GetByCustomerId(string Id);
        BaseResponce<List<TransactionResponseModel>> GetByPropertyId(string PropertyId);
        BaseResponce<List<TransactionResponseModel>> GetAll();
        BaseResponce<TransactionResponseModel> Update(string RefrenceNumber, TransactionRequestModel transactionRequestModel);
        BaseResponce<TransactionResponseModel> Delete(string RefNumber);
    }
}