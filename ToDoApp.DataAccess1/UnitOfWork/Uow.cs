using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.DataAccess1.Contexts;
using ToDoApp.DataAccess1.Interfaces;
using ToDoApp.DataAccess1.Repositories;
using ToDoApp.Entities1.Domains;

namespace ToDoApp.DataAccess1.UnitOfWork
{
    public class Uow : IUow
    {
        private readonly TodoContext _context;
         

        public Uow(TodoContext context)
        {
            _context = context; 

        }

        public IRepository<T> GetRepository<T>() where T : BaseEntity
        {
            return new Repository<T>(_context);
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
    }
}
