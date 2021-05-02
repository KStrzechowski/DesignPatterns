#nullable enable
using System;
using System.Collections.Generic;
using System.Text;

namespace Task3
{
    /// <summary>
    ///  UZUPEŁNIĆ CZYTANIE Z EXCELA
    /// </summary>
    internal class ExcellDatabaseIterator : BaseVirusDatabaseIterator
    {
       // private int i = 0;
        private readonly IGenomeCollection genomeCollection;
        public ExcellDatabaseIterator(ExcellDatabase database, IGenomeCollection genomeCollection)
        {
            this.genomeCollection = genomeCollection;
        }

        // TO DO
        public override VirusData? Next()
        {
            return null;
        }

        public override List<GenomeData>? FindMatchingGenomes()
        {
            var genomeList = genomeCollection.GetGenomeDatas();
            var matchingGenomes = new List<GenomeData>();

            foreach (var genome in genomeList)
            {
                if (genome.Id == null /*  Wstawić prawidłowy genomeId */)
                {
                    matchingGenomes.Add(genome);
                }
            }
            return matchingGenomes;
        }
    }
}
