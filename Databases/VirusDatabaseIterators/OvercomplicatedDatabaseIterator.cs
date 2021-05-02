#nullable enable
using System;
using System.Collections.Generic;
using System.Text;

namespace Task3
{
    internal class OvercomplicatedDatabaseIterator : BaseVirusDatabaseIterator
    {
        private readonly Queue<INode> nodeQueue = new Queue<INode>();
        private readonly IGenomeCollection genomeCollection;
        public OvercomplicatedDatabaseIterator(OvercomplicatedDatabase database, IGenomeCollection genomeCollection)
        {
            this.genomeCollection = genomeCollection;
            nodeQueue.Enqueue(database.Root);

        }

        public override VirusData? Next()
        {
            if (nodeQueue.Count != 0)
            {
                var genomList = FindMatchingGenomes();
                var currentNode = nodeQueue.Dequeue();
                var childNodes = currentNode.Children;
                foreach (var Node in childNodes)
                {
                    nodeQueue.Enqueue(Node);
                }
                var virus = new VirusData(currentNode.VirusName, currentNode.DeathRate, currentNode.InfectionRate, genomList);
                return virus;
            }
            else
            {
                return null;
            }
        }

        public override List<GenomeData>? FindMatchingGenomes()
        {
            var genomeList = genomeCollection.GetGenomeDatas();
            var currentNodeTag = nodeQueue.Peek().GenomeTag;
            var matchingGenomes = new List<GenomeData>();

            foreach (var genome in genomeList)
            {
                foreach (var tag in genome.Tags)
                {
                    if (currentNodeTag == tag)
                    {
                        matchingGenomes.Add(genome);
                        break;
                    }
                }
            }
            return matchingGenomes;
        }
    }
}
