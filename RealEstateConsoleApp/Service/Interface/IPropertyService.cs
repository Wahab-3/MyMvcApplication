using RealEstateConsoleApp.Models;

namespace RealEstateConsoleApp.Service.Interface
{
    public interface IPropertyService
    {
        public void CreateProperty(string UserEmail, string Location, TypeOfLeases TypeOfLeases, double Price, string Description,int cartegoryId);
        public Property GetPropertyById(int id);
        public List<Property> GetPropertyByDescription(string description);
        public List<Property> GetPropertyByLocation(string location);
        public List<Property> GetPropertyByPrice(double Price);
        public List<Property> GetPropertyByCartegoryName(string CartegoryName);
        public List<Property> GetPropertyForRent();
        public List<Property> GetPropertyForSale();
        public void GetAllProperty();
        public void UpdateProperty(int Id, string CartegoryName, string Location, TypeOfLeases TypeOfLeases, double Price, string Description, bool IsAvailable, string OwnersTagNumber);
        public void DeleteProperty(int id);
        
    }
}