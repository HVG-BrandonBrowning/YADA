using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace YADA
{
    public class WhoKnows
    {
        private string StoredProcedure { get; set; }
        private SqlConnection Connection { get; set; }
        public SimpleDataReader DataReader { get; set; }
        private IEnumerable<Parameter> Parameters { get; set; }

        /*
        public WhoKnows(SqlConnection connection, string storedProcedure, IEnumerable<Parameter> parameters = null)
        {
            StoredProcedure = storedProcedure;
            Connection = connection;
            DataReader = reader;
            Parameters = parameters ?? Enumerable.Empty<Parameter>();
        }

        public IDataReader CreateStoredProcedureReader()
        {
            var command = new SqlCommand(storedProcedure, connection);
            command.CommandType = CommandType.StoredProcedure;

            foreach (var parameter in parameters)
                command.Parameters.Add(parameter);

            return command.ExecuteReader();
        }
        */
    }
}
