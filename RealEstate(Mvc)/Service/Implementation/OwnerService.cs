using Microsoft.AspNetCore.Http.HttpResults;
using RealEstate_Mvc_.Dtos;
using RealEstate_Mvc_.Models.Entities;
using RealEstate_Mvc_.Repository.Interface;
using RealEstate_Mvc_.Service.Interface;
using RealEstateMvc.Models.Entities;
using System.Data;

namespace RealEstate_Mvc_.Service.Implementation
{
    public class OwnerService : IOwnerService
    {
        private readonly IOwnerRepository _ownerRepository;
        private readonly ICurrentUser _currentUser;
        private readonly IUserRepository _userRepository;
        private readonly IStaffRepository _staffRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public OwnerService(IOwnerRepository ownerRepository, ICurrentUser currentUser, IUserRepository userRepository, IStaffRepository staffRepository, IRoleRepository roleRepository, IWebHostEnvironment webHostEnvironment)
        {
            _ownerRepository = ownerRepository;
            _currentUser = currentUser;
            _userRepository = userRepository;
            _staffRepository = staffRepository;
            _roleRepository = roleRepository;
            _webHostEnvironment = webHostEnvironment;
        }

        public BaseResponce<OwnerResponseModel> Create(OwnerRequestModel owner)
        {
            var ownerExist = _ownerRepository.Check(owner.Email);
            var userExist = _userRepository.Check(owner.Email);
            var staffExist = _staffRepository.Check(owner.Email);
            if(owner.ProfilePicture!=null)
            {
                var uniqueFileName = Guid.NewGuid().ToString() + "_" + owner.ProfilePicture.FileName;

                if (owner.ProfilePicture != null)
                {
                    string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images");
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        owner.ProfilePicture.CopyToAsync(fileStream);
                    }
                }
                if (ownerExist || userExist || staffExist)
                {
                    return new BaseResponce<OwnerResponseModel>()
                    {
                        Status = false,
                        Message = "Owner Email already exist",
                        Data = null

                    };
                }
                var newPasswordd = BCrypt.Net.BCrypt.HashPassword(owner.Password);
                var staffNumbern = $"Staff{Guid.NewGuid()}";
                if (owner.Password != owner.ConfirmPassword)
                {
                    return new BaseResponce<OwnerResponseModel>
                    {
                        Message = "password does not correspond",
                        Status = false,
                        Data = null,
                    };
                }

                DateTime currentDated = DateTime.Now;

                // Calculate the year of birth by subtracting the age from the current year
                DateTime dobd = currentDated.AddYears(-owner.Age);
                Owner newOwnerd = new Owner()
                {
                    CreatedBy = _currentUser.GetCurrentUser(),
                    IsAvailable = true,
                    StaffNumber = staffNumbern,
                    Email = owner.Email,
                    ProfilePicturePath = uniqueFileName,

                };
                Staff staffn = new Staff()
                {
                    Address = owner.Address,
                    Age = owner.Age,
                    Dob = dobd,
                    FirstName = owner.FirstName,
                    LastName = owner.LastName,
                    Email = owner.Email,
                    PhoneNumber = owner.PhoneNumber,
                    StaffTagNumber = staffNumbern,
                    Gender = owner.Gender,
                    CreatedBy = _currentUser.GetCurrentUser()

                };
                User users = new User()
                {
                    Email = owner.Email,
                    FullName = owner.FirstName + " " + owner.LastName,
                    Password = newPasswordd,
                    CreatedBy = _currentUser.GetCurrentUser(),
                    UserRoles = new List<UserRole>(),
                };

                var roles = _roleRepository.GetByName("Owner");
                if (roles == null)
                {

                    Role newRole = new Role
                    {
                        Name = "Owner",
                        Description = "Owner of properties in the application",
                        IsDeleted = false,
                        CreatedBy = _currentUser.GetCurrentUser(),
                    };
                    string RoleId = newRole.Id;
                    users.UserRoles.Add(new UserRole
                    {
                        User = users,
                        RoleId = newRole.Id,
                        Role = newRole,
                        UserId = users.Id


                    });
                    _roleRepository.Create(newRole);
                }
                //string rolesId = role.Id;
                users.UserRoles.Add(new UserRole
                {
                    User = users,
                    RoleId = roles.Id,
                    Role = roles,
                    UserId = users.Id


                });
                _ownerRepository.Create(newOwnerd);
                _userRepository.Create(users);
                _staffRepository.Create(staffn);


                return new BaseResponce<OwnerResponseModel>
                {
                    Message = "Created Successfully",
                    Status = true,
                    Data = new OwnerResponseModel
                    {
                        Address = owner.Address,
                        Age = owner.Age,
                        Email = owner.Email,
                        FirstName = owner.FirstName,
                        LastName = owner.LastName,
                        Gender = owner.Gender,
                        PhoneNumber = owner.PhoneNumber,
                        StaffNumber = staffNumbern,
                    }
                };
            }
            if (ownerExist || userExist || staffExist)
            {
                return new BaseResponce<OwnerResponseModel>()
                {
                    Status = false,
                    Message = "Owner Email already exist",
                    Data = null

                };
            }
            var newPassword = BCrypt.Net.BCrypt.HashPassword(owner.Password);
            var staffNumber = $"Staff{Guid.NewGuid()}";
            if (owner.Password != owner.ConfirmPassword)
            {
                return new BaseResponce<OwnerResponseModel>
                {
                    Message = "password does not correspond",
                    Status = false,
                    Data = null,
                };
            }

