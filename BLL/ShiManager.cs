﻿using Model;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ShiManager : BaseBLL<Shi>
    {
        public ShiManager() : base(new ShiService())
        {

        }
    }
}
