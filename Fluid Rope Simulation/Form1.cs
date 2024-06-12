using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Numerics;

namespace Fluid_Rope_Simulation
{
    public partial class Form1 : Form
    {
        public Rope rope;
        private Timer timer;

        public Form1()
        {
            InitializeComponent();
            rope = new Rope(new Vector2(200, 50), 20, 10);

            simTimer.Interval = 16; // ~60 FPS
            simTimer.Tick += simTimer_Tick;
            timer.Start();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            base.OnPaint(e);
            rope.Draw(e.Graphics);
        }

        private void simTimer_Tick(object sender, EventArgs e)
        {
            rope.Update(0.016f); // Assuming 60 FPS
            Invalidate();
        }
    }
}
