using Azure;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using RealEstate_Mvc_.Dtos;
using RealEstate_Mvc_.Repository.Interface;
using RealEstate_Mvc_.Service.Interface;
using RealEstateMvc.Models.Entities;
using RealEstateMvc.Models.Enum;
using System.Security.Cryptography;
using System.Security.Cryptography.Xml;

namespace RealEstate_Mvc_.Service.Implementation
{
    public class TransactionService : ITransactionService
    {
        //MakePayment is create transaction
        //Add money to wallet
        private readonly ITransactionRepository _transactionRepository;
        private readonly IUserRepository _userRepository;
        private readonly IPropertyRepository _propertyRepository;
        private readonly ICurrentUser _currentUser;
        private readonly ICustomerRepository _customerRepository;

        public TransactionService(ITransactionRepository transactionRepository, IUserRepository userRepository, IPropertyRepository propertyRepository, ICurrentUser currentUser, ICustomerRepository customerRepository)
        {
            _userRepository = userRepository;
            _transactionRepository = transactionRepository;
            _propertyRepository = propertyRepository;
            _currentUser = currentUser;
            _customerRepository = customerRepository;

        }
        public BaseResponce<TransactionResponseModel> Create(TransactionRequestModel transaction)
        {
            var property = _propertyRepository.GetById(transaction.PropertyId);
            var customer = _customerRepository.GetByEmail(transaction.Email);
            if (property == null || customer == null)
            {
                return new BaseResponce<TransactionResponseModel>
                {
                    Message = "Customer Email or PropertyId not found",
                    Status = false,
                    Data = null,
                };
            }
            if (customer.Wallet < property.Price)
            {
                return new BaseResponce<TransactionResponseModel>
                {
                    Message = "You dont have enough money in your wallet",
                    Status = false,
                    Data = null,
                };
            }
            if (property.IsAvailable == false)
            {
                return new BaseResponce<TransactionResponseModel>
                {
                    Message = "property is not available",
                    Status = false,
                    Data = null,
                };
            }
            Transaction transaction1 = new Transaction
            {
                RefNumber = $"tranc{Guid.NewGuid().ToString()}wer1232",
                CreatedBy = _currentUser.GetCurrentUser(),
                CustomerId = customer.Id,
                Property = property,
                Email = transaction.Email,
                Price = property.Price,
                PropertyId = transaction.PropertyId,
                TypeOfLeases = transaction.TypeOfLeases,
                Customer = customer,
                IsSucessfull = true,
                SellersEmail = transaction.SellersEmail,
            };


            _transactionRepository.Create(transaction1);

            return new BaseResponce<TransactionResponseModel>
            {
                Message = "Transaction Created Succesfully",
                Status = true,
                Data = new TransactionResponseModel
                {

                    RefNumber = transaction1.RefNumber,
                    Email = transaction1.Email,
                    Price = transaction1.Price,
                    SellersEmail = transaction1.SellersEmail,
                    PropertyId = transaction1.PropertyId,
                    IsSucessfull = transaction1.IsSucessfull,
                    TypeOfLeases = transaction1.TypeOfLeases,
                }

            };
        }

        public BaseResponce<TransactionResponseModel> Delete(string RefNumber)
        {
            var transaction = _transactionRepository.GetByRefNumber(RefNumber);

            if (transaction == null)
            {
                return new BaseResponce<TransactionResponseModel>
                {
                    Message = "transaction RefNumber not found",
                    Status = false,
                    Data = null,
                };
            }


            transaction.IsDeleted = true;
            transaction.DeletedBy = _currentUser.GetCurrentUser();
            transaction.DateDeleted = DateTime.UtcNow;
            _transactionRepository.Update(transaction);

            return new BaseResponce<TransactionResponseModel>
            {
                Message = "Deleted ",
                Status = true,
                Data = new TransactionResponseModel
                {

                    RefNumber = transaction.RefNumber,
                    Email = transaction.Email,
                    Price = transaction.Price,
                    SellersEmail = transaction.SellersEmail,
                    PropertyId = transaction.PropertyId,
                    IsSucessfull = transaction.IsSucessfull,
                    TypeOfLeases = transaction.TypeOfLeases,
                }
            };


        }

        public BaseResponce<List<TransactionResponseModel>> GetAll()
        {
            var transactions = _transactionRepository.GetAll();
            if (transactions == null)
            {
                return new BaseResponce<List<TransactionResponseModel>>
                {
                    Message = "no transaction found",
                    Status = false,
                    Data = null,
                };
            }
            var listOfTransactions = transactions.Select(x => new TransactionResponseModel
            {
                RefNumber = x.RefNumber,
                Email = x.Email,
                Price = x.Price,
                SellersEmail = x.SellersEmail,
                PropertyId = x.PropertyId,
                IsSucessfull = x.IsSucessfull,
                TypeOfLeases = x.TypeOfLeases,

            }).ToList();
            return new BaseResponce<List<TransactionResponseModel>>
            {
                Message = "All transaction",
                Status = true,
                Data = listOfTransactions
            };
        }

