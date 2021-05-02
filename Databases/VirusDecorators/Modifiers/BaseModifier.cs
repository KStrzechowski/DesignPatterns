using System;
using System.Collections.Generic;
using System.Text;

namespace Task3
{
    internal abstract class BaseModifier : IModifier
    {
        protected readonly double value;
        public BaseModifier(double value)
        {
            this.value = value;
        }
        public abstract VirusData Modify(VirusData virus);
    }
}
