using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http.HttpResults;
using RealEstate_Mvc_.Dtos;
using RealEstate_Mvc_.Repository.Interface;
using RealEstate_Mvc_.Service.Interface;
using RealEstateMvc.Models.Entities;
using RealEstateMvc.Models.Enum;

namespace RealEstate_Mvc_.Service.Implementation
{
    public class PropertyService : IPropertyService
    {
        private readonly IPropertyRepository _propertyRepository;
        private readonly ICartegoryRepository _cartegoryRepository;
        private readonly ICurrentUser _currentUser;
        private readonly IOwnerRepository _ownerRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IOwnerService _ownerService;
        private readonly IUserRepository _userRepository;
        private readonly IStaffRepository _StaffRepository;
        public PropertyService(IPropertyRepository propertyRepository, ICartegoryRepository cartegoryRepository, ICurrentUser currentUser, IOwnerRepository ownerRepository, IWebHostEnvironment webHostEnvironment, IOwnerService ownerService, IUserRepository userRepository, IStaffRepository StaffRepository)
        {
            _propertyRepository = propertyRepository;
            _cartegoryRepository = cartegoryRepository;
            _currentUser = currentUser;
            _ownerRepository = ownerRepository;
            _webHostEnvironment = webHostEnvironment;
            _ownerService = ownerService;
            _userRepository = userRepository;
            _StaffRepository = StaffRepository;
        }
        public BaseResponce<PropertyResponseModel> Create(PropertyRequestModel Property)
        {
            var owner = _ownerRepository.GetByEmail(Property.Email);
            var staff = _StaffRepository.GetByEmail(Property.Email);
            var user = _userRepository.Get(Property.Email);
            if (Property.ProfilePicture != null)
            {
                var uniqueFileName = Guid.NewGuid().ToString() + "_" + Property.ProfilePicture.FileName;

                if (Property.ProfilePicture != null)
                {
                    string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images");
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        Property.ProfilePicture.CopyToAsync(fileStream);
                    }
                }
                if (owner==null)
                {
                    OwnerRequestModel ownerRequestModel = new OwnerRequestModel()
                    {
                        Email = Property.Email,
                        Address = staff.Address,
                        Age = staff.Age,
                        Dob = staff.Dob,
                        Gender = staff.Gender,
                        FirstName = staff.FirstName,
                        LastName = staff.LastName,
                        PhoneNumber = staff.PhoneNumber,
                        Password = user.Password,

                    };
                   var createOwner = _ownerService.Create(ownerRequestModel);
                    createOwner.Data.StaffNumber = owner.Id;
                    
                }
                Property propertys = new Property
                {
                    Location = Property.Location,
                    TypeOfLeases = Property.TypeOfLeases,
                    Price = Property.Price,
                    IsAvailable = true,
                    Description = Property.Description,
                    IsDeleted = false,
                    CategoryId = Property.CategoryId,
                    OwnerId = owner.Id,
                    CreatedBy = owner.Email,
                    ProfilePicturePath = uniqueFileName,
                };
                _propertyRepository.Create(propertys);

            }
            if (owner == null)
            {
                OwnerRequestModel ownerRequestModel = new OwnerRequestModel()
                {
                    Email = Property.Email,
                    Address = staff.Address,
                    Age = staff.Age,
                    Dob = staff.Dob,
                    Gender = staff.Gender,
                    FirstName = staff.FirstName,
                    LastName = staff.LastName,
                    PhoneNumber = staff.PhoneNumber,
                    Password = user.Password,

                };
                var createOwner = _ownerService.Create(ownerRequestModel);
                createOwner.Data.StaffNumber = owner.Id;

            }

            Property property = new Property
            {
                Location = Property.Location,
                TypeOfLeases = Property.TypeOfLeases,
                Price = Property.Price,
                IsAvailable = true,
                Description = Property.Description,
                IsDeleted = false,
                CategoryId = Property.CategoryId,
                OwnerId = owner.Id,
                CreatedBy = owner.Email,
            };
            _propertyRepository.Create(property);




            return new BaseResponce<PropertyResponseModel>
            {
                Message = "property Created Succesfully",
                Status = true,
                Data = new PropertyResponseModel
                {
                    Location = Property.Location,
                    TypeOfLeases = Property.TypeOfLeases,
                    Price = Property.Price,
                    IsAvailable = true,
                    Description = Property.Description,
                    CategoryId = Property.CategoryId,
                    OwnerId = owner.Id,
                }
            };
        }

        public BaseResponce<PropertyResponseModel> Delete(string Id)
        {
            var property = _propertyRepository.GetById(Id);
            if (property == null)
            {
                return new BaseResponce<PropertyResponseModel>
                {
                    Message = "propertyId Not found",
                    Status = false,
                    Data = null,
                };
            }
            property.IsDeleted = true;
            property.IsAvailable = false;
            property.DeletedBy = _currentUser.GetCurrentUser();
            property.DateDeleted = DateTime.Now;
            var newProperty = _propertyRepository.Update(property);

            return new BaseResponce<PropertyResponseModel>
            {
                Message = "Deleted ",
                Status = true,
                Data = new PropertyResponseModel
                {
                    Location = property.Location,
                    TypeOfLeases = property.TypeOfLeases,
                    Price = property.Price,
                    IsAvailable = true,
                    Description = property.Description,
                    CategoryId = property.CategoryId,
                    OwnerId = property.OwnerId,
                    OwnerEmail = property.Owner.Email,
                }
            };
        }

