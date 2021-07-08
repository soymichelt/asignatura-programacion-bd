using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using AppVenta.Dominio;
using AppVenta.Infraestructura.Datos.Repositorios;
using AppVenta.Aplicaciones.Servicios;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AppVenta.Infraestructura.API.Controllers {
	[Route("api/[controller]")]
	[ApiController]
	public class ProductoController : ControllerBase {

		// GET: api/<ProductoController>
		[HttpGet]
		public ActionResult<IEnumerable<Producto>> Get() {
			ProductoRepositorio repositorio = new ProductoRepositorio();
			ProductoServicio servicio = new ProductoServicio(repositorio);

			return Ok(servicio.Listar());
		}

		// GET api/<ProductoController>/5
		[HttpGet("{id}")]
		public ActionResult<Producto> Get(Guid id) {
			ProductoRepositorio repositorio = new ProductoRepositorio();
			ProductoServicio servicio = new ProductoServicio(repositorio);

			return Ok(servicio.SeleccionarPorID(id));
		}

		// POST api/<ProductoController>
		[HttpPost]
		public ActionResult<Producto> Post([FromBody] Producto producto) {
			ProductoRepositorio repositorio = new ProductoRepositorio();
			ProductoServicio servicio = new ProductoServicio(repositorio);

			var resultado = servicio.Agregar(producto);

			return Ok(resultado);
		}

		// PUT api/<ProductoController>/5
		[HttpPut("{id}")]
		public ActionResult Put(Guid id, [FromBody] Producto producto) {
			ProductoRepositorio repositorio = new ProductoRepositorio();
			ProductoServicio servicio = new ProductoServicio(repositorio);

			producto.productoId = id;

			servicio.Editar(producto);

			return Ok("Editado exitosamente");
		}

		// DELETE api/<ProductoController>/5
		[HttpDelete("{id}")]
		public ActionResult Delete(Guid id) {
			ProductoRepositorio repositorio = new ProductoRepositorio();
			ProductoServicio servicio = new ProductoServicio(repositorio);

			servicio.Eliminar(id);

			return Ok("Eliminado exitosamente");
		}
	}
}
