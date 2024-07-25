using RealEstate_Mvc_.Dtos;
using RealEstateMvc.Models.Entities;

namespace RealEstate_Mvc_.Service.Interface
{
    public interface IOwnerService
    {
        BaseResponce<OwnerResponseModel> Create(OwnerRequestModel Owner);
        BaseResponce<OwnerResponseModel> GetByStaffNumber(string StaffNumber);
        BaseResponce<OwnerResponseModel> GetById(string Id);
        BaseResponce<OwnerResponseModel> GetByEmail(string Email);
        BaseResponce<List<OwnerResponseModel>> GetAll();
        BaseResponce<OwnerResponseModel> Update(OwnerRequestModel OwnerRequestModel);
        BaseResponce<OwnerResponseModel> Delete(string StaffNumber);
    }
}
