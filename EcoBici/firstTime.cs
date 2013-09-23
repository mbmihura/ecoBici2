using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace EcoBici
{
    public partial class firstTime : Form
    {
        public firstTime()
        {
            InitializeComponent();
        }

        private void firstTime_Load(object sender, EventArgs e)
        {
            var estationList = new List<Tuple<int, TimeSpan>>();

            estationList.Add(new Tuple<int, TimeSpan>(1, new TimeSpan(2, 0, 0)));
            estationList.Add(new Tuple<int, TimeSpan>(2, new TimeSpan(0, 30, 0)));
            estationList.Add(new Tuple<int, TimeSpan>(3, new TimeSpan(1, 30, 0)));
            estationList.Add(new Tuple<int, TimeSpan>(4, new TimeSpan(0, 30, 0)));

            //chart1.Series.Clear();
            var s = new Series
            {
                Name = "Series1",
                MarkerStyle = MarkerStyle.Cross,
                MarkerSize = 20,
                XValueType = ChartValueType.Time,
                Color = System.Drawing.Color.Brown,
                IsVisibleInLegend = true,
                IsXValueIndexed = true,
                ChartType = SeriesChartType.Point
            };
            //chart1.Series.Add(s);

            foreach (Tuple<int, TimeSpan> stationTime in estationList)
            {
                double porc = stationTime.Item2.TotalMinutes / 1440;
                chart1.Series["Series1"].Points.AddXY(porc, stationTime.Item1);
                
            }
          //  chart1.Series.Add(s);
            // Populate series data
            //Random random = new Random();

            //Series s1 = new Series("Series1");
            //s1.ChartType = SeriesChartType.StackedBar100;
            //chart1.Series.Add(s1);

            //for (int pointIndex = 0; pointIndex < 10; pointIndex++)
            //{
            //    chart1.Series["Series1"].Points.AddY(Math.Round((double)random.Next(5, 95), 0));
            //    chart1.Series["Series2"].Points.AddY(Math.Round((double)random.Next(5, 75), 0));
            //    chart1.Series["Series3"].Points.AddY(Math.Round((double)random.Next(5, 95), 0));
            //    chart1.Series["Series4"].Points.AddY(Math.Round((double)random.Next(5, 95), 0));
            //}

        }
    }
}
