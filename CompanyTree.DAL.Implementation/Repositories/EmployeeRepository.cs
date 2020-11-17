using CompanyTree.DAL.Abstraction.Repositories;
using CompanyTree.Entities;

namespace CompanyTree.DAL.Implementation.Repositories
{
    public class EmployeeRepository : GenericRepository<EmployeeEntity, int>, IEmployeeRepository
    {
        public EmployeeRepository(CompanyTreeDBContext dbContext) : base(dbContext)
        {
            
        }
    }
}