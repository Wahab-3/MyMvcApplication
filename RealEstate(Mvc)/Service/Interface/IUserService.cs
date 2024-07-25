
using RealEstate_Mvc_.Dtos;
using RealEstateMvc.Models.Entities;

namespace RealEstate_Mvc_.Service.Interface
{
    public interface IUserService
    {

        BaseResponce<UserResponseModel> Create(UserRequestModel user, string RoleName, string RoleDesciption);
        BaseResponce<UserResponseModel> Get(string email);
        BaseResponce<UserResponseModel> Login(UserLoginRequestModel userLoginRequestModel);
        BaseResponce<List<UserResponseModel>> GetByRoleId(string Id);
        BaseResponce<List<UserResponseModel>> GetAll();
        BaseResponce<UserResponseModel> Update(UserRequestModel userRequestModel);
        BaseResponce<UserResponseModel> Delete(string Email);
    }
}