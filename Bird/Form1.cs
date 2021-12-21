using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bird
{
    public partial class Form1 : Form
    {
        Emitter emitter = new Emitter();
        //List<Particle> particles = new List<Particle>();
        public Form1()
        {
            InitializeComponent();
            picBox.Image = new Bitmap(picBox.Width, picBox.Height);
            
           emitter.impactPoints.Add(new GravityPoint(picBox.Width / 2, picBox.Height / 2 - 100));
            emitter.MousePositionX = picBox.Width / 2;
            emitter.MousePositionY = picBox.Height / 2;
        
        
        }
            
        private void timer1_Tick(object sender, EventArgs e)
        {
            emitter.UpdateState();
            using (var g = Graphics.FromImage(picBox.Image))
            {
                g.Clear(Color.White);

                emitter.Render(g);
            }
            picBox.Invalidate();
        }

        private void picBox_Paint(object sender, PaintEventArgs e)
        {
          
        }

        private void picBox_MouseMove(object sender, MouseEventArgs e)
        {
           // emitter.MousePositionX = e.X;
           // emitter.MousePositionY = e.Y;

        }
    }
}
