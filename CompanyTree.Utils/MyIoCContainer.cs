using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotSimpleGame.Utils
{
    public class MyIoCContainer : IIoCContainer
    {
        private readonly Dictionary<Type, RegisteredImplementation> _registeredImplementations = new Dictionary<Type, RegisteredImplementation>();
        private class RegisteredImplementation
        {
            public Type ImplementationType { get; private set; }
            public readonly bool isSinglton;
            public object SingletonInstance { get; private set; }

            public RegisteredImplementation(Type implementationType, bool isSingleton, object instance)
            {
                isSinglton = isSingleton;
                ImplementationType = implementationType;
                SingletonInstance = instance;
            }
            public object CreateInstance(params object[] args)
            {
                object instance = Activator.CreateInstance(ImplementationType, args);
                if (isSinglton)
                    SingletonInstance = instance; 
                return instance;
            }
        }

        public void Register<TType, TImplementation>() where TImplementation : class, TType
        {
            Register<TType, TImplementation>(false, null);
        }
        public void Register<TImplementation>() where TImplementation : class
        {
            Register<TImplementation, TImplementation>(false, null);
        }

        public void RegisterSingleton<TType, TImplementation>(TImplementation obj) where TImplementation : class, TType
        {
            Register<TType, TImplementation>(true, obj);
        }

        public void RegisterSingleton<TImplementation>(TImplementation obj) where TImplementation : class
        {
            Register<TImplementation, TImplementation>(true, obj);
        }

        public TTypeToResolve Resolve<TTypeToResolve>()
        {
            return (TTypeToResolve)ResolveObject(typeof(TTypeToResolve));
        }

        private void Register<TType, TImplementation>(bool isSingleton, TImplementation instance)
        {
            Type type = typeof(TType);
            if (_registeredImplementations.ContainsKey(type))
                _registeredImplementations.Remove(type);
            _registeredImplementations.Add(type, new RegisteredImplementation(typeof(TImplementation), isSingleton, instance));
        }

        private object ResolveObject(Type type)
        {
            var registeredImplementation = _registeredImplementations[type];
            if (registeredImplementation == null)
            {
                throw new ArgumentOutOfRangeException(string.Format("The type {0} has not been registered", type.Name));
            }
            return GetInstance(registeredImplementation);
        }

        private IEnumerable<object> ResolveConstructorParameters(RegisteredImplementation registeredImplementation)
        {
            var constructorInfo = registeredImplementation.ImplementationType.GetConstructors().First();
            return constructorInfo.GetParameters().Select(parameter => ResolveObject(parameter.ParameterType));
        }

        private object GetInstance(RegisteredImplementation registeredImplementation)
        {
            object instance;
            if (registeredImplementation.isSinglton == false || registeredImplementation.SingletonInstance == null)
            {
                var parameters = ResolveConstructorParameters(registeredImplementation);
                instance = registeredImplementation.CreateInstance(parameters.ToArray());
            }
            else
                instance = registeredImplementation.SingletonInstance;

            return instance;
        }
    }
}
