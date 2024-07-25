using RealEstateMvc.Models.Entities;
using RealEstateMvc.Models.Enum;

namespace RealEstate_Mvc_.Repository.Interface
{
    public interface IPropertyRepository
    {
        Property Create(Property property);
        Property GetById(string Id);
        List<Property> GetByOwnerId(string ownerId);
        List<Property> GetByLocation(string Location);
        List<Property> GetByPrice(double Price);
        List<Property> GetByDescription(string Description);
        List<Property> GetByCartegoryId(string CartegoryId);
        List<Property> GetByTypeOfLease(TYpeOfLeases TypeOfLeases);
        List<Property> GetByAvailability();
        List<Property> GetAll();
        Property Update(Property property);

    }
}