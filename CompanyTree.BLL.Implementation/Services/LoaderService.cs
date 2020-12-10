using CompanyTree.BLL.Abstraction.Mappers;
using CompanyTree.BLL.Abstraction.Services;
using CompanyTree.DAL.Abstraction;
using CompanyTree.DAL.Abstraction.Repositories;
using CompanyTree.Entities;
using CompanyTree.Models;
using CompanyTree.Models.Abstractions;

namespace CompanyTree.BLL.Implementation.Services
{
    public class LoaderService : ILoaderService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper<EmployeeEntity, Employee> _employeeMapper;

        public LoaderService(IUnitOfWork unitOfWork, IMapper<EmployeeEntity, Employee> employeeMapper)
        {
            _unitOfWork = unitOfWork;
            _employeeMapper = employeeMapper;
        }

        public Employee LoadData()
        {
            return _employeeMapper.Map(_unitOfWork.Repository<IEmployeeRepository>().GetRoot());
        }

        public void SaveData(Employee employee)
        {
            throw new System.NotImplementedException();
        }
    }
}