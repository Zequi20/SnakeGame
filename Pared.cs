﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    public class Pared:Object
    {
        Image pared = Image.FromFile("C:\\Users\\Ezequiel\\source\\repos\\SnakeGame1\\muro.png");
        public Pared(int x,int y)
        {
            this.x = x;
            this.y = y;
        }

        public void dibujar(Graphics g)
        {
            g.DrawImage(pared, x, y);
        }

    }
}