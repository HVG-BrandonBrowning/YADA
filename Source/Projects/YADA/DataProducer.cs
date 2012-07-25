using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace YADA
{
    public class DataProducer
    {
        public IDataReader Supplier { get; private set; }

        public DataProducer(IDataReader supplier)
        {
            Supplier = supplier;
        }

        public DataProducerResult FromProcedure()
        {
            return null;
        }
    }
}
