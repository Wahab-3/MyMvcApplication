using RealEstateConsoleApp.Models;
using RealEstateConsoleApp.Models.Entities;
using RealEstateConsoleApp.Service.Implementation;
using RealEstateConsoleApp.Service.Interface;

namespace RealEstateConsoleApp.Menu
{
    public class TransactionMenu
    {
        ITransactionService transactionService = new TransactionService();
        IPropertyService propertyService = new PropertyService();
        IUserService userService = new UserService();
        CustomerMenu customerMenu = new CustomerMenu();

        // CartegoryMenu cartegoryMenu = new CartegoryMenu();
        // ICartegoryService cartegoryService = new CartegoryService();

        public void TransactionMainMenuForCustomer()
        {
            try
            {
                System.Console.WriteLine("Enter 1 to Create Transaction\n Enter 2 to Get Transaction By Email\nEnter # to quite application");
                string ans = Console.ReadLine();
                if (ans == "1")
                {
                    // CreateTransaction();
                    TransactionMainMenuForCustomer();
                }
                else if (ans == "5")
                {
                    GetTransactionByEmail();
                    TransactionMainMenuForCustomer();
                }
                else if (ans == "#")
                {

                    customerMenu.CustomerMainMenus();

                }
                else
                {
                    System.Console.WriteLine("++++Wrong Input++++");
                    TransactionMainMenuForCustomer();

                }

            }

            catch (System.Exception)
            {
                System.Console.WriteLine("=====Wrong input======");
                TransactionMainMenuForCustomer();
            }
        }
        // public void TransactionMainMenu()
        // {

        //     try
        //     {
        //         System.Console.WriteLine("Enter 1 to Create Transaction\nEnter 2 to get allTransaction\nEnter 3 to delete Transaction\nEnter 4 to Get Transaction By Id\n Enter 5 to Get Transaction By Email\nEnter 6 to Get Transaction By Property Id\nEnter 7 to Update Transactionn");
        //         string ans = Console.ReadLine();
        //         if (ans == "1")
        //         {
        //             CreateTransaction();
        //             TransactionMainMenu();
        //         }
        //         else if (ans == "2")
        //         {
        //             GetAllTransaction();
        //             TransactionMainMenu();
        //         }
        //         else if (ans == "3")
        //         {
        //             DeleteTransaction();
        //             TransactionMainMenu();
        //         }
        //         else if (ans == "4")
        //         {
        //             GetTransactionById();
        //             TransactionMainMenu();

        //         }
        //         else if (ans == "5")
        //         {
        //             GetTransactionByEmail();
        //             TransactionMainMenu();

        //         }
        //         else if (ans == "6")
        //         {
        //             GetTransactionByPropertyId();
        //             TransactionMainMenu();
        //         }
        //         else if (ans == "7")
        //         {
        //             UpdateTransaction();
        //             TransactionMainMenu();
        //         }

        //         else
        //         {
        //             System.Console.WriteLine("++++Wrong Input++++");
        //             TransactionMainMenu();

        //         }

        //     }

        //     catch (System.Exception)
        //     {
        //         System.Console.WriteLine("=====Wrong input======");
        //         TransactionMainMenu();
        //     }
        // }

