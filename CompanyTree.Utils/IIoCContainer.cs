using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotSimpleGame.Utils
{
    public interface IIoCContainer
    {
        void Register<TType, TImplementation>() where TImplementation : class, TType;
        void Register<TImplementation>() where TImplementation : class;
        void RegisterSingleton<TType, TImplementation>(TImplementation obj = null) where TImplementation : class, TType;
        void RegisterSingleton<TImplementation>(TImplementation obj=null) where TImplementation : class;
        TTypeToResolve Resolve<TTypeToResolve>();
    }
}
