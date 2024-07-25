using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RealEstate_Mvc_.Dtos;
using RealEstate_Mvc_.Service.Interface;

namespace RealEstate_Mvc_.Controllers
{
    public class PropertyController : Controller
    {
        private readonly IPropertyService _PropertyService;
        private readonly ICartegoryService _CartegoryService;

        public PropertyController(IPropertyService PropertyService, ICartegoryService cartegoryService)
        {
            _PropertyService = PropertyService;
            _CartegoryService = cartegoryService;
        }


        public IActionResult CreateProperty()
        {
            var categories = _CartegoryService.GetAll();
            MultiSelectList multiSelectList = new MultiSelectList(categories.Data, "Id", "Name");
            var createDetail = new PropertyRequestModel
            {
                Categories = multiSelectList,
            };
            return View(createDetail);
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
            return RedirectToAction("Index","Home");

        }
    }
}
