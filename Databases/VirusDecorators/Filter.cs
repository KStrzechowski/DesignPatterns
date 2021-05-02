using System;
using System.Collections.Generic;
using System.Text;

namespace Task3
{
    internal abstract class FilterIterator : BaseIteratorDecorator
    {
        public FilterIterator(IVirusDatabaseIterator it) : base(it)
        {
        }
    }
}
