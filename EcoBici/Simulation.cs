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
        
        public ResultSet Run()
        {
            TimeSpan T;
            int e;
            int d;
            int b;
            TimeSpan minTC;
            TimeSpan tv;
            TimeSpan espera;
            int TPS = 0;
            TimeSpan SUB = new TimeSpan(0);
            TimeSpan SEC = new TimeSpan(0);
            TimeSpan[] TMEC = new TimeSpan[amountOfStations];
            TimeSpan[] PMSB = new TimeSpan[amountOfStations];
            for (int p = 0; p < PMSB.Length; ++p)
                PMSB[p] = HV;

            Log.HV = this.HV;
            Log.BikesAmount = this.amountOfBicycles;
            Log.setColumnNumbers();
            Log log;
            do
            {
                log = new Log();
                log.SetState(TC);

                // Move Time to the next arrival to be process
                e = min(TPLL);
                T = TPLL[e];

                // Set next arrival for current station
                TPLL[e] = T + IA(e);

                // Calcula trips destination and duration.
                d = ED(e);
                tv = TV(e, d);
                
                // Serch sooner available bike
                b = min(TC[e]);
                minTC = TC[e][b];

                // Mark bike as used in origin station
                TC[e][b] = HV;

                if (T < minTC)
                {
                    // NO Bikes available now...
                    if (minTC < HV)
                    {
                        // No more bikes at the moments... (wait + trip)

                        // Set bike's new commitment time in destination station
                        TC[d][b] = minTC + tv;
                        log.SetTCAnt(minTC);

                        // Add wait to system's accumulated wait
                        espera = minTC - T;
                        SEC = SEC + espera;

                        // Save maximum wait
                        if (TMEC[e] < espera)
                            TMEC[e] = espera;

                        // Save first moment without bikes
                        if (PMSB[e] == HV)
                            PMSB[e] = T;

                        // Add travel time to system's accumulated travel time
                        SUB = SUB + tv;
                    } 
                    else
                    {
                        // No bikes until end of day... (wait)

                        // Add wait to system's accumulated wait
                        espera = (Tf - T);
                        SEC = SEC + espera;

                        // Save maximum wait
                        if (TMEC[e] < espera)
                            TMEC[e] = espera;

                        // Save first moment without bikes
                        if (PMSB[e] == HV)
                            PMSB[e] = T;
                    }
                }
                else {
                    // Bike available now... (trip)

                    // Set bike's new commitment time in destination station
                    TC[d][b] = T + tv;
                    log.SetT(T);

                    // Add travel time to system's accumulated travel time
                    SUB = SUB + tv;
                }
                // Add process person to person count.
                TPS = TPS + 1;
                
                log.WriteState(T, e, TPLL, d, b, TC[d][b]);
            } while ( T < Tf);

            #region results calculation
            var results = new ResultSet();

            // % uso de bicicles:
            results.PUB = SUB.TotalMinutes / (Ti - Tf).TotalMinutes * amountOfBicycles;

            // 1er momento sin bicis (por estacion):
            results.PMSB = PMSB;

            // Promedio Espera en cola:
            results.PEC = TimeSpan.FromMinutes(SEC.TotalMinutes / TPS);

            // Tiempo max. espera (por estacion):
            results.TMEC = TMEC;

            #endregion

            #region results calculation
            log.WriteLine("");
            log.WriteLine("Porc uso bicicletas: " + results.PUB);
            log.WriteLine("Promedio Espera en cola: " + results.PEC);
            log.WriteLine("1er momento sin bicis (por estacion): ");
            for(int p = 0; p < results.PMSB.Length ; ++p)
                log.WriteLine(p + ": " + results.PMSB[p]);

            log.WriteLine("Tiempo max. espera (por estacion): ");
            for (int p = 0; p < results.TMEC.Length; ++p)
                log.WriteLine(p + ": " + results.TMEC[p]);

            #endregion

            return results;
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
