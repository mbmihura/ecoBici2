using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoBici
{
    /// <summary>
    /// Contains methods to perfom general operation among different data types, such as search in an array or copyng it.
    /// </summary>
    static class DataTypeUtils
    {
        /// <summary>
        /// Creates a deep copy of a given jagged TimeSpan array.
        /// </summary>
        /// <param name="source">Jagged array to be copied.</param>
        /// <returns>New array.</returns>
        public static TimeSpan[][] CopyArray(TimeSpan[][] source)
        {
            TimeSpan[][] destination = new TimeSpan[source.Length][];
            for(int i = 0; i < source.Length; i++)
            {
                destination[i] = new TimeSpan[source[i].Length];
                source[i].CopyTo(destination[i],0);
            }
            return destination;
        }
    }
}
