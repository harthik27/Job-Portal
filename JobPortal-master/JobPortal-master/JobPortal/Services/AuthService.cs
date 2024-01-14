using JobPortal.Helpers;
using JobPortal.Models;
using JobPortal.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace JobPortal.Services
{
    public class AuthService: IAuthService
    {

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AuthService( UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<bool> Register(string userName, string password, bool signIn = true, string roleName = RoleHelper.User)
        {
            var createdUser = await CreateUser(userName, password);
            if (createdUser == null)
            {
                return false;
            }

            var roleAssigned = await AddRoleToUser(createdUser, roleName);
            if (!roleAssigned)
            {
                return false;
            }

            if (signIn)
            {
                await _signInManager.SignInAsync(createdUser, isPersistent: false);
            }

            // TODO: return status codes for further error handling
            return true;
        }

        private async Task<ApplicationUser> CreateUser(string userName, string password)
        {
            var user = new ApplicationUser { UserName = userName, Email = userName };

            try
            {
                var result = await _userManager.CreateAsync(user, password);

                if (!result.Succeeded)
                {
                    user = null;
                }
            }
           catch(Exception ex)
            { 

            }

            return user;
        }
        public async Task<bool> AddRoleToUser(ApplicationUser user, string roleName)
        {
            if (user == null)
            {
                return false;
            }

            var result = await _userManager.AddToRoleAsync(user, roleName);
            return result.Succeeded;
        }
        Task<bool> IAuthService.Logout()
        {
            throw new NotImplementedException();
        }

        Task<bool> IAuthService.Login(string userName, string password, bool rememberMe)
        {
            throw new NotImplementedException();
        }

        Task<bool> IAuthService.IsSignedIn(ClaimsPrincipal claimsUser)
        {
            throw new NotImplementedException();
        }

        Task<bool> IAuthService.AddRoleToUser()
        {
            throw new NotImplementedException();
        }

        Task<bool> IAuthService.RemoveRolesFromUser()
        {
            throw new NotImplementedException();
        }
    }
}
