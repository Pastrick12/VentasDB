using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ventas.Entidades
{
    internal class Producto
    {
        private string _connectionString;
        public int Id { get; set; }
        public string CodigoBarras { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set;}
        public int CategoriaId { get; set; }

        public Producto()
        {
            _connectionString = "Server=localhost;Database=VentasDB;Trusted_Connection=True;TrustServerCertificate=True";
        }

        public void Agregar(Producto producto)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    string query = "insert into Productos" +
                        "(CodigoBarras,Codigo,Descripcion,CategoriaId) " +
                        "values " + "(@CodigoBarras,@Codigo,@Descripcion,@CategoriaId)";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.CommandType = System.Data.CommandType.Text;

                        cmd.Parameters.AddWithValue("@CodigoBarras", producto.CodigoBarras);
                        cmd.Parameters.AddWithValue("@Codigo", producto.Codigo);
                        cmd.Parameters.AddWithValue("@Descripcion", producto.Descripcion);
                        cmd.Parameters.AddWithValue("@CategoriaId", producto.CategoriaId);

                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Actualizar(Producto producto)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    string query = "UPDATE Productos" +
                        " SET " +
                        " CodigoBarras = @CodigoBarras," +
                        "Codigo = @Codigo, " +
                        "Descripcion = @Descripcion, " +
                        "Categoria = @CategoriaId, " +
                        " WHERE " + 
                        " Id = @Id";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.CommandType= System.Data.CommandType.Text;

                        cmd.Parameters.AddWithValue("@Id", producto.Id);
                        cmd.Parameters.AddWithValue("@CodigoBarras", producto.CodigoBarras);
                        cmd.Parameters.AddWithValue("@Codigo", producto.Codigo);
                        cmd.Parameters.AddWithValue("@Descripcion", producto.Descripcion);
                        cmd.Parameters.AddWithValue("@CategoriaId", producto.CategoriaId);

                        con.Open();
                        cmd.ExecuteNonQuery();

                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Eliminar (int id)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    string query = "DELETE FROM Productos" +
                        " WHERE " + 
                        " Id = @Id";

                    using ( SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.CommandType = System.Data.CommandType.Text;

                        cmd.Parameters.AddWithValue ("@Id", id);

                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }


        }

        public DataTable ObtenerTodos()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    string query = "SELECT Id, CodigoBarras, Codigo, Descripcion, CategoriaId, " +
                        "(Select Descripcion From ProductosCategoria Where ProductosCategoria.Id = Productos.CategoriaId) AS Categoria" +
                        " FROM Productos";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.CommandType = System.Data.CommandType.Text;

                        con.Open();

                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        return dt;
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
