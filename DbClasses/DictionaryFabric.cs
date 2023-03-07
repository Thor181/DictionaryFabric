using System;
using System.Collections.Generic;

namespace DictionaryFabricApplication
{
    public partial class DictionaryFabric : ITable
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
    }
}
