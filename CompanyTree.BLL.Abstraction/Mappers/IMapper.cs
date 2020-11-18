using System;
using System.Collections.Generic;
using System.Text;
using CompanyTree.Models;

namespace CompanyTree.BLL.Abstraction.Mappers
{
    public interface IMapper<TEntity, TModel>
    {
        public TModel Map(TEntity entity);
        public TEntity Map(TModel entity);
        public IEnumerable<TModel> Map(IEnumerable<TEntity> entityList);
        public IEnumerable<TEntity> Map(IEnumerable<TModel> entityList);
    }
}
