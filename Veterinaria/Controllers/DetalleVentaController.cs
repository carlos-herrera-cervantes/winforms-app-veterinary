using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Veterinaria.Models;

namespace Veterinaria.Controllers
{
    class DetalleVentaController
    {
        #region snippet_Instances
        Conexiones conexion = new Conexiones();
        #endregion

        //[POST]
        #region snippet_Create
        public void Create(DetalleVenta venta)
        {
            using (var con = conexion.GetCadenaConexion())
            {
                string query = $"INSERT DetalleVenta VALUES ("
                    + $" {venta.GetIdVenta}, '{venta.GetNomnreProducto}',"
                    + $" '{venta.GetUnidad}', {venta.GetCantidad},"
                    + $" {venta.GetPrecio}, {venta.GetIdProducto} )";

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
                string query = "SELECT IdVenta FROM DetalleVenta ORDER BY IdVenta";

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
        #region snippet_GetById
        public List<DetalleVenta> GetById(int id)
        {
            using (var con = conexion.GetCadenaConexion())
            {
                string query = $"SELECT * FROM DetalleVenta WHERE IdVenta = {id}";

                using (var cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    var productos = new List<DetalleVenta>();

                    while (dr.Read())
                    {
                        productos.Add(
                                new DetalleVenta(
                                        int.Parse(dr["IdVenta"].ToString()),
                                        dr["NombreProducto"].ToString(),
                                        dr["Unidad"].ToString(),
                                        float.Parse(dr["Cantidad"].ToString()),
                                        float.Parse(dr["Precio"].ToString()),
                                        int.Parse(dr["IdProducto"].ToString())
                                    )
                            );
                    }
                    dr.Close();
                    con.Close();

                    return productos;
                }
            }
        }
        #endregion
    }
}
