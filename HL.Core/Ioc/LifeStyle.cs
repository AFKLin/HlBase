using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HL.Core.Ioc
{
    public enum LifeStyle
    {
        Singleton=0,
        Transient=1,
        PreRequest=2
    }
}
