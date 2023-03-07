using System;
using System.Collections.Generic;

namespace DictionaryFabricApplication
{
    public partial class Thread : ITable
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public string? Composition { get; set; }
        public byte[]? Image { get; set; }
    }
}