        public void TransactionMainMenuForSuperAdmin()
        {

            try
            {
                System.Console.WriteLine("Enter 1 to Create Transaction\nEnter 2 to get allTransaction\nEnter 3 to delete Transaction\nEnter 4 to Get Transaction By Id\n Enter 5 to Get Transaction By Email\nEnter 6 to Get Transaction By Property Id\nEnter 7 to Update Transaction\nEnter # to exit");
                string ans = Console.ReadLine();
                if (ans == "1")
                {
                    // CreateTransaction();
                    TransactionMainMenuForSuperAdmin();
                }
                else if (ans == "2")
                {
                    GetAllTransaction();
                    TransactionMainMenuForSuperAdmin();
                }
                else if (ans == "3")
                {
                    DeleteTransaction();
                    TransactionMainMenuForSuperAdmin();
                }
                else if (ans == "4")
                {
                    GetTransactionById();
                    TransactionMainMenuForSuperAdmin();

                }
                else if (ans == "5")
                {
                    GetTransactionByEmail();
                    TransactionMainMenuForSuperAdmin();

                }
                else if (ans == "6")
                {
                    GetTransactionByPropertyId();
                    TransactionMainMenuForSuperAdmin();
                }
                else if (ans == "7")
                {
                    UpdateTransaction();
                    TransactionMainMenuForSuperAdmin();
                }
                else if (ans == "#")
                {
                    SuperAdminMenu superAdminMenu = new SuperAdminMenu();
                    superAdminMenu.SuperAdminMainMenu();
                }
                else
                {
                    System.Console.WriteLine("++++Wrong Input++++");
                    TransactionMainMenuForSuperAdmin();

                }

            }

            catch (System.Exception)
            {
                System.Console.WriteLine("=====Wrong input======");
                TransactionMainMenuForSuperAdmin();
            }
        }

        public void TransactionMainMenuForManager()
        {

            try
            {
                System.Console.WriteLine("Enter 2 to get allTransaction\nEnter 4 to Get Transaction By Id\n Enter 5 to Get Transaction By Email\nEnter 6 to Get Transaction By Property Id\nEnter # to quite application");
                string ans = Console.ReadLine();
                if (ans == "1")
                {
                    // CreateTransaction();
                    TransactionMainMenuForManager();
                }
                else if (ans == "2")
                {
                    GetAllTransaction();
                    TransactionMainMenuForManager();
                }
                else if (ans == "3")
                {
                    DeleteTransaction();
                    TransactionMainMenuForManager();
                }
                else if (ans == "4")
                {
                    GetTransactionById();
                    TransactionMainMenuForManager();

                }
                else if (ans == "5")
                {
                    GetTransactionByEmail();
                    TransactionMainMenuForManager();

                }
                else if (ans == "6")
                {
                    GetTransactionByPropertyId();
                    TransactionMainMenuForManager();
                }
                else if (ans == "7")
                {
                    UpdateTransaction();
                    TransactionMainMenuForManager();
                }
                else if (ans == "#")
                {

                    ManagerMenu managerMenu = new ManagerMenu();
                    managerMenu.ManagerNewMainMenu();

                }
                else
                {
                    System.Console.WriteLine("++++Wrong Input++++");
                    TransactionMainMenuForManager();

                }


            }

            catch (System.Exception)
            {
                System.Console.WriteLine("=====Wrong input======");
                TransactionMainMenuForManager();
            }
        }


        public void GetAllTransaction()
        {
            transactionService.GetAllTransaction();
        }

        public void CreateTransaction(int id)
        {

           
            var user = userService.GetUserByEmail(UserSession.LoggedInUserEmail);
            var property = propertyService.GetPropertyById(id);
            if (user.Wallet < property.Price)
            {
                System.Console.WriteLine("Update your wallet");
            }
            else
            {
                if (property.TypeOfLeases == Models.TypeOfLeases.ForSale)
                {
                    user.Wallet -= property.Price;
                    transactionService.CreateTransaction(UserSession.LoggedInUserEmail, id);
                    System.Console.WriteLine("+++Payment sucessful+++");

                    System.Console.WriteLine($"====Recipt=====\nUserName{user.LastName} {user.FirstName} UserEmail{user.Email}\nPropertyId {property.Id}. CartegoryName :{property.CartegoryName} PropertyLocation : {property.Location} TypeOfLease :{property.TypeOfLeases}  PropertyPrice : {property.Price}  IsAvaillable : {property.IsAvailable}  propertyDescription :{property.Description}  OwnerTagNumber :{property.OwnersTagNumber}");
                }
                else
                {
                    System.Console.WriteLine("Enter amount of month you will be renting property for");
                    int months = int.Parse(Console.ReadLine());
                    if (user.Wallet < property.Price * months)
                    {
                        System.Console.WriteLine("Update your wallet");
                        UserMenu userMenu = new UserMenu();
                        userMenu.UpdateWallet();
                    }
                    else
                    {
                        user.Wallet -= property.Price * months;
                        transactionService.CreateTransaction(UserSession.LoggedInUserEmail, id);
                        System.Console.WriteLine("+++Payment sucessful+++");
                        System.Console.WriteLine($"====Recipt=====\nUserName{user.LastName} {user.FirstName} UserEmail{user.Email}\nPropertyId {property.Id}. CartegoryName :{property.CartegoryName} PropertyLocation : {property.Location} TypeOfLease :{property.TypeOfLeases}  PropertyPrice : {property.Price}  IsAvaillable : {property.IsAvailable}  propertyDescription :{property.Description}  OwnerTagNumber :{property.OwnersTagNumber}");
                        transactionService.CreateTransaction(UserSession.LoggedInUserEmail, id);
                        

                    }

                }

            }



        }




