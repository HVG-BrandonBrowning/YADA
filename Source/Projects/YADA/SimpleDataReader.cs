using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Cache = YADA.StoredProcedureProducerCache;

namespace YADA
{
    public class SimpleDataReader
    {
        private string StoredProcedure { get; set; }
        private IDataReader Reader { get; set; }

        public SimpleDataReader(IDataReader reader, string storedProcedure = null)
        {
            StoredProcedure = storedProcedure;
            Reader = reader;
        }

        public DataProducerResult Read()
        {
            bool sprocCached = StoredProcedureProducerCache.ContainsProcedure(StoredProcedure);

            string[] columns;
            if (!sprocCached)
            {
                columns = FindColumnNamesFromDataReader(Reader).ToArray();
                StoredProcedureProducerCache.Save(StoredProcedure, columns);
            }
            else
            {
                columns = StoredProcedureProducerCache.Load(StoredProcedure).ToArray();
            }

            List<dynamic> rows = new List<dynamic>();
            while (Reader.Read())
            {
                object[] values = new object[columns.Length];
                Reader.GetValues(values);

                rows.Add(new SimpleDynamic(columns, values));
            }

            Reader.Close();

            return new DataProducerResult(rows);
        }

        public static IEnumerable<string> FindColumnNamesFromDataReader(IDataReader reader)
        {
            var schemaTable = reader.GetSchemaTable();

            foreach (DataRow row in schemaTable.Rows)
                yield return row.ItemArray[0].ToString();
        }
    }
}
