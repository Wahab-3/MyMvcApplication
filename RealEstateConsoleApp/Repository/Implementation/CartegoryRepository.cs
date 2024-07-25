using RealEstateConsoleApp.Models;
using RealEstateConsoleApp;

namespace RealEstateConsoleApp.Repository.Implementation
{
    public class CartegoryRepository : ICartegoryRepository
    {
        public Cartegory CreateCartegory(Cartegory cartegory)
        {

            var context = ContextClass.cartigories;
            foreach (var item in context)
            {
                if (item.Name == cartegory.Name)
                {
                    return null;
                }
            }
            context.Add(cartegory);
            return cartegory;


        }



        public List<Cartegory> GetAllCartegory()
        {
            var context = ContextClass.cartigories;
            return context;
        }

        public Cartegory GetCartegoryById(int id)
        {
            var context = ContextClass.cartigories;
            foreach (var item in context)
            {
                if (item.Id == id)
                {
                    return item;
                }
            }
            return null;
        }

        public Cartegory GetCartegoryByName(string Name)
        {
            var context = ContextClass.cartigories;
            foreach (var item in context)
            {
                if (item.Name == Name)
                {
                    return item;
                }
            }
            return null;
        }
    }
}