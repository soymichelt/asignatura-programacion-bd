using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

using PatronRepositorio.Helpers;
using PatronRepositorio.Entidades;

namespace PatronRepositorio.Repositorios {
	public class ProductoRepositorioSQLServer : IRepositorio<Producto, Guid> {

		SqlCommand sqlCmd;

		public Producto Agregar(Producto entidad) {
			entidad.productoId = Guid.NewGuid();

			sqlCmd = new SqlCommand($"INSERT INTO productos (productoId, nombre, descripcion, cantidad, precio) VALUES ('{entidad.productoId}', '{entidad.nombre}', '{entidad.descripcion}', {entidad.cantidad}, {entidad.precio})");
			SqlConnection cnn = SqlServerHelper.Connection();
			sqlCmd.Connection = cnn;
			cnn.Open();
			sqlCmd.ExecuteNonQuery();
			return entidad;
		}

		public Producto Editar(Producto entidad) {
			sqlCmd = new SqlCommand($"UPDATE productos SET nombre = '{entidad.nombre}', descripcion = '{entidad.descripcion}', cantidad = {entidad.cantidad}, precio = {entidad.precio} WHERE productoId = '{entidad.productoId}'");
			SqlConnection cnn = SqlServerHelper.Connection();
			sqlCmd.Connection = cnn;
			cnn.Open();
			sqlCmd.ExecuteNonQuery();
			return entidad;
		}

		public void Eliminar(Guid productoId) {
			sqlCmd = new SqlCommand($"Delete From productos Where productoId = '{productoId}'");
			SqlConnection cnn = SqlServerHelper.Connection();
			sqlCmd.Connection = cnn;
			cnn.Open();
			sqlCmd.ExecuteNonQuery();
		}

		public List<Producto> Listar() {
			sqlCmd = new SqlCommand($"Select * From productos");
			SqlConnection cnn = SqlServerHelper.Connection();
			sqlCmd.Connection = cnn;
			cnn.Open();
			SqlDataReader reader = sqlCmd.ExecuteReader();

			List<Producto> productos = new List<Producto>();
			if (reader.HasRows) {
				while (reader.Read()) {
					productos.Add(new Producto() {
						productoId = Guid.Parse(reader["productoId"].ToString()),
						nombre = reader["nombre"].ToString(),
						descripcion = reader["descripcion"].ToString(),
						cantidad = decimal.Parse(reader["cantidad"].ToString()),
						precio = decimal.Parse(reader["precio"].ToString())
					});
				}
			}

			return productos;
		}

		public Producto Seleccionar(Guid tipoId) {
			sqlCmd = new SqlCommand($"Select * From productos");
			SqlConnection cnn = SqlServerHelper.Connection();
			sqlCmd.Connection = cnn;
			cnn.Open();
			SqlDataReader reader = sqlCmd.ExecuteReader();

			Producto producto = null;
			if (reader.HasRows) {
				if (reader.Read()) {
					producto = new Producto() {
						productoId = Guid.Parse(reader["productoId"].ToString()),
						nombre = reader["nombre"].ToString(),
						descripcion = reader["descripcion"].ToString(),
						cantidad = decimal.Parse(reader["cantidad"].ToString()),
						precio = decimal.Parse(reader["precio"].ToString())
					};
				}
			}

			return producto;
		}
	}
}
