using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using System.Security.Claims;
using Azure;
using RealEstate_Mvc_.Dtos;
using RealEstate_Mvc_.Service.Interface;

namespace RealEstate_Mvc_.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IStaffService _staffService;

        public UserController(IUserService userService,IStaffService staffService)
        {
            _userService = userService;
            _staffService = staffService;   
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(UserLoginRequestModel userLoginRequestModel)
        {
            var login = _userService.Login(userLoginRequestModel);
            if (login.Data == null)
            {
                ViewBag.Message = login.Message;
                return View();
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, login.Data.Email),
                new Claim(ClaimTypes.Name, login.Data.FullName),
                new Claim(ClaimTypes.NameIdentifier, login.Data.Id),
                new Claim(ClaimTypes.Role, login.Data.RoleName),
            };

            if (login.Data.RoleName == "Superadmin")
            {
                return View("SuperAdminDashBord");
            }

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);
            var properties = new AuthenticationProperties();

            HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, properties);
            return RedirectToAction("GetAllProperty", "Property");
        }

        [HttpGet]
        public IActionResult createUser()
        {
            return View();
        }
        [HttpPost]
        public IActionResult createUser(StaffRequestModel Staff, UserRequestModel user, string RoleName, string RoleDesciption)
        {
            var createStaff = _staffService.Create(Staff);
            var createUser = _userService.Create(user,RoleName,RoleDesciption);
            if (createStaff.Data == null || createUser.Data == null)
            {
                ViewBag.Message = createUser.Message;
                return View();

            }
            return RedirectToAction("GetAllUser");

        }
        [HttpGet]
        public IActionResult DeleteUser()
        {
            return View();
        }
        [HttpPost]
        public IActionResult DeleteUser(string Email)
        {

            var delete = _userService.Delete(Email);
            if (delete.Data == null)
            {
                ViewBag.Message = delete.Message;
                return RedirectToAction("GetAllUser");
            }
            return View(delete);
        }

        [HttpGet]
        public IActionResult GetAllUser()
        {
            var getAllUser = _userService.GetAll();
            return View(getAllUser);
        }


        [HttpGet]
        public IActionResult GetByRoleId(string Id)
        {
            var getByRoleId = _userService.GetByRoleId(Id);
            if (getByRoleId.Data == null)
            {
                ViewBag.Message = getByRoleId.Message;
                return RedirectToAction("GetAllUser");
            }
            return View(getByRoleId);

        }
        [HttpGet]
        public IActionResult GetUserByEmail(string Email)
        {
            var getByEmail = _userService.Get(Email);
            if (getByEmail.Data == null)
            {
                ViewBag.Message = getByEmail.Message;
                return RedirectToAction("GetAllUser");
            }
            return View(getByEmail);

        }
        [HttpGet]
        public IActionResult UpdateUser()
        {
            return View();
        }
        [HttpPost]
        public IActionResult UpdateUser(UserRequestModel userRequestModel)
        {
            var update = _userService.Update(userRequestModel);
            if (update.Data == null)
            {
                ViewBag.Message = update.Message;
                return RedirectToAction("GetAllUser");
            }
            return View(update);
        }
    }
}
