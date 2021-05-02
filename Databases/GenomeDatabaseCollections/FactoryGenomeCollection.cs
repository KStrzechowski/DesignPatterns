using System;
using System.Collections.Generic;
using System.Text;

namespace Task3
{
    public class FactoryGenomeCollection
    {
        public IGenomeCollection GetGenomeCollection(SimpleGenomeDatabase database) 
            => new SimpleGenomeCollection(database);
    }
}
