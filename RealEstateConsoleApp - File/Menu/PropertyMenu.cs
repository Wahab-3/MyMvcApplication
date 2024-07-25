using System.Security.Cryptography.X509Certificates;
using RealEstateConsoleApp.Models;
using RealEstateConsoleApp.Models.Entities;
using RealEstateConsoleApp.Repository.Implementation;
using RealEstateConsoleApp.Service.Implementation;
using RealEstateConsoleApp.Service.Interface;

namespace RealEstateConsoleApp.Menu
{
    public class PropertyMenu
    {
        IPropertyService propertyService = new PropertyService();

        ICartegoryService cartegoryService = new CartegoryService();
        public void PropertyMainMenuForOwner()
        {
            try
            {
                System.Console.WriteLine("Enter 1 to get all Property\nEnter 2 to Get Property By Id\n Enter 3 to Get Property By CartegoryName\nEnter 4 to Get Property By Description\nEnter 5 to Get Property By Location\nEnter 6 to Get Property By Price\nEnter # to Exit\nEnter 7 to update property\nEnter 8 to create property");
                string ans = Console.ReadLine();
                if (ans == "1")
                {
                    GetAllProperty();
                    PropertyMainMenuForOwner();
                }
                else if (ans == "2")
                {
                    GetPropertyById();
                    PropertyMainMenuForOwner();

                }
                else if (ans == "3")
                {
                    GetPropertyByCartegoryName();
                    PropertyMainMenuForOwner();

                }
                else if (ans == "4")
                {
                    GetPropertyByDescription();
                    PropertyMainMenuForOwner();
                }
                else if (ans == "5")
                {
                    GetPropertyByLocation();
                    PropertyMainMenuForOwner();
                }
                else if (ans == "6")
                {
                    GetPropertyByPrice();
                    PropertyMainMenuForOwner();
                }
                else if (ans == "7")
                {
                    UpdateProperty();
                    PropertyMainMenuForOwner();
                }
                else if (ans == "#")
                {
                    OwnerMenu ownerMenu = new OwnerMenu();
                    ownerMenu.OwnerNewMainMenu();
                }
                else if (ans == "8")
                {
                    CreateProperty();
                    PropertyMainMenuForOwner();
                }
                else
                {
                    System.Console.WriteLine("++++Wrong Input++++");
                    PropertyMainMenuForOwner();

                }
            }


            catch (System.Exception)
            {
                System.Console.WriteLine("=====Wrong input======");
                PropertyMainMenuForOwner();
            }
        }
        public void PropertyMainMenuForManager()
        {
            try
            {
                System.Console.WriteLine("Enter 1 to get all Property\nEnter 2 to Get Property By Id\n Enter 3 to Get Property By CartegoryName\nEnter 4 to Get Property By Description\nEnter 5 to Get Property By Location\nEnter 6 to Get Property By Price\nEnter # to Exit\nEnter 7 to update property\nEnter 8 to create property");
                string ans = Console.ReadLine();
                if (ans == "1")
                {
                    GetAllProperty();
                    PropertyMainMenuForManager();

                }
                else if (ans == "2")
                {
                    GetPropertyById();
                    PropertyMainMenuForManager();

                }
                else if (ans == "3")
                {
                    GetPropertyByCartegoryName();
                    PropertyMainMenuForManager();

                }
                else if (ans == "4")
                {
                    GetPropertyByDescription();
                    PropertyMainMenuForManager();
                }
                else if (ans == "5")
                {
                    GetPropertyByLocation();
                    PropertyMainMenuForManager();
                }
                else if (ans == "6")
                {
                    GetPropertyByPrice();
                    PropertyMainMenuForManager();
                }
                else if (ans == "7")
                {
                    UpdateProperty();
                    PropertyMainMenuForManager();
                }
                else if (ans == "8")
                {
                    CreateProperty();
                    PropertyMainMenuForManager();
                }
                else if (ans == "#")
                {
                    ManagerMenu managerMenu = new ManagerMenu();
                    managerMenu.ManagerNewMainMenu();
                }
                else
                {
                    System.Console.WriteLine("++++Wrong Input++++");
                    PropertyMainMenuForManager();

                }
            }


            catch (System.Exception)
            {
                System.Console.WriteLine("=====Wrong input======");
                PropertyMainMenuForManager();
            }
        }
        public void PropertyMainMenuForCustomer()
        {
            try
            {
                System.Console.WriteLine("Enter 1 to get all Property\nEnter 2 to Get Property By Id\n Enter 3 to Get Property By CartegoryName\nEnter 4 to Get Property By Description\nEnter 5 to Get Property By Location\nEnter 6 to Get Property By Price\nEnter # to Exit");
                string ans = Console.ReadLine();
                if (ans == "1")
                {
                    GetAllProperty();
                    PropertyMainMenuForCustomer();

                }
                else if (ans == "2")
                {
                    GetPropertyById();
                    PropertyMainMenuForCustomer();

                }
                else if (ans == "3")
                {
                    GetPropertyByCartegoryName();
                    PropertyMainMenuForCustomer();

                }
                else if (ans == "4")
                {
                    GetPropertyByDescription();
                    PropertyMainMenuForCustomer();
                }
                else if (ans == "5")
                {
                    GetPropertyByLocation();
                    PropertyMainMenuForCustomer();
                }
                else if (ans == "6")
                {
                    GetPropertyByPrice();
                    PropertyMainMenuForCustomer();
                }
                else if (ans == "#")
                {
                    CustomerMenu customerMenu = new CustomerMenu();
                    customerMenu.CustomerMainMenus();
                }
                else
                {
                    System.Console.WriteLine("++++Wrong Input++++");
                    PropertyMainMenuForCustomer();

                }
            }


            catch (System.Exception)
            {
                System.Console.WriteLine("=====Wrong input======");
                PropertyMainMenuForCustomer();
            }
        }

