using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Veterinaria.Models;

namespace Veterinaria.Controllers
{
    class CatalogoProductosController
    {
        #region snippet_Instances
        private Conexiones conexion = new Conexiones();
        #endregion

        //[POST]
        #region snippet_Create
        public void Create(CatalogoProductos producto)
        {
            using (var con = conexion.GetCadenaConexion())
            {
                string query = $"INSERT CatalogoProductos VALUES ("
                    + $" {producto.GetIdProducto}, '{producto.GetNombreProducto}',"
                    + $" {producto.GetPrecioCompra}, {producto.GetPrecioVenta},"
                    + $" '{producto.GetUnidad}', {producto.GetCantidad})";

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
                string query = "SELECT IdProducto FROM CatalogoProductos ORDER BY IdProducto";

                using (var cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    int id = 0;

                    while (dr.Read())
                    {
                        id = int.Parse(dr["IdProducto"].ToString());
                    }
                    dr.Close();
                    con.Close();

                    if (id != 0)
                    {
                        return id + 1;
                    }
                    else
                    {
                        return 900000;
                    }
                }
            }
        }
        #endregion

        //[GET]
        #region snippet_GetAll
        public List<CatalogoProductos> GetAll()
        {
            using (var con = conexion.GetCadenaConexion())
            {
                string query = "SELECT * FROM CatalogoProductos ORDER BY IdProducto";

                using (var cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    var productos = new List<CatalogoProductos>();

                    while (dr.Read())
                    {
                        productos.Add(
                                new CatalogoProductos(
                                        int.Parse(dr["IdProducto"].ToString()),
                                        dr["NombreProducto"].ToString(),
                                        float.Parse(dr["PrecioCompra"].ToString()),
                                        float.Parse(dr["PrecioVenta"].ToString()),
                                        dr["Unidad"].ToString(),
                                        float.Parse(dr["Cantidad"].ToString())
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

        #region snippet_GetById
        public CatalogoProductos GetById(int id)
        {
            using (var con = conexion.GetCadenaConexion())
            {
                string query = $"SELECT * FROM CatalogoProductos WHERE IdProducto = {id}";

                using (var cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    var producto = new CatalogoProductos();

                    if (dr.Read())
                    {
                        producto = new CatalogoProductos(
                                int.Parse(dr["IdProducto"].ToString()),
                                dr["NombreProducto"].ToString(),
                                float.Parse(dr["PrecioCompra"].ToString()),
                                float.Parse(dr["PrecioVenta"].ToString()),
                                dr["Unidad"].ToString(),
                                float.Parse(dr["Cantidad"].ToString())
                            );
                    }
                    dr.Close();
                    con.Close();

                    return producto;
                }
            }
        }
        #endregion

        #region snippet_GetByName
        public CatalogoProductos GetByName(string nombre)
        {
            using (var con = conexion.GetCadenaConexion())
            {
                string query = $"SELECT * FROM CatalogoProductos WHERE NombreProducto LIKE '{nombre}'";

                using (var cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    var producto = new CatalogoProductos();

                    if (dr.Read())
                    {
                        producto = new CatalogoProductos(
                                int.Parse(dr["IdProducto"].ToString()),
                                dr["NombreProducto"].ToString(),
                                float.Parse(dr["PrecioCompra"].ToString()),
                                float.Parse(dr["PrecioVenta"].ToString()),
                                dr["Unidad"].ToString(),
                                float.Parse(dr["Cantidad"].ToString())
                            );
                    }
                    dr.Close();
                    con.Close();

                    return producto;
                }
            }
        }
        #endregion

        //[PUT]
        #region snippet_Update
        public void Update(CatalogoProductos producto)
        {
            using (var con = conexion.GetCadenaConexion())
            {
                string query = $"UPDATE CatalogoProductos SET NombreProducto ="
                    + $" '{producto.GetNombreProducto}', PrecioCompra ="
                    + $" {producto.GetPrecioCompra}, PrecioVenta ="
                    + $" {producto.GetPrecioVenta}, Unidad ="
                    + $" '{producto.GetUnidad}', Cantidad ="
                    + $" {producto.GetCantidad} WHERE IdProducto = {producto.GetIdProducto}";

                using (var cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
        }
        #endregion

        //[DELETE]
        #region snippet_Delete
        public void Delete(int id)
        {
            using (var con = conexion.GetCadenaConexion())
            {
                string query = $"DELETE FROM CatalogoProductos WHERE IdProducto = {id}";

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
