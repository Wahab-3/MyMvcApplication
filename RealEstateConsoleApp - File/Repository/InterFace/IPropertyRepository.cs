using RealEstateConsoleApp.Models;

namespace RealEstateConsoleApp.Repository.InterFace
{
    public interface IPropertyRepository
    {
        public void CreateProperty(Property property);
        public Property GetPropertyById(int id);
        public List<Property> GetPropertyByDescription(string description);
        public List<Property> GetPropertyByUserEmail(string UserEmail);
        public List<Property> GetPropertyByLocation(string location);
        public List<Property> GetPropertyByPrice(double Price);
        public List<Property> GetPropertyByCartegoryName(string CartegoryName);
        public List<Property> GetAllProperty();
          public void RefreshPropertyFile();
    }
}