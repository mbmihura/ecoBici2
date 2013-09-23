using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoBici
{
    class Log
    {
        public static TimeSpan? HV = null;
        public static int BikesAmount;
        private static int EstimatedAmountSimulatiosTens = 3;
        public static int nState = 0;
        private TimeSpan[][] TC;
        private TimeSpan? tcAnterior = null;
        private TimeSpan t;

        public void SetState(TimeSpan[][] tc)
        {
            this.TC = DataTypeUtils.CopyArray(tc);
        }
        public void SetTCAnt(TimeSpan tcAnterior)
        {
            this.tcAnterior = tcAnterior;
        }
        public void SetT(TimeSpan t)
        {
            this.t = t;
        }

        public void Write(string s)
        {
            Console.Write(s);
        }
          public void WriteLine(string s)
        {
            Console.WriteLine(s);
        }
         public static void NewLine()
        {
            Console.WriteLine();
        }
         public void WriteState(TimeSpan T, int e, TimeSpan[] TPLL, int d, int b, TimeSpan nuevoTc)
        {
            int lastCol;
            NewLine();

            int offSetSpacesTitles = EstimatedAmountSimulatiosTens + 9 * BikesAmount - 1 + 2;
            for (int i = 0; i < offSetSpacesTitles; ++i)
            {
                Write(" ");
            }
            //Write("                                                                                                    ");
            WriteLine("   __Time__  NextTPLL  Est    Des  min B  ____TC (a futuro)_____");
            StringBuilder s = new StringBuilder(String.Format("{0,"+ EstimatedAmountSimulatiosTens +"}", nState++) + "|"); 
            for (int row = 0; row < TC.Length; row++)
            {
                lastCol = TC[row].Length - 1;
                for (int col = 0; col <= lastCol; col++)
                {
                    s.Append(f(TC[row][col]) + (col < lastCol ? " " : "| "));
                }
                Write(s.ToString());
                if (row == 0)
                {
                    Write("  " + T + "  " + f(TPLL[e]) + "   " + e + "  ->  " + d.ToString() + "     " + b + "    " + f(nuevoTc));
                    Write((this.tcAnterior.HasValue ? " (TC:" + f(this.tcAnterior.Value):" ( T:" + f(this.t)) + ")");
                }
                NewLine();
                s = new StringBuilder("   |"); 
            }
        }

        string f(TimeSpan ts)
        {
            return ts >= HV ? "   HV   " : ts.ToString();
        }

        public static void setColumnNumbers()
        {
            NewLine();
            Console.WriteLine("123456789 123456789 123456789 123456789 123456789 123456789 123456789 123456789 123456789 123456789 123456789 123456789 123456789 123456789 123456789 123456789 123456789 [Column number]");
        }


    }
}
