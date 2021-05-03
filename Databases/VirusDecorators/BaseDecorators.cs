#nullable enable
using System;
using System.Collections.Generic;
using System.Text;

namespace Task3
{
    public abstract class BaseVirusDecorator
    {
        private readonly VirusData inner;
        public BaseVirusDecorator(VirusData inner)
        {
            this.inner = inner;
        }

        public BaseVirusDecorator(string virusName, double deathRate, double infectionRate, IReadOnlyList<GenomeData> genomes)
        {
            this.inner = new VirusData(virusName, deathRate, infectionRate, genomes);
        }

        public VirusData GetVirusData() => inner;
    }

    public class BaseVirusIteratorDecorator : IVirusDatabaseIterator
    {
        private readonly IVirusDatabaseIterator inner;
        public BaseVirusIteratorDecorator(IVirusDatabaseIterator inner)
        {
            this.inner = inner;
        }

        public virtual VirusData? Next() => inner.Next();
    }
}
