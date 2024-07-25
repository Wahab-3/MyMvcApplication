using RealEstateConsoleApp.Models;
using RealEstateConsoleApp.Service.Implementation;
using RealEstateConsoleApp.Service.Interface;

namespace RealEstateConsoleApp.Menu
{
    public class OwnerMenu
    {
        // 
        // 
        // PropertyMenu propertyMenu = new PropertyMenu();
        // TransactionMenu transactionMenu = new TransactionMenu();
        // 
        // UserMenu userMenu = new UserMenu();
        // 
        // 
        IOwnerService ownerService = new OwnerService();
        IUserService userServiceuserService = new UserService();

        public void OwnerNewMainMenu()
        {
            try
            {
                System.Console.WriteLine("=====Welcome Back To Owner Menu======");
                System.Console.WriteLine("Enter 1 for cartegoryMenu\nEnter 2 for CustomerMenu\nEnter 3 forPropertyMenu\nEnter 4 for transaction menu\nEnter 5 for usermenu\nEnter 6 for manager menu\nEnter 7 for Owner menu\nEnter # to quite application");
                string ans = Console.ReadLine();
                if (ans == "1")
                {
                    CartegoryMenu cartegoryMenu = new CartegoryMenu();
                    cartegoryMenu.OwnerCartegoryMainMenu();
                    OwnerNewMainMenu();
                }
                else if (ans == "3")
                {
                    PropertyMenu propertyMenu = new PropertyMenu();
                    propertyMenu.PropertyMainMenuForOwner();
                    OwnerNewMainMenu();
                }
                else if (ans == "7")
                {
                    OwnerMenu ownerMenu = new OwnerMenu();
                    ownerMenu.OwnerMainMenus();
                    OwnerNewMainMenu();
                }
                else if (ans == "#")
                {
                    MainMenu main = new MainMenu();
                    main.Main();
                }
                else
                {
                    System.Console.WriteLine("++++Wrong Input++++");
                    OwnerNewMainMenu();
                }
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine("=====Wrong input======");
                OwnerNewMainMenu();


            }

        }

        public void OwnerMainMenuForSuperAdmin()
        {

            try
            {
                System.Console.WriteLine("Enter 1 to get all owner\nEnter 2  to delete owner\nEmter 3 to get owner by email\nEnter 4 to get owner by Id\n enter 5 to update owner\nEnter 6 to create Owner\nEnter # to Exit");
                string ans = Console.ReadLine();
                if (ans == "1")
                {
                    GetAllOwner();
                    OwnerMainMenuForSuperAdmin();
                }
                else if (ans == "2")
                {
                    DeleteOwner();
                    OwnerMainMenuForSuperAdmin();
                }
                else if (ans == "3")
                {
                    GetOwnerByEmail();
                    OwnerMainMenuForSuperAdmin();
                }
                else if (ans == "4")
                {
                    GetownerById();
                    OwnerMainMenuForSuperAdmin();
                }
                else if (ans == "5")
                {
                    UpdateOwner();
                    OwnerMainMenuForSuperAdmin();
                }
                else if (ans == "6")
                {
                    CreateOwner();
                    OwnerMainMenuForSuperAdmin();
                }
                else if (ans == "#")
                {
                    SuperAdminMenu superAdminMenu = new SuperAdminMenu();
                    superAdminMenu.SuperAdminMainMenu();
                }
                else
                {
                    System.Console.WriteLine("++++Wrong Input++++");
                    OwnerMainMenuForSuperAdmin();
                }
            }
            catch (System.Exception)
            {
                System.Console.WriteLine("=====Wrong input======");
                OwnerMainMenuForSuperAdmin();
            }




        }

