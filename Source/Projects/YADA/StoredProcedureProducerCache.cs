using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YADA
{
    public class StoredProcedureProducerCache
    {
        private static Dictionary<string, string[]> ColumnCache { get; set; }

        static StoredProcedureProducerCache()
        {
            ColumnCache = new Dictionary<string, string[]>(short.MaxValue);
        }

        public static bool ContainsProcedure(string storedProcedure)
        {
            return ColumnCache.ContainsKey(storedProcedure);
        }
 
        public static void Save(string storedProcedure, IEnumerable<string> columns)
        {
            ColumnCache[storedProcedure] = columns.ToArray();
        }

        public static IEnumerable<string> Load(string storedProcedure)
        {
            return ColumnCache[storedProcedure];
        }
    }
}
