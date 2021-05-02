using System;
using System.Collections.Generic;
using System.Text;

namespace Task3
{
    public class ModifiyTransform : IVirusTransform
    {
        private readonly double deathRateModifier;
        private readonly double infectionRateModifier;
        public ModifiyTransform(double deathRateModifier = 0, double infectionRateModifier = 0)
        {
            this.deathRateModifier = deathRateModifier;
            this.infectionRateModifier = infectionRateModifier;
        }
        public VirusData Transform(VirusData virus) => new ModifyVirusTransform(virus, deathRateModifier, infectionRateModifier).GetVirusData();
    }

    internal class ModifyVirusTransform : BaseVirusDecorator
    {
        public ModifyVirusTransform(VirusData virus, double deathRateModifier = 0, double infectionRateModifier = 0) :
            base(virus.VirusName, virus.DeathRate + deathRateModifier, virus.InfectionRate + infectionRateModifier, virus.Genomes)
        { 
        }
    }
}
