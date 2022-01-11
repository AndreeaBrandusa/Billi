using BilliWebApp.Data;
using BilliWebApp.Models.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;

namespace BilliWebApp.Services
{
    public class IdentityService
    {
        private ApplicationDbContext _context;
        private UserManager<IdentityUser> _userManager;
        private SignInManager<IdentityUser> _signInManager;

        public IdentityService(ApplicationDbContext context, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<bool> LoginAsync(LoginModel model) 
        {
            if(!ValidateLoginModel(model))
            {
                // invalid model
                return false;
            }
            
            // log in
            if (!await AuthenticateAsync(model))
            {
                // user does not exist
                return false;
            }

            // logged in
            return true;
        }

        public async Task<bool> RegisterAsync(RegisterModel model)
        {
            if (!ValidateRegisterModel(model))
            {
                // invalid model
                return false;
            }

            if (!await CanRegister(model.Username, model.Email)) 
            { 
                return false; 
            }

            if(!await RegisterAccountAsync(model))
            {
                // unable to register account
                return false;
            }

            // log in
            if (!await AuthenticateAsync(RegisterModelToLoginModel(model)))
            {
                // user does not exist
                return false;
            }

            // logged in
            return true;
        }

        private bool ValidateLoginModel(LoginModel model)
        {
            if (model == null)
            {
                // invalid data
                return false;
            }

            if (string.IsNullOrEmpty(model.Username) || string.IsNullOrEmpty(model.Password))
            {
                // invalid data
                return false;
            }

            // valid data
            return true;
        }
        
        private bool ValidateRegisterModel(RegisterModel model)
        {
            if (model == null)
            {
                // invalid data
                return false;
            }

            if (string.IsNullOrEmpty(model.Username) || string.IsNullOrEmpty(model.Password) || string.IsNullOrEmpty(model.Email))
            {
                // invalid data
                return false;
            }

            // valid data
            return true;
        }

        private async Task<bool> AuthenticateAsync(LoginModel model)
        {
            var result = await _signInManager.PasswordSignInAsync(model.Username, model.Password, true, false);

            return result.Succeeded;
        }

        private async Task<bool> RegisterAccountAsync(RegisterModel model)
        {
            var result = await _userManager.CreateAsync(RegisterModelToIdentityUser(model), model.Password);

            return result.Succeeded;
        }

        private async Task<bool> CanRegister(string username, string email)
        {
            if((await _userManager.FindByNameAsync(username)) != null)
            {
                // there is an user with this username
                return false;
            }

            if ((await _userManager.FindByEmailAsync(email)) != null)
            {
                // there is an user with this email
                return false;
            }

            // there is no user with those credentials
            return true;
        }

        private IdentityUser RegisterModelToIdentityUser(RegisterModel model)
        {
            return new IdentityUser
            {
                Id = Guid.NewGuid().ToString(),
                UserName = model.Username,
                Email = model.Email
            };
        }

        private LoginModel RegisterModelToLoginModel(RegisterModel model)
        {
            return new LoginModel
            {
                Username = model.Username,
                Password = model.Password
            };
        }
    }
}
