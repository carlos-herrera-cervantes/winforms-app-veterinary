using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Veterinaria.Models;

namespace Veterinaria.Controllers
{
    class CatalogoServicioController
    {
        #region snippet_Instances
        private Conexiones conexion = new Conexiones();
        #endregion

        //[POST]
        #region snippet_Create
        public void Create(CatalogoServicio catalogo)
        {
            using (var con = conexion.GetCadenaConexion())
            {
                string query = $"INSERT CatalogoServicio VALUES ("
                    + $" {catalogo.GetIdServicio}, '{catalogo.GetNombreServicio}', '{catalogo.GetDescripcionServicio}',"
                    + $" {catalogo.GetCosto} )";

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
                string query = "SELECT * FROM CatalogoServicio ORDER BY IdServicio";

                using (var cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    int id = 0;
                    while (dr.Read())
                    {
                        id = int.Parse(dr["IdServicio"].ToString());
                    }
                    dr.Close();
                    con.Close();

                    if (id != 0)
                    {
                        return id + 1;
                    }
                    else
                    {
                        return 800000;
                    }
                }
            }
        }
        #endregion

        //[GET]
        #region snippet_GetNombre
        public List<CatalogoServicio> GetNombre()
        {
            using (var con = conexion.GetCadenaConexion())
            {
                using (var cmd = new SqlCommand("SELECT NombreServicio FROM CatalogoServicio ORDER BY NombreServicio", con))
                {
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    var nombresServicios = new List<CatalogoServicio>();
                    while (dr.Read())
                    {
                        nombresServicios.Add(
                                new CatalogoServicio(dr["NombreServicio"].ToString())
                            );
                    }
                    dr.Close();
                    con.Close();

                    return nombresServicios;
                }
            }
        }
        #endregion

        #region snippet_GetIdByName
        public int GetIdByName(string nombreServicio)
        {
            using (var con = conexion.GetCadenaConexion())
            {
                string query = $"SELECT IdServicio FROM CatalogoServicio WHERE NombreServicio LIKE {nombreServicio}";
                using (var cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    var id = 0;
                    if (dr.Read())
                    {
                        id = int.Parse(dr["IdServicio"].ToString());
                    }
                    dr.Close();
                    con.Close();

                    return id;
                }
            }
        }
        #endregion

        #region snippet_GetById
        public CatalogoServicio GetById(int id)
        {
            using (var con = conexion.GetCadenaConexion())
            {
                string query = $"SELECT * FROM CatalogoServicio WHERE IdServicio = {id}";

                using (var cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    var servicio = new CatalogoServicio();
                    if (dr.Read())
                    {
                        servicio = new CatalogoServicio(
                                int.Parse(dr["IdServicio"].ToString()),
                                dr["NombreServicio"].ToString(),
                                dr["DescripcionServicio"].ToString(),
                                float.Parse(dr["Costo"].ToString())
                            );
                    }
                    dr.Close();
                    con.Close();

                    return servicio;
                }
            }
        }
        #endregion

        #region snippet_GetByName
        public CatalogoServicio GetByName(string nombre)
        {
            using (var con = conexion.GetCadenaConexion())
            {
                string query = $"SELECT * FROM CatalogoServicio WHERE NombreServicio LIKE '{nombre}'";

                using (var cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    var servicio = new CatalogoServicio();

                    if (dr.Read())
                    {
                        servicio = new CatalogoServicio(
                                int.Parse(dr["IdServicio"].ToString()),
                                dr["NombreServicio"].ToString(),
                                dr["DescripcionServicio"].ToString(),
                                float.Parse(dr["Costo"].ToString())
                            );
                    }
                    dr.Close();
                    con.Close();

                    return servicio;
                }
            }
        }
        #endregion

        //[PUT]
        #region snippet_Update
        public void Update(CatalogoServicio servicio)
        {
            using (var con = conexion.GetCadenaConexion())
            {
                string query = $"UPDATE CatalogoServicio SET NombreServicio ="
                    + $" '{servicio.GetNombreServicio}', DescripcionServicio ="
                    + $" '{servicio.GetDescripcionServicio}', Costo ="
                    + $" {servicio.GetCosto} WHERE IdServicio = {servicio.GetIdServicio}";

                using (var cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
        }
        #endregion
    }
}