        public BaseResponce<List<PropertyResponseModel>> GetAll()
        {
            var propertys = _propertyRepository.GetAll();
            if (propertys == null)
            {
                return new BaseResponce<List<PropertyResponseModel>>
                {
                    Message = "properties Not found",
                    Status = false,
                    Data = null,
                };
            }
            var listOfproperty = propertys.Select(property => new PropertyResponseModel
            {
                Location = property.Location,
                TypeOfLeases = property.TypeOfLeases,
                Price = property.Price,
                IsAvailable = true,
                Description = property.Description,
                CategoryId = property.CategoryId,
                OwnerId = property.OwnerId,
                OwnerEmail = property.Owner?.Email,

            }).ToList();
            return new BaseResponce<List<PropertyResponseModel>>
            {
                Message = "All property",
                Status = true,
                Data = listOfproperty
            };
        }

        public BaseResponce<List<PropertyResponseModel>> GetByAvailability()
        {
            var propertys = _propertyRepository.GetByAvailability();
            if (propertys == null)
            {
                return new BaseResponce<List<PropertyResponseModel>>
                {
                    Message = "No Available Properties",
                    Status = false,
                    Data = null,
                };
            }
            var listOfproperty = propertys.Select(property => new PropertyResponseModel
            {
                Location = property.Location,
                TypeOfLeases = property.TypeOfLeases,
                Price = property.Price,
                IsAvailable = true,
                Description = property.Description,
                CategoryId = property.CategoryId,
                OwnerId = property.OwnerId,
                OwnerEmail = property.Owner.Email,
            }).ToList();
            return new BaseResponce<List<PropertyResponseModel>>
            {
                Message = "All property",
                Status = true,
                Data = listOfproperty
            };
        }

        public BaseResponce<List<PropertyResponseModel>> GetByCartegoryId(string CartegoryId)
        {
            var exist = _cartegoryRepository.GetById(CartegoryId);
            if (exist == null)
            {
                return new BaseResponce<List<PropertyResponseModel>>
                {
                    Message = "cartegoryId not found",
                    Status = false,
                    Data = null,
                };
            }
            var propertys = _propertyRepository.GetByCartegoryId(CartegoryId);
            var listOfproperty = propertys.Select(property => new PropertyResponseModel
            {
                Location = property.Location,
                TypeOfLeases = property.TypeOfLeases,
                Price = property.Price,
                IsAvailable = true,
                Description = property.Description,
                CategoryId = property.CategoryId,
                OwnerId = property.OwnerId,
                OwnerEmail = property.Owner.Email,
            }).ToList();
            return new BaseResponce<List<PropertyResponseModel>>
            {
                Message = "All property",
                Status = true,
                Data = listOfproperty
            };
        }

        public BaseResponce<List<PropertyResponseModel>> GetByDescription(string Description)
        {
            var propertys = _propertyRepository.GetByDescription(Description);
            if (propertys == null)
            {
                return new BaseResponce<List<PropertyResponseModel>>
                {
                    Message = "Description not found",
                    Status = false,
                    Data = null,
                };
            }
            var listOfproperty = propertys.Select(property => new PropertyResponseModel
            {
                Location = property.Location,
                TypeOfLeases = property.TypeOfLeases,
                Price = property.Price,
                IsAvailable = true,
                Description = property.Description,
                CategoryId = property.CategoryId,
                OwnerId = property.OwnerId,
                OwnerEmail = property.Owner.Email,
            }).ToList();
            return new BaseResponce<List<PropertyResponseModel>>
            {
                Message = "All property",
                Status = true,
                Data = listOfproperty
            };
        }

        public BaseResponce<PropertyResponseModel> GetById(string Id)
        {
            var exist = _propertyRepository.GetById(Id);
            if (exist == null)
            {
                return new BaseResponce<PropertyResponseModel>
                {
                    Message = "PropertyId not found",
                    Status = false,
                    Data = null,
                };
            }
            return new BaseResponce<PropertyResponseModel>
            {
                Message = "Gotten the Property",
                Status = true,
                Data = new PropertyResponseModel
                {
                    Location = exist.Location,
                    TypeOfLeases = exist.TypeOfLeases,
                    Price = exist.Price,
                    IsAvailable = exist.IsAvailable,
                    Description = exist.Description,
                    CategoryId = exist.CategoryId,
                    OwnerId = exist.OwnerId,
                    OwnerEmail = exist.Owner.Email,
                }
            };
        }

