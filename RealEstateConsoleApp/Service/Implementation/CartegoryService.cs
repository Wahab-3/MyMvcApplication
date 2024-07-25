using RealEstateConsoleApp.Models;
using RealEstateConsoleApp.Repository;
using RealEstateConsoleApp.Repository.Implementation;
using RealEstateConsoleApp.Service.Interface;

namespace RealEstateConsoleApp.Service.Implementation
{
    public class CartegoryService : ICartegoryService
    {
        ICartegoryRepository cartegoryRepository = new CartegoryRepository();
        public void CreateCartegory(string Name, string Description)
        {
            var newCartegory = new Cartegory(ContextClass.cartigories.Count + 1, Name, Description);
            cartegoryRepository.CreateCartegory(newCartegory);
            // var newCartegory = new Cartegory(ContextClass.cartigories.Count+1,Name,Description); 
        }

        public void DeleteCartegory(string name)
        {
            var delete = cartegoryRepository.GetCartegoryByName(name);
            if (delete == null)
            {
                System.Console.WriteLine("Cartegory does not exist");
            }
            ContextClass.cartigories.Remove(delete);


        }

        public void GetAllCartegory()
        {
            var getAll = cartegoryRepository.GetAllCartegory();
            if (getAll == null)
            {
                System.Console.WriteLine("no cartegory added yet");
            }
            else
            {
                foreach (var item in getAll)
                {
                    System.Console.WriteLine($"CartegoryId :{item.Id}.   CartegoryName :{item.Name}     CartegoryDescription : {item.Description}");
                }
            }

        }

        public Cartegory GetCartegoryById(int id)
        {
            var getById = cartegoryRepository.GetCartegoryById(id);
            if (getById == null)
            {
                System.Console.WriteLine(" cartegory does not exist");
                return null;
            }
            return getById;
        }

        public Cartegory GetCartegoryByName(string Name)
        {
            var getByName = cartegoryRepository.GetCartegoryByName(Name);
            if (getByName == null)
            {
                System.Console.WriteLine(" cartegory does not exist");
                return null;
            }
            return getByName;
        }

        public void UpdateCartegory(string OldName, string NewName, string Description)
        {
            var getByName = cartegoryRepository.GetCartegoryByName(OldName);
            if (getByName == null)
            {
                System.Console.WriteLine(" cartegory does not exist");

            }
            getByName.Name = NewName;
            getByName.Description = Description;

        }
    }
}