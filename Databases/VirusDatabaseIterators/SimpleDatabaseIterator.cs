#nullable enable
using System;
using System.Collections.Generic;
using System.Text;

namespace Task3
{
    internal class SimpleDatabaseIterator : IVirusInfoDatabaseIterator
    {
        private int i = 0;
        private readonly IReadOnlyList<SimpleDatabaseRow> virusDatas;

        public SimpleDatabaseIterator(SimpleDatabase database)
        {
            virusDatas = database.Rows;
        }

        public VirusInfo? Next()
        {
            if (i < virusDatas.Count)
            {
                var virusInfo = new VirusInfo(virusDatas[i].VirusName, virusDatas[i].DeathRate, 
                    virusDatas[i].InfectionRate, virusDatas[i].GenomeId);
                i++;
                return virusInfo;
            }
            else
            {
                return null;
            }
        }
    }
}
