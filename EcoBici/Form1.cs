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
        private Simulation simulation;

        public Form1()
        {
            InitializeComponent();
        }

        public Form1(Simulation simulation)
        {
            InitializeComponent();
            this.simulation = simulation;
        }
    }
}
