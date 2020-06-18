using lppa.equipo._4.BE;
using lppa.equipo._4.MPP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lppa.equipo._4.BLL
{
   public class ArtistBLL
    {
        public List<ArtistEE> ListarArtist()
        {
            ArtistMPP oArtistMPP = new ArtistMPP();

            return oArtistMPP.ListarArtists();
        }

        public bool Operacion(ArtistEE oArtistEE, int op)
        {
            ArtistMPP oArtMPP = new ArtistMPP();

            return oArtMPP.Operacion(oArtistEE, op);
        }
    }
}
