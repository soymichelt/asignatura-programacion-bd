using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

using PatronRepositorio.Helpers;
using PatronRepositorio.Entidades;

namespace PatronRepositorio.Repositorios {
	public class VentaRepositorioSQLServer : IAgregar<Venta>, IEliminar<Guid>, IListar<Venta, Guid> {

		SqlCommand sqlCmd;

		public Venta Agregar(Venta entidad) {
			entidad.ventaId = Guid.NewGuid();

			sqlCmd = new SqlCommand();
			SqlConnection cnn = SqlServerHelper.Connection();
			cnn.Open();
			using (SqlTransaction transaction = cnn.BeginTransaction()) {
				try
				{
					sqlCmd.Connection = cnn;
					sqlCmd.Transaction = transaction;
					sqlCmd.CommandText = "INSERT INTO ventas (ventaId, fecha, cliente, concepto, subtotal, iva, total) VALUES (@ventaId, @fecha, @cliente, @concepto, @subtotal, @iva, @total)";
					sqlCmd.Parameters.AddWithValue("@ventaId", entidad.ventaId);
					sqlCmd.Parameters.AddWithValue("@fecha", entidad.fecha);
					sqlCmd.Parameters.AddWithValue("@concepto", entidad.concepto);
					sqlCmd.Parameters.AddWithValue("@subtotal", entidad.subtotal);
					sqlCmd.Parameters.AddWithValue("@iva", entidad.iva);
					sqlCmd.Parameters.AddWithValue("@total", entidad.total);
					sqlCmd.ExecuteNonQuery();
					sqlCmd.Parameters.Clear();

					foreach (var detalle in entidad.VentasDetalles) {
						sqlCmd.CommandText = "INSERT INTO ventasDetalles (productoId, ventaId, cantidadVendido, precioProducto, total) VALUES (@productoId, @ventaId, @cantidadVendido, @precioProducto, @total)";
						sqlCmd.Parameters.AddWithValue("@productoId", detalle.productoId);
						sqlCmd.Parameters.AddWithValue("@ventaId", detalle.ventaId);
						sqlCmd.Parameters.AddWithValue("@cantidadVendido", detalle.cantidadVendido);
						sqlCmd.Parameters.AddWithValue("@precioProducto", detalle.precioProducto);
						sqlCmd.Parameters.AddWithValue("@total", detalle.total);
						sqlCmd.ExecuteNonQuery();
						sqlCmd.Parameters.Clear();

						sqlCmd.CommandText = "UPDATE productos SET cantidad = cantidad - @cantidadVendido WHERE productoId = @productoId";
						sqlCmd.Parameters.AddWithValue("@cantidad", detalle.cantidadVendido);
						sqlCmd.Parameters.AddWithValue("@productoId", detalle.productoId);
						sqlCmd.ExecuteNonQuery();
						sqlCmd.Parameters.Clear();
					}

					transaction.Commit();
				}
				catch (Exception ex)
				{
					transaction.Rollback();
					throw new Exception(ex.Message);
				}
				return entidad;
			}
		}

		public void Eliminar(Guid ventaId) {
			sqlCmd = new SqlCommand();
			SqlConnection cnn = SqlServerHelper.Connection();
			cnn.Open();
			using (SqlTransaction transaction = cnn.BeginTransaction()) {
				try {
					sqlCmd.CommandText = "DELETE FROM ventasDetalles ventaId = @ventaId";
					sqlCmd.Parameters.AddWithValue("@ventaId", ventaId);
					sqlCmd.ExecuteNonQuery();
					sqlCmd.Parameters.Clear();

					sqlCmd.CommandText = "DELETE FROM ventas WHERE ventaId = @ventaId";
					sqlCmd.Parameters.AddWithValue("@ventaId", ventaId);
					sqlCmd.ExecuteNonQuery();
					sqlCmd.Parameters.Clear();

					transaction.Commit();
				}
				catch (Exception ex) {
					transaction.Rollback();
					throw new Exception(ex.Message);
				}
			}
		}

		public List<Venta> Listar() {
			sqlCmd = new SqlCommand("SELECT * FROM ventas");
			SqlConnection cnn = SqlServerHelper.Connection();
			sqlCmd.Connection = cnn;
			cnn.Open();
			SqlDataReader reader = sqlCmd.ExecuteReader();

			List<Venta> ventas = new List<Venta>();
			if (reader.HasRows) {
				while (reader.Read()) {
					ventas.Add(new Venta() {
						ventaId = Guid.Parse(reader["ventaId"].ToString()),
						fecha = DateTime.Parse(reader["fecha"].ToString()),
						concepto = reader["concepto"].ToString(),
						Cliente = reader["cliente"].ToString(),
						subtotal = decimal.Parse(reader["subtotal"].ToString()),
						iva = decimal.Parse(reader["iva"].ToString()),
						total = decimal.Parse(reader["total"].ToString()),
					});
				}
			}

			return ventas;
		}

		public Venta Seleccionar(Guid ventaId) {
			sqlCmd = new SqlCommand();
			sqlCmd.CommandText = "SELECT * FROM ventas WHERE ventaId = @ventaId";
			SqlConnection cnn = SqlServerHelper.Connection();
			sqlCmd.Connection = cnn;
			cnn.Open();
			SqlDataReader reader = sqlCmd.ExecuteReader();

			Venta venta = null;
			if (reader.HasRows) {
				if (reader.Read()) {
					venta = new Venta() {
						ventaId = Guid.Parse(reader["ventaId"].ToString()),
						fecha = DateTime.Parse(reader["fecha"].ToString()),
						concepto = reader["concepto"].ToString(),
						Cliente = reader["cliente"].ToString(),
						subtotal = decimal.Parse(reader["subtotal"].ToString()),
						iva = decimal.Parse(reader["iva"].ToString()),
						total = decimal.Parse(reader["total"].ToString()),
					};

					sqlCmd.Parameters.Clear();
					sqlCmd.CommandText = "SELECT * FROM ventasDetalles WHERE ventaId = @ventaId";
					sqlCmd.Parameters.AddWithValue("@ventaId", venta.ventaId);
					reader = sqlCmd.ExecuteReader();
					if (reader.HasRows) {
						while (reader.Read()) {
							venta.VentasDetalles.Add(new VentaDetalle() {
								ventaId = Guid.Parse(reader["ventaId"].ToString()),
								productoId = Guid.Parse(reader["productoId"].ToString()),
								cantidadVendido = decimal.Parse(reader["cantidadVendido"].ToString()),
								precioProducto = decimal.Parse(reader["precioProducto"].ToString()),
								total = decimal.Parse(reader["total"].ToString()),
							});
						}
					}
				}
			}

			return venta;
		}
	}
}
