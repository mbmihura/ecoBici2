using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EcoBici
{
    public class ResultSet
    {
        public ResultSet()
        {
            SUB = new List<Tuple<TimeSpan,TimeSpan>>();
            SEC = new List<Tuple<TimeSpan,TimeSpan>>();
        }

        /// <summary>Porcentaje de uso total de las bicicletas del sistema.</summary>
        public double PUB {set; get;}

        /// <summary>Primer momento en que la estación no tuvo bicicletas (por estacion).</summary>
        public TimeSpan[] PMSB { set; get; }

        /// <summary>Promedio de espera en cola.</summary>
        public TimeSpan PEC { set; get; }

        /// <summary> Tiempo maximo espera en cola (por estacion).<summary>
        public TimeSpan[] TMEC { get; set; }

        /// <summary> Tiempo maximo espera en cola (por estacion).<summary>
        public List<Tuple<TimeSpan,TimeSpan>> SUB { get; set; }

        /// <summary> Tiempo maximo espera en cola (por estacion).<summary>
        public List<Tuple<TimeSpan, TimeSpan>> SEC { get; set; }
    }
}
