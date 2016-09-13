using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;

namespace HL.Data
{
    public class EfDbContext : DbContext, IDbContext
    {
        public EfDbContext(string connectionString)
            :base(connectionString)
        {
            Database.CreateIfNotExists();
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.AddFromAssembly(typeof(EfDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
        public DataTable ExcuteSqlToDataTable(string commandtext, params object[] parameters)
        {
            var connection = Database.Connection;
            if (connection.State == ConnectionState.Closed)
                connection.Open();
            using (var cmd=connection.CreateCommand())
            {
                cmd.CommandText = commandtext;
                if (parameters != null)
                    foreach (var p in parameters)
                        cmd.Parameters.Add(p);
                using (SqlDataAdapter apt = new SqlDataAdapter((SqlCommand)cmd))
                {
                    using (var dt = new DataTable())
                    {
                        apt.Fill(dt);
                        return dt;
                    }
                }
                
            }
        }

        public int ExecuteSqlCommand(string commandtext, params object[] parameters)
        {
            return Database.ExecuteSqlCommand(commandtext, parameters);
        }

        public int ExecuteStoredProcedure(string commandtext, params object[] parameters)
        {
            var connection = Database.Connection;
            if (connection.State == ConnectionState.Closed)
                connection.Open();
            using (var cmd=connection.CreateCommand())
            {
                cmd.CommandText = commandtext;
                cmd.CommandType = CommandType.StoredProcedure;
                if (parameters != null)
                    foreach (var p in parameters)
                        cmd.Parameters.Add(p);
                return cmd.ExecuteNonQuery();
            }
        }

        public IEnumerable<T> ExecuteStoredProcedureList<T>(string commandtext, params object[] parameters)
        {
            if (parameters != null && parameters.Length > 0)
            {
                for (int i = 0; i <= parameters.Length - 1; i++)
                {
                    var p = parameters[i] as DbParameter;
                    if (p == null)
                        throw new Exception("Not support parameter type");

                    commandtext += i == 0 ? " " : ", ";

                    commandtext += "@" + p.ParameterName;
                    if (p.Direction == ParameterDirection.InputOutput || p.Direction == ParameterDirection.Output)
                    {
                        //output parameter
                        commandtext += " output";
                    }
                }
            }

            var result = this.Database.SqlQuery<T>(commandtext, parameters).ToArray();
            return result;

        }
        public IEnumerable<T> SqlQuery<T>(string sql, params object[] parameters)
        {
            return Database.SqlQuery<T>(sql, parameters);
        }
    }
}
