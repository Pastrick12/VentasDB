using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ventas.Entidades;

namespace Ventas
{
    public partial class frmProducto : Form
    {
        public frmProducto()
        {
            InitializeComponent();
            CargarCatalogos();
        }
        
        private void CargarCatalogos()
        {
            try
            {
                ProductoCategoria categoria = new ProductoCategoria();
                DataTable dtCategorias = categoria.ObtenerTodos();

                cmbCategorias.DataSource = dtCategorias;
                cmbCategorias.DisplayMember = "Descripcion";
                cmbCategorias.ValueMember = "Id";
            }
            catch (Exception ex)
            {

                MessageBox.Show($"Ocurrio un error al cargar catalogos {ex.Message}");
            }
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                Producto producto = new Entidades.Producto();
                producto.CodigoBarras = txtCodigoBarras.Text;
                producto.Codigo = txtCodigo.Text;
                producto.Descripcion = txtDescripcion.Text;
                producto.CategoriaId = Convert.ToInt32(cmbCategorias.SelectedValue);
                producto.Agregar(producto);

                MessageBox.Show("Producto agregado correctamente");
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
                Entidades.Producto producto = new Entidades.Producto();
                producto.Id = int.Parse(txtId.Text);
                producto.CodigoBarras = txtCodigoBarras.Text;
                producto.Codigo = txtCodigo.Text;
                producto.Descripcion = txtDescripcion.Text;
                //producto.CategoriaId = int.Parse(txtCategoriaId.Text);
                producto.Actualizar(producto);

                MessageBox.Show("Producto actualizado correctamente");
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
                Entidades.Producto producto = new Entidades.Producto();
                producto.Id = int.Parse(txtId.Text);
                producto.Eliminar(int.Parse(txtId.Text));

                MessageBox.Show("Producto eliminado correctamente");
            }
            catch (Exception ex)
            {

                MessageBox.Show($"Error {ex.Message}");
            }
        }

        private void frmProducto_Load(object sender, EventArgs e)
        {

        }

        private void txtId_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
