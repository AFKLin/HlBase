using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HL.Core.Data;

namespace HL.Data
{
    public class EfRepository<T> : IRepository<T> where T:class
    {
        private readonly DbContext _dbcontext;
        private readonly IDbSet<T> _dbSet;

        public EfRepository(IDbContext dbcontext)
        {
            _dbcontext = (DbContext)dbcontext;
            _dbSet = _dbcontext.Set<T>();

        }
        public IQueryable<T> Table
        {
            get
            {
                return _dbSet;
            }
        }

        public void Delete(IEnumerable<T> entitys)
        {
            foreach (var item in entitys)
            {
                _dbSet.Remove(item);
            }
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public T GetById(object id)
        {
            return _dbSet.Find(id);
        }

        public void Insert(IEnumerable<T> entitys)
        {
            foreach (var item in entitys)
            {
                _dbSet.Add(item);
            }
        }

        public void Insert(T entity)
        {
            _dbSet.Add(entity);
        }

        public void Update(IEnumerable<T> entitys)
        {
            
        }

        public void Update(T entity)
        {
            
        }
    }
}
