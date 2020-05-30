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
        Image t = Image.FromFile("C:\\Users\\Ezequiel\\source\\repos\\SnakeGame1\\tail.png");
        Image Arrows = Image.FromFile("C:\\Users\\Ezequiel\\source\\repos\\SnakeGame1\\arr.png");
        Image headUp = Image.FromFile("C:\\Users\\Ezequiel\\source\\repos\\SnakeGame1\\HeadUp.gif");
        Image headDown = Image.FromFile("C:\\Users\\Ezequiel\\source\\repos\\SnakeGame1\\HeadDown.gif");
        Image headRight = Image.FromFile("C:\\Users\\Ezequiel\\source\\repos\\SnakeGame1\\HeadRight.gif");
        Image headLeft = Image.FromFile("C:\\Users\\Ezequiel\\source\\repos\\SnakeGame1\\HeadLeft.gif");
        public bool bx = true;
        public bool by = true;
        public bool cabeza = false;
        public void dibujar(Graphics g)
        {
            g.DrawImage(s, x, y);
        }

        public void dibujarF(Graphics g)
        {
            g.DrawImage(t, x, y);
        }
        public void dibujarCabeza(Graphics g,int n)
        {
            if(n==0)
            {
                g.DrawImage(Arrows, x, y);
            }
            else if(n==1)
            {
                g.DrawImage(headUp, x, y);
            }
            else if (n == 2)
            {
                g.DrawImage(headDown, x, y);
            }
            else if (n == 4)
            {
                g.DrawImage(headLeft, x, y);
            }
            else if (n == 3)
            {
                g.DrawImage(headRight, x, y);
            }
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

    }
}
