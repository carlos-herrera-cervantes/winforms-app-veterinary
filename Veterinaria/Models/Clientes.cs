using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Veterinaria.Models
{
    class Clientes
    {
        #region snippet_Properties
        private int IdCliente;
        private string NombreCliente;
        private string ApellidoCliente;
        private string SexoCliente;
        private string TelefonoCliente;
        private string DireccionCliente;
        private string CorreoCliente;
        private int EdadCliente;
        private string FechaRegistro;
        #endregion

        #region snippet_Constructors
        public Clientes()
        {

        }

        public Clientes(int idCliente)
        {
            IdCliente = idCliente;
        }

        public Clientes(int idCliente, string nombreCliente, string apellidoCliente, string sexoCliente, string telefonoCliente, string direccionCliente, string correoCliente, int edadCliente, string fechaRegistro)
        {
            IdCliente = idCliente;
            NombreCliente = nombreCliente;
            ApellidoCliente = apellidoCliente;
            SexoCliente = sexoCliente;
            TelefonoCliente = telefonoCliente;
            DireccionCliente = direccionCliente;
            CorreoCliente = correoCliente;
            EdadCliente = edadCliente;
            FechaRegistro = fechaRegistro;
        }
        #endregion

        #region snippet_GetIdCliente
        public int GetIdCliente
        {
            get
            {
                return IdCliente;
            }
        }
        #endregion

        #region snippet_GetNombreCliente
        public string GetNombreCliente
        {
            get
            {
                return NombreCliente;
            }
        }
        #endregion

        #region snippet_GetApellidoCliente
        public string GetApellidoCliente
        {
            get
            {
                return ApellidoCliente;
            }
        }
        #endregion

        #region snippet_GetSexoCliente
        public string GetSexoCliente
        {
            get
            {
                return SexoCliente;
            }
        }
        #endregion

        #region snippet_GetTelefonoCliente
        public string GetTelefonoCliente
        {
            get
            {
                return TelefonoCliente;
            }
        }
        #endregion

        #region snippet_GetDireccionCliente
        public string GetDireccionCliente
        {
            get
            {
                return DireccionCliente;
            }
        }
        #endregion

        #region snippet_GetCorreoCliente
        public string GetCorreoCliente
        {
            get
            {
                return CorreoCliente;
            }
        }
        #endregion

        #region snippet_GetEdadCliente
        public int GetEdadCliente
        {
            get
            {
                return EdadCliente;
            }
        }
        #endregion

        #region snippet_GetFechaRegistro
        public string GetFechaRegistro
        {
            get
            {
                return FechaRegistro;
            }
        }
        #endregion
    }
}
