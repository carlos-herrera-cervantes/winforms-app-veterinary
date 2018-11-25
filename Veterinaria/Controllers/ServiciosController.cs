using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Veterinaria.Models;

namespace Veterinaria.Controllers
{
    class ServiciosController
    {
        #region snippet_Instances
        private Conexiones conexion = new Conexiones();
        #endregion

        //[POST]
        #region snippet_Create
        public void Create(Servicios servicio)
        {
            using (var con = conexion.GetCadenaConexion())
            {
                string query = $"INSERT Servicios VALUES ("
                    + $" {servicio.GetIdRegistro}, '{servicio.GetFechaRegistro}',"
                    + $" '{servicio.GetDescripionServicio}', '{servicio.GetDescripcionCostoAdicional}',"
                    + $" {servicio.GetCosto}, {servicio.GetDescuento},"
                    + $" {servicio.GetCostoAdicional}, {servicio.GetPago},"
                    + $" {servicio.GetCambio}, {servicio.GetTotal},"
                    + $" {servicio.GetIdCliente}, {servicio.GetIdMascota},"
                    + $" {servicio.GetIdServicio} )";

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
                string query = "SELECT * FROM Servicios ORDER BY IdRegistro";

                using (var cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    int id = 0;
                    while (dr.Read())
                    {
                        id = int.Parse(dr["IdRegistro"].ToString());
                    }
                    dr.Close();
                    con.Close();

                    if (id != 0)
                    {
                        return id + 1;
                    }
                    else
                    {
                        return 700000;
                    }
                }
            }
        }
        #endregion

        //[GET]
        #region snippet_GetAll
        public List<Servicios> GetAll()
        {
            using (var con = conexion.GetCadenaConexion())
            {
                string query = "SELECT * FROM Servicios WHERE IdCliente != 0 ORDER BY IdRegistro";

                using (var cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    var servicios = new List<Servicios>();
                    while (dr.Read())
                    {
                        servicios.Add(
                            new Servicios(
                                int.Parse(dr["IdRegistro"].ToString()),
                                dr["FechaRegistro"].ToString(),
                                dr["DescripcionServicio"].ToString(),
                                dr["DescripcionCostoAdicional"].ToString(),
                                float.Parse(dr["Costo"].ToString()),
                                float.Parse(dr["Descuento"].ToString()),
                                float.Parse(dr["CostoAdicional"].ToString()),
                                float.Parse(dr["Pago"].ToString()),
                                float.Parse(dr["Cambio"].ToString()),
                                float.Parse(dr["Total"].ToString()),
                                int.Parse(dr["IdCliente"].ToString()), 
                                int.Parse(dr["IdMascota"].ToString()), 
                                int.Parse(dr["IdServicio"].ToString())
                            ));
                    }
                    dr.Close();
                    con.Close();

                    return servicios;
                }
            }
        }
        #endregion

        #region snippet_GetAllNoServicios
        public List<Servicios> GetAllNoServicios()
        {
            using (var con = conexion.GetCadenaConexion())
            {
                string query = "SELECT * FROM Servicios WHERE IdCliente = 0 ORDER BY IdRegistro";

                using (var cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    var servicios = new List<Servicios>();
                    while (dr.Read())
                    {
                        servicios.Add(
                            new Servicios(
                                int.Parse(dr["IdRegistro"].ToString()),
                                dr["FechaRegistro"].ToString(),
                                dr["DescripcionServicio"].ToString(),
                                dr["DescripcionCostoAdicional"].ToString(),
                                float.Parse(dr["Costo"].ToString()),
                                float.Parse(dr["Descuento"].ToString()),
                                float.Parse(dr["CostoAdicional"].ToString()),
                                float.Parse(dr["Pago"].ToString()),
                                float.Parse(dr["Cambio"].ToString()),
                                float.Parse(dr["Total"].ToString()),
                                int.Parse(dr["IdCliente"].ToString()),
                                int.Parse(dr["IdMascota"].ToString()),
                                int.Parse(dr["IdServicio"].ToString())
                           ));
                    }
                    dr.Close();
                    con.Close();

                    return servicios;
                }
            }
        }
        #endregion

        #region snippet_GetById
        public Servicios GetById(int id)
        {
            using (var con = conexion.GetCadenaConexion())
            {
                string query = $"SELECT * FROM Servicios WHERE IdRegistro = {id}";

                using (var cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    var servicio = new Servicios();

                    if (dr.Read())
                    {
                        servicio = new Servicios(
                                int.Parse(dr["IdRegistro"].ToString()),
                                dr["FechaRegistro"].ToString(),
                                dr["DescripcionServicio"].ToString(),
                                dr["DescripcionCostoAdicional"].ToString(),
                                float.Parse(dr["Costo"].ToString()),
                                float.Parse(dr["Descuento"].ToString()),
                                float.Parse(dr["CostoAdicional"].ToString()),
                                float.Parse(dr["Pago"].ToString()),
                                float.Parse(dr["Cambio"].ToString()),
                                float.Parse(dr["Total"].ToString()),
                                int.Parse(dr["IdCliente"].ToString()),
                                int.Parse(dr["IdMascota"].ToString()),
                                int.Parse(dr["IdServicio"].ToString())
                            );
                    }
                    dr.Close();
                    con.Close();

                    return servicio; ;
                }
            }
        }
        #endregion
    }
}
