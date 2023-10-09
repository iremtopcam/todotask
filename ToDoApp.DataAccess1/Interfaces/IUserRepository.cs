//using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Entities1.Domains;

namespace ToDoApp.DataAccess1.Interfaces
{
    public interface IUserRepository
    {
        //Task<ApplicationUser> GetUserByIdAsync(string userId);
        //Task<ApplicationUser> FindUserByEmailAsync(string email);
        //Task<bool> CheckPasswordAsync(ApplicationUser user, string password);
        //Task<User> CreateUserAsync(ApplicationUser user, string password);
        Task<User> LoginAsync(string email, string password);
        //Task LogoutAsync();




    }
}
