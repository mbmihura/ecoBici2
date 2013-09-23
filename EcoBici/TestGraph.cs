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
    public partial class TestGraph : Form
    {
        public TestGraph()
        {
            InitializeComponent();
        }

        private void TestGraph_Load(object sender, EventArgs e)
        {
            // Populate series data
            Random random = new Random();

            Series s1 = new Series("Series1");
            s1.ChartType = SeriesChartType.StackedBar100;
            chart1.Series.Add(s1);

            for (int pointIndex = 0; pointIndex < 10; pointIndex++)
            {
                chart1.Series["Series1"].Points.AddY(Math.Round((double)random.Next(5, 95), 0));
                chart1.Series["Series2"].Points.AddY(Math.Round((double)random.Next(5, 75), 0));
                chart1.Series["Series3"].Points.AddY(Math.Round((double)random.Next(5, 95), 0));
                chart1.Series["Series4"].Points.AddY(Math.Round((double)random.Next(5, 95), 0));
            }



            //for (int pointIndex = 0; pointIndex < 10; pointIndex++)
            //{
            //    chart1.Series["LightBlue"].Points.AddY(random.Next(45, 95));
            //}

            // Set chart type
            chart1.Series["Series1"].ChartType = SeriesChartType.StackedArea100;

            // Show point labels
            chart1.Series["Series1"].IsValueShownAsLabel = true;

            // Disable X axis margin
            chart1.ChartAreas["ChartArea1"].AxisX.IsMarginVisible = false;

            // Set the first two series to be grouped into Group1
            chart1.Series["Series1"]["StackedGroupName"] = "Group1";
            chart1.Series["Series2"]["StackedGroupName"] = "Group1";

            // Set the last two series to be grouped into Group2
            chart1.Series["Series3"]["StackedGroupName"] = "Group2";
            chart1.Series["Series4"]["StackedGroupName"] = "Group2";
	
        
	


            //chart1.Series.Clear();
            //var series1 = new System.Windows.Forms.DataVisualization.Charting.Series
            //{
            //    Name = "Series1",
            //    Color = System.Drawing.Color.Green,
            //    IsVisibleInLegend = true,
            //    IsXValueIndexed = true,
            //    ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line
            //};

            //this.chart1.Series.Add(series1);

            //for (int i = 0; i < 100; i++)
            //{
            //    series1.Points.AddXY(i, f(i));
            //}
            //chart1.Invalidate();
            //chart1.SaveImage("C:\\mypic.png", System.Drawing.Imaging.ImageFormat.Png);
        }
        private double f(int i)
        {
            var f1 = 59894 - (8128 * i) + (262 * i * i) - (1.6 * i * i * i);
            return f1;
        }
    }
}
