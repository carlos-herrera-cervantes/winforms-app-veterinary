using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Veterinaria.Models;

namespace Veterinaria.Controllers
{
    class ClientesController
    {
        #region snippet_Instances
        private Conexiones conexion = new Conexiones();
        #endregion

        //[GET]
        #region snippet_GetAll
        public List<Clientes> GetAll()
        {
            using (var con = conexion.GetCadenaConexion())
            {
                string query = "SELECT * FROM Clientes";

                using (var cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    var clientes = new List<Clientes>();
                    while (dr.Read())
                    {
                        clientes.Add(
                                new Clientes(
                                    int.Parse(dr["IdCliente"].ToString()), 
                                    dr["NombreCliente"].ToString(), 
                                    dr["ApellidoCliente"].ToString(),
                                    dr["SexoCliente"].ToString(), 
                                    dr["TelefonoCliente"].ToString(), 
                                    dr["DireccionCliente"].ToString(),
                                    dr["CorreoCliente"].ToString(), 
                                    int.Parse(dr["EdadCliente"].ToString()), 
                                    dr["FechaRegistro"].ToString()
                                ));
                    }
                    dr.Close();
                    con.Close();

                    return clientes;
                }
            }
        }
        #endregion

        #region snippet_GetId
        public List<Clientes> GetId()
        {
            using (var con = conexion.GetCadenaConexion())
            {
                string query = "SELECT IdCliente FROM Clientes ORDER BY IdCliente";

                using (var cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    var idClientes = new List<Clientes>();
                    while (dr.Read())
                    {
                        idClientes.Add(
                                new Clientes(int.Parse(dr["IdCliente"].ToString()))
                            );
                    }
                    dr.Close();
                    con.Close();

                    return idClientes;
                }
            }
        }
        #endregion

        #region snippet_GetById
        public Clientes GetById(int id)
        {
            using (var con = conexion.GetCadenaConexion())
            {
                string query = $"SELECT * FROM Clientes WHERE IdCliente = {id}";
                
                using (var cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    Clientes cliente = new Clientes();
                    if (dr.Read())
                    {
                        cliente = new Clientes(
                                int.Parse(dr["IdCliente"].ToString()), 
                                dr["NombreCliente"].ToString(), 
                                dr["ApellidoCliente"].ToString(),
                                dr["SexoCliente"].ToString(), 
                                dr["TelefonoCliente"].ToString(), 
                                dr["DireccionCliente"].ToString(),
                                dr["CorreoCliente"].ToString(), 
                                int.Parse(dr["EdadCliente"].ToString()), 
                                dr["FechaRegistro"].ToString()
                            );
                    }
                    dr.Close();
                    con.Close();

                    return cliente;
                }
            }
        }
        #endregion

        #region snippet_GetByNombreMascota
        public Clientes GetByNombreMascota(string nombreMascota)
        {
            using (var con = conexion.GetCadenaConexion())
            {
                string query = $"DECLARE @IdCliente int " +
                                $"SELECT @IdCliente = IdCliente FROM Mascotas WHERE " +
                                $"NombreMascota LIKE '{ nombreMascota}'" +
                                $" SELECT * FROM Clientes WHERE IdCliente = @IdCliente";

                using (var cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    Clientes cliente = new Clientes();
                    if (dr.Read())
                    {
                        cliente = new Clientes(
                                int.Parse(dr["IdCliente"].ToString()), 
                                dr["NombreCliente"].ToString(), 
                                dr["ApellidoCliente"].ToString(),
                                dr["SexoCliente"].ToString(), 
                                dr["TelefonoCliente"].ToString(), 
                                dr["DireccionCliente"].ToString(),
                                dr["CorreoCliente"].ToString(), 
                                int.Parse(dr["EdadCliente"].ToString()), 
                                dr["FechaRegistro"].ToString()
                            );
                    }
                    dr.Close();
                    con.Close();

                    return cliente;
                }
            }
        }
        #endregion

        #region snippet_GetByName
        public Clientes GetByName(string nombre, string apellido)
        {
            using (var con = conexion.GetCadenaConexion())
            {
                string query = $"SELECT * FROM Clientes WHERE NombreCliente LIKE '{nombre}' AND ApellidoCliente LIKE '{apellido}'";

                using (var cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    Clientes cliente = new Clientes();

                    if (dr.Read())
                    {
                        cliente = new Clientes(
                                int.Parse(dr["IdCliente"].ToString()), 
                                dr["NombreCliente"].ToString(),
                                dr["ApellidoCliente"].ToString(), 
                                dr["SexoCliente"].ToString(),
                                dr["TelefonoCliente"].ToString(), 
                                dr["DireccionCliente"].ToString(),
                                dr["CorreoCliente"].ToString(), 
                                int.Parse(dr["EdadCliente"].ToString()),
                                dr["FechaRegistro"].ToString()
                            );
                    }
                    dr.Close();
                    con.Close();

                    return cliente;
                }
            }
        }
        #endregion

        //[POST]
        #region snippet_Create
        public void Create(Clientes cliente)
        {
            using (var con = conexion.GetCadenaConexion())
            {
                string query = $"INSERT Clientes VALUES ("
                    + $" {cliente.GetIdCliente}, '{cliente.GetNombreCliente}',"
                    + $" '{cliente.GetApellidoCliente}', '{cliente.GetSexoCliente}',"
                    + $" '{cliente.GetTelefonoCliente}', '{cliente.GetDireccionCliente}',"
                    + $" '{cliente.GetCorreoCliente}', {cliente.GetEdadCliente},"
                    + $" '{cliente.GetFechaRegistro}' )";

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
                string query = "SELECT * FROM Clientes ORDER BY IdCliente";

                using (var cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    int id = 0;
                    while (dr.Read())
                    {
                        id = int.Parse(dr["IdCliente"].ToString());
                    }
                    dr.Close();
                    con.Close();

                    if (id != 0)
                    {
                        return id + 1;
                    }
                    else
                    {
                        return 500000;
                    }
                }
            }
        }
        #endregion

        //[PUT]
        #region snippet_Update
        public void Update(Clientes cliente)
        {
            using (var con = conexion.GetCadenaConexion())
            {
                string query = $"UPDATE Clientes SET NombreCliente = '{cliente.GetNombreCliente}',"
                    + $" ApellidoCliente = '{cliente.GetApellidoCliente}', SexoCliente = '{cliente.GetSexoCliente}',"
                    + $" TelefonoCliente = '{cliente.GetTelefonoCliente}', DireccionCliente = '{cliente.GetDireccionCliente}',"
                    + $" CorreoCliente = '{cliente.GetCorreoCliente}', EdadCliente = {cliente.GetEdadCliente}"
                    + $" WHERE IdCliente = {cliente.GetIdCliente}";

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
                string query = $"DELETE FROM Clientes WHERE IdCliente = {id}";

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