using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Veterinaria.Models
{
    class DetalleVenta
    {
        #region snippet_Properties
        private int IdVenta;
        private string NombreProducto;
        private string Unidad;
        private float Cantidad;
        private float Precio;
        #endregion

        #region snippet_ForeignKeys
        private int IdProducto;
        #endregion

        #region snippet_Constructors
        public DetalleVenta()
        {

        }

        public DetalleVenta(int idVenta, string nombreProducto, string unidad, float cantidad, float precio, int idProducto)
        {
            IdVenta = idVenta;
            NombreProducto = nombreProducto;
            Unidad = unidad;
            Cantidad = cantidad;
            Precio = precio;
            IdProducto = idProducto;
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

        #region snippet_GetNombreProducto
        public string GetNomnreProducto
        {
            get
            {
                return NombreProducto;
            }
        }
        #endregion

        #region snippet_GetUnidad
        public string GetUnidad
        {
            get
            {
                return Unidad;
            }
        }
        #endregion

        #region snippet_GetCantidad
        public float GetCantidad
        {
            get
            {
                return Cantidad;
            }
        }
        #endregion

        #region snippet_GetPrecio
        public float GetPrecio
        {
            get
            {
                return Precio;
            }
        }
        #endregion

        #region snippet_GetIdProducto
        public int GetIdProducto
        {
            get
            {
                return IdProducto;
            }
        }
        #endregion
    }
}
