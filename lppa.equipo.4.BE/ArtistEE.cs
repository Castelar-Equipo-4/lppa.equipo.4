﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lppa.equipo._4.BE
{
    public class ArtistEE : IdentityEE
    {

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string LifeSpan { get; set; }

        public string Country { get; set; }

        public string Description { get; set; }

        public int TotalProducts { get; set; }

    }
}
