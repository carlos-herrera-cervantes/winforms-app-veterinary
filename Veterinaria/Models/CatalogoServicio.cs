using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Veterinaria.Models
{
    class CatalogoServicio
    {
        #region snippet_Properties
        private int IdServicio;
        private string NombreServicio;
        private string DescripcionServicio;
        private float Costo;
        #endregion

        #region snippet_Constructors
        public CatalogoServicio()
        {

        }

        public CatalogoServicio(string nombreServicio)
        {
            NombreServicio = nombreServicio;
        }

        public CatalogoServicio(int idServicio, string nombreServicio, string descripcionServicio, float costo)
        {
            IdServicio = idServicio;
            NombreServicio = nombreServicio;
            DescripcionServicio = descripcionServicio;
            Costo = costo;
        }
        #endregion

        #region snippet_GetIdServicio
        public int GetIdServicio
        {
            get
            {
                return IdServicio;
            }
        }
        #endregion

        #region snippet_GetNombreServicio
        public string GetNombreServicio
        {
            get
            {
                return NombreServicio;
            }
        }
        #endregion

        #region snippet_GetDescripcionServicio
        public string GetDescripcionServicio
        {
            get
            {
                return DescripcionServicio;
            }
        }
        #endregion

        #region snippet_GetCosto
        public float GetCosto
        {
            get
            {
                return Costo;
            }
        }
        #endregion
    }
}
