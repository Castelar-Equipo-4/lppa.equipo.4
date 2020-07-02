using lppa.equipo._4.Data.Model;
using lppa.equipo._4.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace lppa.equipo._4.Services
{
    public class InMemoryArtistaData : BaseDataService<Artist>
    {
        readonly List<Artist> artistas;

        public InMemoryArtistaData() 
        {
            artistas = new List<Artist>()
            {
                new Artist() {Id=1, FirstName="Luis Felipe", LastName="Noé", LifeSpan="1933 –"  },
                new Artist() {Id=2, FirstName="Florencio", LastName="Molina Campos", LifeSpan="1891 – 1959"  },
                new Artist() {Id=3, FirstName="Marta", LastName="Minujin", LifeSpan="1943 –"  },
            };

         }
        public IEnumerable<Artist> GetAll()
        {
            return artistas.OrderBy(o => o.FirstName);
        }
        
    }
}

