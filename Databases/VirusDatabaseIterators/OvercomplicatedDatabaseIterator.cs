#nullable enable
using System;
using System.Collections.Generic;
using System.Text;

namespace Task3
{
    internal class OvercomplicatedDatabaseIterator : IVirusDatabaseIterator
    {
        private string currentGenomeTag;
        private readonly Stack<INode> nodeStack = new Stack<INode>();
        public OvercomplicatedDatabaseIterator(OvercomplicatedDatabase database)
        {
            nodeStack.Push(database.Root);
            currentGenomeTag = database.Root.GenomeTag;
        }

        public VirusData? Next()
        {
            if (nodeStack.Count != 0)
            {
                var currentNode = nodeStack.Pop();
                var childNodes = currentNode.Children;
                foreach (var Node in childNodes)
                {
                    nodeStack.Push(Node);
                }
                var virus = new VirusData(currentNode.VirusName, currentNode.DeathRate, currentNode.InfectionRate, null);
                currentGenomeTag = currentNode.GenomeTag;
                return virus;
            }
            else
            {
                return null;
            }
        }

        public List<GenomeData>? FindMatchingGenomes(IGenomeCollection collection) => collection.GetGenomeDatas(currentGenomeTag);
    }
}
