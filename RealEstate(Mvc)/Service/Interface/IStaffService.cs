using RealEstate_Mvc_.Dtos;
using RealEstate_Mvc_.Models.Entities;

namespace RealEstate_Mvc_.Service.Interface
{
    public interface IStaffService
    {
        BaseResponce<StaffResponseModel> Create(StaffRequestModel Staff);
        BaseResponce<StaffResponseModel> GetByTagNumber(string StaffNumber);
        BaseResponce<StaffResponseModel> GetByEmail(string Email);
        BaseResponce<StaffResponseModel> GetById(string Id);
        BaseResponce<List<StaffResponseModel>> GetAll();
        BaseResponce<StaffResponseModel> Update(StaffRequestModel StaffRequestModel);
        BaseResponce<StaffResponseModel> Delete(string StaffNumber);
    }
}
