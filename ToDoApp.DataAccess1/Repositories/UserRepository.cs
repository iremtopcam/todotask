
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.DataAccess1.Contexts;
using ToDoApp.DataAccess1.Interfaces;
using ToDoApp.DataAccess1.UnitOfWork;
using ToDoApp.Entities1.Domains;

namespace ToDoApp.DataAccess1.Repositories
{


    public class UserRepository : IUserRepository
    {

        private readonly IUow _uow;

        public UserRepository(IUow uow) 
        {
            _uow = uow;

        }

        //public async Task<ApplicationUser> GetUserByIdAsync(string userId)
        //{
        //    return await _userManager.FindByIdAsync(userId);
        //}

        //public async Task<ApplicationUser> FindUserByEmailAsync(string email)
        //{
        //    return await _userManager.FindByEmailAsync(email);
        //}

        //public async Task<bool> CheckPasswordAsync(ApplicationUser user, string password)
        //{
        //    return await _userManager.CheckPasswordAsync(user, password);
        //}

        //public async Task<User> CreateUserAsync(ApplicationUser user, string password)
        //{
        //    var result = await _userManager.CreateAsync(user, password);
        //    return result;
        //}

        public async Task<User> LoginAsync(string email, string password)
        {
            //var result = await _signInManager.PasswordSignInAsync(email, password, isPersistent: false, lockoutOnFailure: false);
            //return result;
            var result = _uow.GetRepository<User>().GetQuery().Where(x => x.UserName == email && x.Password == password).FirstOrDefault();
            return result;

        }

        //public async Task<User> LogoutAsync()
        //{
        //    //await signInManager.SignOutAsync();
        //    //return RedirectToAction("Index", "Home", new { Area = "" });

        //    var result = _uow.GetRepository<User>().GetQuery().Where(x => x.UserName == email && x.Password == Password).FirstOrDefault();
        //    return result;
        //}


    }

 }

