using System;
using System.Collections.Generic;
using System.Text;

namespace Task3
{
    internal class ModifierDeathRate : IModifier
    {
        private readonly double value;
        public ModifierDeathRate(double value)
        {
            this.value = value;
        }

        public VirusData Modify(VirusData virus)
        {
            return new VirusData(virus.VirusName, virus.DeathRate + value, virus.InfectionRate, virus.Genomes);
        }
    }
}
