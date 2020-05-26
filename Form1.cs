using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace SnakeGame
{
    public partial class Form1 : Form
    {
        Graphics pantalla;
        Cola cabeza = new Cola(20,20);
        List<Cola> cuerpo = new List<Cola>();
        Comida comida = new Comida(50,30);
        int dirx = 0;
        int diry = 0;
        int puntaje = 0;
        bool pause=false;
        int i = 0;
        public Form1()
        {
            InitializeComponent();
            pantalla = screen.CreateGraphics();
            cuerpo.Add(new Cola(-10, -10));
            cuerpo.Add(new Cola(-10, -10));
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            pantalla.Clear(Color.LightGreen);
            comida.dibujar(pantalla);
            cabeza.dibujar(pantalla);
            for (i = 0; i < cuerpo.Count; i++)
            {
                cuerpo[i].dibujar(pantalla);
            }
            mover();
            comer();
            chocar();
            limites();
        }

        public void mover()
        {
            cabeza.setxy(cabeza.x + dirx, cabeza.y + diry);
            for(i=0;i<cuerpo.Count;i++)
            {
                if(i==0)
                {
                    cuerpo[i].setxy(cabeza.ax, cabeza.ay);
                }
                else if(i>0)
                {
                    cuerpo[i].setxy(cuerpo[i-1].ax, cuerpo[i-1].ay);
                }
            }
        }
        private void chocar()
        {
            for (i = 3; i < cuerpo.Count; i++)
            {
                if (cuerpo[i].colision(cabeza) == true)
                {
                    time.Enabled = false;
                    lbl_over.Visible = true;
                    SoundPlayer c = new SoundPlayer();
                    c.SoundLocation = "C:\\Users\\Ezequiel\\source\\repos\\SnakeGame1\\hit.wav";
                    c.Load();
                    c.Play();
                    MessageBox.Show("Hasta la proxima");
                    Application.Restart();
                }
            }
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.P)
            {
                if(pause==false)
                {
                    time.Enabled = false;
                    pause = true;
                    lbl_pausa.Visible = true;
                }
                else if(pause==true)
                {
                    time.Enabled = true;
                    pause = false;
                    lbl_pausa.Visible = false;
                }
            }
            if(cabeza.bx==true)
            {
                if(e.KeyCode == Keys.Up)
                {
                    diry = -cabeza.ancho;
                    dirx = 0;
                    cabeza.bx = false;
                    cabeza.by = true;
                }
                else if(e.KeyCode == Keys.Down)
                {
                    diry = cabeza.ancho;
                    dirx = 0;
                    cabeza.bx = false;
                    cabeza.by = true;
                }
            }
            if(cabeza.by ==true)
            {
                if (e.KeyCode == Keys.Left)
                {
                    dirx = -cabeza.ancho;
                    diry = 0;
                    cabeza.by = false;
                    cabeza.bx = true;
                }
                if (e.KeyCode == Keys.Right)
                {
                    dirx = +cabeza.ancho;
                    diry = 0;
                    cabeza.by = false;
                    cabeza.bx = true;
                }
            }
        }

        private void comer()
        {
            if (cabeza.colision(comida) == true)
            {
                comida.ubicar();
                cuerpo.Add(new Cola(-10,-10));
                puntaje++;
                score.Text = puntaje.ToString();
                SoundPlayer s = new SoundPlayer();
                s.SoundLocation = "C:\\Users\\Ezequiel\\source\\repos\\SnakeGame1\\eat.wav";
                s.Load();
                s.Play();
                if (puntaje>4)
                {
                    time.Interval = 70;
                }
                if (puntaje > 14)
                {
                    time.Interval = 60;
                }
                if (puntaje > 24)
                {
                    time.Interval = 50;
                }
                if (puntaje > 34)
                {
                    time.Interval = 40;
                }
            }
        }

        private void limites()
        {
            if (cabeza.x > 618)
            {
                cabeza.x = 0;
            }
            if (cabeza.x < 0)
            {
                cabeza.x = 620;
            }
            if (cabeza.y > 388)
            {
                cabeza.y = 0;
            }
            if (cabeza.y < 0)
            {
                cabeza.y = 390;
            }
        }

        private void reiniciarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
