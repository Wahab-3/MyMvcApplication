using RealEstate_Mvc_.Dtos;
using RealEstateMvc.Models.Entities;

namespace RealEstate_Mvc_.Service.Interface
{
    public interface ICustomerService
    {
        BaseResponce<CustomerResponseModel> Create(CustomerRequestModel customer);
        BaseResponce<CustomerResponseModel> GetByEmail(string Email);
        BaseResponce<CustomerResponseModel> AddMoneyToWallet(string Email, double amount);
        BaseResponce<CustomerResponseModel> GetById(string Id);
        BaseResponce<List<CustomerResponseModel>> GetAll();
        BaseResponce<CustomerResponseModel> Update(CustomerRequestModel customer);
        BaseResponce<CustomerResponseModel> Delete(string Email);
    }
}