        // public void PropertyMainMenu()
        // {

        //     try
        //     {
        //         System.Console.WriteLine("Enter 1 to create Property\nEnter 2 to get all Property\nEnter 3 to delete Property\nEnter 4 to Get Property By Id\n Enter 5 to Get Property By CartegoryName\nEnter 6 to Get Property By Description\nEnter 7 to Get Property By Location\nEnter 8 to Get Property By Price\nEnter 9 UpdateProperty");
        //         string ans = Console.ReadLine();
        //         if (ans == "1")
        //         {
        //             CreateProperty();
        //             PropertyMainMenu();

        //         }
        //         else if (ans == "2")
        //         {
        //             GetAllProperty();
        //             PropertyMainMenu();

        //         }
        //         else if (ans == "3")
        //         {
        //             DeleteProperty();
        //             PropertyMainMenu();

        //         }
        //         else if (ans == "4")
        //         {
        //             GetPropertyById();
        //             PropertyMainMenu();

        //         }
        //         else if (ans == "5")
        //         {
        //             GetPropertyByCartegoryName();
        //             PropertyMainMenu();

        //         }
        //         else if (ans == "6")
        //         {
        //             GetPropertyByDescription();
        //             PropertyMainMenu();
        //         }
        //         else if (ans == "7")
        //         {
        //             GetPropertyByLocation();
        //             PropertyMainMenu();
        //         }
        //         else if (ans == "8")
        //         {
        //             GetPropertyByPrice();
        //             PropertyMainMenu();
        //         }
        //         else if (ans == "9")
        //         {
        //             UpdateProperty();
        //             PropertyMainMenu();
        //         }
        //         else
        //         {
        //             System.Console.WriteLine("++++Wrong Input++++");
        //             PropertyMainMenu();

        //         }
        //     }


        //     catch (System.Exception)
        //     {
        //         System.Console.WriteLine("=====Wrong input======");
        //         PropertyMainMenu();
        //     }
        // }

