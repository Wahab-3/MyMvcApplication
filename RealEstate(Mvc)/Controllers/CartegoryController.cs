using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using RealEstate_Mvc_.Dtos;
using RealEstate_Mvc_.Service.Interface;

namespace RealEstate_Mvc_.Controllers
{

    //profile images and other pictures
    //Build
    //forgot password
    //check forgot password,confirm password , email and other things from front end
    //recipt

    //forget passord


    public class CartegoryController : Controller
    {
        private readonly ICartegoryService _cartegoryService;
        public CartegoryController(ICartegoryService cartegoryService)
        {
            _cartegoryService = cartegoryService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CategoryRequestModel  cartegoryRequestModel)
        {
           var createCartegory=_cartegoryService.Create(cartegoryRequestModel);
            if (createCartegory.Data == null)
            {
                ViewBag.Message = createCartegory.Message;
                return View();

            }
            return RedirectToAction("GetAllCartegory");
        }
        [HttpGet]
        public IActionResult Delete()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Delete(string Name,string NewCategory)
        {
            
            var delete = _cartegoryService.Delete(Name,NewCategory);
            if (delete.Data == null)
            {

                ViewBag.Message = delete.Message;
                return RedirectToAction("GetAllCartegory");
            }
            return View(delete);
        }
        [HttpGet]
        public IActionResult GetAllCartegory()
        {
            var getAllCartegory = _cartegoryService.GetAll();
            return View(getAllCartegory.Data);
        }
        [HttpGet]
        public IActionResult GetByName(string Name)
        {
            var getByName = _cartegoryService.GetByName(Name);
            if (getByName.Data == null)
            {
                ViewBag.Message = getByName.Message;
                return RedirectToAction("GetAllCartegory");
            }
            return View(getByName);

        }
        [HttpGet]
        public IActionResult GetById(string Id)
        {
            var getById = _cartegoryService.GetById(Id);
            if (getById.Data == null)
            {
                ViewBag.Message = getById.Message;
                return RedirectToAction("GetAllCartegory");
            }
            return View(getById);

        }
        [HttpGet]
        public IActionResult Update()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Update(CategoryRequestModel cartegory)
        {
            var update = _cartegoryService.Update(cartegory);
            if (update.Data == null)
            {
                ViewBag.Message = update.Message;
                return RedirectToAction("GetAllCartegory");
            }
            return View(update);
        }
    }
}
