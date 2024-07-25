using RealEstateConsoleApp.Models;
using RealEstateConsoleApp.Models.Entities;
using RealEstateConsoleApp.Service.Implementation;
using RealEstateConsoleApp.Service.Interface;

namespace RealEstateConsoleApp.Menu
{
    public class CustomerMenu
    {
        MainMenu main = new MainMenu();


        // OwnerMenu ownerMenu = new OwnerMenu();
        // ManagerMenu managerMenu = new ManagerMenu();
        ICustomerService customerService = new CustomerService();
        IUserService userServiceuserService = new UserService();

        public void CustomerMainMenus()
        {

            try
            {
                System.Console.WriteLine("=====Welcome Back To Customer Menu======");
                System.Console.WriteLine();
                System.Console.WriteLine("Enter 1 to see view property according to cartegory\nEnter 2 to view all property\nEnter 3 to update wallet\nEnter # to LogOut\nEnter 4 to see property for rent\nEnter 5 to see property for sale\nEnter 11 to get property by budget\nEnter 6 to get property by State\nEnter 7 to get property by description\nEnter 8 to view your profile\nEnter 10 to view your wallet balance\nEnter 12 to update your profile");
                string ans = Console.ReadLine();
                if (ans == "1")
                {
                    PropertyMenu propertyMenu = new PropertyMenu();
                    propertyMenu.GetPropertyByCartegoryName();
                    CustomerMainMenus();

                }
                else if (ans == "2")
                {
                    PropertyMenu propertyMenu = new PropertyMenu();
                    propertyMenu.GetAllProperty();
                    CustomerMainMenus();

                }
                else if (ans == "3")
                {

                    UserMenu userMenu = new UserMenu();
                    userMenu.UpdateWallet();
                    CustomerMainMenus();

                }
                else if (ans == "4")
                {

                    PropertyMenu propertyMenu = new PropertyMenu();
                    propertyMenu.GetAllPropertyForRent();
                    CustomerMainMenus();


                }
                else if (ans == "5")
                {
                    PropertyMenu propertyMenu = new PropertyMenu();
                    propertyMenu.GetAllPropertyForSale();
                    CustomerMainMenus();

                }
                else if (ans == "6")
                {
                    PropertyMenu propertyMenu = new PropertyMenu();
                    propertyMenu.GetPropertyByLocation();
                    CustomerMainMenus();
                }
                else if (ans == "7")
                {
                    PropertyMenu propertyMenu = new PropertyMenu();
                    propertyMenu.GetPropertyByDescription();

                    CustomerMainMenus();
                }
                else if (ans == "8")
                {
                    GetCustomerByEmail();
                    CustomerMainMenus();
                }

                else if (ans == "10")
                {
                    ViewWallet();
                    CustomerMainMenus();
                }
                else if (ans == "11")
                {
                    PropertyMenu propertyMenu = new PropertyMenu();
                    propertyMenu.GetPropertyByPrice();

                    CustomerMainMenus();
                }
                else if (ans == "12")
                {
                    UpdateCustomer();
                    CustomerMainMenus();

                }

                else if (ans == "#")
                {
                    MainMenu main = new MainMenu();
                    main.Main();
                }
                else
                {
                    System.Console.WriteLine("++++Wrong Input++++");
                    CustomerMainMenus();

                }
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine("=====Wrong input======");
                CustomerMainMenus();
            }
        }



     
        // public void CustomerNewMainMenu()
        // {
        //     try
        //     {
        //         System.Console.WriteLine("=====Welcome Back To Customer Menu======");
        //         System.Console.WriteLine();
        //         System.Console.WriteLine("Enter 1 for cartegoryMenu\nEnter 2 forPropertyMenu\nEnter 3 for transaction menu\nEnter # to quite application");
        //         string ans = Console.ReadLine();
        //         if (ans == "1")
        //         {
        //             CartegoryMenu cartegoryMenu = new CartegoryMenu();
        //             cartegoryMenu.CustomerCartegoryMainMenu();
        //             CustomerNewMainMenu();
        //         }
        //         else if (ans == "2")
        //         {
        //             PropertyMenu propertyMenu = new PropertyMenu();
        //             propertyMenu.PropertyMainMenuForCustomer();
        //             CustomerNewMainMenu();
        //         }
        //         else if (ans == "3")
        //         {
        //             TransactionMenu transactionMenu = new TransactionMenu();
        //             transactionMenu.TransactionMainMenuForCustomer();
        //             CustomerNewMainMenu();
        //         }
        //         else if (ans == "#")
        //         {
        //             main.Main();
        //         }
        //         else
        //         {
        //             System.Console.WriteLine("++++Wrong Input++++");
        //             CustomerNewMainMenu();
        //         }
        //     }
        //     catch (System.Exception ex)
        //     {
        //         System.Console.WriteLine("=====Wrong input======");
        //         CustomerNewMainMenu();


