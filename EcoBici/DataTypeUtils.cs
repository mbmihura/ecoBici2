using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoBici
{
    static class DataTypeUtils
    {
        public static TimeSpan[][] CopyArray(TimeSpan[][] source)
        {
            TimeSpan[][] destination = new TimeSpan[source.Length][];
            Array.Copy(source, destination, source.Length);
            return destination;
        }
    }
}
