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
    public partial class frmProductos : Form
    {
        public frmProductos()
        {
            InitializeComponent();
            CargarProductos();
        }

        private void CargarProductos()
        {
            try
            {
                Producto producto = new Producto();
                DataTable dtProductos = producto.ObtenerTodos();

                dgvProductos.DataSource = dtProductos;
            }
            catch (Exception ex)
            {

                MessageBox.Show($"Ocurrio un error al cargar productos {ex.Message}");
            }
        }
    }
}
