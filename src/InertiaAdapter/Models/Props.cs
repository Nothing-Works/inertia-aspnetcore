using System.Collections.Generic;

namespace InertiaAdapter.Models
{
    internal class Props
    {
        public object? Controller { get; set; }
        public IDictionary<string, object>? SharedProps { get; set; }
        public object? With { get; set; }
    }
}
