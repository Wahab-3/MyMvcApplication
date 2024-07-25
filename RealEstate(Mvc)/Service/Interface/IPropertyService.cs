using RealEstate_Mvc_.Dtos;
using RealEstateMvc.Models.Enum;

namespace RealEstate_Mvc_.Service.Interface
{
    public interface IPropertyService
    {
        BaseResponce<PropertyResponseModel> Create(PropertyRequestModel property);
        BaseResponce<PropertyResponseModel> GetById(string Id);
        BaseResponce<List<PropertyResponseModel>> GetByOwnerId(string ownerId);
        BaseResponce<List<PropertyResponseModel>> GetByLocation(string Location);
        BaseResponce<List<PropertyResponseModel>> GetByPrice(double Price);
        BaseResponce<List<PropertyResponseModel>> GetByDescription(string Description);
        BaseResponce<List<PropertyResponseModel>> GetByCartegoryId(string CartegoryId);
        BaseResponce<List<PropertyResponseModel>> GetByAvailability();
        BaseResponce<List<PropertyResponseModel>> GetByTypeOfLease(TYpeOfLeases TypeOfLeases);
        BaseResponce<List<PropertyResponseModel>> GetAll();
        BaseResponce<PropertyResponseModel> Update(PropertyRequestModel property);
        BaseResponce<PropertyResponseModel> Delete(string Id);
    }
}