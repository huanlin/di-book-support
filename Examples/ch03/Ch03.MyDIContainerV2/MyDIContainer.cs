using Ch03.Common.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ch03.MyDIContainerV2
{
    // 自製 DI 容器 v2
    public static class MyDIContainer
    {
        static readonly Dictionary<Type, Type> typeMap = new Dictionary<Type, Type>();

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
