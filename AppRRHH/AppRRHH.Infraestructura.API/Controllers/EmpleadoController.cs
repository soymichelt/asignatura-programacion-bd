using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using AppRRHH.Dominio;
using AppRRHH.Aplicaciones.Servicios;
using AppRRHH.Infraestructura.Datos.Repositorios;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AppRRHH.Infraestructura.API.Controllers {
	[Route("api/[controller]")]
	[ApiController]
	public class EmpleadoController : ControllerBase {

		EmpleadoServicio CrearServicio() {
			EmpleadoRepositorio repo = new EmpleadoRepositorio();
			EmpleadoServicio servicio = new EmpleadoServicio(repo);
			return servicio;
		}

		// GET: api/<EmpleadoController>
		[HttpGet]
		public ActionResult<List<Empleado>> Get() {
			var servicio = CrearServicio();
			return Ok(servicio.Listar());
		}

		// GET api/<EmpleadoController>/5
		[HttpGet("{id}")]
		public ActionResult<Empleado> Get(Guid id) {
			EmpleadoRepositorio repo = new EmpleadoRepositorio();
			return Ok(repo.SeleccionarPorID(id));
		}

		// POST api/<EmpleadoController>
		[HttpPost]
		public ActionResult Post([FromBody] Empleado entidad) {
			var servicio = CrearServicio();
			servicio.Agregar(entidad);
			return Ok("Guardado correctamente!!!!!!");
		}

		// PUT api/<EmpleadoController>/5
		[HttpPut("{id}")]
		public ActionResult Put(Guid id, [FromBody] Empleado entidad) {
			var servicio = CrearServicio();
			entidad.empleadoId = id;
			servicio.Editar(entidad);
			return Ok("Editar satisfactoriamente!!!!");
		}

		// DELETE api/<EmpleadoController>/5
		[HttpDelete("{id}")]
		public ActionResult Delete(Guid id) {
			var servicio = CrearServicio();
			servicio.Eliminar(id);
			return Ok("Eliminado debidamente!!!!!!!");
		}
	}
}
