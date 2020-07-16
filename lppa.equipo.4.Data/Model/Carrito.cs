using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lppa.equipo._4.Data.Model
{
    public class Carrito : IdentityBase
    {
        public Carrito()
        {
            this.CarritoItem = new HashSet<CarritoItem>();
        }

        public string Cookie { get; set; }
        public System.DateTime CarritoDate { get; set; }
        public int ItemCount { get; set; }


        public virtual ICollection<CarritoItem> CarritoItem { get; set; }
    }
}