        public BaseResponce<List<TransactionResponseModel>> GetByCustomerId(string Id)
        {
            var transfer = _transactionRepository.GetByCustomerId(Id);
            if (transfer == null)
            {
                return new BaseResponce<List<TransactionResponseModel>>
                {
                    Message = "transactions not found",
                    Status = false,
                    Data = null
                };
            }
            var listOfTransaction = transfer.Select(x => new TransactionResponseModel
            {
                RefNumber = x.RefNumber,
                Email = x.Email,
                Price = x.Price,
                SellersEmail = x.SellersEmail,
                PropertyId = x.PropertyId,
                IsSucessfull = x.IsSucessfull,
                TypeOfLeases = x.TypeOfLeases,
            }).ToList();
            return new BaseResponce<List<TransactionResponseModel>>
            {
                Message = "All transactions",
                Status = true,
                Data = listOfTransaction
            };
        }

        public BaseResponce<List<TransactionResponseModel>> GetByCustomerEmail(string Email)
        {
            var user = _userRepository.Get(Email);
            var transfer = _transactionRepository.GetByCustomerEmail(Email);
            if (transfer == null || user == null)
            {
                return new BaseResponce<List<TransactionResponseModel>>
                {
                    Message = "transactions or userEmail not found",
                    Status = false,
                    Data = null
                };
            }
            var listOfTransaction = transfer.Select(x => new TransactionResponseModel
            {
                RefNumber = x.RefNumber,
                Email = x.Email,
                Price = x.Price,
                SellersEmail = x.SellersEmail,
                PropertyId = x.PropertyId,
                IsSucessfull = x.IsSucessfull,
                TypeOfLeases = x.TypeOfLeases,
            }).ToList();
            return new BaseResponce<List<TransactionResponseModel>>
            {
                Message = "All transfer",
                Status = true,
                Data = listOfTransaction
            };
        }

        public BaseResponce<List<TransactionResponseModel>> GetByPropertyId(string PropertyId)
        {
            var proprty = _propertyRepository.GetById(PropertyId);
            var exist = _transactionRepository.GetByPropertyId(PropertyId);
            if (exist == null || proprty == null)
            {
                return new BaseResponce<List<TransactionResponseModel>>
                {
                    Message = "property or transaction Id not found",
                    Status = false,
                    Data = null,
                };
            }
            var listOfTransaction = exist.Select(x => new TransactionResponseModel
            {
                RefNumber = x.RefNumber,
                Email = x.Email,
                Price = x.Price,
                SellersEmail = x.SellersEmail,
                PropertyId = x.PropertyId,
                IsSucessfull = x.IsSucessfull,
                TypeOfLeases = x.TypeOfLeases,
            }).ToList();
            return new BaseResponce<List<TransactionResponseModel>>
            {
                Message = "All transfer by propertyId",
                Status = true,
                Data = listOfTransaction
            };

        }


        public BaseResponce<TransactionResponseModel> GetByRefNumber(string RefNumber)
        {
            var transaction = _transactionRepository.GetByRefNumber(RefNumber);

            if (transaction == null)
            {
                return new BaseResponce<TransactionResponseModel>
                {
                    Message = "transaction not found",
                    Status = false,
                    Data = null,
                };
            }

            return new BaseResponce<TransactionResponseModel>
            {
                Message = "Gotten the transaction",
                Status = true,
                Data = new TransactionResponseModel
                {
                    RefNumber = transaction.RefNumber,
                    Email = transaction.Email,
                    Price = transaction.Price,
                    SellersEmail = transaction.SellersEmail,
                    PropertyId = transaction.PropertyId,
                    IsSucessfull = transaction.IsSucessfull,
                    TypeOfLeases = transaction.TypeOfLeases,
                }
            };




        }

        public BaseResponce<TransactionResponseModel> Update(string RefrenceNumber, TransactionRequestModel transactionRequestModel)
        {
            var transaction = _transactionRepository.GetByRefNumber(RefrenceNumber);
            var property = _propertyRepository.GetById(transactionRequestModel.PropertyId);

            if (transaction == null)
            {
                return new BaseResponce<TransactionResponseModel>
                {
                    Message = "transaction not found",
                    Status = false,
                    Data = null,
                };
            }

            transaction.PropertyId = transactionRequestModel.PropertyId;
            transaction.SellersEmail = transactionRequestModel.SellersEmail;
            transaction.Price = property.Price;
            transaction.CustomerId = transaction.CustomerId;
            transaction.Email = transactionRequestModel.Email;
            transaction.TypeOfLeases = transactionRequestModel.TypeOfLeases;
            transaction.IsSucessfull = transactionRequestModel.IsSucessfull;
            transaction.CreatedBy = _currentUser.GetCurrentUser();

            var updatedTransaction = _transactionRepository.Update(transaction);



            return new BaseResponce<TransactionResponseModel>
            {
                Message = "Updated ",
                Status = true,
                Data = new TransactionResponseModel
                {
                    RefNumber = transaction.RefNumber,
                    Email = transaction.Email,
                    Price = transaction.Price,
                    SellersEmail = transaction.SellersEmail,
                    PropertyId = transaction.PropertyId,
                    IsSucessfull = transaction.IsSucessfull,
                    TypeOfLeases = transaction.TypeOfLeases,
                }
            };

        }
    }

}