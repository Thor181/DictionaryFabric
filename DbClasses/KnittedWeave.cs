using System;
using System.Collections.Generic;

namespace DictionaryFabricApplication
{
    public partial class KnittedWeave : ITable
    {
        public KnittedWeave()
        {
            TypeKnitteds = new HashSet<TypeKnitted>();
        }

        public long Id { get; set; }
        public string? Name { get; set; }
        public byte[]? Image { get; set; }

        public virtual ICollection<TypeKnitted> TypeKnitteds { get; set; }
    }
}
