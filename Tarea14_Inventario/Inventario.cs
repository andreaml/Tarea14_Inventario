using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarea14_Inventario
{
    class Inventario
    {
        private Producto[] _miInventario = new Producto[15];
        public Producto[] miInventario { get { return _miInventario; } }
        private int conteoInventario = 0;

        public Inventario()
        {
            for (int i = 0; i < 15; i++)
            {
                _miInventario[i] = null;
            }
        }

        public void agregarProducto(Producto productoNuevo)
        {
            bool productoAgregado = false;
            int contador = 0;
            while(productoAgregado != true && conteoInventario < 16)
            {
                if(_miInventario[contador++] == null)
                {
                    _miInventario[--contador] = productoNuevo;
                    conteoInventario++;
                    productoAgregado = true;
                }
            }
        }

        public void insertarProducto(Producto productoNuevo, int posicion)
        {
            bool productoAgregado = false;
            int contador = 0;
            if(posicion < 15)
            {
                while (productoAgregado != true && conteoInventario < 16)
                {
                    if (contador <= posicion && _miInventario[contador] == null)
                    {
                        for (int i = contador; i < posicion - 1; i++)
                        {
                            _miInventario[i] = _miInventario[i + 1];
                        }
                        _miInventario[posicion] = productoNuevo;
                        conteoInventario++;
                        productoAgregado = true;
                    }
                    else if (contador > posicion && _miInventario[contador] == null)
                    {
                        for (int i = 14; i > posicion; i--)
                        {
                            _miInventario[i] = _miInventario[i - 1];
                        }
                        _miInventario[posicion] = productoNuevo;
                        conteoInventario++;
                        productoAgregado = true;
                    }
                    contador++;
                }
            }
        }

        private int _buscarProducto(int codigoProducto)
        {
            int producto = -1;
            bool productoEncontrado = false;
            int contador = 0;
            while (productoEncontrado != true)
            {
                if (_miInventario[contador++] != null && _miInventario[contador++].codigo  == codigoProducto)
                {
                    producto = --contador;
                    productoEncontrado = true;
                }
            }
            return producto;
        }

        public Producto buscarProducto(int codigoProducto)
        {
            Producto producto = null;
            int busquedaProducto = _buscarProducto(codigoProducto);
            if (busquedaProducto > -1)
                producto = _miInventario[busquedaProducto];
            return producto;
        }

        public string borrarProducto(int codigoProducto)
        {
            string mensaje = "Producto no encontrado";
            int busquedaProducto = _buscarProducto(codigoProducto);
            if (busquedaProducto > -1)
            {
                _miInventario[busquedaProducto] = null;
                mensaje = "Producto eliminado";
            }
            return mensaje;
        }

        public string reporte()
        {
            string reporte = "";
            foreach (Producto item in _miInventario)
            {
                if (item != null)
                    reporte += item.ToString() + Environment.NewLine + "--------------------------" + Environment.NewLine;
            }
            return reporte;
        }
    }
}
