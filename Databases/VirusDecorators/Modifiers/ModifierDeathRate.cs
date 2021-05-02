using System;
using System.Collections.Generic;
using System.Text;

namespace Task3
{
    internal class ModifierDeathRate : BaseModifier
    {
        public ModifierDeathRate(double value) : base(value)
        {
        }

        public override VirusData Modify(VirusData virus)
        {
            return new VirusData(virus.VirusName, virus.DeathRate + value, virus.InfectionRate, virus.Genomes);
        }
    }
}