        public void DeleteTransaction()
        {

            transactionService.GetAllTransaction();
            System.Console.WriteLine("Enter Transaction Id");
            int Id = int.Parse(Console.ReadLine());
            transactionService.DeleteTransaction(Id);
            System.Console.WriteLine("Deleted Succesfully");




        }

        public void GetTransactionById()
        {

            transactionService.GetAllTransaction();
            System.Console.WriteLine("Enter Transaction Id");
            int Id = int.Parse(Console.ReadLine());
            var getById = transactionService.GetTransactionById(Id);
            System.Console.WriteLine($"{getById.Id}. TransactionUserEmail :{getById.UserEmail} PropertyId : {getById.PropertyId} PropertyPrice :{getById.TotalPrice}  PropertyLeaseType : {getById.TypeOfLeases} ");


        }



        public void GetTransactionByEmail()
        {

            System.Console.WriteLine("Enter UserEmail");
            string UserEmail = Console.ReadLine().ToLower();
            var getByEmail = transactionService.GetTransactionByEmail(UserEmail);
            System.Console.WriteLine($"{getByEmail.Id}. TransactionUserEmail :{getByEmail.UserEmail} PropertyId : {getByEmail.PropertyId} PropertyPrice :{getByEmail.TotalPrice}  PropertyLeaseType : {getByEmail.TypeOfLeases} ");


        }





        public void GetTransactionByPropertyId()
        {

            System.Console.WriteLine("enter property Id");
            int ans = int.Parse(Console.ReadLine());
            var getByPropertyId = transactionService.GetTransactionByPropertyId(ans);
            System.Console.WriteLine($"{getByPropertyId.Id}. TransactionUserEmail :{getByPropertyId.UserEmail} PropertyId : {getByPropertyId.PropertyId} PropertyPrice :{getByPropertyId.TotalPrice}  PropertyLeaseType : {getByPropertyId.TypeOfLeases} ");


        }



        public void UpdateTransaction()
        {

            transactionService.GetAllTransaction();
            System.Console.WriteLine("Enter TransactionId");
            int TransactionId = int.Parse(Console.ReadLine());
            System.Console.WriteLine("Enter Property Id");
            var getById = transactionService.GetTransactionById(TransactionId);
            int PropertyId = int.Parse(Console.ReadLine());
            System.Console.WriteLine("Enter  1 if transaction isSuccessful\n Enter 2 if transaction is not Successful");
            string ans = Console.ReadLine();
            bool isSuccessful = false;
            if (ans == "1")
            {
                isSuccessful = true;
            }
            else if (ans == "2")
            {
                isSuccessful = false;
            }
            else
            {
                System.Console.WriteLine("++++Wrong Input++++");
                UpdateTransaction();
            }

            transactionService.UpdateTransaction(TransactionId, PropertyId, isSuccessful, getById.TypeOfLeases);

        }

    }
}