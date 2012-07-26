using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace YADA
{
    public interface IDataReaderProducer
    {
        IDataReader ProduceDataReader();
    }
}
