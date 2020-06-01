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

        private void label3_Click(object sender, EventArgs e)
        {
            if(showDif==false)
            {
                label4.Visible = true;
                label5.Visible = true;
                label6.Visible = true;
                showDif = true;
            }
            else
            {
                label4.Visible = false;
                label5.Visible = false;
                label6.Visible = false;
                showDif = false;
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
            MessageBox.Show("Snake\nBy: Zequi", "Acerca de:");
        }

        private void label9_Click(object sender, EventArgs e)
        {
            Ayuda n = new Ayuda();
            n.Show();
        }
    }
}
