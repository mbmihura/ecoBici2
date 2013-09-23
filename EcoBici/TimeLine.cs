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
    public partial class TimeLine : Form
    {
        public TimeLine()
        {
            InitializeComponent();
        }

        private void TimeLine_Load(object sender, EventArgs e)
        {

            var estationList = new List<Tuple<TimeSpan, int>>();

            estationList.Add(new Tuple< TimeSpan, int>(new TimeSpan(0, 30, 0),4));
            estationList.Add(new Tuple<TimeSpan, int>(new TimeSpan(1, 0, 0),4));
            estationList.Add(new Tuple< TimeSpan, int>(new TimeSpan(1, 30, 0), 3));
            estationList.Add(new Tuple< TimeSpan, int>(new TimeSpan(4, 30, 0),3));

            chart1.Series.Clear();
            //chart1.Series["Series1"].Points.Clear();

            var s = new Series
            {
                Name = "Series1",
                XValueType = ChartValueType.Time,
                Color = System.Drawing.Color.Brown,
                IsVisibleInLegend = true,
                IsXValueIndexed = false,
                ChartType = SeriesChartType.Line,
                BorderWidth = 2
            };

            chart1.Series.Add(s);

            foreach (Tuple<TimeSpan, int> stationTime in estationList)
            {
                double porc = stationTime.Item1.TotalMinutes / 1440;
                chart1.Series["Series1"].Points.AddXY(porc, stationTime.Item2);

            }
        }
    }
}
