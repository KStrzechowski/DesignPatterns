using System;
using System.Collections.Generic;
using System.Text;

namespace Task3
{
    internal class FilterDeathRateGreater : IFilter
    {
        protected readonly double value;
        public FilterDeathRateGreater(double value)
        {
            this.value = value;
        }

        public bool Filter(VirusData virus)
        {
            return virus.DeathRate > value;
        }
    }

    internal class FilterDeathRateLess : IFilter
    {
        protected readonly double value;
        public FilterDeathRateLess(double value)
        {
            this.value = value;
        }

        public bool Filter(VirusData virus)
        {
            return virus.DeathRate < value;
        }
    }

    internal class FilterDeathRateEquals : IFilter
    {
        protected readonly double value;
        public FilterDeathRateEquals(double value)
        {
            this.value = value;
        }

        public bool Filter(VirusData virus)
        {
            return virus.DeathRate == value;
        }
    }
}
