
using Microsoft.AspNetCore.Hosting;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using RealEstate_Mvc_.Dtos;
using RealEstate_Mvc_.Models.Entities;
using RealEstate_Mvc_.Repository.Interface;
using RealEstate_Mvc_.Service.Interface;
using RealEstateMvc.Models.Entities;

namespace RealEstate_Mvc_.Service.Implementation
{
    public class StafffService : IStaffService
    {
        private readonly IStaffRepository _staffRepository;
        private readonly ICurrentUser _currentUser;
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public StafffService(IStaffRepository staffRepository, ICurrentUser currentUser, IUserRepository userRepository, IRoleRepository roleRepository, IWebHostEnvironment webHostEnvironment)
        {
            _currentUser = currentUser;
            _staffRepository = staffRepository;
            _userRepository = userRepository;
            _roleRepository = roleRepository;
            _webHostEnvironment = webHostEnvironment;
        }
        public BaseResponce<StaffResponseModel> Create(StaffRequestModel StaffRequestModel)
        {
            var staffExist = _staffRepository.Check(StaffRequestModel.Email);
            var userExist = _userRepository.Check(StaffRequestModel.Email);
            if (StaffRequestModel.ProfilePicture != null)
            {
                var uniqueFileName = Guid.NewGuid().ToString() + "_" + StaffRequestModel.ProfilePicture.FileName;

                if (StaffRequestModel.ProfilePicture != null)
                {
                    string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images");
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        StaffRequestModel.ProfilePicture.CopyToAsync(fileStream);
                    }
                }

                if (staffExist || userExist)
                {
                    return new BaseResponce<StaffResponseModel>
                    {
                        Message = "staff Email already exist",
                        Status = false,
                        Data = null,
                    };
                }
                string staffTagNumberd = $"Staff{Guid.NewGuid()}";
                Staff staffd = new Staff
                {
                    IsDeleted = false,
                    Address = StaffRequestModel.Address,
                    Age = StaffRequestModel.Age,
                    CreatedBy = _currentUser.GetCurrentUser(),
                    Email = StaffRequestModel.Email,
                    Dob = StaffRequestModel.Dob,
                    FirstName = StaffRequestModel.FirstName,
                    Gender = StaffRequestModel.Gender,
                    LastName = StaffRequestModel.LastName,
                    PhoneNumber = StaffRequestModel.PhoneNumber,
                    StaffTagNumber = staffTagNumberd,
                    RoleName = StaffRequestModel.RoleName,
                    ProfilePicturePath = uniqueFileName,

                };
                DateTime currentDated = DateTime.Now;
                DateTime dobd = currentDated.AddYears(-staffd.Age);
                var roleExistd = _roleRepository.Check(StaffRequestModel.RoleName);
                if (roleExistd)
                {
                    _staffRepository.Create(staffd);

                    return new BaseResponce<StaffResponseModel>
                    {
                        Message = "staff Created Succesfully",
                        Status = true,
                        Data = new StaffResponseModel
                        {
                            PhoneNumber = StaffRequestModel.PhoneNumber,
                            StaffTagNumber = staffTagNumberd,
                            Gender = StaffRequestModel.Gender,
                            Address = StaffRequestModel.Address,
                            Age = StaffRequestModel.Age,
                            Dob = dobd,
                            Email = StaffRequestModel.Email,
                            FirstName = StaffRequestModel.FirstName,
                            LastName = StaffRequestModel.LastName
                        }
                    };
                }
                Role roles = new Role
                {
                    CreatedBy = _currentUser.GetCurrentUser(),
                    Name = StaffRequestModel.RoleName,
                };
                _roleRepository.Create(roles);
                _staffRepository.Create(staffd);
                return new BaseResponce<StaffResponseModel>
                {
                    Message = "staff Created Succesfully",
                    Status = true,
                    Data = new StaffResponseModel
                    {
                        PhoneNumber = StaffRequestModel.PhoneNumber,
                        StaffTagNumber = staffTagNumberd,
                        Gender = StaffRequestModel.Gender,
                        Address = StaffRequestModel.Address,
                        Age = StaffRequestModel.Age,
                        Dob = StaffRequestModel.Dob,
                        Email = StaffRequestModel.Email,
                        FirstName = StaffRequestModel.FirstName,
                        LastName = StaffRequestModel.LastName
                    }
                };
            }


