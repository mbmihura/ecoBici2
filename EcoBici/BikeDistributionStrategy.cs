using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EcoBici
{
    public class UniformDistribution : EcoBici.IBikeDistributionStrategy
    {
        public TimeSpan[][] Distribute(int amountOfStations, int amountOfBicycles, TimeSpan Ti, TimeSpan HV)
        {

            TimeSpan[][] dist = new TimeSpan[amountOfStations][];

            int bikesPerStation = amountOfBicycles / amountOfStations;
            int bikesRemainder = amountOfBicycles % amountOfStations;

            int b;
            int lowerIncludedBound = 0;
            int upperExcludedBound = 0;

            for (int e = 0; e < amountOfStations; e++)
            {
                lowerIncludedBound = upperExcludedBound;
                upperExcludedBound += bikesPerStation + (bikesRemainder-- > 0 ? 1 : 0);
                dist[e] = new TimeSpan[amountOfBicycles];
                
                for (b = 0; b < lowerIncludedBound; b++)
                {
                    dist[e][b] = HV;
                }
                for (b = lowerIncludedBound; b < upperExcludedBound; b++)
                {
                    dist[e][b] = Ti;
                }
                for (b = upperExcludedBound; b < amountOfBicycles; b++)
                {
                    dist[e][b] = HV;
                }
            }
            return dist;
        }
    }
}
