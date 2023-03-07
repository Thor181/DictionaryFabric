using System;
using System.Collections.Generic;

namespace DictionaryFabricApplication
{
    public partial class WevingWeave : ITable
    { 
        public WevingWeave()
        {
            TypesFabrics = new HashSet<TypesFabric>();
        }

        public long Id { get; set; }
        public string Name { get; set; } = null!;
        public byte[]? Image { get; set; }

        public virtual ICollection<TypesFabric> TypesFabrics { get; set; }
    }
}
