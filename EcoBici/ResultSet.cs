using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EcoBici
{
    public class ResultSet
    {
        /// <summary>Porcentaje de uso total de las bicicletas del sistema.</summary>
        public decimal PUTBS {set; get;}

        /// <summary>Primer momento en que la estación no tuvo bicicletas.</summary>
        public TimeSpan[] PMENB { set; get; }

        /// <summary>Promedio de espera en cola.</summary>
        public TimeSpan PEC { set; get; }
    }
}
