#nullable enable
using System;
using System.Collections.Generic;
using System.Text;

namespace Task3
{
    internal class ExcellDatabaseIterator : IVirusDatabaseIterator
    {
        private int nameIndex = 0;
        private int deathRateIndex = 0;
        private int infectionRateIndex = 0;
        private int genomeIdIndex = 0;
        private bool isEmpty = false;

        private Guid currentGenomeId;
        private readonly ExcellDatabase database;
        public ExcellDatabaseIterator(ExcellDatabase database)
        {
            this.database = database;
        }

        public VirusData? Next()
        {
            if (!isEmpty)
            {
                string virusName, Info;
                double deathRate, infectionRate;
                (virusName, nameIndex) = RetrieveNextString(database.Names, nameIndex);

                (Info, deathRateIndex) = RetrieveNextString(database.DeathRates, deathRateIndex);
                deathRate = RetrieveNumber(Info);

                (Info, infectionRateIndex) = RetrieveNextString(database.InfectionRates, infectionRateIndex);
                infectionRate = RetrieveNumber(Info);

                (Info, genomeIdIndex) = RetrieveNextString(database.GenomeIds, genomeIdIndex);
                currentGenomeId = Guid.Parse(Info);

                var virus = new VirusData(virusName, deathRate, infectionRate, null);
                return virus;
            }
            else
            {
                return null;
            }
        }

        private (string, int) RetrieveNextString(string data, int startingIndex)
        {
            string retrievedData;
            int endIndex = data.IndexOf(';', startingIndex);
            if (endIndex != -1) retrievedData = data.Substring(startingIndex, endIndex - startingIndex); 
            else
            {
                retrievedData = data.Substring(startingIndex);
                isEmpty = true;
            }

            return (retrievedData, endIndex + 1);
        }

        private double RetrieveNumber(string data)
        {
            double sum;
            var number = data.Split('.');
            if (number.Length == 1) sum = Convert.ToDouble(number[0]);
            else sum = Convert.ToDouble(number[0]) + Convert.ToDouble(number[1]) / Math.Pow(10, number[1].Length);
            return sum;
        }

        public List<GenomeData>? FindMatchingGenomes(IGenomeCollection collection) => collection.GetGenomeDatas(currentGenomeId);
    }
}