using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompanyTree.Entities;
using CompanyTree.DAL.Abstraction.Repositories;
using Microsoft.EntityFrameworkCore;
using System.IO;

namespace CompanyTree.DAL.Implementation.Repositories
{
    public class GenericRepository<TEntity, Tkey> : IRepository<TEntity, Tkey> where TEntity: BaseEntity<Tkey> where Tkey : IComparable
    {
        private readonly CompanyTreeDBContext _dbContext;
        protected readonly DbSet<TEntity> dbSet;

        public GenericRepository(CompanyTreeDBContext dbContext)
        {
            _dbContext = dbContext;
            dbSet = _dbContext.Set<TEntity>();
        }

        public virtual void Create(TEntity entity)
        {
            dbSet.Add(entity);
        }

        public virtual TEntity Get(Tkey id)
        {
            return dbSet.Find(id);
        }

        public virtual IEnumerable<TEntity> GetList()
        {
            return dbSet;
        }
        public virtual void Update(TEntity entity)
        {
            TEntity find = this.Get(entity.Id);
            _dbContext.Entry(find).CurrentValues.SetValues(entity);
        }

        public virtual void Delete(TEntity entity)
        {
            dbSet.Remove(this.Get(entity.Id));
        }
    }
}
