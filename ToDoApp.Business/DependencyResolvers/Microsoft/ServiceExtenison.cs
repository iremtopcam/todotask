using AutoMapper;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Business.Interfaces;
using ToDoApp.Business.Mapping.AutoMapper;
using ToDoApp.Business.Services;
using ToDoApp.Business.ValidationRules;
using ToDoApp.DataAccess1.Contexts;
using ToDoApp.DataAccess1.UnitOfWork;
using ToDoApp.Dtos1.Dtos;
using ToDoApp.Business.ValidationRules;
using ToDoApp.Business.Interfaces;
using ToDoApp.Dtos1.Dtos;

namespace ToDoApp.Business.DependencyResolvers.Microsoft
{
    public static class ServiceExtention
    {
        public static void AddDependencies(this IServiceCollection services, Action<ConnectionModel> action)
        {
            var cs = new ConnectionModel();
            action(cs);

            services.AddDbContext<TodoContext>(opt =>
            {
                opt.UseSqlServer(cs.ConnectionString);
                opt.LogTo(Console.WriteLine, LogLevel.Information);
            });

            services.AddScoped<IUow, Uow>();
            services.AddScoped<INoteService, NoteService>();

            services.AddScoped<IUserService, UserService>();

            var config = new MapperConfiguration(opt =>
            {
                opt.AddProfile(new NoteProfile());
            });

            var mapper = config.CreateMapper();
            services.AddSingleton<IMapper>(mapper); //Imapper
            services.AddTransient<IValidator<NoteCreateDto>, NoteCreateDtoValidator>();
            services.AddTransient<IValidator<NoteUpdateDto>, NoteUpdateDtoValidator>();
        }
    }
    public class ConnectionModel
    {
        public string ConnectionString { get; set; } = "";
    }
}
