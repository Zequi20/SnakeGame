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
using System.IO;
using System.Runtime.CompilerServices;

namespace SnakeGame
{
    public partial class Form1 : Form
    {
        Graphics pantalla;
        Graphics buffer;
        Bitmap pantallaAux;
        Cola cabeza = new Cola(245,130);
        List<Cola> cuerpo = new List<Cola>();
        List<Pared> muro = new List<Pared>();
        Comida comida = new Comida(50,30);
        int dirx = 0, diry = 0, puntaje = 0;
        bool pause=false;
        int i = 0, j = 0;
        public int head=0;
        int dificultad=1;
        int[,] mapa = new int[62, 39];
        public Form1()
        {
            InitializeComponent();
            pantalla = screen.CreateGraphics();
            pantallaAux = new Bitmap(Convert.ToInt32(screen.Width), Convert.ToInt32(screen.Height));
            buffer = Graphics.FromImage(pantallaAux);
            cuerpo.Add(new Cola(-10, -10));
            cuerpo.Add(new Cola(-10, -10));
            cargarMapa();
            if (dificultad==1)
            {
                time.Interval = 50;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            buffer.Clear(Color.Black);
            dibujarCuerpo();
            cabeza.dibujarCabeza(buffer, head);
            comida.dibujar(buffer);
            dibujarMapa();
            pantalla.DrawImageUnscaled(pantallaAux, new Point(0, 0));
            mover();
            comer();
            chocar();
            limites();
        }

        void cargarMapa()
        {
            //StreamReader leer = new StreamReader(@"C:\Users\Ezequiel\source\repos\SnakeGame1\mapa.txt");
            for (i = 0; i < 62; i++)
            {
                for (j = 0; j < 39; j++)
                {
                    if (mapa[i,j] == '1')
                    {
                        muro.Add(new Pared(i * 10, j * 10));
                    }
                }
            }
        }
        void dibujarCuerpo()
        {
            for (i = 0; i < cuerpo.Count; i++)
            {
                if (i == cuerpo.Count-1)
                {
                    cuerpo[i].dibujarF(buffer);
                }
                else
                {
                    cuerpo[i].dibujar(buffer);
                }
            }
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
                    MessageBox.Show("Hasta la proxima", "Chocaste");
                    Application.Restart();
                }
            }
            for (i = 0; i < muro.Count; i++)
            {
                if (muro[i].colision(cabeza) == true)
                {
                    time.Enabled = false;
                    lbl_over.Visible = true;
                    SoundPlayer c = new SoundPlayer();
                    c.SoundLocation = "C:\\Users\\Ezequiel\\source\\repos\\SnakeGame1\\hit.wav";
                    c.Load();
                    c.Play();
                    MessageBox.Show("Hasta la proxima", "Chocaste");
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
                    head = 1;
                }
                else if(e.KeyCode == Keys.Down)
                {
                    diry = cabeza.ancho;
                    dirx = 0;
                    cabeza.bx = false;
                    cabeza.by = true;
                    head = 2;
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
                    head = 3;
                }
                if (e.KeyCode == Keys.Right)
                {
                    dirx = +cabeza.ancho;
                    diry = 0;
                    cabeza.by = false;
                    cabeza.bx = true;
                    head = 4;
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

        void dibujarMapa()
        {
            for(i=0;i<muro.Count;i++)
            {
                muro[i].dibujar(buffer);
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
