using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using RealEstate_Mvc_.Dtos;
using RealEstate_Mvc_.Service.Interface;

namespace RealEstate_Mvc_.Controllers
{
    public class OwnerController : Controller
    {
        private readonly IOwnerService _ownerService;
        public OwnerController( IOwnerService ownerService)
        {
            _ownerService = ownerService;
        }
        // GET: OwnerController
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult createOwner()
        {
            return View();
        }
        [HttpPost]
        public IActionResult createOwner(OwnerRequestModel Owner)
        {
            var createOwner = _ownerService.Create(Owner);
            if (createOwner.Data == null)
            {
                ViewBag.Message = createOwner.Message;
                return View();

            }
            return RedirectToAction("GetAllOwner");

        }
        [HttpGet]
        public IActionResult Delete()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Delete(string StaffNumber)
        {

            var delete = _ownerService.Delete(StaffNumber);
            if (delete.Data == null)
            {
                ViewBag.Message = delete.Message;
                return RedirectToAction("GetAllOwner");
            }
            return View(delete);
        }


        [HttpGet]
        public IActionResult GetAllOwner()
        {
            var getAllOwner = _ownerService.GetAll();
            return View(getAllOwner);
        }
        [HttpGet]
        public IActionResult GetByEmail(string Email)
        {
            var getByEmail = _ownerService.GetByEmail(Email);
            if (getByEmail.Data == null)
            {
                ViewBag.Message = getByEmail.Message;
                return RedirectToAction("GetAllOwner");
            }
            return View(getByEmail);

        }


        [HttpGet]
        public IActionResult GetById(string Id)
        {
            var getById = _ownerService.GetById(Id);
            if (getById.Data == null)
            {
                ViewBag.Message = getById.Message;
                return RedirectToAction("GetAllOwner");
            }
            return View(getById);

        }
        [HttpGet]
        public IActionResult GetByStaffNumber(string StaffNumber)
        {
            var getByStaffNumber = _ownerService.GetByStaffNumber(StaffNumber);
            if (getByStaffNumber.Data == null)
            {
                ViewBag.Message = getByStaffNumber.Message;
                return RedirectToAction("GetAllOwner");
            }
            return View(getByStaffNumber);

        }
        [HttpGet]
        public IActionResult Update()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Update(OwnerRequestModel OwnerRequestModel)
        {
            var update = _ownerService.Update(OwnerRequestModel);
            if (update.Data == null)
            {
                ViewBag.Message = update.Message;
                return RedirectToAction("GetAllOwner");
            }
            return View(update);
        }

        // GET: OwnerController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: OwnerController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OwnerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: OwnerController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: OwnerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: OwnerController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: OwnerController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
