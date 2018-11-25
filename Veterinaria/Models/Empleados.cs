using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Veterinaria.Models
{
    class Empleados
    {
        #region snippet_Propiedades
        private int IdEmpleado;
        private string NombreEmpleado;
        private string ApellidoEmpleado;
        private string SexoEmpleado;
        private string TelefonoEmpleado;
        private string DireccionEmpleado;
        private string TipoUsuario;
        private int EdadEmpleado;
        private string FechaIngreso;
        private string Contrasena;
        #endregion

        #region snippet_Constructor
        public Empleados()
        {

        }
        public Empleados(int idEmpleado, string nombre, string apellido, string sexo, string telefono, string direccion, string tipoUsuario, int edad, string fechaIngreso, string contrasena)
        {
            IdEmpleado = idEmpleado;
            NombreEmpleado = nombre;
            ApellidoEmpleado = apellido;
            SexoEmpleado = sexo;
            TelefonoEmpleado = telefono;
            DireccionEmpleado = direccion;
            TipoUsuario = tipoUsuario;
            EdadEmpleado = edad;
            FechaIngreso = fechaIngreso;
            Contrasena = contrasena;
        }
        #endregion

        #region snippet_GetIdEmpleado
        public int GetIdEmpleado
        {
            get
            {
                return IdEmpleado;
            }
        }
        #endregion

        #region snippet_GetNombreEmpleado
        public string GetNombreEmpleado
        {
            get
            {
                return NombreEmpleado;
            }
        }
        #endregion

        #region snippet_GetApellidoEmpleado
        public string GetApellidoEmpleado
        {
            get
            {
                return ApellidoEmpleado;
            }
        }
        #endregion

        #region snippet_GetSexoEmpleado
        public string GetSexoEmpleado
        {
            get
            {
                return SexoEmpleado;
            }
        }
        #endregion

        #region snippet_GetTelefonoEmpleado
        public string GetTelefonoEmpleado
        {
            get
            {
                return TelefonoEmpleado;
            }
        }
        #endregion

        #region snippet_GetDireccionEmpleado
        public string GetDireccionEmpleado
        {
            get
            {
                return DireccionEmpleado;
            }
        }
        #endregion

        #region snippet_GetTipoUsuario
        public string GetTipoUsuario
        {
            get
            {
                return TipoUsuario;
            }
        }
        #endregion

        #region snippet_GetEdadEmpleado
        public int GetEdadEmpleado
        {
            get
            {
                return EdadEmpleado;
            }
        }
        #endregion

        #region snippet_GetFechaIngreso
        public string GetFechaIngreso
        {
            get
            {
                return FechaIngreso;
            }
        }
        #endregion

        #region snippet_GetContrasenaEmpleado
        public string GetContrasenaEmpleado
        {
            get
            {
                return Contrasena;
            }
        }
        #endregion
    }
}