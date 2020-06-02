using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SnakeGame
{
    public partial class Menu : Form
    {
        Form1 v = new Form1();
        bool showDif = false;
        bool showTB = false;
        public Menu()
        {
            InitializeComponent();
            if (v.dif.Text=="1")
            {
                label4.ForeColor = Color.Gray;
                label5.ForeColor = Color.White;
                label6.ForeColor = Color.White;
            }
            else if (v.dif.Text == "2")
            {
                label4.ForeColor = Color.White;
                label5.ForeColor = Color.Gray;
                label6.ForeColor = Color.White;
            }
            else if (v.dif.Text == "3")
            {
                label4.ForeColor = Color.White;
                label5.ForeColor = Color.White;
                label6.ForeColor = Color.Gray;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_MouseHover(object sender, EventArgs e)
        {
            
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Hide();
            v.Show();
        }

        private void label2_MouseLeave(object sender, EventArgs e)
        {
            
        }

        private void label3_MouseHover(object sender, EventArgs e)
        {
            
        }

        private void Menu_Load(object sender, EventArgs e)
        {

        }

        void mostrarLbl()
        {
            label4.Visible = true;
            label5.Visible = true;
            label6.Visible = true;
            showDif = true;
            label10.Visible = true;
            label11.Visible = true;
            checkBox1.Visible = true;
        }

        void ocultarLbl()
        {
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            showDif = false;
            label10.Visible = false;
            label11.Visible = false;
            checkBox1.Visible = false;
        }

        private void label3_Click(object sender, EventArgs e)
        {
            if(showDif==false)
            {
                mostrarLbl();
            }
            else
            {
                ocultarLbl();
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            v.dif.Text = "1";
            label4.ForeColor = Color.Gray;
            label5.ForeColor = Color.White;
            label6.ForeColor = Color.White;
        }

        private void label5_Click(object sender, EventArgs e)
        {
            v.dif.Text = "2";
            label4.ForeColor = Color.White;
            label5.ForeColor = Color.Gray;
            label6.ForeColor = Color.White;
        }

        private void label6_Click(object sender, EventArgs e)
        {
            v.dif.Text = "3";
            label4.ForeColor = Color.White;
            label5.ForeColor = Color.White;
            label6.ForeColor = Color.Gray;
        }

        private void label3_MouseLeave(object sender, EventArgs e)
        {
            
        }

        private void label7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            
        }

        private void label9_Click(object sender, EventArgs e)
        {
            Ayuda n = new Ayuda();
            n.Show();
        }

        private void label11_Click(object sender, EventArgs e)
        {
            if(label11.Text=="<1>")
            {
                label11.Text = "<2>";
                v.nZona.Text = "2";
            }
            else if (label11.Text == "<2>")
            {
                label11.Text = "<3>";
                v.nZona.Text = "3";
            }
            else if (label11.Text == "<3>")
            {
                label11.Text = "<1>";
                v.nZona.Text = "1";
            }
        }

        private void label12_Click(object sender, EventArgs e)
        {
            
        }

        private void txtJugador_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(v.cuadricula==false)
            {
                v.cuadricula = true;
            }
            else
            {
                v.cuadricula = false;
            }
        }
    }
}
