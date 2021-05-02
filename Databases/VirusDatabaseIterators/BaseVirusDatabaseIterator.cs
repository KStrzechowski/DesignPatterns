#nullable enable
using System;
using System.Collections.Generic;
using System.Text;

namespace Task3
{
    internal abstract class BaseVirusDatabaseIterator : IVirusDatabaseIterator
    {
        public abstract VirusData? Next();
        public abstract List<GenomeData>? FindMatchingGenomes();
    }
}
