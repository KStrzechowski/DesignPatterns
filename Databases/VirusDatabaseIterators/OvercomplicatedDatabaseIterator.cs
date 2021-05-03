#nullable enable
using System;
using System.Collections.Generic;
using System.Text;

namespace Task3
{
    internal class OvercomplicatedDatabaseIterator : BaseVirusDatabaseIterator
    {
        private readonly Stack<INode> nodeQueue = new Stack<INode>();
        public OvercomplicatedDatabaseIterator(OvercomplicatedDatabase database, IGenomeCollection genomeCollection) : base(genomeCollection)
        {
            nodeQueue.Push(database.Root);
        }

        public override VirusData? Next()
        {
            if (nodeQueue.Count != 0)
            {
                var genomList = FindMatchingGenomes();
                var currentNode = nodeQueue.Pop();
                var childNodes = currentNode.Children;
                foreach (var Node in childNodes)
                {
                    nodeQueue.Push(Node);
                }
                var virus = new VirusData(currentNode.VirusName, currentNode.DeathRate, currentNode.InfectionRate, genomList);
                return virus;
            }
            else
            {
                return null;
            }
        }

        public override bool CheckCurrentGenome(GenomeData genome)
        {
            var currentNodeTag = nodeQueue.Peek().GenomeTag;
            foreach (var tag in genome.Tags)
            {
                if (currentNodeTag == tag)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
