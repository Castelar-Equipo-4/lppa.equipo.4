using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lppa.equipo._4.Data.Model
{
    public class CarritoItem : IdentityBase
    {
        public int CarritoId { get; set; }
        public int ObrasId { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }


        public virtual Carrito Carrito { get; set; }
    }
}
