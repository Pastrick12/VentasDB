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

        private void CargarProductos(string consultar = "")
        {
            try
            {
                Producto producto = new Producto();
                DataTable dtProductos = null;

                if (string.IsNullOrWhiteSpace(consultar))
                
                {
                     dtProductos = producto.ObtenerTodos();
                }
                
                else
 
                {
                     dtProductos = producto.Consultar(consultar.Trim());
                }

                dgvProductos.DataSource = dtProductos;
            }
            catch (Exception ex)
            {

                MessageBox.Show($"Ocurrio un error al cargar productos {ex.Message}");
            }
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            try
            {
                CargarProductos(txtConsultar.Text);
            }
            catch (Exception ex)
            {

                MessageBox.Show($"Ocurrio un error al cargar productos {ex.Message}");
            }
        }
    }
}
