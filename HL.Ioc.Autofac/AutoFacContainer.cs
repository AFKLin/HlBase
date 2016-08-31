using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HL.Core.Ioc;
using Autofac;
using Autofac.Core;
using Autofac.Builder;

namespace HL.Ioc.Autofac
{
    public class AutoFacContainer : IObjectContainer
    {

        private readonly IContainer _container;
        public AutoFacContainer()
        {
            var autofac = new ContainerBuilder();
            
            _container = autofac.Build();
        }

        public IObjectContainer RegisterType(Type t, string name, LifeStyle lifeStyle)
        {
            UpdateContainer(c =>
            {
                c.RegisterType(t);
                c.Register()
            });
        }

        public IObjectContainer RegisterType(Type t, object instance, string name, LifeStyle lifeStyle)
        {
            throw new NotImplementedException();
        }

        public IObjectContainer RegisterType(Type from, Type to, string name, LifeStyle lifeStyle)
        {
            throw new NotImplementedException();
        }

        public IObjectContainer RegisterType<T>(Func<T> func, string name, LifeStyle lifeStyle)
        {
            throw new NotImplementedException();
        }


        private void UpdateContainer(Action<ContainerBuilder> regeister)
        {
            var builder = new ContainerBuilder();
            regeister(builder);
            builder.Update(_container);
        }


        public object Reslove(Type t)
        {
            throw new NotImplementedException();
        }

        public object Reslove(Type t, string name)
        {
            throw new NotImplementedException();
        }
    }

    public static class AutoFacContainerExtensions
    {
        public static IRegistrationBuilder<object, ConcreteReflectionActivatorData, SingleRegistrationStyle> Li
    }
}
