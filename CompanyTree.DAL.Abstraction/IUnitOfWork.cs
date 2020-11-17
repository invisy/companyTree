using System;
using System.Collections.Generic;
using System.Text;

namespace CompanyTree.DAL.Abstraction
{
    public interface IUnitOfWork
    {
        TRepository Repository<TRepository>();
        void Save();
    }
}
