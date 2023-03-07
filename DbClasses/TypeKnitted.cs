using System;
using System.Collections.Generic;

namespace DictionaryFabricApplication
{
    public partial class TypeKnitted : ITable
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public long? WeaveId { get; set; }
        public string? Composition { get; set; }
        public byte[]? Image { get; set; }

        public virtual KnittedWeave? Weave { get; set; }
    }
}
