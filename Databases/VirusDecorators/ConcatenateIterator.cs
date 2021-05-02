using System;
using System.Collections.Generic;
using System.Text;

namespace Task3
{
    internal class ConcatenateIterator : BaseVirusIteratorDecorator
    {
        private readonly IVirusDatabaseIterator it2;
        public ConcatenateIterator(IVirusDatabaseIterator it1, IVirusDatabaseIterator it2) : base(it1)
        {
            this.it2 = it2;
        }

        public override VirusData? Next()
        {
            var virus = base.Next();
            if (virus == null)
                virus = it2.Next();
            return virus;
        }
    }
}
