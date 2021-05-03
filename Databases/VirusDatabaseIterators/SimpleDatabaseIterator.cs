#nullable enable
using System;
using System.Collections.Generic;
using System.Text;

namespace Task3
{
    internal class SimpleDatabaseIterator : BaseVirusDatabaseIterator
    {
        private int i = 0;
        private readonly IReadOnlyList<SimpleDatabaseRow> virusDatas;
        public SimpleDatabaseIterator(SimpleDatabase database, IGenomeCollection genomeCollection) : base(genomeCollection)
        {
            virusDatas = database.Rows;
        }

        public override VirusData? Next()
        {
            if (i < virusDatas.Count)
            {
                var genomList = FindMatchingGenomes();
                var virus = new VirusData(virusDatas[i].VirusName, virusDatas[i].DeathRate, virusDatas[i].InfectionRate, genomList);
                i++;
                return virus;
            }
            else
            {
                return null;
            }
        }

        public override bool CheckCurrentGenome(GenomeData genome) => genome.Id == virusDatas[i].GenomeId;
    }
}
