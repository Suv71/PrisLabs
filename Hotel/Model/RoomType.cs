﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class RoomType
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public double BaseCost { get; set; }

        public RoomType()
        {
        }
    }
}
