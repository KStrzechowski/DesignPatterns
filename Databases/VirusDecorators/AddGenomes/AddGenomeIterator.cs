#nullable enable
using System;
using System.Collections.Generic;
using System.Text;

namespace Task3
{
    class AddGenomesIterator : BaseVirusIteratorDecorator
    {
        private readonly IGenomeCollection collection;
        public AddGenomesIterator(IVirusDatabaseIterator it, IGenomeCollection collection) : base(it)
        {
            this.collection = collection;
        }

        public override VirusData? Next()
        {
            var virus = base.Next();
            if (virus != null)
            {
                return new VirusData(virus.VirusName, virus.DeathRate, virus.InfectionRate, inner.FindMatchingGenomes(collection));
            }
            else
            {
                return null;
            }
        }
    }
}
