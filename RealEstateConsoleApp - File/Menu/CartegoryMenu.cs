using RealEstateConsoleApp.Models;
using RealEstateConsoleApp.Service.Implementation;
using RealEstateConsoleApp.Service.Interface;

namespace RealEstateConsoleApp.Menu
{
    public class CartegoryMenu
    {
        ICartegoryService cartegoryService = new CartegoryService();


        public void CustomerCartegoryMainMenu()
        {
            try
            {
                System.Console.WriteLine(" ");
                System.Console.WriteLine("Enter 1 to get all cartegory\nEnter 2 to Get Cartegory By Id\nEnter 3 to Get Cartegory By Name\nEnter # to exit");
                string ans = Console.ReadLine();
                if (ans == "1")
                {
                    GetAllCartegory();
                    CustomerCartegoryMainMenu();
                }
                else if (ans == "2")
                {
                    GetCartegoryById();
                    CustomerCartegoryMainMenu();
                }
                else if (ans == "3")
                {
                    GetCartegoryByName();
                    CustomerCartegoryMainMenu();
                }
                else if (ans == "#")
                {
                    CustomerMenu customerMenu = new CustomerMenu();
                    customerMenu.CustomerMainMenus();
                }
                else
                {
                    System.Console.WriteLine("++++Wrong Input++++");
                    CustomerCartegoryMainMenu();
                }
            }


            catch (System.Exception)
            {
                System.Console.WriteLine("=====Wrong input======");
                CustomerCartegoryMainMenu();
            }
        }
        // public void CartegoryMainMenu()
        // {

        //     try
        //     {
        //         System.Console.WriteLine("Enter 1 to create Cartegory\nEnter 2 to get all cartegory\nEnter 3 to delete cartegory\nEnter 4 to Get Cartegory By Id\n Enter 5 to Get Cartegory By Name\nEnter 6 to Update Cartegory");
        //         string ans = Console.ReadLine();
        //         if (ans == "1")
        //         {
        //             CreateCartegory();
        //             CartegoryMainMenu();
        //         }
        //         else if (ans == "2")
        //         {
        //             GetAllCartegory();
        //             CartegoryMainMenu();
        //         }
        //         else if (ans == "3")
        //         {
        //             DeleteCartegory();
        //             CartegoryMainMenu();
        //         }
        //         else if (ans == "4")
        //         {
        //             GetCartegoryById();
        //             CartegoryMainMenu();
        //         }
        //         else if (ans == "5")
        //         {
        //             GetCartegoryByName();
        //             CartegoryMainMenu();
        //         }
        //         else if (ans == "6")
        //         {
        //             UpdateCartegory();
        //             CartegoryMainMenu();
        //         }
        //         else
        //         {
        //             System.Console.WriteLine("++++Wrong Input++++");
        //             CartegoryMainMenu();
        //         }
        //     }


        //     catch (System.Exception)
        //     {
        //         System.Console.WriteLine("=====Wrong input======");
        //         CartegoryMainMenu();
        //     }
        // }



        public void SuperAdminCartegoryMainMenu()
        {

            try
            {
                System.Console.WriteLine("Enter 1 to create Cartegory\nEnter 2 to get all cartegory\nEnter 3 to delete cartegory\nEnter 4 to Get Cartegory By Id\n Enter 5 to Get Cartegory By Name\nEnter 6 to Update Cartegory\nEnter # to exit");
                string ans = Console.ReadLine();
                if (ans == "1")
                {
                    CreateCartegory();
                    SuperAdminCartegoryMainMenu();
                }
                else if (ans == "2")
                {
                    GetAllCartegory();
                    SuperAdminCartegoryMainMenu();
                }
                else if (ans == "3")
                {
                    DeleteCartegory();
                    SuperAdminCartegoryMainMenu();
                }
                else if (ans == "4")
                {
                    GetCartegoryById();
                    SuperAdminCartegoryMainMenu();
                }
                else if (ans == "5")
                {
                    GetCartegoryByName();
                    SuperAdminCartegoryMainMenu();
                }
                else if (ans == "6")
                {
                    UpdateCartegory();
                    SuperAdminCartegoryMainMenu();
                }
                else if (ans == "#")
                {
                    SuperAdminMenu superAdminMenu = new SuperAdminMenu();
                    superAdminMenu.SuperAdminMainMenu();
                }
                else
                {
                    System.Console.WriteLine("++++Wrong Input++++");
                    SuperAdminCartegoryMainMenu();
                }
            }


            catch (System.Exception)
            {
                System.Console.WriteLine("=====Wrong input======");
                SuperAdminCartegoryMainMenu();
            }
        }
        public void OwnerCartegoryMainMenu()
        {

            try
            {
                System.Console.WriteLine("Enter 1 to create Cartegory\nEnter 2 to get all cartegory\nEnter 4 to Get Cartegory By Id\n Enter 5 to Get Cartegory By Name\nEnter 6 to Update Cartegory\nEnter # to Exit ");
                string ans = Console.ReadLine();
                if (ans == "1")
                {
                    CreateCartegory();
                    ManagerCartegoryMainMenu();
                }
                else if (ans == "2")
                {
                    GetAllCartegory();
                    ManagerCartegoryMainMenu();
                }
                else if (ans == "#")
                {
                    OwnerMenu ownerMenu = new OwnerMenu();
                    ownerMenu.OwnerNewMainMenu();
                }
                else if (ans == "4")
                {
                    GetCartegoryById();
                    ManagerCartegoryMainMenu();
                }
                else if (ans == "5")
                {
                    GetCartegoryByName();
                    ManagerCartegoryMainMenu();
                }
                else if (ans == "6")
                {
                    UpdateCartegory();
                    ManagerCartegoryMainMenu();
                }
                else
                {
                    System.Console.WriteLine("++++Wrong Input++++");
                    ManagerCartegoryMainMenu();
                }
            }


            catch (System.Exception)
            {
                System.Console.WriteLine("=====Wrong input======");
                ManagerCartegoryMainMenu();
            }
        }

