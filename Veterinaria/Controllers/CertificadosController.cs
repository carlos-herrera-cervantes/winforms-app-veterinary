using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocumentFormat.OpenXml.Packaging;
using Veterinaria.Models;
using System.IO;
using System.Data.SqlClient;

namespace Veterinaria.Controllers
{
    class CertificadosController
    {
        #region snippet_Instances
        private Conexiones conexion = new Conexiones();
        #endregion

        //[GET]
        #region snippet_GetAll
        public List<Certificados> GetAll()
        {
            using (var con = conexion.GetCadenaConexion())
            {
                string query = "SELECT * FROM Certificados";

                using (var cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    var certificados = new List<Certificados>();

                    while (dr.Read())
                    {
                        certificados.Add(
                            new Certificados(
                                int.Parse(dr["Folio"].ToString()),
                                dr["NombreMascota"].ToString(),
                                dr["Especie"].ToString(),
                                dr["Raza"].ToString(),
                                dr["FechaNacimiento"].ToString(),
                                int.Parse(dr["Edad"].ToString()),
                                dr["Color"].ToString(),
                                dr["Sexo"].ToString(),
                                dr["NombreCliente"].ToString(),
                                dr["DireccionCliente"].ToString(),
                                dr["TelefonoCliente"].ToString(),
                                dr["FechaCertificado"].ToString(),
                                int.Parse(dr["IdMascota"].ToString())
                            )
                        );
                    }
                    dr.Close();
                    con.Close();

                    return certificados;
                }
            }
        }
        #endregion

        //[POST]
        #region snippet_Create
        public void Create(Certificados certificado)
        {
            using (var con = conexion.GetCadenaConexion())
            {
                string query = $"INSERT Certificados VALUES ("
                    + $" {certificado.GetFolio}, '{certificado.GetNombreMascota}',"
                    + $" '{certificado.GetEspecie}', '{certificado.GetRaza}',"
                    + $" '{certificado.GetFechaNacimiento}', {certificado.GetEdad},"
                    + $" '{certificado.GetColor}', '{certificado.GetSexo}',"
                    + $" '{certificado.GetNombreCliente}', '{certificado.GetDireccionCliente}',"
                    + $" '{certificado.GetTelefonoCliente}', '{certificado.GetFechaCertificado}',"
                    + $" {certificado.GetIdMascota} )";

                using (var cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    cmd.Clone();
                }
            }
        }
        #endregion

        #region snippet_CreateId
        public int CreateId()
        {
            using (var con = conexion.GetCadenaConexion())
            {
                string query = "SELECT * FROM Certificados ORDER BY Folio";

                using (var cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    SqlDataReader r = cmd.ExecuteReader();
                    int id = 0;
                    while (r.Read())
                    {
                        id = int.Parse(r["Folio"].ToString());
                    }
                    r.Close();
                    con.Close();

                    if (id != 0)
                    {
                        return id + 1;
                    }
                    else
                    {
                        return 600000;
                    }
                }
            }
        }
        #endregion
    }
}
