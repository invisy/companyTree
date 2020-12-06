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


namespace CompanyTree.BLL.Implementation
{
    public static class BLLBinder
    {
        public static void BindBLL(this IIoCContainer container)
        {
            container.Register<ILoaderService, LoaderServiceDummy>();
            container.Register<ICompanyTreeService, CompanyTreeService>();
            container.Register<IWithHigherSalaryFinderVisitor, WithHigherSalaryFinderVisitor>();
            container.Register<IWithPositionFinderVisitor, WithPositionFinderVisitor>();
            container.Register<IWithMaxSalaryFinderVisitor, WithMaxSalaryFinderVisitor>();
            container.Register<ICompanyStructureDisplayOrder, CompanyStructureDisplayOrder>();
            container.Register<ICompanyStructureDirectStrategy, CompanyStructureDirectStrategy>();
            container.Register<ICompanyStructureByPositionStrategy, CompanyStructureByPositionStrategy>();
            container.Register<IMapper<EmployeeEntity, Employee>, EmployeeMapper>();
            container.RegisterSingleton<TreeContainer, TreeContainer>();
        }
    }
}
