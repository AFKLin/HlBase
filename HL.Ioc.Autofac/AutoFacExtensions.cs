using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HL.Core.Infrastructure;

namespace HL.Ioc.Autofac
{
    public static class AutoFacExtensions
    {
        public static Bootstrapper UseAutoFac(this Bootstrapper bootstrapper)
        {
            Bootstrapper.Current.SetContainer(new AutoFacContainer());
            return bootstrapper;
        }
    }
}
