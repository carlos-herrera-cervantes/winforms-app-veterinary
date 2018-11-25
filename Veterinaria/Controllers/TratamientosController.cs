using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Veterinaria.Models;
using System.Data.SqlClient;

namespace Veterinaria.Controllers
{
    class TratamientosController
    {
        #region snippet_Instances
        private Conexiones conexion = new Conexiones();
        #endregion

        //[GET]
        #region snippet_GetAll
        public List<Tratamientos> GetAll()
        {
            using (var con = conexion.GetCadenaConexion())
            {
                string query = "SELECT * FROM Tratamientos";

                using (var cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    var tratamientos = new List<Tratamientos>();

                    while (dr.Read())
                    {
                        tratamientos.Add(
                                new Tratamientos(
                                    int.Parse(dr["IdTratamiento"].ToString()),
                                    dr["NombreMascota"].ToString(),
                                    float.Parse(dr["PesoMascota"].ToString()),
                                    dr["NombreCliente"].ToString(),
                                    dr["Tratamiento"].ToString(),
                                    dr["FechaTratamiento"].ToString(),
                                    int.Parse(dr["IdMascota"].ToString())
                                )
                       );
                    }
                    dr.Close();
                    con.Close();

                    return tratamientos;
                }
            }
        }
        #endregion

        //[POST]
        #region snippet_Create
        public void Create(Tratamientos tratamiento)
        {
            using (var con = conexion.GetCadenaConexion())
            {
                string query = $"INSERT Tratamientos VALUES ("
                    + $" {tratamiento.GetIdTratamiento}, '{tratamiento.GetNombreMascota}',"
                    + $" {tratamiento.GetPesoMascota}, '{tratamiento.GetNombreCliente}',"
                    + $" '{tratamiento.GetTratamiento}', '{tratamiento.GetFechaTratamiento}',"
                    + $" {tratamiento.GetIdMascota} )";

                using (var cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
        }
        #endregion

        #region snippet_CreateId
        public int CreateId()
        {
            using (var con = conexion.GetCadenaConexion())
            {
                string query = "SELECT * FROM Tratamientos ORDER BY IdTratamiento";

                using (var cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    SqlDataReader r = cmd.ExecuteReader();
                    int id = 0;
                    while (r.Read())
                    {
                        id = int.Parse(r["IdTratamiento"].ToString());
                    }
                    r.Close();
                    con.Close();

                    if (id != 0)
                    {
                        return id + 1;
                    }
                    else
                    {
                        return 400000;
                    }
                }
            }
        }
        #endregion
    }
}