        public void PropertyMainMenuForSuperAdmin()
        {

            try
            {
                System.Console.WriteLine("Enter 1 to create Property\nEnter 2 to get all Property\nEnter 3 to delete Property\nEnter 4 to Get Property By Id\n Enter 5 to Get Property By CartegoryName\nEnter 6 to Get Property By Description\nEnter 7 to Get Property By Location\nEnter 8 to Get Property By Price\nEnter 9 UpdateProperty\nEnter # to Exit");
                string ans = Console.ReadLine();
                if (ans == "1")
                {
                    CreateProperty();
                    PropertyMainMenuForSuperAdmin();

                }
                else if (ans == "2")
                {
                    GetAllProperty();
                    PropertyMainMenuForSuperAdmin();

                }
                else if (ans == "3")
                {
                    DeleteProperty();
                    PropertyMainMenuForSuperAdmin();

                }
                else if (ans == "4")
                {
                    GetPropertyById();
                    PropertyMainMenuForSuperAdmin();

                }
                else if (ans == "5")
                {
                    GetPropertyByCartegoryName();
                    PropertyMainMenuForSuperAdmin();

                }
                else if (ans == "6")
                {
                    GetPropertyByDescription();
                    PropertyMainMenuForSuperAdmin();
                }
                else if (ans == "7")
                {
                    GetPropertyByLocation();
                    PropertyMainMenuForSuperAdmin();
                }
                else if (ans == "8")
                {
                    GetPropertyByPrice();
                    PropertyMainMenuForSuperAdmin();
                }
                else if (ans == "9")
                {
                    UpdateProperty();
                    PropertyMainMenuForSuperAdmin();
                }
                else if (ans == "#")
                {
                    SuperAdminMenu superAdminMenu = new SuperAdminMenu();
                    superAdminMenu.SuperAdminMainMenu();
                }
                else
                {
                    System.Console.WriteLine("++++Wrong Input++++");
                    PropertyMainMenuForSuperAdmin();

                }
            }


            catch (System.Exception)
            {
                System.Console.WriteLine("=====Wrong input======");
                PropertyMainMenuForSuperAdmin();
            }
        }


        public void GetAllProperty()
        {
            propertyService.GetAllProperty();
        }



        public void GetAllPropertyForSale()
        {
            var get = propertyService.GetPropertyForSale();
            foreach (var item in get)
            {
                System.Console.WriteLine($"Id :{item.Id}. CartegoryName :{item.CartegoryName} PropertyLocation : {item.Location} TypeOfLease :{item.TypeOfLeases}  PropertyPrice : {item.Price}  IsAvaillable : {item.IsAvailable}  propertyDescription :{item.Description}  OwnerTagNumber :{item.OwnersTagNumber}");
            }
            System.Console.WriteLine("enter 1 to continue\nenter 2 to move to payment");
            string ans = Console.ReadLine();
            if (ans == "1")
            {

            }
            if (ans == "2")
            {
                foreach (var item in get)
                {
                    System.Console.WriteLine($"Id :{item.Id}. CartegoryName :{item.CartegoryName} PropertyLocation : {item.Location} TypeOfLease :{item.TypeOfLeases}  PropertyPrice : {item.Price}  IsAvaillable : {item.IsAvailable}  propertyDescription :{item.Description}  OwnerTagNumber :{item.OwnersTagNumber}");
                }
                System.Console.WriteLine("Enter property id you will like to buy");
                int id = int.Parse(Console.ReadLine());
                Payment(id);

            }

        }


