using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Veterinaria.Models;

namespace Veterinaria.Controllers
{
    class VentasController
    {
        #region snippet_Instances
        Conexiones conexion = new Conexiones();
        #endregion

        //[POST]
        #region snippet_Create
        public void Create(Ventas venta)
        {
            using (var con = conexion.GetCadenaConexion())
            {
                string query = "INSERT Ventas VALUES ("
                    + $" {venta.GetIdVenta}, '{venta.GetFechaVenta}',"
                    + $" {venta.GetNoProductos}, {venta.GetTotal},"
                    + $" {venta.GetPago}, {venta.GetCambio} )";

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
                string query = "SELECT IdVenta FROM Ventas ORDER BY IdVenta";

                using (var cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    int id = 0;

                    while (dr.Read())
                    {
                        id = int.Parse(dr["IdVenta"].ToString());
                    }
                    dr.Close();
                    con.Close();

                    if (id != 0)
                    {
                        return id + 1;
                    }
                    else
                    {
                        return 1000000;
                    }
                }
            }
        }
        #endregion

        //[GET]
        #region snppet_GetAll
        public List<Ventas> GetAll()
        {
            using (var con = conexion.GetCadenaConexion())
            {
                string query = "SELECT * FROM Ventas ORDER BY IdVenta";

                using (var cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    var ventas = new List<Ventas>();

                    while (dr.Read())
                    {
                        ventas.Add(
                                new Ventas(
                                        int.Parse(dr["IdVenta"].ToString()),
                                        dr["FechaVenta"].ToString(),
                                        int.Parse(dr["NoProductos"].ToString()),
                                        float.Parse(dr["Total"].ToString()),
                                        float.Parse(dr["Pago"].ToString()),
                                        float.Parse(dr["Cambio"].ToString())
                                    )
                            );
                    }
                    dr.Close();
                    con.Close();

                    return ventas;
                }
            }
        }
        #endregion
    }
}
