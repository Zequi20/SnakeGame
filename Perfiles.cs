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
    public partial class Perfiles : Form
    {
        public Perfiles()
        {
            InitializeComponent();
        }

        private void Perfiles_Load(object sender, EventArgs e)
        {
            MessageBox.Show(Environment.CurrentDirectory);
        }
    }
}
