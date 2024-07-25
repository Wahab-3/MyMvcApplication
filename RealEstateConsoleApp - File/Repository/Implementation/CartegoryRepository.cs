using RealEstateConsoleApp.Models;
using RealEstateConsoleApp;
using RealEstateConsoleApp___File;
using Microsoft.VisualBasic;

namespace RealEstateConsoleApp.Repository.Implementation
{
    public class CartegoryRepository : ICartegoryRepository
    {

        string FilePath = Path.Combine(FileContext.FilePath, "Cartegory.txt");
       
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
            using (var str = new StreamWriter(FilePath, true))
            {
                str.WriteLine(cartegory.ToString());
            };
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



        public void RefreshCartegoryFile()
        {
            using (var strm = new StreamWriter(FilePath, false))
            {
                foreach (var item in ContextClass.cartigories)
                {
                    strm.WriteLine(item.ToString());
                }
            }

        }



      
    }
}