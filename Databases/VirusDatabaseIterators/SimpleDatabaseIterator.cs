#nullable enable
using System;
using System.Collections.Generic;
using System.Text;

namespace Task3
{
    internal class SimpleDatabaseIterator : BaseVirusDatabaseIterator
    {
        int i = 0;
        private readonly IReadOnlyList<SimpleDatabaseRow> virusDatas;
        private readonly IGenomeCollection genomeCollection;
        public SimpleDatabaseIterator(SimpleDatabase database, IGenomeCollection genomeCollection)
        {
            virusDatas = database.Rows;
            this.genomeCollection = genomeCollection;
        }

        public override VirusData? Next()
        {
            if (i < virusDatas.Count)
            {
                // Single resposibility ? - chyba jest okej
                var genomList = FindMatchingGenomes();
                // może dodatkowa funkcja tworząca virusa z różnych podanych danych - no bo przecież SINGLE RESPOSIBILITY
                var virus = new VirusData(virusDatas[i].VirusName, virusDatas[i].DeathRate, virusDatas[i].InfectionRate, genomList);
                i++;
                return virus;
            }
            else
            {
                return null;
            }
        }

        public override List<GenomeData>? FindMatchingGenomes()
        {
            var genomeList = genomeCollection.GetGenomeDatas();
            var matchingGenomes = new List<GenomeData>();

            foreach (var genome in genomeList)
            {
                if (genome.Id == virusDatas[i].GenomeId)
                {
                    matchingGenomes.Add(genome);
                }
            }
            return matchingGenomes;
        }
    }
}
