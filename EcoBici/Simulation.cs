using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoBici
{
    public class Simulation
    {
        internal byte?[,] matriz;

        public Simulation(int amountOfBicycles, int amountOfStations)
        {
            matriz = new byte?[amountOfStations, amountOfBicycles];

            //Bicycles distribution stategy:

            // TODO: If needed, improve performance by precomputing
            Action a = () =>
            {
                int remainingBikes = amountOfBicycles;
                for (int bic = 0; bic < matriz.GetLength(1); ++bic)
                {
                    for (int est = 0; est < matriz.GetLength(0); ++est)
                    {
                        matriz[est, bic] = 0;
                        if (--remainingBikes == 0)
                            return;
                    }
                }
            };
        }
        
        public void Run()
        {

        }
    }
}
