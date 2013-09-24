using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EcoBici
{
    interface IfdpManager
    {
        void Start();

        int ExcuteIA(int idStation);

        int ExcuteED(int idStation);

        int ExcuteTV(int idOrigin, int idDestination);

        void Stop();
    }
}
