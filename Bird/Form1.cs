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
        List<Emitter> emitters = new List<Emitter>();
        Emitter emitter ;
        //List<Particle> particles = new List<Particle>();
        public Form1()
        {
            InitializeComponent();
            picBox.Image = new Bitmap(picBox.Width, picBox.Height);
            
/*           emitter.impactPoints.Add(new GravityPoint(picBox.Width / 2, picBox.Height / 2 - 100));
            emitter.X = picBox.Width / 2;
            emitter.Y = picBox.Height / 2;*/
            var offset = -50;
            emitter = new Emitter
            {
                GravitationY = 0, // отключил гравитацию
                Direction = 0, // направление 0
                Spreading = 10, // немного разбрасываю частицы, чтобы было интереснее
                SpeedMin = 10, // минимальная скорость 10
                SpeedMax = 10, // и максимальная скорость 10
                ColorFrom = Color.Gold, // цвет начальный
                ColorTo = Color.Gold, // цвет конечный
                ParticlesPerTick = 3, // 3 частицы за тик генерю
                X = picBox.Width / 2, // x -- по центру экрана
                Y = picBox.Height / 2 - offset -125, // y поднят вверх на offset
            };

            emitter.impactPoints.Add(new GravityPoint
            {
                Power = (int)Math.Pow((emitter.SpeedMax + emitter.SpeedMin) / 2, 2),
                X = emitter.X,
                Y = emitter.Y + offset,
            });

            emitters.Add(emitter);

            offset = 75;
            emitter = new Emitter
            {
                GravitationY = 0, // отключил гравитацию
                Direction = 0, // направление 0
                Spreading = 10, // немного разбрасываю частицы, чтобы было интереснее
                SpeedMin = 10, // минимальная скорость 10
                SpeedMax = 10, // и максимальная скорость 10
                ColorFrom = Color.Gold, // цвет начальный
                ColorTo = Color.Gold, // цвет конечный
                ParticlesPerTick = 10, // 3 частицы за тик генерю
                X = picBox.Width / 2, // x -- по центру экрана
                Y = picBox.Height / 2 - offset , // y поднят вверх на offset
            };

            emitter.impactPoints.Add(new GravityPoint
            {
                Power = (int)Math.Pow((emitter.SpeedMax + emitter.SpeedMin) / 2, 2),
                X = emitter.X,
                Y = emitter.Y + offset,
            });

            emitters.Add(emitter);


        }

        private void timer1_Tick(object sender, EventArgs e)
        {


            using (var g = Graphics.FromImage(picBox.Image))
            {
                g.Clear(Color.Black);
                foreach (var em in emitters)
                {
                    em.UpdateState();
                    

                    em.Render(g);
                }
                picBox.Invalidate();
            }
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
