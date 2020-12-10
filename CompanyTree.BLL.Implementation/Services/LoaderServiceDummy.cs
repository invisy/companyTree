using System;
using CompanyTree.BLL.Abstraction.Services;
using CompanyTree.Models.Abstractions;

namespace CompanyTree.BLL.Implementation.Services
{
    public class LoaderServiceDummy : ILoaderService
    {
        public Employee LoadData()
        {
            return null;
        }

        public void SaveData(Employee employee)
        {
            throw new NotImplementedException();
        }
    }
}