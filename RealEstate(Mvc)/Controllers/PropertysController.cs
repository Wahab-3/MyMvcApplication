using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using RealEstate_Mvc_.Dtos;
using RealEstate_Mvc_.Service.Interface;
using RealEstateMvc.Models.Enum;

namespace RealEstate_Mvc_.Controllers
{
    public class PropertysController : Controller
    {
        private readonly IPropertyService _PropertyService;

        public PropertysController(IPropertyService PropertyService)
        {
            _PropertyService = PropertyService;
        }
       
        
        public IActionResult CreateProperty()
        {
            var n = new PropertyRequestModel
            {

            };
            return View(n);
        }
        [HttpPost]
        public IActionResult CreateProperty(PropertyRequestModel property)
        {


            var createProperty = _PropertyService.Create(property);
            if (createProperty.Data == null)
            {
                ViewBag.Message = createProperty.Message;
                return View();

            }
            return View();

        }
        //[HttpGet]
        //public IActionResult DeleteProperty()
        //{
        //    return View();
        //}
        //[HttpPost]
        //public IActionResult DeleteProperty(string Id)
        //{

        //    var delete = _PropertyService.Delete(Id);
        //    if (delete.Data == null)
        //    {
        //        ViewBag.Message = delete.Message;
        //        return RedirectToAction("GetAllProperty");
        //    }
        //    return View(delete);
        //}


        //[HttpGet]
        //public IActionResult GetAllProperty()
        //{
        //    var getAllProperty = _PropertyService.GetAll();
        //    return View();
        //}

        //[HttpGet]
        //public IActionResult GetByOwnerId(string OwnerId)
        //{
        //    var getPropertyByOwnerId = _PropertyService.GetByOwnerId(OwnerId);
        //    if (getPropertyByOwnerId.Data == null)
        //    {
        //        ViewBag.Message = getPropertyByOwnerId.Message;
        //        return RedirectToAction("GetAllProperty");
        //    }
        //    return View(getPropertyByOwnerId);

        //}  
        //[HttpGet]
        //public IActionResult GetPropertyById(string Id)
        //{
        //    var getPropertyById = _PropertyService.GetById(Id);
        //    if (getPropertyById.Data == null)
        //    {
        //        ViewBag.Message = getPropertyById.Message;
        //        return RedirectToAction("GetAllProperty");
        //    }
        //    return View(getPropertyById);

        //} 
        //[HttpGet]
        //public IActionResult GetPropertyByLocation(string Location)
        //{
        //    var getPropertyByLocation = _PropertyService.GetByLocation(Location);
        //    if (getPropertyByLocation.Data == null)
        //    {
        //        ViewBag.Message = getPropertyByLocation.Message;
        //        return RedirectToAction("GetAllProperty");
        //    }
        //    return View(getPropertyByLocation);

        //}


        //[HttpGet]
        //public IActionResult GetPropertyByTypeOfLeases(TYpeOfLeases TypeOfLeases)
        //{
        //    var getPropertyByTypeOfLeases = _PropertyService.GetByTypeOfLease(TypeOfLeases);
        //    if (getPropertyByTypeOfLeases.Data == null)
        //    {
        //        ViewBag.Message = getPropertyByTypeOfLeases.Message;
        //        return RedirectToAction("GetAllProperty");
        //    }
        //    return View(getPropertyByTypeOfLeases);

        //}
        //[HttpGet]
        //public IActionResult GetPropertyByPrice(double price)
        //{
        //    var getPropertyByPrice = _PropertyService.GetByPrice(price);
        //    if (getPropertyByPrice.Data == null)
        //    {
        //        ViewBag.Message = getPropertyByPrice.Message;
        //        return RedirectToAction("GetAllProperty");
        //    }
        //    return View(getPropertyByPrice);

        //}


        //[HttpGet]
        //public IActionResult GetPropertyByCartegoryId(string CartegoryId)
        //{
        //    var getPropertyByCartegoryId = _PropertyService.GetByCartegoryId(CartegoryId);
        //    if (getPropertyByCartegoryId.Data == null)
        //    {
        //        ViewBag.Message = getPropertyByCartegoryId.Message;
        //        return RedirectToAction("GetAllProperty");
        //    }
        //    return View(getPropertyByCartegoryId);

        //}  
        //[HttpGet]
        //public IActionResult GetByAvailability()
        //{
        //    var getPropertyByAvailability = _PropertyService.GetByAvailability();
        //    if (getPropertyByAvailability.Data == null)
        //    {
        //        ViewBag.Message = getPropertyByAvailability.Message;
        //        return RedirectToAction("GetAllProperty");
        //    }
        //    return View(getPropertyByAvailability);

        //}

        //[HttpGet]
        //public IActionResult GetPropertyByDescription(string Description)
        //{
        //    var getPropertyByDescription = _PropertyService.GetByDescription(Description);
        //    if (getPropertyByDescription.Data == null)
        //    {
        //        ViewBag.Message = getPropertyByDescription.Message;
        //        return RedirectToAction("GetAllProperty");
        //    }
        //    return View(getPropertyByDescription);

        //}
        //[HttpGet]
        //public IActionResult UpdateProperty()
        //{
        //    return View();
        //}
        //[HttpPost]
        //public IActionResult UpdateProperty( PropertyRequestModel property)
        //{
        //    var update = _PropertyService.Update(property);
        //    if (update.Data == null)
        //    {
        //        ViewBag.Message = update.Message;
        //        return RedirectToAction("GetAllProperty");
        //    }
        //    return View(update);
        //}
    }
}
