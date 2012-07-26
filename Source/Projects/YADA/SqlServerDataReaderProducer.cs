using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace YADA
{
    public class SqlServerDataReaderProducer : IDataReaderProducer
    {
        private string StoredProcedure { get; set; }
        private SqlConnection Connection { get; set; }
        private IEnumerable<SqlParameter> Parameters { get; set; }

        public SqlServerDataReaderProducer(SqlConnection connection, string storedProcedure, IEnumerable<SqlParameter> parameters = null)
        {
            StoredProcedure = storedProcedure;
            Connection = connection;
            Parameters = parameters ?? Enumerable.Empty<SqlParameter>();
        }

        public IDataReader ProduceDataReader()
        {
            var command = new SqlCommand(StoredProcedure, Connection);
            command.CommandType = CommandType.StoredProcedure;

            foreach (var parameter in Parameters)
                command.Parameters.Add(parameter);

            if (Connection.State != ConnectionState.Open)
                Connection.Open();

            return command.ExecuteReader();
        }
    }
}
