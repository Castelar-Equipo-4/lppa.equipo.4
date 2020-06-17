using lppa.equipo._4.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace lppa.equipo._4.Services
{
    public class InMemoryArtistaData : IArtistaData
    {
        readonly List<Artista> artistas;

        public InMemoryArtistaData()
        {
            artistas = new List<Artista>()
            {
                new Artista() {Id=1, FirstName="Luis Felipe", LastName="Noé", LifeSpan="1933 –"  },
                new Artista() {Id=2, FirstName="Florencio", LastName="Molina Campos", LifeSpan="1891 – 1959"  },
                new Artista() {Id=3, FirstName="Marta", LastName="Minujin", LifeSpan="1943 –"  },
            };

         }
        public IEnumerable<Artista> GetAll()
        {
            return artistas.OrderBy(o => o.FirstName);
        }
    }
}