        public void GetAllPropertyForRent()
        {
            var get = propertyService.GetPropertyForRent();
            foreach (var item in get)
            {
                System.Console.WriteLine($"Id :{item.Id}. CartegoryName :{item.CartegoryName} PropertyLocation : {item.Location} TypeOfLease :{item.TypeOfLeases}  PropertyPrice : {item.Price}  IsAvaillable : {item.IsAvailable}  propertyDescription :{item.Description}  OwnerTagNumber :{item.OwnersTagNumber}");
            }
            System.Console.WriteLine("enter 1 to continue\nenter 2 to move to payment");
            string ans = Console.ReadLine();
            if (ans == "1")
            {

            }
            if (ans == "2")
            {
                foreach (var item in get)
                {
                    System.Console.WriteLine($"Id :{item.Id}. CartegoryName :{item.CartegoryName} PropertyLocation : {item.Location} TypeOfLease :{item.TypeOfLeases}  PropertyPrice : {item.Price}  IsAvaillable : {item.IsAvailable}  propertyDescription :{item.Description}  OwnerTagNumber :{item.OwnersTagNumber}");
                }
                System.Console.WriteLine("Enter property id you will like to buy");
                int id = int.Parse(Console.ReadLine());
                Payment(id);

            }

        }
        public void CreateProperty()
        {


            CartegoryMenu cartegoryMenu = new CartegoryMenu();
            cartegoryMenu.GetAllCartegory();
            System.Console.WriteLine("Enter Cartegory Id");
            int CartegoryId = int.Parse(Console.ReadLine());
            System.Console.WriteLine("Enter property state ");
            string Location = Console.ReadLine().ToLower();
            System.Console.WriteLine("Enter  1 for Sale\n Enter 2 for Rent");
            string ans = Console.ReadLine();
            TypeOfLeases typeOfLeases = new TypeOfLeases();
            if (ans == "1")
            {
                typeOfLeases = TypeOfLeases.ForSale;
            }
            else if (ans == "2")
            {
                typeOfLeases = TypeOfLeases.ForRent;
            }
            else
            {
                System.Console.WriteLine("++++Wrong Input++++");
                CreateProperty();
            }
            System.Console.WriteLine("Enter price ");
            double price = double.Parse(Console.ReadLine());
            System.Console.WriteLine("Enter Description ");
            string description = Console.ReadLine().ToLower();
            propertyService.CreateProperty(UserSession.LoggedInUserEmail, Location, typeOfLeases, price, description, CartegoryId);
            System.Console.WriteLine("Created sucessfully");



        }

        public void DeleteProperty()
        {

            propertyService.GetAllProperty();
            System.Console.WriteLine("Enter PropertyId");
            int Id = int.Parse(Console.ReadLine());
            propertyService.DeleteProperty(Id);
            System.Console.WriteLine("Deleted Succesfully");






        }

