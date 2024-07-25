using RealEstateConsoleApp.Models;
using RealEstateConsoleApp.Models.Entities;
using RealEstateConsoleApp.Service.Implementation;
using RealEstateConsoleApp.Service.Interface;

namespace RealEstateConsoleApp.Menu
{
    public class MainMenu
    {
        public void Main()
        {
            try
            {
                System.Console.WriteLine("=====welcome to our RealEstate Console App========");
                System.Console.WriteLine();
                System.Console.WriteLine("Enter 1 to SignUp\nEnter 2 to Login");
                string ans = Console.ReadLine();
                if (ans == "1")
                {
                    SignUp();
                    Main();
                }
                else if (ans == "2")
                {
                    Login();
                }
                else
                {
                    System.Console.WriteLine("++++Wrong Input++++");
                    Main();
                }
            }
            catch (System.Exception)
            {
                System.Console.WriteLine("++++Wrong Input++++");
                Main();
            }
        }

        public void SignUp()
        {
            try
            {
                System.Console.WriteLine("Enter Your FirstName");
                string firstName = Console.ReadLine();
                System.Console.WriteLine("Enter Your LastName");
                string lastName = Console.ReadLine();
                System.Console.WriteLine("Enter Your Email");
                string email = Console.ReadLine().ToLower();
                System.Console.WriteLine("Enter Your phoneNumber");
                long phoneNumber = long.Parse(Console.ReadLine());
                System.Console.WriteLine("Enter Your age");
                int age = int.Parse(Console.ReadLine());
                System.Console.WriteLine("Enter Your Address");
                string address = Console.ReadLine();
                System.Console.WriteLine("Enter Your Password");
                string pass = Console.ReadLine().ToLower();
                System.Console.WriteLine("Enter  1 for male\nEnter 2 for Female\nEnter 3 for unknown");
                int ans = int.Parse(Console.ReadLine());
                Gender gender = new Gender();
                if (ans == 1)
                {
                    gender = Gender.Male;
                }
                else if (ans == 2)
                {
                    gender = Gender.Female;
                }
                else if (ans == 3)
                {
                    gender = Gender.Unknown;

                }
                else
                {
                    System.Console.WriteLine("++++Wrong Input++++");
                    SignUp();
                }


                IUserService userServiceuserService = new UserService();
                ICustomerService customerService = new CustomerService();
                userServiceuserService.CreateUser(email, firstName, lastName, phoneNumber, age, address, gender, pass, "Customer");
                customerService.CreateCustomer(email);
                System.Console.WriteLine("====SignUp Succesfull===");


            }
            catch (System.Exception)
            {
                System.Console.WriteLine("++++Wrong Input++++");
                Main();
            }
        }

        public void Login()
        {
            IUserService userServiceuserService = new UserService();

            try
            {
                System.Console.WriteLine("Enter Your Email");
                string email = Console.ReadLine().ToLower();
                System.Console.WriteLine("Enter Your Password");
                string pass = Console.ReadLine().ToLower();
                var user = userServiceuserService.GetUserByEmailAndPassword(email, pass);
                UserSession.SetLoggedInUserEmail(email);

                if (user.RoleName == "Customer")
                {
                    CustomerMenu customerMenu = new CustomerMenu();
                    System.Console.WriteLine("====Login Succesfull===");
                    customerMenu.CustomerMainMenus();
                }
                else if (user.RoleName == "manager")
                {
                    ManagerMenu managerMenu = new ManagerMenu();
                    System.Console.WriteLine("====Login Succesfull===");
                    managerMenu.ManagerNewMainMenu();

                }
                else if (user.RoleName == "SuperAdmin")
                {
                    SuperAdminMenu superAdminMenu = new SuperAdminMenu();
                    System.Console.WriteLine("====Login Succesfull===");
                    superAdminMenu.SuperAdminMainMenu();
                }
                else if (user.RoleName == "Owner")
                {
                    OwnerMenu ownerMenu = new OwnerMenu();
                    System.Console.WriteLine("====Login Succesfull===");
                    ownerMenu.OwnerNewMainMenu();
                }
                else
                {
                    System.Console.WriteLine("++++Customer does not exist on our application++++++");
                    Main();
                }




            }
            catch (System.Exception)
            {
                System.Console.WriteLine("++++Wrong Input++++");
                Main();
            }
        }



    }
}