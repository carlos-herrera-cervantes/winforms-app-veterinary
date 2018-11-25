using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Veterinaria.Models
{
    class Tratamientos
    {
        #region snippet_Properties
        private int IdTratamiento;
        private string NombreMascota;
        private float PesoMascota;
        private string NombreCliente;
        private string Tratamiento;
        private string FechaTratamiento;
        #endregion

        #region snippet_ForeignKeys
        private int IdMascota;
        #endregion

        #region snippet_Constructor
        public Tratamientos()
        {

        }

        public Tratamientos(int idTratamiento, string nombreMascota, float pesoMascota, string nombreCliente, string tratamiento, string fechaTratamiento, int idMascota)
        {
            IdTratamiento = idTratamiento;
            NombreMascota = nombreMascota;
            PesoMascota = pesoMascota;
            NombreCliente = nombreCliente;
            Tratamiento = tratamiento;
            FechaTratamiento = fechaTratamiento;
            IdMascota = idMascota;
        }
        #endregion

        #region snippet_GetIdTratamiento
        public int GetIdTratamiento
        {
            get
            {
                return IdTratamiento;
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

        #region snippet_GetPesoMascota
        public float GetPesoMascota
        {
            get
            {
                return PesoMascota;
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

        #region snippet_GetTratamiento
        public string GetTratamiento
        {
            get
            {
                return Tratamiento;
            }
        }
        #endregion

        #region snippet_GetFechaTratamiento
        public string GetFechaTratamiento
        {
            get
            {
                return FechaTratamiento;
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
