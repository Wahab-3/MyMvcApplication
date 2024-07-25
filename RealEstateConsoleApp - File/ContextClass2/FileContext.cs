using RealEstateConsoleApp;
using RealEstateConsoleApp.Models;

namespace RealEstateConsoleApp___File
{
    public class FileContext
    {
        public static string FilePath = @"C:\\Users\\USER\\Desktop\\PogrammingProjects\\RealEstateConsoleApp - File\\DbFolder";

        public static void CreateFolderAndFIle(string FilePath)
        {


            if (!Directory.Exists(FilePath))
            {
                Directory.CreateDirectory(FilePath);
            }


            var cartegory = Path.Combine(FilePath, "Cartegory.txt");
            if (!File.Exists(cartegory))
            {
                File.Create(cartegory);
            }
            else
            {
                var read = File.ReadAllLines(cartegory);
                foreach (var item in read)
                {
                    var cartegory1 = Cartegory.ToObject(item);
                    ContextClass.cartigories.Add(cartegory1);
                }
            }





            var customer = Path.Combine(FilePath, "Customer.txt");
            if (!File.Exists(customer))
            {
                File.Create(customer);
            }
            else
            {

                var read = File.ReadAllLines(customer);
                foreach (var item in read)
                {
                    var customer1 = Customer.ToObject(item);
                    ContextClass.customers.Add(customer1);
                }

            }


            var manager = Path.Combine(FilePath, "Manager.txt");
            if (!File.Exists(manager))
            {
                File.Create(manager);
            }
            else
            {

                var read = File.ReadAllLines(manager);
                foreach (var item in read)
                {
                    var manager1 = Manager.ToObject(item);
                    ContextClass.managers.Add(manager1);
                }

            }

            var owner = Path.Combine(FilePath, "Owner.txt");
            if (!File.Exists(owner))
            {
                File.Create(owner);
            }
            else
            {


                var read = File.ReadAllLines(owner);
                foreach (var item in read)
                {
                    var owner1 = Owner.ToObject(item);
                    ContextClass.owners.Add(owner1);
                }

            }

            var property = Path.Combine(FilePath, "Property.txt");
            if (!File.Exists(property))
            {
                File.Create(property);
            }
            else
            {

                var read = File.ReadAllLines(property);
                foreach (var item in read)
                {
                    var property1 = Property.ToObject(item);
                    ContextClass.properties.Add(property1);
                }

            }




            var transaction = Path.Combine(FilePath, "Transaction.txt");
            if (!File.Exists(transaction))
            {
                File.Create(transaction);
            }
            else
            {

                var read = File.ReadAllLines(transaction);
                foreach (var item in read)
                {
                    var transaction1 = Transaction.ToObject(item);
                    ContextClass.transactions.Add(transaction1);
                }

            }


            var user = Path.Combine(FilePath, "User.txt");
            if (!File.Exists(user))
            {
                File.Create(user);
            }
            else
            {

                var read = File.ReadAllLines(user);
                foreach (var item in read)
                {
                    var user1 = User.ToObject(item);
                    ContextClass.users.Add(user1);
                }

            }
        }
    }
}