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
        private IDataReaderProducer Reader { get; set; }

        public SimpleDataReader(IDataReaderProducer reader, string storedProcedure = null)
        {
            StoredProcedure = storedProcedure;
            Reader = reader;
        }

        public DataProducerResult Read()
        {
            var reader = Reader.ProduceDataReader();

            bool sprocCached = Cache.ContainsProcedure(StoredProcedure);

            string[] columns;
            if (!sprocCached)
            {
                columns = FindColumnNamesFromDataReader(reader).ToArray();
                StoredProcedureProducerCache.Save(StoredProcedure, columns);
            }
            else
            {
                columns = StoredProcedureProducerCache.Load(StoredProcedure).ToArray();
            }

            List<dynamic> rows = new List<dynamic>();
            while (reader.Read())
            {
                object[] values = new object[columns.Length];
                reader.GetValues(values);

                rows.Add(new SimpleDynamic(columns, values));
            }

            reader.Close();

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
