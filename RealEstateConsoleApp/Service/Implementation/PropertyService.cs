using RealEstateConsoleApp.Models;
using RealEstateConsoleApp.Repository;
using RealEstateConsoleApp.Repository.Implementation;
using RealEstateConsoleApp.Repository.InterFace;
using RealEstateConsoleApp.Service.Interface;

namespace RealEstateConsoleApp.Service.Implementation
{
    public class PropertyService : IPropertyService
    {
        IOwnerRepository ownerRepository = new OwnerRepository();
        IUserRepository userRepository = new UserRepository();
        IPropertyRepository propertyRepository = new PropertyRepository();
        ICartegoryRepository cartegoryRepository = new CartegoryRepository();

        public void CreateProperty(string UserEmail, string Location, TypeOfLeases TypeOfLeases, double Price, string Description, int cartegoryId)
        {
            var getUser = userRepository.GetUserByEmail(UserEmail);
            int tagnumber = getUser.Id;
            var getCartegoryById = cartegoryRepository.GetCartegoryById(cartegoryId);
            var newProperty = new Property(ContextClass.properties.Count + 1, cartegoryId, Location, Price, true, Description, tagnumber.ToString(), UserEmail, getCartegoryById.Name, TypeOfLeases);
            propertyRepository.CreateProperty(newProperty);
        }

        public void DeleteProperty(int id)
        {
            var getPropertyById = propertyRepository.GetPropertyById(id);
            if (getPropertyById == null)
            {
                System.Console.WriteLine("Property does not exist");
            }
            ContextClass.properties.Remove(getPropertyById);
        }

        public void GetAllProperty()
        {
            var getAll = propertyRepository.GetAllProperty();
            if (getAll == null)
            {
                System.Console.WriteLine(" no Property added yet");
            }
            else
            {
                foreach (var item in getAll)
                {
                    System.Console.WriteLine($"Id :{item.Id}. CartegoryName :{item.CartegoryName} PropertyLocation : {item.Location} TypeOfLease :{item.TypeOfLeases}  PropertyPrice : {item.Price}  IsAvaillable : {item.IsAvailable}  propertyDescription :{item.Description}  OwnerTagNumber :{item.OwnersTagNumber}");
                }
            }
        }

        public List<Property> GetPropertyByCartegoryName(string CartegoryName)
        {
            var getPropertyByCartegoryName = propertyRepository.GetPropertyByCartegoryName(CartegoryName);
            if (getPropertyByCartegoryName == null)
            {
                System.Console.WriteLine("Property does not exist");
                // return null;
            }
            return getPropertyByCartegoryName;
        }

        public List<Property> GetPropertyByDescription(string description)
        {
            var getPropertyByCartegoryName = propertyRepository.GetPropertyByDescription(description);
            if (getPropertyByCartegoryName == null)
            {
                System.Console.WriteLine("Property does not exist");
                return null;
            }
            return getPropertyByCartegoryName;
        }

        public Property GetPropertyById(int id)
        {
            var getPropertyById = propertyRepository.GetPropertyById(id);
            if (getPropertyById == null)
            {
                System.Console.WriteLine("Property does not exist");
                return null;
            }
            return getPropertyById;
        }

        public List<Property> GetPropertyByLocation(string location)
        {
            var getPropertyBylocation = propertyRepository.GetPropertyByLocation(location);
            if (getPropertyBylocation == null)
            {
                System.Console.WriteLine("Property does not exist");
                return null;
            }
            return getPropertyBylocation;
        }

        public List<Property> GetPropertyByPrice(double Price)
        {
            var getPropertyByPrice = propertyRepository.GetPropertyByPrice(Price);
            if (getPropertyByPrice == null)
            {
                System.Console.WriteLine("Property does not exist");
            }
            return getPropertyByPrice;
        }

        public List<Property> GetPropertyForRent()
        {
            var newList = new List<Property>();

            var getAll = propertyRepository.GetAllProperty();
            foreach (var item in getAll)
            {
                if (item.TypeOfLeases == TypeOfLeases.ForRent)
                {
                    newList.Add(item);
                }
            }
            return newList;

        }

        public List<Property> GetPropertyForSale()
        {
            var newList = new List<Property>();

            var getAll = propertyRepository.GetAllProperty();
            foreach (var item in getAll)
            {
                if (item.TypeOfLeases == TypeOfLeases.ForSale)
                {
                    newList.Add(item);

                }
            }
            return newList;

        }

        public void UpdateProperty(int Id, string CartegoryName, string Location, TypeOfLeases TypeOfLeases, double Price, string Description, bool IsAvailable, string OwnersTagNumber)
        {
            var getPropertyById = propertyRepository.GetPropertyById(Id);
            if (getPropertyById == null)
            {
                System.Console.WriteLine(" Property does not exist");

            }
            getPropertyById.CartegoryName = CartegoryName;
            getPropertyById.Location = Location;
            getPropertyById.Price = Price;
            getPropertyById.IsAvailable = IsAvailable;
            getPropertyById.Description = Description;
            getPropertyById.OwnersTagNumber = OwnersTagNumber;
        }

    }
}