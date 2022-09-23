
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using RoyalKiddiesWard.Application.Services.Interfaces;
using RoyalKiddiesWard.Data.Models;

namespace RoyalKiddiesWard.Application.Services.Implementation
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly ILogger<UserService> _logger;
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<Role> _roleManager;
        

        public UserService(UserManager<User> userManager, ILogger<UserService> logger, SignInManager<User> signInManager, RoleManager<Role> roleManager)
        {
            _userManager = userManager;
            _logger = logger;
            _signInManager = signInManager;
            _roleManager = roleManager;
            
        }


        public async Task<User> GetUserIfExists(string email)
        {
            User user = null;
            try
            {
                user = await _userManager.FindByEmailAsync(email);
                return user;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error: {ex.Message} {ex.StackTrace}");
                throw;
            }
        }
        public async Task<User> CheckPassword(User user, string password)
        {
            var result = _userManager.PasswordHasher.VerifyHashedPassword(user, user.PasswordHash, password);

            if (result == Microsoft.AspNetCore.Identity.PasswordVerificationResult.Failed)
            {
                return null;
            }
            await _signInManager.PasswordSignInAsync(user.Email, password, false, false);

            return user;

        }

        public async Task<User> AuthenticateUser(string email, string password)
        {
            try
            {
                var existingUser = await GetUserIfExists(email);
                if (existingUser != null)
                {
                    existingUser = await CheckPassword(existingUser, password);
                }
                return existingUser;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error authenticating user: {ex.Message} {ex.StackTrace}");
                throw;
            }

        }

    }
}
