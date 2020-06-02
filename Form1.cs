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
        Cola cabeza = new Cola(300,190);
        List<Cola> cuerpo = new List<Cola>();
        List<Pared> muro = new List<Pared>();
        Comida comida = new Comida(250, 190);
        int dirx = 0, diry = 0, puntaje = 0;
        bool pause=false;
        int i = 0, j = 0;
        public int head=0;
        int[,] mapa = new int[62, 39];
        int segundos=0,minutos=0;
        Image cuadro = Image.FromFile("Files\\cuadro.png");
        public bool cuadricula = false;
        public Form1()
        {
            InitializeComponent();
            pantalla = screen.CreateGraphics();
            pantallaAux = new Bitmap(Convert.ToInt32(screen.Width), Convert.ToInt32(screen.Height));
            buffer = Graphics.FromImage(pantallaAux);
            cuerpo.Add(new Cola(-10, -10));
            cuerpo.Add(new Cola(-10, -10));
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (nZona.Text == "1")
            {
                cargarMapa1();
            }
            if (nZona.Text == "2")
            {
                cargarMapa2();
            }
            if (nZona.Text == "3")
            {
                cargarMapa3();
            }
            if (dif.Text == "1")
            {
                time.Interval = 80;
            }
            else if (dif.Text == "2")
            {
                time.Interval = 50;
            }
            else if (dif.Text == "3")
            {
                time.Interval = 40;
            }
            tJuego.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            comer();
            buffer.Clear(Color.Black);
            dibujarCuadros();
            dibujarMapa();
            dibujarCuerpo();
            cabeza.dibujarCabeza(buffer, head);
            comida.dibujar(buffer); 
            limites();
            pantalla.DrawImageUnscaled(pantallaAux, new Point(0, 0));
            mover();
            chocar();
        }

        void dibujarCuadros()
        {
            if (cuadricula == true)
            {
                for (i = 0; i < 62; i++)
                {
                    for (j = 0; j < 39; j++)
                    {
                        buffer.DrawImage(cuadro, i * 10, j * 10);
                    }
                }
            }
        }

        void cargarMapa1()
        {
            for (i = 0; i < 62; i++)
            {
                for (j = 0; j < 39; j++)
                {
                    if (j > 5 && j < 14)
                    {
                        mapa[i, j] = 1;
                    }
                    if (j > 24 && j < 33)
                    {
                        mapa[i, j] = 1;
                    }
                    if (i > 1 && i < 10)
                    {
                        mapa[i, j] = 0;
                    }
                    if (i > 51 && i < 60)
                    {
                        mapa[i, j] = 0;
                    }

                    if (i < 2 || i > 59)
                    {
                        mapa[i, j] = 1;
                    }
                    if (j < 2 || j > 36)
                    {
                        mapa[i, j] = 1;
                    }
                    if (j > 13 && j < 25)
                    {
                        mapa[i, j] = 0;
                    }
                }
            }
            for (i = 0; i < 62; i++)
            {
                for (j = 0; j < 39; j++)
                {
                    if (mapa[i, j] == 1)
                    {
                        muro.Add(new Pared(i * 10, j * 10));
                    }
                }
            }
        }

        void cargarMapa2()
        {
            for (i = 0; i < 62; i++)
            {
                for (j = 0; j < 39; j++)
                {
                    if(j > 21 && j < 27)
                    {
                        mapa[i, j] = 1;
                    }
                    if (i>32 && i < 39)
                    {
                        mapa[i, j] = 1; 
                        mapa[i, j] = 1;
                    }
                }
            }
            for (i = 0; i < 62; i++)
            {
                for (j = 0; j < 39; j++)
                {
                    if (mapa[i, j] == 1)
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

        void cargarMapa3()
        {
            for (i = 0; i < 62; i++)
            {
                for (j = 0; j < 39; j++)
                {
                    if (i > 4 && i < 24)
                    {
                        mapa[i, j] = 1;
                    }
                    if (i > 36 && i < 57)
                    {
                        mapa[i, j] = 1;
                    }
                    if (j > 1 && j < 5)
                    {
                        mapa[i, j] = 0;
                    }
                    if (j > 33 && j < 37)
                    {
                        mapa[i, j] = 0;
                    }
                    if (j > 15 && j < 23)
                    {
                        mapa[i, j] = 0;
                    }
                    if (i < 2 || i > 59)
                    {
                        mapa[i, j] = 1;
                    }
                    if (j < 2 || j > 36)
                    {
                        mapa[i, j] = 1;
                    }
                }
            }
            for (i = 0; i < 62; i++)
            {
                for (j = 0; j < 39; j++)
                {
                    if (mapa[i, j] == 1)
                    {
                        muro.Add(new Pared(i * 10, j * 10));
                    }
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
            c.SoundLocation = "Files\\Die.wav";
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
            StreamWriter flujoSalida = File.CreateText("Files\\Scores.txt");
            flujoSalida.WriteLine(Jugador.Text+", "+puntaje.ToString()+", "+lblT.Text);
            flujoSalida.Close();
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
            if(e.KeyCode==Keys.P|| e.KeyCode == Keys.Escape)
            {
                if(pause==false)
                {
                    time.Enabled = false;
                    pause = true;
                    lbl_pausa.Visible = true;
                    pMenu.Visible = true;
                    pSalir.Visible = true;
                    Help.Visible = true;
                    puntos.Visible = true;
                    lblT.Visible = true;
                }
                else if(pause==true)
                {
                    time.Enabled = true;
                    pause = false;
                    lbl_pausa.Visible = false;
                    pMenu.Visible = false;
                    pSalir.Visible = false;
                    Help.Visible = false;
                    puntos.Visible = false;
                    lblT.Visible = false;
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
                n.SoundLocation = "Files\\eat.wav";
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
                lblT.Text = "Tiempo " + minutos.ToString() + ":" + segundos.ToString();
            }
        }

        private void lblT_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {
            Ayuda n = new Ayuda();
            n.Show();
        }

        private void TimeShow_Click(object sender, EventArgs e)
        {

        }

        private void screen_Click(object sender, EventArgs e)
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
