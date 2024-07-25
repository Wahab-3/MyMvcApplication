using RealEstateConsoleApp.Models;
using RealEstateConsoleApp.Service.Implementation;
using RealEstateConsoleApp.Service.Interface;

namespace RealEstateConsoleApp.Menu
{
    public class ManagerMenu
    {
        IManagerService managerService = new ManagerService();
        IUserService userServiceuserService = new UserService();
        MainMenu main = new MainMenu();
        // 
        // PropertyMenu propertyMenu = new PropertyMenu();
        // 
        // CustomerMenu customerMenu = new CustomerMenu();
        // 
        // OwnerMenu ownerMenu = new OwnerMenu();

        public void ManagerNewMainMenu()
        {
            try
            {
                System.Console.WriteLine("=====Welcome Back To Manager Menu======");
                System.Console.WriteLine();
                System.Console.WriteLine("Enter 1 for cartegoryMenu\nEnter 2 for customerMenu\nEnter 3 forPropertyMenu\nEnter 4 for transaction menu\nEnter 5 for usermenu\nEnter 6 for manager menu\nEnter # to quite application\nEnter 7 for OwnerMenu");
                string ans = Console.ReadLine();
                if (ans == "1")
                {
                    CartegoryMenu cartegoryMenu = new CartegoryMenu();
                    cartegoryMenu.ManagerCartegoryMainMenu();
                    ManagerNewMainMenu();
                }
                else if (ans == "2")
                {
                    CustomerMenu customerMenu = new CustomerMenu();
                    customerMenu.ManagerCustomerMainMenu();
                    ManagerNewMainMenu();
                }
                else if (ans == "3")
                {
                    PropertyMenu propertyMenu = new PropertyMenu();
                    propertyMenu.PropertyMainMenuForManager();
                    ManagerNewMainMenu();
                }
                else if (ans == "4")
                {
                    TransactionMenu transactionMenu = new TransactionMenu();
                    transactionMenu.TransactionMainMenuForManager();
                    ManagerNewMainMenu();
                }
                else if (ans == "5")
                {
                    UserMenu userMenu = new UserMenu();
                    userMenu.UserMainMenuForManager();
                    ManagerNewMainMenu();
                }

                else if (ans == "6")
                {
                    ManagerMainMenuForManager();
                    ManagerNewMainMenu();
                }
                else if (ans == "7")
                {
                    OwnerMenu ownerMenu  = new OwnerMenu();
                    ownerMenu.OwnerMainMenuForManager();
                    ManagerNewMainMenu();
                }
                else if (ans == "#")
                {
                    main.Main();
                }
                else
                {
                    System.Console.WriteLine("++++Wrong Input++++");
                    ManagerNewMainMenu();
                }
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine("=====Wrong input======");
                ManagerNewMainMenu();

            }

        }


        public void ManagerMainMenuForManager()
        {
            System.Console.WriteLine("Enter 1 to get all manager\nEmter 3 to get manager by email\nEnter 4 to get manager by Id\nEnter # to quite application");
            string ans = Console.ReadLine();
            if (ans == "1")
            {
                GetAllManager();
                ManagerMainMenuForManager();

            }
            else if (ans == "3")
            {
                GetManagerByEmail();
                ManagerMainMenuForManager();
            }
            else if (ans == "4")
            {
                GetManagerById();
                ManagerMainMenuForManager();
            }
            else if (ans == "#")
            {
                main.Main();
            }
            else
            {
                System.Console.WriteLine("++++Wrong Input++++");
                ManagerMainMenuForManager();
            }
        }

        public void ManagerMainMenuForSuperAdmin()
        {


            System.Console.WriteLine("Enter 1 to get all manager\nEnter 2  to delete manager\nEmter 3 to get manager by email\nEnter 4 to get manager by Id\n enter 5 to update manager\nEnter 6 to create Manager\nEnter # to Exit");
            string ans = Console.ReadLine();
            if (ans == "1")
            {
                GetAllManager();
                ManagerMainMenuForSuperAdmin();
            }
            else if (ans == "2")
            {
                DeleteManager();
                ManagerMainMenuForSuperAdmin();
            }
            else if (ans == "3")
            {
                GetManagerByEmail();
                ManagerMainMenuForSuperAdmin();
            }
            else if (ans == "4")
            {
                GetManagerById();
                ManagerMainMenuForSuperAdmin();
            }
            else if (ans == "5")
            {
                UpdateManager();
                ManagerMainMenuForSuperAdmin();
            }
            else if (ans == "6")
            {
                CreateManager();
                ManagerMainMenuForSuperAdmin();
            }
            else if (ans == "#")
            {
                SuperAdminMenu superAdminMenu = new SuperAdminMenu();
                superAdminMenu.SuperAdminMainMenu();
            }
            else
            {
                System.Console.WriteLine("++++Wrong Input++++");
                ManagerMainMenuForSuperAdmin();
            }





        }



