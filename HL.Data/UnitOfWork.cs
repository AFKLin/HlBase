using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HL.Core.Data;

namespace HL.Data
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private bool _disposed;
        private readonly IDbContext _dbContext;
        private readonly IDictionary<Type, object> _repostoryDic;

        public UnitOfWork(IDbContext dbcontext)
        {
            _dbContext = dbcontext;
            
        }
        public int Commit()
        {
           return _dbContext.SaveChanges();
        }
        public virtual void Dispose(bool disposing)
        {
            if (!_disposed)
                if (disposing)
                    _dbContext.Dispose();

            _disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public IRepository<T> Repostory<T>() where T : class
        {
            if (!_repostoryDic.ContainsKey(typeof(T)))
            {
                var repostory = new EfRepository<T>(_dbContext);
                _repostoryDic[typeof(T)] = repostory;
            }

            return (IRepository<T>)_repostoryDic[typeof(T)];
        }
    }
}
