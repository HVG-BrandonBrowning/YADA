using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace YADA.Simple
{
    public class Database
    {
        private SqlConnection Connection { get; set; }

        public Database(SqlConnection connection)
        {
            Connection = connection;
        }

        public Database(string connectionString)
            : this(new SqlConnection(connectionString))
        {
        }

        public List<dynamic> ExecuteProcedure(string storedProcedure, IEnumerable<SqlParameter> parameters = null)
        {
            var producer = new SqlServerDataReaderProducer(Connection, storedProcedure, parameters);
            var formatter = new SimpleDataReader(producer, storedProcedure);

            return formatter.Read().Multiple().ToList();
        }

        public List<T> ExecuteProcedure<T>(string storedProcedure, IEnumerable<SqlParameter> parameters = null)
        {
            var producer = new SqlServerDataReaderProducer(Connection, storedProcedure, parameters);
            var formatter = new SimpleDataReader(producer, storedProcedure);

            return formatter.Read<T>().Multiple().ToList();
        }
    }
}
