using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Veterinaria.Models
{
    class CatalogoProductos
    {
        #region snippet_Properties
        private int IdProducto;
        private string NombreProducto;
        private float PrecioCompra;
        private float PrecioVenta;
        private string Unidad;
        private float Cantidad;
        #endregion

        #region snippet_Constructors
        public CatalogoProductos()
        {

        }

        public CatalogoProductos(int idProducto, string nombreProducto, float precioCompra, float precioVenta, string unidad, float cantidad)
        {
            IdProducto = idProducto;
            NombreProducto = nombreProducto;
            PrecioCompra = precioCompra;
            PrecioVenta = precioVenta;
            Unidad = unidad;
            Cantidad = cantidad;
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

        #region snippet_GetNomnbreProducto
        public string GetNombreProducto
        {
            get
            {
                return NombreProducto;
            }
        }
        #endregion

        #region snippet_GetPrecioCompra
        public float GetPrecioCompra
        {
            get
            {
                return PrecioCompra;
            }
        }
        #endregion

        #region snippet_GetPrecioVenta
        public float GetPrecioVenta
        {
            get
            {
                return PrecioVenta;
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
    }
}