        // }
        // public void ManagerMainMenu()
        // {
        //     System.Console.WriteLine("=====Welcome Back To Manager Menu======");
        //     System.Console.WriteLine();

        //         System.Console.WriteLine("Enter 1 to get all manager\nEnter 2  to delete manager\nEmter 3 to get manager by email\nEnter 4 to get manager by Id\n enter 5 to update manager\nEnter 6 to create Manager\nEnter # to quite application");
        //         string ans = Console.ReadLine();
        //         if (ans == "1")
        //         {
        //             GetAllManager();
        //             ManagerMainMenu();

        //         }
        //         else if (ans == "2")
        //         {
        //             DeleteManager();
        //             ManagerMainMenu();
        //         }
        //         else if (ans == "3")
        //         {
        //             GetManagerByEmail();
        //             ManagerMainMenu();
        //         }
        //         else if (ans == "4")
        //         {
        //             GetManagerById();
        //             ManagerMainMenu();
        //         }
        //         else if (ans == "5")
        //         {
        //             UpdateManager();
        //             ManagerMainMenu();
        //         }
        //         else if (ans == "6")
        //         {
        //             CreateManager();
        //             ManagerMainMenu();
        //         }
        //         else if (ans == "#")
        //         {
        //             main.Main();
        //         }
        //         else
        //         {
        //             System.Console.WriteLine("++++Wrong Input++++");
        //             ManagerMainMenu();
        //         }





        // }
        public void CreateManager()
        {

            System.Console.WriteLine("Enter Your FirstName");
            string firstName = Console.ReadLine();
            System.Console.WriteLine("Enter Your LastName");
            string lastName = Console.ReadLine();
            System.Console.WriteLine("Enter Your Email");
            string email = Console.ReadLine().ToLower();
            System.Console.WriteLine("Enter Your phoneNumber");
            int phoneNumber = int.Parse(Console.ReadLine());
            System.Console.WriteLine("Enter Your age");
            int age = int.Parse(Console.ReadLine());
            System.Console.WriteLine("Enter Your Address");
            string address = Console.ReadLine();
            System.Console.WriteLine("Enter Your Password");
            string pass = Console.ReadLine().ToLower();
            System.Console.WriteLine("Enter Your 1 for male\nEnter 2 for Female\nEnter 3 for unknown");
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
                ManagerNewMainMenu();
            }


            IUserService userServiceuserService = new UserService();
            IManagerService managerService = new ManagerService();
            userServiceuserService.CreateUser(email, firstName, lastName, phoneNumber, age, address, gender, pass, "manager");
            managerService.CreateManager(email);
            System.Console.WriteLine("=====Manager created succesfully=====");


        }


        public void DeleteManager()
        {


            System.Console.WriteLine("Enter manager Email");
            string email = Console.ReadLine().ToLower();
            managerService.DeleteManager(email);
            userServiceuserService.DeleteUser(email);
            System.Console.WriteLine("Deleted succesfully");


        }
        public void GetAllManager()
        {
            managerService.GetAllManager();

        }
        public void GetManagerByEmail()
        {

            System.Console.WriteLine("Enter manager Email");
            string email = Console.ReadLine().ToLower();
            var getByEmail = managerService.GetManagerByEmail(email);
            var getUserByEmail = userServiceuserService.GetUserByEmail(email);
            System.Console.WriteLine($"ManagersName : {getUserByEmail.LastName}  {getUserByEmail.FirstName} ManagersEmail :{getUserByEmail.Email}  ");

        }
        public void GetManagerById()
        {

            System.Console.WriteLine("Enter manager id");
            int id = int.Parse(Console.ReadLine());
            var getById = managerService.GetManagerById(id);
            var getUserByEmail = userServiceuserService.GetUserByEmail(getById.UserEmail);
            System.Console.WriteLine($"ManagersName : {getUserByEmail.LastName}  {getUserByEmail.FirstName} ManagersEmail :{getUserByEmail.Email}  ");

        }
        public void UpdateManager()
        {

            System.Console.WriteLine("Enter  OldEmail");
            string email = Console.ReadLine().ToLower();
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
                ManagerNewMainMenu();
            }
            var getByEmail = managerService.GetManagerByEmail(email);
            var getUserByEmail = userServiceuserService.GetUserByEmail(email);
            userServiceuserService.UpdateUser(email, Newemail, FirstName, LastName, PhoneNumber, Age, Address, gender, Password, getUserByEmail.Wallet);
            getByEmail.UserEmail = Newemail;
            System.Console.WriteLine("Updated succesfully");

        }
    }
}