        public void Payment(int id)
        {

            PropertyService propertyService = new PropertyService();
            // PropertyMenu propertyMenu = new PropertyMenu();
            // propertyMenu.GetAllProperty();
            // System.Console.WriteLine("Enter Property Id");
            var get = propertyService.GetPropertyById(id);
            // System.Console.WriteLine($"{get.Id}. CartegoryName :{get.CartegoryName} PropertyLocation : {get.Location} TypeOfLease :{get.TypeOfLeases}  PropertyPrice : {get.Price}  IsAvaillable : {get.IsAvailable}  propertyDescription :{get.Description}  OwnerTagNumber :{get.OwnersTagNumber}");
            System.Console.WriteLine("Enter 1 to add to wallet\nEnter 2 to continue");
            string ans = Console.ReadLine();
            if (ans == "1")
            {

                UserMenu userMenu = new UserMenu();
                userMenu.UpdateWallet();
                Payment(id);


            }
            else
            {
                UserService userService = new UserService();
                var user = userService.GetUserByEmail(UserSession.LoggedInUserEmail.ToLower());
                if (get.Price > user.Wallet)
                {
                    System.Console.WriteLine("You dont have enough money in your wallet");
                    UserMenu userMenu = new UserMenu();
                    userMenu.UpdateWallet();
                    Payment(id);

                }
                else
                {
                    TransactionMenu transactionMenu = new TransactionMenu();
                    transactionMenu.CreateTransaction(id);
                    CustomerMenu customerMenu = new CustomerMenu();
                    customerMenu.CustomerMainMenus();
                    get.IsAvailable = false;
                    PropertyRepository propertyRepository  = new PropertyRepository();
                    propertyRepository.RefreshPropertyFile();


                }

            }

        }
        public void GetPropertyById()
        {

            propertyService.GetAllProperty();
            System.Console.WriteLine("Enter PropertyId");
            int PropertyId = int.Parse(Console.ReadLine());
            var getById = propertyService.GetPropertyById(PropertyId);
            System.Console.WriteLine($"{getById.Id}. CartegoryName :{getById.CartegoryName} PropertyLocation : {getById.Location} TypeOfLease :{getById.TypeOfLeases}  PropertyPrice : {getById.Price}  IsAvaillable : {getById.IsAvailable}  propertyDescription :{getById.Description}  OwnerTagNumber :{getById.OwnersTagNumber}");
            System.Console.WriteLine("enter 1 to continue\nenter 2 to move to payment");
            string ans = Console.ReadLine();
            if (ans == "1")
            {

            }
            if (ans == "2")
            {
                Payment(getById.Id);

            }




        }
        public void GetPropertyByCartegoryName()
        {

            cartegoryService.GetAllCartegory();
            System.Console.WriteLine("Enter CartegoryId");
            int CartegoryId = int.Parse(Console.ReadLine());
            var getById = cartegoryService.GetCartegoryById(CartegoryId);
            var getByName = propertyService.GetPropertyByCartegoryName(getById.Name);
            foreach (var item in getByName)
            {
                System.Console.WriteLine($"Id :{item.Id}. CartegoryName :{item.CartegoryName} PropertyLocation : {item.Location} TypeOfLease :{item.TypeOfLeases}  PropertyPrice : {item.Price}  IsAvaillable : {item.IsAvailable}  propertyDescription :{item.Description}  OwnerTagNumber :{item.OwnersTagNumber}");
            }
            System.Console.WriteLine("enter 1 to continue\nenter 2 to move to payment");
            string ans = Console.ReadLine();
            if (ans == "1")
            {

            }
            if (ans == "2")
            {
                foreach (var item in getByName)
                {
                    System.Console.WriteLine($"Id :{item.Id}. CartegoryName :{item.CartegoryName} PropertyLocation : {item.Location} TypeOfLease :{item.TypeOfLeases}  PropertyPrice : {item.Price}  IsAvaillable : {item.IsAvailable}  propertyDescription :{item.Description}  OwnerTagNumber :{item.OwnersTagNumber}");
                }
                System.Console.WriteLine("Enter property id you will like to buy");
                int id = int.Parse(Console.ReadLine());
                Payment(id);

            }




        }
        public void GetPropertyByDescription()
        {

            System.Console.WriteLine("Enter Description");
            string Description = Console.ReadLine().ToLower();
            var getByDescription = propertyService.GetPropertyByDescription(Description);
            foreach (var item in getByDescription)
            {
                System.Console.WriteLine($"Id :{item.Id}. CartegoryName :{item.CartegoryName} PropertyLocation : {item.Location} TypeOfLease :{item.TypeOfLeases}  PropertyPrice : {item.Price}  IsAvaillable : {item.IsAvailable}  propertyDescription :{item.Description}  OwnerTagNumber :{item.OwnersTagNumber}");
            }
            System.Console.WriteLine("enter 1 to continue\nenter 2 to move to payment");
            string ans = Console.ReadLine();
            if (ans == "1")
            {

            }
            if (ans == "2")
            {
                foreach (var item in getByDescription)
                {
                    System.Console.WriteLine($"Id :{item.Id}. CartegoryName :{item.CartegoryName} PropertyLocation : {item.Location} TypeOfLease :{item.TypeOfLeases}  PropertyPrice : {item.Price}  IsAvaillable : {item.IsAvailable}  propertyDescription :{item.Description}  OwnerTagNumber :{item.OwnersTagNumber}");
                }
                System.Console.WriteLine("Enter property id you will like to buy");
                int id = int.Parse(Console.ReadLine());
                Payment(id);

            }
        }
        public void GetPropertyByLocation()
        {

            System.Console.WriteLine("Enter Location");
            string Location = Console.ReadLine().ToLower();
            var getByLocation = propertyService.GetPropertyByLocation(Location);
            foreach (var item in getByLocation)
            {
                System.Console.WriteLine($"Id :{item.Id}. CartegoryName :{item.CartegoryName} PropertyLocation : {item.Location} TypeOfLease :{item.TypeOfLeases}  PropertyPrice : {item.Price}  IsAvaillable : {item.IsAvailable}  propertyDescription :{item.Description}  OwnerTagNumber :{item.OwnersTagNumber}");
            }
            System.Console.WriteLine("enter 1 to continue\nenter 2 to move to payment");
            string ans = Console.ReadLine();
            if (ans == "1")
            {

            }
            if (ans == "2")
            {
                foreach (var item in getByLocation)
                {
                    System.Console.WriteLine($"Id :{item.Id}. CartegoryName :{item.CartegoryName} PropertyLocation : {item.Location} TypeOfLease :{item.TypeOfLeases}  PropertyPrice : {item.Price}  IsAvaillable : {item.IsAvailable}  propertyDescription :{item.Description}  OwnerTagNumber :{item.OwnersTagNumber}");
                }
                System.Console.WriteLine("Enter property id you will like to buy");
                int id = int.Parse(Console.ReadLine());
                Payment(id);

            }

        }
        public void GetPropertyByPrice()
        {

            System.Console.WriteLine("Enter Price");
            double Price = double.Parse(Console.ReadLine());
            var getByPrice = propertyService.GetPropertyByPrice(Price);
            foreach (var item in getByPrice)
            {
                System.Console.WriteLine($"Id :{item.Id}. CartegoryName :{item.CartegoryName} PropertyLocation : {item.Location} TypeOfLease :{item.TypeOfLeases}  PropertyPrice : {item.Price}  IsAvaillable : {item.IsAvailable}  propertyDescription :{item.Description}  OwnerTagNumber :{item.OwnersTagNumber}");
            }
            System.Console.WriteLine("enter 1 to continue\nenter 2 to move to payment");
            string ans = Console.ReadLine();
            if (ans == "1")
            {

            }
            if (ans == "2")
            {
                foreach (var item in getByPrice)
                {
                    System.Console.WriteLine($"Id :{item.Id}. CartegoryName :{item.CartegoryName} PropertyLocation : {item.Location} TypeOfLease :{item.TypeOfLeases}  PropertyPrice : {item.Price}  IsAvaillable : {item.IsAvailable}  propertyDescription :{item.Description}  OwnerTagNumber :{item.OwnersTagNumber}");
                }
                System.Console.WriteLine("Enter property id you will like to buy");
                int id = int.Parse(Console.ReadLine());
                Payment(id);





            }
        }
        public void UpdateProperty()
        {

            propertyService.GetAllProperty();
            System.Console.WriteLine("Enter property Id");
            int id = int.Parse(Console.ReadLine());
            var getPropertyById = propertyService.GetPropertyById(id);
            System.Console.WriteLine("Enter Location");
            string Location = Console.ReadLine().ToLower();
            System.Console.WriteLine("Enter price");
            double price = double.Parse(Console.ReadLine());
            System.Console.WriteLine("Enter Description");
            string description = Console.ReadLine().ToLower();
            System.Console.WriteLine("Enter  1 for Sale\n Enter 2 for Rent");
            string ans = Console.ReadLine();
            TypeOfLeases typeOfLeases = new TypeOfLeases();
            if (ans == "1")
            {
                typeOfLeases = TypeOfLeases.ForSale;
            }
            else if (ans == "2")
            {
                typeOfLeases = TypeOfLeases.ForRent;
            }
            else
            {
                System.Console.WriteLine("++++Wrong Input++++");
                UpdateProperty();
            }
            System.Console.WriteLine("Enter  1 if still available\n Enter 2 if not a available Rent");
            string ans2 = Console.ReadLine();
            bool IsAvailable2 = false;
            if (ans == "1")
            {
                IsAvailable2 = true;
            }
            else if (ans == "2")
            {
                IsAvailable2 = false;
            }
            else
            {
                System.Console.WriteLine("++++Wrong Input++++");
                UpdateProperty();
            }

            propertyService.UpdateProperty(id, getPropertyById.CartegoryName, Location, typeOfLeases, price, description, IsAvailable2, getPropertyById.OwnersTagNumber);
            System.Console.WriteLine("Updated Succesfully");


        }
    }
}

