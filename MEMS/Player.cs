﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MEMS
{
    public class Player
    {
        public string Name { get; set; } = "";
        public int Point { get; set; } = 0;

        //public Player()
        //{

        //}

        public Player(string name)
        {
            Name = name;
        }


        //public Player(string name, int point)
        //{
        //    Name = name;
        //    Point = point;
        //}
    }


    
}
