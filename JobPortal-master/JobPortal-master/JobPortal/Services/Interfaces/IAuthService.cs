using JobPortal.Helpers;
using System.Security.Claims;

namespace JobPortal.Services.Interfaces
{
    public interface IAuthService
    {
        Task<bool> Register(string userName, string password, bool signIn = true, string roleName = RoleHelper.User);

        Task<bool> Logout();

        Task<bool> Login(string userName, string password, bool rememberMe);

        Task<bool> IsSignedIn(ClaimsPrincipal claimsUser);

        Task<bool> AddRoleToUser();

        Task<bool> RemoveRolesFromUser();


    }
}
