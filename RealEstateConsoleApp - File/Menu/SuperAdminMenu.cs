namespace RealEstateConsoleApp.Menu
{
    public class SuperAdminMenu
    {
        // MainMenu main = new MainMenu();
        // CartegoryMenu cartegoryMenu = new CartegoryMenu();
        // PropertyMenu propertyMenu = new PropertyMenu();
        // TransactionMenu transactionMenu = new TransactionMenu();
        // CustomerMenu customerMenu = new CustomerMenu();
        // UserMenu userMenu = new UserMenu();
        // OwnerMenu ownerMenu = new OwnerMenu();
        // ManagerMenu managerMenu= new ManagerMenu(); 

        public void SuperAdminMainMenu()
        {
            System.Console.WriteLine("====Welcome Back SuperAdmin====");
            System.Console.WriteLine("");
            System.Console.WriteLine("Enter 1 for cartegoryMenu\nEnter 2 for CustomerMenu\nEnter 3 forPropertyMenu\nEnter 4 for transaction menu\nEnter 5 for usermenu\nEnter 6 for manager menu\nEnter 7 for Owner menu\nEnter # to exit");
            string ans = Console.ReadLine();
            if (ans == "1")
            {
                CartegoryMenu cartegoryMenu = new CartegoryMenu();
                cartegoryMenu.CustomerCartegoryMainMenu();
                SuperAdminMainMenu();
            }
            else if (ans == "2")
            {
                CustomerMenu customerMenu = new CustomerMenu();
                customerMenu.CustomerMainMenuForSUperAdmin();
                SuperAdminMainMenu();
            }
            else if (ans == "3")
            {
                PropertyMenu propertyMenu = new PropertyMenu();
                propertyMenu.PropertyMainMenuForSuperAdmin();
                SuperAdminMainMenu();
            }
            else if (ans == "4")
            {
                TransactionMenu transactionMenu = new TransactionMenu();
                transactionMenu.TransactionMainMenuForSuperAdmin();
                SuperAdminMainMenu();
            }
            else if (ans == "5")
            {
                UserMenu userMenu = new UserMenu();
                userMenu.UserMainMenuForAdmin();
                SuperAdminMainMenu();
            }

            else if (ans == "6")
            {
                ManagerMenu managerMenu = new ManagerMenu();
                managerMenu.ManagerMainMenuForSuperAdmin();
                SuperAdminMainMenu();
            }

            else if (ans == "7")
            {
                OwnerMenu ownerMenu = new OwnerMenu();
                ownerMenu.OwnerMainMenuForSuperAdmin();
                SuperAdminMainMenu();
            }
            else if (ans == "#")
            {
                MainMenu main = new MainMenu();
                main.Main();
            }
            else
            {
                System.Console.WriteLine("++++Wrong Input++++");
                SuperAdminMainMenu();
            }
        }
    }



}