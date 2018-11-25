using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Veterinaria.Models
{
    class Ventas
    {
        #region snippet_Properties
        private int IdVenta;
        private string FechaVenta;
        private int NoProductos;
        private float Total;
        private float Pago;
        private float Cambio;
        #endregion

        #region snippet_Constructors
        public Ventas()
        {

        }

        public Ventas(int idVenta, string fechaVenta, int noProductos, float total, float pago, float cambio)
        {
            IdVenta = idVenta;
            FechaVenta = fechaVenta;
            NoProductos = noProductos;
            Total = total;
            Pago = pago;
            Cambio = cambio;
        }
        #endregion

        #region snippet_GetIdVenta
        public int GetIdVenta
        {
            get
            {
                return IdVenta;
            }
        }
        #endregion

        #region snippet_GetFechaVenta
        public string GetFechaVenta
        {
            get
            {
                return FechaVenta;
            }
        }
        #endregion

        #region snippet_GetNoProductos
        public int GetNoProductos
        {
            get
            {
                return NoProductos;
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
    }
}
