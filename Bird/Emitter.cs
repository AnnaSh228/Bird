using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Bird
{
    class Emitter
    {
        public List<IImpactPoint> impactPoints = new List<IImpactPoint>();

        List<Particle> particles = new List<Particle>();

        public float GravitationX = 0;
        public float GravitationY = 1;

        public float MousePositionX;
        public float MousePositionY;

       // public int X; // координата X центра эмиттера, будем ее использовать вместо MousePositionX
       // public int Y; // соответствующая координата Y 
        public int Direction = 0; // вектор направления в градусах куда сыпет эмиттер
        public int Spreading = 360; // разброс частиц относительно Direction
        public int SpeedMin = 1; // начальная минимальная скорость движения частицы
        public int SpeedMax = 10; // начальная максимальная скорость движения частицы
        public int RadiusMin = 2; // минимальный радиус частицы
        public int RadiusMax = 10; // максимальный радиус частицы
        public int LifeMin = 20; // минимальное время жизни частицы
        public int LifeMax = 100; // максимальное время жизни частицы

        public Color colorFrom = Color.Orange;
        public Color colorTo = Color.FromArgb(0, 0, 0, 0);


        public int ParticlesCount = 500;

      /*  public Emitter(int x, int y)
        {
            X = x;
            Y = y;
           
        }*/

        public void UpdateState()
        {
            foreach (var particle in particles)
            {
                particle.Life -= 1; // уменьшаю здоровье
                                    // если здоровье кончилось
                if (particle.Life < 0)
                {

                    particle.Life = Particle.rnd.Next(LifeMin, LifeMax);

                    particle.X = MousePositionX;
                    particle.Y = MousePositionY;

                    var direction = Direction
                        + (double)Particle.rnd.Next(Spreading)
                        - Spreading / 2;
                    var Speed = Particle.rnd.Next(SpeedMin, SpeedMax);
                    particle.SpeedX = (float)(Math.Cos(direction / 180 * Math.PI) * Speed);
                    particle.SpeedY = -(float)(Math.Sin(direction / 180 * Math.PI) * Speed);

                    particle.Radius = Particle.rnd.Next(RadiusMin, RadiusMax);
                }
                else
                {
                    foreach (var point in impactPoints)
                    {
                        float gX = point.X - particle.X;
                        float gY = point.Y - particle.Y;
                        float r2 = gX * gX + gY * gY;
                        float M = 100;

                        particle.SpeedX += (gX) * M / r2;
                        particle.SpeedY += (gY) * M / r2;
                    }
                   
                    particle.SpeedX += GravitationX;
                    particle.SpeedY += GravitationY;

                    particle.X += particle.SpeedX;
                    particle.Y += particle.SpeedY;
                }
            }
            for (var i = 0; i < 10; ++i)
            {
                if (particles.Count < ParticlesCount)
                {
                    var particle = new Particle();
                    particle.X = MousePositionX;
                    particle.Y = MousePositionY;
                    particles.Add(particle);
                }
                else
                {
                    break;
                }
            }
        }

        public void Render(Graphics g)
        {
            // утащили сюда отрисовку частиц
            foreach (var particle in particles)
            {
                particle.Draw(g);
            }
        }

    }
}
