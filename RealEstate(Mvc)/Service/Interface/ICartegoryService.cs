using RealEstate_Mvc_.Dtos;
using RealEstateMvc.Models.Entities;

namespace RealEstate_Mvc_.Service.Interface
{
    public interface ICartegoryService
    {
        BaseResponce<CategoryResponseModel> Create(CategoryRequestModel cartegory);
        BaseResponce<CategoryResponseModel> GetByName(string Name);
        BaseResponce<CategoryResponseModel> GetById(string Id);
        BaseResponce<List<CategoryResponseModel>> GetAll();
        BaseResponce<CategoryResponseModel> Update(CategoryRequestModel cartegory);
        BaseResponce<CategoryResponseModel> Delete(string Name, string NewCategoryId);




    }
}