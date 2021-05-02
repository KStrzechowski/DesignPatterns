using System;
using System.Collections.Generic;
using System.Text;

namespace Task3
{
    public class VisitorTransform : IteratorTransformingDecorator
    {
        private readonly IVirusTransform transform;
        public VisitorTransform(IVirusDatabaseIterator inner, IVirusTransform transform) : base(inner)
        {
            this.transform = transform;
        }

        protected override VirusData Transform(VirusData virus) => transform.Transform(virus);
    }

    public interface IVirusTransform
    {
        public VirusData Transform(VirusData virus);
    }

}
