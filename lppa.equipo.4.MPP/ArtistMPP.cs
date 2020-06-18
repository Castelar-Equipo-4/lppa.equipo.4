using lppa.equipo._4.BE;
using lppa.equipo._4.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lppa.equipo._4.MPP
{
    public class ArtistMPP
    {
        private ClsDatos oDatos;

        public ArtistMPP()
        {
            this.oDatos = new ClsDatos();
        }

        public List<ArtistEE> ListarArtists()
        {
            DataSet DS = new DataSet();
            List<ArtistEE> ListaArtist = new List<ArtistEE>();

            DS = this.oDatos.Leer("sp_Artists_Listar", null);

            if (DS.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow Item in DS.Tables[0].Rows)
                {
                    ArtistEE oCli = new ArtistEE
                    {
                        Id = int.Parse(Item["Id"].ToString()),
                        FirstName = Item["FirstName"].ToString(),
                        LastName = Item["LastName"].ToString(),
                        LifeSpan = Item["LifeSpan"].ToString(),
                        Country = Item["Country"].ToString(),
                        Description = Item["Description"].ToString()
                    };

                    ListaArtist.Add(oCli);
                }
                return ListaArtist;
            }
            else
            {
                return null;
            }
        }

        public bool Operacion(ArtistEE oArtistEE, int op)
        {
            var hdatos = new Hashtable();
            string consulta;
            switch (op)
            {
                case 1:
                    consulta = "sp_Artist_Insert";
                    break;

                case 2:
                    consulta = "sp_Artist_Update";
                    break;

                case 3:
                    consulta = "sp_Artist_Delete";
                    break;

                default:
                    consulta = null;
                    break;
            }

            if (op != 1)
                if (oArtistEE.Id.HasValue) hdatos.Add("@Id", oArtistEE.Id);

            if (op != 3)
            {
                hdatos.Add("@FirstName", oArtistEE.FirstName);
                hdatos.Add("@LastName", oArtistEE.LastName);
                hdatos.Add("@LifeSpan", oArtistEE.LifeSpan);
                hdatos.Add("@Country", oArtistEE.Country);
                hdatos.Add("@Description", oArtistEE.Description);
            }

            return this.oDatos.Escribir(consulta, hdatos);
        }
    }
}
