#nullable enable
using System;
using System.Collections.Generic;
using System.Text;

namespace Task3
{
    internal class ExcellDatabaseIterator : BaseVirusDatabaseIterator
    {
        private int i = 0;
        private readonly List<SimpleDatabaseRow> virusDatas = new List<SimpleDatabaseRow>();
        public ExcellDatabaseIterator(ExcellDatabase database, IGenomeCollection genomeCollection) : base(genomeCollection)
        {
            string[] Names = database.Names.Split(';');
            string[] DeathRates = database.DeathRates.Split(';');
            string[] InfectionRates = database.InfectionRates.Split(';');
            string[] GenomeIds = database.GenomeIds.Split(';');

            for(int i = 0; i < Names.Length; i++)
            {
                var Row = new SimpleDatabaseRow();
                Row.VirusName = Names[i];
                Row.GenomeId = Guid.Parse(GenomeIds[i]);

                var number = DeathRates[i].Split('.');
                if (number.Length == 1) Row.DeathRate = Convert.ToDouble(number[0]);
                else Row.DeathRate = Convert.ToDouble(number[0]) + Convert.ToDouble(number[1]) / Math.Pow(10, number[1].Length);

                number = InfectionRates[i].Split('.');
                if (number.Length == 1) Row.InfectionRate = Convert.ToDouble(number[0]);
                else Row.InfectionRate = Convert.ToDouble(number[0]) + Convert.ToDouble(number[1]) / Math.Pow(10, number[1].Length);
                virusDatas.Add(Row);
            }
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
