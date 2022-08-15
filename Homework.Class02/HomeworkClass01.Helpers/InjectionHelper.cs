using Microsoft.Extensions.DependencyInjection;
using HomeworkClass01.DataAccess;
using HomeworkClass01.DataAccess.Implementations;
using HomeworkClass01.Domain.Models;
using HomeworkClass01.Services.Interfaces;
using HomeworkClass01.Services.Implementations;

namespace HomeworkClass01.Helpers
{
   public static class InjectionHelper
    {
        public static void InjectRepositories(IServiceCollection services)
        {
            services.AddTransient<IGenericRepository<User>, UserRepository>();
            services.AddTransient<IGenericRepository<Book>, BookRepository>();
        }

        public static void InjectServices(IServiceCollection services)
        {
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IBookService, BookService>();

        }
    }
}
