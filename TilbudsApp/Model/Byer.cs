﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TilbudsApp.Model
{
    class Byer
    {
        public int Id { get; set; }
        public string Bname { get; set; }

        public Byer(int id, string bname)
        {
            Id = id;
            Bname = bname;
        }

        // TODO
    }
}