            if (staffExist || userExist)
            {
                return new BaseResponce<StaffResponseModel>
                {
                    Message = "staff Email already exist",
                    Status = false,
                    Data = null,
                };
            }
            string staffTagNumber = $"Staff{Guid.NewGuid()}";
            Staff staff = new Staff
            {
                IsDeleted = false,
                Address = StaffRequestModel.Address,
                Age = StaffRequestModel.Age,
                CreatedBy = _currentUser.GetCurrentUser(),
                Email = StaffRequestModel.Email,
                Dob = StaffRequestModel.Dob,
                FirstName = StaffRequestModel.FirstName,
                Gender = StaffRequestModel.Gender,
                LastName = StaffRequestModel.LastName,
                PhoneNumber = StaffRequestModel.PhoneNumber,
                StaffTagNumber = staffTagNumber,
                RoleName = StaffRequestModel.RoleName,
            };
            DateTime currentDate = DateTime.Now;
            DateTime dob = currentDate.AddYears(-staff.Age);
            var roleExist = _roleRepository.Check(StaffRequestModel.RoleName);
            if (roleExist)
            {
                _staffRepository.Create(staff);

                return new BaseResponce<StaffResponseModel>
                {
                    Message = "staff Created Succesfully",
                    Status = true,
                    Data = new StaffResponseModel
                    {
                        PhoneNumber = StaffRequestModel.PhoneNumber,
                        StaffTagNumber = staffTagNumber,
                        Gender = StaffRequestModel.Gender,
                        Address = StaffRequestModel.Address,
                        Age = StaffRequestModel.Age,
                        Dob = dob,
                        Email = StaffRequestModel.Email,
                        FirstName = StaffRequestModel.FirstName,
                        LastName = StaffRequestModel.LastName
                    }
                };
            }
            Role role = new Role
            {
                CreatedBy = _currentUser.GetCurrentUser(),
                Name = StaffRequestModel.RoleName,
            };
            _roleRepository.Create(role);
            _staffRepository.Create(staff);
            return new BaseResponce<StaffResponseModel>
            {
                Message = "staff Created Succesfully",
                Status = true,
                Data = new StaffResponseModel
                {
                    PhoneNumber = StaffRequestModel.PhoneNumber,
                    StaffTagNumber = staffTagNumber,
                    Gender = StaffRequestModel.Gender,
                    Address = StaffRequestModel.Address,
                    Age = StaffRequestModel.Age,
                    Dob = StaffRequestModel.Dob,
                    Email = StaffRequestModel.Email,
                    FirstName = StaffRequestModel.FirstName,
                    LastName = StaffRequestModel.LastName
                }
            };

            return new BaseResponce<StaffResponseModel>
            {
                Message = "staff Created Succesfully",
                Status = true,
                Data = new StaffResponseModel
                {
                    PhoneNumber = StaffRequestModel.PhoneNumber,
                    Gender = StaffRequestModel.Gender,
                    Address = StaffRequestModel.Address,
                    Age = StaffRequestModel.Age,
                    Dob = StaffRequestModel.Dob,
                    Email = StaffRequestModel.Email,
                    FirstName = StaffRequestModel.FirstName,
                    LastName = StaffRequestModel.LastName
                }
            };

        }

        public BaseResponce<StaffResponseModel> Delete(string Email)
        {
            var staff = _staffRepository.GetByEmail(Email);
            var user = _userRepository.Get(Email);
            if (staff == null || user == null)
            {
                return new BaseResponce<StaffResponseModel>
                {
                    Message = "staff Email not  found",
                    Status = false,
                    Data = null,
                };
            }
            staff.IsDeleted = true;
            user.IsDeleted = true;
            staff.DateDeleted = DateTime.UtcNow;
            staff.DeletedBy = _currentUser.GetCurrentUser();
            user.DateDeleted = DateTime.UtcNow;
            user.DeletedBy = _currentUser.GetCurrentUser();
            _userRepository.Update(user);
            _staffRepository.Update(staff);

            return new BaseResponce<StaffResponseModel>
            {
                Message = "Deleted ",
                Status = true,
                Data = new StaffResponseModel
                {
                    PhoneNumber = staff.PhoneNumber,
                    StaffTagNumber = staff.StaffTagNumber,
                    Gender = staff.Gender,
                    Address = staff.Address,
                    Age = staff.Age,
                    Dob = staff.Dob,
                    Email = staff.Email,
                    FirstName = staff.FirstName,
                    LastName = staff.LastName
                }
            };

        }

        public BaseResponce<List<StaffResponseModel>> GetAll()
        {
            var staffs = _staffRepository.GetAll();
            if (staffs == null)
            {
                return new BaseResponce<List<StaffResponseModel>>
                {
                    Message = "staffs not  found",
                    Status = false,
                    Data = null,
                };
            }
            var listOfStaffs = staffs.Select(x => new StaffResponseModel
            {
                PhoneNumber = x.PhoneNumber,
                StaffTagNumber = x.StaffTagNumber,
                Gender = x.Gender,
                Address = x.Address,
                Age = x.Age,
                Dob = x.Dob,
                Email = x.Email,
                FirstName = x.FirstName,
                LastName = x.LastName

            }).ToList();
            return new BaseResponce<List<StaffResponseModel>>
            {
                Message = "All staffs",
                Status = true,
                Data = listOfStaffs
            };

        }

