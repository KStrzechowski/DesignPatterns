#nullable enable
using System;
using System.Collections.Generic;
using System.Text;

namespace Task3
{
    internal class OvercomplicatedDatabaseIterator : IVirusInfoDatabaseIterator
    {
        private readonly Stack<INode> nodeStack = new Stack<INode>();
        public OvercomplicatedDatabaseIterator(OvercomplicatedDatabase database)
        {
            nodeStack.Push(database.Root);
        }

        public VirusInfo? Next()
        {
            if (nodeStack.Count != 0)
            {
                var currentNode = nodeStack.Pop();
                var childNodes = currentNode.Children;
                foreach (var Node in childNodes)
                {
                    nodeStack.Push(Node);
                }
                var virusInfo = new VirusInfo(currentNode.VirusName, currentNode.DeathRate, 
                    currentNode.InfectionRate, currentNode.GenomeTag);
                return virusInfo;
            }
            else
            {
                return null;
            }
        }
    }
}