        public BaseResponce<List<PropertyResponseModel>> GetByLocation(string Location)
        {
            var propertys = _propertyRepository.GetByLocation(Location);
            if (propertys == null)
            {
                return new BaseResponce<List<PropertyResponseModel>>
                {
                    Message = "Property with Location not found",
                    Status = false,
                    Data = null,
                };
            }
            var listOfproperty = propertys.Select(property => new PropertyResponseModel
            {
                Location = property.Location,
                TypeOfLeases = property.TypeOfLeases,
                Price = property.Price,
                IsAvailable = true,
                Description = property.Description,
                CategoryId = property.CategoryId,
                OwnerId = property.OwnerId,
                OwnerEmail = property.Owner.Email,
            }).ToList();
            return new BaseResponce<List<PropertyResponseModel>>
            {
                Message = "All property",
                Status = true,
                Data = listOfproperty
            };
        }

        public BaseResponce<List<PropertyResponseModel>> GetByOwnerId(string ownerId)
        {
            var propertys = _propertyRepository.GetByOwnerId(ownerId);
            if (propertys == null)
            {
                return new BaseResponce<List<PropertyResponseModel>>
                {
                    Message = "Owner not found",
                    Status = false,
                    Data = null,
                };
            }
            var listOfproperty = propertys.Select(property => new PropertyResponseModel
            {
                Location = property.Location,
                TypeOfLeases = property.TypeOfLeases,
                Price = property.Price,
                IsAvailable = true,
                Description = property.Description,
                CategoryId = property.CategoryId,
                OwnerId = property.OwnerId,
                OwnerEmail = property.Owner.Email,
            }).ToList();
            return new BaseResponce<List<PropertyResponseModel>>
            {
                Message = " property",
                Status = true,
                Data = listOfproperty
            };
        }

        public BaseResponce<List<PropertyResponseModel>> GetByPrice(double Price)
        {
            var propertys = _propertyRepository.GetByPrice(Price);
            if (propertys == null)
            {
                return new BaseResponce<List<PropertyResponseModel>>
                {
                    Message = "property with price not found",
                    Status = false,
                    Data = null,
                };
            }
            var listOfproperty = propertys.Select(property => new PropertyResponseModel
            {
                Location = property.Location,
                TypeOfLeases = property.TypeOfLeases,
                Price = property.Price,
                IsAvailable = true,
                Description = property.Description,
                CategoryId = property.CategoryId,
                OwnerId = property.OwnerId,
                OwnerEmail = property.Owner.Email,
            }).ToList();
            return new BaseResponce<List<PropertyResponseModel>>
            {
                Message = "All property",
                Status = true,
                Data = listOfproperty
            };
        }

        public BaseResponce<List<PropertyResponseModel>> GetByTypeOfLease(TYpeOfLeases TypeOfLeases)
        {
            var propertys = _propertyRepository.GetByTypeOfLease(TypeOfLeases);
            if (propertys == null)
            {
                return new BaseResponce<List<PropertyResponseModel>>
                {
                    Message = "No TypeOfLease not found",
                    Status = false,
                    Data = null,
                };
            }
            var listOfproperty = propertys.Select(property => new PropertyResponseModel
            {
                Location = property.Location,
                TypeOfLeases = property.TypeOfLeases,
                Price = property.Price,
                IsAvailable = true,
                Description = property.Description,
                CategoryId = property.CategoryId,
                OwnerId = property.OwnerId,
                OwnerEmail = property.Owner.Email,
            }).ToList();
            return new BaseResponce<List<PropertyResponseModel>>
            {
                Message = "All property",
                Status = true,
                Data = listOfproperty
            };
        }

        public BaseResponce<PropertyResponseModel> Update(PropertyRequestModel property)
        {


            var exist = _propertyRepository.GetById(property.Id);
            var uniqueFileName = Guid.NewGuid().ToString() + "_" + property.ProfilePicture.FileName;

            if (property.ProfilePicture != null)
            {
                string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images");
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    property.ProfilePicture.CopyToAsync(fileStream);
                }
            }
            if (exist == null)
            {
                return new BaseResponce<PropertyResponseModel>
                {
                    Message = "property Id not found",
                    Status = false,
                    Data = null,
                };
            }
            exist.CategoryId = property.CategoryId;
            exist.Location = property.Location;
            exist.TypeOfLeases = property.TypeOfLeases;
            exist.Price = property.Price;
            exist.Description = property.Description;
            exist.ProfilePicturePath = uniqueFileName;

            exist.CreatedBy = _currentUser.GetCurrentUser();

            var property1 = _propertyRepository.Update(exist);



            return new BaseResponce<PropertyResponseModel>
            {
                Message = "Updated the Property",
                Status = true,
                Data = new PropertyResponseModel
                {
                    Location = property.Location,
                    TypeOfLeases = property.TypeOfLeases,
                    Price = property.Price,
                    IsAvailable = true,
                    Description = property.Description,
                    CategoryId = property.CategoryId,
                    OwnerId = exist.OwnerId,
                    OwnerEmail = exist.Owner.Email,
                }
            };
        }
    }

}