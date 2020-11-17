using CompanyTree.DAL.Abstraction;
using CompanyTree.DAL.Abstraction.Repositories;
using System;
using System.Collections.Generic;

namespace CompanyTree.DAL.Implementation
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly CompanyTreeDBContext _dbContext;
        private readonly Dictionary<Type, Object> _repositories = new Dictionary<Type, object>();
        public UnitOfWork(CompanyTreeDBContext dbContext, IEmployeeRepository employeeRepository)
        {
            _dbContext = dbContext;
            _repositories.Add(typeof(IEmployeeRepository), employeeRepository);
        }

        public TRepository Repository<TRepository>()
        {
            if (_repositories.ContainsKey(typeof(TRepository)))
                return (TRepository)_repositories[typeof(TRepository)];
            else
                throw new ArgumentException("Repository does not exist!");
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
