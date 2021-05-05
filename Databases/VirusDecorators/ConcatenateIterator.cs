#nullable enable
using System;
using System.Collections.Generic;
using System.Text;

namespace Task3
{
    internal class ConcatenateIterator : BaseVirusIteratorDecorator
    {
        private readonly IVirusDatabaseIterator it2;
        private bool isFirstIteratorEmpty = false;
        public ConcatenateIterator(IVirusDatabaseIterator it1, IVirusDatabaseIterator it2) : base(it1)
        {
            this.it2 = it2;
        }

        public override VirusData? Next()
        {
            var virus = base.Next();
            if (virus == null)
            {
                isFirstIteratorEmpty = true;
                virus = it2.Next();
            }
            return virus;
        }

        public override List<GenomeData>? FindMatchingGenomes(IGenomeCollection collection)
        {
            if (!isFirstIteratorEmpty)
                return inner.FindMatchingGenomes(collection);
            else
                return it2.FindMatchingGenomes(collection);
        }
    }
}