            DateTime currentDate = DateTime.Now;

            // Calculate the year of birth by subtracting the age from the current year
            DateTime dob = currentDate.AddYears(-owner.Age);
            Owner newOwner = new Owner()
            {
                CreatedBy = _currentUser.GetCurrentUser(),
                IsAvailable = true,
                StaffNumber = staffNumber,
                Email = owner.Email,

            };
            Staff staff = new Staff()
            {
                Address = owner.Address,
                Age = owner.Age,
                Dob = dob,
                FirstName = owner.FirstName,
                LastName = owner.LastName,
                Email = owner.Email,
                PhoneNumber = owner.PhoneNumber,
                StaffTagNumber = staffNumber,
                Gender = owner.Gender,
                CreatedBy = _currentUser.GetCurrentUser()

            };
            User user = new User()
            {
                Email = owner.Email,
                FullName = owner.FirstName + " " + owner.LastName,
                Password = newPassword,
                CreatedBy = _currentUser.GetCurrentUser(),
                UserRoles = new List<UserRole>(),
            };

            var role = _roleRepository.GetByName("Owner");
            if (role == null)
            {

                Role newRole = new Role
                {
                    Name = "Owner",
                    Description = "Owner of properties in the application",
                    IsDeleted = false,
                    CreatedBy = _currentUser.GetCurrentUser(),
                };
                string RoleId = newRole.Id;
                user.UserRoles.Add(new UserRole
                {
                    User = user,
                    RoleId = newRole.Id,
                    Role = newRole,
                    UserId = user.Id


                });
                _roleRepository.Create(newRole);
            }
            string roleId = role.Id;
            user.UserRoles.Add(new UserRole
            {
                User = user,
                RoleId = role.Id,
                Role = role,
                UserId = user.Id


            });
            _ownerRepository.Create(newOwner);
            _userRepository.Create(user);
            _staffRepository.Create(staff);


            return new BaseResponce<OwnerResponseModel>
            {
                Message = "Created Successfully",
                Status = true,
                Data = new OwnerResponseModel
                {
                    Address = owner.Address,
                    Age = owner.Age,
                    Email = owner.Email,
                    FirstName = owner.FirstName,
                    LastName = owner.LastName,
                    Gender = owner.Gender,
                    PhoneNumber = owner.PhoneNumber,
                    StaffNumber = staffNumber,
                }
            };


        }

        public BaseResponce<OwnerResponseModel> Delete(string StaffNumber)
        {
            var owner = _ownerRepository.GetByStaffNumber(StaffNumber);
            var staff = _staffRepository.GetByTagNumber(StaffNumber);
            if (owner == null || staff == null)
            {
                return new BaseResponce<OwnerResponseModel>()
                {
                    Message = "Owner  not found",
                    Status = false,
                    Data = null
                };
            }
            var user = _userRepository.Get(staff.Email);
            owner.IsDeleted = true;
            staff.IsDeleted = true;
            user.IsDeleted = true;
            owner.IsAvailable = false;
            owner.DateDeleted = DateTime.Now;
            owner.DeletedBy = _currentUser.GetCurrentUser();
            staff.DateDeleted = DateTime.Now;
            staff.DeletedBy = _currentUser.GetCurrentUser();
            user.DateDeleted = DateTime.Now;
            user.DeletedBy = _currentUser.GetCurrentUser();
            _ownerRepository.Update(owner);
            _staffRepository.Update(staff);
            _userRepository.Update(user);

            return new BaseResponce<OwnerResponseModel>()
            {
                Message = "Deleted successfully",
                Status = true,
                Data = new OwnerResponseModel
                {
                    Address = staff.Address,
                    Age = staff.Age,
                    Email = staff.Email,
                    FirstName = staff.FirstName,
                    LastName = staff.LastName,
                    Gender = staff.Gender,
                    PhoneNumber = staff.PhoneNumber,
                    StaffNumber = staff.StaffTagNumber,
                }
            };
        }

