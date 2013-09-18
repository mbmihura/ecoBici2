using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EcoBici
{
    /// <summary>A TPLL's factory implementation: Generates TPLL TimeSpan arrays which are load all with the same value.</summary>
    public class ArrivalsAtSimulationInitStrategy : EcoBici.IIAInitalizeStrategy
    {
        /// <summary>
        /// Generates a TPLL array
        /// </summary>
        /// <param name="numberOfInputs">Amount of inputs (and length of the generated Array).</param>
        /// <param name="simulationTi">Value used to load the TPLL array.</param>
        /// <returns></returns>
        public TimeSpan[] getSimulationInitialTPLL(int numberOfInputs, TimeSpan simulationTi)
        {
            // Loop through the array and set each i element with the simulationTi value.
            TimeSpan[] initTPLL = new TimeSpan[numberOfInputs];
            for (int i = 0; i < numberOfInputs; i++)
                initTPLL[i] = simulationTi;
            return initTPLL;
        }
    }
}
