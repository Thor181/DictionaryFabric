using System;
using System.Collections.Generic;

namespace DictionaryFabricApplication
{
    public partial class TypesWovenPattern : ITable
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public string? Color { get; set; }
        public string? NumberDesign { get; set; }
        public string? Composition { get; set; }
        public string? Rapport { get; set; }
        public byte[]? Image { get; set; }
        public long? IdPattern { get; set; }

        public virtual Pattern? IdPatternNavigation { get; set; }
    }
}
