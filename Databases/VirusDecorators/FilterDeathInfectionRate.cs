using System;
using System.Collections.Generic;
using System.Text;

namespace Task3
{
    public delegate bool CompareDelegate<T>(T item);

    internal class FilterCompareIterator : FilterIterator
    {
        private readonly CompareDelegate<VirusData> filter;
        public FilterCompareIterator(IVirusDatabaseIterator it, CompareDelegate<VirusData> filter) : base(it)
        {
            this.filter = filter;
        }

        public override VirusData Next()
        {
            var virus = base.Next();
            while (virus != null && !filter(virus))
            {
                virus = base.Next();
            }
            return virus;
        }
    }
}
