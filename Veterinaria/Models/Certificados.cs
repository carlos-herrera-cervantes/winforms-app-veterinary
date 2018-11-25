using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Veterinaria.Models
{
    class Certificados
    {
        #region snippet_Properties
        private int Folio;
        private string NombreMascota;
        private string Especie;
        private string Raza;
        private string FechaNacimiento;
        private int Edad;
        private string Color;
        private string Sexo;
        private string NombreCliente;
        private string DireccionCliente;
        private string TelefonoCliente;
        private string FechaCertificado;
        #endregion

        #region snippet_ForeignKeys
        private int IdMascota;
        #endregion

        #region snippet_Constructor
        public Certificados()
        {

        }

        public Certificados(int folio, string nombreMascota, string especie, string raza, string fechaNacimiento, int edad, string color, string sexo, string nombreCliente, string direccionCliente, string telefonoCliente, string fechaCertificado, int idMascota)
        {
            Folio = folio;
            NombreMascota = nombreMascota;
            Especie = especie;
            Raza = raza;
            FechaNacimiento = fechaCertificado;
            Edad = edad;
            Color = color;
            Sexo = sexo;
            NombreCliente = nombreCliente;
            DireccionCliente = direccionCliente;
            TelefonoCliente = telefonoCliente;
            FechaCertificado = fechaCertificado;
            IdMascota = idMascota;
        }
        #endregion

        #region snippet_GetFolio
        public int GetFolio
        {
            get
            {
                return Folio;
            }
        }
        #endregion

        #region snippet_GetNombreMascota
        public string GetNombreMascota
        {
            get
            {
                return NombreMascota;
            }
        }
        #endregion

        #region snippet_GetEspecie
        public string GetEspecie
        {
            get
            {
                return Especie;
            }
        }
        #endregion

        #region snippet_GetRaza
        public string GetRaza
        {
            get
            {
                return Raza;
            }
        }
        #endregion

        #region snippet_GetFechaNacimiento
        public string GetFechaNacimiento
        {
            get
            {
                return FechaNacimiento;
            }
        }
        #endregion

        #region snippet_GetEdad
        public int GetEdad
        {
            get
            {
                return Edad;
            }
        }
        #endregion

        #region snippet_GetColor
        public string GetColor
        {
            get
            {
                return Color;
            }
        }
        #endregion

        #region snippet_GetSexo
        public string GetSexo
        {
            get
            {
                return Sexo;
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

        #region snippet_GetDireccionCliente
        public string GetDireccionCliente
        {
            get
            {
                return DireccionCliente;
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

        #region snippet_GetFechaCertificado
        public string GetFechaCertificado
        {
            get
            {
                return FechaCertificado;
            }
        }
        #endregion

        #region snippet_GetIdMascota
        public int GetIdMascota
        {
            get
            {
                return IdMascota;
            }
        }
        #endregion
    }
}
