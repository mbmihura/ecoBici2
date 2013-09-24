using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoBici
{
    class MockVA : IfdpManager
    {
        Random rnd = new Random();
        int lstEstationId;
        int minTravelTime;
        int maxTravelTime;
        int maxInvervalBetweenArrivals;

        public MockVA(int estationsAmount, int minTVminutes,int maxTVminutes,int maxTPLLminutes)
        {
            lstEstationId = estationsAmount - 1;
            minTravelTime = minTVminutes;
            maxTravelTime = maxTVminutes;
            maxInvervalBetweenArrivals = maxTPLLminutes;
        }
        public int ExcuteIA(int idStation)
        {
            return rnd.Next(0, maxInvervalBetweenArrivals);
        }
        public int ExcuteED(int idStation)
        {
            return rnd.Next(0, lstEstationId);
        }
        public int ExcuteTV(int idOriginStation, int idDestinationStation)
        {
            return rnd.Next(minTravelTime, maxInvervalBetweenArrivals);
        }
        public void Start()
        {
        }

        public void Stop()
        {
        }
    }
}
