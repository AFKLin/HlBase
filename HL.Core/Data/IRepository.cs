using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HL.Core.Data
{
    public interface IRepository<T>
    {
        void Insert(T entity);
        void Insert(IEnumerable<T> entitys);

        void Update(T entity);
        void Update(IEnumerable<T> entitys);

        void Delete(T entity);
        void Delete(IEnumerable<T> entitys);
        T GetById(object id);

        IQueryable<T> Table { get; }

    }
}
