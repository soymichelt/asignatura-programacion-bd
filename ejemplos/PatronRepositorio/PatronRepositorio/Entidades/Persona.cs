using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatronRepositorio.Entidades
{
    public class Persona
    {
        public Guid PersonaId { get; set; }
        public string nombres { get; set; }
        public string apellidos { get; set; }
        public string genero { get; set; }
        public string fechaNacimiento { get; set; }

        public override bool Equals(object obj)
        {
            if (!(obj is Persona)) return false;

            Persona personaCasted = (Persona)obj;

            if (personaCasted.nombres != this.nombres) return false;
            if (personaCasted.apellidos != this.apellidos) return false;
            if (personaCasted.genero != this.genero) return false;
            if (personaCasted.fechaNacimiento != this.fechaNacimiento) return false;

            return true;
        }
    }
}
