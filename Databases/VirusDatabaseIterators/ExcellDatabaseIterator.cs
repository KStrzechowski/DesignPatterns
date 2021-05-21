#nullable enable
using System;
using System.Collections.Generic;
using System.Text;

namespace Task3
{
    internal class ExcellDatabaseIterator : IVirusInfoDatabaseIterator
    {
        private int nameIndex = 0;
        private int deathRateIndex = 0;
        private int infectionRateIndex = 0;
        private int genomeIdIndex = 0;
        private bool isEmpty = false;

        private readonly ExcellDatabase database;
        public ExcellDatabaseIterator(ExcellDatabase database)
        {
            this.database = database;
        }

        public VirusInfo? Next()
        {
            if (!isEmpty)
            {
                string Info;
                (Info, nameIndex) = RetrieveNextString(database.Names, nameIndex);
                var virusName = Info;

                (Info, deathRateIndex) = RetrieveNextString(database.DeathRates, deathRateIndex);
                var deathRate = RetrieveNumber(Info);

                (Info, infectionRateIndex) = RetrieveNextString(database.InfectionRates, infectionRateIndex);
                var infectionRate = RetrieveNumber(Info);

                (Info, genomeIdIndex) = RetrieveNextString(database.GenomeIds, genomeIdIndex);
                var genomeId = Guid.Parse(Info);

                var virusInfo = new VirusInfo(virusName, deathRate, infectionRate, genomeId);
                return virusInfo;
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
            if (endIndex != -1) retrievedData = data[startingIndex..endIndex]; 
            else
            {
                retrievedData = data[startingIndex..];
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
    }
}