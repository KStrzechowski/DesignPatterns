using System;
using System.Collections.Generic;
using System.Text;

namespace Task3
{
    internal class SimpleGenomeCollection : IGenomeCollection
    {
        private readonly List<GenomeData> genomeDatas;
        public SimpleGenomeCollection(SimpleGenomeDatabase database)
        {
            this.genomeDatas = database.genomeDatas;
        }

        public List<GenomeData> GetGenomeDatas(Guid genomeId)
        {
            var genomeList = new List<GenomeData>();
            foreach (var genome in genomeDatas)
            {
                if (genome.Id == genomeId)
                {
                    genomeList.Add(genome);
                    break;
                }
            }
            return genomeList;
        }

        public List<GenomeData> GetGenomeDatas(string virusGenomeTag)
        {
            var genomeList = new List<GenomeData>();
            foreach (var genome in genomeDatas)
            {
                foreach (var Tag in genome.Tags)
                {
                    if (Tag == virusGenomeTag)
                    {
                        genomeList.Add(genome);
                        break;
                    }
                }
            }
            return genomeList;
        }
    }
}
