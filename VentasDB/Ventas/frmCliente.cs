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
    public partial class frmCliente : Form
    {
        public frmCliente()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                Cliente cliente = new Cliente();
                cliente.Codigo = txtCodigo.Text;
                cliente.RFC = txtRFC.Text;
                cliente.Nombre = txtNombre.Text;
                cliente.Agregar(cliente);

                MessageBox.Show("Cliente agregado correctamente");
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
                Cliente cliente = new Cliente();
                cliente.Id = int.Parse(txtId.Text);
                cliente.Codigo = txtCodigo.Text;
                cliente.RFC = txtRFC.Text;
                cliente.Nombre = txtNombre.Text;
                cliente.Actualizar(cliente);

                MessageBox.Show("Cliente actualizado correctamente.");
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
                Cliente cliente = new Cliente();
                cliente.Eliminar(int.Parse(txtId.Text));

                MessageBox.Show("Cliente eliminado correctamente.");
            }
            catch (Exception ex)
            {

                MessageBox.Show($"Error {ex.Message}");
            }
        }
    }
}
