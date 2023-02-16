using System;
using System.Collections.Generic;
using System.Text;

namespace Store
{
    public class OrderPayment
    {
        public string UnicueCode { get; }
        public string Description { get; }
        public IReadOnlyDictionary<string, string> Parameters { get; }

        public OrderPayment(string unicueCode, string description, IReadOnlyDictionary<string, string> parameters)
        {
            if (string.IsNullOrWhiteSpace(unicueCode))
                throw new AggregateException(nameof(unicueCode));

            if (string.IsNullOrWhiteSpace(description))
                throw new AggregateException(nameof(description));

            if (parameters == null)
                throw new ArgumentNullException(nameof(parameters));

            UnicueCode = unicueCode;
            Description = description;
            Parameters = parameters;
        }
    }
}
