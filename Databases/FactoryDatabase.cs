using System;
using System.Collections.Generic;
using System.Text;

namespace Task3
{
    public class FactoryDatabase
    {
        public IVirusDatabaseIterator GetIterator(SimpleDatabase database, IGenomeCollection search)
            => new SimpleDatabaseIterator(database, search);
        public IVirusDatabaseIterator GetIterator(ExcellDatabase database, IGenomeCollection search)
            => new ExcellDatabaseIterator(database, search);
        public IVirusDatabaseIterator GetIterator(OvercomplicatedDatabase database, IGenomeCollection search)
            => new OvercomplicatedDatabaseIterator(database, search);

        public IGenomeCollection GetGenomeCollection(SimpleGenomeDatabase database)
            => new SimpleGenomeCollection(database);
    }
}
