using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HL.Data
{
    public interface IDbContext
    {
        int SaveChanges();
        int ExecuteSqlCommand(string commandtext, params object[] parameters);

        int ExecuteStoredProcedure(string commandtext, params object[] parameters);

        DataTable ExcuteSqlToDataTable(string commandtext, params object[] parameters);

        IEnumerable<T> ExecuteStoredProcedureList<T>(string commandtext, params object[] parameters);

        IEnumerable<T> SqlQuery<T>(string sql, params object[] parameters);

        void Dispose();

    }
}
