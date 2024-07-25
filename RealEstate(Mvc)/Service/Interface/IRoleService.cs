using RealEstate_Mvc_.Dtos;

namespace RealEstate_Mvc_.Service.Interface
{
    public interface IRoleService
    {
        BaseResponce<RoleResponseModel> Create(RoleRequestModel role);
        BaseResponce<RoleResponseModel> GetByName(string Name);
        BaseResponce<List<RoleResponseModel>> GetAll();
        BaseResponce<RoleResponseModel> Update(RoleRequestModel role);
        BaseResponce<RoleResponseModel> Delete(string Name, string NewRoleName);
    }
}