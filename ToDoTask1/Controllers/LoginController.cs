using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoApp.Business.Interfaces;
using ToDoApp.DataAccess1.Interfaces;
using ToDoApp.Dtos1.Dtos;

namespace ToDoTask1.Controllers
{
    public class LoginController : Controller
    {
        

        IUserService _userService;

        public LoginController(IUserService userService )
        {
            
            this._userService= userService; 
        }

        public async Task<IActionResult> Index()
        {
            //var result = await userService.GetAllUsersWithRoleAsync();

            return View();
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }


        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(UserLoginDto userLoginDto)
        {
            if (ModelState.IsValid)
            {
                var user = _userService.LoginAsync(userLoginDto.Username, userLoginDto.Password);
                if (user != null)
                {
                    //var result = await signInManager.PasswordSignInAsync(user, userLoginDto.Password, userLoginDto.RememberMe, false);
                    var result = _userService.LoginAsync(userLoginDto.Username, userLoginDto.Password);
                    if (result!= null)
                    {
                        return RedirectToAction("Index", "Home", new { Area = "Admin" });
                    }
                    else
                    {
                        ModelState.AddModelError("", "E-posta adresiniz veya şifreniz yanlıştır.");
                        return View();
                    }
                }
                else
                {
                    ModelState.AddModelError("", "E-posta adresiniz veya şifreniz yanlıştır.");
                    return View();
                }
            }
            else
            {
                return View();
            }
        }
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            //await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home", new { Area = "" });
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> AccessDenied()
        {
            return View();
        }
    }


}

//[Area("Admin")]
//public class UserController : Controller
//{

//    private readonly IUserService userService;
//    private readonly IValidator<AppUser> validator;
//    private readonly RoleManager<AppRole> roleManager;
//    private readonly IToastNotification toast;
//    private readonly IMapper mapper;

//    public UserController(UserManager<AppUser> userManager, IUserService userService, IUnitOfWork unitOfWork, IValidator<AppUser> validator, RoleManager<AppRole> roleManager, IImageHelper imageHelper, IToastNotification toast, SignInManager<AppUser> signInManager, IMapper mapper)
//    {

//        this.userService = userService;
//        this.validator = validator;
//        this.roleManager = roleManager;
//        this.toast = toast;

//        this.mapper = mapper;
//    }
//    public async Task<IActionResult> Index()
//    {
//        var result = await userService.GetAllUsersWithRoleAsync();

//        return View(result);
//    }
//    [HttpGet]
//    public async Task<IActionResult> Add()

//    {
//        var roles = await userService.GetAllRolesAsync();
//        return View(new UserAddDto { Roles = roles });


//    }

//    [HttpPost]

//    public async Task<IActionResult> Add(UserAddDto userAddDto)
//    {
//        var map = mapper.Map<AppUser>(userAddDto);
//        var validation = await validator.ValidateAsync(map);
//        var roles = await roleManager.Roles.ToListAsync();

//        if (ModelState.IsValid)
//        {
//            var result = await userService.CreateUserAsync(userAddDto);
//            if (result.Succeeded)
//            {

//                toast.AddSuccessToastMessage(Messages.User.Add(userAddDto.Email), new ToastrOptions { Title = "Başarılı" });
//                return RedirectToAction("Index", "User", new { Area = "Admin" });

//            }
//            else
//            {


//                result.AddToIdentityModelState(this.ModelState);
//                validation.AddToModelState(this.ModelState);
//                return View(new UserAddDto { Roles = roles });



//            }

//        }
//        return View(new UserAddDto { Roles = roles });


//    }
//    [HttpGet]
//    public async Task<IActionResult> Update(Guid userId)
//    {
//        var user = await userService.GetAppUserByIdAsync(userId);

//        var roles = await userService.GetAllRolesAsync();

//        var map = mapper.Map<UserUpdateDto>(user);
//        map.Roles = roles;
//        return View(map);

//    }

//    [HttpPost]

//    public async Task<IActionResult> Update(UserUpdateDto userUpdateDto)
//    {

//        var user = await userService.GetAppUserByIdAsync(userUpdateDto.Id);
//        if (user != null)
//        {

//            var userRole = await userService.GetUserRoleAsync(user);
//            var roles = await userService.GetAllRolesAsync();
//            if (ModelState.IsValid)
//            {
//                var map = mapper.Map(userUpdateDto, user);
//                var validation = await validator.ValidateAsync(map);

//                if (validation.IsValid)
//                {
//                    user.UserName = userUpdateDto.Email;
//                    user.SecurityStamp = Guid.NewGuid().ToString();
//                    var result = await userService.UpdateUserAsync(userUpdateDto);

//                    if (result.Succeeded)
//                    {

//                        toast.AddSuccessToastMessage(Messages.User.Add(userUpdateDto.Email), new ToastrOptions { Title = "Başarılı" });
//                        return RedirectToAction("Index", "User", new { Area = "Admin" });
//                    }
//                    else
//                    {

//                        result.AddToIdentityModelState(this.ModelState);
//                        return View(new UserUpdateDto { Roles = roles });
//                    }

//                }
//                else
//                {

//                    validation.AddToModelState(this.ModelState);
//                    return View(new UserUpdateDto { Roles = roles });

//                }

//            }



//        }
//        return NotFound();
//    }

//    public async Task<IActionResult> Delete(Guid userId)
//    {




//        var result = await userService.DeleteUserAsync(userId);


//        if (result.identityResult.Succeeded)

//        {

//            toast.AddSuccessToastMessage(Messages.User.Delete(result.email), new ToastrOptions { Title = "Başarılı" });
//            return RedirectToAction("Index", "User", new { Area = "Admin" });

//        }
//        else
//        {
//            result.identityResult.AddToIdentityModelState(this.ModelState);
//        }
//        return NotFound();

//    }

//    [HttpGet]

//    public async Task<IActionResult> Profile()
//    {
//        var profile = await userService.GetUserProfileAsync();



//        return View(profile);
//    }
//    [HttpPost]
//    public async Task<IActionResult> Profile(UserProfileDto userProfileDto)
//    {

//        if (ModelState.IsValid)
//        {

//            var result = await userService.UserProfileUpdateAsync(userProfileDto);
//            if (result)
//            {
//                toast.AddSuccessToastMessage("Profil güncelleme işlemi tamamlandı. ", new ToastrOptions { Title = "Başarılı" });
//                return RedirectToAction("Index", "Home", new { Area = "Admin" });
//            }
//            else
//            {
//                var profile = await userService.GetUserProfileAsync();
//                toast.AddErrorToastMessage("Profil güncelleme işlemi tamamlanamadı. ", new ToastrOptions { Title = "Başarısız" });
//                return View(profile);


//            }

//        }
//        else
//            return NotFound();
//    }
//}
//}