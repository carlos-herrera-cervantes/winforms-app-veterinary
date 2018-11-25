using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Veterinaria.Models
{
    class Consultas
    {
        #region snippet_Properties
        private int IdConsulta;
        private string FechaConsulta;
        private string Padecimiento;
        private string TipoPadecimiento;
        #endregion

        #region snippet_ForeignKeys
        private int IdMascota;
        #endregion

        #region snippet_Constructor
        public Consultas()
        {

        }

        public Consultas(int idConsulta, string fechaConsulta, string padecimiento, string tipoPadecimiento, int idMascota)
        {
            IdConsulta = idConsulta;
            FechaConsulta = fechaConsulta;
            Padecimiento = padecimiento;
            TipoPadecimiento = tipoPadecimiento;
            IdMascota = idMascota;
        }
        #endregion

        #region snippet_GetIdConsulta
        public int GetIdConsulta
        {
            get
            {
                return IdConsulta;
            }
        }
        #endregion

        #region snippet_GetFechaConsulta
        public string GetFechaConsulta
        {
            get
            {
                return FechaConsulta;
            }
        }
        #endregion

        #region snippet_GetPadecimiento
        public string GetPadecimiento
        {
            get
            {
                return Padecimiento;
            }
        }
        #endregion

        #region snippet_GetTipoPadecimiento
        public string GetTipoPadecimiento
        {
            get
            {
                return TipoPadecimiento;
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
