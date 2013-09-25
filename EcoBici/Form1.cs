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
    public partial class Form1 : Form
    {
        private ResultSet results;
        private List<Chart> charts = new List<Chart>();


        public Form1(ResultSet results)
        {
            InitializeComponent();
            this.results = results;
        }

        private void export_btn_Click(object sender, EventArgs e)
        {
            foreach (var chart in charts)
            {
                chart.Invalidate();
                chart.SaveImage("C:\\mypic1111.png", System.Drawing.Imaging.ImageFormat.Png);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            chart1.Series.Clear();
            var series1 = new System.Windows.Forms.DataVisualization.Charting.Series
            {
                Name = "Series1",
                Color = System.Drawing.Color.Green,
                IsVisibleInLegend = false,
                IsXValueIndexed = true,
                ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line
            };

            this.chart1.Series.Add(series1);

            for (int i = 0; i < 100; i++)
            {
                series1.Points.AddXY(i, f(i));
            }
            chart1.Invalidate();
            chart1.SaveImage(@"C:\Users\Martín\Desktop\myresult.png", System.Drawing.Imaging.ImageFormat.Png);
        }
        private double f(int i)
        {
            var f1 = 59894 - (8128 * i) + (262 * i * i) - (1.6 * i * i * i);
            return f1;
        }

        
    }
}
