using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Veterinaria.Models
{
    class Servicios
    {
        #region snippet_Properties
        private int IdRegistro;
        private string FechaRegistro;
        private string DescripcionServicio;
        private string DescripcionCostoAdicional;
        private float Costo;
        private float Descuento;
        private float CostoAdicional;
        private float Pago;
        private float Cambio;
        private float Total;
        #endregion

        #region snippet_ForeignKeys
        private int IdCliente;
        private int IdMascota;
        private int IdServicio;
        #endregion

        #region snippet_Constructor
        public Servicios()
        {

        }

        public Servicios(int idRegistro, string fechaRegistro, string descripcionServicio, string descripcionCostoAdicional, float costo, float descuento, float costoAdicional, float pago, float cambio, float total, int idCliente, int idMascota, int idServicio)
        {
            IdRegistro = idRegistro;
            FechaRegistro = fechaRegistro;
            DescripcionServicio = descripcionServicio;
            DescripcionCostoAdicional = descripcionCostoAdicional;
            Costo = costo;
            Descuento = descuento;
            CostoAdicional = costoAdicional;
            Pago = pago;
            Cambio = cambio;
            Total = total;
            IdCliente = idCliente;
            IdMascota = idMascota;
            IdServicio = idServicio;
        }
        #endregion

        #region snippet_GetIdRegistro
        public int GetIdRegistro
        {
            get
            {
                return IdRegistro;
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

        #region snippet_GetDescripcionServicio
        public string GetDescripionServicio
        {
            get
            {
                return DescripcionServicio;
            }
        }
        #endregion

        #region snippet_GetDescripcionCostoAdicional
        public string GetDescripcionCostoAdicional
        {
            get
            {
                return DescripcionCostoAdicional;
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

        #region snippet_GetDescuento
        public float GetDescuento
        {
            get
            {
                return Descuento;
            }
        }
        #endregion

        #region snippet_GetCostoAdicional
        public float GetCostoAdicional
        {
            get
            {
                return CostoAdicional;
            }
        }
        #endregion

        #region snippet_GetPago
        public float GetPago
        {
            get
            {
                return Pago;
            }
        }
        #endregion

        #region snippet_GetCambio
        public float GetCambio
        {
            get
            {
                return Cambio;
            }
        }
        #endregion

        #region snippet_GetTotal
        public float GetTotal
        {
            get
            {
                return Total;
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

        #region snippet_GetIdMascota
        public int GetIdMascota
        {
            get
            {
                return IdMascota;
            }
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
    }
}
