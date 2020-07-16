using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lppa.equipo._4.Data.Model
{
    public class CarritoItem : IdentityBase
    {
        public int CartId { get; set; }
        public int ProductId { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }

        public virtual Carrito Carrito { get; set; }
    }
}
