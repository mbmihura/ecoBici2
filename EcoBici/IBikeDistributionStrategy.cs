using System;

namespace EcoBici
{
    public interface IBikeDistributionStrategy
    {
        TimeSpan[][] Distribute(int amountOfBicycles, int amountOfStations);
    }
}
