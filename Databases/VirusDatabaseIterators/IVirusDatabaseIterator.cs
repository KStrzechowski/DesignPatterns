#nullable enable
using System;
using System.Collections.Generic;
using System.Text;

namespace Task3
{
    public interface IVirusInfoDatabaseIterator
    {
        VirusInfo? Next();
    }

    public interface IVirusDatabaseIterator
    {
        VirusData? Next();
    }
}
