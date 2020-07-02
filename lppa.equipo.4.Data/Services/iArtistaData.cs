using lppa.equipo._4.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lppa.equipo._4.Services
{
    public interface IArtistaData
    {
        IEnumerable<Artist> GetAll();
    }

}
