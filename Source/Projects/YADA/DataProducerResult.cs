using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;

namespace YADA
{
    public class DataProducerResult
    {
        private IEnumerable<dynamic> Results { get; set; }

        public DataProducerResult(IEnumerable<dynamic> results)
        {
            Contract.Assume(results != null);
            Contract.Assume(results.Any());

            Results = results;
        }

        public dynamic Single()
        {
            Contract.Ensures(Contract.Result<dynamic>() != null);
            return Results.First();
        }

        public IEnumerable<dynamic> Multiple()
        {
            Contract.Ensures(Contract.Result<IEnumerable<dynamic>>() != null);
            Contract.Ensures(Contract.Result<IEnumerable<dynamic>>().Any());
            return Results;
        }
    }
}
