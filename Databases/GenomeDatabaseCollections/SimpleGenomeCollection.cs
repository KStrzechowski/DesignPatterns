using System;
using System.Collections.Generic;
using System.Text;

namespace Task3
{
    internal class SimpleGenomeCollection : IGenomeCollection
    {
        private readonly List<GenomeData> genomeDatas;
        public SimpleGenomeCollection(SimpleGenomeDatabase database)
        {
            this.genomeDatas = database.genomeDatas;
        }

        public List<GenomeData> GetGenomeDatas() => genomeDatas;
    }
}
