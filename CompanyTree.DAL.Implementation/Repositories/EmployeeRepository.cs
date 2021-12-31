using System.Collections.Generic;
using System.Linq;
using CompanyTree.DAL.Abstraction.Repositories;
using CompanyTree.Entities;

namespace CompanyTree.DAL.Implementation.Repositories
{
    public class EmployeeRepository : GenericRepository<EmployeeEntity, int>, IEmployeeRepository
    {
        public EmployeeRepository(CompanyTreeDBContext dbContext) : base(dbContext)
        {
            
        }
        
        public EmployeeEntity GetRoot()
        {
            List<EmployeeEntity> root = dbSet.Where(employee => employee.positionId == null).ToList();
            if (root.Any())
                return root[0];
            return null;
        }
    }
}