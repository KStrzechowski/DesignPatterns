using System;
using System.Collections.Generic;
using System.Text;

namespace Task3
{
    internal abstract class BaseFilter : IFilter
    {
        protected readonly double value;
        public BaseFilter(double value)
        {
            this.value = value;
        }
        public abstract bool Filter(VirusData virus);
    }
}
