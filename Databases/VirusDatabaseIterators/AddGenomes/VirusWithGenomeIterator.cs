#nullable enable
using System;
using System.Collections.Generic;
using System.Text;

namespace Task3
{
    class VirusWithGenomeIterator : IVirusDatabaseIterator
    {
        private readonly IGenomeCollection? collection;
        private readonly IVirusInfoDatabaseIterator it;
        public VirusWithGenomeIterator(IVirusInfoDatabaseIterator it, IGenomeCollection? collection = null)
        {
            this.collection = collection;
            this.it = it;
        }

        public VirusData? Next()
        {
            var virusInfo = it.Next();
            
            if (virusInfo != null && collection != null)
            {
                if (virusInfo.GenomeId != null)
                {
                    return new VirusData(virusInfo.VirusName, virusInfo.DeathRate,
                        virusInfo.InfectionRate, collection.GetGenomeDatas((Guid)virusInfo.GenomeId));
                }
                else
                {
                    return new VirusData(virusInfo.VirusName, virusInfo.DeathRate,
                        virusInfo.InfectionRate, collection.GetGenomeDatas(virusInfo.GenomeTag));
                }
                
            }
            else if (virusInfo != null)
            {
                return new VirusData(virusInfo.VirusName, virusInfo.DeathRate, virusInfo.InfectionRate, null);
            }
            else
            {
                return null;
            }
        }
    }
}
