using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PatronRepositorio.Repositorios;
using PatronRepositorio.Entidades;

namespace PatronRepositorio
{
    class Program
    {
        static void Main(string[] args)
        {

            RepositorioSQLServerPersona personas = new RepositorioSQLServerPersona();
            personas.Agregar(new Persona() {
                nombres = "Jose",
                apellidos = "Perez",
                genero = "M",
                fechaNacimiento = "31/12/90",
            });
            Console.WriteLine("Agregado!!!!!");

            /*personas.Editar(new Persona() {
                PersonaId = Guid.Parse("95C2138A-ABC9-4515-ADEA-E7C22CF2F0EC"),
                nombres = "Michel",
                apellidos = "Traña",
                genero = "M",
                fechaNacimiento = "02/09/1994",
            });
            Console.WriteLine("Editado!!!!");*/

            /*personas.Eliminar(Guid.Parse("95C2138A-ABC9-4515-ADEA-E7C22CF2F0EC"));
            Console.WriteLine("Eliminado!!!!");*/

            Console.WriteLine("LISTADO DE PERSONAS");
            Console.WriteLine("--------------------------------------------------------------");
            personas.Listado().ForEach(c => {
                Console.WriteLine($"{c.nombres}\t{c.apellidos}\t{c.genero}\t{c.fechaNacimiento}");
            });

            Console.ReadKey();

        }
    }
}
