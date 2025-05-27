using System.Threading.Tasks;
using Kholy.IKEA.DAL.Entites.Identity;
using Kholy.IKEA.PL.ViewModels.Account;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Kholy.IKEA.PL.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        #region Signup
        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpModelView _signUpModelView)
        {
            if (!ModelState.IsValid)
            {
                return View(_signUpModelView);
            }
            var user = await _userManager.FindByNameAsync(_signUpModelView.UserName);
            if (user == null)
            {
                user = new ApplicationUser()
                {
                    UserName = _signUpModelView.UserName,
                    Email = _signUpModelView.Email,
                    FirstName = _signUpModelView.FirstName,
                    LastName = _signUpModelView.LastName,
                    isAgree = _signUpModelView.IsAgreed
                };
                var result = await _userManager.CreateAsync(user, _signUpModelView.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction(nameof(SignIn));
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            else
            {
                ModelState.AddModelError(nameof(SignUpModelView.UserName), "User already exists.");
            }

            return View(_signUpModelView);
        }
        #endregion

        #region SignIn
        [HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(SignInModelView _signInModelView)
        {
            if (!ModelState.IsValid)
            {
                return View(_signInModelView);
            }
            var user = await _userManager.FindByNameAsync(_signInModelView.UserName);
            if (user != null)
            {
                var result = await _signInManager.PasswordSignInAsync(user, _signInModelView.Password, _signInModelView.RememberMe, true);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid login attempt.");
                }
            }
            else
            {
                ModelState.AddModelError("", "Invalid login attempt.");
            }
            return View(_signInModelView);

        }
        //if (!ModelState.IsValid)
        //{
        //    return View(_signInModelView);
        //}
        //var result = await _signInManager.PasswordSignInAsync(_signInModelView.UserName, _signInModelView.Password, _signInModelView.RememberMe, false);
        //if (result.Succeeded)
        //{
        //    return RedirectToAction("Index", "Home");
        //}
        //else
        //{
        //    ModelState.AddModelError("", "Invalid login attempt.");
        //}
        //return View(_signInModelView);
    }
    #endregion


}

