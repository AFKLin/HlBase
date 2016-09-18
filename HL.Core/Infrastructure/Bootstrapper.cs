using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HL.Core;
using HL.Core.Ioc;

namespace HL.Core.Infrastructure
{
    public class Bootstrapper
    {
        public static Bootstrapper Current;
        public static Bootstrapper Create()
        {
            var result= Current ?? (Current = new Bootstrapper());
            return result;
        }


        
        public IObjectContainer Container;
        public void SetContainer(IObjectContainer container)
        {
            Container = container;
        }


        public Bootstrapper RegestCustomCommponet(Action<IObjectContainer> func)
        {
            func(Container);
            return this;
        }
    }
}
