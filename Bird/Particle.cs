using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Bird
{
    public class Particle
    {
        public float X;
        public float Y;

        public int Radius;

        public float SpeedX; // скорость перемещения
        public float SpeedY; // скорость перемещения

        public float Life;

        public static Random rnd = new Random();


        public virtual void Draw(Graphics g)
        {

            var b = new SolidBrush(Color.Red);

            g.FillEllipse(b, X - Radius, Y - Radius, Radius * 2, Radius * 2);

            b.Dispose();
        }



    }
}
