using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;
using Veterinaria.Models;

namespace Veterinaria.Controllers
{
    class EmpleadosController
    {
        #region snippet_Instancias
        private Conexiones conexion = new Conexiones();
        #endregion

        //[GET]
        #region snippet_GetAll
        public List<Empleados> GetAll()
        {
            using (var con = conexion.GetCadenaConexion())
            {
                string query = "SELECT * FROM Empleados";

                using (var cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    var empleados = new List<Empleados>();
                    while (dr.Read())
                    {
                        empleados.Add(
                                new Empleados(
                                        int.Parse(dr["IdEmpleado"].ToString()), 
                                        dr["NombreEmpleado"].ToString(),
                                        dr["ApellidoEmpleado"].ToString(), 
                                        dr["SexoEmpleado"].ToString(),
                                        dr["TelefonoEmpleado"].ToString(), 
                                        dr["DireccionEmpleado"].ToString(),
                                        dr["TipoUsuario"].ToString(), 
                                        int.Parse(dr["EdadEmpleado"].ToString()),
                                        dr["FechaIngreso"].ToString(), 
                                        dr["Contrasena"].ToString()
                                    )
                            );
                    }

                    dr.Close();
                    con.Close();

                    return empleados;
                }
            }
        }
        #endregion

        #region snippet_GetById
        public Empleados GetById(int id)
        {
            using (var con = conexion.GetCadenaConexion())
            {
                string query = $"SELECT * FROM Empleados WHERE IdEmpleado = {id}";

                using (var cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    Empleados empleado = new Empleados();

                    if (dr.Read())
                    {
                        empleado = new Empleados(
                                        int.Parse(dr["IdEmpleado"].ToString()), 
                                        dr["NombreEmpleado"].ToString(),
                                        dr["ApellidoEmpleado"].ToString(), 
                                        dr["SexoEmpleado"].ToString(), 
                                        dr["TelefonoEmpleado"].ToString(),
                                        dr["DireccionEmpleado"].ToString(), 
                                        dr["TipoUsuario"].ToString(), 
                                        int.Parse(dr["EdadEmpleado"].ToString()),
                                        dr["FechaIngreso"].ToString(), 
                                        dr["Contrasena"].ToString()
                                   );
                    }
                    dr.Close();
                    con.Close();

                    return empleado;
                }
            }
        }
        #endregion

        #region snippet_GetByName
        public Empleados GetByName(string nombre, string apellido)
        {
            using (var con = conexion.GetCadenaConexion())
            {
                string query = $"SELECT * FROM Empleados WHERE NombreEmpleado LIKE '{nombre}' AND ApellidoEmpleado LIKE '{apellido}'";

                using (var cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    var empleado = new Empleados();

                    if (dr.Read())
                    {
                        empleado = new Empleados(
                                int.Parse(dr["IdEmpleado"].ToString()), 
                                dr["NombreEmpleado"].ToString(),
                                dr["ApellidoEmpleado"].ToString(), 
                                dr["SexoEmpleado"].ToString(), 
                                dr["TelefonoEmpleado"].ToString(),
                                dr["DireccionEmpleado"].ToString(), 
                                dr["TipoUsuario"].ToString(), 
                                int.Parse(dr["EdadEmpleado"].ToString()),
                                dr["FechaIngreso"].ToString(), 
                                dr["Contrasena"].ToString()
                           );
                    }
                    dr.Close();
                    con.Close();

                    return empleado;
                }
            }

        }
        #endregion

        #region snippet_GetTipoUsuario
        public string GetTipoUsuario(int id)
        {
            using (var con = conexion.GetCadenaConexion())
            {
                string query = $"SELECT TipoUsuario FROM Empleados WHERE IdEmpleado = {id}";

                using (var cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    string tipoUsuario = string.Empty;

                    if (dr.Read())
                    {
                        tipoUsuario = dr["TipoUsuario"].ToString();
                    }
                    dr.Close();
                    con.Close();

                    return tipoUsuario;
                }
            }
        }
        #endregion

        #region snippet_IsId
        public bool IsId(int id)
        {
            using (var con = conexion.GetCadenaConexion())
            {
                string query = $"SELECT * FROM Empleados WHERE IdEmpleado = {id}";

                using (var cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    bool resultado = false;

                    if (dr.Read())
                    {
                        resultado = true;
                    }
                    dr.Close();
                    con.Close();

                    return resultado;
                }
            }
        }
        #endregion

        #region snippet_IsContrasena
        public string IsContrasena(int id)
        {
            using (var con = conexion.GetCadenaConexion())
            {
                string query = $"SELECT Contrasena FROM Empleados WHERE IdEmpleado = {id}";

                using (var cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    string contrasena = string.Empty;

                    if (dr.Read())
                    {
                        contrasena = dr["Contrasena"].ToString();
                    }
                    dr.Close();
                    con.Close();

                    return contrasena;
                }
            }
        }
        #endregion

        //[POST]
        #region snippet_CreateId
        public int CreateId()
        {
            using (var con = conexion.GetCadenaConexion())
            {
                string query = "SELECT * FROM Empleados ORDER BY IdEmpleado";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    int id = 0;
                    while (dr.Read())
                    {
                        id = int.Parse(dr["IdEmpleado"].ToString());
                    }
                    dr.Close();
                    con.Close();

                    if (id != 0)
                    {
                        return id + 1;
                    }
                    else
                    {
                        return 100000;
                    }
                }
            }
        }
        #endregion

        #region snippet_Create
        public void Create(Empleados empleado)
        {
            using (var cadenaConexion = conexion.GetCadenaConexion())
            {
                string query = $"INSERT Empleados VALUES ("
                    + $" {empleado.GetIdEmpleado}, '{empleado.GetNombreEmpleado}',"
                    + $" '{empleado.GetApellidoEmpleado}', '{empleado.GetSexoEmpleado}',"
                    + $" '{empleado.GetTelefonoEmpleado}', '{empleado.GetDireccionEmpleado}',"
                    + $" '{empleado.GetTipoUsuario}', {empleado.GetEdadEmpleado},"
                    + $" '{empleado.GetFechaIngreso}', '{empleado.GetContrasenaEmpleado}' )";

                using (SqlCommand cmd = new SqlCommand(query, cadenaConexion))
                {
                    cadenaConexion.Open();
                    cmd.ExecuteNonQuery();
                    cadenaConexion.Close();
                }
            }
        }
        #endregion

        //[PUT]
        #region snippet_Update
        public void Update(Empleados empleado)
        {
            using (var con = conexion.GetCadenaConexion())
            {
                string query = $"UPDATE Empleados SET NombreEmpleado = '{empleado.GetNombreEmpleado}',"
                    + $" ApellidoEmpleado = '{empleado.GetApellidoEmpleado}', EdadEmpleado = {empleado.GetEdadEmpleado},"
                    + $" TelefonoEmpleado = '{empleado.GetTelefonoEmpleado}', SexoEmpleado = '{empleado.GetSexoEmpleado}',"
                    + $" TipoUsuario = '{empleado.GetTipoUsuario}', DireccionEmpleado = '{empleado.GetDireccionEmpleado}'"
                    + $" WHERE IdEmpleado = {empleado.GetIdEmpleado}";

                using (var cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
        }
        #endregion

        #region snippet_UpdateContrasena
        public void UpdateContrasena(int id, string nuevaContrasena)
        {
            using (var con = conexion.GetCadenaConexion())
            {
                string query = $"UPDATE Empleados SET Contrasena = '{nuevaContrasena}' WHERE IdEmpleado = {id}";

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
                string query = $"DELETE FROM Empleados WHERE IdEmpleado = {id}";

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
