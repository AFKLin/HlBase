using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HL.Core.Data;

namespace HL.Data
{
    public interface IUnitOfWork
    {
        int Commit();
        IRepository<T> Repostory<T>() where T:class;

    }
}
