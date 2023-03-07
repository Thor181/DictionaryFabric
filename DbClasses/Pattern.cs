using System;
using System.Collections.Generic;

namespace DictionaryFabricApplication
{
    public partial class Pattern : ITable
    {
        public Pattern()
        {
            TypesWovenPatterns = new HashSet<TypesWovenPattern>();
        }

        public long Id { get; set; }
        public string? Name { get; set; }

        public virtual ICollection<TypesWovenPattern> TypesWovenPatterns { get; set; }
    }
}
