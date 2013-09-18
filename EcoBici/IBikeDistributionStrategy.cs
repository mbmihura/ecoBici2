using System;

namespace EcoBici
{
    public interface IBikeDistributionStrategy
    {
        TimeSpan[][] Distribute(int amountOfStations, int amountOfBicycles);
    }
}
