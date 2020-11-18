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
            IQueryable<EmployeeEntity> rootQueryable = dbSet.AsQueryable().Where(employee => employee.parentId == null);
            List<EmployeeEntity> list = rootQueryable.ToList();
            if (list.Count() > 0)
                return list[0];
            return null;
        }
    }
}