using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SnakeGame
{
    public class Comida : Object
    {
        static string dir = Directory.GetParent(Directory.GetCurrentDirectory()).ToString();
        public static string directorio = Directory.GetParent(dir).ToString();
        Image c = Image.FromFile(@directorio+@"\egg.png");
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