        public BaseResponce<List<OwnerResponseModel>> GetAll()
        {
            var owners = _ownerRepository.GetAll();
            if (owners == null)
            {
                return new BaseResponce<List<OwnerResponseModel>>
                {
                    Message = "owners not found",
                    Status = true,
                    Data = null
                };
            }

            var listOfOwners = owners.Select(x => new OwnerResponseModel
            {
                StaffNumber = x.StaffNumber,
                IsAvailable = x.IsAvailable,
                Email = x.Email,
            }).ToList();

            return new BaseResponce<List<OwnerResponseModel>>
            {
                Message = "All owners",
                Status = true,
                Data = listOfOwners
            };
        }

        public BaseResponce<OwnerResponseModel> GetByEmail(string Email)
        {
            var owner = _ownerRepository.GetByEmail(Email);
            if (owner == null)
            {
                return new BaseResponce<OwnerResponseModel>
                {
                    Message = "owner Email not found",
                    Status = true,
                    Data = null
                };
            }
            return new BaseResponce<OwnerResponseModel>
            {
                Message = "Owner",
                Status = true,
                Data = new OwnerResponseModel
                {
                    StaffNumber = owner.StaffNumber,
                    IsAvailable = owner.IsAvailable,
                    Email = owner.Email,
                }
            };
        }

        public BaseResponce<OwnerResponseModel> GetById(string Id)
        {
            var owner = _ownerRepository.GetById(Id);
            if (owner == null)
            {
                return new BaseResponce<OwnerResponseModel>
                {
                    Message = "owner not found",
                    Status = true,
                    Data = null
                };
            }
            return new BaseResponce<OwnerResponseModel>
            {
                Message = "Owner",
                Status = true,
                Data = new OwnerResponseModel
                {
                    StaffNumber = owner.StaffNumber,
                    IsAvailable = owner.IsAvailable,
                    Email = owner.Email,

                }
            };

        }

        public BaseResponce<OwnerResponseModel> GetByStaffNumber(string StaffNumber)
        {
            var owner = _ownerRepository.GetByStaffNumber(StaffNumber);
            if (owner == null)
            {
                return new BaseResponce<OwnerResponseModel>
                {
                    Message = "owner StaffNumber not found",
                    Status = true,
                    Data = null
                };
            }
            return new BaseResponce<OwnerResponseModel>
            {
                Message = "Owner",
                Status = true,
                Data = new OwnerResponseModel
                {
                    StaffNumber = owner.StaffNumber,
                    IsAvailable = owner.IsAvailable,
                    Email = owner.Email,
                }
            };
        }

        public BaseResponce<OwnerResponseModel> Update(OwnerRequestModel OwnerRequestModel)
        {
            var owner = _ownerRepository.GetByEmail(OwnerRequestModel.Email);
            var user = _userRepository.Get(OwnerRequestModel.Email);
            var staff = _staffRepository.GetByEmail(OwnerRequestModel.Email);
            var uniqueFileName = Guid.NewGuid().ToString() + "_" + OwnerRequestModel.ProfilePicture.FileName;

            if (OwnerRequestModel.ProfilePicture != null)
            {
                string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images");
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    OwnerRequestModel.ProfilePicture.CopyToAsync(fileStream);
                }
            }
            if (owner == null)
            {
                return new BaseResponce<OwnerResponseModel>
                {
                    Message = "owner Email not found",
                    Status = true,
                    Data = null
                };
            }
            var newPassword = $"qwert{BCrypt.Net.BCrypt.HashPassword(OwnerRequestModel.Password)}";

            owner.Email = OwnerRequestModel.Email;
            user.Email = OwnerRequestModel.Email;
            user.FullName = OwnerRequestModel.FirstName + " " + OwnerRequestModel.LastName;
            user.Password = newPassword;
            staff.Address = OwnerRequestModel.Address;
            staff.Email = OwnerRequestModel.Email;
            staff.Age = OwnerRequestModel.Age;
            staff.Dob = OwnerRequestModel.Dob;
            owner.ProfilePicturePath = uniqueFileName;

            staff.Gender = OwnerRequestModel.Gender;
            staff.PhoneNumber = OwnerRequestModel.PhoneNumber;
            staff.LastName = OwnerRequestModel.LastName;
            staff.FirstName = OwnerRequestModel.FirstName;
            staff.CreatedBy = _currentUser.GetCurrentUser();
            owner.CreatedBy = _currentUser.GetCurrentUser();

            _ownerRepository.Update(owner);
            _staffRepository.Update(staff);
            _userRepository.Update(user);
            return new BaseResponce<OwnerResponseModel>()
            {
                Message = "Updated successfully",
                Status = true,
                Data = new OwnerResponseModel
                {
                    Address = staff.Address,
                    Age = staff.Age,
                    Email = staff.Email,
                    FirstName = staff.FirstName,
                    LastName = staff.LastName,
                    Gender = staff.Gender,
                    PhoneNumber = staff.PhoneNumber,
                    StaffNumber = staff.StaffTagNumber,
                }
            };


        }
    }
}
