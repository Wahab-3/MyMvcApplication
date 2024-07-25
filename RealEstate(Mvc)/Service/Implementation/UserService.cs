using Azure;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using RealEstate_Mvc_.Context;
using RealEstate_Mvc_.Dtos;
using RealEstate_Mvc_.Models.Entities;
using RealEstate_Mvc_.Repository.Interface;
using RealEstate_Mvc_.Service.Interface;
using RealEstateMvc.Models.Entities;
using System.Collections.Generic;

namespace RealEstate_Mvc_.Service.Implementation
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly ICurrentUser _currentUser;
        private readonly IRoleRepository _roleRepository;
        private readonly ContextClass _contextClass;
        public UserService(IUserRepository userRepository, ICurrentUser currentUser, IRoleRepository roleRepository,ContextClass contextClass)
        {
            _userRepository = userRepository;
            _currentUser = currentUser;
            _roleRepository = roleRepository;
            _contextClass = contextClass;
        }

        public BaseResponce<UserResponseModel> Create(UserRequestModel user, string RoleName, string RoleDesciption)
        {
            var Check = _userRepository.Check(user.Email);
            var role = _roleRepository.GetByName(RoleName);
            if (Check)
            {
                return new BaseResponce<UserResponseModel>
                {
                    Message = "user Email already exist found",
                    Status = false,
                    Data = null,
                };
            }
            var newPassword = BCrypt.Net.BCrypt.HashPassword(user.Password);
            if (user.Password != user.ConfirmPassword)
            {
                return new BaseResponce<UserResponseModel>
                {
                    Message = "password does not correspond",
                    Status = false,
                    Data = null,
                };
            }
            User newUser = new User
            {
                Email = user.Email,
                CreatedBy = _currentUser.GetCurrentUser(),
                FullName = user.FullName,
                Password = newPassword,
                UserRoles = new List<UserRole>(),


            };
            if (role == null)
            {

                Role newRole = new Role
                {
                    Name = RoleName,
                    Description = RoleDesciption,
                    IsDeleted = false,
                    CreatedBy = _currentUser.GetCurrentUser(),
                };
                string RoleId = newRole.Id;
                newUser.UserRoles.Add(new UserRole
                {
                    User = newUser,
                    RoleId = newRole.Id,
                    Role = newRole,
                    UserId = newUser.Id
                });
                _roleRepository.Create(newRole);
            }
            newUser.UserRoles.Add(new UserRole
            {
                User = newUser,
                RoleId = role.Id,
                Role = role,
                UserId = newUser.Id


            });
            _userRepository.Create(newUser);
            return new BaseResponce<UserResponseModel>
            {
                Message = "user Created",
                Status = true,
                Data = new UserResponseModel
                {
                    Email = user.Email,
                    FullName = user.FullName,
                    Id = newUser.Id,
                    RoleName = RoleName,
                }
            };
        }

        public BaseResponce<UserResponseModel> Delete(string Email)
        {
            var user = _userRepository.Get(Email);
            if (user == null)
            {
                return new BaseResponce<UserResponseModel>
                {
                    Message = "user Email Not found",
                    Status = false,
                    Data = null,
                };
            }
            user.IsDeleted = true;
            user.DeletedBy = _currentUser.GetCurrentUser();
            user.DateDeleted = DateTime.Now;
            var newUser = _userRepository.Update(user);

            return new BaseResponce<UserResponseModel>
            {
                Message = "Deleted ",
                Status = true,
                Data = new UserResponseModel
                {
                    Email = user.Email,
                    FullName = user.FullName,

                }
            };
        }

        public BaseResponce<UserResponseModel> Get(string email)
        {
            var exist = _userRepository.Check(email);
            if (!exist)
            {
                return new BaseResponce<UserResponseModel>
                {
                    Message = "user Email not found",
                    Status = false,
                    Data = null,
                };
            }
            var user = _userRepository.Get(email);
            return new BaseResponce<UserResponseModel>
            {
                Message = "Gotten the user",
                Status = true,
                Data = new UserResponseModel
                {
                    Email = user.Email,
                    FullName = user.FullName,
                }
            };
        }

        public BaseResponce<List<UserResponseModel>> GetAll()
        {
            var users = _userRepository.GetAll();
            if (users == null)
            {
                return new BaseResponce<List<UserResponseModel>>
                {
                    Message = " no users Available",
                    Status = false,
                    Data = null,
                };
            }
            var listOfUser = users.Select(user => new UserResponseModel
            {
                Email = user.Email,
                FullName = user.FullName,
            }).ToList();
            return new BaseResponce<List<UserResponseModel>>
            {
                Message = "All users",
                Status = true,
                Data = listOfUser
            };
        }

        public BaseResponce<List<UserResponseModel>> GetByRoleId(string Id)
        {

            var exist = _userRepository.GetByRoleId(Id);
            if (exist == null)
            {
                return new BaseResponce<List<UserResponseModel>>
                {
                    Message = "users not found",
                    Status = false,
                    Data = null,
                };
            }
            var user = _userRepository.GetByRoleId(Id);
            var listOfUser = user.Select(user => new UserResponseModel
            {
                Email = user.Email,
                FullName = user.FullName,
            }).ToList();
            return new BaseResponce<List<UserResponseModel>>
            {
                Message = "Gotten the user",
                Status = true,
                Data = listOfUser,
            };
        }

        public BaseResponce<UserResponseModel> Login(UserLoginRequestModel userLoginRequestModel)
        {
            var exist = _userRepository.Check(userLoginRequestModel.Email);
            if (!exist)
            {
                return new BaseResponce<UserResponseModel>
                {
                    Message = "user Email not found",
                    Status = false,
                    Data = null,
                };
            }
            var user = _userRepository.Get(userLoginRequestModel.Email);
            var isPasswordValid = BCrypt.Net.BCrypt.Verify(userLoginRequestModel.Password, user.Password);
            if (isPasswordValid)
            {
              
                    // Fetch the user's role
                    var role = _contextClass.UserRoles
                        .Where(ur => ur.UserId == user.Id)
                        .Select(ur => ur.Role.Name)
                        .FirstOrDefault();
                return new BaseResponce<UserResponseModel>
                {
                    Message = "Login successful",
                    Status = true,
                    Data = new UserResponseModel
                    {
                        Email = user.Email,
                        FullName = user.FullName,
                        RoleName = role
                    }
                };
            }
            return new BaseResponce<UserResponseModel>
            {
                Message = "Password does not match",
                Status = false,
                Data = null
            };
        }

        public BaseResponce<UserResponseModel> Update(UserRequestModel userRequestModel)
        {
            var exist = _userRepository.Get(userRequestModel.Email);
            if (exist == null)
            {
                return new BaseResponce<UserResponseModel>
                {
                    Message = "user Email not found",
                    Status = false,
                    Data = null,
                };
            }
            var newPassword = $"qwert{BCrypt.Net.BCrypt.HashPassword(userRequestModel.Password)}";

            exist.Email = userRequestModel.Email;
            exist.Password = newPassword;
            exist.FullName = userRequestModel.FullName;
            exist.CreatedBy = _currentUser.GetCurrentUser();
            var updatedUser = _userRepository.Update(exist);



            return new BaseResponce<UserResponseModel>
            {
                Message = "Updated the user",
                Status = true,
                Data = new UserResponseModel
                {
                    Email = exist.Email,
                    FullName = exist.FullName,
                }
            };
        }
    }
}
