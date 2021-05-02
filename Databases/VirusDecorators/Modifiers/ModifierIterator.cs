#nullable enable
using System;
using System.Collections.Generic;
using System.Text;

namespace Task3
{
    internal class ModifierIterator : BaseVirusIteratorDecorator
    {
        private readonly IModifier modifier;
        public ModifierIterator(IVirusDatabaseIterator it, IModifier modifier) : base(it)
        {
            this.modifier = modifier;
        }

        public override VirusData? Next()
        {
            var virus = base.Next();
            if (virus == null) return null; 
            else return modifier.Modify(virus);
        }
    }
}