        public BaseResponce<StaffResponseModel> GetByEmail(string Email)
        {
            var staffExist = _staffRepository.Check(Email);
            if (!staffExist)
            {
                return new BaseResponce<StaffResponseModel>
                {
                    Message = "staff Email not found",
                    Status = false,
                    Data = null,
                };
            }
            var Staff = _staffRepository.GetByEmail(Email);
            return new BaseResponce<StaffResponseModel>
            {
                Message = "Gotten the staff",
                Status = true,
                Data = new StaffResponseModel
                {
                    PhoneNumber = Staff.PhoneNumber,
                    StaffTagNumber = Staff.StaffTagNumber,
                    Gender = Staff.Gender,
                    Address = Staff.Address,
                    Age = Staff.Age,
                    Dob = Staff.Dob,
                    Email = Staff.Email,
                    FirstName = Staff.FirstName,
                    LastName = Staff.LastName
                }
            };




        }

        public BaseResponce<StaffResponseModel> GetById(string Id)
        {
            var Staff = _staffRepository.GetById(Id);
            if (Staff == null)
            {
                return new BaseResponce<StaffResponseModel>
                {
                    Message = "staff Id not found",
                    Status = false,
                    Data = null,
                };
            }
            return new BaseResponce<StaffResponseModel>
            {
                Message = "Gotten the staff",
                Status = true,
                Data = new StaffResponseModel
                {
                    PhoneNumber = Staff.PhoneNumber,
                    StaffTagNumber = Staff.StaffTagNumber,
                    Gender = Staff.Gender,
                    Address = Staff.Address,
                    Age = Staff.Age,
                    Dob = Staff.Dob,
                    Email = Staff.Email,
                    FirstName = Staff.FirstName,
                    LastName = Staff.LastName
                }
            };
        }

        public BaseResponce<StaffResponseModel> GetByTagNumber(string TagNumber)
        {
            var Staff = _staffRepository.GetByTagNumber(TagNumber);
            if (Staff == null)
            {
                return new BaseResponce<StaffResponseModel>
                {
                    Message = "staff Tag Number not found",
                    Status = false,
                    Data = null,
                };
            }
            return new BaseResponce<StaffResponseModel>
            {
                Message = "Gotten the staff",
                Status = true,
                Data = new StaffResponseModel
                {
                    PhoneNumber = Staff.PhoneNumber,
                    StaffTagNumber = Staff.StaffTagNumber,
                    Gender = Staff.Gender,
                    Address = Staff.Address,
                    Age = Staff.Age,
                    Dob = Staff.Dob,
                    Email = Staff.Email,
                    FirstName = Staff.FirstName,
                    LastName = Staff.LastName
                }
            };
        }

        public BaseResponce<StaffResponseModel> Update(StaffRequestModel staff)
        {
            var staffExist = _staffRepository.GetByEmail(staff.Email);
            var uniqueFileName = Guid.NewGuid().ToString() + "_" + staff.ProfilePicture.FileName;

            if (staff.ProfilePicture != null)
            {
                string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images");
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    staff.ProfilePicture.CopyToAsync(fileStream);
                }
            }

            if (staffExist == null)
            {
                return new BaseResponce<StaffResponseModel>
                {
                    Message = "Staff Email found",
                    Status = false,
                    Data = null,
                };
            }

            staffExist.Email = staff.Email;
            staffExist.Age = staff.Age;
            staffExist.Address = staff.Address;
            staffExist.Gender = staff.Gender;
            staffExist.Dob = staff.Dob;
            staffExist.FirstName = staff.FirstName;
            staffExist.ProfilePicturePath = uniqueFileName;

            staffExist.LastName = staff.LastName;
            staffExist.PhoneNumber = staff.PhoneNumber;
            staffExist.CreatedBy = _currentUser.GetCurrentUser();


            var updatedStaff = _staffRepository.Update(staffExist);
            return new BaseResponce<StaffResponseModel>
            {
                Message = "Updated the Staff",
                Status = true,
                Data = new StaffResponseModel
                {
                    PhoneNumber = updatedStaff.PhoneNumber,
                    StaffTagNumber = updatedStaff.StaffTagNumber,
                    Gender = updatedStaff.Gender,
                    Address = updatedStaff.Address,
                    Age = updatedStaff.Age,
                    Dob = updatedStaff.Dob,
                    Email = updatedStaff.Email,
                    FirstName = updatedStaff.FirstName,
                    LastName = updatedStaff.LastName
                }
            };

        }
    }
}