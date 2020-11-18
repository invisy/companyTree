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
        private IUnitOfWork _unitOfWork;
        private IMapper<EmployeeEntity, Employee> _employeeMapper;
        
        public LoaderService(IUnitOfWork unitOfWork, IMapper<EmployeeEntity, Employee> employeeMapper)
        {
            _unitOfWork = unitOfWork;
            _employeeMapper = employeeMapper;
        }

        public void LoadData()
        {
            TreeContainer containerInstance = TreeContainer.GetInstance();
            containerInstance.Root = _employeeMapper.Map(_unitOfWork.Repository<IEmployeeRepository>().GetRoot());
        }

        public void SaveData()
        {
            throw new System.NotImplementedException();
        }
    }
}