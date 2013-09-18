using System;
namespace EcoBici
{
    interface IBikeDistributionStrategy
    {
        TimeSpan[][] Distribute(int amountOfBicycles, int amountOfStations);
    }
}
