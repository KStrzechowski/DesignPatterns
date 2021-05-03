using System;
using System.Collections.Generic;
using System.Text;

namespace Task3
{
    internal class FilterDeathRateGreater : BaseFilter
    {
        public FilterDeathRateGreater(double value) : base(value)
        {
        }

        public override bool Filter(VirusData virus)
        {
            return virus.DeathRate > value;
        }
    }

    internal class FilterDeathRateLess : BaseFilter
    {
        public FilterDeathRateLess(double value) : base(value)
        {
        }

        public override bool Filter(VirusData virus)
        {
            return virus.DeathRate < value;
        }
    }

    internal class FilterDeathRateEquals : BaseFilter
    {
        public FilterDeathRateEquals(double value) : base(value)
        {
        }

        public override bool Filter(VirusData virus)
        {
            return virus.DeathRate == value;
        }
    }
}
