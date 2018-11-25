using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Veterinaria.Models
{
    class Documento
    {
        #region snipppet_Properties
        private string CadenaInicial;
        private string CadenaFinal;
        private string Ruta;
        #endregion

        #region snippet_Constructor
        public Documento()
        {

        }
        public Documento(string cadenaIncial, string cadenaFinal, string ruta)
        {
            CadenaInicial = cadenaIncial;
            CadenaFinal = cadenaFinal;
            Ruta = ruta;
        }
        #endregion

        #region snippet_GetCadenaIncial
        public string GetCadenaInicial
        {
            get
            {
                return CadenaInicial;
            }
        }
        #endregion

        #region snippet_GetCadenaFinal
        public string GetCadenaFinal
        {
            get
            {
                return CadenaFinal;
            }
        }
        #endregion

        #region snippet_GetRuta
        public string GetRuta
        {
            get
            {
                return Ruta;
            }
        }
        #endregion
    }
}
