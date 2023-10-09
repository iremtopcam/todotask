
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.DataAccess1.Interfaces;
using ToDoApp.Entities1.Domains;

namespace ToDoApp.Business.Interfaces
{
    public interface IUserService
    {
        //Task<ApplicationUser> GetUserByIdAsync(string userId);
        //Task<ApplicationUser> GetUserByEmailAsync(string email);
        //Task<bool> CheckPasswordAsync(ApplicationUser user, string password);

        //kayıt olmayla mı ilgili 
        //Task<IdentityResult> CreateUserAsync(ApplicationUser user, string password);
        User LoginAsync(string email, string password);
        //Task LogoutAsync();


    }
}
