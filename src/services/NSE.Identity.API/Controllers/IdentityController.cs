using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NSE.Identity.API.Interfaces;
using NSE.Identity.API.Model;

namespace NSE.Identity.API.Controllers
{
    [Route("api/identity")]
    public class IdentityController : MainController
    {

        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private IIdentityHandler _identityHandler;

        public IdentityController(SignInManager<IdentityUser> signInManager,
                                  UserManager<IdentityUser> userManager,
                                  IIdentityHandler identityHandler)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _identityHandler = identityHandler;
        }

        [HttpPost("newRegister")]
        public async Task<ActionResult> Register(UserRegister userRegister)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            IdentityUser user = new IdentityUser
            {
                UserName = userRegister.Email,
                Email = userRegister.Email,
                EmailConfirmed = true
            };

            var result = await _userManager.CreateAsync(user, userRegister.Password);

            if (result.Succeeded)
            {
                //await _signInManager.SignInAsync(user, false);
                return CustomResponse(await GenerateJwt(userRegister.Email));
            }

            foreach(var error in result.Errors)
            {
                AddErrorProcessor(error.Description);
            }

            return CustomResponse();
        }

        [HttpPost("authenticate")]
        public async Task<ActionResult> Login(UserLogin userLogin)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var result = await _signInManager.PasswordSignInAsync(
                userLogin.Email,
                userLogin.Password,
                false,
                true);

            if (result.Succeeded) return CustomResponse(await GenerateJwt(userLogin.Email));


            if (result.IsLockedOut)
            {
                AddErrorProcessor("User blocked for exceeding attempts");
                return CustomResponse();
            }

            AddErrorProcessor("Wrong username or password");
            return CustomResponse();
        }

        private async Task<UserLoginResponse> GenerateJwt(string email)
        {
            return await _identityHandler.GenerateJwt(email);
        } 
    }
}
