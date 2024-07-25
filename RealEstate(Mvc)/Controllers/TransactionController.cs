using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using RealEstate_Mvc_.Dtos;
using RealEstate_Mvc_.Service.Interface;

namespace RealEstate_Mvc_.Controllers
{
    public class TransactionController : Controller
    {
        private readonly ITransactionService _transferService;

        public TransactionController(ITransactionService transferService)
        {
            _transferService = transferService;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult createTransfer()
        {
            return View();
        }
        [HttpPost]
        public IActionResult createTransfer(TransactionRequestModel transaction)
        {


            var createTransaction = _transferService.Create(transaction);
            if (createTransaction.Data == null)
            {
                ViewBag.Message = createTransaction.Message;
                return View();

            }
            return RedirectToAction("GetAllTransfer");

        }
        [HttpGet]
        public IActionResult DeleteTransfer()
        {
            return View();
        }
        [HttpPost]
        public IActionResult DeleteTransfer(string RefNumber)
        {

            var delete = _transferService.Delete(RefNumber);
            if (delete.Data == null)
            {
                ViewBag.Message = delete.Message;
                return RedirectToAction("GetAllTransfer");
            }
            return View(delete);
        }


        [HttpGet]
        public IActionResult GetAllTransfer()
        {
            var getAllTransfer = _transferService.GetAll();
            return View(getAllTransfer);
        }

        [HttpGet]
        public IActionResult GetTransferByPropertyId(string PropertyId)
        {
            var getTransferByPropertyId = _transferService.GetByPropertyId(PropertyId);
            if (getTransferByPropertyId.Data == null)
            {
                ViewBag.Message = getTransferByPropertyId.Message;
                return RedirectToAction("GetAllTransfer");
            }
            return View(getTransferByPropertyId);

        }
        [HttpGet]
        public IActionResult GetTransferByRefNumber(string RefNumber)
        {
            var getTransferByRefNumber = _transferService.GetByRefNumber(RefNumber);
            if (getTransferByRefNumber.Data == null)
            {
                ViewBag.Message = getTransferByRefNumber.Message;
                return RedirectToAction("GetAllTransfer");
            }
            return View(getTransferByRefNumber);

        }
        [HttpGet]
        public IActionResult GetByCustomerId(string Id)
        {
            var getTransferById = _transferService.GetByCustomerId(Id);
            if (getTransferById.Data == null)
            {
                ViewBag.Message = getTransferById.Message;
                return RedirectToAction("GetAllTransfer");
            }
            return View(getTransferById);

        }
        public IActionResult GetTransferByEmail(string Email)
        {
            var getTransferByEmail = _transferService.GetByCustomerEmail(Email);
            if (getTransferByEmail.Data == null)
            {
                ViewBag.Message = getTransferByEmail.Message;
                return RedirectToAction("GetAllTransfer");
            }
            return View(getTransferByEmail);

        }


        [HttpGet]
        public IActionResult UpdateTransfer()
        {
            return View();
        }
        [HttpPost]
        public IActionResult UpdateTransfer(string RefrenceNumber, TransactionRequestModel transactionRequestModel)
        {
            var update = _transferService.Update(RefrenceNumber, transactionRequestModel);
            if (update.Data == null)
            {
                ViewBag.Message = update.Message;
                return RedirectToAction("GetAllTransfer");
            }
            return View(update);
        }
    }


  
}
