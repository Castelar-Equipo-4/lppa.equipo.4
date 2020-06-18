using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace lppa.equipo._4.Data
{
    public class ClsDatos
    {
        private string CadenaC = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        private SqlConnection Cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
        private SqlTransaction Tranx;

        private SqlCommand Cmd;

        public DataSet Leer(string consulta, Hashtable hdatos = null)
        {
            try
            {
                Cmd = new SqlCommand
                {
                    Connection = Cnn,
                    CommandText = consulta,
                    CommandType = CommandType.StoredProcedure
                };

                if ((hdatos != null))
                {
                    foreach (string dato in hdatos.Keys)
                    {
                        Cmd.Parameters.AddWithValue(dato, hdatos[dato]);
                    }
                }

                var Ds = new DataSet();
                using (var adaptador = new SqlDataAdapter(Cmd))
                {
                    adaptador.Fill(Ds);
                }
                return Ds;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }


        }

        public bool Escribir(string consulta, Hashtable hdatos)
        {
            if (Cnn.State == ConnectionState.Closed)
            {
                Cnn.ConnectionString = CadenaC;
                Cnn.Open();
            }
            try
            {
                Tranx = Cnn.BeginTransaction();
                Cmd = new SqlCommand
                {
                    Connection = Cnn,
                    CommandText = consulta,
                    CommandType = CommandType.StoredProcedure,
                    Transaction = Tranx
                };

                if ((hdatos != null))
                {
                    foreach (string dato in hdatos.Keys)
                    {
                        Cmd.Parameters.AddWithValue(dato, hdatos[dato]);
                    }
                }

                int respuesta = Cmd.ExecuteNonQuery();
                Tranx.Commit();
                return true;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            catch (Exception ex)
            {
                Console.Write(ex);
                Tranx.Rollback();
                return false;
            }
            finally
            {
                Cnn.Close();
            }
        }
    }
}
