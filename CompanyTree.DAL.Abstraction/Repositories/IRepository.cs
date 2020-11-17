using CompanyTree.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyTree.DAL.Abstraction.Repositories
{
    public interface IRepository<TEntity, Tkey> where TEntity : BaseEntity<Tkey> 
    {
        IEnumerable<TEntity> GetList();
        TEntity Get(Tkey id);
        void Create(TEntity item);
        void Delete(TEntity item);
        void Update(TEntity item);
    }
}
