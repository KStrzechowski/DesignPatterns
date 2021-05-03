#nullable enable
using System;
using System.Collections.Generic;
using System.Text;

namespace Task3
{
    internal abstract class BaseVirusDatabaseIterator : IVirusDatabaseIterator
    {
        private readonly IGenomeCollection genomeCollection;
        protected BaseVirusDatabaseIterator(IGenomeCollection genomeCollection)
        {
            this.genomeCollection = genomeCollection;
        }

        public abstract VirusData? Next();
        public List<GenomeData>? FindMatchingGenomes()
        {
            var genomeList = GetGenomeList();
            var matchingGenomes = new List<GenomeData>();

            foreach (var genome in genomeList)
            {
                if (CheckCurrentGenome(genome))
                {
                    matchingGenomes.Add(genome);
                }
            }
            return matchingGenomes;
        }

        public List<GenomeData> GetGenomeList() => genomeCollection.GetGenomeDatas();
        public abstract bool CheckCurrentGenome(GenomeData genome);
    }
}
