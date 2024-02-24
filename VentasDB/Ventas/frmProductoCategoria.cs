using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ventas.Entidades
{
    public partial class frmProductoCategoria : Form
    {
        public frmProductoCategoria()
        {
            InitializeComponent();
        }

        private void ProductosCategorias_Load(object sender, EventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                ProductoCategoria productocategoria = new ProductoCategoria();
                productocategoria.Descripcion = txtDescripcion.Text;
                productocategoria.Agregar(productocategoria);

                MessageBox.Show("Categoria agregada correctamente");

            }
            catch (Exception ex)
            {

                MessageBox.Show($"Error {ex.Message}");
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                ProductoCategoria productocategoria = new ProductoCategoria();
                productocategoria.Id = int.Parse(txtId.Text);
                productocategoria.Descripcion = txtDescripcion.Text;
                productocategoria.Actualizar(productocategoria);

                MessageBox.Show("Categoria actualizada correctamente.");
            }
            catch (Exception ex)
            {

                MessageBox.Show($"Error {ex.Message}");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                ProductoCategoria cliente = new ProductoCategoria();
                cliente.Eliminar(int.Parse(txtId.Text));

                MessageBox.Show("Categoria eliminada correctamente.");
            }
            catch (Exception ex)
            {

                MessageBox.Show($"Error {ex.Message}");
            }
        }
    }
}