        public void OwnerMainMenus()
        {

            try
            {
                System.Console.WriteLine("Emter 1 to get your profile\n enter 2 to update owner\nEnter # to quite application");
                string ans = Console.ReadLine();
                if (ans == "1")
                {
                    GetOwnerByEmail();
                    OwnerMainMenus();
                }
                else if (ans == "2")
                {
                    UpdateOwner();
                    OwnerMainMenus();
                }
                else if (ans == "#")
                {
                    MainMenu main = new MainMenu();
                    main.Main();
                }
                else
                {
                    System.Console.WriteLine("++++Wrong Input++++");
                    OwnerMainMenus();
                }
            }
            catch (System.Exception)
            {
                System.Console.WriteLine("=====Wrong input======");
                OwnerMainMenus();
            }




        }
        // public void OwnerMainMenu()
        // {
        //     System.Console.WriteLine("=====Welcome Back To Owner Menu======");
        //     System.Console.WriteLine();
        //     try
        //     {
        //         System.Console.WriteLine("Enter 1 to get all owner\nEnter 2  to delete owner\nEmter 3 to get owner by email\nEnter 4 to get owner by Id\n enter 5 to update owner\nEnter 6 to create Owner\nEnter # to quite application");
        //         string ans = Console.ReadLine();
        //         if (ans == "1")
        //         {
        //             GetAllOwner();
        //             OwnerMainMenu();
        //         }
        //         else if (ans == "2")
        //         {
        //             DeleteOwner();
        //             OwnerMainMenu();
        //         }
        //         else if (ans == "3")
        //         {
        //             GetOwnerByEmail();
        //             OwnerMainMenu();
        //         }
        //         else if (ans == "4")
        //         {
        //             GetownerById();
        //             OwnerMainMenu();
        //         }
        //         else if (ans == "5")
        //         {
        //             UpdateOwner();
        //             OwnerMainMenu();
        //         }
        //         else if (ans == "6")
        //         {
        //             CreateOwner();
        //             OwnerMainMenu();
        //         }
        //         else if (ans == "#")
        //         {
        //             MainMenu main = new MainMenu();
        //             main.Main();
        //         }
        //         else
        //         {
        //             System.Console.WriteLine("++++Wrong Input++++");
        //             OwnerMainMenu();
        //         }
        //     }
        //     catch (System.Exception)
        //     {
        //         System.Console.WriteLine("=====Wrong input======");
        //         OwnerMainMenu();
        //     }




        // }



        public void OwnerMainMenuForManager()
        {
            try
            {
                System.Console.WriteLine("Enter 1 to get all owner\nEmter 3 to get owner by email\nEnter 4 to get owner by Id\nEnter 6 to create Owner\nEnter # to quite application");
                string ans = Console.ReadLine();
                if (ans == "1")
                {
                    GetAllOwner();
                    OwnerMainMenuForManager();
                }
                else if (ans == "3")
                {
                    GetOwnerByEmail();
                    OwnerMainMenuForManager();
                }
                else if (ans == "4")
                {
                    GetownerById();
                    OwnerMainMenuForManager();
                }
                else if (ans == "5")
                {
                    UpdateOwner();
                    OwnerMainMenuForManager();
                }
                else if (ans == "#")
                {
                    ManagerMenu managerMenu = new ManagerMenu();
                    managerMenu.ManagerNewMainMenu();
                }
                else if (ans == "6")
                {
                    CreateOwner();
                    OwnerMainMenuForSuperAdmin();
                }
                else
                {
                    System.Console.WriteLine("++++Wrong Input++++");
                    OwnerMainMenuForManager();
                }
            }
            catch (System.Exception)
            {
                System.Console.WriteLine("=====Wrong input======");
                OwnerMainMenuForManager();
            }
        }
        public void CreateOwner()
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
                CreateOwner();
            }


            IUserService userServiceuserService = new UserService();
            IOwnerService ownerService = new OwnerService();
            userServiceuserService.CreateUser(email, firstName, lastName, phoneNumber, age, address, gender, pass, "Owner");
            ownerService.CreateOwner(email);
            System.Console.WriteLine("Created sucessfully");



        }
        public void DeleteOwner()
        {


            System.Console.WriteLine("Enter Owner Email");
            string email = Console.ReadLine().ToLower();
            ownerService.DeleteOwner(email);
            userServiceuserService.DeleteUser(email);
            System.Console.WriteLine("Deleted succesfully");

        }
        public void GetAllOwner()
        {
            ownerService.GetAllOwner();
        }
        public void GetOwnerByEmail()
        {

            System.Console.WriteLine("Enter owners Email");
            string email = Console.ReadLine().ToLower();
            var getByEmail = ownerService.GetOwnerByEmail(email);
            var getUserByEmail = userServiceuserService.GetUserByEmail(getByEmail.UserEmail);
            System.Console.WriteLine($"OwnersName : {getUserByEmail.LastName}  {getUserByEmail.FirstName} OwnersEmail :{getUserByEmail.Email}  ");

        }
        public void GetownerById()
        {

            System.Console.WriteLine("Enter owners id");
            int id = int.Parse(Console.ReadLine());
            var getById = ownerService.GetOwnerById(id);
            var getUserByEmail = userServiceuserService.GetUserByEmail(getById.UserEmail);
            System.Console.WriteLine($"OwnersName : {getUserByEmail.LastName}  {getUserByEmail.FirstName} OwnersEmail :{getUserByEmail.Email}  ");

        }
        public void UpdateOwner()
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
                UpdateOwner();
            }
            var getByEmail = ownerService.GetOwnerByEmail(email);
            var getUserByEmail = userServiceuserService.GetUserByEmail(email);
            userServiceuserService.UpdateUser(email, Newemail, FirstName, LastName, PhoneNumber, Age, Address, gender, Password, getUserByEmail.Wallet);
            getByEmail.UserEmail = Newemail;
            System.Console.WriteLine("Updated succesfully");

        }
    }
}