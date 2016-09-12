using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HL.Core.Ioc
{
    public interface IObjectContainer
    {
        IObjectContainer RegisterType(Type t, string name,LifeStyle lifeStyle);
        IObjectContainer RegisterType(Type from, Type to,string name, LifeStyle lifeStyle);
        IObjectContainer RegisterType(Type t,object instance, string name, LifeStyle lifeStyle);
        IObjectContainer RegisterType<T>(Func<T> func,string name, LifeStyle lifeStyle);

        object Reslove(Type t,string name);

        object Reslove(Type t);

        IEnumerable<object> ResloveAll(Type t);


    }
}
