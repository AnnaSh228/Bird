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

        public float MaxSpeed = 20;
        public float MinSpeed = 10;

        public float Life;

        public static Random rnd = new Random();

        public Particle(float x,float y)
        {
            X = x;
            Y = y;
            
            Radius = rnd.Next(5, 15);
            var Direction = (double)rnd.Next(0,360);
            var Speed = rnd.Next((int)MinSpeed, (int)MaxSpeed);
            SpeedX = (float)(Math.Cos(Direction / 180 * Math.PI) * Speed);
            SpeedY = -(float)(Math.Sin(Direction / 180 * Math.PI) * Speed);
            Life = rnd.Next(20, 120);
        }

        public void Draw(Graphics g)
        {

            var b = new SolidBrush(Color.Red);

            g.FillEllipse(b, X - Radius, Y - Radius, Radius * 2, Radius * 2);

            b.Dispose();
        }



    }
}
