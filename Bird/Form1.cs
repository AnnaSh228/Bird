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
        bool body = true;
        bool heart = true;
        bool tail  = true;
        bool wings = true;
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
                organ = "body",
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
                organ = "body",
                GravitationY = 0, // отключил гравитацию
                Direction = 0, // направление 0
                Spreading = 10, // немного разбрасываю частицы, чтобы было интереснее
                SpeedMin = 10, // минимальная скорость 10
                SpeedMax = 10, // и максимальная скорость 10
                ColorFrom = Color.Gold, // цвет начальный
                ColorTo = Color.Orange, // цвет конечный
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

            this.emitter = new Emitter // создаю эмиттер и привязываю его к полю emitter
            {
                organ = "wingL",
                LifeMax = 20,
                Direction = 60,
                Spreading = 60,
                SpeedMin = 10,
                SpeedMax = 10,
                ColorFrom = Color.Gold,
                ColorTo =Color.Gold,
                ParticlesPerTick = 10,
                X = picBox.Width / 2 + offset -10,
                Y = picBox.Height / 2 - offset/2,
            };

            emitters.Add(this.emitter);

            this.emitter = new Emitter // создаю эмиттер и привязываю его к полю emitter
            {
                organ = "wingR",
                LifeMax = 20,
                Direction = 120,
                Spreading = 60,
                SpeedMin = 10,
                SpeedMax = 10,
                ColorFrom = Color.Gold,
                ColorTo = Color.Gold,
                ParticlesPerTick = 10,
                X = picBox.Width / 2 - offset + 10,
                Y = picBox.Height / 2 - offset / 2,
            };

            emitters.Add(this.emitter);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {


            using (var g = Graphics.FromImage(picBox.Image))
            {
                g.Clear(Color.Black);
                foreach (var em in emitters)
                {
                    if ((body && em.organ == "body")
                        || (wings && (em.organ == "wingR" || em.organ == "wingL")))
                    {
                        em.UpdateState();
                        em.Render(g);
                    }
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

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            body = checkBox1.Checked;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            tail = checkBox2.Checked;
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            heart = checkBox3.Checked;
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            wings = checkBox4.Checked;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            foreach (var em in emitters)
            {
                if(em.organ == "wingL")
                {
                    em.Direction = trackBar1.Value - 60;
                }
                if (em.organ == "wingR")
                {
                    em.Direction = 180 - (trackBar1.Value - 60);

                }
            }    
        }
    }
}
