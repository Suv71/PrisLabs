﻿using Model;
using Model.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IRoomTypeRepository
    {
        IEnumerable<RoomType> GetAll();
        RoomType GetById(RoomTypes id);
    }
}
