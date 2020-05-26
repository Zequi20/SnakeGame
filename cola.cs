using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SnakeGame
{
    public class Cola : Object
    {
        Image s = Image.FromFile("C:\\Users\\Ezequiel\\source\\repos\\SnakeGame1\\snake.png");
        Image shadow = Image.FromFile("C:\\Users\\Ezequiel\\source\\repos\\SnakeGame1\\shadow.png");
        public bool bx = true;
        public bool by = true;
        public bool cabeza = false;
        public void dibujar(Graphics g)
        {
            //g.DrawImage(shadow, x + 3, y + 3);
            g.DrawImage(s, x, y);
        }
        public void setxy(int xx, int yy)
        {
            ax = x;
            ay = y;
            this.x = xx;
            this.y = yy;
        }

        public Cola(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public void seguir(Cola obj)
        {
            if (this.colision(obj) == false)
            {
                setxy(obj.x, obj.y);
            }
            else if(this.colision(obj) == true)
            {
                setxy(ax, ay);
            }
        }
    }
}
