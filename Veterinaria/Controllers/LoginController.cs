using System.Data.SqlClient;
using Veterinaria.Models;

namespace Veterinaria.Controllers
{
    class LoginController
    {
        #region snippet_Instances
        private Conexiones Conexiones = new Conexiones();
        #endregion

        //[GET]
        #region snippet_GetIdEmpleado
        public bool GetIdEmpleado(int id)
        {
            using (var con = Conexiones.GetCadenaConexion())
            {
                string query = $"SELECT * FROM Empleados WHERE IdEmpleado = id";

                using (var cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    var resultado = false;
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

        #region snippet_GetContrasenaEmpleado
        public bool GetContrasenaEmpleado(string contrasena)
        {
            using (var con = Conexiones.GetCadenaConexion())
            {
                string query = $"SELECT * FROM Empleados WHERE Contrasena LIKE '{contrasena}'";

                using (var cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    var resultado = false;
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
    }
}
