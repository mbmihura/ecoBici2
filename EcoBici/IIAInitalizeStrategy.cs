using System;

namespace EcoBici
{
    /// <summary>TPLL Factories Interface: Classes which implement these interface should be able to generate TPLL TimeSpan arrays.</summary>
    public interface IIAInitalizeStrategy
    {
        TimeSpan[] getSimulationInitialTPLL(int numberOfInputs, TimeSpan simulationTi);
    }
}
