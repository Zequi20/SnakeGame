﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    public class Object
    {
        public int x=5;
        public int y=5;
        public int ax = 0;
        public int ay = 0;
        public int ancho=10;
        public bool colision(Object objeto)
        {
            int px = Math.Abs(this.x - objeto.x);
            int py = Math.Abs(this.y - objeto.y);
            if(px >=0 && px < 10 && py >= 0 && py < 10)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}