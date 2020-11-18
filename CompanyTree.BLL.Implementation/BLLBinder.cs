using CompanyTree.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CompanyTree.DAL.Implementation;
using CompanyTree.BLL.Abstraction;
using CompanyTree.BLL.Implementation.Services;
using CompanyTree.BLL.Abstraction.Mappers;
using CompanyTree.BLL.Abstraction.Services;
using CompanyTree.BLL.Implementation.Mappers;

using CompanyTree.Entities;
using CompanyTree.Models;
using CompanyTree.Models.Abstractions;


namespace NotSimpleGame.BL.Implementation
{
    public static class BLBinder
    {
        public static void BindBL(this IIoCContainer container)
        {
            container.Register<ILoaderService, LoaderService>();
            container.Register<IMapper<EmployeeEntity, Employee>, EmployeeMapper>();
        }
    }
}
