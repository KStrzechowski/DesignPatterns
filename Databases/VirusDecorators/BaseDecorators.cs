#nullable enable
using System;
using System.Collections.Generic;
using System.Text;

namespace Task3
{
    public abstract class BaseVirusIteratorDecorator : IVirusDatabaseIterator
    {
        protected readonly IVirusDatabaseIterator inner;
        public BaseVirusIteratorDecorator(IVirusDatabaseIterator inner)
        {
            this.inner = inner;
        }

        public virtual VirusData? Next() => inner.Next();
    }
}
