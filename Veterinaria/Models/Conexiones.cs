using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Veterinaria.Models
{
    class Conexiones
    {
        #region snippet_Properties
        private SqlConnection CadenaConexion { get; set; }
        #endregion

        #region snippet_GetCadenaConexion
        public SqlConnection GetCadenaConexion()
        {
            SqlConnection cadenaConexion = new SqlConnection(@"Data Source = CARLOS-ELEKTRA\SQLEXPRESS; Initial catalog = Veterinaria; Integrated Security = True");

            CadenaConexion = cadenaConexion;

            return CadenaConexion;
        }
        #endregion
    }
}
