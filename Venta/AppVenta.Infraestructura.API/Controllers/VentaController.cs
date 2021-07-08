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
	public class VentaController : ControllerBase {
		// GET: api/<VentaController>
		[HttpGet]
		public ActionResult<IEnumerable<Venta>> Get() {
			VentaRepositorio repositorio = new VentaRepositorio();
			VentaServicio servicio = new VentaServicio(repositorio);

			return Ok(servicio.Listar());
		}

		// GET api/<VentaController>/5
		[HttpGet("{id}")]
		public ActionResult<Venta> Get(Guid id) {
			VentaRepositorio repositorio = new VentaRepositorio();
			VentaServicio servicio = new VentaServicio(repositorio);

			return Ok(servicio.SeleccionarPorID(id));
		}

		// POST api/<VentaController>
		[HttpPost]
		public ActionResult<Venta> Post([FromBody] Venta venta) {
			VentaRepositorio repositorio = new VentaRepositorio();
			VentaServicio servicio = new VentaServicio(repositorio);

			var resultado = servicio.Agregar(venta);

			return Ok(new Venta() {
				ventaId = resultado.ventaId,
				numeroVenta = resultado.numeroVenta,
				fecha = resultado.fecha,
				concepto = resultado.concepto,
				subtotal = resultado.total,
				descuento = resultado.descuento,
				impuesto = resultado.impuesto,
				total = resultado.total,
				anulado = resultado.anulado,
			});
		}

		// DELETE api/<VentaController>/5
		[HttpDelete("{id}")]
		public ActionResult Delete(Guid id) {
			VentaRepositorio repositorio = new VentaRepositorio();
			VentaServicio servicio = new VentaServicio(repositorio);

			servicio.Anular(id);

			return Ok("Anulado correctamente");
		}
	}
}
