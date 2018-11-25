using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Veterinaria.Models;

namespace Veterinaria.Controllers
{
    class ConsultasController
    {
        #region snippet_Instances
        Conexiones conexion = new Conexiones();
        #endregion

        //[POST]
        #region snippet_CreateId
        public int CreateId()
        {
            using (var con = conexion.GetCadenaConexion())
            {
                string query = "SELECT * FROM Consultas ORDER BY IdConsulta";

                using (var cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    SqlDataReader r = cmd.ExecuteReader();
                    int id = 0;
                    while (r.Read())
                    {
                        id = int.Parse(r["IdConsulta"].ToString());
                    }
                    r.Close();
                    con.Close();

                    if (id != 0)
                    {
                        return id + 1;
                    }
                    else
                    {
                        return 200000;
                    }
                }
            }
        }
        #endregion

        #region snippet_GetById
        public bool GetById(int id)
        {
            using (var con = conexion.GetCadenaConexion())
            {
                string query = $"SELECT * FROM Consultas WHERE IdConsulta = {id}";

                using (var cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    SqlDataReader r = cmd.ExecuteReader();
                    bool resultado = false;
                    if (r.Read())
                    {
                        resultado = true;
                    }
                    r.Close();
                    con.Close();

                    return resultado;
                }
            }
        }
        #endregion
    }
}
