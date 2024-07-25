

using RealEstate_Mvc_.Dtos;
using RealEstate_Mvc_.Repository.Interface;
using RealEstate_Mvc_.Service.Interface;
using RealEstateMvc.Models.Entities;

namespace RealEstate_Mvc_.Service.Implementation
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;
        private readonly ICurrentUser _currentUser;

        public RoleService(IRoleRepository roleRepository, ICurrentUser currentUser)
        {
            _roleRepository = roleRepository;
            _currentUser = currentUser;
        }
        public BaseResponce<RoleResponseModel> Create(RoleRequestModel role)
        {
            var roleExist = _roleRepository.Check(role.Name);
            if (roleExist)
            {
                return new BaseResponce<RoleResponseModel>
                {
                    Message = "role Name alraedy existing",
                    Status = false,
                    Data = null,
                };
            }
            Role newRole = new Role
            {
                Name = role.Name,
                Description = role.Description,
                IsDeleted = false,
                CreatedBy = _currentUser.GetCurrentUser(),
            };
            _roleRepository.Create(newRole);
            return new BaseResponce<RoleResponseModel>
            {
                Message = "role Created Succesfully",
                Status = true,
                Data = new RoleResponseModel
                {
                    Name = role.Name,
                    Description = role.Description,
                }
            };

        }

        public BaseResponce<RoleResponseModel> Delete(string Name, string NewRoleName)
        {
            var role = _roleRepository.GetByName(Name);
            if (role == null)
            {
                return new BaseResponce<RoleResponseModel>
                {
                    Message = "role Name not found",
                    Status = false,
                    Data = null,
                };
            }


            role.IsDeleted = true;
            role.DateDeleted = DateTime.Now;
            role.DeletedBy = _currentUser.GetCurrentUser();
            var allRole = _roleRepository.GetAll();
            var users = role.UserRoles.ToList();
            var newRole = _roleRepository.GetByName(NewRoleName);
            if (newRole == null)
            {
                return new BaseResponce<RoleResponseModel>
                {
                    Message = "new role not found",
                    Status = false,
                    Data = null,
                };
            }
            foreach (var item in users)
            {
                item.RoleId = newRole.Id;
            }
            _roleRepository.Update(role);

            return new BaseResponce<RoleResponseModel>
            {
                Message = "Deleted ",
                Status = true,
                Data = new RoleResponseModel
                {
                    Name = role.Name,
                    Description = role.Description,

                }
            };

        }

        public BaseResponce<List<RoleResponseModel>> GetAll()
        {


            var roles = _roleRepository.GetAll();
            if (roles == null)
            {
                return new BaseResponce<List<RoleResponseModel>>
                {
                    Message = "roles not found",
                    Status = false,
                    Data = null,
                };
            }
            var listOfrole = roles.Select(x => new RoleResponseModel
            {
                Name = x.Name,
                Description = x.Description,

            }).ToList();
            return new BaseResponce<List<RoleResponseModel>>
            {
                Message = "All roles",
                Status = true,
                Data = listOfrole
            };

        }

        public BaseResponce<RoleResponseModel> GetByName(string Name)
        {


            var roleExist = _roleRepository.Check(Name);


            if (!roleExist)
            {
                return new BaseResponce<RoleResponseModel>
                {
                    Message = "role Name not found",
                    Status = false,
                    Data = null,
                };
            }
            var role = _roleRepository.GetByName(Name);

            return new BaseResponce<RoleResponseModel>
            {
                Message = "Gotten the role",
                Status = true,
                Data = new RoleResponseModel
                {
                    Name = role.Name,
                    Description = role.Description,
                }
            };




        }

        public BaseResponce<RoleResponseModel> Update(RoleRequestModel role)
        {
            var roleExist = _roleRepository.GetByName(role.Name);
            if (roleExist == null)
            {
                return new BaseResponce<RoleResponseModel>
                {
                    Message = "role  Name not found",
                    Status = false,
                    Data = null,
                };
            }

            roleExist.Name = role.Name;
            roleExist.Description = role.Description;
            roleExist.CreatedBy = _currentUser.GetCurrentUser();



            var role1 = _roleRepository.Update(roleExist);



            return new BaseResponce<RoleResponseModel>
            {
                Message = "Updated the role",
                Status = true,
                Data = new RoleResponseModel
                {
                    Name = role1.Name,
                    Description = role1.Description,
                }
            };

        }
    }

}