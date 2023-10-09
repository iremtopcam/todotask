
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Business.Interfaces;
using ToDoApp.DataAccess1.Interfaces;
using ToDoApp.DataAccess1.Repositories;
using ToDoApp.DataAccess1.UnitOfWork;
using ToDoApp.Entities1.Domains;

namespace ToDoApp.Business.Services
{
    public class UserService : IUserService
    {
      

        private readonly IUow _uow;
        public UserService(IUow uow)
        {
            _uow = uow;
           
        }

        //public async Task<ApplicationUser> GetUserByIdAsync(string userId)
        //{
        //    return await _userRepository.GetUserByIdAsync(userId);
        //}

        //public async Task<ApplicationUser> GetUserByEmailAsync(string email)
        //{
        //    return await _userRepository.FindUserByEmailAsync(email);
        //}

        //public async Task<bool> CheckPasswordAsync(ApplicationUser user, string password)
        //{
        //    return await _userRepository.CheckPasswordAsync(user, password);
        //}

        //public async Task<IdentityResult> CreateUserAsync(ApplicationUser user, string password)
        //{
        //    return await _userRepository.CreateUserAsync(user, password);
        //}

        public User LoginAsync(string email, string password)
        {
            return _uow.GetRepository<User>().GetQuery().FirstOrDefault(x => x.UserName == email && x.Password == password);
        }

        //public async Task LogoutAsync()
        //{
        //    await _userRepository.LogoutAsync();
        //}
    }
}
