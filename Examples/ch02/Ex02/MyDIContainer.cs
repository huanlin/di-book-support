using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ch02.Ex02
{
    static class MyDIContainer
    {
        private static readonly Dictionary<Type, Type> typeMap = new Dictionary<Type, Type>();

        public static void Register(Type typeToResolve, Type concreteType)
        {
            typeMap[typeToResolve] = concreteType;
        }

        public static void Register<TypeToResolve, ConcreteType>()
        {
            typeMap[typeof(TypeToResolve)] = typeof(ConcreteType);
        }

        public static TypeToResolve Resolve<TypeToResolve>()
        {
            Type concreteType = typeMap[typeof(TypeToResolve)];
            Object instance = Activator.CreateInstance(concreteType);
            return (TypeToResolve)instance; 
        }
    }

}
