using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoBici
{
    public class Simulation
    {
        TimeSpan[][] TC;
        TimeSpan[] TPLL;
        
        TimeSpan Ti;
        TimeSpan Tf;
        TimeSpan HV;
        int amountOfBicycles;
        int amountOfStations;
        IBikeDistributionStrategy distributionStrategy;
        IIAInitalizeStrategy iAInitStrategy;
        DataWarehouseManager dwm;

        public Simulation(int amountOfBicycles, int amountOfStations, UniformDistribution distributionStrategy, TimeSpan Tf)
            : this(amountOfBicycles, amountOfStations, distributionStrategy, Tf, new TimeSpan(0))
        {}

        public Simulation(int amountOfBicycles, int amountOfStations, IBikeDistributionStrategy distributionStrategy, TimeSpan Tf, TimeSpan Ti)
        {
            this.Ti = Ti;
            this.Tf = Tf;
            this.HV = Tf - Ti + new TimeSpan(24, 0, 0);
            this.amountOfBicycles = amountOfBicycles;
            this.amountOfStations = amountOfStations;
            this.distributionStrategy = distributionStrategy;
            this.iAInitStrategy = new ArrivalsAtSimulationInitStrategy();

            // Set initial bikes distribution and TPLL;
            TPLL = iAInitStrategy.getSimulationInitialTPLL(amountOfStations, Ti);
            TC = distributionStrategy.Distribute(amountOfStations, amountOfBicycles, Ti, HV);

            dwm = new DataWarehouseManager();
        }
        
        public void Run()
        {
            TimeSpan T;
            int e;
            int d;
            int b;
            TimeSpan tv;

            do
            {
                e = min(TPLL);
                T = TPLL[e];

                TPLL[e] = T + IA(e);

                d = ED(e);
                tv = TV(e, d);

                b = min(TC[e]);

                if (T < TC[e][b])
                {
                    // No more bikes
                    TC[e][b] = TC[e][b] + tv;
                    TC[d][b] = HV;
 
                }
                else {
                    // Bike available
                    TC[e][b] = HV;
                    TC[d][b] = T + tv;              
                }
            } while ( T > Tf);
            
            // TODO: calc results.

            // TODO: print results.
        }

        /// <summary>
        /// Gets the index of the minimum element in the array.
        /// </summary>
        /// <param name="array">TimeSpan array in which to search for the minimum value.</param>
        /// <exception cref="System.OverflowException">The array is multidimensional and contains more than System.Int32.MaxValue elements.</exception>
        /// <exception cref="System.IndexOutOfRangeException">The array length should be at least 1.</exception>
        /// <returns>Index of the minimum element in the array.</returns>
        private int min(TimeSpan[] array)
        {
            int minIndex = 0; TimeSpan minValue = array[0];
            for (int e = 1; e < array.Length; e++)
            {
                if (array[e] < minValue)
                {
                    minValue = array[e];
                    minIndex = e;
                }
            }
            return minIndex;
        }
        /// <summary>
        /// Arrivals intervals stochastic variable of a specific station in the system. 
        /// </summary>
        /// <param name="idStation">Station's id for which to get the interval between arrivals.</param>
        /// <returns>A time interval of set of possible different values. Each of the timespans returned are subject to a probability which varies from station to station.</returns>
        public TimeSpan IA(int idStation)
        {
            return new TimeSpan(0, dwm.ExcuteIA(idStation), 0);
        }

        /// <summary>
        /// Destination station's id stochastic variable. 
        /// </summary>
        /// <param name="idStation">Origin station's id from where the bycicle's is before the trip.</param>
        /// <returns>A destination station's id of set of possible destination stations for the origin station's id. Each of the destination stations' ids returned are subject to a probability which varies from one origin station to another one.</returns>
        public int ED(int idStation)
        {
            return dwm.ExcuteED(idStation);
        }

        /// <summary>
        /// Travel time stochastic variable. 
        /// </summary>
        /// <param name="idOrigin">Origin station's id where the bycicle's is before the trip.</param>
        /// <param name="idDestination">Destination station's id where the bycicle's is after the trip.</param>
        /// <returns>A time interval of the set of possible travel time intervals that a bicycle needed to travel from origin station to the destination station. Each of the time intervals returned are subject to a probability which varies from one pair of origin-destination station to another one.</returns>
        private TimeSpan TV(int idOrigin, int idDestination)
        {
            return new TimeSpan(0, dwm.ExcuteTV(idOrigin,idDestination), 0);
        }
    }
}
