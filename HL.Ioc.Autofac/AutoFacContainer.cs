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
                var reg=c.RegisterType(t).ToLifeStyle(lifeStyle);
                if (!string.IsNullOrEmpty(name))
                {
                    reg.Named(name,t);
                }
            });
            return this;
        }

        public IObjectContainer RegisterType(Type t, object instance, string name, LifeStyle lifeStyle)
        {
            return RegisterType(t, t, null, lifeStyle);
        }

        public IObjectContainer RegisterType(Type from, Type to, string name, LifeStyle lifeStyle)
        {

            UpdateContainer(c =>
            {
                if (from.IsGenericType&&to.IsGenericTypeDefinition)
                {
                    var tempreg=c.RegisterGeneric(from).As(to);
                    if (!string.IsNullOrEmpty(name))
                    {
                        tempreg.Named(name, to);
                    }
                }
                else
                {
                    var tempreg = c.RegisterType(from).As(to);
                    if (!string.IsNullOrEmpty(name))
                    {
                        tempreg.Named(name, to);
                    }
                }
            });
            return this;
        }

        public IObjectContainer RegisterType<T>(Func<T> func, string name, LifeStyle lifeStyle)
        {
            UpdateContainer(c =>
            {
                var temp = c.Register(e => func()).ToLifeStyle(lifeStyle);
                if (!string.IsNullOrEmpty(name))
                {
                    temp.Named(name, typeof(T));
                }
            });
            return this;
        }


        private void UpdateContainer(Action<ContainerBuilder> regeister)
        {
            var builder = new ContainerBuilder();
            regeister(builder);
            builder.Update(_container);
        }


        public object Reslove(Type t)
        {
            return LoadScope().Resolve(t);
        }

        public object Reslove(Type t, string name)
        {
            return LoadScope().ResolveNamed(name, t);
        }

        public IEnumerable<object> ResloveAll(Type t)
        {
            var type = typeof(IEnumerable<>).MakeGenericType(t);
            return (IEnumerable<object>)LoadScope().Resolve(type);
        }


        private ILifetimeScope LoadScope()
        {
            try
            {
                return AutoFacHttpModule.GetLifeScope(_container);
            }
            catch (Exception)
            {

                return _container;
            }
        }

        public T Reslove<T>() where T : class
        {
            return (T)Reslove(typeof(T));
        }
    }

    public static class AutoFacContainerExtensions
    {
        public static IRegistrationBuilder<TLimit, TActivatorData, TRegistrationStyle> ToLifeStyle<TLimit, TActivatorData, TRegistrationStyle>(this IRegistrationBuilder<TLimit, TActivatorData, TRegistrationStyle> builder,LifeStyle lifestyle)
        {
            switch (lifestyle)
            {
                case LifeStyle.Singleton:
                    return builder.SingleInstance();
                case LifeStyle.Transient:
                    return builder.InstancePerDependency();
                case LifeStyle.PreRequest:
                    return builder.InstancePerLifetimeScope();
                default:
                    return null;
            }
        }
    }
}
