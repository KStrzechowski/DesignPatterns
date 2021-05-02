#nullable enable
using System;
using System.Collections.Generic;
using System.Text;

namespace Task3
{
    internal class FilterIterator : BaseVirusIteratorDecorator
    {
        private readonly IFilter filter;
        public FilterIterator(IVirusDatabaseIterator it, IFilter filter) : base(it)
        {
            this.filter = filter;
        }

        public override VirusData? Next()
        {
            var virus = base.Next();
            while (virus != null && !filter.Filter(virus))
            {
                virus = base.Next();
            }
            return virus;
        }
    }
}
