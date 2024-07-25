using Humanizer;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using RealEstate_Mvc_.Dtos;
using RealEstate_Mvc_.Models.Entities;
using RealEstate_Mvc_.Repository.Interface;
using RealEstate_Mvc_.Service.Interface;
using RealEstateMvc.Models.Entities;
using RealEstateMvc.Models.Enum;
using System.Xml.Linq;

namespace RealEstate_Mvc_.Service.Implementation
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IUserRepository _userRepository;
        private readonly ICurrentUser _currentUser;
        private readonly IRoleRepository _roleRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public CustomerService(ICustomerRepository customerRepository, IUserRepository userRepository, ICurrentUser currentUser, IRoleRepository roleRepository, IWebHostEnvironment webHostEnvironment)
        {
            _customerRepository = customerRepository;
            _userRepository = userRepository;
            _currentUser = currentUser;
            _roleRepository = roleRepository;
            _webHostEnvironment = webHostEnvironment;
        }

        public BaseResponce<CustomerResponseModel> AddMoneyToWallet(string Email, double amount)
        {
            var customer = _customerRepository.GetByEmail(Email);

            if (customer == null)
            {
                return new BaseResponce<CustomerResponseModel>
                {
                    Message = "Customer Email already Exist",
                    Status = false,
                    Data = null,
                };
            }

            customer.Wallet += amount;
            _customerRepository.Update(customer);
            return new BaseResponce<CustomerResponseModel>
            {
                Message = "Wallet Updated Succesfully",
                Status = true,
                Data = new CustomerResponseModel
                {
                    Email = customer.Email,
                    FirstName = customer.FirstName,
                    LastName = customer.LastName,
                    PhoneNumber = customer.PhoneNumber,
                    Age = customer.Age,
                    Address = customer.Address,
                    Gender = customer.Gender,
                    Wallet = customer.Wallet
                }
            };

        }




        public BaseResponce<CustomerResponseModel> Create(CustomerRequestModel customer)
        {

            var customerExist = _customerRepository.Check(customer.Email);
            var userExist = _userRepository.Check(customer.Email);
            if (customer.ProfilePicture != null)
            {
                var uniqueFileName = Guid.NewGuid().ToString() + "_" + customer.ProfilePicture.FileName;
                if (customer.ProfilePicture.FileName != null)
                {
                    string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images");
                    if (Path.Exists(uploadsFolder))
                    {
                        var folder = Directory.CreateDirectory(uploadsFolder);
                    }
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        customer.ProfilePicture.CopyTo(fileStream);
                    }
                }


                if (customerExist || userExist)
                {
                    return new BaseResponce<CustomerResponseModel>
                    {
                        Message = "Customer Email already Exist",
                        Status = false,
                        Data = null,
                    };
                }
                if (customer.Password != customer.ConfirmPassword)
                {
                    return new BaseResponce<CustomerResponseModel>
                    {
                        Message = "password does not correspond",
                        Status = false,
                        Data = null,
                    };
                }
                var newPasswordd = BCrypt.Net.BCrypt.HashPassword(customer.Password);
                DateTime currentDatee = DateTime.Now;
                DateTime dobt = currentDatee.AddYears(-customer.Age);

                Customer customers = new Customer
                {
                    Email = customer.Email,
                    TagNumber = $"cust{Guid.NewGuid().ToString()}",
                    IsDeleted = false,
                    PhoneNumber = customer.PhoneNumber,
                    LastName = customer.LastName,
                    Address = customer.Address,
                    Age = customer.Age,
                    CreatedBy = customer.Email,
                    Dob = dobt,
                    FirstName = customer.FirstName,
                    Gender = customer.Gender,
                    ProfilePicturePath = uniqueFileName

                };
                User Users = new User
                {
                    Email = customer.Email,
                    Password = newPasswordd,
                    CreatedBy = customer.Email,
                    UserRoles = new List<UserRole>(),
                    FullName = customer.FirstName + " " + customer.LastName
                };

                var roles = _roleRepository.GetByName("Customer");
                if (roles == null)
                {

                    Role newRole = new Role
                    {
                        Name = "Customer",
                        Description = "Customer in the application",
                        IsDeleted = false,
                        CreatedBy = customer.Email

                    };
                    string RoleId = newRole.Id;
                    roles.Id = newRole.Id;
                    Users.UserRoles.Add(new UserRole
                    {
                        User = Users,
                        RoleId = newRole.Id,
                        Role = newRole,
                        UserId = Users.Id


                    });
                    _roleRepository.Create(newRole);
                }
                string rolesId = roles.Id;
                Users.UserRoles.Add(new UserRole
                {
                    User = Users,
                    RoleId = rolesId,
                    Role = roles,
                    UserId = Users.Id


                });
                _customerRepository.Create(customers);
                _userRepository.Create(Users);
                return new BaseResponce<CustomerResponseModel>
                {
                    Message = "Customer Created Succesfully",
                    Status = true,
                    Data = new CustomerResponseModel
                    {
                        Email = customer.Email,
                        FirstName = customer.FirstName,
                        LastName = customer.LastName,
                        PhoneNumber = customer.PhoneNumber,
                        Age = customer.Age,
                        Address = customer.Address,
                        Gender = customer.Gender,
                        Wallet = customers.Wallet
                    }
                };
            }

            if (customerExist || userExist)
            {
                return new BaseResponce<CustomerResponseModel>
                {
                    Message = "Customer Email already Exist",
                    Status = false,
                    Data = null,
                };
            }
            if (customer.Password != customer.ConfirmPassword)
            {
                return new BaseResponce<CustomerResponseModel>
                {
                    Message = "password does not correspond",
                    Status = false,
                    Data = null,
                };
            }
            var newPassword = BCrypt.Net.BCrypt.HashPassword(customer.Password);
            DateTime currentDate = DateTime.Now;
            DateTime dob = currentDate.AddYears(-customer.Age);

            Customer customer1 = new Customer
            {
                Email = customer.Email,
                TagNumber = $"cust{Guid.NewGuid().ToString()}",
                IsDeleted = false,
                PhoneNumber = customer.PhoneNumber,
                LastName = customer.LastName,
                Address = customer.Address,
                Age = customer.Age,
                CreatedBy = customer.Email,
                Dob = dob,
                FirstName = customer.FirstName,
                Gender = customer.Gender,

            };
            User User = new User
            {
                Email = customer.Email,
                Password = newPassword,
                CreatedBy = customer.Email,
                UserRoles = new List<UserRole>(),
                FullName = customer.FirstName + " " + customer.LastName
            };

            var role = _roleRepository.GetByName("Customer");
            if (role == null)
            {

                Role newRole = new Role
                {
                    Name = "Customer",
                    Description = "Customer in the application",
                    IsDeleted = false,
                    CreatedBy = customer.Email

                };
                string RoleId = newRole.Id;
                role.Id = newRole.Id;
                User.UserRoles.Add(new UserRole
                {
                    User = User,
                    RoleId = newRole.Id,
                    Role = newRole,
                    UserId = User.Id


                });
                _roleRepository.Create(newRole);
            }
            string roleId = role.Id;
            User.UserRoles.Add(new UserRole
            {
                User = User,
                RoleId = roleId,
                Role = role,
                UserId = User.Id


            });
            _customerRepository.Create(customer1);
            _userRepository.Create(User);
            return new BaseResponce<CustomerResponseModel>
            {
                Message = "Customer Created Succesfully",
                Status = true,
                Data = new CustomerResponseModel
                {
                    Email = customer.Email,
                    FirstName = customer.FirstName,
                    LastName = customer.LastName,
                    PhoneNumber = customer.PhoneNumber,
                    Age = customer.Age,
                    Address = customer.Address,
                    Gender = customer.Gender,
                    Wallet = customer1.Wallet
                }
            };
        }

        public BaseResponce<CustomerResponseModel> Delete(string Email)
        {
            var customer = _customerRepository.GetByEmail(Email);
            var user = _userRepository.Get(Email);
            if (customer == null || user == null)
            {
                return new BaseResponce<CustomerResponseModel>
                {
                    Message = "Customer Email not found",
                    Status = false,
                    Data = null,
                };
            }
            customer.IsDeleted = true;

            customer.DateCrated = DateTime.Now;
            customer.DeletedBy = _currentUser.GetCurrentUser();
            user.IsDeleted = true;
            user.DateCrated = DateTime.Now;
            user.DeletedBy = _currentUser.GetCurrentUser();
            var newCustomer = _customerRepository.Update(customer);
            _userRepository.Update(user);
            _customerRepository.Update(newCustomer);



            return new BaseResponce<CustomerResponseModel>
            {
                Message = "Deleted ",
                Status = true,
                Data = new CustomerResponseModel
                {
                    Email = customer.Email,
                    FirstName = customer.FirstName,
                    LastName = customer.LastName,
                    PhoneNumber = customer.PhoneNumber,
                    Age = customer.Age,
                    Address = customer.Address,
                    Gender = customer.Gender,
                    Wallet = customer.Wallet
                }
            };
        }

        public BaseResponce<List<CustomerResponseModel>> GetAll()
        {
            var customers = _customerRepository.GetAll();
            if (customers == null)
            {
                return new BaseResponce<List<CustomerResponseModel>>
                {
                    Message = "customers not found",
                    Status = true,
                    Data = null
                };
            }

            var listOfCustomers = customers.Select(x => new CustomerResponseModel
            {
                Email = x.Email,
                FirstName = x.FirstName,
                LastName = x.LastName,
                PhoneNumber = x.PhoneNumber,
                Age = x.Age,
                Address = x.Address,
                Gender = x.Gender,
                Wallet = x.Wallet,
                Transactions = x.Transactions.Select(c => new TransactionResponseModel
                {
                    Email = c.Email,
                    IsSucessfull = c.IsSucessfull,
                    Price = c.Price,
                    PropertyId = c.PropertyId,
                    RefNumber = c.RefNumber,
                    SellersEmail = c.SellersEmail,
                    TypeOfLeases = c.TypeOfLeases
                }).ToList()



            }).ToList();

            return new BaseResponce<List<CustomerResponseModel>>
            {
                Message = "All customers",
                Status = true,
                Data = listOfCustomers
            };
        }

        public BaseResponce<CustomerResponseModel> GetByEmail(string Email)
        {
            var customerExist = _customerRepository.Check(Email);
            var userExist = _userRepository.Check(Email);

            if (!customerExist || !userExist)
            {
                return new BaseResponce<CustomerResponseModel>
                {
                    Message = "Customer Email Not found",
                    Status = false,
                    Data = null,
                };
            }
            var customer = _customerRepository.GetByEmail(Email);
            var user = _userRepository.Get(Email);
            return new BaseResponce<CustomerResponseModel>
            {
                Message = "Gotten the customer",
                Status = true,
                Data = new CustomerResponseModel
                {
                    Email = customer.Email,
                    FirstName = customer.FirstName,
                    LastName = customer.LastName,
                    PhoneNumber = customer.PhoneNumber,
                    Age = customer.Age,
                    Address = customer.Address,
                    Gender = customer.Gender,
                    Wallet = customer.Wallet,
                    Transactions = customer.Transactions.Select(c => new TransactionResponseModel
                    {
                        Email = c.Email,
                        IsSucessfull = c.IsSucessfull,
                        Price = c.Price,
                        PropertyId = c.PropertyId,
                        RefNumber = c.RefNumber,
                        SellersEmail = c.SellersEmail,
                        TypeOfLeases = c.TypeOfLeases
                    }).ToList()
                }
            };
        }

        public BaseResponce<CustomerResponseModel> GetById(string Id)
        {

            var customer = _customerRepository.GetById(Id);
            var user = _userRepository.Get(Id);

            if (customer == null || user == null)
            {
                return new BaseResponce<CustomerResponseModel>
                {
                    Message = "Customer  not found",
                    Status = false,
                    Data = null,
                };
            }
            return new BaseResponce<CustomerResponseModel>
            {
                Message = "Gotten the customer",
                Status = true,
                Data = new CustomerResponseModel
                {
                    Email = customer.Email,
                    FirstName = customer.FirstName,
                    LastName = customer.LastName,
                    PhoneNumber = customer.PhoneNumber,
                    Age = customer.Age,
                    Address = customer.Address,
                    Gender = customer.Gender,
                    Wallet = customer.Wallet,
                    Transactions = customer.Transactions.Select(c => new TransactionResponseModel
                    {
                        Email = c.Email,
                        IsSucessfull = c.IsSucessfull,
                        Price = c.Price,
                        PropertyId = c.PropertyId,
                        RefNumber = c.RefNumber,
                        SellersEmail = c.SellersEmail,
                        TypeOfLeases = c.TypeOfLeases
                    }).ToList()
                }
            };
        }

        public BaseResponce<CustomerResponseModel> Update(CustomerRequestModel customer)
        {
            var customerExist = _customerRepository.GetByEmail(customer.Email);
            var userExist = _userRepository.Get(customer.Email);


            var uniqueFileName = Guid.NewGuid().ToString() + "_" + customer.ProfilePicture.FileName;

            if (customer.ProfilePicture != null)
            {
                string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images");
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    customer.ProfilePicture.CopyToAsync(fileStream);
                }
            }
            if (customerExist == null || userExist == null)
            {
                return new BaseResponce<CustomerResponseModel>
                {
                    Message = "Customer Email not found",
                    Status = false,
                    Data = null,
                };
            }
            var newPassword = $"qwert{BCrypt.Net.BCrypt.HashPassword(customer.Password)}";
            customerExist.Email = customer.Email;
            customerExist.FirstName = customer.FirstName;
            customerExist.LastName = customer.LastName;
            customerExist.PhoneNumber = customer.PhoneNumber;
            customerExist.Age = customer.Age;
            customerExist.Address = customer.Address;
            customerExist.Gender = customer.Gender;
            customerExist.ProfilePicturePath = uniqueFileName;
            customerExist.Dob = customer.Dob;
            userExist.Email = customer.Email;
            userExist.Password = newPassword;
            userExist.CreatedBy = _currentUser.GetCurrentUser();
            customerExist.CreatedBy = _currentUser.GetCurrentUser();

            userExist.FullName = customer.FirstName + customer.LastName;
            var customer1 = _customerRepository.Update(customerExist);
            var user1 = _userRepository.Update(userExist);



            return new BaseResponce<CustomerResponseModel>
            {

                Message = "Updated the customer",
                Status = true,
                Data = new CustomerResponseModel
                {
                    Email = customer.Email,
                    FirstName = customer.FirstName,
                    LastName = customer.LastName,
                    PhoneNumber = customer.PhoneNumber,
                    Age = customer.Age,
                    Address = customer.Address,
                    Gender = customer.Gender,
                    Wallet = customerExist.Wallet,
                    Transactions = customerExist.Transactions.Select(c => new TransactionResponseModel
                    {
                        Email = c.Email,
                        IsSucessfull = c.IsSucessfull,
                        Price = c.Price,
                        PropertyId = c.PropertyId,
                        RefNumber = c.RefNumber,
                        SellersEmail = c.SellersEmail,
                        TypeOfLeases = c.TypeOfLeases
                    }).ToList()
                }
            };
        }
    }
}