using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EcoBici
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Allocate Console
            NativeMethods.AllocConsole();
            Console.WriteLine("Buenos Aires Ciudad - Plan de Movilidad Sustentable:");
            Console.WriteLine("EcoBici BA System Simulation");
            Console.WriteLine();

            // Load simulation profiles defaults from file
            Console.Write("Loading simulation profile... ");
            Console.WriteLine("OK");

            // Ask for a value for profile's not settted variable
            Console.Write("Amount of bicycles: ");
            int b = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("");

            // Create simulation
            Console.Write("Creating simulation...");
            var Ti = new TimeSpan(0);
            var Tf = new TimeSpan(4, 0, 0);
            Simulation simulation = new Simulation(b, 3, new UniformDistribution(), Tf, Ti);
            Console.WriteLine("OK" + Environment.NewLine);

            // Run simulation
            Console.Write("Running simulation...");
            ResultSet rset = simulation.Run();
            Console.WriteLine("OK" + Environment.NewLine);


            // Load GUI and Results
            Console.Write("Loading GUI and Results...");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Form resultView = new Form1(rset);

            // Deallocate Console
            Console.Write("Exiting command interface...");
            NativeMethods.FreeConsole();

            // Display GUI
            Application.Run(resultView);
        }
    }


        internal static class NativeMethods
        {
            // http://msdn.microsoft.com/en-us/library/ms681944(VS.85).aspx
            /// <summary>
            /// Allocates a new console for the calling process.
            /// </summary>
            /// <returns>nonzero if the function succeeds; otherwise, zero.</returns>
            /// <remarks>
            /// A process can be associated with only one console,
            /// so the function fails if the calling process already has a console.
            /// </remarks>
            [DllImport("kernel32.dll", SetLastError = true)]
            internal static extern int AllocConsole();

            // http://msdn.microsoft.com/en-us/library/ms683150(VS.85).aspx
            /// <summary>
            /// Detaches the calling process from its console.
            /// </summary>
            /// <returns>nonzero if the function succeeds; otherwise, zero.</returns>
            /// <remarks>
            /// If the calling process is not already attached to a console,
            /// the error code returned is ERROR_INVALID_PARAMETER (87).
            /// </remarks>
            [DllImport("kernel32.dll", SetLastError = true)]
            internal static extern int FreeConsole();
        }
}
