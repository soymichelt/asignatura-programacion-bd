using System;
using System.Collections.Generic;
using System.Text;

namespace AppRRHH.Dominio {
	public class Empleado {

		public Guid empleadoId { get; set; }

		public string nombres { get; set; }

		public string apellidos { get; set; }

		public string area { get; set; }

		public decimal salario { get; set; }

		public Boolean activo { get; set; }

	}
}
