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
        private TreeContainer _containerInstance;
        
        public LoaderService(IUnitOfWork unitOfWork, TreeContainer container, IMapper<EmployeeEntity, Employee> employeeMapper)
        {
            _unitOfWork = unitOfWork;
            _employeeMapper = employeeMapper;
            _containerInstance = container;
        }

        public void LoadData()
        {
            _containerInstance.Root = _employeeMapper.Map(_unitOfWork.Repository<IEmployeeRepository>().GetRoot());
        }

        public void SaveData()
        {
            throw new System.NotImplementedException();
        }
    }
}