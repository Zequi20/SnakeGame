using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    public class Comida : Object
    {
        Image c = Image.FromFile("C:\\Users\\Ezequiel\\source\\repos\\SnakeGame1\\egg.png");
        public void dibujar(Graphics g)
        {
            g.DrawImage(c, x, y);
        }
        public void ubicar()
        {
            this.x = r.Next(1, 52) * 10;
            this.y = r.Next(1, 29) * 10;
        }

        public Comida(int x,int y)
        {
            this.x = x;
            this.y = y;
        }
    }
}
