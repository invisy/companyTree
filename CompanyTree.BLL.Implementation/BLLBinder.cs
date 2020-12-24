using CompanyTree.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CompanyTree.DAL.Implementation;
using CompanyTree.BLL.Abstraction;
using CompanyTree.BLL.Abstraction.CompanyStructureDisplay;
using CompanyTree.BLL.Implementation.Services;
using CompanyTree.BLL.Abstraction.Mappers;
using CompanyTree.BLL.Abstraction.Services;
using CompanyTree.BLL.Abstraction.Visitors;
using CompanyTree.BLL.Implementation.CompanyStructureDisplay;
using CompanyTree.BLL.Implementation.Mappers;
using CompanyTree.BLL.Implementation.Visitors;
using CompanyTree.Entities;
using CompanyTree.Models;
using CompanyTree.Models.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace CompanyTree.BLL.Implementation
{
    public static class BLLBinder
    {
        public static IServiceCollection BindBLL(this IServiceCollection services)
        {
            services.AddScoped<ILoaderService, LoaderServiceDummy>();
            services.AddScoped<ICompanyTreeStructuringService, CompanyTreeStructuringService>();
            services.AddScoped<ICompanyTreeFinderService, CompanyTreeFinderService>();
            services.AddTransient<IWithHigherSalaryFinderVisitor, WithHigherSalaryFinderVisitor>();
            services.AddTransient<IWithPositionFinderVisitor, WithPositionFinderVisitor>();
            services.AddTransient<IWithMaxSalaryFinderVisitor, WithMaxSalaryFinderVisitor>();
            services.AddTransient<ICompanyStructureDisplayOrder, CompanyStructureDisplayOrder>();
            services.AddTransient<ICompanyStructureDirectStrategy, CompanyStructureDirectStrategy>();
            services.AddTransient<ICompanyStructureByPositionStrategy, CompanyStructureByPositionStrategy>();
            services.AddTransient<IMapper<EmployeeEntity, Employee>, EmployeeMapper>();

            return services;
        }
    }
}