        public void ManagerCartegoryMainMenu()
        {

            try
            {
                System.Console.WriteLine("Enter 1 to create Cartegory\nEnter 2 to get all cartegory\nEnter 4 to Get Cartegory By Id\n Enter 5 to Get Cartegory By Name\nEnter 6 to Update Cartegory\nEnter # to Exit ");
                string ans = Console.ReadLine();
                if (ans == "1")
                {
                    CreateCartegory();
                    ManagerCartegoryMainMenu();
                }
                else if (ans == "2")
                {
                    GetAllCartegory();
                    ManagerCartegoryMainMenu();
                }
                else if (ans == "#")
                {
                    ManagerMenu managerMenu = new ManagerMenu();
                    managerMenu.ManagerNewMainMenu();
                }
                else if (ans == "4")
                {
                    GetCartegoryById();
                    ManagerCartegoryMainMenu();
                }
                else if (ans == "5")
                {
                    GetCartegoryByName();
                    ManagerCartegoryMainMenu();
                }
                else if (ans == "6")
                {
                    UpdateCartegory();
                    ManagerCartegoryMainMenu();
                }
                else
                {
                    System.Console.WriteLine("++++Wrong Input++++");
                    ManagerCartegoryMainMenu();
                }
            }


            catch (System.Exception)
            {
                System.Console.WriteLine("=====Wrong input======");
                ManagerCartegoryMainMenu();
            }
        }

        public void GetAllCartegory()
        {
            cartegoryService.GetAllCartegory();
        }

        public void CreateCartegory()
        {

            cartegoryService.GetAllCartegory();
            System.Console.WriteLine("Enter new cartegoryName");
            string cartegoryName = Console.ReadLine().ToLower();
            System.Console.WriteLine("Enter Cartegory Description");
            string Description = Console.ReadLine().ToLower();
            cartegoryService.CreateCartegory(cartegoryName, Description);
            System.Console.WriteLine("Created sucessfully");


        }




        public void DeleteCartegory()
        {

            cartegoryService.GetAllCartegory();
            System.Console.WriteLine("Enter CartegoryName");
            string cartegoryName = Console.ReadLine().ToLower();
            cartegoryService.DeleteCartegory(cartegoryName);
            System.Console.WriteLine("Deleted Succesfully");




        }

        public void GetCartegoryById()
        {

            cartegoryService.GetAllCartegory();
            System.Console.WriteLine("Enter CartegoryId");
            int CartegoryId = int.Parse(Console.ReadLine());
            var getById = cartegoryService.GetCartegoryById(CartegoryId);
            System.Console.WriteLine($"{getById.Id}. CartegoryName :{getById.Name} CartegoryDescription : {getById.Description}");


        }



        public void GetCartegoryByName()
        {

            cartegoryService.GetAllCartegory();
            System.Console.WriteLine("Enter CartegoryName");
            string CartegoryName = Console.ReadLine().ToLower();
            var getByName = cartegoryService.GetCartegoryByName(CartegoryName);
            System.Console.WriteLine($"{getByName.Id}. CartegoryName :{getByName.Name} CartegoryDescription : {getByName.Description}");



        }

        public void UpdateCartegory()
        {

            cartegoryService.GetAllCartegory();
            System.Console.WriteLine("Enter CartegoryName to be updated");
            string CartegoryName = Console.ReadLine().ToLower();
            System.Console.WriteLine("Enter Cartegory New Name");
            string newCartegoryName = Console.ReadLine().ToLower();
            System.Console.WriteLine("Enter Cartegory New Name Description");
            string newCartegoryDescription = Console.ReadLine();
            cartegoryService.UpdateCartegory(CartegoryName, newCartegoryName, newCartegoryDescription);
            System.Console.WriteLine("Updated Succesfully");


        }
    }
}




