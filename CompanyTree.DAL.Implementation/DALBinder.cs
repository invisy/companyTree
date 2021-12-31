using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CompanyTree.Utils;
using CompanyTree.Entities;
using CompanyTree.DAL.Abstraction;
using CompanyTree.DAL.Abstraction.Repositories;
using CompanyTree.DAL.Implementation.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CompanyTree.DAL.Implementation
{
    public static class DALBinder
    {
        public static void BindDAL(this IIoCContainer container, string connectionString)
        {

            container.Register<IUnitOfWork, UnitOfWork>();

            var optionsBuilder = new DbContextOptionsBuilder<CompanyTreeDBContext>();
            optionsBuilder.UseSqlServer(connectionString);
            container.RegisterSingleton(new CompanyTreeDBContext(optionsBuilder.Options));
        }
        
        public static IServiceCollection BindDAL(this IServiceCollection services, string connectionString)
        {

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            
            services.AddDbContext<CompanyTreeDBContext>(options =>
                options.UseSqlServer(connectionString));

            return services;
        }
    }
}