        //     }
        // propertyMenu.GetPropertyByCartegoryName();
        // propertyMenu.GetPropertyById();
        // System.Console.WriteLine("Enter 1 to buy or rent property\nEnter 2 to go back");
        // string ans = Console.ReadLine();
        // if (ans == "1")
        // {
        //     transactionMenu.CreateTransaction();
        //     // propertyMenu.GetPropertyByCartegoryName();
        //     // propertyMenu.GetPropertyById();

        // }
        // else
        // {
        //     CustomerNewMainMenu();
        // }
        // }
        // public void CustomerMainMenu()
        // {
        //     System.Console.WriteLine("=====Welcome Back To Customer Menu======");
        //     System.Console.WriteLine();
        //     try
        //     {

        //         System.Console.WriteLine("Enter 1 to get all customer\nEnter 2  to delete customer\nEmter 3 to get customer by email\nEnter 4 to get customer by Id\n enter 5 to update customer\nEnter # to quite application");
        //         string ans = Console.ReadLine();
        //         if (ans == "1")
        //         {
        //             GetAllCustomer();
        //             CustomerMainMenu();

        //         }
        //         else if (ans == "2")
        //         {
        //             DeleteCustomer();
        //             CustomerMainMenu();
        //         }
        //         else if (ans == "3")
        //         {
        //             GetCustomerByEmail();
        //             CustomerMainMenu();

        //         }
        //         else if (ans == "4")
        //         {
        //             GetCustomerById();
        //             CustomerMainMenu();
        //         }
        //         else if (ans == "5")
        //         {
        //             UpdateCustomer();
        //             CustomerMainMenu();
        //         }
        //         else if (ans == "#")
        //         {
        //             main.Main();
        //         }
        //         else
        //         {
        //             System.Console.WriteLine("++++Wrong Input++++");
        //             CustomerMainMenu();
        //         }
        //     }
        //     catch (System.Exception)
        //     {
        //         System.Console.WriteLine("=====Wrong input======");
        //         CustomerMainMenu();
        //     }




        // }



