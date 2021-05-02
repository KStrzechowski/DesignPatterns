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

  /*  public abstract class IteratorTransformingDecorator : BaseVirusIteratorDecorator
    {
        public IteratorTransformingDecorator(IVirusDatabaseIterator inner): base(inner)
        {
        }

        public override VirusData? Next()
        {
            var virus = base.Next();
            if (virus == null) return null;
            else return Transform(virus);
        }

        protected abstract VirusData Transform(VirusData virus);
    }*/
}
