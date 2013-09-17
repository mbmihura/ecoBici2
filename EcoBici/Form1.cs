using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EcoBici
{
    public partial class Form1 : Form
    {

        bool mouseClicked = false;

        private void chart1_MouseDown(object sender,
                     System.Windows.Forms.MouseEventArgs e)
        {
            mouseClicked = true;
        }

        private void chart1_MouseUp(object sender,
                System.Windows.Forms.MouseEventArgs e)
        {
            mouseClicked = false;
        }

        private void chart1_MouseMove(object sender,
             System.Windows.Forms.MouseEventArgs e)
        {
            if (mouseClicked)
            {
                this.chart1.Height = this.button1.Top = this.button1.Top + e.Y;
                this.chart1.Width = this.button1.Left = this.button1.Left + e.X;
            }
        }

        public Form1()
        {
            InitializeComponent();
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
            chart1.SaveImage("C:\\mypic.png", System.Drawing.Imaging.ImageFormat.Png);
        }
        private double f(int i)
        {
            var f1 = 59894 - (8128 * i) + (262 * i * i) - (1.6 * i * i * i);
            return f1;
        }

        private void button2_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void button2_MouseUp(object sender, MouseEventArgs e)
        {

        }

        private void button2_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void chart1_Enter(object sender, EventArgs e)
        {
            
        }

        private void chart1_Leave(object sender, EventArgs e)
        {
            
        }

        private void chart1_MouseClick(object sender, MouseEventArgs e)
        {
            button1.Visible = button2.Visible = true;
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            button1.Visible = button2.Visible = false;
        }
    }
}
