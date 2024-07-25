using RealEstateConsoleApp.Models;
using RealEstateConsoleApp.Models.Entities;
using RealEstateConsoleApp.Service.Implementation;
using RealEstateConsoleApp.Service.Interface;

namespace RealEstateConsoleApp.Menu
{
    public class UserMenu
    {
        // ICustomerService customerService = new CustomerService();
        IUserService userServiceuserService = new UserService();
        public void UserMainMenuForManager()
        {

            try
            {
                System.Console.WriteLine("Enter 1 to get all Users\nEnter 2  Get User By Email\nEmter 3 to get Get User By Id\nEnter # to exit");
                string ans = Console.ReadLine();
                if (ans == "1")
                {
                    GetAllUser();
                    UserMainMenuForManager();

                }
                else if (ans == "2")
                {
                    GetUserByEmail();
                    UserMainMenuForManager();
                }
                else if (ans == "3")
                {
                    GetUserById();
                    UserMainMenuForManager();

                }
                else if (ans == "#")
                {
                    ManagerMenu managerMenu = new ManagerMenu();
                    managerMenu.ManagerNewMainMenu();
                }
                else
                {
                    System.Console.WriteLine("++++Wrong Input++++");
                    UserMainMenuForManager();
                }
            }
            catch (System.Exception)
            {
                System.Console.WriteLine("=====Wrong input======");
                UserMainMenuForManager();
            }
        }




        // }
        // public void UserMainMenu()
        // {

        //     try
        //     {
        //         System.Console.WriteLine("Enter 1 to get all Users\nEnter 2  Get User By Email\nEmter 3 to get Get User By Id\nEnter 4 to UpdateUser");
        //         string ans = Console.ReadLine();
        //         if (ans == "1")
        //         {
        //             GetAllUser();
        //             UserMainMenu();

        //         }
        //         else if (ans == "2")
        //         {
        //             GetUserByEmail();
        //             UserMainMenu();
        //         }
        //         else if (ans == "3")
        //         {
        //             GetUserById();
        //             UserMainMenu();

        //         }
        //         else if (ans == "4")
        //         {
        //             UpdateUser();
        //             UserMainMenu();
        //         }
        //         else
        //         {
        //             System.Console.WriteLine("++++Wrong Input++++");
        //             UserMainMenu();
        //         }
        //     }
        //     catch (System.Exception)
        //     {
        //         System.Console.WriteLine("=====Wrong input======");
        //         UserMainMenu();
        //     }




        // }


        public void UserMainMenuForAdmin()
        {

            try
            {
                System.Console.WriteLine("Enter 1 to get all Users\nEnter 2  Get User By Email\nEmter 3 to get Get User By Id\nEnter 4 to UpdateUser\nEnter # to Exit");
                string ans = Console.ReadLine();
                if (ans == "1")
                {
                    GetAllUser();
                    UserMainMenuForAdmin();

                }
                else if (ans == "2")
                {
                    GetUserByEmail();
                    UserMainMenuForAdmin();
                }
                else if (ans == "3")
                {
                    GetUserById();
                    UserMainMenuForAdmin();

                }
                else if (ans == "4")
                {
                    UpdateUser();
                    UserMainMenuForAdmin();
                }
                else if (ans == "#")
                {
                    SuperAdminMenu superAdminMenu = new SuperAdminMenu();
                    superAdminMenu.SuperAdminMainMenu();
                }
                else
                {
                    System.Console.WriteLine("++++Wrong Input++++");
                    UserMainMenuForAdmin();
                }
            }
            catch (System.Exception)
            {
                System.Console.WriteLine("=====Wrong input======");
                UserMainMenuForAdmin();
            }




        }

        public void GetAllUser()
        {
            userServiceuserService.GetAllUser();
        }
        public void GetUserByEmail()
        {

            System.Console.WriteLine("Enter User Email");
            string email = Console.ReadLine().ToLower();
            var getUserByEmail = userServiceuserService.GetUserByEmail(email);
            System.Console.WriteLine($"UserName : {getUserByEmail.LastName}  {getUserByEmail.FirstName} UserEmail :{getUserByEmail.Email}  ");

        }
        public void GetUserById()
        {

            System.Console.WriteLine("Enter User id");
            int id = int.Parse(Console.ReadLine());
            var getUserById = userServiceuserService.GetUserById(id);
            System.Console.WriteLine($"CustomersName : {getUserById.LastName}  {getUserById.FirstName} CustomersEmail :{getUserById.Email}  ");

        }
        public void UpdateUser()
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
                UpdateUser();
            }
            var getUserByEmail = userServiceuserService.GetUserByEmail(email);
            userServiceuserService.UpdateUser(email, Newemail, FirstName, LastName, PhoneNumber, Age, Address, gender, Password, getUserByEmail.Wallet);
            System.Console.WriteLine("Updated succesfully");

        }


        public void UpdateWallet()
        {
           
            userServiceuserService.GetUserByEmail( UserSession.LoggedInUserEmail);
            System.Console.WriteLine("Enter Ammount to be added");
            double ans = double.Parse(Console.ReadLine());
            if (ans <= 0)
            {
                System.Console.WriteLine("cannot add amount less than 0");
            }
            else
            {
                var getUser = userServiceuserService.GetUserByEmail( UserSession.LoggedInUserEmail);
                getUser.Wallet += ans;
                System.Console.WriteLine("wallet updated successfully");
            }

        }
    }
}