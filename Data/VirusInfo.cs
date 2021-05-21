using System;
using System.Collections.Generic;
using System.Text;
#nullable enable

namespace Task3
{
    public class VirusInfo
    {
        public string VirusName { get; private set; }
        public double DeathRate { get; private set; }
        public double InfectionRate { get; private set; }
        public Guid? GenomeId { get; private set; }
        public string? GenomeTag { get; private set; }

        public VirusInfo(string name, double deathRate, double infectionRate, string genomeTag)
        {
            VirusName = name;
            DeathRate = deathRate;
            InfectionRate = infectionRate;
            GenomeId = null;
            GenomeTag = genomeTag;
        }

        public VirusInfo(string name, double deathRate, double infectionRate, Guid genomeId)
        {
            VirusName = name;
            DeathRate = deathRate;
            InfectionRate = infectionRate;
            GenomeId = genomeId;
            GenomeTag = null;
        }
    }
}
