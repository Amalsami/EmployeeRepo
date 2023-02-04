using EmployeeRep.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace EmployeeRep.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;
        private object result;

        public AccountController(UserManager<IdentityUser> _userManager,SignInManager<IdentityUser> _signInManager)
        {
            userManager = _userManager;
            signInManager = _signInManager;
        }
        //open link
        public IActionResult Registration()
        {
            return View();
        }

        // action from database 
        [HttpPost]
        public async Task< IActionResult> Registration(RegisterAccountViewModel newAccount)   
        {
            if(ModelState.IsValid==true)
            {
                IdentityUser user = new IdentityUser();
                user.UserName = newAccount.UserName;
                user.Email = newAccount.Email;

             IdentityResult result= await userManager.CreateAsync(user, newAccount.Password);
                if(result.Succeeded)
                { 
                    await signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("GetByid", "employee");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }

                }
            }
           


            return View(newAccount);
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task< IActionResult> Login(LoginViewModel loginUser)
        {
            IdentityUser user = await userManager.FindByIdAsync(loginUser.UserName);
            if (user == null)
            {
                Microsoft.AspNetCore.Identity.SignInResult result =  await signInManager.PasswordSignInAsync(user,loginUser.Password,loginUser.isPressted,false);
                if (result.Succeeded)
                {
                    return RedirectToAction("GetByid", "employee");
                }
                else
                {
                    ModelState.AddModelError("", "Username and password not corect");
                }
            }
            else
            {
                ModelState.AddModelError("", "invalid User Name and Password");
            }


           
            return View();
        }
    }

    
}
