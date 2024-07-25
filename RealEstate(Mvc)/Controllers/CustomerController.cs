using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using RealEstate_Mvc_.Dtos;
using RealEstate_Mvc_.Service.Interface;

namespace RealEstate_Mvc_.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult AddMoneyToWallet()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddMoneyToWallet(string Email, double amount)
        {

            
            var addMoneyToWallet = _customerService.AddMoneyToWallet(Email,amount);
            if (addMoneyToWallet.Data == null)
            {
                ViewBag.Message = addMoneyToWallet.Message;
                return View();

            }
            return RedirectToAction("GetAllProperty","PropertyController");
            
        }

        [HttpGet]
        public IActionResult CreateCustomer()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateCustomer(CustomerRequestModel customer)
        {

            
           var createCustomer = _customerService.Create(customer);
            if (createCustomer.Data == null)
            {
                ViewBag.Message = createCustomer.Message;
                return View();

            }
            return RedirectToAction("Login","User");
            
        }
        [HttpGet]
        public IActionResult DeleteCustomer()
        {
            return View();
        }
        [HttpPost]
        [Authorize]
        public IActionResult DeleteCustomer(string Email)
        {

            var delete = _customerService.Delete(Email);
            if (delete.Data == null)
            {
                ViewBag.Message = delete.Message;
                return RedirectToAction("GetAllCustomer");
            }
            return View(delete);
        }


        [HttpGet]
        public IActionResult GetAllCustomer()
        {
            var getAllCustomer= _customerService.GetAll();
            return View(getAllCustomer.Data);
        }

        [HttpGet]
        public IActionResult GetByCustomerByEmail(string Email)
        {
            var getByEmail= _customerService.GetByEmail(Email);
            if (getByEmail.Data == null)
            {
                ViewBag.Message = getByEmail.Message;
                return RedirectToAction("GetAllCustomer");
            }
            return View(getByEmail);

        }
        [HttpGet]
        public IActionResult GetByCustomerById(string Id)
        {
            var getById= _customerService.GetById(Id);
            if (getById.Data == null)
            {
                ViewBag.Message = getById.Message;
                return RedirectToAction("GetAllCustomer");
            }
            return View(getById);

        }
        [HttpGet]
        public IActionResult UpdateCustomer()
        {
            return View();
        }
        [HttpPost]
        public IActionResult UpdateCustomer(CustomerRequestModel customer)
        {
            var update = _customerService.Update(customer);
            if (update.Data == null)
            {
                ViewBag.Message = update.Message;
                return RedirectToAction("GetAllCustomer");
            }
            return View(update);
        }


    }
}
