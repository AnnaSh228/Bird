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
        public float X;
        public float Y;

        public float GravitationX = 0;
        public float GravitationY = 1;

        public int ParticlesCount = 500;

        public Emitter(float x, float y)
        {
            X = x;
            Y = y;
           
        }

        public void UpdateState()
        {
            foreach (var particle in particles)
            {
                particle.Life -= 1; // уменьшаю здоровье
                                    // если здоровье кончилось
                if (particle.Life < 0)
                {

                    particle.Life =Particle.rnd.Next(20,120);

                    particle.X = X;
                    particle.Y = Y;

                    var Direction = (double)Particle.rnd.Next(360);
                    var Speed = Particle.rnd.Next(10, 40);
                    particle.SpeedX = (float)(Math.Cos(Direction / 180 * Math.PI) * Speed);
                    particle.SpeedY = -(float)(Math.Sin(Direction / 180 * Math.PI) * Speed);
                }
                else
                {
                    float gX = impactPoints[0].X - particle.X;
                    float gY = impactPoints[0].Y - particle.Y;

                    // считаем квадрат расстояния между частицей и точкой r^2
                    float r2 = gX * gX + gY * gY;
                    float M = 100; // сила притяжения к точке, пусть 100 будет

                    // пересчитываем вектор скорости с учетом притяжения к точке
                    particle.SpeedX += (gX) * M / r2;
                    particle.SpeedY += (gY) * M / r2;

                    // а это старый код, его не трогаем
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
                    // а у тут уже наш новый класс используем
                    var particle = new Particle(X,Y);
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
