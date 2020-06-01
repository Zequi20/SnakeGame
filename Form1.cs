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
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;

namespace SnakeGame
{
    public partial class Form1 : Form
    {
        Graphics pantalla;
        Graphics buffer;
        Bitmap pantallaAux;
        Cola cabeza = new Cola(150,130);
        List<Cola> cuerpo = new List<Cola>();
        List<Pared> muro = new List<Pared>();
        Comida comida = new Comida(200, 30);
        int dirx = 0, diry = 0, puntaje = 0;
        bool pause=false;
        int i = 0, j = 0;
        public int head=0;
        int[,] mapa = new int[62, 39];
        int segundos=0,minutos=0;
        public Form1()
        {
            InitializeComponent();
            pantalla = screen.CreateGraphics();
            pantallaAux = new Bitmap(Convert.ToInt32(screen.Width), Convert.ToInt32(screen.Height));
            buffer = Graphics.FromImage(pantallaAux);
            cuerpo.Add(new Cola(-10, -10));
            cuerpo.Add(new Cola(-10, -10));
            cargarMapa();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (dif.Text == "1")
            {
                time.Interval = 60;
            }
            else if (dif.Text == "2")
            {
                time.Interval = 40;
            }
            else if (dif.Text == "3")
            {
                time.Interval = 30;
            }
            tJuego.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            comer();
            buffer.Clear(Color.Black);
            dibujarMapa();
            dibujarCuerpo();
            cabeza.dibujarCabeza(buffer, head);
            comida.dibujar(buffer); 
            limites();
            pantalla.DrawImageUnscaled(pantallaAux, new Point(0, 0));
            mover();
            chocar();
        }

        void cargarMapa()
        {
            for (i = 0; i < 62; i++)
            {
                for (j = 0; j < 39; j++)
                {
                    if (i < 2 || i > 59)
                    {
                        mapa[i, j] = 1;
                    }
                    if (j < 2 || j > 36)
                    {
                        mapa[i, j] = 1;
                    }
                    if(i>30&&i<40&&j>15&&j<25)
                    {
                        mapa[i, j] = 1;
                    }
                }
            }
            for (i = 0; i < 62; i++)
            {
                for (j = 0; j < 39; j++)
                {
                    if (mapa[i,j]==1)
                    {
                        muro.Add(new Pared(i*10,j*10));
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

        private void morir()
        {
            lbl_over.Visible = true;
            SoundPlayer c = new SoundPlayer();
            c.SoundLocation = "C:\\Users\\Ezequiel\\source\\repos\\SnakeGame1\\Die.wav";
            c.Load();
            c.Play();
            buffer.Clear(Color.Black);
            cabeza.dibujarMuerto(buffer);
            for (i = 0; i < cuerpo.Count; i++)
            {
                cuerpo[i].dibujarMuerto(buffer);
            }
            dibujarMapa();
            pantalla.DrawImageUnscaled(pantallaAux, new Point(0, 0));
            muro.Clear();
            time.Enabled = false;
            tJuego.Enabled = false;
            puntos.Text = "Puntaje: " + puntaje.ToString();
            puntos.Visible = true;
            pMenu.Visible = true;
            pSalir.Visible = true;
            lblT.Text = ""+TimeShow.Text;
            lblT.Visible = true;
        }

        private void chocar()
        {
            for (i = 3; i < cuerpo.Count; i++)
            {
                if (cuerpo[i].colision(cabeza) == true)
                {
                    morir();
                }
            }
            for (i = 0; i < muro.Count; i++)
            {
                if (muro[i].colision(cabeza) == true)
                {
                    morir();
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
                    pMenu.Visible = true;
                    pSalir.Visible = true;
                }
                else if(pause==true)
                {
                    time.Enabled = true;
                    pause = false;
                    lbl_pausa.Visible = false;
                    pMenu.Visible = false;
                    pSalir.Visible = false;
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
            if (comida.colision(cabeza) == true)
            {
                ubicarComida();
                cuerpo.Add(new Cola(-10,-10));
                SoundPlayer n = new SoundPlayer();
                n.SoundLocation = "C:\\Users\\Ezequiel\\source\\repos\\SnakeGame1\\eat.wav";
                n.Load();
                n.Play();
                puntaje++;
                score.Text = puntaje.ToString();
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

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        void dibujarMapa()
        {
            for(i=0;i<muro.Count;i++)
            {
                muro[i].dibujar(buffer);
            }
        }

        private void ubicarComida()
        {
            comida.ubicar();
            for(i=0;i<muro.Count;i++)
            {
                if (comida.colision(muro[i])==true)
                {
                    ubicarComida();
                }
                if (comida.colision(cabeza) == true)
                {
                    ubicarComida();
                }
            }
            for (i = 0; i < cuerpo.Count; i++)
            {
                if (comida.colision(cuerpo[i]) == true)
                {
                    ubicarComida();
                }
            }
        }

        private void lbl_over_Click(object sender, EventArgs e)
        {

        }

        private void puntos_Click(object sender, EventArgs e)
        {

        }

        private void tJuego_Tick(object sender, EventArgs e)
        {
            if (pause==false)
            {
                segundos++;
                if (segundos == 60)
                {
                    segundos = 0;
                    minutos++;
                }
                TimeShow.Text = "Tiempo " + minutos.ToString() + ":" + segundos.ToString();
            }
        }

        private void lblT_Click(object sender, EventArgs e)
        {

        }

        private void pSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pMenu_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void reiniciarToolStripMenuItem_Click(object sender, EventArgs e)
        {
         
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
