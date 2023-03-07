using System;
using System.Collections.Generic;

namespace DictionaryFabricApplication
{
    public partial class TypesFabric : ITable
    {
        public long Id { get; set; }
        public string Name { get; set; } = null!;
        public long? WeaveId { get; set; }
        public string? Composition { get; set; }
        public double? Density { get; set; }
        public byte[]? Image { get; set; }

        public virtual WevingWeave? Weave { get; set; }
    }
}
