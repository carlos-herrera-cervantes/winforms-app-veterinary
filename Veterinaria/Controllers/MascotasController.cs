using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Veterinaria.Models;
using System.Data.SqlClient;

namespace Veterinaria.Controllers
{
    class MascotasController
    {
        #region snippet_Instances
        Conexiones conexion = new Conexiones();
        #endregion

        //[GET]
        #region snippet_GetAll
        public List<Mascotas> GetAll()
        {
            using (var con = conexion.GetCadenaConexion())
            {
                string query = "SELECT * FROM Mascotas";

                using (var cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    var mascotas = new List<Mascotas>();
                    while (dr.Read())
                    {
                        mascotas.Add(
                                new Mascotas(
                                        int.Parse(dr["IdMascota"].ToString()), 
                                        dr["NombreMascota"].ToString(), 
                                        dr["Especie"].ToString(),
                                        dr["Raza"].ToString(), 
                                        int.Parse(dr["EdadMascota"].ToString()), 
                                        dr["SexoMascota"].ToString(),
                                        dr["Color"].ToString(), 
                                        float.Parse(dr["Peso"].ToString()), 
                                        dr["FechaNacimiento"].ToString(), 
                                        dr["FechaRegistro"].ToString(),
                                        int.Parse(dr["IdCliente"].ToString())
                                    ));
                    }
                    dr.Close();
                    con.Close();

                    return mascotas;
                }
            }
        }
        #endregion

        #region snippet_GetById
        public Mascotas GetById(int id)
        {
            using (var con = conexion.GetCadenaConexion())
            {
                string query = $"SELECT * FROM Mascotas WHERE IdMascota = {id}";

                using (var cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    Mascotas mascota = new Mascotas();
                    if (dr.Read())
                    {
                        mascota = new Mascotas(
                                int.Parse(dr["IdMascota"].ToString()), 
                                dr["NombreMascota"].ToString(), 
                                dr["Especie"].ToString(), 
                                dr["Raza"].ToString(),
                                int.Parse(dr["EdadMascota"].ToString()), 
                                dr["SexoMascota"].ToString(), 
                                dr["Color"].ToString(), 
                                float.Parse(dr["Peso"].ToString()),
                                dr["FechaNacimiento"].ToString(), 
                                dr["FechaRegistro"].ToString(), 
                                int.Parse(dr["IdCliente"].ToString())
                            );
                    }
                    dr.Close();
                    con.Close();

                    return mascota;
                }
            }
        }
        #endregion

        #region snippet_GetByClienteId
        public List<Mascotas> GetByClienteId(int id)
        {
            using (var con = conexion.GetCadenaConexion())
            {
                string query = $"SELECT * FROM Mascotas WHERE IdCliente = {id} ORDER BY IdMascota";

                using (var cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    var mascotas = new List<Mascotas>();
                    while (dr.Read())
                    {
                        mascotas.Add(
                                new Mascotas(
                                        int.Parse(dr["IdMascota"].ToString()), 
                                        dr["NombreMascota"].ToString(), 
                                        dr["Especie"].ToString(),
                                        dr["Raza"].ToString(), 
                                        int.Parse(dr["EdadMascota"].ToString()), 
                                        dr["SexoMascota"].ToString(),
                                        dr["Color"].ToString(), 
                                        float.Parse(dr["Peso"].ToString()),
                                        dr["FechaNacimiento"].ToString(), 
                                        dr["FechaRegistro"].ToString(), 
                                        int.Parse(dr["IdCliente"].ToString())
                                    ));
                    }
                    dr.Close();
                    con.Close();

                    return mascotas;
                }
            }
        }
        #endregion

        #region snippet_GetByName
        public Mascotas GetByName(string nombre)
        {
            using (var con = conexion.GetCadenaConexion())
            {
                string query = $"SELECT * FROM Mascotas WHERE NombreMascota LIKE '{nombre}'";

                using (var cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    Mascotas mascota = new Mascotas();

                    if (dr.Read())
                    {
                        mascota = new Mascotas(
                                int.Parse(dr["IdMascota"].ToString()), 
                                dr["NombreMascota"].ToString(), 
                                dr["Especie"].ToString(), 
                                dr["Raza"].ToString(),
                                int.Parse(dr["EdadMascota"].ToString()), 
                                dr["SexoMascota"].ToString(), 
                                dr["Color"].ToString(), 
                                float.Parse(dr["Peso"].ToString()),
                                dr["FechaNacimiento"].ToString(), 
                                dr["FechaRegistro"].ToString(), 
                                int.Parse(dr["IdCliente"].ToString())
                            );
                    }
                    dr.Close();
                    con.Close();

                    return mascota;
                }
            }
        }
        #endregion

        #region snippet_IsExists
        public bool IsExists(int id)
        {
            using (var con = conexion.GetCadenaConexion())
            {
                string query = $"SELECT * FROM Mascotas WHERE IdMascota = {id}";

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

        //[POST]
        #region snippet_Create
        public void Create(Mascotas mascota)
        {
            using (var con = conexion.GetCadenaConexion())
            {
                string query = $"INSERT Mascotas VALUES ("
                    + $" {mascota.GetIdMascota}, {mascota.GetIdCliente},"
                    + $" '{mascota.GetNombreMascota}', '{mascota.GetEspecie}',"
                    + $" '{mascota.GetRaza}', {mascota.GetEdadMascota},"
                    + $" '{mascota.GetSexoMascota}', '{mascota.GetColor}',"
                    + $" {mascota.GetPeso}, '{mascota.GetFechaRegistro}',"
                    + $" '{mascota.GetFechaNacimiento}' )";

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
                string query = "SELECT * FROM Mascotas ORDER BY IdMascota";

                using (var cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    int id = 0;
                    while (dr.Read())
                    {
                        id = int.Parse(dr["IdMascota"].ToString());
                    }
                    dr.Close();
                    con.Close();

                    if (id != 0)
                    {
                        return id + 1;
                    }
                    else
                    {
                        return 300000;
                    }
                }
            }
        }
        #endregion

        //[PUT]
        #region snippet_Update
        public void Update(Mascotas mascota)
        {
            using (var con = conexion.GetCadenaConexion())
            {
                string query = $"UPDATE Mascotas SET NombreMascota = '{mascota.GetNombreMascota}',"
                    + $" Especie = '{mascota.GetEspecie}', Raza = '{mascota.GetRaza}',"
                    + $" Color = '{mascota.GetColor}', EdadMascota = {mascota.GetEdadMascota},"
                    + $" SexoMascota = '{mascota.GetSexoMascota}', FechaNacimiento = '{mascota.GetFechaNacimiento}'"
                    + $" WHERE IdMascota = '{mascota.GetIdMascota}'";

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
                string query = $"DELETE FROM Mascotas WHERE IdMascota = {id}";

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