using RealEstateConsoleApp.Models;

namespace RealEstateConsoleApp.Service.Interface
{
  public interface ICartegoryService
  {
    public void CreateCartegory(string Name, string Description);
    public Cartegory GetCartegoryByName(string Name);
    public Cartegory GetCartegoryById(int id);
    public void GetAllCartegory();
    public void UpdateCartegory(string OldName, string NewName, String Description);
    public void DeleteCartegory(string name);
  }
}