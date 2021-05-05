using System;
using System.Collections.Generic;
using System.Text;

namespace Task3
{
    public interface IGenomeCollection
    {
        List<GenomeData> GetGenomeDatas(Guid genomeId);
        List<GenomeData> GetGenomeDatas(string genomeTag);
    }
}
