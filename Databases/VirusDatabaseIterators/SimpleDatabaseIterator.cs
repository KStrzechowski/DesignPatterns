#nullable enable
using System;
using System.Collections.Generic;
using System.Text;

namespace Task3
{
    internal class SimpleDatabaseIterator : IVirusDatabaseIterator
    {
        private int i = 0;
        private Guid currentGenomeId;
        private readonly IReadOnlyList<SimpleDatabaseRow> virusDatas;

        public SimpleDatabaseIterator(SimpleDatabase database)
        {
            virusDatas = database.Rows;
        }

        public VirusData? Next()
        {
            if (i < virusDatas.Count)
            {
                var virus = new VirusData(virusDatas[i].VirusName, virusDatas[i].DeathRate, virusDatas[i].InfectionRate, null);
                currentGenomeId = virusDatas[i].GenomeId;
                i++;
                return virus;
            }
            else
            {
                return null;
            }
        }

        public List<GenomeData>? FindMatchingGenomes(IGenomeCollection collection) => collection.GetGenomeDatas(currentGenomeId);
    }
}
