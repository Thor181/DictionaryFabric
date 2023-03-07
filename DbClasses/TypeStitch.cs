using System;
using System.Collections.Generic;

namespace DictionaryFabricApplication
{
    public partial class TypeStitch : ITable
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public byte[]? Image { get; set; }
    }
}
