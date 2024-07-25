using RealEstateConsoleApp.Models;

namespace RealEstateConsoleApp.Repository
{
    public interface ICartegoryRepository 
    {
        public Cartegory CreateCartegory(Cartegory cartegory);
        public Cartegory GetCartegoryByName(string Name);
        public Cartegory GetCartegoryById(int id);
        public List<Cartegory> GetAllCartegory();
        public void RefreshCartegoryFile();

    }


}