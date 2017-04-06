using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tarea14_Inventario
{
    public partial class frmPantallaPrincipal : Form
    {
        public frmPantallaPrincipal()
        {
            InitializeComponent();
        }

        Inventario miInventario = new Inventario();

        private void btnInsertarProducto_Click(object sender, EventArgs e)
        {
            Producto miProducto = new Producto(Convert.ToInt16(txtCodigoProducto.Text), txtNombreProducto.Text, Convert.ToSingle(txtPrecioProducto.Text), Convert.ToInt16(txtCantidadProducto.Text));
            miInventario.insertarProducto(miProducto, Convert.ToInt16(txtPosicion.Text));
        }

        private void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            Producto miProducto = new Producto(Convert.ToInt16(txtCodigoProducto.Text), txtNombreProducto.Text, Convert.ToSingle(txtPrecioProducto.Text), Convert.ToInt16(txtCantidadProducto.Text));
            miInventario.agregarProducto(miProducto);
        }

        private void btnBorrarProducto_Click(object sender, EventArgs e)
        {
           MessageBox.Show(miInventario.borrarProducto(Convert.ToInt16(txtCodigoProducto.Text)));
        }

        private void btnBuscarProducto_Click(object sender, EventArgs e)
        {
            MessageBox.Show(miInventario.buscarProducto(Convert.ToInt16(txtCodigoProducto.Text)).ToString());
        }

        private void btnReporteInventario_Click(object sender, EventArgs e)
        {
            txtReporte.Text = miInventario.reporte();
        }
    }
}
