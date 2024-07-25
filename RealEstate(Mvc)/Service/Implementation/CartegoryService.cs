using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using RealEstate_Mvc_.Dtos;
using RealEstate_Mvc_.Repository.Interface;
using RealEstate_Mvc_.Service.Interface;
using RealEstateMvc.Models.Entities;
using RealEstateMvc.Models.Enum;

namespace RealEstate_Mvc_.Service.Implementation
{
    public class CartegoryService : ICartegoryService
    {
        private readonly ICartegoryRepository _cartegoryRepository;
        private readonly ICurrentUser _currentUser;
        public CartegoryService(ICartegoryRepository cartegoryRepository, ICurrentUser currentUser)
        {
            _cartegoryRepository = cartegoryRepository;
            _currentUser = currentUser;
        }
        public BaseResponce<CategoryResponseModel> Create(CategoryRequestModel cartegory)
        {
            var check = _cartegoryRepository.Check(cartegory.Name);
            if (check)
            {
                return new BaseResponce<CategoryResponseModel>
                {
                    Message = "CartegoryName Already exist",
                    Status = false,
                    Data = null
                };
            }
            Category cartegory1 = new Category
            {
                Name = cartegory.Name,
                Description = cartegory.Description,
                IsDeleted = false,
                CreatedBy = _currentUser.GetCurrentUser(),



            };
            _cartegoryRepository.Create(cartegory1);

            return new BaseResponce<CategoryResponseModel>
            {
                Message = "Cartegory Created Succesfully",
                Status = true,
                Data = new CategoryResponseModel
                {
                    Id = cartegory1.Id,
                    Name = cartegory1.Name,
                    Description = cartegory1.Description,

                }
            };
        }

        public BaseResponce<CategoryResponseModel> Delete(string Name, string NewCategoryId)
        {
            var category = _cartegoryRepository.GetByName(Name);
            if (category == null)
            {
                return new BaseResponce<CategoryResponseModel>
                {
                    Message = "CartegoryName Not found",
                    Status = false,
                    Data = null,
                };
            }
            category.IsDeleted = true;
            category.DateCrated = DateTime.Now;
            category.DeletedBy = _currentUser.GetCurrentUser();
            //_cartegoryRepository.Update(category);
            var categories = _cartegoryRepository.GetAll();
            var properties = category.properties.ToList();
            var categoryById = _cartegoryRepository.GetById(NewCategoryId);
            if (categoryById == null)
            {
                return new BaseResponce<CategoryResponseModel>
                {
                    Message = "Cartegory Not found",
                    Status = false,
                    Data = null,
                };
            }
            foreach (var item in properties)
            {
                item.Id = categoryById.Id;
            }

            var newcartegory = _cartegoryRepository.Update(category);
            return new BaseResponce<CategoryResponseModel>
            {
                Message = "Deleted ",
                Status = true,
                Data = new CategoryResponseModel
                {
                    Id = category.Id,
                    Name = category.Name,
                    Description = category.Description,
                    properties = properties.Select(p => new PropertyResponseModel
                    {
                        Location = p.Location,
                        TypeOfLeases = p.TypeOfLeases,
                        Price = p.Price,
                        IsAvailable = p.IsAvailable,
                        Description = p.Description,
                        CategoryId = p.CategoryId,
                        OwnerId = p.OwnerId
                    }).ToList()
                }
            };


        }

        public BaseResponce<List<CategoryResponseModel>> GetAll()
        {

            var cartegorys = _cartegoryRepository.GetAll();
            if (cartegorys == null)
            {
                return new BaseResponce<List<CategoryResponseModel>>
                {
                    Message = "no Cartegorys Available",
                    Status = false,
                    Data = null,
                };
            }
            var listOfcartegorys = cartegorys.Select(x => new CategoryResponseModel
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                properties = x.properties.Select(p => new PropertyResponseModel
                {
                    Location = p.Location,
                    TypeOfLeases = p.TypeOfLeases,
                    Price = p.Price,
                    IsAvailable = p.IsAvailable,
                    Description = p.Description,
                    CategoryId = p.CategoryId,
                    OwnerId = p.OwnerId
                }).ToList()
            }).ToList();
            return new BaseResponce<List<CategoryResponseModel>>
            {
                Message = "All customers",
                Status = true,
                Data = listOfcartegorys
            };
        }

        public BaseResponce<CategoryResponseModel> GetById(string Id)
        {
            var cartegory = _cartegoryRepository.GetById(Id);
            if (cartegory == null)
            {
                return new BaseResponce<CategoryResponseModel>
                {
                    Message = "Cartegory not found",
                    Status = false,
                    Data = null,
                };
            }
            return new BaseResponce<CategoryResponseModel>
            {
                Message = "Gotten the Cartegory",
                Status = true,
                Data = new CategoryResponseModel
                {
                    Id = cartegory.Id,
                    Name = cartegory.Name,
                    Description = cartegory.Description,
                    properties = cartegory.properties.Select(p => new PropertyResponseModel
                    {
                        Location = p.Location,
                        TypeOfLeases = p.TypeOfLeases,
                        Price = p.Price,
                        IsAvailable = p.IsAvailable,
                        Description = p.Description,
                        CategoryId = p.CategoryId,
                        OwnerId = p.OwnerId
                    }).ToList()
                }
            };
        }

        public BaseResponce<CategoryResponseModel> GetByName(string Name)
        {
            var exist = _cartegoryRepository.Check(Name);
            if (!exist)
            {
                return new BaseResponce<CategoryResponseModel>
                {
                    Message = "CartegoryName not found",
                    Status = false,
                    Data = null,
                };
            }
            var cartegory = _cartegoryRepository.GetByName(Name);
            return new BaseResponce<CategoryResponseModel>
            {
                Message = "Gotten the Cartegory",
                Status = true,
                Data = new CategoryResponseModel
                {
                    Id = cartegory.Id,
                    Name = cartegory.Name,
                    Description = cartegory.Description,
                    properties = cartegory.properties.Select(p => new PropertyResponseModel
                    {
                        Location = p.Location,
                        TypeOfLeases = p.TypeOfLeases,
                        Price = p.Price,
                        IsAvailable = p.IsAvailable,
                        Description = p.Description,
                        CategoryId = p.CategoryId,
                        OwnerId = p.OwnerId
                    }).ToList()
                }
            };
        }

        public BaseResponce<CategoryResponseModel> Update(CategoryRequestModel cartegory)
        {
            var get = _cartegoryRepository.GetByName(cartegory.Name);
            if (get == null)
            {
                return new BaseResponce<CategoryResponseModel>
                {
                    Message = "CartegoryName not found",
                    Status = false,
                    Data = null,
                };
            }

            get.Description = cartegory.Description;
            get.Name = cartegory.Name;
            get.CreatedBy = _currentUser.GetCurrentUser();


            var newcartegory = _cartegoryRepository.Update(get);

            return new BaseResponce<CategoryResponseModel>
            {
                Message = "Updated the Cartegory",
                Status = true,
                Data = new CategoryResponseModel
                {
                    Id = newcartegory.Id,
                    Name = newcartegory.Name,
                    Description = newcartegory.Description,
                    properties = newcartegory.properties.Select(p => new PropertyResponseModel
                    {
                        Location = p.Location,
                        TypeOfLeases = p.TypeOfLeases,
                        Price = p.Price,
                        IsAvailable = p.IsAvailable,
                        Description = p.Description,
                        CategoryId = p.CategoryId,
                        OwnerId = p.OwnerId
                    }).ToList()
                }
            };
        }
    }
}