using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    public class Pared:Object
    {
        Image bloque = Image.FromFile("Files\\muro.png");
        public Pared(int x,int y)
        {
            this.x = x;
            this.y = y;
        }

        public void dibujar(Graphics g)
        {
            g.DrawImage(bloque, x, y);
        }

    }
}
