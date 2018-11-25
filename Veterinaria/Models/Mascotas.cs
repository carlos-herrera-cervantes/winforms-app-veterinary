using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Veterinaria.Models
{
    class Mascotas
    {
        #region snippet_Properties
        private int IdMascota;        
        private string NombreMascota;
        private string Especie;
        private string Raza;
        private int EdadMascota;
        private string SexoMascota;
        private string Color;
        private float Peso;
        private string FechaNacimiento;
        private string FechaRegistro;
        #endregion

        #region snippet_ForeignKeys
        private int IdCliente;
        #endregion

        #region snippet_Constructors
        public Mascotas()
        {

        }

        public Mascotas(int idMascota, string nombreMascota, string especie, string raza, int edadMascota, string sexoMascota, string color, float peso, string fechaNacimiento)
        {
            IdMascota = idMascota;
            NombreMascota = nombreMascota;
            Especie = especie;
            Raza = raza;
            EdadMascota = edadMascota;
            SexoMascota = sexoMascota;
            Color = color;
            Peso = peso;
            FechaNacimiento = fechaNacimiento;
        }

        public Mascotas(int idMascota, string nombreMascota, string especie, string raza, int edadMascota, string sexoMascota, string color, float peso, string fechaNacimiento, string fechaRegistro, int idCliente)
        {
            IdMascota = idMascota;
            NombreMascota = nombreMascota;
            Especie = especie;
            Raza = raza;
            EdadMascota = edadMascota;
            SexoMascota = sexoMascota;
            Color = color;
            Peso = peso;
            FechaNacimiento = fechaNacimiento;
            FechaRegistro = fechaRegistro;
            IdCliente = idCliente;
        }
        #endregion

        #region snipper_GetIdMascota
        public int GetIdMascota
        {
            get
            {
                return IdMascota;
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

        #region snippet_GetEdadMascota
        public int GetEdadMascota
        {
            get
            {
                return EdadMascota;
            }
        }
        #endregion

        #region snippet_GetSexoMascota
        public string GetSexoMascota
        {
            get
            {
                return SexoMascota;
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

        #region snippet_GetPeso
        public float GetPeso
        {
            get
            {
                return Peso;
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

        #region snippet_GetFechaRegistro
        public string GetFechaRegistro
        {
            get
            {
                return FechaRegistro;
            }
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
    }
}