        public void CustomerMainMenuForSUperAdmin()
        {
            try
            {

                System.Console.WriteLine("Enter 1 to get all customer\nEnter 2  to delete customer\nEmter 3 to get customer by email\nEnter 4 to get customer by Id\n enter 5 to update customer\nEnter # to Exit");
                string ans = Console.ReadLine();
                if (ans == "1")
                {
                    GetAllCustomer();
                    CustomerMainMenuForSUperAdmin();

                }
                else if (ans == "2")
                {
                    DeleteCustomer();
                    CustomerMainMenuForSUperAdmin();
                }
                else if (ans == "3")
                {
                    GetCustomerByEmail();
                    CustomerMainMenuForSUperAdmin();

                }
                else if (ans == "4")
                {
                    GetCustomerById();
                    CustomerMainMenuForSUperAdmin();
                }
                else if (ans == "5")
                {
                    UpdateCustomer();
                    CustomerMainMenuForSUperAdmin();
                }
                else if (ans == "#")
                {
                    SuperAdminMenu superAdminMenu = new SuperAdminMenu();
                    superAdminMenu.SuperAdminMainMenu();
                }
                else
                {
                    System.Console.WriteLine("++++Wrong Input++++");
                    CustomerMainMenuForSUperAdmin();
                }
            }
            catch (System.Exception)
            {
                System.Console.WriteLine("=====Wrong input======");
                CustomerMainMenuForSUperAdmin();
            }




        }
        public void ManagerCustomerMainMenu()
        {
            System.Console.WriteLine();
            try
            {

                System.Console.WriteLine("Emter 1 to get customer by email\nEnter 2 to get customer by Id\nEnter # to go application");
                string ans = Console.ReadLine();
                if (ans == "1")
                {
                    GetCustomerByEmail();
                    ManagerCustomerMainMenu();

                }
                else if (ans == "2")
                {
                    GetCustomerById();
                    ManagerCustomerMainMenu();
                }
                else if (ans == "#")
                {
                    ManagerMenu managerMenu = new ManagerMenu();
                    managerMenu.ManagerNewMainMenu();
                }
                else
                {
                    System.Console.WriteLine("++++Wrong Input++++");
                    ManagerCustomerMainMenu();
                }
            }
            catch (System.Exception)
            {
                System.Console.WriteLine("=====Wrong input======");
                ManagerCustomerMainMenu();
            }




        }
        public void DeleteCustomer()
        {


            System.Console.WriteLine("Enter customer Email");
            string email = Console.ReadLine().ToLower();
            customerService.DeleteCustomer(email);
            userServiceuserService.DeleteUser(email);
            System.Console.WriteLine("Deleted succesfully");

        }
        public void GetAllCustomer()
        {
            customerService.GetAllCustomer();
        }
        public void GetCustomerByEmail()
        {

   
            var getByEmail = customerService.GetCustomerByEmail(UserSession.LoggedInUserEmail);
            var getUserByEmail = userServiceuserService.GetUserByEmail(UserSession.LoggedInUserEmail);
            System.Console.WriteLine($"CustomersName : {getUserByEmail.LastName}  {getUserByEmail.FirstName} CustomersEmail :{getUserByEmail.Email}  ");

        }
        public void ViewWallet()
        {

            var getByEmail = customerService.GetCustomerByEmail(UserSession.LoggedInUserEmail);
            var getUserByEmail = userServiceuserService.GetUserByEmail(UserSession.LoggedInUserEmail);
            System.Console.WriteLine($"CustomersName : {getUserByEmail.LastName}  {getUserByEmail.FirstName} CustomersEmail :{getUserByEmail.Email} customerWallet :{getUserByEmail.Wallet}  ");

        }
        public void GetCustomerById()
        {

            System.Console.WriteLine("Enter customer id");
            int id = int.Parse(Console.ReadLine());
            var getById = customerService.GetCustomerById(id);
            var getUserByEmail = userServiceuserService.GetUserByEmail(getById.UserEmail);
            System.Console.WriteLine($"CustomersName : {getUserByEmail.LastName}  {getUserByEmail.FirstName} CustomersEmail :{getUserByEmail.Email}  ");

        }
        public void UpdateCustomer()
        {

            System.Console.WriteLine("Enter  NewEmail");
            string Newemail = Console.ReadLine().ToLower();
            System.Console.WriteLine("Enter  FirstName");
            string FirstName = Console.ReadLine();
            System.Console.WriteLine("Enter  LastName");
            string LastName = Console.ReadLine();
            System.Console.WriteLine("Enter  PhoneNumber");
            int PhoneNumber = int.Parse(Console.ReadLine());
            System.Console.WriteLine("Enter  Age");
            int Age = int.Parse(Console.ReadLine());
            System.Console.WriteLine("Enter  Password");
            string Password = Console.ReadLine().ToLower();
            System.Console.WriteLine("Enter  Address");
            string Address = Console.ReadLine();
            System.Console.WriteLine("Enter Your 1 for male\n Enter 2 for Female\nEnter 3 for unknown");
            string ans = Console.ReadLine();
            Gender gender = new Gender();
            if (ans == "1")
            {
                gender = Gender.Male;
            }
            else if (ans == "2")
            {
                gender = Gender.Female;
            }
            else if (ans == "3")
            {
                gender = Gender.Unknown;

            }
            else
            {
                System.Console.WriteLine("++++Wrong Input++++");
                UpdateCustomer();
            }
            var getByEmail = customerService.GetCustomerByEmail(UserSession.LoggedInUserEmail);
            var getUserByEmail = userServiceuserService.GetUserByEmail(UserSession.LoggedInUserEmail);
            userServiceuserService.UpdateUser(UserSession.LoggedInUserEmail, Newemail, FirstName, LastName, PhoneNumber, Age, Address, gender, Password, getUserByEmail.Wallet);
            getByEmail.UserEmail = Newemail;
            System.Console.WriteLine("Updated succesfully");

        }
    }
}